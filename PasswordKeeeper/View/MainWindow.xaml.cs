using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace PasswordKeeeper.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Class;
        public MainWindow()
        {
            Data.DB.Initialize();
            InitializeComponent();
            Class = this;
            PasswordKeeper.Data.Crypt.Fs.WriteKey();
            PasswordKeeper.Data.Crypt.Fs.ReadKey();
            new Controller.ListboxSelectionChanged();
            new Controller.AddDelChange();
            new ShowHidePassword();
            new Controller.RandomPasswordAndCopy();
        }
    }
}
