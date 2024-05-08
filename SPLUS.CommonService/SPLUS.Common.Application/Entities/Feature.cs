using System;
using System.Collections.Generic;

namespace SPLUS.Common.Application.Entities;

public partial class Feature
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;
}
