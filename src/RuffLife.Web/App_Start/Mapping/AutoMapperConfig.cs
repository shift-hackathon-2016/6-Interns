using AutoMapper;
using RuffLife.Core.Models.Owner;
using RuffLife.Core.Models.Walker;
using RuffLife.Data.Models;
using RuffLife.Core.Models.Walk;
using RuffLife.Data.Context;
using RuffLife.Core.Models.Dog;
using RuffLife.Core.Models.ReviewForDog;

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
            Mapper.CreateMap<RuffLifeContext, RuffLifeContext>();

            Mapper.CreateMap<Owner, ViewOwnerDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ViewOwnerDto, Owner>().IgnoreUnmappedProperties();


            Mapper.CreateMap<Walker, ViewWalkerDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<Walk, ViewWalkDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<Dog, ViewDogDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ReviewForDog, ViewReviewForDogDto>().IgnoreUnmappedProperties();

            Mapper.CreateMap<UpdateWalkDto, ViewWalkDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ViewWalkDto, UpdateWalkDto>().IgnoreUnmappedProperties();
        }
    }
}