using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordKeeeper.Controller
{
    public static class Ext
    {
        private static View.MainWindow MainW = View.MainWindow.Class;
        public static void SetPassword(this string value)
        {
            MainW.PasswordBox.Password = value;
            MainW.PasswordTxtBox.Text = value;
        }
    }
}
