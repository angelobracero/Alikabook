using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alikabook.Utility
{
    public static class SD
    {
        public static string TruncateTitle(this string title, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(title) || title.Length <= maxLength)
            {
                return title;
            }

            var truncatedTitle = title.Substring(0, maxLength);

            int lastSpaceIndex = truncatedTitle.LastIndexOf(' ');
            if (lastSpaceIndex > 0)
            {
                truncatedTitle = truncatedTitle.Substring(0, lastSpaceIndex);
            }

            return truncatedTitle + "...";
        }
    }
}
