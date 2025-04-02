namespace BuddyCLI.Core;

public static class StringExtensions
{
    public static bool ContainsParam(this string @string, string paramName) 
        => @string == $"-{paramName}" || @string == $"--{paramName}" || @string.Contains($"-{paramName}=");
}