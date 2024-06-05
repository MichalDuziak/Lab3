namespace Lab3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.buttonGenerateKeys = new System.Windows.Forms.Button();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.textBoxPlainText = new System.Windows.Forms.TextBox();
            this.textBoxCipherText = new System.Windows.Forms.TextBox();
            this.textBoxPlainTextASCII = new System.Windows.Forms.TextBox();
            this.textBoxCipherTextASCII = new System.Windows.Forms.TextBox();
            this.textBoxPlainTextHEX = new System.Windows.Forms.TextBox();
            this.textBoxCipherTextHEX = new System.Windows.Forms.TextBox();
            this.textBoxKey = new System.Windows.Forms.TextBox();
            this.textBoxIV = new System.Windows.Forms.TextBox();
            this.labelEncryptionTime = new System.Windows.Forms.Label();
            this.labelDecryptionTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.FormattingEnabled = true;
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(12, 12);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAlgorithm.TabIndex = 0;
            // 
            // buttonGenerateKeys
            // 
            this.buttonGenerateKeys.Location = new System.Drawing.Point(150, 10);
            this.buttonGenerateKeys.Name = "buttonGenerateKeys";
            this.buttonGenerateKeys.Size = new System.Drawing.Size(121, 23);
            this.buttonGenerateKeys.TabIndex = 1;
            this.buttonGenerateKeys.Text = "Generate Keys";
            this.buttonGenerateKeys.UseVisualStyleBackColor = true;
            this.buttonGenerateKeys.Click += new System.EventHandler(this.buttonGenerateKeys_Click);
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Location = new System.Drawing.Point(12, 60);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonEncrypt.TabIndex = 2;
            this.buttonEncrypt.Text = "Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.buttonEncrypt_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Location = new System.Drawing.Point(100, 60);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(75, 23);
            this.buttonDecrypt.TabIndex = 3;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.buttonDecrypt_Click);
            // 
            // textBoxPlainText
            // 
            this.textBoxPlainText.Location = new System.Drawing.Point(12, 100);
            this.textBoxPlainText.Multiline = true;
            this.textBoxPlainText.Name = "textBoxPlainText";
            this.textBoxPlainText.Size = new System.Drawing.Size(300, 40);
            this.textBoxPlainText.TabIndex = 4;
            // 
            // textBoxCipherText
            // 
            this.textBoxCipherText.Location = new System.Drawing.Point(12, 160);
            this.textBoxCipherText.Multiline = true;
            this.textBoxCipherText.Name = "textBoxCipherText";
            this.textBoxCipherText.Size = new System.Drawing.Size(300, 40);
            this.textBoxCipherText.TabIndex = 5;
            // 
            // textBoxPlainTextASCII
            // 
            this.textBoxPlainTextASCII.Location = new System.Drawing.Point(12, 220);
            this.textBoxPlainTextASCII.Multiline = true;
            this.textBoxPlainTextASCII.Name = "textBoxPlainTextASCII";
            this.textBoxPlainTextASCII.Size = new System.Drawing.Size(300, 40);
            this.textBoxPlainTextASCII.TabIndex = 6;
            // 
            // textBoxCipherTextASCII
            // 
            this.textBoxCipherTextASCII.Location = new System.Drawing.Point(12, 280);
            this.textBoxCipherTextASCII.Multiline = true;
            this.textBoxCipherTextASCII.Name = "textBoxCipherTextASCII";
            this.textBoxCipherTextASCII.Size = new System.Drawing.Size(300, 40);
            this.textBoxCipherTextASCII.TabIndex = 7;
            // 
            // textBoxPlainTextHEX
            // 
            this.textBoxPlainTextHEX.Location = new System.Drawing.Point(12, 340);
            this.textBoxPlainTextHEX.Multiline = true;
            this.textBoxPlainTextHEX.Name = "textBoxPlainTextHEX";
            this.textBoxPlainTextHEX.Size = new System.Drawing.Size(300, 40);
            this.textBoxPlainTextHEX.TabIndex = 8;
            // 
            // textBoxCipherTextHEX
            // 
            this.textBoxCipherTextHEX.Location = new System.Drawing.Point(12, 400);
            this.textBoxCipherTextHEX.Multiline = true;
            this.textBoxCipherTextHEX.Name = "textBoxCipherTextHEX";
            this.textBoxCipherTextHEX.Size = new System.Drawing.Size(300, 40);
            this.textBoxCipherTextHEX.TabIndex = 9;
            // 
            // textBoxKey
            // 
            this.textBoxKey.Location = new System.Drawing.Point(330, 12);
            this.textBoxKey.Name = "textBoxKey";
            this.textBoxKey.Size = new System.Drawing.Size(300, 20);
            this.textBoxKey.TabIndex = 10;
            // 
            // textBoxIV
            // 
            this.textBoxIV.Location = new System.Drawing.Point(330, 38);
            this.textBoxIV.Name = "textBoxIV";
            this.textBoxIV.Size = new System.Drawing.Size(300, 20);
            this.textBoxIV.TabIndex = 11;
            // 
            // labelEncryptionTime
            // 
            this.labelEncryptionTime.AutoSize = true;
            this.labelEncryptionTime.Location = new System.Drawing.Point(330, 70);
            this.labelEncryptionTime.Name = "labelEncryptionTime";
            this.labelEncryptionTime.Size = new System.Drawing.Size(86, 13);
            this.labelEncryptionTime.TabIndex = 12;
            this.labelEncryptionTime.Text = "Encryption Time:";
            // 
            // labelDecryptionTime
            // 
            this.labelDecryptionTime.AutoSize = true;
            this.labelDecryptionTime.Location = new System.Drawing.Point(330, 100);
            this.labelDecryptionTime.Name = "labelDecryptionTime";
            this.labelDecryptionTime.Size = new System.Drawing.Size(87, 13);
            this.labelDecryptionTime.TabIndex = 13;
            this.labelDecryptionTime.Text = "Decryption Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(636, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Key";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(636, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "IV";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "PlainText";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "CipherText";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "PlainTextASCII";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 307);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "CipherTextASCII";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(318, 367);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "PlainTextHEX";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(318, 428);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "CipherTextHEX";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelDecryptionTime);
            this.Controls.Add(this.labelEncryptionTime);
            this.Controls.Add(this.textBoxIV);
            this.Controls.Add(this.textBoxKey);
            this.Controls.Add(this.textBoxCipherTextHEX);
            this.Controls.Add(this.textBoxPlainTextHEX);
            this.Controls.Add(this.textBoxCipherTextASCII);
            this.Controls.Add(this.textBoxPlainTextASCII);
            this.Controls.Add(this.textBoxCipherText);
            this.Controls.Add(this.textBoxPlainText);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.buttonGenerateKeys);
            this.Controls.Add(this.comboBoxAlgorithm);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.Button buttonGenerateKeys;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.TextBox textBoxPlainText;
        private System.Windows.Forms.TextBox textBoxCipherText;
        private System.Windows.Forms.TextBox textBoxPlainTextASCII;
        private System.Windows.Forms.TextBox textBoxCipherTextASCII;
        private System.Windows.Forms.TextBox textBoxPlainTextHEX;
        private System.Windows.Forms.TextBox textBoxCipherTextHEX;
        private System.Windows.Forms.TextBox textBoxKey;
        private System.Windows.Forms.TextBox textBoxIV;
        private System.Windows.Forms.Label labelEncryptionTime;
        private System.Windows.Forms.Label labelDecryptionTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}
