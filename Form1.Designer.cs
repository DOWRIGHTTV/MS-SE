
namespace MS539___2021_07_07
{
	partial class StockPrice
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.update_data = new System.Windows.Forms.Button();
            this.add_stock = new System.Windows.Forms.Button();
            this.delete_stock = new System.Windows.Forms.Button();
            this.add_box_input = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboTicker = new System.Windows.Forms.ComboBox();
            this.comboCollections = new System.Windows.Forms.ComboBox();
            this.view30 = new System.Windows.Forms.RadioButton();
            this.view60 = new System.Windows.Forms.RadioButton();
            this.view90 = new System.Windows.Forms.RadioButton();
            this.view352 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // update_data
            // 
            this.update_data.Location = new System.Drawing.Point(1489, 18);
            this.update_data.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.update_data.Name = "update_data";
            this.update_data.Size = new System.Drawing.Size(174, 78);
            this.update_data.TabIndex = 2;
            this.update_data.Text = "Update";
            this.update_data.UseVisualStyleBackColor = true;
            this.update_data.Click += new System.EventHandler(this.update_Click);
            // 
            // add_stock
            // 
            this.add_stock.Location = new System.Drawing.Point(839, 28);
            this.add_stock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.add_stock.Name = "add_stock";
            this.add_stock.Size = new System.Drawing.Size(230, 58);
            this.add_stock.TabIndex = 3;
            this.add_stock.Text = "ADD";
            this.add_stock.UseVisualStyleBackColor = true;
            this.add_stock.Click += new System.EventHandler(this.add_stock_Click);
            // 
            // delete_stock
            // 
            this.delete_stock.Location = new System.Drawing.Point(1077, 28);
            this.delete_stock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.delete_stock.Name = "delete_stock";
            this.delete_stock.Size = new System.Drawing.Size(230, 58);
            this.delete_stock.TabIndex = 4;
            this.delete_stock.Text = "DELETE";
            this.delete_stock.UseVisualStyleBackColor = true;
            this.delete_stock.Click += new System.EventHandler(this.delete_stock_Click);
            // 
            // add_box_input
            // 
            this.add_box_input.Location = new System.Drawing.Point(699, 43);
            this.add_box_input.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.add_box_input.Name = "add_box_input";
            this.add_box_input.Size = new System.Drawing.Size(132, 30);
            this.add_box_input.TabIndex = 7;
            this.add_box_input.TextChanged += new System.EventHandler(this.add_box_input_TextChanged);
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(15, 191);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(1610, 618);
            this.formsPlot1.TabIndex = 12;
            this.formsPlot1.Load += new System.EventHandler(this.formsPlot1_Load);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // comboTicker
            // 
            this.comboTicker.FormattingEnabled = true;
            this.comboTicker.Location = new System.Drawing.Point(309, 81);
            this.comboTicker.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboTicker.Name = "comboTicker";
            this.comboTicker.Size = new System.Drawing.Size(184, 31);
            this.comboTicker.TabIndex = 14;
            this.comboTicker.Text = "Tickers...";
            this.comboTicker.SelectedIndexChanged += new System.EventHandler(this.comboTicker_Change);
            // 
            // comboCollections
            // 
            this.comboCollections.FormattingEnabled = true;
            this.comboCollections.Items.AddRange(new object[] {
            "Collection 1",
            "Collection 2",
            "Collection 3",
            "Collection 4",
            "Collection 5",
            "Collection 6",
            "Collection 7"});
            this.comboCollections.Location = new System.Drawing.Point(85, 81);
            this.comboCollections.Name = "comboCollections";
            this.comboCollections.Size = new System.Drawing.Size(184, 31);
            this.comboCollections.TabIndex = 15;
            this.comboCollections.Text = "Collections...";
            this.comboCollections.SelectedIndexChanged += new System.EventHandler(this.comboCollection_Change);
            // 
            // radioButton1
            // 
            this.view30.AutoSize = true;
            this.view30.Location = new System.Drawing.Point(1238, 169);
            this.view30.Name = "view30";
            this.view30.Size = new System.Drawing.Size(92, 27);
            this.view30.TabIndex = 17;
            this.view30.TabStop = true;
            this.view30.Text = "30 Days";
            this.view30.UseVisualStyleBackColor = true;
            this.view30.CheckedChanged += new System.EventHandler(this.view_CheckedChanged);
            // 
            // radioButton2
            // 
            this.view60.AutoSize = true;
            this.view60.Location = new System.Drawing.Point(1336, 169);
            this.view60.Name = "view60";
            this.view60.Size = new System.Drawing.Size(92, 27);
            this.view60.TabIndex = 18;
            this.view60.TabStop = true;
            this.view60.Text = "60 Days";
            this.view60.UseVisualStyleBackColor = true;
            this.view60.CheckedChanged += new System.EventHandler(this.view_CheckedChanged);
            // 
            // radioButton3
            // 
            this.view90.AutoSize = true;
            this.view90.Location = new System.Drawing.Point(1434, 169);
            this.view90.Name = "view90";
            this.view90.Size = new System.Drawing.Size(92, 27);
            this.view90.TabIndex = 19;
            this.view90.TabStop = true;
            this.view90.Text = "90 Days";
            this.view90.UseVisualStyleBackColor = true;
            this.view90.CheckedChanged += new System.EventHandler(this.view_CheckedChanged);
            // 
            // radioButton4
            // 
            this.view352.AutoSize = true;
            this.view352.Location = new System.Drawing.Point(1532, 169);
            this.view352.Name = "view352";
            this.view352.Size = new System.Drawing.Size(61, 27);
            this.view352.TabIndex = 20;
            this.view352.TabStop = true;
            this.view352.Text = "1 YR";
            this.view352.UseVisualStyleBackColor = true;
            this.view352.CheckedChanged += new System.EventHandler(this.view_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.Location = new System.Drawing.Point(0, 0);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(104, 24);
            this.radioButton5.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(745, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 22;
            this.label1.Text = "References";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1406, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 23;
            this.label2.Text = "Views";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(699, 176);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(115, 27);
            this.checkBox1.TabIndex = 25;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // StockPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1676, 954);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.view30);
            this.Controls.Add(this.view60);
            this.Controls.Add(this.view90);
            this.Controls.Add(this.view352);
            this.Controls.Add(this.comboCollections);
            this.Controls.Add(this.comboTicker);
            this.Controls.Add(this.formsPlot1);
            this.Controls.Add(this.add_box_input);
            this.Controls.Add(this.delete_stock);
            this.Controls.Add(this.add_stock);
            this.Controls.Add(this.update_data);
            this.Font = new System.Drawing.Font("SamsungImagination", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "StockPrice";
            this.Text = "StockPrice";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Collection_1;
        private System.Windows.Forms.Button Collection_2;
        private System.Windows.Forms.Button update_data;
        private System.Windows.Forms.Button add_stock;
        private System.Windows.Forms.Button delete_stock;
        private System.Windows.Forms.Button Collection_3;
        private System.Windows.Forms.TextBox add_box_input;
        private System.Windows.Forms.Button collection_3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private ScottPlot.FormsPlot formsPlot1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboCollections;
        private System.Windows.Forms.ComboBox comboTicker;
        private System.Windows.Forms.RadioButton view30;
        private System.Windows.Forms.RadioButton view60;
        private System.Windows.Forms.RadioButton view90;
        private System.Windows.Forms.RadioButton view352;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

