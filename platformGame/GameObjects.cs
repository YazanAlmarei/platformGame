using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Security.Cryptography.X509Certificates;

namespace platformGame
{
    abstract class GameObjects
    {
        protected Rectangle size;
        protected Texture2D tex;
        
        public Rectangle Size
        {
            get { return size; }
        }

        public GameObjects(Rectangle rect)
        {
            size = rect;
            
        }

        

        public abstract void Draw(SpriteBatch spriteBatch);


    }
}
