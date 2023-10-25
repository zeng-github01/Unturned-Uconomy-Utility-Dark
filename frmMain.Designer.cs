namespace Unturned_Uconomy_Utility
{
    partial class frmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvLocal = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvDatabase = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbBuy = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblSell = new System.Windows.Forms.Label();
            this.tbSell = new System.Windows.Forms.TextBox();
            this.lblBuy = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblAbout = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbVehicles = new System.Windows.Forms.RadioButton();
            this.rbItems = new System.Windows.Forms.RadioButton();
            this.contextMenuStripLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripDatabase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wikiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCleanTable = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.contextMenuStripLocal.SuspendLayout();
            this.contextMenuStripDatabase.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.lvLocal);
            this.toolTip1.SetToolTip(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.lvDatabase);
            this.toolTip1.SetToolTip(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
            this.splitContainer1.TabStop = false;
            this.toolTip1.SetToolTip(this.splitContainer1, resources.GetString("splitContainer1.ToolTip"));
            // 
            // lvLocal
            // 
            resources.ApplyResources(this.lvLocal, "lvLocal");
            this.lvLocal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.lvLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvLocal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.lvLocal.FullRowSelect = true;
            this.lvLocal.HideSelection = false;
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.TabStop = false;
            this.toolTip1.SetToolTip(this.lvLocal, resources.GetString("lvLocal.ToolTip"));
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            this.lvLocal.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // columnHeader2
            // 
            resources.ApplyResources(this.columnHeader2, "columnHeader2");
            // 
            // lvDatabase
            // 
            resources.ApplyResources(this.lvDatabase, "lvDatabase");
            this.lvDatabase.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.lvDatabase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lvDatabase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.lvDatabase.FullRowSelect = true;
            this.lvDatabase.HideSelection = false;
            this.lvDatabase.Name = "lvDatabase";
            this.lvDatabase.TabStop = false;
            this.toolTip1.SetToolTip(this.lvDatabase, resources.GetString("lvDatabase.ToolTip"));
            this.lvDatabase.UseCompatibleStateImageBehavior = false;
            this.lvDatabase.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            resources.ApplyResources(this.columnHeader3, "columnHeader3");
            // 
            // columnHeader4
            // 
            resources.ApplyResources(this.columnHeader4, "columnHeader4");
            // 
            // columnHeader5
            // 
            resources.ApplyResources(this.columnHeader5, "columnHeader5");
            // 
            // columnHeader6
            // 
            resources.ApplyResources(this.columnHeader6, "columnHeader6");
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.tbSearch);
            this.groupBox1.Controls.Add(this.lblSearch);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // btnSearch
            // 
            resources.ApplyResources(this.btnSearch, "btnSearch");
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.TabStop = false;
            this.toolTip1.SetToolTip(this.btnSearch, resources.GetString("btnSearch.ToolTip"));
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            resources.ApplyResources(this.tbSearch, "tbSearch");
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.tbSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.tbSearch.Name = "tbSearch";
            this.toolTip1.SetToolTip(this.tbSearch, resources.GetString("tbSearch.ToolTip"));
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // lblSearch
            // 
            resources.ApplyResources(this.lblSearch, "lblSearch");
            this.lblSearch.Name = "lblSearch";
            this.toolTip1.SetToolTip(this.lblSearch, resources.GetString("lblSearch.ToolTip"));
            // 
            // tbBuy
            // 
            resources.ApplyResources(this.tbBuy, "tbBuy");
            this.tbBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.tbBuy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbBuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.tbBuy.Name = "tbBuy";
            this.toolTip1.SetToolTip(this.tbBuy, resources.GetString("tbBuy.ToolTip"));
            this.tbBuy.TextChanged += new System.EventHandler(this.tbBuy_TextChanged);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.btnGet);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.lblSell);
            this.groupBox2.Controls.Add(this.tbSell);
            this.groupBox2.Controls.Add(this.lblBuy);
            this.groupBox2.Controls.Add(this.tbBuy);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // btnGet
            // 
            resources.ApplyResources(this.btnGet, "btnGet");
            this.btnGet.Name = "btnGet";
            this.toolTip1.SetToolTip(this.btnGet, resources.GetString("btnGet.ToolTip"));
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnRemove
            // 
            resources.ApplyResources(this.btnRemove, "btnRemove");
            this.btnRemove.Name = "btnRemove";
            this.toolTip1.SetToolTip(this.btnRemove, resources.GetString("btnRemove.ToolTip"));
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.toolTip1.SetToolTip(this.btnEdit, resources.GetString("btnEdit.ToolTip"));
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.toolTip1.SetToolTip(this.btnAdd, resources.GetString("btnAdd.ToolTip"));
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblSell
            // 
            resources.ApplyResources(this.lblSell, "lblSell");
            this.lblSell.Name = "lblSell";
            this.toolTip1.SetToolTip(this.lblSell, resources.GetString("lblSell.ToolTip"));
            // 
            // tbSell
            // 
            resources.ApplyResources(this.tbSell, "tbSell");
            this.tbSell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(39)))), ((int)(((byte)(42)))));
            this.tbSell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSell.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.tbSell.Name = "tbSell";
            this.toolTip1.SetToolTip(this.tbSell, resources.GetString("tbSell.ToolTip"));
            // 
            // lblBuy
            // 
            resources.ApplyResources(this.lblBuy, "lblBuy");
            this.lblBuy.Name = "lblBuy";
            this.toolTip1.SetToolTip(this.lblBuy, resources.GetString("lblBuy.ToolTip"));
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.btnDisconnect);
            this.groupBox3.Controls.Add(this.btnConnect);
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // btnDisconnect
            // 
            resources.ApplyResources(this.btnDisconnect, "btnDisconnect");
            this.btnDisconnect.Name = "btnDisconnect";
            this.toolTip1.SetToolTip(this.btnDisconnect, resources.GetString("btnDisconnect.ToolTip"));
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            resources.ApplyResources(this.btnConnect, "btnConnect");
            this.btnConnect.Name = "btnConnect";
            this.toolTip1.SetToolTip(this.btnConnect, resources.GetString("btnConnect.ToolTip"));
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.lblAbout);
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // lblAbout
            // 
            resources.ApplyResources(this.lblAbout, "lblAbout");
            this.lblAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAbout.ForeColor = System.Drawing.Color.Blue;
            this.lblAbout.Name = "lblAbout";
            this.toolTip1.SetToolTip(this.lblAbout, resources.GetString("lblAbout.ToolTip"));
            this.lblAbout.Click += new System.EventHandler(this.lblAbout_Click);
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.rbVehicles);
            this.groupBox5.Controls.Add(this.rbItems);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            this.toolTip1.SetToolTip(this.groupBox5, resources.GetString("groupBox5.ToolTip"));
            // 
            // rbVehicles
            // 
            resources.ApplyResources(this.rbVehicles, "rbVehicles");
            this.rbVehicles.Name = "rbVehicles";
            this.rbVehicles.TabStop = true;
            this.toolTip1.SetToolTip(this.rbVehicles, resources.GetString("rbVehicles.ToolTip"));
            this.rbVehicles.UseVisualStyleBackColor = true;
            // 
            // rbItems
            // 
            resources.ApplyResources(this.rbItems, "rbItems");
            this.rbItems.Checked = true;
            this.rbItems.Name = "rbItems";
            this.rbItems.TabStop = true;
            this.toolTip1.SetToolTip(this.rbItems, resources.GetString("rbItems.ToolTip"));
            this.rbItems.UseVisualStyleBackColor = true;
            this.rbItems.CheckedChanged += new System.EventHandler(this.rbItems_CheckedChanged);
            // 
            // contextMenuStripLocal
            // 
            resources.ApplyResources(this.contextMenuStripLocal, "contextMenuStripLocal");
            this.contextMenuStripLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.wikiToolStripMenuItem1});
            this.contextMenuStripLocal.Name = "contextMenuStripLocal";
            this.contextMenuStripLocal.ShowImageMargin = false;
            this.toolTip1.SetToolTip(this.contextMenuStripLocal, resources.GetString("contextMenuStripLocal.ToolTip"));
            // 
            // addToolStripMenuItem
            // 
            resources.ApplyResources(this.addToolStripMenuItem, "addToolStripMenuItem");
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // wikiToolStripMenuItem1
            // 
            resources.ApplyResources(this.wikiToolStripMenuItem1, "wikiToolStripMenuItem1");
            this.wikiToolStripMenuItem1.Name = "wikiToolStripMenuItem1";
            this.wikiToolStripMenuItem1.Click += new System.EventHandler(this.wikiToolStripMenuItem1_Click);
            // 
            // contextMenuStripDatabase
            // 
            resources.ApplyResources(this.contextMenuStripDatabase, "contextMenuStripDatabase");
            this.contextMenuStripDatabase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem,
            this.editToolStripMenuItem,
            this.wikiToolStripMenuItem});
            this.contextMenuStripDatabase.Name = "contextMenuStripLocal";
            this.contextMenuStripDatabase.ShowImageMargin = false;
            this.toolTip1.SetToolTip(this.contextMenuStripDatabase, resources.GetString("contextMenuStripDatabase.ToolTip"));
            // 
            // removeToolStripMenuItem
            // 
            resources.ApplyResources(this.removeToolStripMenuItem, "removeToolStripMenuItem");
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // wikiToolStripMenuItem
            // 
            resources.ApplyResources(this.wikiToolStripMenuItem, "wikiToolStripMenuItem");
            this.wikiToolStripMenuItem.Name = "wikiToolStripMenuItem";
            this.wikiToolStripMenuItem.Click += new System.EventHandler(this.wikiToolStripMenuItem_Click);
            // 
            // btnImport
            // 
            resources.ApplyResources(this.btnImport, "btnImport");
            this.btnImport.Name = "btnImport";
            this.toolTip1.SetToolTip(this.btnImport, resources.GetString("btnImport.ToolTip"));
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCleanTable
            // 
            resources.ApplyResources(this.btnCleanTable, "btnCleanTable");
            this.btnCleanTable.Name = "btnCleanTable";
            this.toolTip1.SetToolTip(this.btnCleanTable, resources.GetString("btnCleanTable.ToolTip"));
            this.btnCleanTable.UseVisualStyleBackColor = true;
            this.btnCleanTable.Click += new System.EventHandler(this.btnCleanTable_Click);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.BackgroundImage = global::Unturned_Uconomy_Utility.Properties.Resources.GreyBacker;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.SizingGrip = false;
            this.toolTip1.SetToolTip(this.statusStrip1, resources.GetString("statusStrip1.ToolTip"));
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // frmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(47)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnCleanTable);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(137)))), ((int)(((byte)(218)))));
            this.Name = "frmMain";
            this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.contextMenuStripLocal.ResumeLayout(false);
            this.contextMenuStripDatabase.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblSell;
        private System.Windows.Forms.Label lblBuy;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblAbout;
        private System.Windows.Forms.ListView lvLocal;
        private System.Windows.Forms.ListView lvDatabase;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.RadioButton rbVehicles;
        internal System.Windows.Forms.RadioButton rbItems;
        internal System.Windows.Forms.TextBox tbBuy;
        internal System.Windows.Forms.TextBox tbSell;
        internal System.Windows.Forms.ToolStripStatusLabel lblStatus;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripLocal;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDatabase;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        internal System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnCleanTable;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ToolStripMenuItem wikiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wikiToolStripMenuItem1;
    }
}

