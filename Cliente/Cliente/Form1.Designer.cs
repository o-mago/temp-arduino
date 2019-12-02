namespace Cliente
{
    partial class Form1
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
            this.textBoxReceber = new System.Windows.Forms.TextBox();
            this.temperaturaLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.celsiusRadio = new System.Windows.Forms.RadioButton();
            this.fahrenheitRadio = new System.Windows.Forms.RadioButton();
            this.kelvinRadio = new System.Windows.Forms.RadioButton();
            this.unidadeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxReceber
            // 
            this.textBoxReceber.Location = new System.Drawing.Point(12, 187);
            this.textBoxReceber.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxReceber.Multiline = true;
            this.textBoxReceber.Name = "textBoxReceber";
            this.textBoxReceber.ReadOnly = true;
            this.textBoxReceber.Size = new System.Drawing.Size(108, 26);
            this.textBoxReceber.TabIndex = 1;
            // 
            // temperaturaLabel
            // 
            this.temperaturaLabel.AutoSize = true;
            this.temperaturaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperaturaLabel.Location = new System.Drawing.Point(12, 163);
            this.temperaturaLabel.Name = "temperaturaLabel";
            this.temperaturaLabel.Size = new System.Drawing.Size(101, 17);
            this.temperaturaLabel.TabIndex = 2;
            this.temperaturaLabel.Text = "Temperatura";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Unidade";
            // 
            // celsiusRadio
            // 
            this.celsiusRadio.AutoSize = true;
            this.celsiusRadio.Location = new System.Drawing.Point(12, 43);
            this.celsiusRadio.Name = "celsiusRadio";
            this.celsiusRadio.Size = new System.Drawing.Size(74, 21);
            this.celsiusRadio.TabIndex = 4;
            this.celsiusRadio.TabStop = true;
            this.celsiusRadio.Text = "Celsius";
            this.celsiusRadio.UseVisualStyleBackColor = true;
            this.celsiusRadio.CheckedChanged += new System.EventHandler(this.cmRadio_CheckedChanged);
            // 
            // fahrenheitRadio
            // 
            this.fahrenheitRadio.AutoSize = true;
            this.fahrenheitRadio.Location = new System.Drawing.Point(12, 84);
            this.fahrenheitRadio.Name = "fahrenheitRadio";
            this.fahrenheitRadio.Size = new System.Drawing.Size(97, 21);
            this.fahrenheitRadio.TabIndex = 5;
            this.fahrenheitRadio.TabStop = true;
            this.fahrenheitRadio.Text = "Fahrenheit";
            this.fahrenheitRadio.UseVisualStyleBackColor = true;
            this.fahrenheitRadio.CheckedChanged += new System.EventHandler(this.inRadio_CheckedChanged);
            // 
            // kelvinRadio
            // 
            this.kelvinRadio.AutoSize = true;
            this.kelvinRadio.Location = new System.Drawing.Point(12, 122);
            this.kelvinRadio.Name = "kelvinRadio";
            this.kelvinRadio.Size = new System.Drawing.Size(67, 21);
            this.kelvinRadio.TabIndex = 6;
            this.kelvinRadio.TabStop = true;
            this.kelvinRadio.Text = "Kelvin";
            this.kelvinRadio.UseVisualStyleBackColor = true;
            this.kelvinRadio.CheckedChanged += new System.EventHandler(this.hv41Radio_CheckedChanged);
            // 
            // unidadeLabel
            // 
            this.unidadeLabel.AutoSize = true;
            this.unidadeLabel.Location = new System.Drawing.Point(128, 195);
            this.unidadeLabel.Name = "unidadeLabel";
            this.unidadeLabel.Size = new System.Drawing.Size(59, 17);
            this.unidadeLabel.TabIndex = 7;
            this.unidadeLabel.Text = "unidade";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.unidadeLabel);
            this.Controls.Add(this.kelvinRadio);
            this.Controls.Add(this.fahrenheitRadio);
            this.Controls.Add(this.celsiusRadio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.temperaturaLabel);
            this.Controls.Add(this.textBoxReceber);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Cliente";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxReceber;
        private System.Windows.Forms.Label temperaturaLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton celsiusRadio;
        private System.Windows.Forms.RadioButton fahrenheitRadio;
        private System.Windows.Forms.RadioButton kelvinRadio;
        private System.Windows.Forms.Label unidadeLabel;
    }
}

