using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfStudyApplication.Database.Abstract;
using WpfStudyApplication.Database.Enities;
using WpfStudyApplication.Database.Exceptions;

namespace WpfStudyApplication
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public TestWindow(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            InitializeComponent();

            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        private void AuthorCreate(object sender, RoutedEventArgs e)
        {
            var author = new Author()
            {
                LastName = authorLastName.Text,
                FirstName = authorFirstName.Text,
                Patronymic = authorPatronymic.Text
            };
            var result = _authorRepository.CreateAuthor(author);
            if (result)
            {
                MessageBox.Show($"Автор успешно создан!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show($"Автор не создан!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void AuthorFindByLastName(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(authorFindLastName.Text))
                {
                    var author = _authorRepository.GetAuthorByLastName(authorFindLastName.Text);
                    MessageBox.Show($"{author.Id} {author.LastName} {author.FirstName} {author.Patronymic}", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    var author = _authorRepository.GetAuthorByFullName(authorFindFullName.Text);
                    MessageBox.Show($"{author.Id} {author.LastName} {author.FirstName} {author.Patronymic}", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (EntityNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch
            {
                MessageBox.Show("Unexpected exception", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
