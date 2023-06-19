using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    /// <summary>
    /// This class represents an album in the music library.
    /// </summary>
    public class Album
    {
        [Key]
        public int AlbumID { get; set; }
        public string AlbumName { get; set; }
        public string ComposerName { get; set; }
        public ObservableCollection<Track> AlbumTracks { get; set; }
    }
}

