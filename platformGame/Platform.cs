using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace platformGame
{
    internal class Platform : GameObjects
    {

        public Rectangle tileRect;
        public Platform(Rectangle rect) : base(rect)
        {
            tex = Assests.platoformTex;
            tileRect = new Rectangle (0 , 0, tex.Width, tex.Height);
        }


        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, Size, Color.White);
        }


    }
}