
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
            resources.ApplyResources(this.lblBuy, "lblBuy");
            this.lblBuy.Name = "lblBuy";
            // 
            // txtBuy
            // 
            resources.ApplyResources(this.txtBuy, "txtBuy");
            this.txtBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.txtBuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.txtBuy.Name = "txtBuy";
            this.txtBuy.TextChanged += new System.EventHandler(this.txtBuy_TextChanged);
            // 
            // txtSell
            // 
            resources.ApplyResources(this.txtSell, "txtSell");
            this.txtSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.txtSell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.txtSell.Name = "txtSell";
            this.txtSell.TextChanged += new System.EventHandler(this.txtSell_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditDbEntry
            // 
            this.AcceptButton = this.btnSave;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSell);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuy);
            this.Controls.Add(this.lblBuy);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EditDbEntry";
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