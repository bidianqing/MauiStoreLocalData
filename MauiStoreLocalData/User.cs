using SQLite;

namespace MauiStoreLocalData
{
    [Table("user")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Username { get; set; }
    }

    public class UserRepository
    {
        private SQLiteAsyncConnection connection;
        private string _databasePath;

        public UserRepository(string databasePath)
        {
            _databasePath = databasePath;
        }

        private async Task Init()
        {
            if (connection != null)
                return;

            connection = new SQLiteAsyncConnection(_databasePath);
            await connection.CreateTableAsync<User>();
        }

        public async Task AddNewPerson(string name)
        {
            // Call Init()
            await Init();

            // basic validation to ensure a name was entered
            if (string.IsNullOrEmpty(name))
                throw new Exception("Valid name required");

            await connection.InsertAsync(new User { Username = name });
        }
    }
}
