using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PasswordKeeeper.Controller
{
    class RandomPasswordAndCopy
    {
        private static View.MainWindow MainW = View.MainWindow.Class;
        public RandomPasswordAndCopy()
        {
            MainW.RandomPasswordBtn.Click += (s, e) =>
            {
                GetRandomPassword().SetPassword();
            };

            MainW.CopyPasswordBtn.Click += (s, e) =>
            {
                System.Windows.Clipboard.SetText(Data.Data.CurrentPassword);
            };
        }

        private int random(int max)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[4];

            rng.GetBytes(buffer);
            int result = BitConverter.ToInt32(buffer, 0);
            return new Random(result).Next(max);
        }

        public string GetRandomPassword()
        {
            const string charav = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~";
            StringBuilder password = new StringBuilder();
            Random rnd = new Random();
            int length = 16;
            while (length-- > 0)
                password.Append(charav[random(charav.Length)]);
            return password.ToString();
        }
    }
}
