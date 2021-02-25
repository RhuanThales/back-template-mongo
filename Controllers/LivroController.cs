using System;
using System.Collections.Generic;
using back_template_mongo.Utils;
using back_template_mongo.Extensions.Responses;
using back_template_mongo.DAL.Models;
using back_template_mongo.DAL.DTO;
using back_template_mongo.BLL;
using back_template_mongo.BLL.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace back_template_mongo.Controllers
{
  // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [Route("api/[controller]")]
  [ApiController]
  public class LivroController:ControllerBase
  {
    private readonly ILivroBll _livroBll;
    private ILoggerManager _logger;
    private IMapper _mapper;
      
    public LivroController(ILivroBll livroBll, ILoggerManager logger, IMapper mapper)
    {
      _livroBll = livroBll;
      _logger = logger;
      _mapper = mapper;
    }

    [HttpPost("Inserir")]
    public IActionResult Inserir([FromBody]Livro objLivro)
    {
      try
      {
        _livroBll.Inserir(objLivro);
        return Ok(new ApiResponse(200, "Livro inserido com sucesso."));
      }
      catch (ObrigatoryFieldNotNullException error)
      {
        return BadRequest(new ApiResponse(402, error.Message));
      }
      catch (AlreadyExistsException error)
      {
        return BadRequest(new ApiResponse(403, error.Message));
      }
      catch (Exception error)
      {
        return BadRequest(new ApiResponse(500, error.Message));
      }
    }

      [HttpGet("ObterTodos")]
      public ActionResult<List<LivroDto>> ObterTodos()
      {
        try
        {
          var livros = _livroBll.ObterTodos();
          return Ok(new ApiOkResponse(livros));
        }
        catch (Exception error)
        {
          return BadRequest(new ApiResponse(500, error.Message));
        }
      }

      [HttpGet("ObterPorId/{id}")]
      public ActionResult<LivroDto> ObterPorId(string id)
      {
        try
        {
          var livro = _livroBll.ObterPorId(id);
          return Ok(new ApiOkResponse(livro));
        }
        catch (ObrigatoryFieldNotNullException error)
        {
          return BadRequest(new ApiResponse(402, error.Message));
        }
        catch (NotFoundException error)
        {
          return NotFound(new ApiResponse(404, error.Message));
        }
        catch (Exception error)
        {
          return BadRequest(new ApiResponse(500, error.Message));
        }
      }

      [HttpGet("ObterPorTitulo/{titulo}")]
      public ActionResult<LivroDto> ObterPorTitulo(string titulo)
      {
        try
        {
          var livro = _livroBll.ObterPorTitulo(titulo);
          return Ok(new ApiOkResponse(livro));
        }
        catch (ObrigatoryFieldNotNullException error)
        {
          return BadRequest(new ApiResponse(402, error.Message));
        }
        catch (NotFoundException error)
        {
          return NotFound(new ApiResponse(404, error.Message));
        }
        catch (Exception error)
        {
          return BadRequest(new ApiResponse(500, error.Message));
        }
      }

      [HttpPut("Atualizar/{id}")]
      public IActionResult Atualizar(string id, Livro objLivro)
      {
        try
        {
          _livroBll.Atualizar(id, objLivro);
          return Ok(new ApiResponse(200, $"{objLivro.titulo} atualizado com sucesso."));
        }
        catch (AlreadyExistsException error)
        {
          return BadRequest(new ApiResponse(403, error.Message));
        }
        catch (Exception error)
        {
          return BadRequest(new ApiResponse(500, error.Message));
        }
      }
      
      [HttpDelete("Deletar/{id}")]
      public IActionResult Deletar(string id)
      {
        try
        {
          _livroBll.Deletar(id);  
          return Ok(new ApiResponse(200, "Livro removido com sucesso."));
        }
        catch (NotFoundException error)
        {
          return NotFound(new ApiResponse(404, error.Message));
        }
        catch (Exception error)
        {
          return BadRequest(new ApiResponse(500, error.Message));
        }
      }
  }
}
