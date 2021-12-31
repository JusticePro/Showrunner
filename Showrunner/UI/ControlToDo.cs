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
    public partial class ControlToDo : UserControl
    {
        private Checkable checkable;
        private string name;

        public ControlToDo(Checkable checkable, string name)
        {
            InitializeComponent();

            this.checkable = checkable;
            this.name = name;
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (textBoxItem.Text.Equals(""))
            {
                MessageBox.Show("You must provide a name for this item.", "Showrunner");
                return;
            }

            if (checkBoxList.Items.Contains(textBoxItem.Text))
            {
                MessageBox.Show("You already have an item with that name.", "Showrunner");
                return;
            }

            checkBoxList.Items.Add(textBoxItem.Text);
            textBoxItem.Text = "";
        }

        private void ControlToDo_Leave(object sender, EventArgs e)
        {
            Dictionary<string, bool> values = new Dictionary<string, bool>();

            foreach (string item in checkBoxList.Items)
            {
                values[item] = checkBoxList.GetItemChecked(checkBoxList.Items.IndexOf(item));
            }

            checkable.updateToDo(name, values);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkBoxList.SelectedIndex == -1)
            {
                MessageBox.Show("You must select an item to delete.", "Showrunner");
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete \"" + checkBoxList.SelectedItem + "\"", "Showrunner", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                checkBoxList.Items.RemoveAt(checkBoxList.SelectedIndex);
            }

        }

        private void moveUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = checkBoxList.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("You must select an item to move.", "Showrunner");
                return;
            }

            if (index == 0)
            {
                return;
            }
            string item = checkBoxList.SelectedItem + "";

            checkBoxList.Items.RemoveAt(index);
            checkBoxList.Items.Insert(index - 1, item);
        }

        private void moveDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = checkBoxList.SelectedIndex;

            if (index == -1)
            {
                MessageBox.Show("You must select an item to move.", "Showrunner");
                return;
            }

            if (index == checkBoxList.Items.Count-1)
            {
                return;
            }
            string item = checkBoxList.SelectedItem + "";

            checkBoxList.Items.RemoveAt(index);
            checkBoxList.Items.Insert(index + 1, item);
        }
    }
}
