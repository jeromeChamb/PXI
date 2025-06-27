namespace TestPXIe6363
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.valueDisplay = new System.Windows.Forms.TextBox();
            this.buttonLire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valeur mesurée : ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // valueDisplay
            // 
            this.valueDisplay.Location = new System.Drawing.Point(125, 28);
            this.valueDisplay.Name = "valueDisplay";
            this.valueDisplay.Size = new System.Drawing.Size(88, 22);
            this.valueDisplay.TabIndex = 1;
            this.valueDisplay.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonLire
            // 
            this.buttonLire.Location = new System.Drawing.Point(260, 30);
            this.buttonLire.Name = "buttonLire";
            this.buttonLire.Size = new System.Drawing.Size(75, 23);
            this.buttonLire.TabIndex = 2;
            this.buttonLire.Text = "Lire";
            this.buttonLire.UseVisualStyleBackColor = true;
            this.buttonLire.Click += new System.EventHandler(this.buttonLire_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 79);
            this.Controls.Add(this.buttonLire);
            this.Controls.Add(this.valueDisplay);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "PXIe-6363 Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox valueDisplay;
        private System.Windows.Forms.Button buttonLire;
    }
}

