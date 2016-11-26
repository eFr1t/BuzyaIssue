using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace EPAM.WebClient.Controllers
{
    public class ControllersLibrary
    {
        public static string LogInPage = "/LogIn/Index";

        public static string RenderPartialToString(string viewName, ControllerContext context, ViewDataDictionary viewData, TempDataDictionary tempData)
        {
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                var viewContext = new ViewContext(context, viewResult.View, viewData, tempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(context, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}