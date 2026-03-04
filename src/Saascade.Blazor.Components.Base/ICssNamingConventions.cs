namespace Saascade.Blazor.Components.Base;

public interface ICssNamingConventions
{
    IEnumerable<string> GetInitialCssClassesForComponent<T>(T component) where T : BaseComponent;
}
