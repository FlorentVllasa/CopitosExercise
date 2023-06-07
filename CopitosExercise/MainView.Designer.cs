namespace CopitosExercise
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHomepage = new System.Windows.Forms.Button();
            this.btnShowMergerView = new System.Windows.Forms.Button();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.lblInitialMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnHomepage);
            this.panel1.Controls.Add(this.btnShowMergerView);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 556);
            this.panel1.TabIndex = 0;
            // 
            // btnHomepage
            // 
            this.btnHomepage.Image = ((System.Drawing.Image)(resources.GetObject("btnHomepage.Image")));
            this.btnHomepage.Location = new System.Drawing.Point(-1, -1);
            this.btnHomepage.Name = "btnHomepage";
            this.btnHomepage.Size = new System.Drawing.Size(46, 32);
            this.btnHomepage.TabIndex = 1;
            this.btnHomepage.UseVisualStyleBackColor = true;
            this.btnHomepage.Click += new System.EventHandler(this.btnHomepage_Click);
            // 
            // btnShowMergerView
            // 
            this.btnShowMergerView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowMergerView.Location = new System.Drawing.Point(-1, 52);
            this.btnShowMergerView.Name = "btnShowMergerView";
            this.btnShowMergerView.Size = new System.Drawing.Size(200, 37);
            this.btnShowMergerView.TabIndex = 0;
            this.btnShowMergerView.Text = "Daten zusammenführen";
            this.btnShowMergerView.UseVisualStyleBackColor = true;
            this.btnShowMergerView.Click += new System.EventHandler(this.btnShowMergerView_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlContent.Controls.Add(this.lblInitialMessage);
            this.pnlContent.Location = new System.Drawing.Point(206, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(910, 556);
            this.pnlContent.TabIndex = 1;
            // 
            // lblInitialMessage
            // 
            this.lblInitialMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInitialMessage.AutoSize = true;
            this.lblInitialMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialMessage.Location = new System.Drawing.Point(89, 150);
            this.lblInitialMessage.Name = "lblInitialMessage";
            this.lblInitialMessage.Size = new System.Drawing.Size(597, 168);
            this.lblInitialMessage.TabIndex = 0;
            this.lblInitialMessage.Text = resources.GetString("lblInitialMessage.Text");
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 555);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.panel1);
            this.Name = "MainView";
            this.Text = "Hauptmenü";
            this.panel1.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowMergerView;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Label lblInitialMessage;
        private System.Windows.Forms.Button btnHomepage;
    }
}

