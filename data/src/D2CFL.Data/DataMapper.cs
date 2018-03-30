using System.Linq;
using D2CFL.Data.Interfaces;
using AutoMapper.QueryableExtensions;

namespace D2CFL.Data
{
    public class DataMapper : IDataMapper
    {
        public IQueryable<TDestination> Map<TDestination>(IQueryable source)
        {
            return source.ProjectTo<TDestination>();
        }
    }
}