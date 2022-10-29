using Country_WinFrom_.HalpForCountry;
using Data1.Models;
using ToWinFromFromAPI;

namespace Country_WinFrom_
{
    public partial class Form1 : Form
    {
        private readonly string _url;
        private readonly HalperAPI _aPI;
        public Form1()
        {
            _url = "https://localhost:7296/api/Country";

            _aPI = new HalperAPI(_url);
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            var res = await _aPI.Get();
            foreach (var item in res)
            {
                AddPanel(item);
            }
        }

        private void AddPanel (Country country)
        {
            CountryCon usr = new CountryCon(country);
                usr.Dock = DockStyle.Top;
            panel1.Controls.Add(usr);
        }

        private  void button2_Click(object sender, EventArgs e)
        {
            new PostC().Show();
        }
    }
}