using System;
using System.Linq;
using System.Collections.Generic;
using MongoDB.Driver;
using back_template_mongo.DAL.Models;
using back_template_mongo.DAL.DTO;

namespace back_template_mongo.DAL.DAO
{
  public class LivroDao : ILivroDao
  {
    private readonly IMongoContext _context;

    public LivroDao(IMongoContext context)
    {
      _context = context;
    }

    public void Inserir(Livro objLivro)
    {
      Livro livro = new Livro
      {
        titulo = objLivro.titulo.TrimStart().TrimEnd(),
        autor = objLivro.autor.TrimStart().TrimEnd(),
        editora = objLivro.editora.TrimStart().TrimEnd(),
        ano = objLivro.ano,
        sinopse = objLivro.sinopse.TrimStart().TrimEnd(),
        descricao = objLivro.descricao.TrimStart().TrimEnd(),
        qtd_paginas = objLivro.qtd_paginas,
        preco = objLivro.preco
      };
      
      _context.CollectionLivro.InsertOne(livro);
    }
    
    public List<LivroDto> ObterTodos()
    {
      List<LivroDto> listaLivros = new List<LivroDto>();
      
      var livros = _context.CollectionLivro.Find(liv => true).ToList();

      foreach (var item in livros)
      {
        LivroDto livro = new LivroDto
        {
          id = item.id,
          titulo = item.titulo,
          autor = item.autor,
          editora = item.editora,
          ano = item.ano,
          sinopse = item.sinopse,
          descricao = item.descricao,
          qtd_paginas = item.qtd_paginas,
          preco = item.preco
        };

        listaLivros.Add(livro);
      }

      return listaLivros;
    }

    public LivroDto ObterPorId(string id)
    {
      var resultado = _context.CollectionLivro.Find<Livro>(liv => liv.id == id).FirstOrDefault();
      
      if (resultado != null)
      {
        LivroDto livro = new LivroDto
        {
          id = resultado.id,
          titulo = resultado.titulo,
          autor = resultado.autor,
          editora = resultado.editora,
          ano = resultado.ano,
          sinopse = resultado.sinopse,
          descricao = resultado.descricao,
          qtd_paginas = resultado.qtd_paginas,
          preco = resultado.preco
        };
        
        return livro;
      }
      else{
        return null;
      }
    }

    public LivroDto ObterPorTitulo(string titulo)
    {
      var resultado = _context.CollectionLivro.Find<Livro>(liv => liv.titulo.ToLower() == titulo.ToLower()).FirstOrDefault();

      if (resultado != null)
      {
        LivroDto livro = new LivroDto
        {
          id = resultado.id,
          titulo = resultado.titulo,
          autor = resultado.autor,
          editora = resultado.editora,
          ano = resultado.ano,
          sinopse = resultado.sinopse,
          descricao = resultado.descricao,
          qtd_paginas = resultado.qtd_paginas,
          preco = resultado.preco
        };

        return livro;
      }
      else {
        return null;
      }
    }

    public void Atualizar(string id, Livro objLivro)
    {
      Livro livro = new Livro
      {
        id = id,
        titulo = objLivro.titulo.TrimStart().TrimEnd(),
        autor = objLivro.autor.TrimStart().TrimEnd(),
        editora = objLivro.editora.TrimStart().TrimEnd(),
        ano = objLivro.ano,
        sinopse = objLivro.sinopse.TrimStart().TrimEnd(),
        descricao = objLivro.descricao.TrimStart().TrimEnd(),
        qtd_paginas = objLivro.qtd_paginas,
        preco = objLivro.preco
      };

      _context.CollectionLivro.ReplaceOne(liv => liv.id == id, livro);
    }

    public void Deletar(string id)
    {
      _context.CollectionLivro.DeleteOne(liv => liv.id == id);
    }
  }
}