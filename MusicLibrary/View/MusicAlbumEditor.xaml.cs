using MusicLibrary.ViewModel;
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

namespace MusicLibrary.View
{
    /// <summary>
    /// Interaction logic for MusicAlbumEditor.xaml
    /// </summary>
    public partial class MusicAlbumEditor : Window
    {
        public MusicAlbumEditor()
        {
            InitializeComponent();

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (Application.Current.Windows[0].WindowState == WindowState.Maximized)
            {
                Application.Current.Windows[0].WindowState = WindowState.Normal;
            }
            else
            {
                Application.Current.Windows[0].WindowState = WindowState.Maximized;
            }
        }
        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }

    }
}
