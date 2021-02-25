using MongoDB.Driver;
using Microsoft.Extensions.Options;
using back_template_mongo.DAL.Models;

namespace back_template_mongo.DAL.DAO
{
    public class MongoContext:IMongoContext
    {
        private readonly IMongoDatabase _db;

        public MongoContext(IOptions<Configuracoes> options, IMongoClient client)
        {
            _db = client.GetDatabase(options.Value.Database);
        }
        public IMongoCollection<Livro> CollectionLivro => _db.GetCollection<Livro>("Livro");
    }
}