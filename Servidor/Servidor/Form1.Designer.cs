namespace Servidor
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
            this.components = new System.ComponentModel.Container();
            this.textBoxReceber = new System.Windows.Forms.TextBox();
            this.sensorPort = new System.IO.Ports.SerialPort(this.components);
            this.serialSelect = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxReceber
            // 
            this.textBoxReceber.Location = new System.Drawing.Point(17, 108);
            this.textBoxReceber.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxReceber.Multiline = true;
            this.textBoxReceber.Name = "textBoxReceber";
            this.textBoxReceber.ReadOnly = true;
            this.textBoxReceber.Size = new System.Drawing.Size(344, 190);
            this.textBoxReceber.TabIndex = 1;
            // 
            // sensorPort
            // 
            this.sensorPort.PortName = "COM3";
            this.sensorPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.sensorPort_DataReceived);
            // 
            // serialSelect
            // 
            this.serialSelect.FormattingEnabled = true;
            this.serialSelect.Location = new System.Drawing.Point(54, 46);
            this.serialSelect.Name = "serialSelect";
            this.serialSelect.Size = new System.Drawing.Size(190, 24);
            this.serialSelect.TabIndex = 2;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(250, 47);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(97, 23);
            this.connectButton.TabIndex = 3;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 321);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.serialSelect);
            this.Controls.Add(this.textBoxReceber);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Servidor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxReceber;
        private System.IO.Ports.SerialPort sensorPort;
        private System.Windows.Forms.ComboBox serialSelect;
        private System.Windows.Forms.Button connectButton;
    }
}

