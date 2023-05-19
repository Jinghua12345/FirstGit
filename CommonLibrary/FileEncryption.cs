//********************************************************************************************
//
// 文件名(File Name):                    FileEncryption
//
// 作者(Author):                            LEGION
//
// 日期(Create Date):                     2023/4/12 16:29:51
//
// 功能(Function):                         文件加密
//
// 修改记录(Revision History):
//         R1:
//********************************************************************************************

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class FileEncryption
    {
        public static void Main()
        {
            //string strPath= System.Windows.Application.Current.Windows.
            // Create a new file to work with
            FileStream fsOut = File.Create(@"d:\temp\encrypted.txt");
            // Create a new crypto provider
            TripleDESCryptoServiceProvider tdes =
             new TripleDESCryptoServiceProvider();
            // Create a cryptostream to encrypt to the filestream
            CryptoStream cs = new CryptoStream(fsOut, tdes.CreateEncryptor(),
             CryptoStreamMode.Write);
            // Create a StreamWriter to format the output
            StreamWriter sw = new StreamWriter(cs);
            // And write some data
            sw.WriteLine("20250101");
            //sw.WriteLine("Did gyre and gimble in the wabe.");
            sw.Flush();
            sw.Close();
            // save the key and IV for future use
            FileStream fsKeyOut = File.Create(@"d:\\temp\encrypted.key");
            // use a BinaryWriter to write formatted data to the file
            BinaryWriter bw = new BinaryWriter(fsKeyOut);
            // write data to the file
            bw.Write(tdes.Key);
            bw.Write(tdes.IV);
            // flush and close
            bw.Flush();
            bw.Close();
        }
    }
}
