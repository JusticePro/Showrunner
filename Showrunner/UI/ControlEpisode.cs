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
        public Dictionary<string, ControlNotepad> notepads = new Dictionary<string, ControlNotepad>(); // Name : Notepad Control
        private Dictionary<string, ControlToDo> todos = new Dictionary<string, ControlToDo>(); // Name : Notepad Control

        public ControlEpisode(Episode episode)
        {
            InitializeComponent();
            this.episode = episode;

            textBoxTitle.Text = episode.getTitle();

            foreach (string notepad in episode.getNoteList())
            {
                listBoxNotes.Items.Add(notepad);

                //setupNotepad(notepad);
                //notepads[notepad].textBox.Text = episode.notes[notepad]; // Set the notepad to equal the correct data.
            }

            foreach (string todo in episode.getToDoList())
            {
                listBoxToDo.Items.Add(todo);

                /*setupToDo(todo);
                foreach (string item in episode.todoLists[todo].Keys)
                {
                    CheckedListBox list = todos[todo].checkBoxList;
                    int index = list.Items.Add(item); // Set the to do list to equal the correct data.
                    list.SetItemChecked(index, episode.todoLists[todo][item]);
                }*/
            }
        }

        /***
         * Setup a notepad.
         */
        public void setupNotepad(string name)
        {
            //listBoxNotes.Items.Add(name); // Add the notepad to the list to allow for it to be deleted.

            ControlNotepad c = new ControlNotepad(episode, name, notepads);
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
            //listBoxToDo.Items.Add(name); // Add the notepad to the list to allow for it to be deleted.

            ControlToDo c = new ControlToDo(episode, name, todos);
            todos.Add(name, c); // Add the notepad control to the list.

            TabPage page = new TabPage(name);
            page.BackColor = Color.White;
            page.Controls.Add(c);

            tabControlToDo.TabPages.Add(page);
            c.Size = page.Size;
            c.Dock = DockStyle.Fill;
        }

        /***
         * Is notepad open.
         */
        public bool isNoteOpen(string notepad)
        {
            return notepads.ContainsKey(notepad);
        }

        /***
         * Is notepad open.
         */
        public bool isTodoOpen(string todo)
        {
            return todos.ContainsKey(todo);
        }

        /***
         * Open Notepad
         */
        public void openNotepad(string notepad)
        {
            setupNotepad(notepad);

            if (episode.getNote(notepad).StartsWith("{\\rtf")) // Check for RTF
            {
                notepads[notepad].textBox.Rtf = episode.getNote(notepad);
            }else
            {
                notepads[notepad].textBox.Text = episode.getNote(notepad);
            }
        }

        /***
         * Open To Do
         */
        public void openTodo(string todo)
        {
            setupToDo(todo);
            foreach (string item in episode.getToDoList())
            {
                CheckedListBox list = todos[todo].checkBoxList;
                int index = list.Items.Add(item); // Set the to do list to equal the correct data.
                list.SetItemChecked(index, episode.getToDo(todo)[item]);
            }
        }


        private void textBoxTitle_Leave(object sender, EventArgs e)
        {
            textBoxTitle.Font = new Font(textBoxTitle.Font, FontStyle.Regular);
            textBoxTitle.Text = episode.getTitle();
        }

        private void textBoxTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                episode.setTitle(textBoxTitle.Text);
                Parent.Text = episode.getTitle();
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
            FormMain.instance.openControlEpisodes.Remove(this);
        }

        private void buttonCreateNotepad_Click(object sender, EventArgs e)
        {
            if (textBoxNotepad.Text.Equals(""))
            {
                MessageBox.Show("You must provide a name for the notepad.", "Showrunner");
                return;
            }

            if (episode.getNoteList().Contains(textBoxNotepad.Text))
            {
                MessageBox.Show("You already have a notepad with that name.", "Showrunner");
                return;
            }

            string notepadName = textBoxNotepad.Text;
            textBoxNotepad.Text = "";

            episode.updateNote(notepadName, "");
            setupNotepad(notepadName); // Create a new notepad.
            listBoxNotes.Items.Add(notepadName);

        }

        private void buttonCreateToDo_Click(object sender, EventArgs e)
        {
            if (textBoxToDo.Text.Equals(""))
            {
                MessageBox.Show("You must provide a name for the to do list.", "Showrunner");
                return;
            }

            if (episode.getToDoList().Contains(textBoxToDo.Text))
            {
                MessageBox.Show("You already have a to do list with that name.", "Showrunner");
                return;
            }

            string todoName = textBoxToDo.Text;
            textBoxToDo.Text = "";

            episode.updateToDo(todoName, new Dictionary<string, bool>());
            setupToDo(todoName); // Create a new notepad.

            listBoxToDo.Items.Add(todoName);
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

                episode.removeNote(name);
                listBoxNotes.Items.Remove(name);

                if (isNoteOpen(name))
                {
                    TabControl tc = (TabControl)notepads[name].Parent.Parent;
                    tc.TabPages.Remove((TabPage)notepads[name].Parent);

                    notepads.Remove(name);
                }
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

                episode.removeToDo(name);
                listBoxToDo.Items.Remove(name);

                TabControl tc = (TabControl)todos[name].Parent.Parent;
                tc.TabPages.Remove((TabPage)todos[name].Parent);

                todos.Remove(name);
            }
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBoxNotes.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("You must select an note to move.", "Showrunner");
                return;
            }

            if (index == 0)
            {
                return;
            }
            object o = listBoxNotes.Items[index];

            listBoxNotes.Items.RemoveAt(index);
            listBoxNotes.Items.Insert(index - 1, o);
            /*string notepad = episode.notes.Keys[index];

            episode.notes.RemoveAt(index);
            episode.notes.Insert(index - 1, episode);
            updateList();*/
        }

        private void listBoxNotes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxNotes.SelectedIndex != -1)
            {
                string notepad = listBoxNotes.SelectedItem + "";
                if (isNoteOpen(notepad))
                {
                    return;
                }
                openNotepad(notepad);
            }
        }

        private void listBoxToDo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxToDo.SelectedIndex != -1)
            {
                string todo = listBoxToDo.SelectedItem + "";
                if (isTodoOpen(todo))
                {
                    return;
                }
                openTodo(todo);
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxNotes.SelectedIndex != -1)
            {
                string note = listBoxNotes.SelectedItem + "";
                if (isNoteOpen(note))
                {
                    MessageBox.Show("You must close the tab for this note before you can rename it.", "Showrunner");
                    return;
                }
                FormPrompt prompt = new FormPrompt("New name for \"" + note + "\"?");

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    if (episode.getNoteList().Contains(prompt.textBox1.Text))
                    {
                        MessageBox.Show("There's already a note with that name.", "Showrunner");
                        return;
                    }
                    episode.updateNote(prompt.textBox1.Text, episode.getNote(note));
                    episode.removeNote(note);
                    int index = listBoxNotes.Items.IndexOf(note);
                    listBoxNotes.Items.Remove(note);
                    listBoxNotes.Items.Insert(index, prompt.textBox1.Text);
                }
            }
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBoxNotes.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("You must select an note to move.", "Showrunner");
                return;
            }

            if (index == listBoxNotes.Items.Count - 1) // If there are two items (indexs: 0, 1). If we try to move index 1, check if index equals length (2) minus one (1). If equal, return the function.
            {
                return;
            }
            object o = listBoxNotes.Items[index];

            listBoxNotes.Items.RemoveAt(index);
            listBoxNotes.Items.Insert(index + 1, o);
        }

        private void renameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listBoxToDo.SelectedIndex != -1)
            {
                string todo = listBoxToDo.SelectedItem + "";
                if (isTodoOpen(todo))
                {
                    MessageBox.Show("You must close the tab for this todo list before you can rename it.", "Showrunner");
                    return;
                }
                FormPrompt prompt = new FormPrompt("New name for \"" + todo + "\"?");

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    if (episode.getToDoList().Contains(prompt.textBox1.Text))
                    {
                        MessageBox.Show("There's already a todo list with that name.", "Showrunner");
                        return;
                    }
                    episode.updateToDo(prompt.textBox1.Text, episode.getToDo(todo));
                    episode.removeToDo(todo);
                    int index = listBoxToDo.Items.IndexOf(todo);
                    listBoxToDo.Items.Remove(todo);
                    listBoxToDo.Items.Insert(index, prompt.textBox1.Text);
                }
            }
        }
    }
}
