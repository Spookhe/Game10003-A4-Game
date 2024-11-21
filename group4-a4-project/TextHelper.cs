using System;
using System.Numerics;

namespace Game10003;

public class TextHelper
{
    public Color textColor = Color.White;
    public Color textBubbleColor = new Color(0, 0, 0, 255);

    string lineOneText = string.Empty;
    string lineTwoText = string.Empty;
    string lineThreeText = string.Empty;

    int bubbleRadius = 50;
    int textSize = 28;

    /// <summary>
    /// Creates a text bubble at a given position
    /// </summary>
    /// <param name="position"></param>
    /// <param name="text"></param>
    public void TextBubble(string position, string text)
    {
        Vector2 bubblePosition = new Vector2(100, 400);

        // Draw text bubble background
        Draw.FillColor = textBubbleColor;
        Draw.Capsule(bubblePosition, new Vector2(Window.Width - bubblePosition.X, bubblePosition.Y), bubbleRadius);
        Draw.Triangle(Window.Width - bubblePosition.X - 50, bubblePosition.Y + bubbleRadius, Window.Width - bubblePosition.X - 10, bubblePosition.Y + bubbleRadius, Window.Width - bubblePosition.X + 10, bubblePosition.Y + bubbleRadius + 15);

        Text.Color = textColor;
        Text.Size = textSize;

        // Handle one line of text
        if (text.Length < 42)
        {
            bubbleRadius = 25;
            for (int i = 0; i < text.Length; i++)
            {
                if (lineOneText.Length < text.Length)
                {
                    lineOneText += text[i];
                }
            }
        }
        // Handle two lines of text
        else if (text.Length > 42)
        {
            bubbleRadius = 50;
            for (int i = 0; i < text.Length; i++)
            {
                if (lineOneText.Length < 42)
                {
                    lineOneText += text[i];
                }

                if (lineTwoText.Length < text.Length - 42 && i >= 42)
                {
                    lineTwoText += text[i];
                }
            }
        }

        // Draw text over the text bubble
        Text.Draw(lineOneText, bubblePosition.X, bubblePosition.Y - (bubbleRadius / 2));
        Text.Draw(lineTwoText, bubblePosition.X, bubblePosition.Y - (bubbleRadius / 2) + 25);
    }

    // Reset text lines to an empty string
    public void ResetText(Color newBubbleColor)
    {
        lineOneText = string.Empty;
        lineTwoText = string.Empty;
        lineThreeText = string.Empty;
        textColor = Color.White;
        textBubbleColor = newBubbleColor;
    }

    // Hide text bubble 
    public void HideBubble()
    {
        textColor = Color.Clear;
        textBubbleColor = Color.Clear;
    }
}
