using System.Drawing;
using System.Windows.Forms;

namespace LearningWinform
{
    partial class TextControlForm
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
            this.num1Lbl = new System.Windows.Forms.Label();
            this.num1Txt = new System.Windows.Forms.TextBox();
            this.num2Lbl = new System.Windows.Forms.Label();
            this.num2Txt = new System.Windows.Forms.TextBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.resultTxt = new System.Windows.Forms.TextBox();
            this.resultLbl = new System.Windows.Forms.Label();
            this.num1ErrorLbl = new System.Windows.Forms.Label();
            this.num2ErrorLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // num1Lbl
            // 
            this.num1Lbl.AutoSize = true;
            this.num1Lbl.Location = new System.Drawing.Point(77, 89);
            this.num1Lbl.Name = "num1Lbl";
            this.num1Lbl.Size = new System.Drawing.Size(80, 20);
            this.num1Lbl.TabIndex = 0;
            this.num1Lbl.Text = "Number 1";
            // 
            // num1Txt
            // 
            //this.num1Txt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            //this.num1Txt.UseSystemPasswordChar = true;
            //this.num1Txt.PasswordChar = '*';
            //this.num1Txt.Multiline = true;
            //this.num1Txt.ScrollBars = ScrollBars.Vertical;
            //this.num1Txt.AcceptsReturn = true;
            //this.num1Txt.WordWrap = true;
            this.num1Txt.Location = new System.Drawing.Point(81, 112);
            this.num1Txt.MaxLength = 10;
            this.num1Txt.Name = "num1Txt";
            this.num1Txt.Size = new System.Drawing.Size(286, 27);
            this.num1Txt.TabIndex = 1;
            this.num1Txt.TextChanged += new System.EventHandler(this.num1Txt_TextChanged);
            // 
            // num2Lbl
            // 
            this.num2Lbl.AutoSize = true;
            this.num2Lbl.Location = new System.Drawing.Point(77, 154);
            this.num2Lbl.Name = "num2Lbl";
            this.num2Lbl.Size = new System.Drawing.Size(80, 20);
            this.num2Lbl.TabIndex = 2;
            this.num2Lbl.Text = "Number 2";
            // 
            // num2Txt
            // 
            this.num2Txt.Location = new System.Drawing.Point(81, 194);
            this.num2Txt.MaxLength = 10;
            this.num2Txt.Name = "num2Txt";
            this.num2Txt.Size = new System.Drawing.Size(286, 27);
            this.num2Txt.TabIndex = 3;
            this.num2Txt.TextChanged += new System.EventHandler(this.num2Txt_TextChanged);
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(292, 227);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 30);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // resultTxt
            // 
            this.resultTxt.Location = new System.Drawing.Point(81, 276);
            this.resultTxt.Name = "resultTxt";
            this.resultTxt.Size = new System.Drawing.Size(286, 27);
            this.resultTxt.TabIndex = 6;
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Location = new System.Drawing.Point(81, 254);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(53, 20);
            this.resultLbl.TabIndex = 5;
            this.resultLbl.Text = "Result";
            // 
            // num1ErrorLbl
            // 
            this.num1ErrorLbl.AutoSize = true;
            this.num1ErrorLbl.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num1ErrorLbl.Location = new System.Drawing.Point(337, 78);
            this.num1ErrorLbl.Name = "num1ErrorLbl";
            this.num1ErrorLbl.Size = new System.Drawing.Size(35, 45);
            this.num1ErrorLbl.TabIndex = 7;
            this.num1ErrorLbl.Text = "*";
            this.num1ErrorLbl.Visible = false;
            // 
            // num2ErrorLbl
            // 
            this.num2ErrorLbl.AutoSize = true;
            this.num2ErrorLbl.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num2ErrorLbl.Location = new System.Drawing.Point(332, 154);
            this.num2ErrorLbl.Name = "num2ErrorLbl";
            this.num2ErrorLbl.Size = new System.Drawing.Size(35, 45);
            this.num2ErrorLbl.TabIndex = 8;
            this.num2ErrorLbl.Text = "*";
            this.num2ErrorLbl.Visible = false;

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 450);
            this.Controls.Add(this.num2ErrorLbl);
            this.Controls.Add(this.resultLbl);
            this.Controls.Add(this.resultTxt);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.num2Txt);
            this.Controls.Add(this.num2Lbl);
            this.Controls.Add(this.num1Lbl);
            this.Controls.Add(this.num1Txt);
            this.Controls.Add(this.num1ErrorLbl);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Red;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Text Control";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TextControlForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox num1Txt;
        private System.Windows.Forms.Label num1Lbl;
        private System.Windows.Forms.Label num2Lbl;
        private System.Windows.Forms.TextBox num2Txt;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox resultTxt;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.Label num1ErrorLbl;
        private System.Windows.Forms.Label num2ErrorLbl;
    }
}

