using MongoDB.Driver;

namespace MongoCRUD
{
    public class MongoDbService
    {
        private readonly IMongoCollection<User> collection;

        public MongoDbService(IConfiguration configuration)
        {
            var database = new MongoClient(configuration.GetConnectionString("MongoDb")).GetDatabase("Account");
            collection = database.GetCollection<User>("User");
        }

        public async Task Create(User user) => await collection.InsertOneAsync(user);
        public async Task<User> Read(string id) => (await collection.FindAsync(x => x.Id == id)).FirstOrDefault();
        public async Task Update(User user) => await collection.ReplaceOneAsync(x => x.Id == user.Id, user);
        public async Task Delete(string id) => await collection.DeleteOneAsync(x => x.Id == id);
    }
}
