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
using System.Windows.Shapes;

namespace MurderMysteryCapstone.Views
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>
    public partial class JournalStatusView : Window
    { 
        JournalStatusViewModel _journalStatusViewModel;
    
        public JournalStatusView(JournalStatusViewModel journalStatusViewModel)
        {
            _journalStatusViewModel = journalStatusViewModel;
            DataContext = journalStatusViewModel;

            InitializeWindowTheme();        

            InitializeComponent();
        }
        private void InitializeWindowTheme()
        {
            this.Title = "The Golden Mystery";
        }

        private void JournalStatusWindowClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
