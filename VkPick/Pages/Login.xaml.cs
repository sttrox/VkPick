using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkPick.Utils;

namespace VkPick.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private VkApi _api;
        private BinaryFormatter formatter = new BinaryFormatter();
        private SerializedProperty property;
        public Login()
        {
            
            _api = Api.GetInstance();
            try
            {
                using (FileStream fs = new FileStream("system.dat", FileMode.OpenOrCreate))
                {
                    property = (SerializedProperty) formatter.Deserialize(fs);
                    _api.Authorize(new ApiAuthParams() {AccessToken = property.Token});
                }
               
            }
            catch (SerializationException e)
            {
                Console.WriteLine(e);
            }

            try
            {
                if (property.Id != null)
                {
                    MessageBox.Show(_api.Account.GetAppPermissions(long.Parse(property.Id)).ToString());
                    MainWindow.GoPage(new News());
                }
            }
            catch (UserAuthorizationFailException e)
            {
                Console.WriteLine(e);
                //throw;
            }
            InitializeComponent();

        }

        private void ButtonEnter_OnClick(object sender, RoutedEventArgs e)
        {
            
            _api.Authorize(new ApiAuthParams
            {
                ApplicationId = 5943542,
                Settings = Settings.All,
                Login = BoxLogin.Text,
                Password = BoxPassword.Password,
            });

            

            using (FileStream fs = new FileStream("system.dat",FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs,new SerializedProperty(){Token = _api.Token,Id=_api.UserId.ToString()});
                //MessageBox.Show("Успех");
            }
            MainWindow.GoPage(new News());

            //MessageBox.Show(_api.Users.Get(1, ProfileFields.All, NameCase.Gen, false))

        }
    }
}
