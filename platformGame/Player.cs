using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using SharpDX.Direct3D9;
using System.Collections.Generic;

namespace platformGame
{
    internal class Player : GameObjects
    {
        
        Vector2 position;
        public Vector2 velocity;
        public bool hasJumped;
        public Rectangle playerRec;
      

        public Player (Rectangle rect) : base (rect)
        {
            tex = Assests.playerTex;  
            hasJumped = true;
            velocity = new Vector2(0, 0);
            position = new Vector2(rect.X, rect.Y);      

        }
        
        

        public void Update(GameTime gametTime, List<Platform>platforms)
        {
            playerRec = new Rectangle((int)(position.X), (int)(position.Y), tex.Width, tex.Height);

            

            if (KeyMouseReader.KeyPressed(Keys.Right)) velocity.X = 2f;
            else if (KeyMouseReader.KeyPressed(Keys.Left)) velocity.X = -2f; //else velocity.X = 0f;

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

            Vector2 newPos = (position + velocity);
            Rectangle newRec = new Rectangle ((int)newPos.X, (int)newPos.Y, tex.Width, tex.Height);

            bool hasCollided = false;



            foreach (Platform p in platforms)
            {
                if (newRec.Intersects(p.tileRect))
                {
                    velocity = Vector2.Zero;
                    hasJumped = false;
                    hasCollided = true;
                }



            }
            
            if (hasCollided == true)
            {
                hasJumped = true;
                velocity.Y = -5f;
            }

            position += velocity;

            /*if (position.Y + tex.Height >= 440)
                hasJumped = false;

            if (hasJumped == false)
                velocity.Y = 0f;*/






        }


        public override void Draw (SpriteBatch sb)
        {

            sb.Draw(tex, position, Color.White);
        }
    }
}
