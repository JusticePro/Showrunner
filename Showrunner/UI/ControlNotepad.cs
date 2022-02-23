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

        public void save()
        {
            noteable.updateNote(name, textBox.Rtf);
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            save();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save();
            Parent.Dispose();
            notepadList.Remove(name);
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleStyle(FontStyle.Bold);
        }

        private void italicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleStyle(FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleStyle(FontStyle.Underline);
        }

        private void strikeMenuItem_Click(object sender, EventArgs e)
        {
            toggleStyle(FontStyle.Strikeout);
        }

        private void toggleStyle(FontStyle style)
        {
            if (textBox.SelectionFont.Style.HasFlag(style))
            {
                textBox.SelectionFont = new Font(textBox.SelectionFont, textBox.SelectionFont.Style & ~style);
            }
            else
            {
                textBox.SelectionFont = new Font(textBox.SelectionFont, textBox.SelectionFont.Style | style);
            }
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.B)
                {
                    toggleStyle(FontStyle.Bold);
                    e.SuppressKeyPress = true;
                }

                if (e.KeyCode == Keys.I)
                {
                    toggleStyle(FontStyle.Italic);
                    e.SuppressKeyPress = true;
                }

                if (e.KeyCode == Keys.U)
                {
                    toggleStyle(FontStyle.Underline);
                    e.SuppressKeyPress = true;
                }

                if (e.KeyCode == Keys.K)
                {
                    toggleStyle(FontStyle.Strikeout);
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
}
