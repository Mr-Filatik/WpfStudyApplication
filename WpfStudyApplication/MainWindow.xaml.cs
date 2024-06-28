using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfStudyApplication.Database;
using WpfStudyApplication.Database.Abstract;
using WpfStudyApplication.Database.Enities;

namespace WpfStudyApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyDbContext _context;
        private IUserRepository _userRepository;

        public MainWindow(MyDbContext context, IUserRepository userRepository)
        {
            InitializeComponent();

            _context = context;
            _userRepository = userRepository;
        }

        private void PressStartApplication(object sender, RoutedEventArgs e)
        {
            //startButton
            Button button = sender as Button;
            if (button != null)
            {
                //DataTable dataTable = new DataTable();
                //var res = dataTable.Compute("(5+5*(4-1.5))/2", "");
                //if (res != null)
                //{
                //    MessageBox.Show(res.ToString());
                //}
                //button.Content = "HELLO";

                var result = MessageBox.Show("Вы программируете больше года?", "Опрос", MessageBoxButton.YesNoCancel, MessageBoxImage.Information);
                switch (result)
                {
                    case MessageBoxResult.None:
                        MessageBox.Show("MessageBoxResult.None");
                        break;
                    case MessageBoxResult.OK:
                        MessageBox.Show("MessageBoxResult.OK");
                        break;
                    case MessageBoxResult.Cancel:
                        MessageBox.Show("MessageBoxResult.Cancel");
                        break;
                    case MessageBoxResult.Yes:
                        MessageBox.Show("MessageBoxResult.Yes");
                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show("MessageBoxResult.No");
                        break;
                    default:
                        break;
                }

                //Button button1 = new Button();
                //button1.Width = 200;
                //button1.Height = 200;
                //button1.VerticalAlignment = VerticalAlignment.Bottom;
                //button1.HorizontalAlignment = HorizontalAlignment.Center;
                //mainGrid.Children.Add(button1);
            }
        }

        private void CreateUser(object sender, RoutedEventArgs e)
        {
            User user = new User()
            {
                Name = nameBox.Text,
                Password = passwordBox.Text,
                Email = emailBox.Text,
                BirthDay = DateTime.UtcNow
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private void FindUser(object sender, RoutedEventArgs e)
        {
            var user = _userRepository.GetUserById(int.Parse(idBox.Text));
            if (user is not null)
            {
                MessageBox.Show($"User: Id ({user.Id}), Name ({user.Name}), Email ({user.Email})");
            }
            else
            {
                MessageBox.Show($"User not found!", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //user.Email += ".com";

            _context.SaveChanges();
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            _context.Users.Remove(new User() { Id = int.Parse(idDelBox.Text) });
            _context.SaveChanges();
        }
    }
}