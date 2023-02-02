using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace platformGame
{
    internal class Player : GameObjects
    {
        
        Vector2 position;
        Vector2 velocity;
        bool hasJumped;


        public Player (Rectangle rect) : base (rect)
        {
            tex = Assests.playerTex;  
            hasJumped = true;
        }
        
        

        public void Update(GameTime gametime)
        {
            position += velocity;

            if (Keyboard.GetState().IsKeyDown(Keys.Right)) velocity.X = 3f;
            else if (Keyboard.GetState().IsKeyDown(Keys.Left)) velocity.X = -3f; else velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && hasJumped == false)
            {
                position.Y -= 10f;
                velocity.Y = -5f;
                hasJumped = true;
            }

            if (hasJumped == true)
            {
                float i = 1;
                velocity.Y += 0.15f * i;
            }

            if (position.Y + tex.Height >= 450)
                hasJumped = false;

            if (hasJumped == false)
                velocity.Y = 0f;

        }


        public void Draw (SpriteBatch sb)
        {
            sb.Draw(tex, size, Color.White);
        }
    }
}
