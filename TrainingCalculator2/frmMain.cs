using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrainingCalculator2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            MaximumSize = Size;
            MinimumSize = Size;
        }





        private void Button1_Click(object sender, System.EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender,
            System.Windows.Forms.KeyEventArgs e)
        {
            //受け取ったキーを表示する
            Console.WriteLine(e.KeyCode);

            e.Handled = true;
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyCode.ToString());
            e.Handled = true;
        }
    }
}
