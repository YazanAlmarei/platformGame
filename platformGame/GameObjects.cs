using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Security.Cryptography.X509Certificates;

namespace platformGame
{
    internal class GameObjects
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


    }
}
