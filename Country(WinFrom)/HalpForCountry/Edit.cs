using Data1.DTO;
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
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Country_WinFrom_.HalpForCountry
{
    public partial class Edit : Form
    {
        private readonly string _url;
        private readonly Country _country;
        private readonly HalperAPI _aPI;
        public Edit(Country country)
        {
            _country = country;
            _url = "https://localhost:7296/api/Country";
            _aPI = new HalperAPI(_url);
            InitializeComponent();
            lblID.Text = _country.Id.ToString();
            txtTitle.Text = _country.Name;
            txtUrl.Text = _country.MspUrl;
            richTextBox.Text = _country.Description;

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            CounrtyDto country = new CounrtyDto();
            country.Name = txtTitle.Text;
            country.MspUrl = txtUrl.Text;
            country.Description = richTextBox.Text;
            

            string str = await _aPI.Put(int.Parse(lblID.Text), country);
            MessageBox.Show(str);
            this.Close();


        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblUrl_Click(object sender, EventArgs e)
        {

        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
