using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using SharpDX.Direct3D9;

namespace platformGame
{
    internal class Enemy : GameObjects
    {
        public Rectangle enemyRec;
        public Vector2 position;

        public Enemy(Rectangle rect) : base(rect)
        {
            tex = Assests.enemyTex;
            position = new Vector2(rect.X, rect.Y);
        }
        public void Update()
        {
            enemyRec = new Rectangle((int)position.X, (int)position.Y, tex.Width, tex.Height);

        }



        public override void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, size, Color.White);
        }



    }
}
