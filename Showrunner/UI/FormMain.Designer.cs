
namespace Showrunner.UI
{
    partial class FormMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.buttonAddEpisode = new System.Windows.Forms.Button();
            this.listBoxEpisodes = new System.Windows.Forms.ListBox();
            this.episodeContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tabControlTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.tabControlNotes = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonDeleteNotepad = new System.Windows.Forms.Button();
            this.listBoxNotes = new System.Windows.Forms.ListBox();
            this.buttonCreateNotepad = new System.Windows.Forms.Button();
            this.textBoxNotepad = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.episodeContext.SuspendLayout();
            this.tabControlTabs.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControlNotes.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.buttonAddEpisode);
            this.splitContainer1.Panel1.Controls.Add(this.listBoxEpisodes);
            this.splitContainer1.Panel1.Controls.Add(this.labelTitle);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlTabs);
            this.splitContainer1.Size = new System.Drawing.Size(760, 604);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 0;
            // 
            // buttonAddEpisode
            // 
            this.buttonAddEpisode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddEpisode.Location = new System.Drawing.Point(12, 569);
            this.buttonAddEpisode.Name = "buttonAddEpisode";
            this.buttonAddEpisode.Size = new System.Drawing.Size(229, 23);
            this.buttonAddEpisode.TabIndex = 2;
            this.buttonAddEpisode.Text = "Add Episode";
            this.buttonAddEpisode.UseVisualStyleBackColor = true;
            this.buttonAddEpisode.Click += new System.EventHandler(this.buttonAddEpisode_Click);
            // 
            // listBoxEpisodes
            // 
            this.listBoxEpisodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxEpisodes.ContextMenuStrip = this.episodeContext;
            this.listBoxEpisodes.FormattingEnabled = true;
            this.listBoxEpisodes.Location = new System.Drawing.Point(12, 37);
            this.listBoxEpisodes.Name = "listBoxEpisodes";
            this.listBoxEpisodes.Size = new System.Drawing.Size(229, 524);
            this.listBoxEpisodes.TabIndex = 1;
            this.listBoxEpisodes.DoubleClick += new System.EventHandler(this.listBoxEpisodes_DoubleClick);
            // 
            // episodeContext
            // 
            this.episodeContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.episodeContext.Name = "episodeContext";
            this.episodeContext.Size = new System.Drawing.Size(139, 70);
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            this.moveUpToolStripMenuItem.Click += new System.EventHandler(this.moveUpToolStripMenuItem_Click);
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            this.moveDownToolStripMenuItem.Click += new System.EventHandler(this.moveDownToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(127, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Show Name";
            // 
            // tabControlTabs
            // 
            this.tabControlTabs.Controls.Add(this.tabPage1);
            this.tabControlTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlTabs.Location = new System.Drawing.Point(0, 0);
            this.tabControlTabs.Name = "tabControlTabs";
            this.tabControlTabs.SelectedIndex = 0;
            this.tabControlTabs.Size = new System.Drawing.Size(503, 604);
            this.tabControlTabs.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonExit);
            this.tabPage1.Controls.Add(this.buttonSave);
            this.tabPage1.Controls.Add(this.tabControlNotes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(495, 578);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Show Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonExit.Location = new System.Drawing.Point(91, 547);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(96, 23);
            this.buttonExit.TabIndex = 10;
            this.buttonExit.Text = "Exit to Menu";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(10, 547);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 9;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // tabControlNotes
            // 
            this.tabControlNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlNotes.Controls.Add(this.tabPage4);
            this.tabControlNotes.Location = new System.Drawing.Point(6, 3);
            this.tabControlNotes.Name = "tabControlNotes";
            this.tabControlNotes.SelectedIndex = 0;
            this.tabControlNotes.Size = new System.Drawing.Size(481, 536);
            this.tabControlNotes.TabIndex = 8;
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
            this.tabPage4.Size = new System.Drawing.Size(473, 510);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "Notes Settings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteNotepad
            // 
            this.buttonDeleteNotepad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteNotepad.Location = new System.Drawing.Point(6, 478);
            this.buttonDeleteNotepad.Name = "buttonDeleteNotepad";
            this.buttonDeleteNotepad.Size = new System.Drawing.Size(461, 23);
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
            this.listBoxNotes.Size = new System.Drawing.Size(461, 420);
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
            this.textBoxNotepad.Size = new System.Drawing.Size(364, 20);
            this.textBoxNotepad.TabIndex = 0;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(760, 604);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Showrunner";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.episodeContext.ResumeLayout(false);
            this.tabControlTabs.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControlNotes.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tabControlTabs;
        private System.Windows.Forms.ListBox listBoxEpisodes;
        private System.Windows.Forms.Button buttonAddEpisode;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControlNotes;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonDeleteNotepad;
        private System.Windows.Forms.ListBox listBoxNotes;
        private System.Windows.Forms.Button buttonCreateNotepad;
        private System.Windows.Forms.TextBox textBoxNotepad;
        private System.Windows.Forms.ContextMenuStrip episodeContext;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSave;
    }
}

