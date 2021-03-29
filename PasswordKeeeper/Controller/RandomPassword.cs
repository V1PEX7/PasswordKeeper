using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace PasswordKeeeper.Controller
{
    class RandomPassword
    {
        private static View.MainWindow MainW = View.MainWindow.Class;
        public RandomPassword()
        {
            MainW.RandomPasswordBtn.Click += (s, e) =>
            {
                const string charav = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!#$%&\'()*+,-./:;<=>?@[\\]^_`{|}~";
                StringBuilder password = new StringBuilder();
                Random rnd = new Random();
                int length = 16;
                while (length-- > 0)
                    password.Append(charav[random(charav.Length)]);
                password.ToString().SetPassword();
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
    }
}
