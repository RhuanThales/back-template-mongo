using System;
using System.Collections.Generic;
using back_template_mongo.DAL.Models;
using back_template_mongo.DAL.DTO;

namespace back_template_mongo.DAL.DAO
{
  public interface ILivroDao
  {
    // Create
    void Inserir(Livro objLivro);
    
    // Read
    List<LivroDto> ObterTodos();
    LivroDto ObterPorId(string id);
    LivroDto ObterPorTitulo(string titulo);
    
    // Update
    void Atualizar(string id, Livro objLivro);
    
    // Delete
    void Deletar(string id);
  }
}