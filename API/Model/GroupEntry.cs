using System.ComponentModel.DataAnnotations;

namespace Shabroek.Kantinescherm.API.Model;

public class GroupEntry
{
    [Key]
    public int GroupId { get; set; }

    public IEnumerable<PriceEntry> Prices { get; set; }
    public string GroupName { get; set; }
}