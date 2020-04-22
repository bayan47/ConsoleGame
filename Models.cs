using System.Collections.Generic;

namespace sample1

{
     internal class Models

    {
         internal List<Entity> model = new List<Entity>();

    }

    internal class Box:Models
    {
        
        internal Box()
        {
            model.Add(new Entity("@",new Vector2(0,0)));
            model.Add(new Entity("@",new Vector2(0,1)));
            model.Add(new Entity("@",new Vector2(1,0)));
            model.Add(new Entity("@",new Vector2(1,1)));
        }


    }

    internal class BorderLine:Models
    {
        
        internal class UpperLine:BorderLine
        {

        }

        internal class HorizontalLine:BorderLine
        {
            internal HorizontalLine()
            {
                for(int x1=0;x1<Program.screen_x-1;x1++)
                {
                    model.Add(new Entity(Symbols.border,new Vector2(x1,0)));

                }
            }
        }

        internal class VerticalLine:BorderLine
        {
            internal VerticalLine()
            {
                for(int y1=0;y1<Program.screen_y-1;y1++)
                {
                    model.Add(new Entity(Symbols.border,new Vector2(0,y1)));

                }
            }
        }

    }

    internal class Box2:Models
    {
            internal Box2()
        {
            model.Add(new Entity("@",new Vector2(0,0)));
            model.Add(new Entity("@",new Vector2(0,1)));
            model.Add(new Entity("@",new Vector2(0,2)));
            model.Add(new Entity("@",new Vector2(1,0)));
            model.Add(new Entity("@",new Vector2(1,1)));
            model.Add(new Entity("@",new Vector2(1,2)));
        }
    }

    internal class PlayerModel: Models
    {
        internal PlayerModel()
        {
            model.Add(new Entity(Symbols.star,new Vector2(0,0)));                
            model.Add(new Entity(Symbols.star,new Vector2(1,0)));                
            model.Add(new Entity(Symbols.star,new Vector2(-1,1)));
            model.Add(new Entity(Symbols.star,new Vector2(0,1)));
            model.Add(new Entity(Symbols.star,new Vector2(1,1)));
            model.Add(new Entity(Symbols.star,new Vector2(2,1)));
            model.Add(new Entity(Symbols.star,new Vector2(-1,2)));
            model.Add(new Entity(Symbols.star,new Vector2(0,2)));
            model.Add(new Entity(Symbols.star,new Vector2(1,2)));
            model.Add(new Entity(Symbols.star,new Vector2(2,2)));
            model.Add(new Entity(Symbols.star,new Vector2(0,3)));
            model.Add(new Entity(Symbols.star,new Vector2(1,3)));
            model.Add(new Entity(Symbols.star,new Vector2(0,4)));
            model.Add(new Entity(Symbols.star,new Vector2(1,4)));
            model.Add(new Entity(Symbols.star,new Vector2(0,5)));
            model.Add(new Entity(Symbols.star,new Vector2(1,5)));
        }
    }

}