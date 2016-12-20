using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication8.Models
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string altText, string height)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            builder.MergeAttribute("height", height);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        // Source http://stackoverflow.com/questions/4896439/action-image-mvc3-razor
        //public static MvcHtmlString ActionImage(this HtmlHelper html, string action, object routeValues, string imagePath, string alt)
        //{
        //    var url = new UrlHelper(html.ViewContext.RequestContext);

        //    // build the <img> tag
        //    var imgBuilder = new TagBuilder("img");
        //    imgBuilder.MergeAttribute("src", url.Content(imagePath));
        //    imgBuilder.MergeAttribute("alt", alt);
        //    string imgHtml = imgBuilder.ToString(TagRenderMode.SelfClosing);

        //    // build the <a> tag
        //    var anchorBuilder = new TagBuilder("a");
        //    anchorBuilder.MergeAttribute("href", url.Action(action, routeValues));
        //    anchorBuilder.InnerHtml = imgHtml; // include the <img> tag inside
        //    string anchorHtml = anchorBuilder.ToString(TagRenderMode.Normal);

        //    return MvcHtmlString.Create(anchorHtml);
        //}
    }
}