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
    /// Creates a text bubble at a given position on screen; "bottom", "middle", "top"
    /// </summary>
    /// <param name="position"></param>
    /// <param name="text"></param>
    public void TextBubble(string text)
    {
        Vector2 bubblePosition = new Vector2(100, 100);

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
            for (int textIndex = 0; textIndex < text.Length; textIndex++)
            {
                if (lineOneText.Length < text.Length)
                {
                    lineOneText += text[textIndex];
                }
            }
        }
        // Handle two lines of text
        else if (text.Length > 42 && text.Length < 82)
        {
            bubbleRadius = 50;
            for (int textIndex = 0; textIndex < text.Length; textIndex++)
            {
                if (lineOneText.Length < 42)
                {
                    lineOneText += text[textIndex];
                }

                if (lineTwoText.Length < text.Length - 42 && textIndex >= 42)
                {
                    lineTwoText += text[textIndex];
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