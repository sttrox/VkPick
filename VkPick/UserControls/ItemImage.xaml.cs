using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VkPick.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ItemImage.xaml
    /// </summary>
    public partial class ItemImage : UserControl
    {
        public ItemImage(ImageSource imageSource, string firstName, ImageSource avatarSource, DateTime? date)
        {
            _imageSource = imageSource;
            _firstName = firstName;
            _avatarSource = avatarSource;
            DateTime = date;
            InitializeComponent();
        }

        public DateTime? DateTime { get; }

        private ImageSource _imageSource;
        public ImageSource ImageSource => _imageSource;

        private string _firstName;
        public string FirstName => _firstName;

        private ImageSource _avatarSource;
        public ImageSource AvatarSource  => _avatarSource;

       
    }
}
