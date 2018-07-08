using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using VkPick.UserControls;
using VkPick.Utils;

namespace VkPick.Pages
{
    /// <summary>
    /// Логика взаимодействия для News.xaml
    /// </summary>
    public partial class News : Page
    {
        ListFeedSaveImage listFeedSaveImage = new ListFeedSaveImage(new List<long>()
        {
            301772958,
            443373916,
            80570296,
            82794736,
            228041052,
            162638515,
            190962731,
            62573147,
            171887986
        });

        public News()
        {
            InitializeComponent();
            listFeedSaveImage.GetPhotos();
            NextPage();
        }

        private void NextPage()
        {
            var tempPhotos = listFeedSaveImage.GetPhotos();
            foreach (var tempPhoto in tempPhotos)
            {
                ListImages.Add(new ItemImage(new BitmapImage(tempPhoto.Photo604), tempPhoto.UserId.ToString(),
                    new BitmapImage(tempPhoto.Photo604), tempPhoto.CreateTime));
            }
        }

        public ObservableCollection<ItemImage> ListImages { get; } = new ObservableCollection<ItemImage>();

        private void ScrollViewer_OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.VerticalOffset+30>ScrollViewer.ScrollableHeight )
            {
                NextPage();
            }
        }
    }
}