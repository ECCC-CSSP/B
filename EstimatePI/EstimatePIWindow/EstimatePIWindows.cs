using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EstimatePI;

namespace EstimatePIWindow
{
    public partial class EstimatePIWindows : Form
    {
        public EstimatePIWindows()
        {
            InitializeComponent();
        }

        private void butStartEstimatingPI_Click(object sender, EventArgs e)
        {
            Estimate estimate = new Estimate();

            int NumberOfDarts = int.Parse(textBoxNumberOfDarts.Text);
            estimate.EstimatePI(NumberOfDarts, 1);
        }
    }
}
