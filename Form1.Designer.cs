
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
            this.update_data = new System.Windows.Forms.Button();
            this.add_stock = new System.Windows.Forms.Button();
            this.delete_stock = new System.Windows.Forms.Button();
            this.add_box_input = new System.Windows.Forms.TextBox();
            this.collection_1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // update_data
            // 
            this.update_data.Location = new System.Drawing.Point(1032, 12);
            this.update_data.Name = "update_data";
            this.update_data.Size = new System.Drawing.Size(161, 65);
            this.update_data.TabIndex = 2;
            this.update_data.Text = "Update";
            this.update_data.UseVisualStyleBackColor = true;
            this.update_data.Click += new System.EventHandler(this.button3_Click);
            // 
            // add_stock
            // 
            this.add_stock.Location = new System.Drawing.Point(528, 129);
            this.add_stock.Name = "add_stock";
            this.add_stock.Size = new System.Drawing.Size(161, 38);
            this.add_stock.TabIndex = 3;
            this.add_stock.Text = "ADD";
            this.add_stock.UseVisualStyleBackColor = true;
            this.add_stock.Click += new System.EventHandler(this.button4_Click);
            // 
            // delete_stock
            // 
            this.delete_stock.Location = new System.Drawing.Point(725, 129);
            this.delete_stock.Name = "delete_stock";
            this.delete_stock.Size = new System.Drawing.Size(161, 38);
            this.delete_stock.TabIndex = 4;
            this.delete_stock.Text = "DELETE";
            this.delete_stock.UseVisualStyleBackColor = true;
            this.delete_stock.Click += new System.EventHandler(this.delete_stock_Click);
            // 
            // add_box_input
            // 
            this.add_box_input.Location = new System.Drawing.Point(528, 100);
            this.add_box_input.Name = "add_box_input";
            this.add_box_input.Size = new System.Drawing.Size(161, 23);
            this.add_box_input.TabIndex = 7;
            // 
            // collection_1
            // 
            this.collection_1.Location = new System.Drawing.Point(25, 46);
            this.collection_1.Name = "collection_1";
            this.collection_1.Size = new System.Drawing.Size(101, 39);
            this.collection_1.TabIndex = 8;
            this.collection_1.Text = "Collection 1";
            this.collection_1.UseVisualStyleBackColor = true;
            this.collection_1.Click += new System.EventHandler(this.collection_1_Click);
            // 
            // StockPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 787);
            this.Controls.Add(this.collection_1);
            this.Controls.Add(this.add_box_input);
            this.Controls.Add(this.delete_stock);
            this.Controls.Add(this.add_stock);
            this.Controls.Add(this.update_data);
            this.Name = "StockPrice";
            this.Text = "StockPrice";
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
        private System.Windows.Forms.Button collection_1;
        private System.Windows.Forms.Button collection_3;
    }
}

