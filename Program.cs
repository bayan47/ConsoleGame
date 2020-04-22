using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace sample1
{

    class Program
    {
      static internal Curses c;
      static internal List<Object> objects = new List<Object>();
      static internal Vector2 debug_point = new Vector2(1,1);
      static internal int screen_x = 0; // Ширина консольного окна
      static internal int screen_y = 0; // Высота консольного окна
      
      static internal long deltasec =0;
      


         static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            
            c = new Curses();
            c.noEcho();
            c.SetCursorMode(0);
            c.NoDelay(true);
            UpdateScreenSize(out screen_x,out screen_y);
            
            Object box = new Object(new Box().model,new Vector2(5,5),false);
            c.Refresh();
            Player.window = c;
            Object box2 = new Object(new Box2().model,new Vector2(25,8),false);

            FillCorners();
            TimeAction time = new TimeAction();
            TimeAction grav = new TimeAction();
           
            
            while (true)
            {
                deltasec = stopwatch.ElapsedMilliseconds;
                c.Refresh();
                Player.CheckActions(c.GetKeyDown());
                PrintDebug(deltasec.ToString());
                time.Operation(300,10000,CreateRandomBoxes);
                grav.Operation(50,-1,Gravity);

            }


        }

        static void CreateRandomBoxes()
        {
            Random rand = new Random();
            
            Object box = new Object(new Box().model,new Vector2(rand.Next(1,screen_x-1),5),false);

        }

        static void Gravity()
        {
            foreach (Object obj in objects)
            {
                obj.Fall();
            }
        }

        static void UpdateScreenSize(out int x, out int y)
        {
            x = Console.WindowWidth;
            y = Console.WindowHeight;
        }

        static internal void PrintDebug(string message)
        {
            c.Print(debug_point,message);
        }

        /// <summary>
        /// Заполнить поля по краям терминального окна
        /// </summary>
        static void FillCorners()
        {
            Object upline = new Object(new BorderLine.HorizontalLine().model,Vector2.zero,true );
            Object downline = new Object(new BorderLine.HorizontalLine().model,new Vector2(0,Program.screen_y-1),true);
            Object left = new Object(new BorderLine.VerticalLine().model,Vector2.zero,true);
            Object right = new Object(new BorderLine.VerticalLine().model,new Vector2(Program.screen_x-1,0),true);
            
        }

        
    }
}
