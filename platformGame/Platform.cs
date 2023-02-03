using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using SharpDX.Direct3D9;

namespace platformGame
{
    internal class Platform : GameObjects
    {

        public Rectangle tileRect;
        public Vector2 position;
        public Platform(Rectangle rect) : base(rect)
        {
            tex = Assests.platoformTex;
            
            position = new Vector2(rect.X, rect.Y);
            Update();
            
        }

        public void Update()
        {
            tileRect = new Rectangle((int)(position.X), (int)(position.Y), tex.Width, tex.Height);

        }


        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, Size, Color.White);
        }


    }
}