using System;
using System.Numerics;

namespace Game10003;

public class TextHelper
{
    public Color textColor = Color.White;
    public Color textBubbleColor = Color.Black;
    Vector2 bubblePosition = new Vector2();

    string lineOneText = string.Empty;
    string lineTwoText = string.Empty;
    string lineThreeText = string.Empty;

    int bubbleRadius = 0;

    public void TextBubble(string position, string text)
    {
        if (position == "bottom")
        {
            bubblePosition = new Vector2(100, 400);
            bubbleRadius = 25;
        }
        else if (position == "middle")
        {
            bubblePosition = new Vector2(100, 250);
            bubbleRadius = 50;
        }
        else
        {
            bubblePosition = new Vector2(100, 100);
            bubbleRadius = 25;
        }

        Draw.FillColor = textBubbleColor;
        Draw.Capsule(bubblePosition, new Vector2(Window.Width - bubblePosition.X, bubblePosition.Y), bubbleRadius);
        Draw.Triangle(Window.Width - bubblePosition.X - 50, bubblePosition.Y + bubbleRadius, Window.Width - bubblePosition.X - 10, bubblePosition.Y + bubbleRadius, Window.Width - bubblePosition.X + 10, bubblePosition.Y + bubbleRadius + 15);

        Text.Color = textColor;



    }
}
