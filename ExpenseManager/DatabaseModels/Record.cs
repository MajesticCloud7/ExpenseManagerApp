using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExpenseManager.DatabaseModels
{
    public class Record
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public RecordType RecordType { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }

        public Record(string userId, RecordType recordType, double amount, string description)
        {
            UserId = userId;
            RecordType = recordType;
            Amount = amount;
            Description = description;
        }
    }

    public enum RecordType
    {
        Expense,
        Income
    }
}
