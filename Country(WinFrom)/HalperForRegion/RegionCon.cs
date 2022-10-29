using Data1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToWinFromFromAPI;
using Region = Data1.Models.Region;

namespace Country_WinFrom_.HalperForRegion
{
    
    public partial class RegionCon : UserControl
    {
        private readonly Region _reg;
        private readonly string _url;
        private readonly HalperAPI _aPi;
        public RegionCon(Region re)
        {
            _reg = re;
            _url = "https://localhost:7296/api/Region";
            _aPi = new HalperAPI(_url);
            InitializeComponent();
            label1.Text = _reg.Name;

        }

        private async void delete(object sender, EventArgs e)
        {
            MessageBox.Show("Rosdan ham " + _reg.Name + "ni o'chirmoqchimisiz", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            string str = await _aPi.DeleteRegion(_reg.Id);
            MessageBox.Show(str);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new EditReg(_reg).Show();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cilk_Region_Show(object sender, EventArgs e)
        {
            new RegionShow(_reg).Show();
        }
    }
}
