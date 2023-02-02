using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace platformGame
{
    internal class Platform : GameObjects
    {


        public Platform(Rectangle rect) : base(rect)
        {
            tex = Assests.platoformTex;

        }


        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, Size, Color.White);
        }


    }
}
