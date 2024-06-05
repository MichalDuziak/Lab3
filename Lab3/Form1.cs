using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private SymmetricAlgorithm algorithm;
        private Stopwatch stopwatch;

        public Form1()
        {
            InitializeComponent();
            InitializeComboBox();
            stopwatch = new Stopwatch();
        }

        private void InitializeComboBox()
        {
            comboBoxAlgorithm.Items.Add("AES");
            comboBoxAlgorithm.Items.Add("DES");
            comboBoxAlgorithm.SelectedIndex = 0;
        }

        private void buttonGenerateKeys_Click(object sender, EventArgs e)
        {
            switch (comboBoxAlgorithm.SelectedItem.ToString())
            {
                case "AES":
                    algorithm = new AesCryptoServiceProvider();
                    break;
                case "DES":
                    algorithm = new DESCryptoServiceProvider();
                    break;
            }

            algorithm.GenerateKey();
            algorithm.GenerateIV();

            textBoxKey.Text = BitConverter.ToString(algorithm.Key).Replace("-", "");
            textBoxIV.Text = BitConverter.ToString(algorithm.IV).Replace("-", "");
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (algorithm == null)
            {
                MessageBox.Show("Generate keys first.");
                return;
            }

            byte[] plainTextBytes = Encoding.UTF8.GetBytes(textBoxPlainText.Text);
            byte[] encryptedBytes;

            stopwatch.Restart();
            using (ICryptoTransform encryptor = algorithm.CreateEncryptor())
            {
                encryptedBytes = encryptor.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);
            }
            stopwatch.Stop();
            labelEncryptionTime.Text = $"Encryption Time: {stopwatch.ElapsedMilliseconds} ms";

            textBoxCipherText.Text = Convert.ToBase64String(encryptedBytes);
            textBoxCipherTextASCII.Text = Encoding.ASCII.GetString(encryptedBytes);
            textBoxCipherTextHEX.Text = BitConverter.ToString(encryptedBytes).Replace("-", "");
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            if (algorithm == null)
            {
                MessageBox.Show("Generate keys first.");
                return;
            }

            byte[] encryptedBytes = Convert.FromBase64String(textBoxCipherText.Text);
            byte[] decryptedBytes;

            stopwatch.Restart();
            using (ICryptoTransform decryptor = algorithm.CreateDecryptor())
            {
                decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            }
            stopwatch.Stop();
            labelDecryptionTime.Text = $"Decryption Time: {stopwatch.ElapsedMilliseconds} ms";

            textBoxPlainTextASCII.Text = Encoding.ASCII.GetString(decryptedBytes);
            textBoxPlainTextHEX.Text = BitConverter.ToString(decryptedBytes).Replace("-", "");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
