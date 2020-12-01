using System;
using System.Collections.Generic;
using System.Text;
using Ardalis.Specification;
using WebTechnologyProjectCore.Entities;
using WebTechnologyProjectCore.Enums;

namespace WebTechnologyProjectCore.Specifications
{
    public class FilteredAuthorsSpecification: Specification<Author>
    {
        public FilteredAuthorsSpecification(Genre? genre)
        {
            Query.Where(author => !genre.HasValue || author.Genre == genre);
        }
    }
}
