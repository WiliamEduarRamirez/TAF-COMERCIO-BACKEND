using System;
using Application.Common.Models;

namespace Application.Categories.Queries
{
    public class CategoryParams : PagingParams
    {
        public bool IsEnable { get; set; }
        public string Query { get; set; }
        public Guid TypeId { get; set; }
    }
}