using Microsoft.Extensions.DependencyInjection;
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
using WpfStudyApplication.Database.Repository;

namespace WpfStudyApplication
{
    /// <summary>
    /// Interaction logic for WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public Book SelectedBook { get; set; }
        public Author SelectedAuthor { get; set; }

        public WorkWindow(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            InitializeComponent();

            _authorRepository = authorRepository;
            _bookRepository = bookRepository;

            var authors = new Author[]
            {
                new Author() { Id = 1, LastName = "LastName1", FirstName = "FirstName1", Patronymic = "Patronymic1"},
                new Author() { Id = 2, LastName = "LastName2", FirstName = "FirstName2", Patronymic = "Patronymic2"}
            };
            bookList.ItemsSource = new List<Book>()
            {
                new Book() { Id = 1, Name = "Name 1", Description = "Description 1", AuthorId = 1, Author = authors[0] },
                new Book() { Id = 2, Name = "Name 2", Description = "Description 2", AuthorId = 2, Author = authors[1] },
                new Book() { Id = 3, Name = "Name 3", Description = "Description 3" }
            };
        }

        private void SearchByBookName(object sender, RoutedEventArgs e)
        {

        }

        private void SearchByAuthor(object sender, RoutedEventArgs e)
        {
            if (SelectedAuthor is not null)
            {
                var books = _bookRepository.GetBooksByAuthor(SelectedAuthor);
                bookList.ItemsSource = books.books;
            }
        }

        private void SearchByUser(object sender, RoutedEventArgs e)
        {

        }

        private void FirstPage(object sender, RoutedEventArgs e)
        {

        }

        private void PreviousPage(object sender, RoutedEventArgs e)
        {

        }

        private void NextPage(object sender, RoutedEventArgs e)
        {

        }

        private void LastPage(object sender, RoutedEventArgs e)
        {

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            bookList.ItemsSource = null;
            bookAuthor.Text = string.Empty;
            bookName.Text = string.Empty;
            bookUser.Text = string.Empty;
            authorLastName.Text = string.Empty;
            authorFullName.Text = string.Empty;
            userEmail.Text = string.Empty;
            userFullName.Text = string.Empty;
            userLastName.Text = string.Empty;
            SelectedAuthor = null;
        }

        private void BookSelected(object sender, SelectionChangedEventArgs e)
        {
            var book = (Book)bookList.SelectedItem;
            if (book is not null)
            {
                SelectedBook = book;
                //MessageBox.Show($"{book.Name}", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
                var window = ((App)App.Current).ServiceProvider.GetService<BookWindow>();
                window.CurrentBook = book;
                window.Show();
                window.Owner = this;
            }
        }

        private void SearchAuthorByLastName(object sender, RoutedEventArgs e)
        {
            try
            {
                var text = authorLastName.Text;
                var author = _authorRepository.GetAuthorByLastName(text);
                var output = MessageBox.Show($"{author.LastName} {author.FirstName} {author.Patronymic}{Environment.NewLine}OK - use in search, Cancel - exit", "Message", MessageBoxButton.OKCancel, MessageBoxImage.None);
                if (output == MessageBoxResult.OK)
                {
                    SelectedAuthor = author;
                    bookAuthor.Text = $"{author.LastName} {author.FirstName} {author.Patronymic}";
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

        private void SearchAuthorByFullName(object sender, RoutedEventArgs e)
        {
            try
            {
                var text = authorFullName.Text;
                var author = _authorRepository.GetAuthorByFullName(text);
                var output = MessageBox.Show($"{author.LastName} {author.FirstName} {author.Patronymic}{Environment.NewLine}OK - use in search, Cancel - exit", "Message", MessageBoxButton.OKCancel, MessageBoxImage.None);
                if (output == MessageBoxResult.OK)
                {
                    SelectedAuthor = author;
                    bookAuthor.Text = $"{author.LastName} {author.FirstName} {author.Patronymic}";
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

        private void CreateNewBook(object sender, RoutedEventArgs e)
        {
            var window = ((App)App.Current).ServiceProvider.GetService<BookWindow>();
            window.Show();
            window.Owner = this;
        }
    }
}
