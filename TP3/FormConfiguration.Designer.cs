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
            this.lbNbLignes.Location = new System.Drawing.Point(19, 31);
            this.lbNbLignes.Name = "lbNbLignes";
            this.lbNbLignes.Size = new System.Drawing.Size(99, 13);
            this.lbNbLignes.TabIndex = 2;
            this.lbNbLignes.Text = "Nombre de Lignes :";
            // 
            // lbNbColonnes
            // 
            this.lbNbColonnes.AutoSize = true;
            this.lbNbColonnes.Location = new System.Drawing.Point(6, 60);
            this.lbNbColonnes.Name = "lbNbColonnes";
            this.lbNbColonnes.Size = new System.Drawing.Size(112, 13);
            this.lbNbColonnes.TabIndex = 3;
            this.lbNbColonnes.Text = "Nombre de Colonnes :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnOkConfig);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lbNbColonnes);
            this.groupBox1.Controls.Add(this.lbNbLignes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 150);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration de la partie";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(125, 60);
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
            this.numericUpDown2.Size = new System.Drawing.Size(54, 20);
            this.numericUpDown2.TabIndex = 9;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(125, 31);
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
            this.numericUpDown1.Size = new System.Drawing.Size(54, 20);
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
            this.checkBox1.Location = new System.Drawing.Point(11, 88);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(107, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Désactivé le Son";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnOkConfig
            // 
            this.btnOkConfig.Location = new System.Drawing.Point(215, 114);
            this.btnOkConfig.Name = "btnOkConfig";
            this.btnOkConfig.Size = new System.Drawing.Size(80, 25);
            this.btnOkConfig.TabIndex = 6;
            this.btnOkConfig.Text = "Ok";
            this.btnOkConfig.UseVisualStyleBackColor = true;
            this.btnOkConfig.Click += new System.EventHandler(this.btnOkConfig_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(111, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Annuler";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(321, 170);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
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