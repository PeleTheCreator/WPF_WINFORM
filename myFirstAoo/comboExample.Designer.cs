namespace myFirstAoo
{
    partial class comboExample
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
            this.countryDD = new System.Windows.Forms.ComboBox();
            this.citiesDD = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ansLabel = new System.Windows.Forms.Label();
            this.showBtn = new System.Windows.Forms.Button();
            this.myItemsLB = new System.Windows.Forms.ListBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.backBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Countries";
            // 
            // countryDD
            // 
            this.countryDD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.countryDD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.countryDD.FormattingEnabled = true;
            this.countryDD.Items.AddRange(new object[] {
            "Pakistan",
            "China",
            "Canada",
            "Iran"});
            this.countryDD.Location = new System.Drawing.Point(13, 45);
            this.countryDD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.countryDD.Name = "countryDD";
            this.countryDD.Size = new System.Drawing.Size(324, 29);
            this.countryDD.TabIndex = 0;
            this.countryDD.SelectedIndexChanged += new System.EventHandler(this.countryDD_SelectedIndexChanged);
            // 
            // citiesDD
            // 
            this.citiesDD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.citiesDD.FormattingEnabled = true;
            this.citiesDD.Location = new System.Drawing.Point(13, 106);
            this.citiesDD.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.citiesDD.Name = "citiesDD";
            this.citiesDD.Size = new System.Drawing.Size(324, 29);
            this.citiesDD.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cities";
            // 
            // ansLabel
            // 
            this.ansLabel.AutoSize = true;
            this.ansLabel.Location = new System.Drawing.Point(13, 209);
            this.ansLabel.Name = "ansLabel";
            this.ansLabel.Size = new System.Drawing.Size(22, 21);
            this.ansLabel.TabIndex = 4;
            this.ansLabel.Text = "....";
            // 
            // showBtn
            // 
            this.showBtn.Location = new System.Drawing.Point(220, 143);
            this.showBtn.Name = "showBtn";
            this.showBtn.Size = new System.Drawing.Size(117, 49);
            this.showBtn.TabIndex = 3;
            this.showBtn.Text = "Show";
            this.showBtn.UseVisualStyleBackColor = true;
            this.showBtn.Click += new System.EventHandler(this.showBtn_Click);
            // 
            // myItemsLB
            // 
            this.myItemsLB.FormattingEnabled = true;
            this.myItemsLB.ItemHeight = 21;
            this.myItemsLB.Items.AddRange(new object[] {
            "Pakistan",
            "China",
            "Canada",
            "Iran"});
            this.myItemsLB.Location = new System.Drawing.Point(17, 255);
            this.myItemsLB.Name = "myItemsLB";
            this.myItemsLB.Size = new System.Drawing.Size(320, 277);
            this.myItemsLB.TabIndex = 5;
            this.myItemsLB.Visible = false;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(97, 143);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(117, 49);
            this.addBtn.TabIndex = 6;
            this.addBtn.Text = "ADD TO LIST";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(252, 198);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 48);
            this.backBtn.TabIndex = 10;
            this.backBtn.Text = "back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // comboExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 258);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.myItemsLB);
            this.Controls.Add(this.showBtn);
            this.Controls.Add(this.ansLabel);
            this.Controls.Add(this.citiesDD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.countryDD);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "comboExample";
            this.Text = "comboExample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox countryDD;
        private System.Windows.Forms.ComboBox citiesDD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label ansLabel;
        private System.Windows.Forms.Button showBtn;
        private System.Windows.Forms.ListBox myItemsLB;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button backBtn;
    }
}