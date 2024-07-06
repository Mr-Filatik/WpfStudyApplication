using System.Globalization;
using System.Windows.Data;
using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Converters
{
    public class UserConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var user = value as User;
            if (user is null)
            {
                return "В наличии";
            }
            return $"Не в наличии";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
