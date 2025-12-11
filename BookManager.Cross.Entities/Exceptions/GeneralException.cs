namespace BookManager.Cross.Entities.Exceptions
{
    public class GeneralException : Exception
    {
        public string Detail { get; set; }
        public GeneralException() : base() { }
        public GeneralException(string message) : base(message) { }
        public GeneralException(string message, Exception innerException) : base(message, innerException) { }
        public GeneralException(string title, string detail) : base(title) =>
            Detail = detail;
    }
}
