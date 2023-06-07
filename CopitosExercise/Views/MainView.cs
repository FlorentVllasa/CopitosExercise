using CopitosExercise.Views.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopitosExercise
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void btnShowMergerView_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            DataMerger merger = new DataMerger();
            pnlContent.Controls.Add(merger);
        }

        private void btnHomepage_Click(object sender, EventArgs e)
        {
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(lblInitialMessage);
        }
    }
}
