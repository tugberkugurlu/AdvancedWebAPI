using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_PerRouteMHOwnershipSample.Models.Core {

    public static class IQueryableExtensions {

        public static PaginatedList<T> ToPaginatedList<T>(
            this IQueryable<T> query,
            int pageIndex,
            int pageSize) {

            var baseQuery = query;
            query = query.Skip(
                (pageIndex - 1) * pageSize).Take(pageSize);

            var totalCount = baseQuery.Count();
            return new PaginatedList<T>(
                pageIndex, pageSize, totalCount, query);
        }
    }
}