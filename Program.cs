using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace sample1
{

    class Program
    {
      static internal Curses c = new Curses();
        static internal List<Object> objects;
      static internal Vector2 debug_point = new Vector2(1,1);
      static internal int screen_x = 0; // Ширина консольного окна
      static internal int screen_y = 0; // Высота консольного окна
      static internal Stopwatch stopwatch;
      static internal bool gameover;
      static internal long deltasec =0; // Начало времени
      static internal TimeAction time;
      static internal TimeAction grav;
      static internal TimeAction addscore;





        static internal void Main(string[] args)
        {
            gameover = false;
            objects = new List<Object>();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            
            c.noEcho();
            c.SetCursorMode(0);
            c.NoDelay(true);
            UpdateScreenSize(out screen_x,out screen_y);

            Player.CreatePlayer(true);
            
           // Object box = new Object(new Box().model,new Vector2(5,5),false);
            c.Refresh();
            Player.window = c;
            //Object box2 = new Object(new Box2().model,new Vector2(25,8),false);

            FillCorners();
            time = new TimeAction();
            grav = new TimeAction();
            addscore = new TimeAction();

           
            
            while (Player.lives>0)
            {
                deltasec = stopwatch.ElapsedMilliseconds;
                c.Refresh();
                Player.ShowLives();
                Player.ShowScores();
                Player.CheckActions(c.GetKeyDown());
                time.Operation(75,-1,CreateRandomBoxes);
                grav.Operation(25,-1,Gravity);
                addscore.Operation(1000, -1, AddScore);
            }

            GameOver();

        }


        static void AddScore()
        {
            Player.scores++;
        }
        static void GameOver()
        {

            gameover = true;
            foreach (Object obj in objects.ToArray())
            {
                obj.DestroyObject();
            }
            c.Clear();
            c.Print(new Vector2(screen_x / 2, screen_y / 2), "Game Over");
            c.Print(new Vector2(screen_x / 2, screen_y / 2 + 1), "Scores:"+Player.scores);
            c.Print(new Vector2(screen_x / 2-2, screen_y / 2+2), "Restart? (Y/N)");
            
            

            while (gameover==true)
            {
                Player.CheckActions(c.GetKeyDown());
            }
        }

        static void CreateRandomBoxes()
        {
            Random rand = new Random();
            
            Object box = new Object(new Box().model,new Vector2(rand.Next(1,screen_x-1),rand.Next(1,10)),false);

        }

        static void Gravity()
        {
            foreach (Object obj in objects.ToArray())
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
