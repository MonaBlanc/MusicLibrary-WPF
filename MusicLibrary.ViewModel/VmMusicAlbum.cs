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

namespace MusicLibrary.ViewModel
{
    public class VmMusicAlbum : ViewModelBase
    {
        //Liste d'albums 
        public ObservableCollection<Album> _albums;
        private readonly IMainView _view;

        public interface IMainView
        {
            void DisplayError(string AlbumName, string ComposerName);
            void OpenNewWindow(VmMusicAlbum currentViewModel);
        }


        public VmMusicAlbum(ObservableCollection<Album> albumList, IMainView view)
        {
            _albums = albumList ?? new ObservableCollection<Album>();
            SelectedAlbum = albums.FirstOrDefault();
            SelectedTrack = TrackList?.FirstOrDefault();
            _view = view;
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

        private string _newTrack;

        public string NewTrack
        {
            get { return _newTrack; }
            set { _newTrack = value; OnPropertyChanged(); }
        }

        public void AddNewAlbum()
        {
            if (albums.Any(x => x.AlbumName == AlbumName && x.ComposerName == ComposerName))
            {
                _view.DisplayError(AlbumName, ComposerName);
            }
            else
            {
                TrackList = new ObservableCollection<Track>();
                albums.Add(new Album { AlbumName = AlbumName, ComposerName = ComposerName, AlbumTracks = TrackList });
                SelectedAlbum = albums.FirstOrDefault(x => x.AlbumName == AlbumName && x.ComposerName == ComposerName);
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
            SelectedAlbum.AlbumTracks.Add(new Track() { Title = NewTrack, TrackID = newId });
        }

        public void DeleteTrack()
        {
            albums.FirstOrDefault(x => x.AlbumName == SelectedAlbum.AlbumName && x.ComposerName == SelectedAlbum.ComposerName).AlbumTracks.Remove(SelectedTrack);

            foreach (var track in TrackList)
            {
                track.TrackID = TrackList.IndexOf(track);
                OnPropertyChanged(nameof(track.TrackID));
            }

            OnPropertyChanged(nameof(TrackList));
        }

        public void OpenNewWindow()
        {
            _view.OpenNewWindow(this);
        }

        private bool CanDeleteTrack => SelectedTrack != null;
        private bool CanDeleteAlbum => SelectedAlbum != null;
        public bool CanAddNewAlbum => !(string.IsNullOrWhiteSpace(AlbumName) || string.IsNullOrWhiteSpace(ComposerName));
        public bool CanAddNewTrack => !string.IsNullOrWhiteSpace(NewTrack);
        private bool CanOpenNewWindow => SelectedAlbum != null;

        private ICommand _addNewAlbum;
        public ICommand AddNewAlbumCommand => _addNewAlbum ??= new CommandHandler(AddNewAlbum, () => CanAddNewAlbum);

        private ICommand _deleteAlbum;
        public ICommand DeleteAlbumCommand => _deleteAlbum ??= new CommandHandler(DeleteAlbum, () => CanDeleteAlbum);

        private ICommand _addNewTrack;
        public ICommand AddNewTrackCommand => _addNewTrack ??= new CommandHandler(AddNewTrack, () => CanAddNewTrack);

        private ICommand _deleteTrack;
        public ICommand DeleteTrackCommand => _deleteTrack ??= new CommandHandler(DeleteTrack, () => CanDeleteTrack);
        
        private ICommand _openNewWindow;

        public ICommand OpenNewWindowCommand => _openNewWindow ??= new CommandHandler(OpenNewWindow, () => CanOpenNewWindow);

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
