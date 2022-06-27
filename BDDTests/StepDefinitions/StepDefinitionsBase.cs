using ExpenseManager.DatabaseModels;
using MongoDB.Driver;

namespace BDDTests.StepDefinitions
{
    public class StepDefinitionsBase
    {
        protected const int MillisecondsDelay = 2000;
        private const string ConnectionString = "mongodb://127.0.0.1:27017";
        private const string DatabaseName = "ExpenseManagerDB";
        private const string UsersCollectionName = "Users";
        protected readonly List<User> Users;

        public StepDefinitionsBase()
        {
            var mongoClient = new MongoClient(ConnectionString);
            var database = mongoClient.GetDatabase(DatabaseName);
            var usersCollection = database.GetCollection<User>(UsersCollectionName);
            Users = usersCollection.Find(_ => true).ToList();
        }
    }
}
