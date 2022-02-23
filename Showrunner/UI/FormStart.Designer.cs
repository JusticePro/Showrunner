
namespace Showrunner.UI
{
    partial class FormStart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStart));
            this.listBoxRecent = new System.Windows.Forms.ListBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxRecent
            // 
            this.listBoxRecent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxRecent.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBoxRecent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxRecent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.listBoxRecent.FormattingEnabled = true;
            this.listBoxRecent.Location = new System.Drawing.Point(12, 37);
            this.listBoxRecent.Name = "listBoxRecent";
            this.listBoxRecent.Size = new System.Drawing.Size(497, 405);
            this.listBoxRecent.TabIndex = 1;
            this.listBoxRecent.DoubleClick += new System.EventHandler(this.listBoxRecent_DoubleClick);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCreate.FlatAppearance.BorderSize = 0;
            this.buttonCreate.Location = new System.Drawing.Point(12, 450);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(127, 23);
            this.buttonCreate.TabIndex = 2;
            this.buttonCreate.Text = "Create New Show";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoad.BackColor = System.Drawing.SystemColors.Control;
            this.buttonLoad.FlatAppearance.BorderSize = 0;
            this.buttonLoad.Location = new System.Drawing.Point(377, 450);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(132, 23);
            this.buttonLoad.TabIndex = 3;
            this.buttonLoad.Text = "Load Show";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Showrunner";
            // 
            // FormStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(521, 485);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.listBoxRecent);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStart";
            this.Text = "Showrunner";
            this.Shown += new System.EventHandler(this.FormStart_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxRecent;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label label1;
    }
}