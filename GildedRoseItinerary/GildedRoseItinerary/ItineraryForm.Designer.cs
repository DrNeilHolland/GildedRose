namespace GildedRoseItinerary
{
    partial class ItineraryForm
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
            this.tbItinerary = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbItinerary
            // 
            this.tbItinerary.Location = new System.Drawing.Point(22, 38);
            this.tbItinerary.Multiline = true;
            this.tbItinerary.Name = "tbItinerary";
            this.tbItinerary.Size = new System.Drawing.Size(307, 134);
            this.tbItinerary.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Itinerary. Each row shows an item, its sell by date, and its quality";
            // 
            // bnUpdate
            // 
            this.bnUpdate.Location = new System.Drawing.Point(142, 197);
            this.bnUpdate.Name = "bnUpdate";
            this.bnUpdate.Size = new System.Drawing.Size(75, 23);
            this.bnUpdate.TabIndex = 2;
            this.bnUpdate.Text = "Update";
            this.bnUpdate.UseVisualStyleBackColor = true;
            this.bnUpdate.Click += new System.EventHandler(this.bnUpdate_Click);
            // 
            // ItineraryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 244);
            this.Controls.Add(this.bnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbItinerary);
            this.Name = "ItineraryForm";
            this.Text = "Gilded Rose";
            this.Load += new System.EventHandler(this.ItineraryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbItinerary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bnUpdate;
    }
}

