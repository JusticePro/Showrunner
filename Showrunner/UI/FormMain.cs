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
        private Show show;
        public static FormMain instance;

        public List<Episode> openEpisodes = new List<Episode>();
        public List<ControlEpisode> openControlEpisodes = new List<ControlEpisode>();
        private Dictionary<string, ControlNotepad> notepads = new Dictionary<string, ControlNotepad>(); // Name : Notepad Control

        /***
         * Form Main
         */
        public FormMain(Show show)
        {
            InitializeComponent();
            instance = this;

            Text = "Showrunner " + Updater.getVersionName(); // Display version.

            this.show = show;

            // Setup Season Box
            seasonBox.SelectedIndex = 0;

            foreach (Episode episode in show.getEpisodes())
            {
                if (!seasonBox.Items.Contains(episode.getSeason()))
                {
                    addSeasonToList(episode.getSeason());
                }
            }

            this.labelTitle.Text = show.getTitle(); // Set the title.

            updateList(); // Add the episodes.

            // Add the notepads
            updateNotepads();
            updateFolderContext();
            updateFolders();

            comboBox1.SelectedIndex = 0; // Select "No Template"

            foreach (string templateName in show.getTemplates())
            {
                comboBox1.Items.Add(templateName);
            }

        }

        public void addSeasonToList(string name)
        {
            ToolStripMenuItem seasonTab = new ToolStripMenuItem(name);
            seasonTab.Click += new EventHandler((Object o, EventArgs a) =>
            {
                if (listBoxEpisodes.SelectedItem != null)
                {
                    show.getEpisode(getEpisodeIndex(listBoxEpisodes.SelectedIndex, seasonBox.SelectedItem + "")).setSeason(name);
                    updateList();
                }
            });

            moveToSeasonToolStripMenuItem.DropDownItems.Add(seasonTab);
            seasonBox.Items.Add(name);
        }

        /***
         * Clears the episode list and adds the items from the show episode list.
         */
        public void updateList()
        {
            listBoxEpisodes.Items.Clear();

            foreach (Episode episode in show.getEpisodes())
            {
                if (!episode.getSeason().Equals(seasonBox.Text))
                {
                    continue;
                }

                listBoxEpisodes.Items.Add(episode.getTitle());
            }
        }

        /***
         * Creates a tab for an episode.
         */
        private void openEpisode(Episode episode)
        {
            ControlEpisode c = new ControlEpisode(episode);
            TabPage page = new TabPage(episode.getTitle());
            page.BackColor = Color.White;
            page.Controls.Add(c);

            tabControlTabs.TabPages.Add(page);

            c.Size = page.Size;
            c.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

            openEpisodes.Add(episode); // Add the episode to the list of open episodes (to prevent duplicate tabs).
            openControlEpisodes.Add(c);
        }

        /***
         * Delete an episode and remove it from the list and close any tabs of it.
         */
        private void deleteEpisode(string name, int index)
        {
            Episode episode = show.getEpisode(index);

            if (openEpisodes.Contains(episode)) // If the episode is open.
            {
                MessageBox.Show("You must close the tab for this episode before you can delete it.", "Showrunner");
                return;
            }

            show.removeEpisode(index);
            listBoxEpisodes.Items.RemoveAt(index); // Remove from list.
        }

        /***
         * Create a new episode.
         */
        private Episode createEpisode()
        {
            Episode episode = new Episode();
            show.addEpisode(episode);
            updateList();

            return episode;
        }

        /***
         * Create a new episode.
         */
        private Episode createEpisode(Episode template)
        {
            Episode episode = (Episode) template.Clone();
            episode.setTitle("Untitled Episode");
            show.addEpisode(episode);
            updateList();

            return episode;
        }

        /***
         * Returns whether or not there is a tab with a specific episode open.
         */
        private bool isEpisodeOpen(Episode episode)
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
        private void setupNotepad(string name)
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
        private bool isNoteOpen(string notepad)
        {
            return notepads.ContainsKey(notepad);
        }

        /***
         * Open Notepad
         */
        private void openNotepad(string notepad)
        {
            setupNotepad(notepad);

            if (show.getNote(notepad).StartsWith("{\\rtf")) // Check for RTF
            {
                notepads[notepad].textBox.Rtf = show.getNote(notepad);
            }
            else
            {
                notepads[notepad].textBox.Text = show.getNote(notepad);
            }
        }

        /**
         * Save the file
         */
        private void save()
        {
            foreach (ControlNotepad notepad in notepads.Values)
            {
                notepad.save();
            }

            foreach (ControlEpisode episode in openControlEpisodes)
            {
                foreach (ControlNotepad notepad in episode.notepads.Values)
                {
                    notepad.save();
                }
            }

            Program.WriteToBinaryFile(FormStart.showrunnerPath + "/" + show.getTitle() + ".show", show);
        }

        public int getEpisodeIndex(int listIndex, string season)
        {
            int i = 0;
            int li = 0;

            foreach (Episode episode in show.getEpisodes())
            {
                if (episode.getSeason().Equals(season))
                {
                    if (li == listIndex)
                    {
                        return i + li;
                    }
                    li++;
                }else
                {
                    i++;
                }
            }

            return -1;
        }

        public void updateNotepads()
        {
            updateNotepads(null);
        }

        public void updateNotepads(string folder)
        {
            listBoxNotes.Items.Clear();

            string[] array = show.getNotes();

            if (folder != null)
            {
                array = show.getNotesInFolder(folder);
            }

            foreach (string notepad in array)
            {
                listBoxNotes.Items.Add(notepad);
                //setupNotepad(notepad); // Setup the notepad.
                //notepads[notepad].textBox.Text = show.notes[notepad]; // Set the text in the notepad form.
            }
        }

        public void updateFolderContext()
        {
            // Clear all but the first item.
            for (int i = 1; i < folderContext.Items.Count; i++)
            {
                folderContext.Items.RemoveAt(i);
            }

            foreach (string folder in show.getFolders())
            {
                ToolStripMenuItem item = new ToolStripMenuItem(folder);

                item.Click += new EventHandler((object sender, EventArgs e) =>
                {
                    if (listBoxNotes.SelectedIndex == -1)
                    {
                        MessageBox.Show("You need to select a note.");
                        return;
                    }
                    show.addToFolder(listBoxNotes.SelectedItem + "", folder);
                });

                folderContext.Items.Add(item);
            }
        }

        public void updateFolders()
        {
            noteFolderBox.Items.Clear();
            noteFolderBox.Items.Add("No Folder");

            foreach (string folder in show.getFolders())
            {
                noteFolderBox.Items.Add(folder);
            }
            noteFolderBox.SelectedIndex = 0;
        }


        private void buttonAddEpisode_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                openEpisode(createEpisode());
            }else
            {
                // show.templates[comboBox1.SelectedItem + ""]
                openEpisode(createEpisode(show.getTemplate(comboBox1.SelectedItem + "")));
            }
        }

        private void listBoxEpisodes_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxEpisodes.SelectedIndex != -1)
            {
                Episode episode = show.getEpisode(getEpisodeIndex(listBoxEpisodes.SelectedIndex, seasonBox.Text));
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

            if (show.getNotes().Contains(textBoxNotepad.Text))
            {
                MessageBox.Show("You already have a notepad with that name.", "Showrunner");
                return;
            }

            string notepadName = textBoxNotepad.Text;
            textBoxNotepad.Text = "";

            show.updateNote(notepadName, ""); // Create notepad
            setupNotepad(notepadName); // Create a new notepad.
            updateNotepads();
        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = getEpisodeIndex(listBoxEpisodes.SelectedIndex, seasonBox.Text);

            if (index == -1)
            {
                MessageBox.Show("You must select an episode to move.", "Showrunner");
                return;
            }

            if (index == 0)
            {
                return;
            }

            show.moveEpisodeUp(index);
            updateList();
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = getEpisodeIndex(listBoxEpisodes.SelectedIndex, seasonBox.Text);

            if (index == -1)
            {
                MessageBox.Show("You must select an episode to move.", "Showrunner");
                return;
            }

            if (index == listBoxEpisodes.Items.Count - 1)
            {
                return;
            }

            show.moveEpisodeDown(index);
            updateList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxEpisodes.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an episode to delete.", "Showrunner");
                return;
            }

            if (openEpisodes.Contains(show.getEpisode(listBoxEpisodes.SelectedIndex))) // If the episode is open.
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
                
                show.removeNote(name);
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
                show.addTemplate(prompt.textBox1.Text, show.getEpisode(listBoxEpisodes.SelectedIndex));
                comboBox1.Items.Add(prompt.textBox1.Text);
            }

        }

        private void seasonBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateList();
        }

        private void defaultSeasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxEpisodes.SelectedItem != null)
            {
                show.getEpisode(getEpisodeIndex(listBoxEpisodes.SelectedIndex, seasonBox.SelectedItem + "")).setSeason("Default Season");
                updateList();
            }
        }

        private void createNewSeasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrompt prompt = new FormPrompt("Season name?");
            
            if (prompt.ShowDialog() == DialogResult.OK)
            {
                addSeasonToList(prompt.textBox1.Text);

                if (listBoxEpisodes.SelectedItem != null)
                {
                    show.getEpisode(getEpisodeIndex(listBoxEpisodes.SelectedIndex, seasonBox.SelectedItem + "")).setSeason(prompt.textBox1.Text);
                    updateList();
                }
            }
        }

        private void noteFolderBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (noteFolderBox.SelectedItem.Equals("No Folder") || noteFolderBox.SelectedItem == null)
            {
                updateNotepads();
                buttonRemoveFromFolder.Enabled = false;
                return;
            }

            buttonRemoveFromFolder.Enabled = true;
            updateNotepads(noteFolderBox.SelectedItem + "");
        }

        private void addToNewFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBoxNotes.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a note.");
                return;
            }
            FormPrompt prompt = new FormPrompt("Folder name?");

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                show.addToFolder(listBoxNotes.SelectedItem + "", prompt.textBox1.Text);
                updateFolders();
                updateFolderContext();
            }
        }

        private void buttonRemoveFromFolder_Click(object sender, EventArgs e)
        {
            if (noteFolderBox.SelectedItem.Equals("No Folder") || noteFolderBox.SelectedItem == null)
            {
                return;
            }

            if (listBoxNotes.SelectedIndex == -1)
            {
                MessageBox.Show("You need to select a note.");
                return;
            }

            show.removeFromFolder(listBoxNotes.SelectedItem + "", noteFolderBox.SelectedItem + "");
            
            if (show.getNotesInFolder(noteFolderBox.SelectedItem + "").Length == 0)
            {
                updateFolderContext();
                updateFolders();
            }else
            {
                listBoxNotes.Items.RemoveAt(listBoxNotes.SelectedIndex);
            }

        }
    }
}
