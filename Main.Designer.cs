namespace PMS
{
    partial class Main
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
            this.btnInOut = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnTapeline = new System.Windows.Forms.Button();
            this.btnLoom = new System.Windows.Forms.Button();
            this.btnAddDrop = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnInventory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInOut
            // 
            this.btnInOut.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInOut.Location = new System.Drawing.Point(375, 168);
            this.btnInOut.Name = "btnInOut";
            this.btnInOut.Size = new System.Drawing.Size(152, 49);
            this.btnInOut.TabIndex = 0;
            this.btnInOut.Text = "In/Out";
            this.btnInOut.UseVisualStyleBackColor = true;
            this.btnInOut.Click += new System.EventHandler(this.btnInOut_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.Location = new System.Drawing.Point(375, 278);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(152, 49);
            this.btnOrder.TabIndex = 1;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnTapeline
            // 
            this.btnTapeline.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTapeline.Location = new System.Drawing.Point(710, 168);
            this.btnTapeline.Name = "btnTapeline";
            this.btnTapeline.Size = new System.Drawing.Size(152, 49);
            this.btnTapeline.TabIndex = 2;
            this.btnTapeline.Text = "Tapeline";
            this.btnTapeline.UseVisualStyleBackColor = true;
            this.btnTapeline.Click += new System.EventHandler(this.btnTapeline_Click);
            // 
            // btnLoom
            // 
            this.btnLoom.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoom.Location = new System.Drawing.Point(710, 278);
            this.btnLoom.Name = "btnLoom";
            this.btnLoom.Size = new System.Drawing.Size(152, 49);
            this.btnLoom.TabIndex = 3;
            this.btnLoom.Text = "Loom";
            this.btnLoom.UseVisualStyleBackColor = true;
            this.btnLoom.Click += new System.EventHandler(this.btnLoom_Click);
            // 
            // btnAddDrop
            // 
            this.btnAddDrop.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDrop.Location = new System.Drawing.Point(375, 388);
            this.btnAddDrop.Name = "btnAddDrop";
            this.btnAddDrop.Size = new System.Drawing.Size(152, 49);
            this.btnAddDrop.TabIndex = 4;
            this.btnAddDrop.Text = "Add/Drop";
            this.btnAddDrop.UseVisualStyleBackColor = true;
            this.btnAddDrop.Click += new System.EventHandler(this.btnAddDrop_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.Location = new System.Drawing.Point(542, 498);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(152, 49);
            this.btnUsers.TabIndex = 5;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnInventory
            // 
            this.btnInventory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInventory.Location = new System.Drawing.Point(710, 388);
            this.btnInventory.Name = "btnInventory";
            this.btnInventory.Size = new System.Drawing.Size(152, 49);
            this.btnInventory.TabIndex = 6;
            this.btnInventory.Text = "Inventory";
            this.btnInventory.UseVisualStyleBackColor = true;
            this.btnInventory.Click += new System.EventHandler(this.btnInventory_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.btnInventory);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnAddDrop);
            this.Controls.Add(this.btnLoom);
            this.Controls.Add(this.btnTapeline);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.btnInOut);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInOut;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnTapeline;
        private System.Windows.Forms.Button btnLoom;
        private System.Windows.Forms.Button btnAddDrop;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnInventory;
    }
}