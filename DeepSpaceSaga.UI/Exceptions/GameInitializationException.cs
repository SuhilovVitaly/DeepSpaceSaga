namespace DeepSpaceSaga.UI.Exceptions;

public class GameInitializationException : Exception
{
    public GameInitializationException(string message) : base(message) { }
    public GameInitializationException(string message, Exception inner) : base(message, inner) { }
}
