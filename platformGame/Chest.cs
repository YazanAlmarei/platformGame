using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using SharpDX.Direct3D9;

namespace platformGame
{
    internal class Chest : GameObjects
    {
        public Rectangle chestRec;
        public Vector2 position;

        public Chest(Rectangle rect) : base(rect)
        {
            tex = Assests.chestTex;
            position = new Vector2(rect.X, rect.Y);
        }
        public void Update()
        {
            chestRec = new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);
        }



        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, size, Color.White);
        }


    }
}
