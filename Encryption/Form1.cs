using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryption2
{
    public partial class Form1 : Form
    {
        // Path variables for source, encryption, and
        // decryption folders. Must end with a backslash.
        const string EncrFolder = @"c:\Encrypt\";
        const string DecrFolder = @"c:\Decrypt\";
        const string SrcFolder = @"c:\docs\";
        private Encryption encryption;
        // Public key file
        const string PubKeyFile = @"c:\encrypt\rsaPublicKey.txt";

        // Key container name for
        // private/public key value pair.
        const string keyName = "Key01";
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            encryption = new Encryption();
          
         }
        private void buttonCreateAsmKeys_Click(object sender, System.EventArgs e)
        {
           
        }
        private void buttonEncryptFile_Click(object sender, System.EventArgs e)
        {
           // Display a dialog box to select a file to encrypt.
                openFileDialog1.InitialDirectory = SrcFolder;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string fName = openFileDialog1.FileName;
                    if (fName != null)
                    {
                        FileInfo fInfo = new FileInfo(fName);
                        // Pass the file name without the path.
                        string name = fInfo.FullName;
                        encryption.EncryptFile(name);
                }
                }
         }
        
      
        private void buttonDecryptFile_Click(object sender, EventArgs e)
        {
            // Display a dialog box to select the encrypted file.
                openFileDialog2.InitialDirectory = EncrFolder;
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    string fName = openFileDialog2.FileName;
                    if (fName != null)
                    {
                        FileInfo fi = new FileInfo(fName);
                        string name = fi.Name;
                        encryption.DecryptFile(name);
                    }
                }
        }
        
        

        void buttonExportPublicKey_Click(object sender, System.EventArgs e)
        {
            encryption.ExportPublicKey();   
        }

        void buttonImportPublicKey_Click(object sender, System.EventArgs e)
        {
           encryption.ImportPublicKey();
        }
        private void buttonGetPrivateKey_Click(object sender, EventArgs e)
        {
            encryption.GetPrivateKey();
        }
    }
}
