namespace sample1
{
    internal class Entity
    {
        private string _content;
        private Vector2 _position;
        private Vector2 _world_position;

        
        internal Entity(string Content, Vector2 Position)
        {
            content = Content;
            position = Position;
            world_position = Position;
        }

        internal string content
        {
            get
            {
                return _content;
            }

            set
            {
                _content = value;
            }
        }

        internal Vector2 position
        {
            get
            {
                return _position;
            }
            set{
                _position = value;
            }
        }

        internal Vector2 world_position
        {
            get{
                return _world_position;
            }
            set{
                _world_position = value;
            }
        }

    }

    

}