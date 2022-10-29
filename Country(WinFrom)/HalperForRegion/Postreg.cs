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
using Region = Data1.Models.Region;

namespace Country_WinFrom_.HalperForRegion
{
    public partial class Postreg : Form
    {
        
        private readonly string _url;
        private readonly  HalperAPI _aPI;
        private readonly int countryID;
       
        public Postreg(int Id)
        {
            countryID = Id;
            _url = "https://localhost:7296/api/Region";
            _aPI = new HalperAPI(_url);
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            RegionDto dto = new RegionDto();
            dto.Name = txtName.Text;
            dto.MapUrl = txtUrl.Text;
            dto.CountryId = countryID;


            string str = await _aPI.PostRegion(dto);
            MessageBox.Show(str);
            this.Close();
        }
    }
}
