namespace s20522_SejmAPI.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message) { }
}