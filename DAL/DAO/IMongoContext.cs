using back_template_mongo.DAL.Models;
using MongoDB.Driver;

namespace back_template_mongo.DAL.DAO
{
    public interface IMongoContext
    {
        IMongoCollection<Livro> CollectionLivro { get; }
    }
}