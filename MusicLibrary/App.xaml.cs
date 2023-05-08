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

namespace MusicLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
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
        
            VmMusicAlbum vMMusicAlbum = new (albumList);
            MusicAlbumEditor musicAlbumEditor = new(vMMusicAlbum);
            musicAlbumEditor.Show();

        }
    }
}
