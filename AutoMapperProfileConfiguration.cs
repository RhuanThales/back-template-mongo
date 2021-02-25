using AutoMapper;
using back_template_mongo.DAL.DTO;
using back_template_mongo.DAL.Models;

namespace back_template_mongo
{
	public class AutoMapperProfileConfiguration : Profile
	{
		public AutoMapperProfileConfiguration()
		{
			// Mapper de Livros
			CreateMap<LivroDto, Livro>().
				AfterMap((dto, model) => model.id = dto.id);
			CreateMap<Livro, LivroDto>().
				AfterMap((model, dto) => dto.id = model.id);
		}
	}
}