using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoTuto
{
    public class Livro
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Ano { get; set; }
        public int Paginas { get; set; }
        public List<string> Assunto { get; set; }

        public Livro(string titulo, string autor, int ano, int paginas, string assunto)
        {
            Titulo = titulo;
            Autor = autor;
            Ano = ano;
            Paginas = paginas;

            string[] arrAssunto = assunto.Split(',');

            var listaAssunto = new List<string>();

            for (int i = 0; i <= arrAssunto.Length - 1; i++)
            {
                listaAssunto.Add(arrAssunto[i].Trim());
            }

            Assunto = listaAssunto;
        }
    }
}