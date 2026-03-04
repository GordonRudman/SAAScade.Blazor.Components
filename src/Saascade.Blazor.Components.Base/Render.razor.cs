using Microsoft.AspNetCore.Components;

namespace Saascade.Blazor.Components.Base;

public partial class Render : ComponentBase
{
    [Parameter] public bool When { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }
}