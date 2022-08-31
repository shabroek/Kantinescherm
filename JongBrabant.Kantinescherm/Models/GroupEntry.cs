using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JongBrabant.Kantinescherm.Models;

public class GroupEntry
{
    [Key]
    public int GroupId { get; set; }

    public IEnumerable<PriceEntry> Prices { get; set; }
    public string GroupName { get; set; }
}