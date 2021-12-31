
namespace Showrunner.UI
{
    partial class ControlEpisode
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlNotes = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonDeleteNotepad = new System.Windows.Forms.Button();
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.buttonCreateNotepad = new System.Windows.Forms.Button();
            this.textBoxNotepad = new System.Windows.Forms.TextBox();
            this.tabControlToDo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonDeleteToDo = new System.Windows.Forms.Button();
            this.listBoxToDo = new System.Windows.Forms.ListBox();
            this.buttonCreateToDo = new System.Windows.Forms.Button();
            this.textBoxToDo = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlNotes.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControlToDo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Location = new System.Drawing.Point(420, 555);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 12;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTitle.Location = new System.Drawing.Point(7, 3);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(473, 26);
            this.textBoxTitle.TabIndex = 13;
            this.textBoxTitle.Enter += new System.EventHandler(this.textBoxTitle_Enter);
            this.textBoxTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTitle_KeyDown);
            this.textBoxTitle.Leave += new System.EventHandler(this.textBoxTitle_Leave);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(7, 35);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControlNotes);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlToDo);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(485, 514);
            this.splitContainer1.SplitterDistance = 224;
            this.splitContainer1.TabIndex = 14;
            // 
            // tabControlNotes
            // 
            this.tabControlNotes.Controls.Add(this.tabPage4);
            this.tabControlNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlNotes.Location = new System.Drawing.Point(0, 0);
            this.tabControlNotes.Name = "tabControlNotes";
            this.tabControlNotes.SelectedIndex = 0;
            this.tabControlNotes.Size = new System.Drawing.Size(485, 224);
            this.tabControlNotes.TabIndex = 13;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.buttonDeleteNotepad);
            this.tabPage4.Controls.Add(this.listBoxNotes);
            this.tabPage4.Controls.Add(this.buttonCreateNotepad);
            this.tabPage4.Controls.Add(this.textBoxNotepad);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(477, 198);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Notes Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteNotepad
            // 
            this.buttonDeleteNotepad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteNotepad.Location = new System.Drawing.Point(6, 166);
            this.buttonDeleteNotepad.Name = "buttonDeleteNotepad";
            this.buttonDeleteNotepad.Size = new System.Drawing.Size(465, 23);
            this.buttonDeleteNotepad.TabIndex = 3;
            this.buttonDeleteNotepad.Text = "Delete Notepad";
            this.buttonDeleteNotepad.UseVisualStyleBackColor = true;
            this.buttonDeleteNotepad.Click += new System.EventHandler(this.buttonDeleteNotepad_Click);
            // 
            // listBoxNotes
            // 
            this.listBoxNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxNotes.FormattingEnabled = true;
            this.listBoxNotes.Location = new System.Drawing.Point(6, 32);
            this.listBoxNotes.Name = "listBoxNotes";
            this.listBoxNotes.Size = new System.Drawing.Size(465, 121);
            this.listBoxNotes.TabIndex = 2;
            // 
            // buttonCreateNotepad
            // 
            this.buttonCreateNotepad.Location = new System.Drawing.Point(6, 3);
            this.buttonCreateNotepad.Name = "buttonCreateNotepad";
            this.buttonCreateNotepad.Size = new System.Drawing.Size(91, 23);
            this.buttonCreateNotepad.TabIndex = 1;
            this.buttonCreateNotepad.Text = "Create Notepad";
            this.buttonCreateNotepad.UseVisualStyleBackColor = true;
            this.buttonCreateNotepad.Click += new System.EventHandler(this.buttonCreateNotepad_Click);
            // 
            // textBoxNotepad
            // 
            this.textBoxNotepad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNotepad.Location = new System.Drawing.Point(103, 5);
            this.textBoxNotepad.Name = "textBoxNotepad";
            this.textBoxNotepad.Size = new System.Drawing.Size(368, 20);
            this.textBoxNotepad.TabIndex = 0;
            // 
            // tabControlToDo
            // 
            this.tabControlToDo.Controls.Add(this.tabPage1);
            this.tabControlToDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlToDo.Location = new System.Drawing.Point(0, 0);
            this.tabControlToDo.Name = "tabControlToDo";
            this.tabControlToDo.SelectedIndex = 0;
            this.tabControlToDo.Size = new System.Drawing.Size(485, 286);
            this.tabControlToDo.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonDeleteToDo);
            this.tabPage1.Controls.Add(this.listBoxToDo);
            this.tabPage1.Controls.Add(this.buttonCreateToDo);
            this.tabPage1.Controls.Add(this.textBoxToDo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(477, 260);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "To Do Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteToDo
            // 
            this.buttonDeleteToDo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteToDo.Location = new System.Drawing.Point(6, 231);
            this.buttonDeleteToDo.Name = "buttonDeleteToDo";
            this.buttonDeleteToDo.Size = new System.Drawing.Size(469, 23);
            this.buttonDeleteToDo.TabIndex = 7;
            this.buttonDeleteToDo.Text = "Delete To Do List";
            this.buttonDeleteToDo.UseVisualStyleBackColor = true;
            this.buttonDeleteToDo.Click += new System.EventHandler(this.buttonDeleteToDo_Click);
            // 
            // listBoxToDo
            // 
            this.listBoxToDo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxToDo.FormattingEnabled = true;
            this.listBoxToDo.Location = new System.Drawing.Point(4, 33);
            this.listBoxToDo.Name = "listBoxToDo";
            this.listBoxToDo.Size = new System.Drawing.Size(469, 173);
            this.listBoxToDo.TabIndex = 6;
            // 
            // buttonCreateToDo
            // 
            this.buttonCreateToDo.Location = new System.Drawing.Point(4, 4);
            this.buttonCreateToDo.Name = "buttonCreateToDo";
            this.buttonCreateToDo.Size = new System.Drawing.Size(98, 23);
            this.buttonCreateToDo.TabIndex = 5;
            this.buttonCreateToDo.Text = "Create To Do List";
            this.buttonCreateToDo.UseVisualStyleBackColor = true;
            this.buttonCreateToDo.Click += new System.EventHandler(this.buttonCreateToDo_Click);
            // 
            // textBoxToDo
            // 
            this.textBoxToDo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxToDo.Location = new System.Drawing.Point(108, 6);
            this.textBoxToDo.Name = "textBoxToDo";
            this.textBoxToDo.Size = new System.Drawing.Size(365, 20);
            this.textBoxToDo.TabIndex = 4;
            // 
            // ControlEpisode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonExit);
            this.Name = "ControlEpisode";
            this.Size = new System.Drawing.Size(495, 578);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlNotes.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabControlToDo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControlNotes;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonDeleteNotepad;
        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.Button buttonCreateNotepad;
        private System.Windows.Forms.TextBox textBoxNotepad;
        private System.Windows.Forms.TabControl tabControlToDo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonDeleteToDo;
        private System.Windows.Forms.ListBox listBoxToDo;
        private System.Windows.Forms.Button buttonCreateToDo;
        private System.Windows.Forms.TextBox textBoxToDo;
    }
}
