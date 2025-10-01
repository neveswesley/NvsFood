namespace NvsFood.Exceptions.ExceptionBase;

public class ErrorOnValidationException : NvsFoodException
{
    public IList<string> ErrorMessages { get; set; }

    public ErrorOnValidationException(IList<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}