using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Gms.Common
{
    public static class LinkAreasExtensions
    {
        //[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an Extension Method which allows the user to provide a strongly-typed argument via Expression")]
        //public static MvcForm BeginFormForAreas<TController>(this HtmlHelper helper, Expression<Action<TController>> action, FormMethod method, object htmlAttributes) where TController : System.Web.Mvc.Controller
        //{
        //    TagBuilder tagBuilder = new TagBuilder("form");
        //    tagBuilder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
        //    string formAction = GetUrl(action, helper); // LinkExtensions.BuildUrlFromExpression(helper, action);
        //    tagBuilder.MergeAttribute("action", formAction);
        //    tagBuilder.MergeAttribute("method", HtmlHelper.GetFormMethodString(method));

        //    helper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
        //    return new MvcForm(helper.ViewContext);
        //}

        //[SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an Extension Method which allows the user to provide a strongly-typed argument via Expression")]
        //public static MvcForm BeginFormForAreas<TController>(this HtmlHelper helper, Expression<Action<TController>> action, FormMethod method) where TController : System.Web.Mvc.Controller
        //{
        //    return BeginFormForAreas(helper, action, method, null);
        //}


    }
}
