using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circular_Progressbar
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            Task.Run(() =>{
                for (int i=0; i<=100; i++)
                {
                    new System.Threading.Thread(
                         new System.Threading.ParameterizedThreadStart(this.ProgressUpgrade)).Start(i);

                         System.Threading.Thread.Sleep(50);
                }
            });
        }


        public void ProgressUpgrade(object progress)
        {
            circularProgressBar1.Invoke(
                (MethodInvoker)delegate {
                    circularProgressBar1.UpdateProgress(Convert.ToInt32(progress));
                }
            );
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

    }


}
