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

            _userRepository = userRepository;
            _librarianRepository = librarianRepository;
        }

        private void LoginInApplication(object sender, RoutedEventArgs e)
        {
            CustomList<int> list = new CustomList<int>();

            MessageBox.Show($"Lenght: {list.Lenght}, Capacity: {list.Capacity}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            list.Add(1);
            MessageBox.Show($"Lenght: {list.Lenght}, Capacity: {list.Capacity}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            //Show(list);

            list.AddRange(new int[] { 1, 2 });
            MessageBox.Show($"Lenght: {list.Lenght}, Capacity: {list.Capacity}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            //Show(list);

            list.Insert(1, 22);
            MessageBox.Show($"Lenght: {list.Lenght}, Capacity: {list.Capacity}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            list.AddRange(new int[] { 1, 2, 3, 4 });
            MessageBox.Show($"Lenght: {list.Lenght}, Capacity: {list.Capacity}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

            list.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 });
            MessageBox.Show($"Lenght: {list.Lenght}, Capacity: {list.Capacity}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            //Show(list);

            list.Remove(22);
            MessageBox.Show($"Lenght: {list.Lenght}, Capacity: {list.Capacity}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            //Show(list);

            list.RemoveAt(2);
            MessageBox.Show($"Lenght: {list.Lenght}, Capacity: {list.Capacity}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            //Show(list);

            list.Add(19);
            MessageBox.Show($"Lenght: {list.Lenght}, Capacity: {list.Capacity}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            //Show(list);

            //try
            //{
            //    var librarian = _librarianRepository.LoginLibrarianByEmailAndPassword(emailBox.Text, passwordBox.Text);
            //    //save
            //    MessageBox.Show("OK", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            //}
            //catch (EntityNotFoundException ex)
            //{
            //    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            //catch (PasswordNotCorrectException ex)
            //{
            //    MessageBox.Show(ex.Message, "Message", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}

            void Show<T>(IEnumerable<T> values)
            {
                string str = "";
                foreach (T value in values)
                {
                    str += $"{value}, ";
                }
                MessageBox.Show($"{str}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}