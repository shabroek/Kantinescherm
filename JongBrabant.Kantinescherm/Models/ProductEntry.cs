using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JongBrabant.Kantinescherm.Models;

public class ProductEntry
{
    [Key]
    public int ProductId { get; set; }

    public int GroupId { get; set; }
    [DisplayName("Groep")]
    public GroupEntry Group { get; set; }
    [DisplayName("Naam")]
    public string Name { get; set; }
    [DisplayFormat(DataFormatString = "€{0:N2}", ApplyFormatInEditMode = false)]
    [DisplayName("Prijs")]
    public decimal Price { get; set; }
    [Display(Name = "Volgorde")]
    public int Order { get; set; }
}