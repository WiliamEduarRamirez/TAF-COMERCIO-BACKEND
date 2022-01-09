using System;
using Application.Common.Models;

namespace Application.Types.Queries
{
    public class TypeParams : PagingParams
    {
        public bool IsEnable { get; set; }
        public string Query { get; set; }
    }
}