using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace HomeWrok.Converter
{
    class songnameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {

                if (value.ToString().Length > 5)
                {
                    value = value.ToString().Remove(5);
                    value = value + "...";
                }
            }
            catch
            { value = "unknow"; }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
    class singernameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {

                if (value.ToString().Length > 3)
                {
                    value = value.ToString().Remove(3) + "...";
                }
               
            }
            catch
            {
                value = "unknow";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
