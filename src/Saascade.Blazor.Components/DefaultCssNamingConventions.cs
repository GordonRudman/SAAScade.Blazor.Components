using Saascade.Blazor.Components.Base;

namespace Saascade.Blazor.Components;

internal class DefaultCssNamingConventions : ICssNamingConventions
{
    private bool _componentNamesShouldToAddedAsCssClasses;

    public DefaultCssNamingConventions(bool componentNamesShouldToAddedAsCssClasses = true)
    {
        _componentNamesShouldToAddedAsCssClasses = componentNamesShouldToAddedAsCssClasses;
    }

    public IEnumerable<string> GetInitialCssClassesForComponent<T>(T component) where T : BaseComponent
    {
        if (_componentNamesShouldToAddedAsCssClasses && !string.IsNullOrWhiteSpace(component.Name))
        {
            yield return component.Name.ToLowerSnakeCase();
        }

        var typeName = component.GetType().Name;
        switch (typeName)
        {
            case nameof(H1):
                yield return "h1";
                yield break;

            case nameof(H2):
                yield return "h2";
                yield break;

            case nameof(H3):
                yield return "h3";
                yield break;

            case nameof(H4):
                yield return "h4";
                yield break;

            //case nameof(H5):
            //    yield return "h5";
            //    yield break;

            //case nameof(H6):
            //    yield return "h6";
            //    yield break;

            //case nameof(Button):
            //    yield return "btn";
            //    yield break;

            //case nameof(NavigationLink):
            //    yield return "nav-link";
            //    yield break;
        }

        yield return typeName.ToLowerSnakeCase();
    }
}
