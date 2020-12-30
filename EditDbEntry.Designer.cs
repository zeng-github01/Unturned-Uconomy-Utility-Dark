
namespace Unturned_Uconomy_Utility
{
    partial class EditDbEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditDbEntry));
            this.lblBuy = new System.Windows.Forms.Label();
            this.txtBuy = new System.Windows.Forms.TextBox();
            this.txtSell = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBuy
            // 
            this.lblBuy.AutoSize = true;
            this.lblBuy.Location = new System.Drawing.Point(9, 9);
            this.lblBuy.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblBuy.Name = "lblBuy";
            this.lblBuy.Size = new System.Drawing.Size(95, 24);
            this.lblBuy.TabIndex = 0;
            this.lblBuy.Text = "Buy Price:";
            // 
            // txtBuy
            // 
            this.txtBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.txtBuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.txtBuy.Location = new System.Drawing.Point(13, 37);
            this.txtBuy.Name = "txtBuy";
            this.txtBuy.Size = new System.Drawing.Size(273, 29);
            this.txtBuy.TabIndex = 1;
            this.txtBuy.TextChanged += new System.EventHandler(this.txtBuy_TextChanged);
            // 
            // txtSell
            // 
            this.txtSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.txtSell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.txtSell.Location = new System.Drawing.Point(13, 96);
            this.txtSell.Name = "txtSell";
            this.txtSell.Size = new System.Drawing.Size(273, 29);
            this.txtSell.TabIndex = 3;
            this.txtSell.TextChanged += new System.EventHandler(this.txtSell_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 68);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sell Price:";
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(13, 131);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(273, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditDbEntry
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(298, 179);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSell);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuy);
            this.Controls.Add(this.lblBuy);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditDbEntry";
            this.Text = "%EntryName%";
            this.Load += new System.EventHandler(this.EditDbEntry_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBuy;
        private System.Windows.Forms.TextBox txtBuy;
        private System.Windows.Forms.TextBox txtSell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
    }
}