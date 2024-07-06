using System.Globalization;
using System.Windows.Data;
using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication.Converters
{
    public class AuthorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var author = value as Author;
            if (author is null)
            {
                return "Нет автора";
            }
            return $"{author.LastName} {author.FirstName} {author.Patronymic}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
