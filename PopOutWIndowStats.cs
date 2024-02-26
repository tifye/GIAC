using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GIAC
{
    public partial class PopOutWIndowStats : Form
    {
        ImageWindow ImageWin;

        int tickRate = 0;
        public PopOutWIndowStats(ImageWindow imgWin)
        {
            InitializeComponent();

            ImageWin = imgWin;
        }

        private void PopOutWIndowStats_Load(object sender, EventArgs e)
        {

        }

        private void tbxTickRate_TextChanged(object sender, EventArgs e)
        {
            if( !Int32.TryParse(tbxTickRate.Text, out tickRate) )
            {
                tbxTickRate.SelectAll();
            }
            else
            {

            }
        }
    }
}
