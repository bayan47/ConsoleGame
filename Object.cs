using System.Collections.Generic;



namespace sample1
{
    internal class Object
    {
        internal List<Entity> _model;
        internal int id;
        internal bool is_static;
        internal Vector2 _position;
        
        internal Collision.BoundingBox boundingBox;

            internal Object(List<Entity> model,Vector2 position,bool static_mode)
        {
            _model = model;
            _position = position;
            is_static = static_mode;
            boundingBox = Collision.BoundingBox.UpdateBoundingBox(model);
            Program.objects.Add(this);
            id = Program.objects.LastIndexOf(this);
            Program.objects[id].id = id;
            Draw();
            
        }


        ~Object(){
            Erase();
        }

           internal Object(List<Entity> model)
        {
            _model = model;
            Program.objects.Add(this);
            id = Program.objects.LastIndexOf(this);
            Program.objects[id].id = id;
        }

        internal void EnableCollision(bool mode)
        {
            if (mode==true)
            {
                this.boundingBox = Collision.BoundingBox.UpdateBoundingBox(this._model);
            }
            else
            {
                this.boundingBox = null;
            }
        }


        internal void EnableStaticMode(bool mode)
        {
            if (mode==true)
            {
                this.is_static = true;
            }
            else
            {
                this.is_static = false;
            }
        }

        internal void Draw()
        {
            foreach(Entity entity in _model)
            {
                entity.world_position = entity.position + _position;
                Program.c.Print(entity);
            }
            boundingBox = Collision.BoundingBox.UpdateBoundingBox(_model);
            boundingBox.FillCorners();
            
        }

         internal void Erase()

        {
            foreach(Entity entity in _model)
            {
                Program.c.Print(new Entity(" ",entity.world_position));
            }
        }

        internal void Fall()
        {
            if (this._position.y!=-1 && this.is_static==false)
            {
                this.Move(Vector2.down);
            }
        }
         internal void Move(Vector2 direction)
        {

            _position = _position + direction;
           
            for (int n=0;n!=this.boundingBox.lines.Count;n++) //для каждой линии
            {
                    for (int z=0;z!=this.boundingBox.lines[n].dots.Count;z++) //для каждой точки
                    {
                            Collision.Ray ray = new Collision.Ray(this.boundingBox.lines[n].dots[z],this.boundingBox.lines[n].dots[z]+direction,this);

                            if(ray.Cast())
                            {
                                _position = _position-direction;
                                ray = null;
                                return;
                            }
                            ray = null;

                    }
            }
            
            
            Erase();
            Draw();
        }

    }
}