using System;
using System.Linq;
using System.Collections.Generic;
using back_template_mongo.DAL.Models;
using back_template_mongo.DAL.DTO;
using back_template_mongo.DAL.DAO;
using back_template_mongo.BLL.Exceptions;

namespace back_template_mongo.BLL
{
  public class LivroBll : ILivroBll
  {
    public readonly ILivroDao _livroDao;
    
		public LivroBll(ILivroDao livroDao)
    {
      _livroDao = livroDao;
    }

    public void Inserir(Livro objLivro)
    {
      bool isTitleNull = String.IsNullOrWhiteSpace(objLivro.titulo); 
      
      if(isTitleNull)
      {
        throw new ObrigatoryFieldNotNullException("O titulo do livro não pode ser vazio!");
      }

      bool hasAnyBook = (_livroDao.ObterPorTitulo(objLivro.titulo)) != null;

      if (!hasAnyBook)
      {
        _livroDao.Inserir(objLivro);
      }
      else
      {
        throw new AlreadyExistsException("Já existe um livro com o titulo informado!");
      }
    }

    public List<LivroDto> ObterTodos()
    {
			try
			{
				return _livroDao.ObterTodos();
			}
			catch (SystemException error) 
			{
				throw new System.Exception(error.Message);
			}
    }

    public LivroDto ObterPorId(string id)
    {
			bool isIdNull = String.IsNullOrWhiteSpace(id); 

			if(isIdNull)
			{
				throw new ObrigatoryFieldNotNullException("O id do livro não pode ser vazio!");
			}
			
			var livro = _livroDao.ObterPorId(id);

			if(livro == null)
			{
				throw new NotFoundException("Livro com o id informado não encontrado.");
			}
			else
			{
				return livro;
			}
    }

    public LivroDto ObterPorTitulo(string titulo)
    {
			bool isTitleNull = String.IsNullOrWhiteSpace(titulo); 

			if(isTitleNull)
			{
				throw new ObrigatoryFieldNotNullException("O titulo do livro não pode ser vazio!");
			}

			var livro = _livroDao.ObterPorTitulo(titulo);

			if(livro == null)
			{
				throw new NotFoundException("Livro com o titulo informado não encontrado.");
			}
			else
			{
				return livro;
			}
    }

    public void Atualizar(string id, Livro objLivro)
    {
			var book = (_livroDao.ObterPorTitulo(objLivro.titulo));
			bool hasAnyBook = book!=null;

			if (!hasAnyBook)
			{
				_livroDao.Atualizar(id, objLivro);
			} 
			else 
			{
				if (book.id == id)
				{
					_livroDao.Atualizar(id, objLivro);
				}
				else
				{
					throw new AlreadyExistsException("Já existe um livro com o titulo informado!");
				}
			}
    }

    public void Deletar(string id)
    {
			var book = _livroDao.ObterPorId(id);
			bool hasAnyBook = book != null;
			
			if (!hasAnyBook)
			{
				throw new NotFoundException("Livro com o id informado não encontrado!");
			}
			else {
				try
				{
					_livroDao.Deletar(id);
				}
				catch (SystemException error)
				{
					throw new System.Exception(error.Message);
				}
			}
    }
  }
}
