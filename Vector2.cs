namespace sample1
{
    internal class Vector2
    {
        private int X;
        private int Y;
        internal Vector2(int xpos,int ypos)

        {
            X = xpos;
            Y = ypos;
        }

        static internal Vector2 zero = new Vector2(0,0);
        static internal Vector2 up = new Vector2(0,-1);

        static internal Vector2 down = new Vector2(0,1);

        static internal Vector2 left = new Vector2(-1,0);

        static internal Vector2 right = new Vector2(1,0);

        public int x
        {
                get
                {
                    return X;
                }
                set
                {
                    X = value;
                }
        }

        public int y
        {
                get
                {
                    return Y;
                }
                set
                {
                    Y = value;
                }
        }

        static public Vector2 operator +(Vector2 vec1,Vector2 vec2)
        {
            return new Vector2(vec1.x+vec2.x,vec1.y+vec2.y);
        }

        static public Vector2 operator -(Vector2 vec1,Vector2 vec2)
        {
            return new Vector2(vec1.x-vec2.x,vec1.y-vec2.y);
        }

        static public bool operator ==(Vector2 vec1,Vector2 vec2)
        {
            if (vec1.x==vec2.x && vec1.y==vec2.y)
            {
            return true;
            }
            return false;
        }

        static public bool operator !=(Vector2 vec1,Vector2 vec2)
        {
            if (vec1.x!=vec2.x || vec1.y!=vec2.y)
            {
            return true;
            }
            return false;
        }

        static public Vector2 operator *(Vector2 vec1,Vector2 vec2)
        {
 
            return new Vector2(vec1.x*vec2.x,vec1.y*vec2.y);
        }

        static public Vector2 operator *(Vector2 vec1,int z)
        {
 
            return new Vector2(vec1.x*z,vec1.y*z);
        }

        
    }

}