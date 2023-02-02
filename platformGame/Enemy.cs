using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace platformGame
{
    internal class Enemy : GameObjects
    {
        public Enemy(Rectangle rect) : base(rect)
        {
            tex = Assests.enemyTex;
        }

        public void Update()
        {

        }



        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, size, Color.White);
        }



    }
}
