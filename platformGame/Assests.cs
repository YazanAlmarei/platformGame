using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace platformGame
{
    internal class Assests
    {
        public static Texture2D platoformTex, playerTex, enemyTex;

        public static void LoadTextures(ContentManager gd)
        {
            platoformTex = gd.Load<Texture2D>("floor");
            playerTex = gd.Load<Texture2D>("player");
            enemyTex = gd.Load<Texture2D>("enemy");

        }
    }
}
