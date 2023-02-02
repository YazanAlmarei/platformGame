using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

static class RectangleHelper
{
    const int penetrationMargin = 5;
    public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Bottom >= r2.Top - penetrationMargin &&
            r1.Bottom <= r2.Top + 1 &&
            r1.Right >= r2.Left + 5 &&
            r1.Left <= r2.Right - 5);
    }
}
