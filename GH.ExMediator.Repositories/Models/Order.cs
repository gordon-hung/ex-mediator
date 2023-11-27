using System.ComponentModel.DataAnnotations.Schema;

namespace GH.ExMediator.Repositories.Models;

[Table("order")]
public class Order
{
    public long Id { get; set; }

    public string UserName { get; set; } = default!;

    public decimal Money { get; set; }

    public int State { get; set; }

    public DateTimeOffset CreatedTime { get; set; }

    public DateTimeOffset ConfirmedTime { get; set; }

    public DateTimeOffset CompletedTime { get; set; }

    public DateTimeOffset UpdateTime { get; set; }
}
