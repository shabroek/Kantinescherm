using System.ComponentModel.DataAnnotations;

namespace JongBrabant.Kantinescherm.Models;

public class PriceEntry
{
    [Key]
    public int PriceId { get; set; }

    public int GroupId { get; set; }
    public GroupEntry Group { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}