namespace TP3
{
    partial class FormConfiguration
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
      this.lbNbLignes = new System.Windows.Forms.Label();
      this.lbNbColonnes = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
      this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
      this.checkBox1 = new System.Windows.Forms.CheckBox();
      this.btnOkConfig = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
      this.SuspendLayout();
      // 
      // lbNbLignes
      // 
      this.lbNbLignes.AutoSize = true;
      this.lbNbLignes.Location = new System.Drawing.Point(25, 38);
      this.lbNbLignes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbNbLignes.Name = "lbNbLignes";
      this.lbNbLignes.Size = new System.Drawing.Size(132, 17);
      this.lbNbLignes.TabIndex = 2;
      this.lbNbLignes.Text = "Nombre de Lignes :";
      // 
      // lbNbColonnes
      // 
      this.lbNbColonnes.AutoSize = true;
      this.lbNbColonnes.Location = new System.Drawing.Point(8, 74);
      this.lbNbColonnes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbNbColonnes.Name = "lbNbColonnes";
      this.lbNbColonnes.Size = new System.Drawing.Size(149, 17);
      this.lbNbColonnes.TabIndex = 3;
      this.lbNbColonnes.Text = "Nombre de Colonnes :";
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.groupBox1.Controls.Add(this.numericUpDown2);
      this.groupBox1.Controls.Add(this.numericUpDown1);
      this.groupBox1.Controls.Add(this.checkBox1);
      this.groupBox1.Controls.Add(this.btnOkConfig);
      this.groupBox1.Controls.Add(this.button2);
      this.groupBox1.Controls.Add(this.button1);
      this.groupBox1.Controls.Add(this.lbNbColonnes);
      this.groupBox1.Controls.Add(this.lbNbLignes);
      this.groupBox1.ForeColor = System.Drawing.Color.Maroon;
      this.groupBox1.Location = new System.Drawing.Point(4, 2);
      this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupBox1.Size = new System.Drawing.Size(401, 185);
      this.groupBox1.TabIndex = 4;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Configuration de la partie";
      // 
      // numericUpDown2
      // 
      this.numericUpDown2.Location = new System.Drawing.Point(167, 74);
      this.numericUpDown2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.numericUpDown2.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.numericUpDown2.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.numericUpDown2.Name = "numericUpDown2";
      this.numericUpDown2.Size = new System.Drawing.Size(72, 22);
      this.numericUpDown2.TabIndex = 9;
      this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
      // 
      // numericUpDown1
      // 
      this.numericUpDown1.Location = new System.Drawing.Point(167, 38);
      this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.numericUpDown1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
      this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Size = new System.Drawing.Size(72, 22);
      this.numericUpDown1.TabIndex = 8;
      this.numericUpDown1.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
      // 
      // checkBox1
      // 
      this.checkBox1.AutoSize = true;
      this.checkBox1.Location = new System.Drawing.Point(15, 108);
      this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.Size = new System.Drawing.Size(136, 21);
      this.checkBox1.TabIndex = 7;
      this.checkBox1.Text = "Désactivé le Son";
      this.checkBox1.UseVisualStyleBackColor = true;
      // 
      // btnOkConfig
      // 
      this.btnOkConfig.BackColor = System.Drawing.Color.DarkRed;
      this.btnOkConfig.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.btnOkConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOkConfig.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.btnOkConfig.Location = new System.Drawing.Point(287, 140);
      this.btnOkConfig.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnOkConfig.Name = "btnOkConfig";
      this.btnOkConfig.Size = new System.Drawing.Size(107, 31);
      this.btnOkConfig.TabIndex = 6;
      this.btnOkConfig.Text = "Ok";
      this.btnOkConfig.UseVisualStyleBackColor = false;
      this.btnOkConfig.Click += new System.EventHandler(this.btnOkConfig_Click);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.DarkRed;
      this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.button2.Location = new System.Drawing.Point(148, 140);
      this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(107, 31);
      this.button2.TabIndex = 5;
      this.button2.Text = "Reset";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.btnReset_Click);
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.DarkRed;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
      this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.button1.Location = new System.Drawing.Point(9, 140);
      this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(107, 31);
      this.button1.TabIndex = 4;
      this.button1.Text = "Annuler";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // FormConfiguration
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.ClientSize = new System.Drawing.Size(409, 190);
      this.ControlBox = false;
      this.Controls.Add(this.groupBox1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "FormConfiguration";
      this.Text = "Configuration du Jeu";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbNbLignes;
        private System.Windows.Forms.Label lbNbColonnes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnOkConfig;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.NumericUpDown numericUpDown2;
        public System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}