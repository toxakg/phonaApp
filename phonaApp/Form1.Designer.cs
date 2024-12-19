namespace phonaApp
{
    partial class Form1
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
            txtModel = new TextBox();
            txtBrand = new TextBox();
            txtPrice = new TextBox();
            txtSearchModel = new TextBox();
            btnAddPhone = new Button();
            btnSearch = new Button();
            dataGridViewPhones = new DataGridView();
            labelModel = new Label();
            labelBrand = new Label();
            labelPrice = new Label();
            labelSearch = new Label();
            btnEditPhone = new Button();
            btnDeletePhone = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPhones).BeginInit();
            SuspendLayout();
            // 
            // txtModel
            // 
            txtModel.Location = new Point(120, 50);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(200, 27);
            txtModel.TabIndex = 0;
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(120, 90);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(200, 27);
            txtBrand.TabIndex = 1;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(120, 130);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(200, 27);
            txtPrice.TabIndex = 2;
            // 
            // txtSearchModel
            // 
            txtSearchModel.Location = new Point(120, 170);
            txtSearchModel.Name = "txtSearchModel";
            txtSearchModel.Size = new Size(200, 27);
            txtSearchModel.TabIndex = 3;
            // 
            // btnAddPhone
            // 
            btnAddPhone.Location = new Point(120, 210);
            btnAddPhone.Name = "btnAddPhone";
            btnAddPhone.Size = new Size(200, 30);
            btnAddPhone.TabIndex = 4;
            btnAddPhone.Text = "Добавить телефон";
            btnAddPhone.UseVisualStyleBackColor = true;
            btnAddPhone.Click += btnAddPhone_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(120, 250);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(200, 30);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Поиск по модели";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // dataGridViewPhones
            // 
            dataGridViewPhones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPhones.Location = new Point(350, 50);
            dataGridViewPhones.Name = "dataGridViewPhones";
            dataGridViewPhones.RowHeadersWidth = 51;
            dataGridViewPhones.Size = new Size(550, 300);
            dataGridViewPhones.TabIndex = 6;
            // 
            // labelModel
            // 
            labelModel.AutoSize = true;
            labelModel.Location = new Point(42, 50);
            labelModel.Name = "labelModel";
            labelModel.Size = new Size(63, 20);
            labelModel.TabIndex = 7;
            labelModel.Text = "Модель";
            // 
            // labelBrand
            // 
            labelBrand.AutoSize = true;
            labelBrand.Location = new Point(60, 90);
            labelBrand.Name = "labelBrand";
            labelBrand.Size = new Size(52, 20);
            labelBrand.TabIndex = 8;
            labelBrand.Text = "Бренд";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(60, 130);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(45, 20);
            labelPrice.TabIndex = 9;
            labelPrice.Text = "Цена";
            // 
            // labelSearch
            // 
            labelSearch.AutoSize = true;
            labelSearch.Location = new Point(5, 177);
            labelSearch.Name = "labelSearch";
            labelSearch.Size = new Size(109, 20);
            labelSearch.TabIndex = 10;
            labelSearch.Text = "Поиск модели";
            // 
            // btnEditPhone
            // 
            btnEditPhone.Location = new Point(120, 290);
            btnEditPhone.Name = "btnEditPhone";
            btnEditPhone.Size = new Size(200, 30);
            btnEditPhone.TabIndex = 11;
            btnEditPhone.Text = "Изменить телефон";
            btnEditPhone.UseVisualStyleBackColor = true;
            btnEditPhone.Click += btnEditPhone_Click;
            // 
            // btnDeletePhone
            // 
            btnDeletePhone.Location = new Point(120, 330);
            btnDeletePhone.Name = "btnDeletePhone";
            btnDeletePhone.Size = new Size(200, 30);
            btnDeletePhone.TabIndex = 12;
            btnDeletePhone.Text = "Удалить телефон";
            btnDeletePhone.UseVisualStyleBackColor = true;
            btnDeletePhone.Click += btnDeletePhone_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(949, 546);
            Controls.Add(labelSearch);
            Controls.Add(labelPrice);
            Controls.Add(labelBrand);
            Controls.Add(labelModel);
            Controls.Add(dataGridViewPhones);
            Controls.Add(btnSearch);
            Controls.Add(btnAddPhone);
            Controls.Add(txtSearchModel);
            Controls.Add(txtPrice);
            Controls.Add(txtBrand);
            Controls.Add(txtModel);
            Controls.Add(btnEditPhone);
            Controls.Add(btnDeletePhone);
            Name = "Form1";
            Text = "Магазин телефонов";
            ((System.ComponentModel.ISupportInitialize)dataGridViewPhones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditPhone;
        private Button btnDeletePhone;
        private TextBox txtModel;
        private TextBox txtBrand;
        private TextBox txtPrice;
        private TextBox txtSearchModel;
        private Button btnAddPhone;
        private Button btnSearch;
        private DataGridView dataGridViewPhones;
        private Label labelModel;
        private Label labelBrand;
        private Label labelPrice;
        private Label labelSearch;
    }
}
