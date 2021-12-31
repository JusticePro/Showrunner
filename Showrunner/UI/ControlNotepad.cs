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
    public partial class ControlNotepad : UserControl
    {
        private Noteable noteable;
        private string name;

        public ControlNotepad(Noteable noteable, string name)
        {
            InitializeComponent();

            this.noteable = noteable;
            this.name = name;
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            noteable.updateNote(name, textBox.Text);
        }
    }
}
