using SQLite;

namespace MauiStoreLocalData
{
    [Table("conversation")]
    public class Conversation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public long UserId { get; set; }

        public string Username { get; set; }
    }
}
