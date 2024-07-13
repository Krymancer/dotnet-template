using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }

    [Display(Name = "Created Date")] public DateTime CreatedDate { get; set; } = DateTime.Now;
    [Display(Name = "ModifiedDate Date")] public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public bool Cancelled { get; set; }
}