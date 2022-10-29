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

namespace Country_WinFrom_.HalpForCountry
{
    public partial class PostC : Form
    {
        private readonly string _url;
        
        private readonly HalperAPI _aPI;
        public PostC()
        {
            _url = "https://localhost:7296/api/Country";
            _aPI = new HalperAPI(_url);
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            CounrtyDto country = new CounrtyDto();
            country.Name = txtTitle.Text;
            country.MspUrl = txtUrl.Text;
            country.Description = richTextBox.Text;


            string str = await _aPI.Post( country);
            MessageBox.Show(str);
            this.Close();
        }
    }
}
