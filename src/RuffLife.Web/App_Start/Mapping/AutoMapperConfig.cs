using AutoMapper;
using RuffLife.Core.Models.Owner;
using RuffLife.Core.Models.Walker;
using RuffLife.Core.Repositories;
using RuffLife.Data.Models;

namespace RuffLife.Web.Mapping
{
    public static class AutoMapperConfig
    {
        private static IMappingExpression<TSource, TDestination> IgnoreUnmappedProperties<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            var typeMap = Mapper.FindTypeMapFor<TSource, TDestination>();
            if (typeMap == null) return expression;
            foreach (var unmappedPropertyName in typeMap.GetUnmappedPropertyNames())
            {
                expression.ForMember(unmappedPropertyName, opt => opt.Ignore());
            }

            return expression;
        }
        public static void Configure()
        {
#pragma warning disable 618

            Mapper.CreateMap<Owner, ViewOwnerDto>();
            Mapper.CreateMap<Walker, ViewWalkerDto>();
        }
    }
}