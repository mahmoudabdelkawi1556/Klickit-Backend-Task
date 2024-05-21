using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Specification.Base
{
    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQueryWithSpec(IQueryable<T> querystart, ISpecification<T> spec)
        {
            var query = querystart;
            if (spec.Criterias.Any()) query = spec.Criterias.Aggregate(query, (currentQuery, Criteria) => currentQuery.Where(Criteria));
            query = spec.Includes.Aggregate(query, (currentQuery, Include) => currentQuery.Include(Include));
            if (spec.OrderByAsc is not null) query = query.OrderBy(spec.OrderByAsc);
            if (spec.OrderByDesc is not null) query = query.OrderByDescending(spec.OrderByDesc);
            if (spec.IsPaginationEnabled) query = query.Skip(spec.Skip).Take(spec.Take);
            return query;
        }
    }
}
