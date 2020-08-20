using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.Common
{
    public abstract class AuditableEntity : Entity
    {
        public string CreatedBy { get; private set; }

        public DateTime Created { get; private set; }

        public string LastModifiedBy { get; private set; }

        public DateTime? LastModified { get; private set; }
    }
}
