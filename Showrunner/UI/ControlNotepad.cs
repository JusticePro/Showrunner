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
        private Dictionary<string, ControlNotepad> notepadList;

        public ControlNotepad(Noteable noteable, string name, Dictionary<string, ControlNotepad> notepadList)
        {
            InitializeComponent();

            this.noteable = noteable;
            this.name = name;
            this.notepadList = notepadList;
        }

        public void updateNote()
        {
            noteable.updateNote(name, textBox.Text);
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            noteable.updateNote(name, textBox.Text);
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            noteable.updateNote(name, textBox.Text);
            Parent.Dispose();
            notepadList.Remove(name);
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
