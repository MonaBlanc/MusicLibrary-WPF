using MusicLibrary.Model;
using MusicLibrary.View;
using MusicLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using static MusicLibrary.ViewModel.VmMusicAlbum;

namespace MusicLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IMainView
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            //Initialization of the album list
            var albumList = new ObservableCollection<Album> {  new Album { AlbumID = 0, AlbumName = "FirstAlbum",  ComposerName = "Kim" }};
            //Add a track to the album
            albumList[0].AlbumTracks = new ObservableCollection<Track>
            {
                new Track() { Title = "TestTrack", AlbumID = 0, Album = albumList[0] }

            };

            MusicAlbumEditor musicAlbumEditor = new();
            musicAlbumEditor.DataContext = new VmMusicAlbum(albumList, this); // Impossible à écrire en XAML.
            musicAlbumEditor.Show();

        }

        public void DisplayError(string AlbumName, string ComposerName)
        {
            MessageBox.Show("The album : " + AlbumName + " and composer : " + ComposerName + " already exists", "Duplicate Entry");
        }
        public void OpenNewWindow(VmMusicAlbum currentViewModel)
        {
            var albumDetails = new AlbumDetails
            {
                DataContext = currentViewModel
            };
            albumDetails.Show();
        }

    }
}
