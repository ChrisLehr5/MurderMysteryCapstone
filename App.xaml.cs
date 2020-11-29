using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using MurderMysteryCapstone.BusinessLayer;

namespace MurderMysteryCapstone
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            GameBusiness gameBusiness = new GameBusiness();

            InitializeComponent();
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };
            timer.Tick += delegate
            {
                timer.Stop();
                MessageBox.Show("Hey, pay attention!");
                timer.Start();
            };
            timer.Start();
            InputManager.Current.PostProcessInput += delegate (object s, ProcessInputEventArgs r)
            {
                if (r.StagingItem.Input is MouseButtonEventArgs || r.StagingItem.Input is KeyEventArgs)
                    timer.Interval = TimeSpan.FromSeconds(10);
            };

        }

    }
}    

