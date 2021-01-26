using System.Collections.Generic;



namespace sample1
{
    
    static internal class Player
    {
        static internal Vector2 start_pos = new Vector2(15,10);
        static internal Curses window;
        static internal int scores = 0;
        static internal int lives=3;




        static internal Object character; 

        static internal void CreatePlayer(bool wReady)
        {
            if (wReady)
            {
                character = new Object(new PlayerModel().model, start_pos, false);
                character.eraseble = false;
            }
        }

        static internal void ShowLives()
        {
            Program.c.Print(1, 1, "Lives:" + lives);
        }
        static internal void ShowScores()
        {
            Program.c.Print(9, 1, "Scores:" + scores);
        }
      
        static internal void CheckActions(int keycode)

        {
            if (Program.gameover == false)
            {

                if (keycode == 100) // стрелочка вправо
                {
                    character.Move(Vector2.right);
                }
                if (keycode == 97) // стрелочка влево
                {
                    character.Move(Vector2.left);
                }


                if (keycode == 10) // Enter справа
                {
                    foreach (Object obj in Program.objects)
                    {
                        Collision.BoundingBox.ShowBox(obj.boundingBox);
                    }
                    Program.c.Print(5, 1, Program.objects[5].boundingBox.lines.Count.ToString());
                }
            }

              if (Program.gameover==true)
            {
                if (keycode == 121) // стрелочка вниз
                {
                    Program.stopwatch = null;
                   // Program.c = null;
                    Program.objects = null;
                    Program.time = null;
                    Program.grav = null;
                    Program.deltasec = 0;
                    Player.lives = 3;
                    Program.c.Clear();
                    scores = 0;
                    Program.Main(null);


                }
                if (keycode == 110) // стрелочка вниз
                {
                    System.Environment.Exit(0);
                }
            }
            
        }

    }

}