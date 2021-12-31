using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Showrunner.UI
{
    public partial class FormPrompt : Form
    {
        public FormPrompt(string text)
        {
            InitializeComponent();

            Text = text;
            label.Text = text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("You don't have anything in the text box.", "Showrunner");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
