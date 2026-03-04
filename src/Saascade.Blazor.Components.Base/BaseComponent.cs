using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;

namespace Saascade.Blazor.Components.Base;

public abstract class BaseComponent : ComponentBase
{
    [CascadingParameter(Name = "Parent")] internal virtual BaseComponent? Parent { get; set; }

    [Parameter] public virtual string Id { get; set; }
    [Parameter] public virtual string Name { get; set; }
    [Parameter] public virtual string Class { get; set; }
    [Parameter] public virtual string Tooltip { get; set; }
    [Parameter] public virtual string AriaLabel { get; set; }
    [Parameter] public virtual string AriaLabelledby { get; set; }

    protected string _initialClassesAsText = "NOT SET";

    //TODO: can't do this yet: [Inject(optional = true)] protected ICssNamingConventions? CssNamingConvention { get; set; }
    //So need to use IServiceProvider directly for now as a workaround
    [Inject] private IServiceProvider _serviceProvider { get; set; }


    protected override Task OnParametersSetAsync()
    {
        var initialClasses = GetInitialCssClasses();
        _initialClassesAsText = string.Join(' ', initialClasses.Distinct());

        Name ??= GetType().Name;
        Name = Name.ToLowerSnakeCase();

        // Tooltip = GetFullname();
        return base.OnParametersSetAsync();
    }

    private IEnumerable<string> GetInitialCssClasses()
    {
        var cssNamingConvention = _serviceProvider.GetService<ICssNamingConventions>();
        if (cssNamingConvention != null)
        {
            return cssNamingConvention.GetInitialCssClassesForComponent(this);
        }

        return Enumerable.Empty<string>();
    }

    protected string GetFinalClassNames()
    {
        return $"{_initialClassesAsText.Trim()} {Class?.Trim()} {string.Join(" ", LateClassing.GetAppendedClasses(Name, GetFullname()))}".Trim();
    }

    protected string GetFullname()
    {
        return Parent?.GetFullname() + ">" + Name;
    }
}
