namespace Unturned_Uconomy_Utility
{
    partial class frmCleanTables
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCleanTables));
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbRenameItems = new System.Windows.Forms.ListBox();
            this.lbRemoveItems = new System.Windows.Forms.ListBox();
            this.lbRenameVehicles = new System.Windows.Forms.ListBox();
            this.lbRemoveVehicles = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbRename = new System.Windows.Forms.CheckBox();
            this.cbRemove = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAnalyze
            // 
            resources.ApplyResources(this.btnAnalyze, "btnAnalyze");
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // btnClean
            // 
            resources.ApplyResources(this.btnClean, "btnClean");
            this.btnClean.Name = "btnClean";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lbRenameItems
            // 
            resources.ApplyResources(this.lbRenameItems, "lbRenameItems");
            this.lbRenameItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.lbRenameItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRenameItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.lbRenameItems.FormattingEnabled = true;
            this.lbRenameItems.Name = "lbRenameItems";
            this.lbRenameItems.TabStop = false;
            // 
            // lbRemoveItems
            // 
            resources.ApplyResources(this.lbRemoveItems, "lbRemoveItems");
            this.lbRemoveItems.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.lbRemoveItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRemoveItems.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.lbRemoveItems.FormattingEnabled = true;
            this.lbRemoveItems.Name = "lbRemoveItems";
            this.lbRemoveItems.TabStop = false;
            // 
            // lbRenameVehicles
            // 
            resources.ApplyResources(this.lbRenameVehicles, "lbRenameVehicles");
            this.lbRenameVehicles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.lbRenameVehicles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRenameVehicles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.lbRenameVehicles.FormattingEnabled = true;
            this.lbRenameVehicles.Name = "lbRenameVehicles";
            this.lbRenameVehicles.TabStop = false;
            // 
            // lbRemoveVehicles
            // 
            resources.ApplyResources(this.lbRemoveVehicles, "lbRemoveVehicles");
            this.lbRemoveVehicles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(43)))), ((int)(((byte)(47)))));
            this.lbRemoveVehicles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRemoveVehicles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.lbRemoveVehicles.FormattingEnabled = true;
            this.lbRemoveVehicles.Name = "lbRemoveVehicles";
            this.lbRemoveVehicles.TabStop = false;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Name = "panel1";
            // 
            // cbRename
            // 
            resources.ApplyResources(this.cbRename, "cbRename");
            this.cbRename.Checked = true;
            this.cbRename.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRename.Name = "cbRename";
            this.cbRename.UseVisualStyleBackColor = true;
            // 
            // cbRemove
            // 
            resources.ApplyResources(this.cbRemove, "cbRemove");
            this.cbRemove.Checked = true;
            this.cbRemove.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRemove.Name = "cbRemove";
            this.cbRemove.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Name = "panel3";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // frmCleanTables
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbRemove);
            this.Controls.Add(this.cbRename);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbRemoveVehicles);
            this.Controls.Add(this.lbRenameVehicles);
            this.Controls.Add(this.lbRemoveItems);
            this.Controls.Add(this.lbRenameItems);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnAnalyze);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCleanTables";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbRenameItems;
        private System.Windows.Forms.ListBox lbRemoveItems;
        private System.Windows.Forms.ListBox lbRenameVehicles;
        private System.Windows.Forms.ListBox lbRemoveVehicles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbRename;
        private System.Windows.Forms.CheckBox cbRemove;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}