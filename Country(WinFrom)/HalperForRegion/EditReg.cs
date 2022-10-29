using Data1.DTO;
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
    public partial class EditReg : Form
    {
        private readonly Region region1;
        private readonly  string _url;
        private readonly  HalperAPI _aPI;
        public EditReg(Region region)
        {
            region1 = region;
            _url = "https://localhost:7296/api/Region";
            _aPI =new HalperAPI(_url);
            InitializeComponent();
            lblId.Text=region1.Id.ToString();
            txtName.Text = region1.Name;
            txtUrl.Text = region1.MapUrl;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            RegionDto dto = new RegionDto();
            dto.Name = txtName.Text;
            dto.MapUrl = txtUrl.Text;
            dto.CountryId = region1.CountryId;


            string str = await _aPI.PutRegion(int.Parse(lblId.Text), dto);
            MessageBox.Show(str);
            this.Close();

        }
    }
}
