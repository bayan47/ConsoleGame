using System.Collections.Generic;



namespace sample1
{
    
    static internal class Player
    {
        static internal Vector2 start_pos = new Vector2(15,10);
        static internal Curses window;


       
        
        static internal Object character = new Object(new PlayerModel().model,start_pos,false);

      
        static internal void CheckActions(int keycode)

        {
            
            if (keycode == 100 ) // стрелочка вправо
            {
                character.Move(Vector2.right);
            } 
            if (keycode == 97) // стрелочка влево
            {
                character.Move(Vector2.left);
            } 
            if (keycode == 119 || keycode ==32) // стрелочка вверх
            {
                character.Move(Vector2.up*6);
            } 
            if (keycode == 115) // стрелочка вниз
            {
                character.Move(Vector2.down);
            } 


              if (keycode == 10) // Enter справа
            {
                foreach(Object obj in Program.objects)
                {
                Collision.BoundingBox.ShowBox(obj.boundingBox);
                }
                Program.c.Print(5,1,Program.objects[5].boundingBox.lines.Count.ToString());
            }
            
        }

    }

}