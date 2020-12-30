using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Unturned_Uconomy_Utility
{
    public partial class frmMain : Form
    {
        internal static frmMain Instance;

        internal static MySqlConnection dataConnection = new MySqlConnection();
        internal static List<ListViewItem> listOriginalItems = new List<ListViewItem>();
        internal static List<ListViewItem> listOriginalVehicles = new List<ListViewItem>();

        internal static List<ListViewItem> listUserItemsLocal = new List<ListViewItem>();
        internal static List<ListViewItem> listUserItemsDatabase = new List<ListViewItem>();
        internal static List<ListViewItem> listUserVehiclesLocal = new List<ListViewItem>();
        internal static List<ListViewItem> listUserVehiclesDatabase = new List<ListViewItem>();

        internal static string host = string.Empty;
        internal static string port = string.Empty;
        internal static string user = string.Empty;
        internal static string password = string.Empty;
        internal static string database = string.Empty;
        internal static string tableItems = "uconomyitemshop";
        internal static string tableVehicles = "uconomyvehicleshop";

        public const string ModdedItemsTable = "uconutility_modded_items";
        public const string ModdedVehiclesTable = "uconutility_modded_vehicles";

        internal static bool DetectMods = false;

        public Dictionary<ushort, string> ItemIndex = new Dictionary<ushort, string>();
        public Dictionary<ushort, string> VehicleIndex = new Dictionary<ushort, string>();

        public frmMain()
        {
            InitializeComponent();
            Instance = this;
            Init();
        }

        public async Task Init()
        {
            using (WebClient wcPastebin = new WebClient())
            {
                lblStatus.Text = "Retrieving items and vehicles from pastebin...";
                Refresh();

                string[] items = (await wcPastebin.DownloadStringTaskAsync(new Uri("http://pastebin.com/raw.php?i=HGGPMXFQ"))).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in items)
                {
                    string[] strSplit = item.Trim().Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                    ListViewItem lvItem = new ListViewItem(strSplit);
                    listOriginalItems.Add(lvItem);
                    listUserItemsLocal.Add(lvItem);

                    if (ushort.TryParse(strSplit[0], out ushort ID))
                        ItemIndex.Add(ID, strSplit[1]);
                }

                string[] vehicles = (await wcPastebin.DownloadStringTaskAsync(new Uri("http://pastebin.com/raw.php?i=sMjawF47"))).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string vehicle in vehicles)
                {
                    string[] strSplit = vehicle.Trim().Split(new string[] { "; " }, StringSplitOptions.RemoveEmptyEntries);
                    ListViewItem lvItem = new ListViewItem(strSplit);
                    listOriginalVehicles.Add(lvItem);
                    listUserVehiclesLocal.Add(lvItem);
                    if (ushort.TryParse(strSplit[0], out ushort ID))
                        VehicleIndex.Add(ID, strSplit[1]);
                }
                Console.WriteLine($"IDI {ItemIndex.Count}, IDV: {VehicleIndex.Count}");
                lvLocal.Items.AddRange(listUserItemsLocal.ToArray());
                lblStatus.Text = "Ready!";
            }

            AppDomain.CurrentDomain.ProcessExit += currentDomain_ProcessExit;
            dataConnection.StateChange += dataConnection_StateChange;
            this.tbBuy.KeyDown += new KeyEventHandler(tbBuy_KeyDown);
            this.tbBuy.KeyPress += new KeyPressEventHandler(tbBuy_KeyPress);
            this.tbSell.KeyDown += new KeyEventHandler(tbSell_KeyDown);
            this.tbSell.KeyPress += new KeyPressEventHandler(tbSell_KeyPress);
            this.tbSearch.KeyDown += new KeyEventHandler(tbSearch_KeyDown);
            this.tbSearch.PreviewKeyDown += new PreviewKeyDownEventHandler(tbSearch_PreviewKeyDown);
            this.lvLocal.MouseClick += new MouseEventHandler(lvLocal_MouseClick);
            this.lvLocal.MouseDoubleClick += new MouseEventHandler(lvLocal_MouseDoubleClick);
            this.lvDatabase.MouseClick += new MouseEventHandler(lvDatabase_MouseClick);
            this.lvDatabase.MouseDoubleClick += new MouseEventHandler(lvDatabase_MouseDoubleClick);
        }

        public bool LoadModded()
        {
            Console.WriteLine("loading modded...");
            try
            {
                Dictionary<ushort, string> Items = new Dictionary<ushort, string>();
                Dictionary<ushort, string> Vehicles = new Dictionary<ushort, string>();

                List<ushort> ShopItems = new List<ushort>();
                List<ushort> ShopVehicles = new List<ushort>();

                List<ushort> KnownItems = new List<ushort>();
                List<ushort> Knownvehicles = new List<ushort>();

                foreach (ListViewItem item in listOriginalItems)
                {
                    if (ushort.TryParse(item.SubItems[0].Text, out ushort id)) KnownItems.Add(id);
                }

                foreach (ListViewItem vehicle in listOriginalVehicles)
                {
                    if (ushort.TryParse(vehicle.SubItems[0].Text, out ushort id)) Knownvehicles.Add(id);
                }

                foreach (ListViewItem item in listUserItemsDatabase)
                {
                    if (ushort.TryParse(item.SubItems[0].Text, out ushort id)) ShopItems.Add(id);
                }

                foreach (ListViewItem vehicle in listUserVehiclesDatabase)
                {
                    if (ushort.TryParse(vehicle.SubItems[0].Text, out ushort id)) ShopVehicles.Add(id);
                }

                Console.WriteLine($"ShopItem: {ShopItems.Count}, V: {ShopVehicles.Count}");

                Console.WriteLine($"KI: {KnownItems.Count}, KV : {Knownvehicles.Count}");

                using (MySqlCommand itemCommand = new MySqlCommand($"SELECT * FROM `{ModdedItemsTable}`;", dataConnection))
                using (MySqlDataReader itemReader = itemCommand.ExecuteReader())
                {
                    while (itemReader.Read())
                    {
                        ushort ID = itemReader.GetUInt16(0);
                        string Name = itemReader.GetString(1);
                        Items.Add(ID, Name);
                    }
                }

                using (MySqlCommand vehicleCommand = new MySqlCommand($"SELECT * FROM `{ModdedVehiclesTable}`;", dataConnection))
                using (MySqlDataReader vehicleReader = vehicleCommand.ExecuteReader())
                {
                    while (vehicleReader.Read())
                    {
                        ushort ID = vehicleReader.GetUInt16(0);
                        string Name = vehicleReader.GetString(1);
                        Vehicles.Add(ID, Name);
                    }
                }
                Console.WriteLine($"Collected {Items.Count} items and {Vehicles.Count} vehicles");

                //listOriginalItems.Clear();
                //listOriginalVehicles.Clear();
                //listUserItemsLocal.Clear();
                //listUserVehiclesLocal.Clear();

                //lvLocal.Clear();
                //lvDatabase.Clear();

                var FilterItems = Items.Where(x => !KnownItems.Contains(x.Key));
                var FilterVehicles = Vehicles.Where(x => !Knownvehicles.Contains(x.Key));

                foreach (var item in FilterItems)
                {
                    ListViewItem vi = new ListViewItem(new string[] { item.Key.ToString(), item.Value });
                    listOriginalItems.Add(vi);

                    if (!ShopItems.Contains(item.Key))
                    {
                        listUserItemsLocal.Add(vi);

                        if (rbItems.Checked)
                        {
                            lvLocal.Items.Add(vi);
                        }
                    }
                }

                foreach (var vehicle in FilterVehicles)
                {
                    ListViewItem vi = new ListViewItem(new string[] { vehicle.Key.ToString(), vehicle.Value });
                    listOriginalVehicles.Add(vi);
                    if (!ShopVehicles.Contains(vehicle.Key))
                    {
                        listUserVehiclesLocal.Add(vi);
                        if (!rbItems.Checked)
                        {
                            lvLocal.Items.Add(vi);
                        }
                    }
                }

                foreach (var item in Items)
                {
                    if (!ItemIndex.ContainsKey(item.Key))
                    {
                        ItemIndex.Add(item.Key, item.Value);
                    }
                }

                foreach (var item in Vehicles)
                {
                    if (!VehicleIndex.ContainsKey(item.Key))
                    {
                        VehicleIndex.Add(item.Key, item.Value);
                    }
                }
                Console.WriteLine($"IDI {ItemIndex.Count}, IDV: {VehicleIndex.Count}");

                Console.WriteLine($"Loaded {FilterItems.Count()} modded items and {FilterVehicles.Count()} modded vehicles");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        internal void searchList()
        {
            lvLocal.BeginUpdate();
            lvDatabase.BeginUpdate();
            if (tbSearch.Text.Trim().Length == 0)
            {
                lvLocal.Items.Clear();
                lvDatabase.Items.Clear();
                if (rbItems.Checked)
                {
                    lvLocal.Items.AddRange(listUserItemsLocal.ToArray());
                    lvDatabase.Items.AddRange(listUserItemsDatabase.ToArray());
                }
                else
                {
                    lvLocal.Items.AddRange(listUserVehiclesLocal.ToArray());
                    lvDatabase.Items.AddRange(listUserVehiclesDatabase.ToArray());
                }
            }
            else
            {
                lvLocal.Items.Clear();
                lvDatabase.Items.Clear();
                if (rbItems.Checked)
                {
                    foreach (ListViewItem lvItemLocal in listUserItemsLocal)
                    {
                        if (lvItemLocal.Text.ToLower().Contains(tbSearch.Text.ToLower()) || lvItemLocal.SubItems[1].Text.ToLower().Contains(tbSearch.Text.ToLower()))
                        {
                            lvLocal.Items.Add(lvItemLocal);
                        }
                    }
                    foreach (ListViewItem lvItemDatabase in listUserItemsDatabase)
                    {
                        if (lvItemDatabase.Text.ToLower().Contains(tbSearch.Text.ToLower()) || lvItemDatabase.SubItems[1].Text.ToLower().Contains(tbSearch.Text.ToLower()))
                        {
                            lvDatabase.Items.Add(lvItemDatabase);
                        }
                    }
                }
                else
                {
                    foreach (ListViewItem lvItemLocal in listUserVehiclesLocal)
                    {
                        if (lvItemLocal.Text.ToLower().Contains(tbSearch.Text.ToLower()) || lvItemLocal.SubItems[1].Text.ToLower().Contains(tbSearch.Text.ToLower()))
                        {
                            lvLocal.Items.Add(lvItemLocal);
                        }
                    }
                    foreach (ListViewItem lvItemDatabase in listUserVehiclesDatabase)
                    {
                        if (lvItemDatabase.Text.ToLower().Contains(tbSearch.Text.ToLower()) || lvItemDatabase.SubItems[1].Text.ToLower().Contains(tbSearch.Text.ToLower()))
                        {
                            lvDatabase.Items.Add(lvItemDatabase);
                        }
                    }
                }
            }
            lvLocal.EndUpdate();
            lvDatabase.EndUpdate();
        }

        #region Click Events

        private void btnSearch_Click(object sender, EventArgs e)
        {
            searchList();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            new frmDatabase().ShowDialog();
            tbSearch.Focus();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            dataConnection.Close();
            tbSearch.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dataConnection.State != ConnectionState.Open || lvLocal.SelectedItems.Count == 0) { tbSearch.Focus(); return; }
            StringBuilder stringBuilder = new StringBuilder();

            if (rbItems.Checked) { foreach (ListViewItem lvSelectedItem in lvLocal.SelectedItems) { stringBuilder.AppendLine("INSERT INTO `" + tableItems + "` (id,itemname,cost,buyback) VALUES('" + lvSelectedItem.Text + "','" + lvSelectedItem.SubItems[1].Text.Replace(@"'", @"\'") + "','" + tbBuy.Text + "','" + tbSell.Text + "');"); } lblStatus.Text = "Trying to add item/s..."; }
            else { foreach (ListViewItem lvSelectedItem in lvLocal.SelectedItems) { stringBuilder.AppendLine("INSERT INTO `" + tableVehicles + "` (id,vehiclename,cost) VALUES('" + lvSelectedItem.Text + "','" + lvSelectedItem.SubItems[1].Text + "','" + tbBuy.Text + "');"); } lblStatus.Text = "Trying to add vehicle/s..."; }

            try
            {
                MySqlCommand dataCommand = new MySqlCommand(stringBuilder.ToString(), dataConnection);
                dataCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int lastIndex = lvLocal.SelectedItems[0].Index - 1;

            if (rbItems.Checked)
            {
                foreach (ListViewItem lvSelectedItem in lvLocal.SelectedItems)
                {
                    listUserItemsLocal.Remove(listUserItemsLocal.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text));
                    ListViewItem lvItem = new ListViewItem(lvSelectedItem.Text);
                    lvItem.SubItems.Add(lvSelectedItem.SubItems[1].Text);
                    lvItem.SubItems.Add(tbBuy.Text);
                    lvItem.SubItems.Add(tbSell.Text);
                    listUserItemsDatabase.Add(lvItem);
                }
                listUserItemsDatabase.Sort((s1, s2) => Convert.ToInt64(s1.Text).CompareTo(Convert.ToInt64(s2.Text)));
                lblStatus.Text = "Successfully added " + lvLocal.SelectedItems.Count.ToString() + " item/s.";
            }
            else
            {
                foreach (ListViewItem lvSelectedItem in lvLocal.SelectedItems)
                {
                    listUserVehiclesLocal.Remove(listUserVehiclesLocal.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text));
                    ListViewItem lvItem = new ListViewItem(lvSelectedItem.Text);
                    lvItem.SubItems.Add(lvSelectedItem.SubItems[1].Text);
                    lvItem.SubItems.Add(tbBuy.Text);
                    listUserVehiclesDatabase.Add(lvItem);
                }
                listUserVehiclesDatabase.Sort((s1, s2) => Convert.ToInt64(s1.Text).CompareTo(Convert.ToInt64(s2.Text)));
                lblStatus.Text = "Successfully added " + lvLocal.SelectedItems.Count.ToString() + " vehicle/s.";
            }

            searchList();
            if (lastIndex >= 0) { lvLocal.Items[lastIndex].Selected = true; lvLocal.EnsureVisible(lastIndex); }
            tbSearch.Focus();
        }

        public void SendBaseRemove()
        {
            if (dataConnection.State != ConnectionState.Open || lvDatabase.SelectedItems.Count == 0) { tbSearch.Focus(); return; }
            StringBuilder stringBuilder = new StringBuilder();

            if (rbItems.Checked) { foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems) { stringBuilder.AppendLine("DELETE FROM `" + tableItems + "` WHERE `id`='" + lvSelectedItem.Text.Replace(@"'", @"\'") + "';"); } lblStatus.Text = "Trying to remove item/s..."; }
            else { foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems) { stringBuilder.AppendLine("DELETE FROM `" + tableVehicles + "` WHERE `id`='" + lvSelectedItem.Text + "';"); } lblStatus.Text = "Trying to remove vehicle/s..."; }

            try
            {
                MySqlCommand dataCommand = new MySqlCommand(stringBuilder.ToString(), dataConnection);
                dataCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int lastIndex = lvDatabase.SelectedItems[0].Index - 1;

            if (rbItems.Checked)
            {
                foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems)
                {
                    listUserItemsDatabase.Remove(listUserItemsDatabase.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text));
                    ListViewItem lvItem = new ListViewItem(lvSelectedItem.Text);
                    lvItem.SubItems.Add(listOriginalItems.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text).SubItems[1].Text);
                    listUserItemsLocal.Add(lvItem);
                }
                listUserItemsLocal.Sort((s1, s2) => Convert.ToInt64(s1.Text).CompareTo(Convert.ToInt64(s2.Text)));
                lblStatus.Text = "Successfully removed " + lvDatabase.SelectedItems.Count.ToString() + " item/s.";
            }
            else
            {
                foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems)
                {
                    listUserVehiclesDatabase.Remove(listUserVehiclesDatabase.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text));
                    ListViewItem lvItem = new ListViewItem(lvSelectedItem.Text);
                    lvItem.SubItems.Add(listOriginalVehicles.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text).SubItems[1].Text);
                    listUserVehiclesLocal.Add(lvItem);
                }
                listUserVehiclesLocal.Sort((s1, s2) => Convert.ToInt64(s1.Text).CompareTo(Convert.ToInt64(s2.Text)));
                lblStatus.Text = "Successfully removed " + lvDatabase.SelectedItems.Count.ToString() + " vehicle/s.";
            }

            searchList();
            if (lastIndex >= 0) { lvDatabase.Items[lastIndex].Selected = true; lvDatabase.EnsureVisible(lastIndex); }
            tbSearch.Focus();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            SendBaseRemove();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataConnection.State != ConnectionState.Open || lvDatabase.SelectedItems.Count == 0) { tbSearch.Focus(); return; }
            StringBuilder stringBuilder = new StringBuilder();

            if (rbItems.Checked) { foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems) { stringBuilder.AppendLine("UPDATE `" + tableItems + "` SET `cost` = '" + tbBuy.Text + "', `buyback` = '" + tbSell.Text + "' WHERE `id` = '" + lvSelectedItem.Text + "';"); } lblStatus.Text = "Trying to edit item/s..."; }
            else { foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems) { stringBuilder.AppendLine("UPDATE `" + tableVehicles + "` SET `cost` = '" + tbBuy.Text + "' WHERE `id` = '" + lvSelectedItem.Text + "';"); } lblStatus.Text = "Trying to edit vehicle/s..."; }

            try
            {
                MySqlCommand dataCommand = new MySqlCommand(stringBuilder.ToString(), dataConnection);
                dataCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (rbItems.Checked)
            {
                foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems)
                {
                    lvSelectedItem.SubItems[2].Text = tbBuy.Text;
                    lvSelectedItem.SubItems[3].Text = tbSell.Text;
                    ListViewItem lvItem = listUserItemsDatabase.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text);
                    lvItem.SubItems[2].Text = tbBuy.Text;
                    lvItem.SubItems[3].Text = tbSell.Text;
                }
                lblStatus.Text = "Successfully edited " + lvDatabase.SelectedItems.Count.ToString() + " item/s.";
            }
            else
            {
                foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems)
                {
                    lvSelectedItem.SubItems[2].Text = tbBuy.Text;
                    ListViewItem lvItem = listUserVehiclesDatabase.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text);
                    lvItem.SubItems[2].Text = tbBuy.Text;
                }
                lblStatus.Text = "Successfully edited " + lvDatabase.SelectedItems.Count.ToString() + " vehicle/s.";
            }
            tbSearch.Focus();
        }

        public void SendDeleteAll(List<ushort> IDs, bool Item)
        {
            if (dataConnection.State != ConnectionState.Open || lvDatabase.SelectedItems.Count == 0) { tbSearch.Focus(); return; }
            StringBuilder stringBuilder = new StringBuilder();

            if (Item)
            {
                foreach (ushort ID in IDs)
                {
                    stringBuilder.AppendLine("DELETE FROM `" + tableItems + "` WHERE `id`='" + ID + "';");
                }
                lblStatus.Text = "Trying to remove item/s...";
            }
            else
            {
                foreach (ushort ID in IDs)
                {
                    stringBuilder.AppendLine("DELETE FROM `" + tableVehicles + "` WHERE `id`='" + ID + "';");
                }
                lblStatus.Text = "Trying to remove vehicle/s...";
            }

            try
            {
                MySqlCommand dataCommand = new MySqlCommand(stringBuilder.ToString(), dataConnection);
                dataCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int lastIndex = lvDatabase.SelectedItems[0].Index - 1;

            if (Item == rbItems.Checked)
            {
                if (rbItems.Checked)
                {
                    List<ListViewItem> RemoveItems = new List<ListViewItem>();
                    foreach (ListViewItem item in lvDatabase.Items)
                    {
                        if (ushort.TryParse(item.SubItems[0].Text, out ushort InnerID) && IDs.Contains(InnerID)) RemoveItems.Add(item);
                    }

                    foreach (ListViewItem item in RemoveItems)
                    {
                        lvDatabase.Items.Remove(item);
                        ListViewItem lvItem = new ListViewItem(item.Text);
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.SubItems[0].Text });
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.SubItems[1].Text });
                        listUserItemsLocal.Add(lvItem);
                    }
                    listUserItemsLocal.Sort((s1, s2) => Convert.ToInt64(s1.Text).CompareTo(Convert.ToInt64(s2.Text)));
                    lblStatus.Text = "Successfully removed " + lvDatabase.SelectedItems.Count.ToString() + " item/s.";
                }
                else
                {
                    List<ListViewItem> RemoveItems = new List<ListViewItem>();
                    foreach (ListViewItem item in lvDatabase.Items)
                    {
                        if (ushort.TryParse(item.SubItems[0].Text, out ushort InnerID) && IDs.Contains(InnerID)) RemoveItems.Add(item);
                    }

                    foreach (ListViewItem item in RemoveItems)
                    {
                        lvDatabase.Items.Remove(item);
                        ListViewItem lvItem = new ListViewItem(item.Text);
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.SubItems[0].Text });
                        lvItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.SubItems[1].Text });
                        listUserItemsLocal.Add(lvItem);
                    }
                    listUserItemsLocal.Sort((s1, s2) => Convert.ToInt64(s1.Text).CompareTo(Convert.ToInt64(s2.Text)));
                    lblStatus.Text = "Successfully removed " + lvDatabase.SelectedItems.Count.ToString() + " vehicle/s.";
                }
            }
            else
            {
                if (Item)
                {
                    lblStatus.Text = "Successfully removed " + lvDatabase.SelectedItems.Count.ToString() + " item/s.";
                }
                else
                {
                    lblStatus.Text = "Successfully removed " + lvDatabase.SelectedItems.Count.ToString() + " vehicle/s.";
                }
            }

            searchList();
            if (lastIndex >= 0) { lvDatabase.Items[lastIndex].Selected = true; lvDatabase.EnsureVisible(lastIndex); }
            tbSearch.Focus();
        }

        public void SendEditAll(decimal Buyprice, decimal Sellprice)
        {
            if (dataConnection.State != ConnectionState.Open || lvDatabase.SelectedItems.Count == 0) { tbSearch.Focus(); return; }
            StringBuilder stringBuilder = new StringBuilder();

            if (rbItems.Checked) { foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems) { stringBuilder.AppendLine("UPDATE `" + tableItems + "` SET `cost` = '" + Buyprice + "', `buyback` = '" + Sellprice + "' WHERE `id` = '" + lvSelectedItem.Text + "';"); } lblStatus.Text = "Trying to edit item/s..."; }
            else { foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems) { stringBuilder.AppendLine("UPDATE `" + tableVehicles + "` SET `cost` = '" + Buyprice + "' WHERE `id` = '" + lvSelectedItem.Text + "';"); } lblStatus.Text = "Trying to edit vehicle/s..."; }

            try
            {
                MySqlCommand dataCommand = new MySqlCommand(stringBuilder.ToString(), dataConnection);
                dataCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (rbItems.Checked)
            {
                foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems)
                {
                    lvSelectedItem.SubItems[2].Text = tbBuy.Text;
                    lvSelectedItem.SubItems[3].Text = tbSell.Text;
                    ListViewItem lvItem = listUserItemsDatabase.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text);
                    lvItem.SubItems[2].Text = tbBuy.Text;
                    lvItem.SubItems[3].Text = tbSell.Text;
                }
                lblStatus.Text = "Successfully edited " + lvDatabase.SelectedItems.Count.ToString() + " item/s.";
            }
            else
            {
                foreach (ListViewItem lvSelectedItem in lvDatabase.SelectedItems)
                {
                    lvSelectedItem.SubItems[2].Text = tbBuy.Text;
                    ListViewItem lvItem = listUserVehiclesDatabase.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text);
                    lvItem.SubItems[2].Text = tbBuy.Text;
                }
                lblStatus.Text = "Successfully edited " + lvDatabase.SelectedItems.Count.ToString() + " vehicle/s.";
            }
            tbSearch.Focus();
        }

        public void SendEditAll(bool items, decimal Buyprice, decimal Sellprice, List<ushort> IDs)
        {
            if (dataConnection.State != ConnectionState.Open || lvDatabase.SelectedItems.Count == 0) { tbSearch.Focus(); return; }
            StringBuilder stringBuilder = new StringBuilder();

            if (items)
            {
                foreach (ushort ID in IDs)
                {
                    stringBuilder.AppendLine("UPDATE `" + tableItems + "` SET `cost` = '" + Buyprice + "', `buyback` = '" + Sellprice + "' WHERE `id` = '" + ID + "';");
                }
                lblStatus.Text = "Trying to edit item/s...";
            }
            else
            {
                foreach (ushort ID in IDs)
                {
                    stringBuilder.AppendLine("UPDATE `" + tableVehicles + "` SET `cost` = '" + Buyprice + "' WHERE `id` = '" + ID + "';");
                }
                lblStatus.Text = "Trying to edit vehicle/s...";
            }

            try
            {
                MySqlCommand dataCommand = new MySqlCommand(stringBuilder.ToString(), dataConnection);
                dataCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (items == rbItems.Checked)
            {
                if (rbItems.Checked)
                {
                    foreach (ushort ID in IDs)
                    {
                        foreach (ListViewItem i in lvDatabase.Items)
                        {
                            if (i.SubItems[0].Text == ID.ToString())
                            {
                                i.SubItems[2].Text = Buyprice.ToString();
                                i.SubItems[3].Text = Sellprice.ToString();
                            }
                        }
                    }
                    lblStatus.Text = "Successfully edited " + IDs.Count + " item/s.";
                }
                else
                {
                    foreach (ushort ID in IDs)
                    {
                        foreach (ListViewItem i in lvDatabase.Items)
                        {
                            if (i.SubItems[0].Text == ID.ToString())
                            {
                                i.SubItems[2].Text = Buyprice.ToString();
                            }
                        }
                    }
                    lblStatus.Text = "Successfully edited " + lvDatabase.SelectedItems.Count.ToString() + " vehicle/s.";
                }
            }
            else
            {
                if (items)
                {
                    lblStatus.Text = "Successfully edited " + IDs.Count + " item/s.";
                }
                else
                {
                    lblStatus.Text = "Successfully edited " + lvDatabase.SelectedItems.Count.ToString() + " vehicle/s.";
                }
            }

            tbSearch.Focus();
        }

        public void SendAddAll(bool items, decimal Buyprice, decimal Sellprice, List<ushort> IDs)
        {
            if (dataConnection.State != ConnectionState.Open || lvLocal.SelectedItems.Count == 0) { tbSearch.Focus(); return; }
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine("run cmds");
            if (items)
            {
                foreach (ushort ID in IDs)
                {
                    string name = "UNKNOWN";
                    if (ItemIndex.ContainsKey(ID))
                        name = ItemIndex[ID].Replace("'", "''");

                    stringBuilder.AppendLine("INSERT INTO `" + tableItems + $"` VALUES ({ID}, '{name}', {Buyprice}, {Sellprice}); ");
                }
                lblStatus.Text = "Trying to add item/s...";
            }
            else
            {
                foreach (ushort ID in IDs)
                {
                    string name = "UNKNOWN";
                    if (ItemIndex.ContainsKey(ID))
                        name = ItemIndex[ID].Replace("'", "''");

                    stringBuilder.AppendLine("INSERT INTO `" + tableVehicles + $"` VALUES ({ID}, '{name}', {Buyprice}); ");
                }
                lblStatus.Text = "Trying to add vehicle/s...";
            }
            Console.WriteLine($"cmd dump:");
            Console.WriteLine();
            Console.WriteLine(stringBuilder.ToString());
            try
            {
                MySqlCommand dataCommand = new MySqlCommand(stringBuilder.ToString(), dataConnection);
                dataCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex) { MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int lastIndex = lvLocal.SelectedItems[0].Index - 1;

            if (rbItems.Checked)
            {
                foreach (ListViewItem lvSelectedItem in lvLocal.SelectedItems)
                {
                    listUserItemsLocal.Remove(listUserItemsLocal.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text));
                    ListViewItem lvItem = new ListViewItem(lvSelectedItem.Text);
                    lvItem.SubItems.Add(lvSelectedItem.SubItems[1].Text);
                    lvItem.SubItems.Add(Buyprice.ToString());
                    lvItem.SubItems.Add(Sellprice.ToString());
                    listUserItemsDatabase.Add(lvItem);
                }
                listUserItemsDatabase.Sort((s1, s2) => Convert.ToInt64(s1.Text).CompareTo(Convert.ToInt64(s2.Text)));
                lblStatus.Text = "Successfully added " + lvLocal.SelectedItems.Count.ToString() + " item/s.";
            }
            else
            {
                foreach (ListViewItem lvSelectedItem in lvLocal.SelectedItems)
                {
                    listUserVehiclesLocal.Remove(listUserVehiclesLocal.FirstOrDefault(cus => cus.Text == lvSelectedItem.Text));
                    ListViewItem lvItem = new ListViewItem(lvSelectedItem.Text);
                    lvItem.SubItems.Add(lvSelectedItem.SubItems[1].Text);
                    lvItem.SubItems.Add(Buyprice.ToString());
                    listUserVehiclesDatabase.Add(lvItem);
                }
                listUserVehiclesDatabase.Sort((s1, s2) => Convert.ToInt64(s1.Text).CompareTo(Convert.ToInt64(s2.Text)));
                lblStatus.Text = "Successfully added " + lvLocal.SelectedItems.Count.ToString() + " vehicle/s.";
            }

            searchList();
            if (lastIndex >= 0) { lvLocal.Items[lastIndex].Selected = true; lvLocal.EnsureVisible(lastIndex); }
            tbSearch.Focus();

            tbSearch.Focus();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (lvDatabase.SelectedItems.Count > 0)
            {
                strCurrencyBuy = lvDatabase.SelectedItems[0].SubItems[2].Text.Replace(".", string.Empty);
                tbBuy.Text = lvDatabase.SelectedItems[0].SubItems[2].Text;
                if (rbItems.Checked)
                {
                    strCurrencySell = lvDatabase.SelectedItems[0].SubItems[3].Text.Replace(".", string.Empty);
                    tbSell.Text = lvDatabase.SelectedItems[0].SubItems[3].Text;
                }
            }
            tbSearch.Focus();
        }

        private void btnCleanTable_Click(object sender, EventArgs e)
        {
            new frmCleanTables().ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            new frmImport().ShowDialog();
        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=DC6ZS6AES6GUE");
        }

        private void lblAbout_Click(object sender, EventArgs e)
        {
            Process.Start("http://steamcommunity.com/profiles/76561198187138313");
        }

        #endregion Click Events

        #region ListView / Context Menu Events

        private void lvLocal_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvLocal.FocusedItem.Bounds.Contains(e.Location) && lvLocal.SelectedItems.Count > 0) { contextMenuStripLocal.Show(Cursor.Position); }
        }

        private void lvLocal_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            addToolStripMenuItem.PerformClick();
            //if (lvLocal.FocusedItem.Bounds.Contains(e.Location) && lvLocal.SelectedItems.Count > 0) { Process.Start("http://unturned.wikia.com/wiki/" + lvLocal.SelectedItems[0].SubItems[1].Text); }
        }

        private void lvDatabase_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && lvDatabase.FocusedItem.Bounds.Contains(e.Location) && lvDatabase.SelectedItems.Count > 0) { contextMenuStripDatabase.Show(Cursor.Position); }
        }

        private void lvDatabase_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editToolStripMenuItem_Click(sender, e);
        }

        public void SendWiki()
        {
            if (lvDatabase.SelectedItems.Count > 0)
            {
                Process.Start("http://unturned.wikia.com/wiki/" + lvDatabase.SelectedItems[0].SubItems[1].Text);
            }
        }

        public void SendWikiLocal()
        {
            if (lvLocal.SelectedItems.Count > 0)
            {
                Process.Start("http://unturned.wikia.com/wiki/" + lvLocal.SelectedItems[0].SubItems[1].Text);
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //btnAdd.PerformClick();

            List<ushort> IDs = new List<ushort>();
            List<string> Names = new List<string>();

            decimal buy = 0;
            decimal sell = 0;
            foreach (ListViewItem item in lvLocal.SelectedItems)
            {
                if (ushort.TryParse(item.SubItems[0].Text, out ushort id))
                {
                    IDs.Add(id);
                    Names.Add(item.SubItems[1].Text);
                }
            }
            string title;
            if (Names.Count < 4)
            {
                title = string.Join(", ", Names);
            }
            else
            {
                title = $"Adding {IDs.Count} {(rbItems.Checked ? "items" : "vehicles")}";
            }
            new EditDbEntry(IDs, rbItems.Checked, AddCallback, null, buy, sell, title).ShowDialog();
        }

        public void AddCallback(List<ushort> IDs, byte Type, decimal Buy, decimal Sell)
        {
            Console.WriteLine("Run add callback");
            SendAddAll(Type == 1, Buy, Sell, IDs);
        }

        /*
         *
         *         private void editToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    //btnEdit.PerformClick();

                    List<ushort> IDs = new List<ushort>();
                    List<string> Names = new List<string>();

                    decimal buy = 0;
                    decimal sell = 0;
                    foreach (ListViewItem item in lvDatabase.SelectedItems)
                    {
                        if (ushort.TryParse(item.SubItems[0].Text, out ushort id))
                        {
                            IDs.Add(id);
                            Names.Add(item.SubItems[1].Text);

                            decimal.TryParse(item.SubItems[2].Text, out buy);
                            if (rbItems.Checked)
                                decimal.TryParse(item.SubItems[3].Text, out sell);
                        }
                    }
                    string title;
                    if (Names.Count < 4)
                    {
                        title = string.Join(", ", Names);
                    }
                    else
                    {
                        title = $"Editing {IDs.Count} {(rbItems.Checked ? "items" : "vehicles")}";
                    }
                    new EditDbEntry(IDs, rbItems.Checked, EditCallback, DeleteCallback, buy, sell, title).ShowDialog();
                }

                public void EditCallback(List<ushort> IDs, byte Type, decimal Buy, decimal Sell)
                {
                    SendEditAll(Type == 1, Buy, Sell, IDs);
                }

                public void DeleteCallback(List<ushort> IDs, byte Type)
                {
                    SendDeleteAll(IDs, Type == 1);
                }
        */

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRemove.PerformClick();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //btnEdit.PerformClick();

            List<ushort> IDs = new List<ushort>();
            List<string> Names = new List<string>();

            decimal buy = 0;
            decimal sell = 0;
            foreach (ListViewItem item in lvDatabase.SelectedItems)
            {
                if (ushort.TryParse(item.SubItems[0].Text, out ushort id))
                {
                    IDs.Add(id);
                    Names.Add(item.SubItems[1].Text);

                    decimal.TryParse(item.SubItems[2].Text, out buy);
                    if (rbItems.Checked)
                        decimal.TryParse(item.SubItems[3].Text, out sell);
                }
            }
            string title;
            if (Names.Count < 4)
            {
                title = string.Join(", ", Names);
            }
            else
            {
                title = $"Editing {IDs.Count} {(rbItems.Checked ? "items" : "vehicles")}";
            }
            new EditDbEntry(IDs, rbItems.Checked, EditCallback, DeleteCallback, buy, sell, title).ShowDialog();
        }

        public void EditCallback(List<ushort> IDs, byte Type, decimal Buy, decimal Sell)
        {
            SendEditAll(Type == 1, Buy, Sell, IDs);
        }

        public void DeleteCallback(List<ushort> IDs, byte Type)
        {
            SendDeleteAll(IDs, Type == 1);
        }

        #endregion ListView / Context Menu Events

        #region TextBox Events

        private string strCurrencyBuy = string.Empty;
        private string strCurrencySell = string.Empty;
        private bool acceptableKey = false;

        private void tbBuy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tbBuy.Text = "0.00";
                strCurrencyBuy = string.Empty;
                acceptableKey = false;
            }
            if ((e.KeyCode >= Keys.D0 & e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 & e.KeyCode <= Keys.NumPad9) || e.KeyCode == Keys.Back) { acceptableKey = true; }
            else { acceptableKey = false; e.SuppressKeyPress = true; }
        }

        private void tbBuy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!acceptableKey) { e.Handled = true; return; }
            else
            {
                if (e.KeyChar == Convert.ToChar(Keys.Back)) { if (strCurrencyBuy.Length > 0) { strCurrencyBuy = strCurrencyBuy.Substring(0, strCurrencyBuy.Length - 1); } }
                else { strCurrencyBuy = strCurrencyBuy + e.KeyChar; }

                if (strCurrencyBuy.Length == 0) { tbBuy.Text = "0.00"; }
                else if (strCurrencyBuy.Length == 1) { tbBuy.Text = "0.0" + strCurrencyBuy; }
                else if (strCurrencyBuy.Length == 2) { tbBuy.Text = "0." + strCurrencyBuy; }
                else if (strCurrencyBuy.Length > 2) { tbBuy.Text = strCurrencyBuy.Substring(0, strCurrencyBuy.Length - 2) + "." + strCurrencyBuy.Substring(strCurrencyBuy.Length - 2); }
                tbBuy.Select(tbBuy.Text.Length, 0);
            }
            e.Handled = true;
        }

        private void tbSell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tbSell.Text = "0.00";
                strCurrencySell = string.Empty;
                acceptableKey = false;
            }
            if ((e.KeyCode >= Keys.D0 & e.KeyCode <= Keys.D9) || (e.KeyCode >= Keys.NumPad0 & e.KeyCode <= Keys.NumPad9) || e.KeyCode == Keys.Back) { acceptableKey = true; }
            else { acceptableKey = false; e.SuppressKeyPress = true; }
        }

        private void tbSell_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!acceptableKey) { e.Handled = true; return; }
            else
            {
                if (e.KeyChar == Convert.ToChar(Keys.Back)) { if (strCurrencySell.Length > 0) { strCurrencySell = strCurrencySell.Substring(0, strCurrencySell.Length - 1); } }
                else { strCurrencySell = strCurrencySell + e.KeyChar; }

                if (strCurrencySell.Length == 0) { tbSell.Text = "0.00"; }
                else if (strCurrencySell.Length == 1) { tbSell.Text = "0.0" + strCurrencySell; }
                else if (strCurrencySell.Length == 2) { tbSell.Text = "0." + strCurrencySell; }
                else if (strCurrencySell.Length > 2) { tbSell.Text = strCurrencySell.Substring(0, strCurrencySell.Length - 2) + "." + strCurrencySell.Substring(strCurrencySell.Length - 2); }
                tbSell.Select(tbSell.Text.Length, 0);
            }
            e.Handled = true;
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                tbSearch.Clear();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        private void tbSearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (rbItems.Checked)
                {
                    rbItems.Checked = false;
                    rbVehicles.Checked = true;
                }
                else
                {
                    rbItems.Checked = true;
                    rbVehicles.Checked = false;
                }
            }
        }

        #endregion TextBox Events

        #region Other Events

        private void currentDomain_ProcessExit(object sender, EventArgs e)
        {
            if (dataConnection.State == ConnectionState.Open) { dataConnection.Close(); }
        }

        private void dataConnection_StateChange(object sender, StateChangeEventArgs e)
        {
            if (e.CurrentState == ConnectionState.Open)
            {
                Console.WriteLine("refreshing data....");
                lblStatus.Text = "Successfully connected to MySQL host. Loading items and vehicles...";
                Refresh();

                MySqlCommand dataCommand;
                dataCommand = new MySqlCommand("SELECT * FROM `" + tableItems + "`;", dataConnection);
                using (MySqlDataReader dataReaderItems = dataCommand.ExecuteReader())
                {
                    while (dataReaderItems.Read())
                    {
                        ListViewItem lvItem = new ListViewItem(dataReaderItems["id"].ToString());
                        lvItem.SubItems.Add(dataReaderItems["itemname"].ToString());
                        lvItem.SubItems.Add(dataReaderItems["cost"].ToString().Replace(",", "."));
                        lvItem.SubItems.Add(dataReaderItems["buyback"].ToString().Replace(",", "."));

                        listUserItemsDatabase.Add(lvItem);
                    }
                }
                dataCommand = new MySqlCommand("SELECT * FROM `" + tableVehicles + "`;", dataConnection);
                using (MySqlDataReader dataReaderVehicles = dataCommand.ExecuteReader())
                {
                    while (dataReaderVehicles.Read())
                    {
                        ListViewItem lvItem = new ListViewItem(dataReaderVehicles["id"].ToString());
                        lvItem.SubItems.Add(dataReaderVehicles["vehiclename"].ToString());
                        lvItem.SubItems.Add(dataReaderVehicles["cost"].ToString().Replace(",", "."));

                        listUserVehiclesDatabase.Add(lvItem);
                    }
                }
                dataCommand.Dispose();

                List<ListViewItem> listItemsToRemove = new List<ListViewItem>();
                List<ListViewItem> listVehiclesToRemove = new List<ListViewItem>();
                foreach (ListViewItem lvItem in listUserItemsLocal)
                {
                    if (listUserItemsDatabase.Exists(cus => cus.Text == lvItem.Text)) { listItemsToRemove.Add(lvItem); }
                }
                foreach (ListViewItem lvItem in listUserVehiclesLocal)
                {
                    if (listUserVehiclesDatabase.Exists(cus => cus.Text == lvItem.Text)) { listVehiclesToRemove.Add(lvItem); }
                }
                foreach (ListViewItem lvItem in listItemsToRemove) { listUserItemsLocal.Remove(lvItem); }
                foreach (ListViewItem lvItem in listVehiclesToRemove) { listUserVehiclesLocal.Remove(lvItem); }

                lvLocal.Items.Clear();
                if (rbItems.Checked)
                {
                    lvLocal.Items.AddRange(listUserItemsLocal.ToArray());
                    lvDatabase.Items.AddRange(listUserItemsDatabase.ToArray());
                }
                else
                {
                    lvLocal.Items.AddRange(listUserVehiclesLocal.ToArray());
                    lvDatabase.Items.AddRange(listUserVehiclesDatabase.ToArray());
                }

                btnConnect.Enabled = false;
                btnDisconnect.Enabled = true;
                btnCleanTable.Enabled = true;
                lblStatus.Text = "Successfully loaded items and vehicles.";
            }
            else if (e.CurrentState == ConnectionState.Closed || e.CurrentState == ConnectionState.Broken)
            {
                lvLocal.Items.Clear();
                lvDatabase.Items.Clear();
                listUserItemsDatabase.Clear();
                listUserVehiclesDatabase.Clear();
                listUserItemsLocal = new List<ListViewItem>(listOriginalItems);
                listUserVehiclesLocal = new List<ListViewItem>(listOriginalVehicles);

                if (rbItems.Checked) { lvLocal.Items.AddRange(listUserItemsLocal.ToArray()); }
                else { lvLocal.Items.AddRange(listUserVehiclesLocal.ToArray()); }

                btnConnect.Enabled = true;
                btnDisconnect.Enabled = false;
                btnCleanTable.Enabled = false;
                if (e.CurrentState == ConnectionState.Closed) { lblStatus.Text = "Disconnected from MySQL host."; }
                else if (e.CurrentState == ConnectionState.Broken) { lblStatus.Text = "Lost connection to MySQL host."; }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            searchList();
        }

        private void rbItems_CheckedChanged(object sender, EventArgs e)
        {
            lvLocal.Items.Clear();
            lvDatabase.Items.Clear();

            if (rbItems.Checked)
            {
                tbSell.Enabled = true;
                lvLocal.Items.AddRange(listUserItemsLocal.ToArray());
                if (dataConnection.State == ConnectionState.Open) { lvDatabase.Items.AddRange(listUserItemsDatabase.ToArray()); }
            }
            else
            {
                tbSell.Enabled = false;
                lvLocal.Items.AddRange(listUserVehiclesLocal.ToArray());
                if (dataConnection.State == ConnectionState.Open) { lvDatabase.Items.AddRange(listUserVehiclesDatabase.ToArray()); }
            }

            tbSearch.Focus();
        }

        #endregion Other Events

        private void tbBuy_TextChanged(object sender, EventArgs e)
        {
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendWiki();
        }

        private void wikiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SendWikiLocal();
        }
    }
}