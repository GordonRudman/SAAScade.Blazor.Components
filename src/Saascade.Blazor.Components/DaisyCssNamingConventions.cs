//namespace Saascade.BlazorComponents;

//public class DaisyCssNamingConventions : ICssNamingConventions
//{ 
//    private static readonly ICssNamingConventions _defaultCssNamingConventions = new DefaultCssNamingConventions(componentNamesShouldToAddedAsCssClasses: true);

//    public IEnumerable<string> GetInitialCssClassesForComponent<T>(T component) where T : BaseComponent
//    {
//        // Use the default naming convention for maximum cmpatibility:
//        foreach (var cssClass in _defaultCssNamingConventions.GetInitialCssClassesForComponent(component))
//        {
//            yield return cssClass;
//        } 

//        // Return custom conventions
//        //var typeName = component.GetType().Name;
//        //switch (typeName)
//        //{
//        //    case nameof(Button):
//        //        yield return "btn";
//        //        yield break;

//        //    case nameof(NavigationLink):
//        //        yield return "nav-link";
//        //        yield break;
//        //}


//        //This should already be covered by the default convention
//        //yield return typeName.ToLowerSnakeCase();
//    }
//}
