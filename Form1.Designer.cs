
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
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
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(1238, 169);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(92, 27);
            this.radioButton1.TabIndex = 17;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "30 Days";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(1336, 169);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(92, 27);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "60 Days";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(1434, 169);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(92, 27);
            this.radioButton3.TabIndex = 19;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "90 Days";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(1532, 169);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(61, 27);
            this.radioButton4.TabIndex = 20;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "1 YR";
            this.radioButton4.UseVisualStyleBackColor = true;
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
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
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
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

