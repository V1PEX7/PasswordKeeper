using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using PasswordKeeeper.Controller;
using PasswordKeeeper.View;
namespace PasswordKeeper.Data.Crypt
{
    public static class Fs
    {
        private static MainWindow MainW = MainWindow.Class;

        public static void WriteKey()
        {
            if (File.Exists("settings"))
                return;

            using (var fstream = SecureFileStream.OpenWithStream("settings", "keeperdata", FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(fstream, Encoding.Unicode))
            {
                var r = new RandomPasswordAndCopy();
                writer.Write(r.GetRandomPassword());
            }
        }

        public static void ReadKey()
        {
            using (var fstream = SecureFileStream.OpenWithStream("settings", "keeperdata", FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(fstream, Encoding.Unicode))
            {
                AES_256.aeskey = Encoding.ASCII.GetBytes(reader.ReadToEnd());
            }
        }
    }
}
