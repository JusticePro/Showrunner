using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Showrunner.UI
{
    public partial class FormMain : Form
    {
        public Show show;
        public static FormMain instance;

        public List<Episode> openEpisodes = new List<Episode>();
        public Dictionary<string, ControlNotepad> notepads = new Dictionary<string, ControlNotepad>(); // Name : Notepad Control

        /***
         * Form Main
         */
        public FormMain(Show show)
        {
            InitializeComponent();
            instance = this;

            Text = "Showrunner " + Updater.getVersionName(); // Display version.

            this.show = show;

            this.labelTitle.Text = show.title; // Set the title.
            updateList(); // Add the episodes.

            // Add the notepads
            foreach (string notepad in show.notes.Keys)
            {
                listBoxNotes.Items.Add(notepad);
                //setupNotepad(notepad); // Setup the notepad.
                //notepads[notepad].textBox.Text = show.notes[notepad]; // Set the text in the notepad form.
            }

            comboBox1.SelectedIndex = 0; // Select "No Template"

            foreach (string templateName in show.templates.Keys)
            {
                comboBox1.Items.Add(templateName);
            }
        }

        /***
         * Clears the episode list and adds the items from the show episode list.
         */
        public void updateList()
        {
            listBoxEpisodes.Items.Clear();
            foreach (Episode episode in show.episodes)
            {
                listBoxEpisodes.Items.Add(episode.title);
            }
        }

        /***
         * Creates a tab for an episode.
         */
        public void openEpisode(Episode episode)
        {
            ControlEpisode c = new ControlEpisode(episode);
            TabPage page = new TabPage(episode.title);
            page.BackColor = Color.White;
            page.Controls.Add(c);

            tabControlTabs.TabPages.Add(page);

            c.Size = page.Size;
            c.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            openEpisodes.Add(episode); // Add the episode to the list of open episodes (to prevent duplicate tabs).
        }

        /***
         * Delete an episode and remove it from the list and close any tabs of it.
         */
        public void deleteEpisode(string name, int index)
        {
            Episode episode = show.episodes[index];

            if (openEpisodes.Contains(episode)) // If the episode is open.
            {
                MessageBox.Show("You must close the tab for this episode before you can delete it.", "Showrunner");
                return;
            }

            show.episodes.RemoveAt(index);
            listBoxEpisodes.Items.RemoveAt(index); // Remove from list.
        }

        /***
         * Create a new episode.
         */
        public Episode createEpisode()
        {
            Episode episode = new Episode();
            show.episodes.Add(episode);
            updateList();

            return episode;
        }

        /***
         * Create a new episode.
         */
        public Episode createEpisode(Episode template)
        {
            Episode episode = (Episode) template.Clone();
            episode.title = "Untitled Episode";
            show.episodes.Add(episode);
            updateList();

            return episode;
        }

        /***
         * Returns whether or not there is a tab with a specific episode open.
         */
        public bool isEpisodeOpen(Episode episode)
        {
            foreach (Episode e in openEpisodes)
            {
                if (episode.GetHashCode() == e.GetHashCode())
                {
                    return true;
                }
            }

            return false;
        }

        /***
         * Setup a notepad.
         */
        public void setupNotepad(string name)
        {
            // listBoxNotes.Items.Add(name); // Add the notepad to the list to allow for it to be deleted.

            ControlNotepad c = new ControlNotepad(show, name, notepads);
            notepads.Add(name, c); // Add the notepad control to the list.

            TabPage page = new TabPage(name);
            page.BackColor = Color.White;
            page.Controls.Add(c);

            tabControlNotes.TabPages.Add(page);
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
         * Open Notepad
         */
        public void openNotepad(string notepad)
        {
            setupNotepad(notepad);
            notepads[notepad].textBox.Text = show.notes[notepad];
        }

        /**
         * Save the file
         */
        public void save()
        {
            Program.WriteToBinaryFile(FormStart.showrunnerPath + "/" + show.title + ".show", show);
        }

        private void buttonAddEpisode_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                openEpisode(createEpisode());
            }else
            {
                openEpisode(createEpisode(show.templates[comboBox1.SelectedItem + ""]));
            }
        }

        private void listBoxEpisodes_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxEpisodes.SelectedIndex != -1)
            {
                Episode episode = show.episodes[listBoxEpisodes.SelectedIndex];
                if (isEpisodeOpen(episode))
                {
                    return;
                }
                openEpisode(episode);
            }
        }

        private void buttonCreateNotepad_Click(object sender, EventArgs e)
        {
            if (textBoxNotepad.Text.Equals(""))
            {
                MessageBox.Show("You must provide a name for the notepad.", "Showrunner");
                return;
            }

            if (show.notes.ContainsKey(textBoxNotepad.Text))
            {
                MessageBox.Show("You already have a notepad with that name.", "Showrunner");
                return;
            }

            string notepadName = textBoxNotepad.Text;
            textBoxNotepad.Text = "";

            show.notes.Add(notepadName, ""); // Create notepad
            setupNotepad(notepadName); // Create a new notepad.
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBoxEpisodes.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("You must select an episode to move.", "Showrunner");
                return;
            }

            if (index == 0)
            {
                return;
            }
            Episode episode = show.episodes[index];

            show.episodes.RemoveAt(index);
            show.episodes.Insert(index - 1, episode);
            updateList();
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = listBoxEpisodes.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("You must select an episode to move.", "Showrunner");
                return;
            }

            if (index == listBoxEpisodes.Items.Count - 1)
            {
                return;
            }
            Episode episode = show.episodes[index];

            show.episodes.RemoveAt(index);
            show.episodes.Insert(index + 1, episode);
            updateList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxEpisodes.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an episode to delete.", "Showrunner");
                return;
            }

            if (openEpisodes.Contains(show.episodes[listBoxEpisodes.SelectedIndex])) // If the episode is open.
            {
                MessageBox.Show("You must close the tab for this episode before you can delete it.", "Showrunner");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete \"" + listBoxEpisodes.SelectedItem + "\"", "Showrunner", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                deleteEpisode(listBoxEpisodes.SelectedItem+"", listBoxEpisodes.SelectedIndex);
            }
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
                
                show.notes.Remove(name);
                listBoxNotes.Items.Remove(name);

                TabControl tc = (TabControl) notepads[name].Parent.Parent;
                tc.TabPages.Remove((TabPage)notepads[name].Parent);

                notepads.Remove(name);
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            save();
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            save();
            SystemSounds.Beep.Play();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                save();
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private void tabControlTabs_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void listBoxNotes_DoubleClick(object sender, EventArgs e)
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

        private void createTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxEpisodes.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an episode to turn into a template.", "Showrunner");
                return;
            }

            FormPrompt prompt = new FormPrompt("Name for the template?");
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                show.templates.Add(prompt.textBox1.Text, show.episodes[listBoxEpisodes.SelectedIndex]);
                comboBox1.Items.Add(prompt.textBox1.Text);
            }

        }
    }
}
