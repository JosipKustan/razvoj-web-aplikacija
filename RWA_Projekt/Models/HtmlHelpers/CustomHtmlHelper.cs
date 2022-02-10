using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RWA_Projekt.Models.HtmlHelpers
{
    public static class CustomHtmlHelper
    {
        public static MvcHtmlString DDLGradovi(this HtmlHelper html, List<Grad> gradovi,Grad selectedGrad)
        {
            //int indexSelected = 0;
            TagBuilder selectTag = new TagBuilder("select");

            selectTag.MergeAttribute("id","Grad.IDGrad");
            selectTag.MergeAttribute("name","Grad.IDGrad");
            selectTag.AddCssClass("form-control");

            foreach(Grad grad in gradovi)
            {
                TagBuilder optionTag = new TagBuilder("option");
                optionTag.MergeAttribute("value", grad.IDGrad.ToString());
                optionTag.SetInnerText(grad.Naziv);
                if (grad.Equals(selectedGrad))
                {
                    optionTag.MergeAttribute("selected", "selected");
                }
                selectTag.InnerHtml += optionTag.ToString();
            }

            return new MvcHtmlString(selectTag.ToString());
        } 
    }
}