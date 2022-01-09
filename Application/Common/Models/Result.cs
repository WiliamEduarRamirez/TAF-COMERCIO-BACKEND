using System;

namespace Application.Common.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public bool IsNotFound { get; set; }
        public T Value { get; set; }
        public Object Error { get; set; }

        public static Result<T> Success(T value) => new Result<T> {IsSuccess = true, Value = value};

        public static Result<T> Failure(string error) =>
            new Result<T> {IsSuccess = false, Error = new {message = error}};

        public static Result<T> NotFound(string error) =>
            new Result<T> {IsNotFound = true, Error = new {message = error}};
    }
}