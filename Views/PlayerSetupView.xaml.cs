using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using MurderMysteryCapstone.Models;
using MurderMysteryCapstone.DataAcessLayer;
using System.Data.SqlClient;
using System.Data;

namespace MurderMysteryCapstone.Views
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;      
       

        public PlayerSetupView(Player player)
        {
            _player = player;

            InitializeComponent();

            SetupWindow();
        }

        private void SetupWindow()
        {
            //generate content for inside the combo box 

            //List<string> traits = Enum.GetNames(typeof(Player.TraitType)).ToList();
            //List<string> jobTitles = Enum.GetNames(typeof(Player.PlayThroughDifficulty)).ToList();
            //JobTitleComboBox.ItemsSource = jobTitles;
            //TraitComboBox.ItemsSource = traits;

            //hide error message box
            ErrorMessageTextBlock.Visibility = Visibility.Hidden;
        }

        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (NameTextBox.Text == "")
            {
                errorMessage += "Name cannot be empty! Please input a name.\n";
            }
            if (int.TryParse(NameTextBox.Text, out int name))
            {
                errorMessage += "Player Name cannot contain numbers. \n";
            }
            else
            {
                _player.Name = NameTextBox.Text;
            }
            if (!int.TryParse(AgeTextBox.Text, out int age))
            {
                errorMessage += "Player Age is required and must be a number.\n";
            }
            else
            {
                _player.Age = age;
            }

            return errorMessage == "" ? true : false;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if (IsValidInput(out errorMessage))
            {
                //get values from combo boxes 
                //Enum.TryParse(JobTitleComboBox.SelectionBoxItem.ToString(), out Player.PlayThroughDifficulty playStyle);
               // Enum.TryParse(TraitComboBox.SelectionBoxItem.ToString(), out Player.TraitType trait);

                //player properties 
                //_player.PlayStyle = playStyle;
                //_player.Trait = trait;
                _player.Inventory = new ObservableCollection<GameItemQuantity>()
                {                   
                    new GameItemQuantity(GameData.GameItemById(2001), 5),
                };               

                Visibility = Visibility.Hidden;
            }
            else
            {
                //display error message 
                ErrorMessageTextBlock.Visibility = Visibility.Visible;
                ErrorMessageTextBlock.Text = errorMessage;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            NameTextBox.Text = "";
            AgeTextBox.Text = "";
            //JobTitleComboBox.SelectedIndex = 0;
            //TraitComboBox.SelectedIndex = 0;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            

            SqlConnection sc = new SqlConnection();
            SqlCommand com = new SqlCommand();
            sc.ConnectionString = ("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PlayerDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            sc.Open();
            com.Connection = sc;

            com.CommandText = @"INSERT INTO PlayerInfo (Id, Name, Age) VALUES (@Id, @Name, @Age)";
            com.Parameters.Add(new SqlParameter("Name", NameTextBox.Text));
            com.Parameters.Add(new SqlParameter("Age", AgeTextBox.Text));
            com.Parameters.Add(new SqlParameter("Id", IdTextBox.Text));

            com.ExecuteNonQuery();
            sc.Close();
        }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}