using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OpenAIIttenaryManager.CustomCOntrols
{

    public class RoundedButton : Button
    {
        // Rounded radius property
        public int BorderRadius { get; set; } = 20;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Set up the drawing
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent.BackColor); // Clear the background to match the parent

            // Create a path with rounded corners
            GraphicsPath path = new GraphicsPath();
            path.AddArc(new Rectangle(0, 0, BorderRadius, BorderRadius), 180, 90);
            path.AddArc(new Rectangle(Width - BorderRadius, 0, BorderRadius, BorderRadius), 270, 90);
            path.AddArc(new Rectangle(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius), 0, 90);
            path.AddArc(new Rectangle(0, Height - BorderRadius, BorderRadius, BorderRadius), 90, 90);
            path.CloseFigure();

            // Fill the button with color
            e.Graphics.FillPath(new SolidBrush(this.BackColor), path);

            // Draw the text on the button
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

            // Optionally, draw a border
            using (Pen pen = new Pen(this.ForeColor, 1.75F))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}
