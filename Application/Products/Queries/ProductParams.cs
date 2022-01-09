using System;
using Application.Common.Models;

namespace Application.Products.Queries
{
    public class ProductParams : PagingParams
    {
        public Guid? CategoryId { get; set; }
        public Guid? TypeId { get; set; }
        public bool IsEnable { get; set; }
    }
}