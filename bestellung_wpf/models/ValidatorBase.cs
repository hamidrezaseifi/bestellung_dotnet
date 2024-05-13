using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.models
{
    public class ValidatorBase
    {
        
        protected static bool IsValueValid(string value)
        {
            if (value == null || value.Trim() == "" || value == ArticleItem.DefaultValue)
            {
                return false;
            }

            return true;
        }
    }
}
