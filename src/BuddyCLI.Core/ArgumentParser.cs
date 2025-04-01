namespace BuddyCLI.Core;

public class ArgumentParser
{
    private readonly List<KeyValuePair<string, string>> _params;
    private readonly List<string> _arguments = [];
    private readonly string[] _args;

    public ArgumentParser(string[] args)
    {
        _args = args;
        List<int> paramIndexes = args.Select((x, i) => (x, i)).Skip(2)
            .Where(x => x.Item1.StartsWith('-') || x.Item1.StartsWith("--"))
            .Select(x => x.Item2)
            .ToList();
        
        int firstArgumentIndex = 2;
        if(paramIndexes.Count > 0)
        {
            var lastParam = args[paramIndexes.Last()];
            if(lastParam.Contains('=') || lastParam == "--") firstArgumentIndex = paramIndexes[^1] + 1;
            else firstArgumentIndex = paramIndexes[^1] + 2;
        }
        if(firstArgumentIndex < _args.Length) _arguments = _args.Skip(firstArgumentIndex).ToList();
        
        _params = new List<KeyValuePair<string, string>>();
        foreach (int paramIndex in paramIndexes)
        {
            var param = args[paramIndex];
            if(param == "--") continue;
            if(param.Contains('='))
            {
                _params.Add(new KeyValuePair<string, string>(param.Split("=")[0], param.Split("=")[1]));
                continue;
            }
            if(paramIndex + 1 == _args.Length)
            {
                _params.Add(new KeyValuePair<string, string>(param, ""));
                continue;
            }
            var nextParam = args[paramIndex+1];
            if(nextParam.StartsWith('-'))
            {
                _params.Add(new KeyValuePair<string, string>(param, ""));
                continue;
            }
            _params.Add(new KeyValuePair<string, string>(param, nextParam));
        }
        
    }
    
    public string Resource => _args.FirstOrDefault() ?? string.Empty;
    
    public string Command => _args.Skip(1).FirstOrDefault() ?? string.Empty;

    public List<KeyValuePair<string, string>> Params => _params;

    public List<string> Arguments => _arguments;
}