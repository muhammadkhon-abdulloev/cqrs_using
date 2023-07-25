namespace Application.Common.Models;

public class CityDto
{
    public int Id { get; init; }
    public string? Name { get; init; }
    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Domain.Entities.City, CityDto>().ReverseMap();
        }
    }
}