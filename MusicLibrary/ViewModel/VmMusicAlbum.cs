using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using MusicLibrary.Helper;
using MusicLibrary.Model;
using MusicLibrary.View;

namespace MusicLibrary.ViewModel
{
    public class VmMusicAlbum : INotifyPropertyChanged
    {
        //Liste d'albums 
        public ObservableCollection<Album> _albums;

        public VmMusicAlbum(ObservableCollection<Album> albumList)
        {
            _albums = albumList ?? new ObservableCollection<Album>();
            SelectedAlbum = albums.FirstOrDefault();
            SelectedTrack = TrackList?.FirstOrDefault();

        }

        public VmMusicAlbum()
        {
            
        }

        private string _composerName;

        public string ComposerName
        {
            get { return _composerName; }
            set { _composerName = value; OnPropertyChanged(); }
        }

        private string _albumName;

        public string AlbumName
        {
            get { return _albumName; }
            set { _albumName = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Track> _trackList;

        public ObservableCollection<Track> TrackList
        {
            get { return _trackList; }
            set { _trackList = value; OnPropertyChanged(nameof(TrackList)); }
        }

        public ObservableCollection<Album> albums
        {
            get { return _albums; }
            set { _albums = value; OnPropertyChanged(); }
        }

        private Album _selectedAlbum;

        public Album SelectedAlbum
        {
            get { return _selectedAlbum; }
            set
            {
                _selectedAlbum = value;
                    
                    TrackList = _selectedAlbum?.AlbumTracks;
                    AlbumName = _selectedAlbum?.AlbumName;
                    ComposerName = _selectedAlbum?.ComposerName;
                
                OnPropertyChanged();
            }
        }

        private string _trackTitle;

        public string TrackTitle
        {
            get { return _trackTitle; }
            set { _trackTitle = value; OnPropertyChanged(); }
        }

        private Track _selectedTrack;

        public Track SelectedTrack
        {
            get { return _selectedTrack; }
            set
            {
                _selectedTrack = value;
                TrackTitle = _selectedTrack?.Title;
                OnPropertyChanged(nameof(SelectedTrack));
            }
        }

        /*public Track SelectedTrack
        {
            get { return _selectedTrack; }
            set { _selectedTrack = value;
                TrackTitle = _selectedTrack.Title;
                OnPropertyChanged();
            }
        }*/

        private string _newTrack;

        public string NewTrack
        {
            get { return _newTrack; }
            set { _newTrack = value;
                OnPropertyChanged(); }
        }


        public void AddNewAlbum()
        {
            if (albums.Any(x => x.AlbumName == AlbumName && x.ComposerName == ComposerName ))
            {
                MessageBox.Show("The album : " + AlbumName + " and composer : " + ComposerName + " already exists", "Duplicate Entry");
            }
            else
            {
                TrackList = new ObservableCollection<Track>();
                albums.Add(new Album { AlbumName = AlbumName, ComposerName = ComposerName, AlbumTracks = TrackList });
                SelectedAlbum = albums.FirstOrDefault(x => x.AlbumName == AlbumName && x.ComposerName == ComposerName);
                MessageBox.Show("New album successfully created", "New Album");
            }
        }
        public void DeleteAlbum()
        {
            albums.Remove(SelectedAlbum);
        }


        public void AddNewTrack()
        {
            var newId = 1;
            if (SelectedAlbum.AlbumTracks.Any())
            {
                newId = SelectedAlbum.AlbumTracks.Max(x => x.TrackID) + 1;
            }
            SelectedAlbum.AlbumTracks.Add(new Track() { Title = NewTrack, TrackID = newId});
        }
        public void DeleteTrack()
        {
            albums.FirstOrDefault(x => x.AlbumName == SelectedAlbum.AlbumName && x.ComposerName == SelectedAlbum.ComposerName).AlbumTracks.Remove(SelectedTrack);
            /*            SelectedAlbum.AlbumTracks = new ObservableCollection<Track>(SelectedAlbum.AlbumTracks.Distinct());
            */
            foreach (var track in TrackList)
            {
                track.TrackID = TrackList.IndexOf(track);
                OnPropertyChanged(nameof(track.TrackID));
            }

            OnPropertyChanged(nameof(TrackList));

        }

        public void OpenNewWindow()
        {
            var albumDetails = new AlbumDetails
            {
                DataContext = this
            };
            albumDetails.Show();
        }
        private bool CanDeleteTrack
        {
            get
            {
                return SelectedTrack != null;
            }

        }
        private bool CanDeleteAlbum
        {
            get
            {
                return SelectedAlbum != null;
            }

        }
        public bool canAddNewalbum
        {
            get { return !(string.IsNullOrWhiteSpace(AlbumName) || string.IsNullOrWhiteSpace(ComposerName)); }

        }
        private ICommand _addNewAlbum;
        public ICommand addNewAlbum
        {
            get
            {
                return _addNewAlbum ?? (_addNewAlbum = new CommandHandler(() => AddNewAlbum(), () => canAddNewalbum));
            }
        }
        private ICommand _deleteAlbum;
        public ICommand deleteAlbum
        {
            get
            {
                return _deleteAlbum ?? (_deleteAlbum = new CommandHandler(() => DeleteAlbum(), () => CanDeleteAlbum));
            }
        }




        public bool canAddnewTrack
        {
            get { return !string.IsNullOrWhiteSpace(NewTrack); }

        }


        private ICommand _addNewTrack;

        public ICommand addNewTrack
        {
            get
            {
                return _addNewTrack ?? (_addNewTrack = new CommandHandler(() => AddNewTrack(), () => canAddnewTrack));
            }
        }

        private ICommand _deleteTrack;

        public ICommand deleteTrack
        {
            get
            {
                return _deleteTrack ?? (_deleteTrack = new CommandHandler(() => DeleteTrack(), () => CanDeleteTrack));
            }
        }
        private ICommand _openNewWindow;

        public ICommand openNewWindow
        {
            get
            {
                return _openNewWindow ?? (_openNewWindow = new CommandHandler(() => OpenNewWindow(), () => true));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
