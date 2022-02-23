using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Showrunner;

namespace Showrunner.UI
{
    public partial class FormStart : Form
    {
        public static string showrunnerPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Showrunner");
        private static Dictionary<string, string> paths = new Dictionary<string, string>();

        public FormStart()
        {
            InitializeComponent();
            Text = "Showrunner " + Updater.getVersionName(); // Display version.

            if (!Directory.Exists(showrunnerPath))
            {
                Directory.CreateDirectory(showrunnerPath);
            }

            foreach (string file in Directory.GetFiles(showrunnerPath))
            {
                if (file.EndsWith(".show"))
                {
                    string[] f = file.Substring(0, file.Length - 5).Split('\\');
                    listBoxRecent.Items.Add(f[f.Length - 1]);

                    paths[f[f.Length - 1]] = file;
                }
            }

        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            FormPrompt prompt = new FormPrompt("Show name?");
            DialogResult result = prompt.ShowDialog();

            if (result == DialogResult.OK)
            {
                string name = prompt.textBox1.Text;

                Show show = new Show();
                show.title = name;

                FormMain formMain = new FormMain(show);
                formMain.Show();
                Visible = false;
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (listBoxRecent.SelectedItem == null)
            {
                MessageBox.Show("You must select a show to load.", "Showrunner");
                return;
            }

            if (!listBoxRecent.Items.Contains(listBoxRecent.SelectedItem))
            {
                MessageBox.Show("That show doesn't exist.", "Showrunner");
                return;
            }

            string path = paths[listBoxRecent.SelectedItem + ""];

            if (!File.Exists(path))
            {
                MessageBox.Show("That show doesn't exist.", "Showrunner");
                return;
            }

            Show show = Program.ReadFromBinaryFile<Show>(path);

            FormMain formMain = new FormMain(show);
            formMain.Show();
            Visible = false;
        }

        private void listBoxRecent_DoubleClick(object sender, EventArgs e)
        {
            // Check if an item is selected.
            if (listBoxRecent.SelectedItem != null)
            {
                // Check if the item actually exists on the list.
                if (listBoxRecent.Items.Contains(listBoxRecent.SelectedItem))
                {
                    // Get the path from the name.
                    string path = paths[listBoxRecent.SelectedItem + ""];

                    if (!File.Exists(path))
                    {
                        MessageBox.Show("That show doesn't exist.", "Showrunner");
                        return;
                    }

                    // Open the show.
                    Show show = Program.ReadFromBinaryFile<Show>(path);
                    show.update();

                    FormMain formMain = new FormMain(show);
                    formMain.Show();
                    Visible = false;
                }
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormStart_Shown(object sender, EventArgs e)
        {
            Updater.checkForUpdate(); // Check for update and display a prompt.
        }
    }
}
