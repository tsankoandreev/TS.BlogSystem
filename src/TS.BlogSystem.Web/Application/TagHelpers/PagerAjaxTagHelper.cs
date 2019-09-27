using System;
using System.Net;
using TS.BlogSystem.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TS.BlogSystem.Web.Application.TagHelpers
{
    [HtmlTargetElement("pager-ajax", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class PagerAjaxTagHelper : TagHelper
    {
        private readonly HttpContext _httpContext;
        private readonly IUrlHelper _urlHelper;

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public PagerAjaxTagHelper(IHttpContextAccessor accessor, IActionContextAccessor actionContextAccessor, IUrlHelperFactory urlHelperFactory)
        {
            _httpContext = accessor.HttpContext;
            _urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }

        [HtmlAttributeName("pager-ajax-model")]
        public IPagedBase Model { get; set; }

        [HtmlAttributeName("pager-ajax-update")]
        public string UpdateTarget { get; set; }

        [HtmlAttributeName("pager-ajax-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("pager-ajax-action")]
        public string Action { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Model == null || Model.ResultsCaunt <= 0 || string.IsNullOrWhiteSpace(Action) || string.IsNullOrWhiteSpace(Controller))
                return;

            string urlTemplate = WebUtility.UrlDecode(_urlHelper.Action(Action, Controller,new { page = "{0}" }));

            var startIndex = (Model.PageIndex <=3) ? 1: Model.PageIndex-3;
            var finishIndex = (Model.PageIndex <= 3) ? Math.Min(6, Model.ResultPages) : Math.Min(Model.PageIndex + 3, Model.ResultPages);

            output.TagName = "";

            var request = _httpContext.Request;
            foreach (var key in request.Query.Keys)
            {
                if (key == "page")
                {
                    continue;
                }

                urlTemplate += "&" + key + "=" + request.Query[key];
            }

            // Disable default element output
            output.SuppressOutput();

            output.Content.AppendHtml("<ul class=\"pagination\">");
            AddPageLink(output, string.Format(urlTemplate, 1), "&laquo;");

            for (var i = startIndex; i <= finishIndex; i++)
            {
                if (i == Model.PageIndex)
                {
                    AddCurrentPageLink(output, i);
                }
                else
                {
                    AddPageLink(output, string.Format(urlTemplate, i), i.ToString());
                }
            }

            AddPageLink(output, string.Format(urlTemplate, Model.ResultPages), "&raquo;");



            output.Content.AppendHtml("</ul>");
        }

        private void AddPageLink(TagHelperOutput output, string url, string text)
        {
            output.Content.AppendHtml("<li><a href data-ajax=\"true\" data-ajax-url=\"");
            output.Content.AppendHtml(url);
            output.Content.AppendHtml("\" data-ajax-update=\"");
            output.Content.AppendHtml(UpdateTarget);
            output.Content.AppendHtml("\">");
            output.Content.AppendHtml(text);
            output.Content.AppendHtml("</a>");
            output.Content.AppendHtml("</li>");
        }

        private void AddCurrentPageLink(TagHelperOutput output, int page)
        {
            output.Content.AppendHtml("<li class=\"active\">");
            output.Content.AppendHtml("<span>");
            output.Content.AppendHtml(page.ToString());
            output.Content.AppendHtml("</span>");
            output.Content.AppendHtml("</li>");
        }
    }
}
