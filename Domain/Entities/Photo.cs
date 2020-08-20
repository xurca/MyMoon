using MyMoon.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Domain.Entities
{
    public class Photo : ValueObject
    {
        public Photo()
        {
        }

        public Photo(string filename, string extension)
        {
            Extension = extension;
            FileName = filename;
        }

        public string Extension { get; private set; }

        public string FileName { get; private set; }

        public string GetFileName()
        {
            return $"{FileName}.{Extension}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FileName;
            yield return Extension;
        }
    }
}
