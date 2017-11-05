using System.Collections.Generic;

namespace AutoRespect.Shared.Errors.Design
{
    public class R<T>
    {
        public List<Error> Failures { get; private set; } = new List<Error>();
        public T Value { get; private set; }
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;

        private R() { }

        private R(List<Error> errors)
        {
            IsSuccess = false;
            Failures = errors;
        }

        private R(Error error)
        {
            IsSuccess = false;
            Failures.Add(error);
        }

        private R(T value)
        {
            IsSuccess = true;
            Value = value;
        }

        public static implicit operator R<T>(List<Error> errors) => new R<T>(errors);
        public static implicit operator R<T>(Error error) => new R<T>(error);
        public static implicit operator R<T>(T value) => new R<T>(value);
    }
}
