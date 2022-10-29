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

namespace Country_WinFrom_.HalperForRegion
{
    public partial class RegionShow : Form
    {
       
        public RegionShow(Region region)
        {
            InitializeComponent();
            
            label1.Text = region.Name;
            pictureBox1.ImageLocation = region.MapUrl;
        }
    }
}
