using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Gms.Common;
using Gms.Domain;

namespace Gms.Web.Mvc.Controllers
{
    public static class HtmlCommonCodeExtentions
    {
        public static MvcHtmlString DropDownListForCommonCode<T>(this HtmlHelper<T> helper, Expression<Func<T, CommonCode>> commonCodeExpression, CommonCodeType type)
        {
            return helper.DropDownListForCommonCode(commonCodeExpression, type, null);
        }

        public static MvcHtmlString DropDownListForCommonCode<T>(this HtmlHelper<T> helper, Expression<Func<T, CommonCode>> commonCodeExpression, CommonCodeType type, string optionLabel)
        {
            var val = ModelMetadata.FromLambdaExpression(commonCodeExpression, helper.ViewData);

            var selectval = val.Model;

            IList<CommonCode> selList = new List<CommonCode>();

            if (selectval != null)
            {
                selList.Add((CommonCode)selectval);
            }

            var list = helper.GetCommonCodeList(type, selList);

            return helper.SelectInternal(optionLabel, ExpressionHelper.GetExpressionText(commonCodeExpression), list, false, null);
        }

        public static MvcHtmlString DropDownListForCommonCode<T>(this HtmlHelper<T> helper, Expression<Func<T, CommonCode>> commonCodeExpression, CommonCodeType type, string name, string optionLabel)
        {
            var list = helper.GetCommonCodeList(type, null);
            return helper.SelectInternal(optionLabel, name, list, false, null);

        }

        public static MvcHtmlString CheckBoxListForCommonCode<T>(this HtmlHelper<T> helper, Expression<Func<T, IList<CommonCode>>> commonCodeExpression, CommonCodeType type)
        {
            return helper.CheckBoxListForCommonCode(commonCodeExpression, type, null);
        }

        public static MvcHtmlString CheckBoxListForCommonCode<T>(this HtmlHelper<T> helper, Expression<Func<T, IList<CommonCode>>> commonCodeExpression, CommonCodeType type, string name)
        {
            var val = ModelMetadata.FromLambdaExpression(commonCodeExpression, helper.ViewData);

            var list = helper.GetCommonCodeList(type, (IList<CommonCode>)val.Model);

            if (name == null)
            {
                name = ExpressionHelper.GetExpressionText(commonCodeExpression);
            }

            return helper.CheckBoxInternal(name, list, null);
        }

        private static IEnumerable<SelectListItem> GetCommonCodeList<T>(this HtmlHelper<T> helper, CommonCodeType type, IList<CommonCode> selectval)
        {
            IEnumerable<SelectListItem> selectList = null;

            IList<CommonCode> list = new List<CommonCode>();

            var controller = helper.ViewContext.Controller as BaseController;
            if (controller != null)
                list = controller.CommonCodeRepository.GetRoot(type);
            
            selectList = from CommonCode item in list
                         select new SelectListItem
                         {
                             Value = item.Id.ToString(),
                             Text = item.Name,
                             Selected = (selectval!=null?selectval.Contains(item):false)
                         };

            return selectList;
        }
        
        private static MvcHtmlString CheckBoxInternal(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name is Null", "name");
            }

            StringBuilder builder = new StringBuilder();
            
            foreach (SelectListItem item in selectList)
            {
                StringBuilder sb = new StringBuilder();
                TagBuilder label = new TagBuilder("label");
                label.SetInnerText(HttpUtility.HtmlEncode(item.Text));

                TagBuilder input = new TagBuilder("input");

                input.MergeAttribute("name", name);

                input.MergeAttribute("type", "checkbox");

                input.MergeAttribute("value", item.Value);

                if (item.Selected)
                {
                    input.MergeAttribute("checked", "checked");
                }
                
                sb.AppendLine(input.ToString());
                sb.AppendLine(label.ToString());

                TagBuilder builderSpan = new TagBuilder("span")
                {
                    InnerHtml = sb.ToString()
                };
                builderSpan.MergeAttributes<string, object>(htmlAttributes);

                builder.AppendLine(builderSpan.ToString());
            }
         
            return MvcHtmlString.Create(builder.ToString());
        }

    }
}