
namespace Projekat_OOP
{
    partial class frmIgra
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
            this.pbxTabela = new System.Windows.Forms.PictureBox();
            this.lblNaslov = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbxBrojZastavica = new System.Windows.Forms.TextBox();
            this.lblBrojZastavica = new System.Windows.Forms.Label();
            this.tbxTajmer = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTabela)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxTabela
            // 
            this.pbxTabela.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbxTabela.Location = new System.Drawing.Point(31, 53);
            this.pbxTabela.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pbxTabela.Name = "pbxTabela";
            this.pbxTabela.Size = new System.Drawing.Size(360, 360);
            this.pbxTabela.TabIndex = 0;
            this.pbxTabela.TabStop = false;
            this.pbxTabela.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pbxTabela.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxTabela_MouseClick);
            // 
            // lblNaslov
            // 
            this.lblNaslov.AutoSize = true;
            this.lblNaslov.Font = new System.Drawing.Font("Showcard Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNaslov.Location = new System.Drawing.Point(113, 9);
            this.lblNaslov.Name = "lblNaslov";
            this.lblNaslov.Size = new System.Drawing.Size(181, 40);
            this.lblNaslov.TabIndex = 1;
            this.lblNaslov.Text = " Миноловац";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(144, 462);
            this.btnStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(134, 50);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Покрени игру";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbxBrojZastavica
            // 
            this.tbxBrojZastavica.Location = new System.Drawing.Point(31, 20);
            this.tbxBrojZastavica.Name = "tbxBrojZastavica";
            this.tbxBrojZastavica.Size = new System.Drawing.Size(33, 26);
            this.tbxBrojZastavica.TabIndex = 3;
            // 
            // lblBrojZastavica
            // 
            this.lblBrojZastavica.AutoSize = true;
            this.lblBrojZastavica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrojZastavica.Location = new System.Drawing.Point(70, 20);
            this.lblBrojZastavica.Name = "lblBrojZastavica";
            this.lblBrojZastavica.Size = new System.Drawing.Size(54, 20);
            this.lblBrojZastavica.TabIndex = 4;
            this.lblBrojZastavica.Text = "Broj ⚑:";
            // 
            // tbxTajmer
            // 
            this.tbxTajmer.Location = new System.Drawing.Point(358, 23);
            this.tbxTajmer.Name = "tbxTajmer";
            this.tbxTajmer.Size = new System.Drawing.Size(33, 26);
            this.tbxTajmer.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmIgra
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(744, 664);
            this.Controls.Add(this.tbxTajmer);
            this.Controls.Add(this.lblBrojZastavica);
            this.Controls.Add(this.tbxBrojZastavica);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblNaslov);
            this.Controls.Add(this.pbxTabela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmIgra";
            this.Text = "Миноловац";
            this.Load += new System.EventHandler(this.frmIgra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxTabela)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxTabela;
        private System.Windows.Forms.Label lblNaslov;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbxBrojZastavica;
        private System.Windows.Forms.Label lblBrojZastavica;
        private System.Windows.Forms.TextBox tbxTajmer;
        private System.Windows.Forms.Timer timer1;
    }
}

