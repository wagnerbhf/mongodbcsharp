using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace MongoTuto
{
    public class MongoAeroportoRepository
    {
        private readonly MongoAeroporto _mongoAeroporto;

        public MongoAeroportoRepository()
        {
            _mongoAeroporto = new MongoAeroporto();
        }

        public async Task Listar()
        {
            var ponto = new GeoJson2DGeographicCoordinates(-118.325258, 34.103212);
            var localizacao = new GeoJsonPoint<GeoJson2DGeographicCoordinates>(ponto);

            var construtor = Builders<Aeroporto>.Filter;
            var condicao = construtor.NearSphere(l => l.loc, localizacao, 100000);

            var aeroportos = await _mongoAeroporto.Aeroportos.Find(condicao).ToListAsync();

            foreach(var aeroporto in aeroportos)
            {
                Console.WriteLine(aeroporto.ToJson());
            }
        }
    }
}