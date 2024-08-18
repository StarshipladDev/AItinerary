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
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.itineraryNameTextBox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.reccomendatiopnButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.reccomendationTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 82);
            this.descriptionTextBox.Multiline = true;
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(406, 255);
            this.descriptionTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter Itinerary Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter Itinerary Name";
            // 
            // itineraryNameTextBox
            // 
            this.itineraryNameTextBox.Location = new System.Drawing.Point(12, 25);
            this.itineraryNameTextBox.Name = "itineraryNameTextBox";
            this.itineraryNameTextBox.Size = new System.Drawing.Size(406, 20);
            this.itineraryNameTextBox.TabIndex = 3;
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.Teal;
            this.confirmButton.Location = new System.Drawing.Point(12, 362);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(114, 47);
            this.confirmButton.TabIndex = 4;
            this.confirmButton.Text = "Confirm Itinerary";
            this.confirmButton.UseVisualStyleBackColor = false;
            // 
            // reccomendatiopnButton
            // 
            this.reccomendatiopnButton.BackColor = System.Drawing.Color.Teal;
            this.reccomendatiopnButton.Location = new System.Drawing.Point(160, 362);
            this.reccomendatiopnButton.Name = "reccomendatiopnButton";
            this.reccomendatiopnButton.Size = new System.Drawing.Size(114, 47);
            this.reccomendatiopnButton.TabIndex = 5;
            this.reccomendatiopnButton.Text = "Get Reccomendation From AI";
            this.reccomendatiopnButton.UseVisualStyleBackColor = false;
            this.reccomendatiopnButton.Click += new System.EventHandler(this.reccomendatiopnButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.BackColor = System.Drawing.Color.Teal;
            this.updateButton.Location = new System.Drawing.Point(304, 362);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(114, 47);
            this.updateButton.TabIndex = 6;
            this.updateButton.Text = "Update Itinerary With AI";
            this.updateButton.UseVisualStyleBackColor = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(444, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Reccomendation";
            // 
            // reccomendationTextBox
            // 
            this.reccomendationTextBox.Location = new System.Drawing.Point(447, 83);
            this.reccomendationTextBox.Name = "reccomendationTextBox";
            this.reccomendationTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.reccomendationTextBox.Size = new System.Drawing.Size(213, 254);
            this.reccomendationTextBox.TabIndex = 8;
            this.reccomendationTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 450);
            this.Controls.Add(this.reccomendationTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.reccomendatiopnButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.itineraryNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descriptionTextBox);
            this.Name = "Form1";
            this.Text = "Manage An Itinerary";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox itineraryNameTextBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button reccomendatiopnButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox reccomendationTextBox;
    }
}

