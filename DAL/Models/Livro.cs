using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace back_template_mongo.DAL.Models
{
  public class Livro
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string id { get; set; }

    [BsonElement("titulo")]
    public string titulo { get; set; }

    [BsonElement("autor")]
    public string autor { get; set; }

    [BsonElement("editora")]
    public string editora { get; set; }

    [BsonElement("ano")]
    public int ano { get; set; }

    [BsonElement("sinopse")]
    public string sinopse { get; set; }

    [BsonElement("descricao")]
    public string descricao { get; set; }

    [BsonElement("qtd_paginas")]
    public int qtd_paginas { get; set; }

    [BsonElement("preco")]
    public float preco { get; set; }
  }
}