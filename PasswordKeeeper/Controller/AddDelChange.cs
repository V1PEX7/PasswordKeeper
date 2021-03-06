using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
namespace PasswordKeeeper.Controller
{
    public class AddDelChange
    {
        private static View.MainWindow MainW = View.MainWindow.Class;

        public AddDelChange()
        {  
            MainW.AddBtn.Click += (s, e) =>
            {
                MainW.listbox.Items.Add(MainW.ResourceBox.Text);
                Data.DB.AddItem(MainW.ResourceBox.Text, MainW.LoginBox.Text, Data.Data.CurrentPassword);
                View.v.ClearAllTextboxes();
            };

            MainW.DeleteBtn.Click += (s, e) =>
            {
                if(MainW.listbox.SelectedIndex != -1)
                {
                    Data.DB.DeleteItem(Data.Data.list[MainW.listbox.SelectedIndex].id);
                    MainW.listbox.Items.Remove(MainW.listbox.SelectedItem);
                }
            };

            MainW.ChangeBtn.Click += (s, e) =>
            {
                string text = MainW.ResourceBox.Text;
                int i = MainW.listbox.SelectedIndex;
                Data.DB.UpdateItem(Data.Data.list[i].id,
                                   MainW.ResourceBox.Text,
                                   MainW.LoginBox.Text,
                                   Data.Data.CurrentPassword);
                MainW.listbox.Items.RemoveAt(i);
                MainW.listbox.Items.Insert(i, text);
                MainW.listbox.SelectedIndex = i;
            };
        }
    }
}
