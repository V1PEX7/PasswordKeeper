using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordKeeeper.View
{
    public static class v
    {
        private static View.MainWindow MainW = View.MainWindow.Class;
        public static void ClearAllTextboxes()
        {
            MainW.ResourceBox.Text = "";
            MainW.LoginBox.Text = "";
            MainW.PasswordBox.Password = "";
            MainW.PasswordTxtBox.Text = "";
        }
    }
}
