using MongoDB.Driver;

namespace MongoTuto
{
    public class MongoAeroporto
    {
        private const string connString = "mongodb://localhost:27017";
        public const string databaseName = "geo";
        public const string collectionName = "airports";
        private static IMongoClient cliente;
        private static IMongoDatabase database;

        public MongoAeroporto()
        {
            cliente = new MongoClient(connString);
            database = cliente.GetDatabase(databaseName);
        }

        public IMongoClient Cliente
        {
            get { return cliente; }
        }

        public IMongoCollection<Aeroporto> Aeroportos
        {
            get { return database.GetCollection<Aeroporto>(collectionName); }
        }
    }
}
