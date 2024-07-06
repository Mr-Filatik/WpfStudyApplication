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
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        private Book _currentBook;
        public Book CurrentBook 
        {
            get
            {
                return _currentBook;
            }
            set 
            { 
                if (value is not null)
                {
                    _currentBook = value;

                    SetInfo();

                    buttonCreateBook.Visibility = Visibility.Collapsed;
                    buttonEditBook.Visibility = Visibility.Visible;
                    buttonDeleteBook.Visibility = Visibility.Visible;
                }
            }
        }

        public BookWindow(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            InitializeComponent();

            _bookRepository = bookRepository;
            _authorRepository = authorRepository;

            _currentBook = new Book();
            SetInfo();
            buttonCreateBook.Visibility = Visibility.Visible;
            buttonEditBook.Visibility = Visibility.Collapsed;
            buttonDeleteBook.Visibility = Visibility.Collapsed;
        }

        private void AuthorCreate(object sender, RoutedEventArgs e)
        {
            //var author = new Author()
            //{
            //    LastName = authorLastName.Text,
            //    FirstName = authorFirstName.Text,
            //    Patronymic = authorPatronymic.Text
            //};
            //var result = _authorRepository.CreateAuthor(author);
            //if (result)
            //{
            //    MessageBox.Show($"Автор успешно создан!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //else
            //{
            //    MessageBox.Show($"Автор не создан!", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
        }

        private void AuthorFindByLastName(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (!string.IsNullOrEmpty(authorFindLastName.Text))
            //    {
            //        var author = _authorRepository.GetAuthorByLastName(authorFindLastName.Text);
            //        MessageBox.Show($"{author.Id} {author.LastName} {author.FirstName} {author.Patronymic}", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    }
            //    else
            //    {
            //        var author = _authorRepository.GetAuthorByFullName(authorFindFullName.Text);
            //        MessageBox.Show($"{author.Id} {author.LastName} {author.FirstName} {author.Patronymic}", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    }
            //}
            //catch (EntityNotFoundException ex)
            //{
            //    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            //catch
            //{
            //    MessageBox.Show("Unexpected exception", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            //}
        }

        public void SetInfo()
        {
            bookId.Text = _currentBook.Id.ToString();
            bookName.Text = _currentBook.Name;
            bookDescription.Text = _currentBook.Description;
            //bookAuthor.Text = _currentBook.Author.ToString();
            //bookUser.Text = _currentBook.User.ToString();

            if (_currentBook.Author is not null)
            {
                bookAuthor.Text = $"{_currentBook.Author.LastName} {_currentBook.Author.FirstName} {_currentBook.Author.Patronymic}";
            }
            else
            {
                bookAuthor.Text = "Без автора";
            }

            if (_currentBook.User is not null)
            {
                bookUser.Text = $"Занята {_currentBook.User.LastName} {_currentBook.User.FirstName} {_currentBook.User.Patronymic}";

                textIssueBook.Visibility = Visibility.Collapsed;
                buttonIssueBook.Visibility = Visibility.Collapsed;
                buttonReturnBook.Visibility = Visibility.Visible;
            }
            else
            {
                bookUser.Text = "В наличии";

                textIssueBook.Visibility = Visibility.Visible;
                buttonIssueBook.Visibility = Visibility.Visible;
                buttonReturnBook.Visibility = Visibility.Collapsed;
            }
        }

        private void ChangeBookName(object sender, RoutedEventArgs e)
        {
            _currentBook.Name = textboxChangeName.Text;

            textboxChangeName.Text = string.Empty;
            bookName.Text = _currentBook.Name;
        }

        private void CreateBook(object sender, RoutedEventArgs e)
        {
            var result = _bookRepository.CreateBook(_currentBook);
            if (result)
            {
                MessageBox.Show("Book created", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Book not created", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchAuthorByFullName(object sender, RoutedEventArgs e)
        {
            try
            {
                var text = textboxChangeAuthor.Text;
                var author = _authorRepository.GetAuthorByFullName(text);
                var output = MessageBox.Show($"{author.LastName} {author.FirstName} {author.Patronymic}{Environment.NewLine}OK - use in search, Cancel - exit", "Message", MessageBoxButton.OKCancel, MessageBoxImage.None);
                if (output == MessageBoxResult.OK)
                {
                    _currentBook.Author = author;
                    SetInfo();
                    textboxChangeAuthor.Text = string.Empty;
                }
                if (output == MessageBoxResult.Cancel)
                {
                    //
                }
            }
            catch (EntityNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch
            {
                MessageBox.Show("Unexpected exception", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EditBook(object sender, RoutedEventArgs e)
        {
            var result = _bookRepository.EditBook(_currentBook);
            if (result)
            {
                MessageBox.Show("Book edit", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Book not edit", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DelereBook(object sender, RoutedEventArgs e)
        {
            var result = _bookRepository.DeleteBook(_currentBook);
            if (result)
            {
                MessageBox.Show("Book deleted", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Book not deleted", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
