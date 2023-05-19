//********************************************************************************************
//
// 文件名(File Name):                    FileDecryption
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/12 16:35:01
//
// 功能(Function):                         
//
// 修改记录(Revision History):
//         R1:
//********************************************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CommonLibrary
{
    public class FileDecryption
    {
        public static string Main()
        {

            String appStartupPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            appStartupPath = appStartupPath.Replace("bin\\Debug", "encrypted.key");
            string fileName = "encrypted.key";

            //D:\Project\TestWPF\TestWPF\bin\Debug

            // Create a new crypto provider

            TripleDESCryptoServiceProvider tdes =
             new TripleDESCryptoServiceProvider();
            // open the file containing the key and IV
            FileStream fsKeyIn = File.OpenRead(@"d:\temp\encrypted.key");
            // use a BinaryReader to read formatted data from the file
            BinaryReader br = new BinaryReader(fsKeyIn);
            // read data from the file and close it
            tdes.Key = br.ReadBytes(24);
            tdes.IV = br.ReadBytes(8);
            // Open the encrypted file
            FileStream fsIn = File.OpenRead(@"d:\\temp\\encrypted.txt");
            // Create a cryptostream to decrypt from the filestream
            CryptoStream cs = new CryptoStream(fsIn, tdes.CreateDecryptor(),
             CryptoStreamMode.Read);
            // Create a StreamReader to format the input
            StreamReader sr = new StreamReader(cs);
            // And decrypt the data
            string strFileContext = sr.ReadToEnd();
            sr.Close();
            return strFileContext;
        }

        public static void DecryptFile(string inputFile, string outputFile)
        {
            try
            {
                string password = @"12345678";
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

                MessageBox.Show("Decrypt Source file succeed!", "Msg :");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Source file error", "Error :");
            }
        }

    }
}
