using System;
using System.Web.Mvc;

namespace WebIdeias.Helpers
{
    public static class IdeasHelper
    {
        public static string NavRender(this HtmlHelper helper, string selected)
        {
            const string partial = @"
            <ul id=""nav"">
                <li{0}><a href=""/Home"">início</a></li>
                <li{1}><a href=""/Idea"">driving ideas</a></li>
                <li{2}><a href=""/User"">as minhas ideias</a></li>
                <li{3}><a href=""/Category"">categorias</a></li>
                <li{4}><a href=""/Stats"">estatísticas</a></li>
            </ul>";
            var home = selected.Equals("Home") ? " class=\"selected\"" : "";
            var idea = selected.Equals("Idea") ? " class=\"selected\"" : "";
            var user = selected.Equals("User") ? " class=\"selected\"" : "";
            var category = selected.Equals("Category") ? " class=\"selected\"" : "";
            var stats = selected.Equals("Stats") ? " class=\"selected\"" : "";
            return String.Format(partial, home, idea, user, category, stats);
        }
    }
}