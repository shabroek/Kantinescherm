using Microsoft.AspNetCore.Mvc;
using Shabroek.Kantinescherm.API.Dtos;
using Shabroek.Kantinescherm.API.Model;

namespace Shabroek.Kantinescherm.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PricesController : ControllerBase
{
    private readonly PriceListContext _context;

    public PricesController(PriceListContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<PriceListGroupDto> Get()
    {
        return _context.Groups.Select(x =>

            new PriceListGroupDto
            {
                Name = x.GroupName,
                Prices = x.Prices.Select(p => new PriceDto
                {
                    Name = p.Name,
                    Price = p.Price
                })
            });
    }
}