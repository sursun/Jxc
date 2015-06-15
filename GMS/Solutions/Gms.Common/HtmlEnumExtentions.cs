using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace Gms.Common
{
    public static class HtmlEnumExtentions
    {

        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {

            return DropDownListFor(htmlHelper, expression, null);
        }

        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string optionLabel)
        {
            return DropDownListFor(htmlHelper, expression, optionLabel, null);
        }

        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string optionLabel, IDictionary<string, object> htmlAttributes)
        {


            return htmlHelper.DropDownListForEnum(expression, optionLabel, htmlAttributes);

        }

        public static MvcHtmlString DropDownList<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string name, string optionLabel, object htmlAttributes)
        {
            return htmlHelper.DropDownListForEnum<TProperty>(name, optionLabel, htmlAttributes);
        }

        public static MvcHtmlString DropDownListForEnum<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string optionLabel, object htmlAttributes)
        {
            //IEnumerable<SelectListItem> selectList = null;
            //var val = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            //var selectval = val.Model;
            //selectList = GetEnumList<TProperty>(selectval);
            //IDictionary<string, object> atts;
            //if (htmlAttributes is IDictionary<string, object>)
            //{
            //    atts = htmlAttributes as IDictionary<string, object>;
            //}
            //else
            //{
            //    atts = new RouteValueDictionary(htmlAttributes);
            //}
            //return htmlHelper.SelectInternal(optionLabel, ExpressionHelper.GetExpressionText(expression), selectList, false, atts);
            return htmlHelper.DropDownListForEnum(expression,ExpressionHelper.GetExpressionText(expression), optionLabel, htmlAttributes);
        }

        public static MvcHtmlString DropDownListForEnum<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, string name,string optionLabel, object htmlAttributes)
        {
            IEnumerable<SelectListItem> selectList = null;
            var val = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var selectval = val.Model;
            selectList = GetEnumList<TProperty>(selectval);
            IDictionary<string, object> atts;
            if (htmlAttributes is IDictionary<string, object>)
            {
                atts = htmlAttributes as IDictionary<string, object>;
            }
            else
            {
                atts = new RouteValueDictionary(htmlAttributes);
            }
            return htmlHelper.SelectInternal(optionLabel, name, selectList, false, atts);
            //return htmlHelper.DropDownListForEnum<TProperty>(ExpressionHelper.GetExpressionText(expression), optionLabel, htmlAttributes);
        }

        private static IEnumerable<SelectListItem> GetEnumList<TProperty>(object selectval)
        {
            IEnumerable<SelectListItem> selectList = null;
            var tp = typeof(TProperty).GetRealType();
            if (tp.IsEnum)
            {

                selectList = from TProperty e in Enum.GetValues(tp)
                             select new SelectListItem
                             {
                                 Value = Enum.Format(tp, e, "d"),
                                 Text = e.ToString(),
                                 Selected = (e.Equals(selectval))
                             };

                //selectList = new SelectList(values, "Value", "Text", Enum.Format(val.ModelType, val.Model, "d"));
            }
            return selectList;
        }


        public static MvcHtmlString DropDownListForEnum<TProperty>(this HtmlHelper htmlHelper, string name, string optionLabel, object htmlAttributes)
        {
            return htmlHelper.DropDownListForEnum<TProperty>(name, optionLabel, false, htmlAttributes);
        }
        public static MvcHtmlString DropDownListForEnum<TProperty>(this HtmlHelper htmlHelper, string name, string optionLabel, bool allowMultiple, object htmlAttributes)
        {
            IEnumerable<SelectListItem> selectList = GetEnumList<TProperty>(null);


            IDictionary<string, object> atts;
            if (htmlAttributes is IDictionary<string, object>)
            {
                atts = htmlAttributes as IDictionary<string, object>;
            }
            else
            {
                atts = new RouteValueDictionary(htmlAttributes);
            }
            return htmlHelper.SelectInternal(optionLabel, name, selectList, allowMultiple, atts);
        }
        public static IDictionary<int, string> ToDictionary(this Enum enumType)
        {
            return (from Enum e in Enum.GetValues(enumType.GetType())
                    select new
                    {
                        Key = Int32.Parse(Enum.Format(enumType.GetType(), e, "d")),
                        Value = e.ToString()
                    }).ToDictionary(k => k.Key, v => v.Value);
        }


        internal static string ListItemToOption(SelectListItem item)
        {
            TagBuilder builder = new TagBuilder("option")
            {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null)
            {
                builder.Attributes["value"] = item.Value;
            }
            if (item.Selected)
            {
                builder.Attributes["selected"] = "selected";
            }
            return builder.ToString(TagRenderMode.Normal);
        }
        
        public static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple, IDictionary<string, object> htmlAttributes)
        {
            ModelState state;
            name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name is Null", "name");
            }

            StringBuilder builder = new StringBuilder();
            if (optionLabel != null)
            {
                builder.AppendLine(ListItemToOption(new SelectListItem { Text = optionLabel, Value = string.Empty, Selected = false }));
            }
            foreach (SelectListItem item3 in selectList)
            {
                builder.AppendLine(ListItemToOption(item3));
            }
            TagBuilder builder2 = new TagBuilder("select")
            {
                InnerHtml = builder.ToString()
            };
            builder2.MergeAttributes<string, object>(htmlAttributes);
            builder2.MergeAttribute("name", name, true);
            builder2.GenerateId(name);
            if (allowMultiple)
            {
                builder2.MergeAttribute("multiple", "multiple");
            }
            if (htmlHelper.ViewData.ModelState.TryGetValue(name, out state) && (state.Errors.Count > 0))
            {
                builder2.AddCssClass(HtmlHelper.ValidationInputCssClassName);
            }

            return MvcHtmlString.Create(builder2.ToString(TagRenderMode.Normal));

        }


        /// <summary>
        /// 复选按钮组
        /// </summary>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="name"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        //public static MvcHtmlString RadioButtonListForEnum<TProperty>(this HtmlHelper htmlHelper, string name, object htmlAttributes)
        //{
        //    return htmlHelper.RadioBoxListForEnum<TProperty>(name, htmlAttributes);
        //}


    }
}
