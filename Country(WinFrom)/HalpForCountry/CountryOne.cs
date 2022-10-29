using Country_WinFrom_.HalperForRegion;
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
using Region = Data1.Models.Region;

namespace Country_WinFrom_.HalpForCountry
{
    public partial class CountryOne : Form
    {
        private readonly Country _country;
        public CountryOne(Country country)
        {
            _country = country;
            InitializeComponent();
            pictureBox1.ImageLocation = _country.MspUrl;
            label3.Text = _country.Name;
            richTextBox.Text = _country.Description;
            foreach (var item in _country.Regions)
            {
                addReg(item);
            }
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void addReg(Region region)
        {
            RegionCon usr = new RegionCon(region);
            usr.Dock = DockStyle.Top;
            panel1.Controls.Add(usr);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Postreg(_country.Id).Show();
        }
    }
}
