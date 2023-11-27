using System.ComponentModel.DataAnnotations;

namespace GH.ExMediator.ViewModels;

public record AddViewModel
{
    [Required]
    public string UserName { get; set; } = default!;
    [Required]
    public decimal Money { get; set; }
}
