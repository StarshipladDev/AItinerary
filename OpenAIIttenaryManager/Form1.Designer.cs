using OpenAIIttenaryManager.CustomCOntrols;

namespace OpenAIIttenaryManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.LabelItineraryName = new System.Windows.Forms.Label();
            this.LabelDescriptionText = new System.Windows.Forms.Label();
            this.itineraryNameTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new RoundedButton();
            this.reccomendatiopnButton = new RoundedButton();
            this.updateButton = new RoundedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.reccomendationTextBox = new System.Windows.Forms.RichTextBox();
            this.reccomendatiopnButton.Click += new System.EventHandler(this.reccomendatiopnButton_Click);
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // Set the form's properties
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F); // Updated for better scaling
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 500); // Slightly larger for modern screen resolutions
            this.BackColor = System.Drawing.Color.White; // Clean white background
            this.Font = new System.Drawing.Font("Segoe UI", 10F); // Modern font

            // Add and style controls

            // Label 1
            this.LabelItineraryName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LabelItineraryName.ForeColor = System.Drawing.Color.Black;
            this.LabelItineraryName.Location = new System.Drawing.Point(50, 50); // Consistent padding from the edges
            this.LabelItineraryName.Text = "Ittinerary Name:";
            this.LabelItineraryName.AutoSize = true;

            // Itinerary Name TextBox
            this.itineraryNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.itineraryNameTextBox.Location = new System.Drawing.Point(50, 90);
            this.itineraryNameTextBox.Width = 300; // Consistent width for textboxes

            // Label 2
            this.LabelDescriptionText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.LabelDescriptionText.ForeColor = System.Drawing.Color.Black;
            this.LabelDescriptionText.Location = new System.Drawing.Point(50, 140); 
            this.LabelDescriptionText.Text = "Ittinerary Description:";
            this.LabelDescriptionText.AutoSize = true;

            // Description TextBox
            this.descriptionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.descriptionTextBox.Location = new System.Drawing.Point(50, 180);
            this.descriptionTextBox.Width = 300;
            this.descriptionTextBox.Height = 100; // Larger height for multi-line input

            // Reccomendation TextBox
            this.reccomendationTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reccomendationTextBox.Location = new System.Drawing.Point(50, 300);
            this.reccomendationTextBox.Width = 300;

            // Label 3
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(50, 270);
            this.label3.AutoSize = true;

            // Confirm Button
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.confirmButton.ForeColor = System.Drawing.Color.White;
            this.confirmButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.confirmButton.Location = new System.Drawing.Point(50, 350);
            this.confirmButton.Width = 150;
            this.confirmButton.Height = 40; // Modern button size
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;

            // Reccomendation Button
            this.reccomendatiopnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reccomendatiopnButton.BackColor = System.Drawing.Color.Gray;
            this.reccomendatiopnButton.ForeColor = System.Drawing.Color.White;
            this.reccomendatiopnButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.reccomendatiopnButton.Location = new System.Drawing.Point(50, 450);
            this.reccomendatiopnButton.Width = 310;
            this.reccomendatiopnButton.Height = 40;
            this.reccomendatiopnButton.Text = "Recommendation";
            this.reccomendatiopnButton.UseVisualStyleBackColor = true;

            // Update Button
            this.updateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateButton.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.updateButton.ForeColor = System.Drawing.Color.White;
            this.updateButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.updateButton.Location = new System.Drawing.Point(50, 400);
            this.updateButton.Width = 310;
            this.updateButton.Height = 40;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;

            // Final form settings
            this.Name = "Form1";
            this.Text = "Manage An Itinerary";
            this.TopMost = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Cleaner border
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Center the form on the screen


            //Add elements
            this.Controls.Add(this.reccomendationTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.reccomendatiopnButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.itineraryNameTextBox);
            this.Controls.Add(this.LabelDescriptionText);
            this.Controls.Add(this.LabelItineraryName);
            this.Controls.Add(this.descriptionTextBox);
            this.Name = "AIttenary";
            this.Text = "Manage An Itinerary";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label LabelItineraryName;
        private System.Windows.Forms.Label LabelDescriptionText;
        private System.Windows.Forms.TextBox itineraryNameTextBox;
        private RoundedButton confirmButton;
        private RoundedButton reccomendatiopnButton;
        private RoundedButton updateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox reccomendationTextBox;
    }
}

