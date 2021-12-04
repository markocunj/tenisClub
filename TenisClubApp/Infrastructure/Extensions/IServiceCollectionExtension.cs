using TC.DomainModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TrackableEntities.Common.Core;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF;
using URF.Core.EF.Trackable;

namespace eUpisi.Api.Infrastructure.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static T Clone<T>(this T entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            var returnValue = JsonConvert.DeserializeObject<T>(json);
            return returnValue;
        }

      
        public static void RegisterServices(this IServiceCollection services)
        {
            //var models = GetAllMarkedServices();
            //foreach (var model in models)
            //{
            //    Type serviceInterface = model.GetInterface($"I{model.Name}");
            //    if (serviceInterface != null)
            //    {
            //        services.AddScoped(serviceInterface, model);
            //    }
            //}


            //services.AddScoped<IHolidayService, HolidayService>();

        }

        public static void RegisterRepositories(this IServiceCollection services)
        {
            //services.AddScoped<IUserRepository, UserRepository>();
        }

        //private static IEnumerable<Type> GetAllMarkedServices()
        //{
        //    Assembly assembly = Assembly.GetAssembly(typeof(AdditionalProfileDocumentService));
        //    return assembly.GetTypes().Where(t => t.FullName.Contains("Service")).ToList();
        //}

        public static void RegisterTrackableRepositories(this IServiceCollection services)
        {
            IEnumerable<Type> models = GetAllModels();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<DbContext, ApplicationDbContext>();
            foreach (var model in models)
            {
                Type repositoryInterface = typeof(ITrackableRepository<>);
                repositoryInterface.MakeGenericType(model);
                Type repositoryImplementation = typeof(TrackableRepository<>);
                repositoryImplementation.MakeGenericType(model);
                services.AddScoped(repositoryInterface, repositoryImplementation);
            }
        }

        private static IEnumerable<Type> GetAllModels()
        {
            Type trackableInterface = typeof(ITrackable);
            Assembly assembly = Assembly.GetAssembly(typeof(ITrackable));
            return assembly.GetTypes().Where(t => trackableInterface.IsAssignableFrom(t)).ToList();
        }

    }
}
