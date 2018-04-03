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
using System.Configuration;
using System.Data.Common;

namespace DzGroops
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected DbConnection CreateConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["SteamAppConnectionString"];
            string ConnectionString = connectionString.ConnectionString;
           string ProviderName = connectionString.ProviderName;
            DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);
            var connection = factory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            return connection;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                var deleteCommand = connection.CreateCommand();
                //лучше stringbuilder и форматирование
                deleteCommand.CommandText = $@"Create table gruppa (Id int primary key identity,Name Varchar(50))";
                deleteCommand.ExecuteNonQuery();

            }
        }
    }
}
