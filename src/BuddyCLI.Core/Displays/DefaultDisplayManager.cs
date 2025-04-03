namespace BuddyCLI.Core.Displays;

public class DefaultDisplayManager: IDisplayManager
{
    private string _message = string.Empty;
    private int _pad = 0;
    private bool _padLeft = false;
    private ConsoleColor _color = ConsoleColor.White;

    public IDisplayManager AddMessage(string message)
    {
        _message = message;
        return this;
    }
    
    public IDisplayManager PadLeft(int characters)
    {
        _pad = characters;
        _padLeft = true;
        return this;
    }
    
    public IDisplayManager PadRight(int characters)
    {
        _pad = characters;
        _padLeft = false;
        return this;
    }
    
    public IDisplayManager SetColor(ConsoleColor color)
    {
        _color = color;
        return this;
    }

    public IDisplayManager Send()
    {
        var current = Console.ForegroundColor;
        Console.ForegroundColor = _color;
        var missing = _pad - _message.Length;
        if (missing < 0) missing = 0;
        string msg =  _padLeft 
            ? string.Join("", Enumerable.Repeat(' ', missing)) + _message 
            : _message + string.Join("", Enumerable.Repeat(' ', missing));
        Console.Write(msg);
        Console.ForegroundColor = current;
        
        _message = string.Empty;
        _pad = 0;
        _padLeft = false;
        _color = ConsoleColor.White;
        return this;
    }
    
    public IDisplayManager SendNewLine()
    {
        Console.WriteLine();
        return this;
    }
}