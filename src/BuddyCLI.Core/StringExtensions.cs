namespace BuddyCLI.Core;

public static class StringExtensions
{
    public static bool ContainsParam(this string @string, string paramName) 
        => @string == $"-{paramName}" || @string == $"--{paramName}" || @string.Contains($"-{paramName}=");
    
    public static string FilterOutNone(this string @string)
        => string.Equals(@string, "none", StringComparison.OrdinalIgnoreCase) ? string.Empty : @string;
}