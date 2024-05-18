using bestellung_wpf.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bestellung_wpf.models
{
    public interface IArticleItem
    {
        string getName();
        string getManufacturer();
        string getArticleNumber();
        string getPurchaseSource();
        double getPrice();
        BestellungStatus getStatus();
    }

    public class ArticleItemValidator : ValidatorBase
    {
        public static bool IsValid(IArticleItem articleItem)
        {
            if (!IsValueValid(articleItem.getName()))
            {
                return false;
            }

            if (!IsValueValid(articleItem.getManufacturer()))
            {
                return false;
            }

            if (!IsValueValid(articleItem.getArticleNumber()))
            {
                return false;
            }

            if (!IsValueValid(articleItem.getPurchaseSource()))
            {
                return false;
            }

            return true;
        }

    }

}
