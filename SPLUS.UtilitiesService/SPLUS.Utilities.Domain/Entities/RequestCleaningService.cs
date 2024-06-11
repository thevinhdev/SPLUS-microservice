using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SPLUS.Utilities.Domain.Entities;

public partial class RequestCleaningService
{
    [Key]
    public int Id { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string ProjectCode { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string TowerCode { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string ApartmentCode { get; set; } = null!;

    [StringLength(255)]
    public string ApartmentName { get; set; } = null!;

    public int ResidentId { get; set; }

    [StringLength(255)]
    public string ResidentName { get; set; } = null!;

    [StringLength(255)]
    public string UserRequestName { get; set; } = null!;

    [StringLength(255)]
    public string? UserRequestPhone { get; set; }

    public int ProcessStatus { get; set; }

    [StringLength(512)]
    public string Note { get; set; } = null!;

    public int CreatedById { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    public int? UpdatedById { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}
