using System;
using System.Collections.Generic;

namespace back_template_mongo.DAL.DTO
{
  public class LivroDto
  {
    public string id { get; set; }
    public string titulo { get; set; }
    public string autor { get; set; }
    public string editora { get; set; }
    public int ano { get; set; }
    public string sinopse { get; set; }
    public string descricao { get; set; }
    public int qtd_paginas { get; set; }
    public float preco { get; set; }
  }
}