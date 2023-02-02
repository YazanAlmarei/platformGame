using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace platformGame
{
    internal class Player : GameObjects
    {
        public Player (Rectangle rect) : base (rect)
        {
            tex = Assests.playerTex;
        }

        public void Update()
        {

        }


        public void Draw (SpriteBatch sb)
        {
            sb.Draw(tex, size, Color.White);
        }
    }
}
