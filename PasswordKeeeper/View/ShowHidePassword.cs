using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace PasswordKeeeper.View
{

    class ShowHidePassword
    {
         static View.MainWindow MainW = View.MainWindow.Class;
        private bool hidepass = true;
        public ShowHidePassword()
        {
            MainW.PasswordBox.PasswordChar = '\u25CF';
            MainW.ShowPassBtn.Click += (s, e) =>
            {
                if (hidepass)
                {
                    MainW.PasswordTxtBox.Text = Data.Data.CurrentPassword;

                    MainW.PasswordBox.Visibility = System.Windows.Visibility.Hidden;
                    MainW.PasswordTxtBox.Visibility = System.Windows.Visibility.Visible;

                    hidepass = false;
                    MainW.ShowPassBtn.Content = "Скрыть пароль";
                }

                else
                {
                    MainW.PasswordBox.Password = Data.Data.CurrentPassword;

                    MainW.PasswordBox.Visibility = System.Windows.Visibility.Visible;
                    MainW.PasswordTxtBox.Visibility = System.Windows.Visibility.Hidden;

                    hidepass = true;
                    MainW.ShowPassBtn.Content = "Показать пароль";
                }
            };

            MainW.PasswordBox.PasswordChanged += (s, e) =>
            {
                if(hidepass)
                    Data.Data.CurrentPassword = MainW.PasswordBox.Password;
            };

            MainW.PasswordTxtBox.TextChanged += (s, e) =>
            {
                if (!hidepass)
                    Data.Data.CurrentPassword = MainW.PasswordTxtBox.Text;
            };
        }
    }
}
