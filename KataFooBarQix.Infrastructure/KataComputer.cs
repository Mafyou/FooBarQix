namespace KataFooBarQix.Infrastructure;

public class KataComputer : IComputer
{
    private StringBuilder _stringBuilder = new();
    private int _number = 0;
    private readonly Dictionary<int, string> mapping = new()
        {
            { 3, "Foo" },
            { 5, "Bar" },
            { 7, "Qix" },
            { 0, "*" }
        };
    public string Compute(string rawInput)
    {
        _number = int.Parse(rawInput);
        var isFooBarQix = false;
        foreach (var currentCouple in mapping
                                            .Where(x => x.Key != 0 &&
                                                    _number % x.Key == 0))
        {
            _stringBuilder.Append(currentCouple.Value);
            isFooBarQix = true;
        }
        if (!isFooBarQix)
        {
            return rawInput.Replace("0", "*");
        }
        foreach (char character in rawInput)
        {
            var tmpNb = char.GetNumericValue(character);
            if (mapping.Any(x => x.Key == tmpNb))
            {
                _stringBuilder.Append(mapping.First(x => x.Key == tmpNb).Value);
            }
        }
        return _stringBuilder.ToString();
    }
}