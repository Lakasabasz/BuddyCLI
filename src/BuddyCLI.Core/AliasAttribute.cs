using System.Reflection;

namespace BuddyCLI.Core;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class AliasAttribute(string name) : Attribute
{
    public string Name { get; set; } = name;
}

public static class EnumExtensions
{
    public static List<string> GetAliases<T>(this T enumValue) where T : Enum
    {
        // Pobranie pola typu Enum
        MemberInfo[] memberInfo = typeof(T).GetMember(enumValue.ToString());
        
        if (memberInfo.Length == 0)
            return new List<string>();

        // Pobranie wszystkich atrybutów Alias dla pola
        var attributes = memberInfo[0].GetCustomAttributes<AliasAttribute>(false);
        
        // Zwrócenie listy nazw aliasów
        return attributes.Select(a => a.Name).ToList();
    }

    // Metoda wyszukująca wartość enum na podstawie aliasu
    public static T GetValueFromAlias<T>(string alias) where T : Enum
    {
        var type = typeof(T);
        
        foreach (var field in type.GetFields())
        {
            if (field.GetCustomAttributes<AliasAttribute>(false)
                .Any(attr => string.Equals(attr.Name, alias, StringComparison.OrdinalIgnoreCase)))
            {
                return (T)field.GetValue(null)!;
            }
        }
        
        throw new ArgumentException($"No enum value found with alias '{alias}'", nameof(alias));
    }

    public static T ParseValueIncludingAliases<T>(this string value) where T : Enum => 
        (TryParseValueIncludingAliases(value, out T? result) ? result : throw new ArgumentException($"No enum value found with alias '{value}'", nameof(value)))!;
    
    public static bool TryParseValueIncludingAliases<T>(this string value, out T? parsed) where T : Enum
    {
        parsed = GetAllAliases<T>().FirstOrDefault(x => 
            x.Value.Any(alias => string.Equals(alias, value, StringComparison.OrdinalIgnoreCase)) 
            || string.Equals(x.Key.ToString(), value, StringComparison.OrdinalIgnoreCase)).Key;
        return parsed is not null;
    }
    
    // Metoda zwracająca słownik wszystkich wartości enum i ich aliasów
    public static Dictionary<T, List<string>> GetAllAliases<T>() where T : Enum
    {
        var result = new Dictionary<T, List<string>>();
        
        foreach (T value in Enum.GetValues(typeof(T)))
        {
            result[value] = value.GetAliases();
        }
        
        return result;
    }
    
    public static string ToStringList(this IEnumerable<string> aliases)
    {
        var list = aliases.ToList();
        return list.Any(x => !string.IsNullOrEmpty(x)) ? $"(aliases: {string.Join(", ", list)})" : string.Empty;
    }
}