using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMoon.Infrastructure
{
    public static class EntityTypeConfigurationExtensions
    {
        public static PropertyBuilder<string> HasMaxLength200(this PropertyBuilder<string> property)
        {
            return property.HasMaxLength(200);
        }

        public static PropertyBuilder<string> HasMaxLength400(this PropertyBuilder<string> property)
        {
            return property.HasMaxLength(400);
        }

        public static PropertyBuilder<string> HasMaxLength800(this PropertyBuilder<string> property)
        {
            return property.HasMaxLength(800);
        }
    }
}
