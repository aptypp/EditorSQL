using System.ComponentModel;
using System.Runtime.CompilerServices;
using EditorSQL.Models;
using Microsoft.Data.SqlClient;

namespace EditorSQL.ViewModels
{
    public sealed class EditorViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string databaseData
        {
            get => _model.databaseData;
            private set
            {
                if (value == _model.databaseData) return;
                _model.databaseData = value;
                OnPropertyChanged();
            }
        }

        private readonly EditorModel _model;
        private readonly SqlConnection _sqlConnection;

        public EditorViewModel()
        {
            _model = new EditorModel();
            _sqlConnection = ConnectToDataBase();
        }

        ~EditorViewModel()
        {
            _sqlConnection.Dispose();
        }

        public void PullData()
        {
            string query = "SELECT * FROM things";

            string newData = string.Empty;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            using SqlConnection connection =
                new SqlConnection(
                    "Server=localhost;Database=notes;Trusted_Connection=True;TrustServerCertificate=True");
            connection.Open();

            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                newData += reader.GetString(0) + "\n";
            }

            databaseData = newData;

            connection.Close();
        }

        public void PushData(string data)
        {
            string query = $"INSERT INTO things (Content) values (@Value)";

            using SqlConnection connection =
                new SqlConnection(
                    "Server=localhost;Database=notes;Trusted_Connection=True;TrustServerCertificate=True");
            connection.Open();

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Value", data);

            command.ExecuteNonQuery();

            connection.Close();
        }

        private SqlConnection ConnectToDataBase()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "<ARTUR>";
            builder.InitialCatalog = "<notes>";
            builder.IntegratedSecurity = true;

            return new SqlConnection(builder.ConnectionString);
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}