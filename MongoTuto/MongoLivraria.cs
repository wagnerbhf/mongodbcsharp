using MongoDB.Driver;

namespace MongoTuto
{
    public class MongoLivraria
    {
        private const string connString = "mongodb://localhost:27017";
        public const string databaseName = "Biblioteca";
        public const string collectionName = "Livros";
        private static IMongoClient cliente;
        private static IMongoDatabase database;

        public MongoLivraria()
        {
            cliente = new MongoClient(connString);
            database = cliente.GetDatabase(databaseName);
        }

        public IMongoClient Cliente
        {
            get { return cliente; }
        }

        public IMongoCollection<Livro> Livros
        {
            get { return database.GetCollection<Livro>(collectionName); }
        }
    }
}