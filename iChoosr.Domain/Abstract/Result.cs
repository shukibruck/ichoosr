using System.Diagnostics.CodeAnalysis;

namespace iChoosr.Domain.Abstract
{
    public class Result
    {
        protected Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
                throw new InvalidOperationException(nameof(isSuccess));

            if (!isSuccess && error == Error.None)
                throw new InvalidOperationException(nameof(error));

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        public static Result Success()
        {
            return new Result(true, Error.None);
        }

        public static Result Failure(Error error)
        {
            return new Result(false, error);
        }

        public static Result<TValue> Success<TValue>(TValue value)
        {
            return new Result<TValue>(value, true, Error.None);
        }

        public static Result<TValue> Failure<TValue>(Error error)
        {
            return new Result<TValue>(default, false, error);
        }

        public static Result<TValue> Create<TValue>(TValue? value)
        {
            return value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
        }
    }

    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        public Result(TValue? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        [NotNull]
        public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

        public static implicit operator Result<TValue>(TValue? value)
        {
            return Create(value);
        }
    }

    public record Error(string Code, string Name)
    {
        public static Error None => new(string.Empty, string.Empty);
        public static Error NullValue => new("Error.NullValue", "Null value was provided");
    }

}