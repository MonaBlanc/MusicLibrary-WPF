using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicLibrary.Model
{
    /// <summary>
    /// This class represents a track in the music library.
    /// </summary>
    public class Track
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrackID { get; set; }

        public Album Album { get; set; }

        [ForeignKey("Album")]
        public int AlbumID { get; set; }

        public string Title { get; set; }
        public Track()
        {
        }
    }
}

