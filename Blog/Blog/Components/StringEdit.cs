using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Components
{
    public static class StringEdit
    {
        public static string RemoveExtraSpase (string text)
        {
            if (text != null)
            {
                text.Trim();
                while (text.Contains("  "))
                {
                    text = text.Replace("  ", " ");
                }
                return text;
            }
            return "";
        }
    }
}
