using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;





namespace GalleryXnew
{
    public class Artist
    {
        private string ArtistName;
        private string Address;
        private int ArtistID;
        private List<Artwork> artwork;


        public int ThisArtistID
        {
            get { return ArtistID; }
            set { ArtistID = value; }
        }
        public string ThisArtistName
        {
            get { return ArtistName; }
            set { ArtistName = value; }
        }
        public string thisArtistAddres
        {
            get { return Address; }
            set { Address = value; }
        }


        public List<Artwork> ArtistArtwork
        {
            get { return artwork; }
            set { artwork = value; }
        }

        /// <summary>
        /// Edit the artist's Address /// </summary>
        /// <param name="artist"></param> A collection of artist
        /// <param name="ID"></param>
        /// <param name="changeAddress"></param>
        public void editArtist(List<Artist> artist, int ID, string changeAddress)
        {
            /// Change Artist list into a array for searching
            Artist[] ArtistInstance = artist.ToArray();

            /// Search through the array with a loop
            for (int i = 0; i < ArtistInstance.Length; i++)
            {
                /// Matches the Artist ID with the one provided
                if (ID == ArtistInstance[i].ArtistID)
                {
                    /// Sets the new address
                    ArtistInstance[i].Address = changeAddress;
                }
            }
            /// Return array into artist List
            artist = ArtistInstance.ToList();

            /// Save changes to the artist's Address
            Savexml.SaveData(artist, "ArtistList.xml");
        }


        ///Method to assign artwork to artist
        public void AssignArtworkToArtist(List<Artist> artistx, List<Artwork> art)
        {
            // set up the lists as arrays so we can search through them
            Artist[] arrayofArtist = artistx.ToArray();
            Artwork[] arrayofArtwork = art.ToArray();

            /// Search through the arrays
            for (int i = 0; i < arrayofArtist.Length; i++)
            {
                for (int t = 0; t < arrayofArtwork.Length; t++)
                {
                    /// Matches the artist ID with the Artist ID in the artwork array
                    if (arrayofArtist[i].ArtistID == arrayofArtwork[t].HoldArtistID)
                    {
                        /// Assigns the new artwork to the artist
                        arrayofArtist[i].ArtistArtwork.Add(arrayofArtwork[t]);
                    }
                }
            }
            /// Return artist array back into a list
            artistx = arrayofArtist.ToList();

            // Save the assigned artwork
            Savexml.SaveData(artistx, "ArtistList.xml");
        }

    }

}
