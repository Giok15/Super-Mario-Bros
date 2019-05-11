namespace Mario
{
    partial class AccountResultaten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountResultaten));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgSpellen = new System.Windows.Forms.DataGridView();
            this.lblAantalSpellen = new System.Windows.Forms.Label();
            this.lblWereld = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSpellen)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(904, 525);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dgSpellen
            // 
            this.dgSpellen.AllowUserToAddRows = false;
            this.dgSpellen.AllowUserToDeleteRows = false;
            this.dgSpellen.AllowUserToResizeColumns = false;
            this.dgSpellen.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgSpellen.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSpellen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSpellen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSpellen.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgSpellen.Location = new System.Drawing.Point(132, 63);
            this.dgSpellen.MultiSelect = false;
            this.dgSpellen.Name = "dgSpellen";
            this.dgSpellen.ReadOnly = true;
            this.dgSpellen.RowTemplate.Height = 24;
            this.dgSpellen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSpellen.ShowEditingIcon = false;
            this.dgSpellen.Size = new System.Drawing.Size(640, 310);
            this.dgSpellen.TabIndex = 2;
            this.dgSpellen.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgSpellen_ColumnHeaderMouseClick);
            this.dgSpellen.SelectionChanged += new System.EventHandler(this.dgSpellen_SelectionChanged);
            this.dgSpellen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgSpellen_KeyDown);
            // 
            // lblAantalSpellen
            // 
            this.lblAantalSpellen.AutoSize = true;
            this.lblAantalSpellen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblAantalSpellen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAantalSpellen.Location = new System.Drawing.Point(266, 395);
            this.lblAantalSpellen.Name = "lblAantalSpellen";
            this.lblAantalSpellen.Size = new System.Drawing.Size(200, 20);
            this.lblAantalSpellen.TabIndex = 3;
            this.lblAantalSpellen.Text = "Aantal gespeelde spellen:";
            // 
            // lblWereld
            // 
            this.lblWereld.AutoSize = true;
            this.lblWereld.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblWereld.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWereld.Location = new System.Drawing.Point(389, 26);
            this.lblWereld.Name = "lblWereld";
            this.lblWereld.Size = new System.Drawing.Size(0, 24);
            this.lblWereld.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Klik op esc om terug te gaan";
            // 
            // AccountResultaten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 525);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblWereld);
            this.Controls.Add(this.lblAantalSpellen);
            this.Controls.Add(this.dgSpellen);
            this.Controls.Add(this.pictureBox1);
            this.Name = "AccountResultaten";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountResultaten";
            this.Load += new System.EventHandler(this.AccountResultaten_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountResultaten_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSpellen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgSpellen;
        private System.Windows.Forms.Label lblAantalSpellen;
        private System.Windows.Forms.Label lblWereld;
        private System.Windows.Forms.Label label1;
    }
}