using System.Collections.Generic;

namespace sample1
{
    internal class Collision
    {


         internal class Ray : Line
        {
            internal Vector2 hit_point;
            Object _origin;

            internal void ShowRay()
            {
                Program.PrintDebug(dots.Count.ToString());
                foreach (Vector2 dot in dots)
                {
                    Program.c.Print(dot,Symbols.ray);
                }
            }

            internal Ray(Vector2 start,Vector2 end, Object origin)
            {
                _start = start;
                _end = end;
                _origin = origin;
                CreateDots();
            }

            internal bool Cast()
            {
 
                foreach (Object obj in Program.objects) // для каждого объекта в списке объектов на сцене
                {
                    if (obj.id!=_origin.id) // если ид текущего объекта не совпадает с очередным
                    {
                        for (int n=0;n<obj.boundingBox.lines.Count;n++) // для каждой граничащей линии объекта
                        {
                            for (int z=0;z<obj.boundingBox.lines[n].dots.Count;z++) // для каждой граничащей точки линии
                            {
                                    for (int y=0; y<dots.Count;y++) // для каждой точки луча
                                    {
                                        if (dots[y].x == obj.boundingBox.lines[n].dots[z].x && dots[y].y == obj.boundingBox.lines[n].dots[z].y)
                                        {
                                            hit_point = new Vector2(dots[y].x,dots[y].y);
                                            return true;
                                        }
                                    }
                                
                            }
                            
                        }
                    }
                }

                return false;
            }
        }
        internal class Line
        {
            internal List<Vector2> dots = new List<Vector2>();
            internal Vector2 _start;
            internal Vector2 _end;

            internal Line()
            {

            }
            internal Line(Vector2 start, Vector2 end) // вертикальные и горизонтальные линии
            {

                _start = start;
                _end = end;
                CreateDots();


                

            }

            internal void CreateDots()
            {
                    if (_start.x>_end.x)
                {
                    for (int n=_start.x;n!=_end.x-1;n--)
                    {
                        dots.Add(new Vector2(n,_start.y));
                    }
                }
                 if (_start.x<_end.x)
                {
                    for (int n=_start.x;n!=_end.x+1;n++)
                    {
                        dots.Add(new Vector2(n,_start.y));
                    }
                }


                if (_start.y<_end.y)
                {
                   for (int n=_start.y;n!=_end.y+1;n++)
                    {
                        dots.Add(new Vector2(_start.x,n));
                    }
                }

                 if (_start.y>_end.y)
                {
                   for (int n=_start.y;n!=_end.y-1;n--)
                    {
                        dots.Add(new Vector2(_start.x,n));
                    }
                }
            }

            

                


        }
        internal class BoundingBox
        {
            internal Vector2 _x1;
            internal Vector2 _x2;
            internal Vector2 _x3;
            internal Vector2 _x4;
            internal List<Line> lines = new List<Line>();

            internal List<Vector2> corners = new List<Vector2>();

            internal void FillCorners()
            {
                corners.Clear();
                corners.Add(_x1);
                corners.Add(_x2);
                corners.Add(_x3);
                corners.Add(_x4);
                UpdateLines();
            }
            internal BoundingBox(Vector2 x1, Vector2 x2,Vector2 x3,Vector2 x4)
        {
            _x1 = x1;
            _x2 = x2; 
            _x3 = x3; 
            _x4 = x4;

            FillCorners();

            

        }
            internal void UpdateLines()
            {
                lines.Clear();

                for (int n=0;n!=corners.Count;n++)
                {
                    
                    
                    if (n!=corners.Count-1)
                    {
                        lines.Add(new Line(corners[n],corners[n+1]));
                    }
                    else
                    {
                        lines.Add(new Line(corners[n],corners[0]));
                        break;
                    }
                    
                    
                    
                }
            }

            internal BoundingBox()
            {
                
            }

            internal static BoundingBox UpdateBoundingBox(List<Entity> model)
            {
                int x1 = model[0].world_position.x;
                int x2 = model[0].world_position.x;;
                int y1 = model[0].world_position.y;;
                int y2 = model[0].world_position.y;;

                foreach(Entity entity in model)
                {
                    if(entity.world_position.x<x1)
                    {
                        x1 = entity.world_position.x;
                    }
                    if(entity.world_position.x>x2)
                    {
                        x2 = entity.world_position.x;
                    }
                    if(entity.world_position.y<y1)
                    {
                        y1 = entity.world_position.y;
                    }
                    if(entity.world_position.y>y2)
                    {
                        y2 = entity.world_position.y;
                    }
                }



                return new BoundingBox(new Vector2(x1,y1),new Vector2(x2,y1),new Vector2(x2,y2),new Vector2(x1,y2));
            }

            internal static void ShowBox(BoundingBox box1)
            {

                foreach (Line line in box1.lines)
                {
                    foreach (Vector2 dot in line.dots)
                    {
                        Program.c.Print(dot,Symbols.line_dot);
                    }
                    
                }
                
            }
        }






    }


}