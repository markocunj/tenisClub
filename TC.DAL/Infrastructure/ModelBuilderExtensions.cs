using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TC.DAL.Infrastrucutre
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
               /// Apply all configurtions to model builder.
               /// </summary>
               /// <param name="builder">The builder.</param>
        public static void LoadAllEntityConfigurations(this ModelBuilder builder)
        {
            var dalAssembly = Assembly.GetAssembly(typeof(ModelBuilderExtensions));
            var configurations = dalAssembly.GetTypes()
              .Where(type => type.GetInterfaces().Any(
                i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var confguration in configurations)
            {
                dynamic configurationInstance = Activator.CreateInstance(confguration);
                builder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}