using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace PasswordKeeeper.Controller
{
    public class ListboxSelectionChanged
    {
        private static View.MainWindow MainW = View.MainWindow.Class;
        
        public ListboxSelectionChanged()
        {
            Data.DB.GetAllItems();
            for (int i = 0; i < Data.LogPassDescList.list.Count; i++)
            {
                MainW.listbox.Items.Add(Data.LogPassDescList.list[i].Resource);
            }

            MainW.listbox.MouseDown += (s, e) =>
            {
                MainW.listbox.SelectedIndex = -1;
            };

            MainW.listbox.SelectionChanged += (s, e) =>
            {
                Data.DB.GetAllItems();
                if(MainW.listbox.SelectedIndex == -1 || MainW.listbox.SelectedIndex >= Data.LogPassDescList.list.Count)
                {
                    View.v.ClearAllTextboxes();
                }
                else
                {
                    MainW.ResourceBox.Text = Data.LogPassDescList.list[MainW.listbox.SelectedIndex].Resource;
                    MainW.LoginBox.Text = Data.LogPassDescList.list[MainW.listbox.SelectedIndex].Login;
                    Data.LogPassDescList.list[MainW.listbox.SelectedIndex].Password.SetPassword();
                }
            };
        }
    }
}
