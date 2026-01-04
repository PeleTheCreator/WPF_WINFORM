namespace myFirstAoo
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.num1Txt = new System.Windows.Forms.TextBox();
            this.num2Txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.resTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.num1ErrorLabel = new System.Windows.Forms.Label();
            this.num2ErrorLabel = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number 1";
            // 
            // num1Txt
            // 
            this.num1Txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num1Txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.num1Txt.Location = new System.Drawing.Point(12, 35);
            this.num1Txt.MaxLength = 10;
            this.num1Txt.Name = "num1Txt";
            this.num1Txt.Size = new System.Drawing.Size(286, 23);
            this.num1Txt.TabIndex = 1;
            this.num1Txt.TextChanged += new System.EventHandler(this.num1Txt_TextChanged);
            // 
            // num2Txt
            // 
            this.num2Txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num2Txt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.num2Txt.Location = new System.Drawing.Point(12, 80);
            this.num2Txt.MaxLength = 10;
            this.num2Txt.Name = "num2Txt";
            this.num2Txt.Size = new System.Drawing.Size(286, 23);
            this.num2Txt.TabIndex = 3;
            this.num2Txt.TextChanged += new System.EventHandler(this.num2Txt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Number 2";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(223, 109);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "ADD";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // resTxt
            // 
            this.resTxt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resTxt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.resTxt.Location = new System.Drawing.Point(12, 138);
            this.resTxt.MaxLength = 10;
            this.resTxt.Name = "resTxt";
            this.resTxt.Size = new System.Drawing.Size(286, 23);
            this.resTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Result";
            // 
            // num1ErrorLabel
            // 
            this.num1ErrorLabel.AutoSize = true;
            this.num1ErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num1ErrorLabel.Location = new System.Drawing.Point(279, 10);
            this.num1ErrorLabel.Name = "num1ErrorLabel";
            this.num1ErrorLabel.Size = new System.Drawing.Size(29, 37);
            this.num1ErrorLabel.TabIndex = 7;
            this.num1ErrorLabel.Text = "*";
            this.num1ErrorLabel.Visible = false;
            // 
            // num2ErrorLabel
            // 
            this.num2ErrorLabel.AutoSize = true;
            this.num2ErrorLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num2ErrorLabel.Location = new System.Drawing.Point(278, 56);
            this.num2ErrorLabel.Name = "num2ErrorLabel";
            this.num2ErrorLabel.Size = new System.Drawing.Size(29, 37);
            this.num2ErrorLabel.TabIndex = 8;
            this.num2ErrorLabel.Text = "*";
            this.num2ErrorLabel.Visible = false;
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(12, 167);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 10;
            this.backBtn.Text = "back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(309, 244);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resTxt);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.num2Txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.num1Txt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num1ErrorLabel);
            this.Controls.Add(this.num2ErrorLabel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Maroon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home Screen";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox num1Txt;
        private System.Windows.Forms.TextBox num2Txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox resTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label num1ErrorLabel;
        private System.Windows.Forms.Label num2ErrorLabel;
        private System.Windows.Forms.Button backBtn;


    }
}

