﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLUS.Utilities.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
    }
}