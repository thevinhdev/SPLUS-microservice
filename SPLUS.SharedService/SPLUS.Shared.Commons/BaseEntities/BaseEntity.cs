﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SPLUS.Shared.Commons.Enums.AppEnum;

namespace SPLUS.Shared.Commons.BaseEntities
{
    public class BaseEntity<TId>
    {
        public virtual TId Id { get; set; }
        public virtual EntityStatus Status { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }

    public class BaseEntity
    {
        public virtual int Id { get; set; }
        public virtual EntityStatus Status { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual DateTime UpdatedAt { get; set; }
    }
}
