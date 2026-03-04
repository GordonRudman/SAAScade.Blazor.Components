namespace Saascade.Blazor.Components.Base;

public static class LateClassing
{


    public static void AddElementMapping(string from, string to)
    {
        elementMappings.Add(new Mapping { From = from, To = to });
    }
    public static void AddFullnameMapping(string from, string to)
    {
        fullnameMappings.Add(new Mapping { From = from, To = to });
    }

    public static void AddMapping(string from, string to)
    {
        var numberOfPeriods = from.Count(c => c == '>');

        switch (numberOfPeriods)
        {
            case 0:
                throw new ArgumentOutOfRangeException(nameof(from), "Names must have '>' in them");
            case 1:
                AddElementMapping(from[1..], to);
                break;
            default:
                AddFullnameMapping(from, to);
                break;
        }
    }

    public static IEnumerable<string> GetAppendedClasses(string name, string fullname)
    {
        if (!string.IsNullOrWhiteSpace(fullname))
        {
            foreach (var mapping in fullnameMappings.Where(m => m.From.Equals(fullname, StringComparison.OrdinalIgnoreCase)))
            {
                yield return mapping.To;
            }
        }

        if (!string.IsNullOrWhiteSpace(name))
        {
            foreach (var mapping in elementMappings.Where(m => m.From.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                yield return mapping.To;
            }
        }
    }

    private class Mapping
    {
        public string From { get; set; }
        public string To { get; set; }
    }

    private static readonly IList<Mapping> elementMappings = new List<Mapping>();
    private static readonly IList<Mapping> fullnameMappings = new List<Mapping>();

}
