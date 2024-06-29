namespace WpfStudyApplication.Database.Exceptions
{
    public class PasswordNotCorrectException : Exception
    {
        public PasswordNotCorrectException(string message) : base(message) { }
    }
}
