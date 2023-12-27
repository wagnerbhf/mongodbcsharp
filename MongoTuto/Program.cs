namespace MongoTuto
{
    public class Program
    {
        private static MongoLivrariaRepository _mongoLivrariaRepository = new();
        private static MongoAeroportoRepository _mongoAeroportoRepository = new();

        public static async Task Main()
        {
            await _mongoAeroportoRepository.Listar();
        }
    }
}