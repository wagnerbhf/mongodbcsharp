using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoTuto
{
    public class MongoLivrariaRepository
    {
        private readonly MongoLivraria _mongoLivraria;

        public MongoLivrariaRepository()
        {
            _mongoLivraria = new MongoLivraria();
        }

        public async Task Inserir()
        {
            var livro1 = new Livro("Dom Casmurro", "Machado de Assis", 1923, 188, "Romance,Brasileira");
            var livro2 = new Livro("A Arte da Ficção", "David Lodge", 2002, 230, "Didático, Auto Ajuda");

            await _mongoLivraria.Livros.InsertOneAsync(livro1);
            await _mongoLivraria.Livros.InsertOneAsync(livro2);

            Console.WriteLine("Documento incluído");
        }

        public void Pesquisar1()
        {
            var filtro = new BsonDocument()
            {
                {"Titulo", "Dom Casmurro" }
            };

            var livros = _mongoLivraria.Livros.Find(filtro).SortBy(l => l.Titulo).ToListAsync().Result;

            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson());
            }
        }

        public async Task Pesquisar2()
        {
            var construtorFilter = Builders<Livro>.Filter;
            var condicaoFilter = construtorFilter.Eq(l => l.Titulo, "Dom Casmurro");

            var livros = await _mongoLivraria.Livros.Find(condicaoFilter).ToListAsync();

            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson());
            }
        }

        public async Task Pesquisar3()
        {
            var construtorFilter = Builders<Livro>.Filter;
            var condicaoFilter = construtorFilter.Gte(l => l.Ano, 1999) & construtorFilter.Gte(l => l.Paginas, 300);

            var livros = await _mongoLivraria.Livros.Find(condicaoFilter).ToListAsync();

            foreach (var livro in livros)
            {
                Console.WriteLine(livro.ToJson());
            }
        }

        public async Task Alterar1()
        {
            var construtorFilter = Builders<Livro>.Filter;
            var condicaoFilter = construtorFilter.Eq(l => l.Titulo, "Dom Casmurro");

            var livros = await _mongoLivraria.Livros.Find(condicaoFilter).ToListAsync();

            foreach (var livro in livros)
            {
                livro.Ano = 2000;
                livro.Paginas = 900;

                await _mongoLivraria.Livros.ReplaceOneAsync(condicaoFilter, livro);
            }
        }

        public async Task Alterar2()
        {
            var construtorFilter = Builders<Livro>.Filter;
            var condicaoFilter = construtorFilter.Eq(l => l.Titulo, "Dom Casmurro");

            var construtorUpdate = Builders<Livro>.Update;
            var condicaoUpdate = construtorUpdate.Set(l => l.Ano, 2011);

            _mongoLivraria.Livros.UpdateMany(condicaoFilter, condicaoUpdate);
        }

        public async Task Excluir()
        {
            var construtorFilter = Builders<Livro>.Filter;
            var condicaoFilter = construtorFilter.Eq(l => l.Titulo, "Dom Casmurro");

            await _mongoLivraria.Livros.DeleteManyAsync(condicaoFilter);
        }
    }
}