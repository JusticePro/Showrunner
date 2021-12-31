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
    public partial class ControlEpisode : UserControl
    {
        private Episode episode;
        private Dictionary<string, ControlNotepad> notepads = new Dictionary<string, ControlNotepad>(); // Name : Notepad Control
        private Dictionary<string, ControlToDo> todos = new Dictionary<string, ControlToDo>(); // Name : Notepad Control

        public ControlEpisode(Episode episode)
        {
            InitializeComponent();
            this.episode = episode;

            textBoxTitle.Text = episode.title;

            foreach (string notepad in episode.notes.Keys)
            {
                setupNotepad(notepad);
                notepads[notepad].textBox.Text = episode.notes[notepad]; // Set the notepad to equal the correct data.
            }

            foreach (string todo in episode.todoLists.Keys)
            {
                setupToDo(todo);
                foreach (string item in episode.todoLists[todo].Keys)
                {
                    CheckedListBox list = todos[todo].checkBoxList;
                    int index = list.Items.Add(item); // Set the to do list to equal the correct data.
                    list.SetItemChecked(index, episode.todoLists[todo][item]);
                }
                
            }
        }

        /***
         * Setup a notepad.
         */
        public void setupNotepad(string name)
        {
            listBoxNotes.Items.Add(name); // Add the notepad to the list to allow for it to be deleted.

            ControlNotepad c = new ControlNotepad(episode, name);
            notepads.Add(name, c); // Add the notepad control to the list.

            TabPage page = new TabPage(name);
            page.BackColor = Color.White;
            page.Controls.Add(c);

            tabControlNotes.TabPages.Add(page);
            c.Size = page.Size;
            c.Dock = DockStyle.Fill;
        }

        /***
         * Setup a to do list.
         */
        public void setupToDo(string name)
        {
            listBoxToDo.Items.Add(name); // Add the notepad to the list to allow for it to be deleted.

            ControlToDo c = new ControlToDo(episode, name);
            todos.Add(name, c); // Add the notepad control to the list.

            TabPage page = new TabPage(name);
            page.BackColor = Color.White;
            page.Controls.Add(c);

            tabControlToDo.TabPages.Add(page);
            c.Size = page.Size;
            c.Dock = DockStyle.Fill;
        }

        private void textBoxTitle_Leave(object sender, EventArgs e)
        {
            textBoxTitle.Font = new Font(textBoxTitle.Font, FontStyle.Regular);
            textBoxTitle.Text = episode.title;
        }

        private void textBoxTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                episode.title = textBoxTitle.Text;
                Parent.Text = episode.title;
                tabControlNotes.Focus();

                FormMain.instance.updateList();
            }
        }

        private void textBoxTitle_Enter(object sender, EventArgs e)
        {
            textBoxTitle.Font = new Font(textBoxTitle.Font, FontStyle.Italic);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            ((TabControl)Parent.Parent).Controls.RemoveAt(((TabControl)Parent.Parent).SelectedIndex); // Close this tab.
            FormMain.instance.openEpisodes.Remove(episode);
        }

        private void buttonCreateNotepad_Click(object sender, EventArgs e)
        {
            if (textBoxNotepad.Text.Equals(""))
            {
                MessageBox.Show("You must provide a name for the notepad.", "Showrunner");
                return;
            }

            if (episode.notes.ContainsKey(textBoxNotepad.Text))
            {
                MessageBox.Show("You already have a notepad with that name.", "Showrunner");
                return;
            }

            string notepadName = textBoxNotepad.Text;
            textBoxNotepad.Text = "";

            episode.notes.Add(notepadName, "");
            setupNotepad(notepadName); // Create a new notepad.
        }

        private void buttonCreateToDo_Click(object sender, EventArgs e)
        {
            if (textBoxToDo.Text.Equals(""))
            {
                MessageBox.Show("You must provide a name for the to do list.", "Showrunner");
                return;
            }

            if (episode.todoLists.ContainsKey(textBoxToDo.Text))
            {
                MessageBox.Show("You already have a to do list with that name.", "Showrunner");
                return;
            }

            string todoName = textBoxToDo.Text;
            textBoxToDo.Text = "";

            episode.todoLists.Add(todoName, new Dictionary<string, bool>());
            setupToDo(todoName); // Create a new notepad.
        }

        private void buttonDeleteNotepad_Click(object sender, EventArgs e)
        {
            if (listBoxNotes.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a notepad to delete.", "Showrunner");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete \"" + listBoxNotes.SelectedItem + "\"", "Showrunner", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string name = listBoxNotes.SelectedItem + "";

                episode.notes.Remove(name);
                listBoxNotes.Items.Remove(name);

                TabControl tc = (TabControl)notepads[name].Parent.Parent;
                tc.TabPages.Remove((TabPage)notepads[name].Parent);

                notepads.Remove(name);
            }
        }

        private void buttonDeleteToDo_Click(object sender, EventArgs e)
        {
            if (listBoxToDo.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a to do list to delete.", "Showrunner");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete \"" + listBoxToDo.SelectedItem + "\"", "Showrunner", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string name = listBoxToDo.SelectedItem + "";

                episode.todoLists.Remove(name);
                listBoxToDo.Items.Remove(name);

                TabControl tc = (TabControl)todos[name].Parent.Parent;
                tc.TabPages.Remove((TabPage)todos[name].Parent);

                todos.Remove(name);
            }
        }
    }
}
