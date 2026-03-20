using DevExpress.ExpressApp.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MINI_CRM_SAMIR_NAKRANI.Module.BusinessObjects
{
    public static class EnumExtensions
    {
        public static string ToCaption(this Enum value)
        {
            return CaptionHelper.GetDisplayText(value);
        }
    }
}
