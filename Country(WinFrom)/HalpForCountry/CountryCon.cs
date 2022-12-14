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

namespace Country_WinFrom_.HalpForCountry
{
   
    public partial class CountryCon : UserControl
    {
        private readonly Country _country;
        private readonly string _url;
        private readonly HalperAPI _api;
        public CountryCon(Country country)
        {
            _country = country;
            _url= "https://localhost:7296/api/Country";
            _api = new HalperAPI(_url);
            InitializeComponent();
            label1.Text = _country.Name;
        }

        private async void edit(object sender, EventArgs e)
        {
            new Edit(_country).Show();
        }

        private void Click_ShowCountry(object sender, EventArgs e)
        {
           new CountryOne(_country).Show(); 
        }

        private async void Delete(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Delete",
                "A Question",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if(res == DialogResult.Cancel)
            {
                new Form1().Close();
            }
            else
            {
                string str = await _api.Delete(_country.Id);
                new Form1().Close();
            }
             
            

        }
    }
}
