using System.Collections.Generic;

namespace sample1
{
    internal class Blocks: Object
    {
        internal Blocks(List<Entity> model):base(model)
        {

        }

        internal Blocks(List<Entity> model,Vector2 position,bool static_mode):base(model,position,static_mode)
        {
            this.EnableCollision(false);
            
        }
    }
}