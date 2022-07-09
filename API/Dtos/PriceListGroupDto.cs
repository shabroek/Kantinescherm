namespace Shabroek.Kantinescherm.API.Dtos;

public class PriceListGroupDto
{
    public object Name { get; set; }
    public IEnumerable<PriceDto> Prices { get; set; }
}