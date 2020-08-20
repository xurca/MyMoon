using MyMoon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.Entities
{
    public class Preference : Entity
    {
        private Preference() { }

        public Preference(string name)
        {
            Name = name;
            IsActive = true;
            IsDeleted = false;
        }

        public string Name { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDeleted { get; private set; }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }

        public void MarkAsInActive()
        {
            IsActive = true;
        }
    }
}
