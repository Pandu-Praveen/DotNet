namespace SuperMarketApp
{
    partial class SalesPerson
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
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnMyCart = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnFindBills = new System.Windows.Forms.Button();
            this.txtWelcome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(405, 116);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(153, 46);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Find Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnMyCart
            // 
            this.btnMyCart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyCart.Location = new System.Drawing.Point(405, 287);
            this.btnMyCart.Name = "btnMyCart";
            this.btnMyCart.Size = new System.Drawing.Size(153, 45);
            this.btnMyCart.TabIndex = 1;
            this.btnMyCart.Text = "My Cart";
            this.btnMyCart.UseVisualStyleBackColor = true;
            this.btnMyCart.Click += new System.EventHandler(this.btnMyCart_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(862, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(91, 42);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnFindBills
            // 
            this.btnFindBills.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindBills.Location = new System.Drawing.Point(405, 201);
            this.btnFindBills.Name = "btnFindBills";
            this.btnFindBills.Size = new System.Drawing.Size(153, 45);
            this.btnFindBills.TabIndex = 7;
            this.btnFindBills.Text = "Find Bills";
            this.btnFindBills.UseVisualStyleBackColor = true;
            this.btnFindBills.Click += new System.EventHandler(this.btnFindBills_Click);
            // 
            // txtWelcome
            // 
            this.txtWelcome.AutoSize = true;
            this.txtWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWelcome.Location = new System.Drawing.Point(12, 21);
            this.txtWelcome.Name = "txtWelcome";
            this.txtWelcome.Size = new System.Drawing.Size(115, 25);
            this.txtWelcome.TabIndex = 8;
            this.txtWelcome.Text = "Welcome ";
            // 
            // SalesPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(965, 450);
            this.Controls.Add(this.txtWelcome);
            this.Controls.Add(this.btnFindBills);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMyCart);
            this.Controls.Add(this.btnAddProduct);
            this.Name = "SalesPerson";
            this.Text = "SalesPerson";
            this.Load += new System.EventHandler(this.SalesPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnMyCart;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnFindBills;
        private System.Windows.Forms.Label txtWelcome;
    }
}