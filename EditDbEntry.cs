using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Unturned_Uconomy_Utility
{
    public partial class EditDbEntry : Form
    {
        public List<ushort> IDs = new List<ushort>();
        public byte IDType;

        public delegate void SaveCallbackArgs(List<ushort> IDs, byte Type, decimal Buy, decimal Sell);

        public delegate void DeleteCallbackArgs(List<ushort> IDs, byte Type);

        public SaveCallbackArgs SaveCallback;
        public DeleteCallbackArgs DeleteCallback;

        public EditDbEntry(List<ushort> EntryIDs, bool IsItem, SaveCallbackArgs saveCallback, DeleteCallbackArgs deleteCallback, decimal InitalBuy, decimal InitialSell, string TitleText)
        {
            IDs = EntryIDs;
            IDType = (byte)(IsItem ? 1 : 0);
            SaveCallback = saveCallback;
            DeleteCallback = deleteCallback;
            InitializeComponent();
            txtBuy.Text = InitalBuy.ToString();
            txtSell.Text = InitialSell.ToString();
            Text = TitleText;
            if (!IsItem)
            {
                txtSell.Enabled = false;
            }
        }

        public EditDbEntry()
        {
            InitializeComponent();
        }

        private static char[] Numerics = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private string ScrubNumeric(string input)
        {
            StringBuilder outb = new StringBuilder();
            bool HasDecimal = false;

            foreach (char cha in input)
            {
                if (Numerics.Contains(cha))
                {
                    outb.Append(cha);
                }
                else if (cha == '.' && !HasDecimal)
                {
                    HasDecimal = true;
                    outb.Append(cha);
                }
            }
            return outb.ToString();
        }

        private void txtBuy_TextChanged(object sender, EventArgs e)
        {
            txtBuy.Text = ScrubNumeric(txtBuy.Text);
        }

        private void txtSell_TextChanged(object sender, EventArgs e)
        {
            txtSell.Text = ScrubNumeric(txtSell.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCallback(IDs, IDType, decimal.Parse(txtBuy.Text), decimal.Parse(txtSell.Text));
            Close();
        }

        private void SendDelete()
        {
            DeleteCallback(IDs, IDType);
            Close();
        }

        private void EditDbEntry_Load(object sender, EventArgs e)
        {

        }
    }
}