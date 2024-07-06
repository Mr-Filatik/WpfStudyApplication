using Microsoft.Extensions.DependencyInjection;
using Other;
using System.Windows;
using WpfStudyApplication.Database.Abstract;
using WpfStudyApplication.Database.Exceptions;

namespace WpfStudyApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUserRepository _userRepository;
        private readonly ILibrarianRepository _librarianRepository;

        public MainWindow(IUserRepository userRepository, ILibrarianRepository librarianRepository)
        {
            InitializeComponent();

            emailBox.Text = "filatov@gmail.com";
            passwordBox.Text = "123456";

            _userRepository = userRepository;
            _librarianRepository = librarianRepository;
        }

        private void LoginInApplication(object sender, RoutedEventArgs e)
        {
            try
            {
                var librarian = _librarianRepository.LoginLibrarianByEmailAndPassword(emailBox.Text, passwordBox.Text);
                //save
                //MessageBox.Show("OK", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                var window = ((App)App.Current).ServiceProvider.GetService<WorkWindow>();
                window.Show();
                //window.Owner = this;
                this.Close();
            }
            catch (EntityNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (PasswordNotCorrectException ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch
            {
                MessageBox.Show("Unexpected exception", "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}