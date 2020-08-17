﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.Common
{
    public abstract class AuditableEntity : Entity
    {
        public string CreatedBy { get; set; }

        public DateTime Created { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
