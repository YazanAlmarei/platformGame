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
        public Vector2 gravity;
        public Rectangle playerRec;


        public bool hasJumped = true;
        public bool isFalling = true;

        public Player(Rectangle rect) : base(rect)
        {
            tex = Assests.playerTex;
            velocity = new Vector2(0, 0);
            position = new Vector2(rect.X, rect.Y);
            gravity = new Vector2(0, 1f);
        }

        public void Update(GameTime gameTime, List<Platform> platforms)
        {
            playerRec = new Rectangle((int)(position.X), (int)(position.Y), tex.Width, tex.Height);

            if (KeyMouseReader.KeyPressed(Keys.Right))
            {
                velocity.X = 4f;
            }
            else if (KeyMouseReader.KeyPressed(Keys.Left))
            {
                velocity.X = -4f;
            }

            if (KeyMouseReader.KeyPressed(Keys.Space) && !hasJumped && !isFalling)
            {
                velocity.Y = -12f;
                hasJumped = true;
                isFalling = true;
            }

            if (isFalling)
            {
                velocity += gravity * 0.5f;
            }

            Vector2 newPos = position + velocity + gravity;
            Rectangle newRec = new Rectangle((int)(newPos.X), (int)(newPos.Y), tex.Width, tex.Height);

            float newXPos = UpdateXComponent(newRec, platforms);
            float newYPos = UpdateYComponent(newRec, platforms);

            position = new Vector2(newXPos, newYPos);
        }

        public float UpdateXComponent(Rectangle newRec, List<Platform> platforms)
        {
            // Fix the X coordinate collision
            foreach (Platform p in platforms)
            {
                if (newRec.Intersects(p.tileRect))
                {
                    return position.X;
                }
            }

            return newRec.X;
        }

        public float UpdateYComponent(Rectangle newRec, List<Platform> platforms)
        {
            // Y component collision
            foreach (Platform p in platforms)
            {
                if (newRec.Intersects(p.tileRect))
                {
                    isFalling = false;
                    hasJumped = false;
                    velocity.Y = 0;
                    return p.tileRect.Y - p.tileRect.Height - gravity.Y;
                }
            }

            isFalling = true;

            return newRec.Y;
        }


        public override void Draw(SpriteBatch sb)
        {

            sb.Draw(tex, position, Color.White);
        }
    }
}
