namespace BuddyCLI.Core.Displays;

public interface IDisplayManager
{
    public IDisplayManager AddMessage(string message);
    public IDisplayManager PadLeft(int characters);
    public IDisplayManager PadRight(int characters);
    public IDisplayManager SetColor(ConsoleColor color);
    
    public IDisplayManager Send();
    public IDisplayManager SendNewLine();
}