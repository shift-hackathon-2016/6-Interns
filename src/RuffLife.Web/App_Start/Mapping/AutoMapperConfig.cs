using AutoMapper;
using RuffLife.Core.Models.Owner;
using RuffLife.Core.Models.Walker;
using RuffLife.Data.Models;
using RuffLife.Core.Models.Walk;
using RuffLife.Data.Context;
using RuffLife.Core.Models.Dog;
using RuffLife.Core.Models.ReviewForDog;
using RuffLife.Core.Models.ReviewForWalker;

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
            Mapper.CreateMap<Owner, CreateOwnerDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<CreateOwnerDto, Owner>().IgnoreUnmappedProperties();

            Mapper.CreateMap<Dog, ViewDogDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ViewDogDto, Dog>().IgnoreUnmappedProperties();
            Mapper.CreateMap<Dog, UpdateDogDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<UpdateDogDto, Dog>().IgnoreUnmappedProperties();
            Mapper.CreateMap<Dog, ViewDogDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ViewDogDto, Dog>().IgnoreUnmappedProperties();

            Mapper.CreateMap<ReviewForDog, ViewReviewForDogDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ViewReviewForDogDto, ReviewForDog>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ReviewForDog, CreateReviewForDogDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<CreateReviewForDogDto, ReviewForDog>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ReviewForDog, UpdateReviewForDogDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<UpdateReviewForDogDto, ReviewForDog>().IgnoreUnmappedProperties();

            Mapper.CreateMap<UpdateWalkDto, ViewWalkDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ViewWalkDto, UpdateWalkDto>().IgnoreUnmappedProperties();

            Mapper.CreateMap<ReviewForWalker, ViewReviewForWalkerDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ViewReviewForWalkerDto, ReviewForWalker>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ReviewForWalker, CreateReviewForWalkerDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<CreateReviewForWalkerDto, ReviewForWalker>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ReviewForWalker, UpdateReviewForWalkerDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<UpdateReviewForWalkerDto, ReviewForWalker>().IgnoreUnmappedProperties();

            Mapper.CreateMap<Walk, ViewWalkDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ViewWalkDto, Walk>().IgnoreUnmappedProperties();
            Mapper.CreateMap<Walk, CreateWalkDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<CreateWalkDto, Walk>().IgnoreUnmappedProperties();
            Mapper.CreateMap<Walk, UpdateWalkDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<UpdateWalkDto, Walk>().IgnoreUnmappedProperties();

            Mapper.CreateMap<Walker, ViewWalkerDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<ViewWalkerDto, Walker>().IgnoreUnmappedProperties();
            Mapper.CreateMap<Walker, CreateWalkerDto>().IgnoreUnmappedProperties();
            Mapper.CreateMap<CreateWalkerDto, Walker>().IgnoreUnmappedProperties();
        }
    }
}