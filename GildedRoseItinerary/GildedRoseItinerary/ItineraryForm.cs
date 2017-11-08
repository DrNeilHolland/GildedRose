using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GildedRoseItinerary
{
    public partial class ItineraryForm : Form
    {
        InventoryManager manager = new InventoryManager();

        public ItineraryForm()
        {
            InitializeComponent();
            UpdateInventoryView(manager.ReadTestInput());
        }

        private void ItineraryForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateInventoryView(string[] lines)
        {
            tbItinerary.Clear();
            foreach (string line in lines)
                tbItinerary.AppendText(line + "\n");
        }

        private void bnUpdate_Click(object sender, EventArgs e)
        {
            UpdateInventoryView(manager.UpdateItems());
        }
    }
}
