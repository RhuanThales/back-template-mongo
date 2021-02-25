using System.Collections.Generic;
using System.Linq;
using back_template_mongo.DAL.Models;
using MongoDB.Driver;

namespace back_template_mongo.DAL.DAO
{
    public class SeedingService
    {
        private readonly IMongoContext _context;

        public SeedingService(IMongoContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            /* if (_context.CollectionLivro.Find(unid => true).ToList().Count != 0)
            {
                return; // DB has been seeded
            }

            Livro obj = new Livro();

            List<Livro> livros = new List<Livro>();
            livros.Add(obj);

            _context.CollectionLivro.InsertMany(livros); */
        }
    }
}
