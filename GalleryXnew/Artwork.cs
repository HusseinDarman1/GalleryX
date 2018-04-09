using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;


namespace GalleryXnew
{
    public class Artwork
    {

        private int ArtworkID;
        private decimal price;
        private string description;
        private int ArtistID;
        private DateTime timeaddedtodisplay;

        public int ThisArtworkID
        {
            get { return ArtworkID; }
            set { ArtworkID = value; }
        }
        public decimal ThisArtworkPrice
        {
            get { return price; }
            set { price = value; }
        }
        public int HoldArtistID
        {
            get { return ArtistID; }
            set { ArtistID = value; }
        }
        public string ThisArtworkDescription
        {
            get { return description; }
            set { description = value; }
        }
        public DateTime TimeaddedtoDisplaynow
        {
            get { return timeaddedtodisplay; }
            set { timeaddedtodisplay = value; }
        }


        /// <summary>
        /// Loads the artwork by the artist
        /// </summary>
        /// <param name="artist"></param> A collection of artists
        /// <param name="Artworks"></param> A collection of artworks
        /// <param name="ID"></param> The artist ID
        /// <param name="SendoutArtistList"></param> The artwork by the artist
        public void loadArtist(List<Artist> artist, List<Artwork> Artworks, int ID, List<Artwork> SendoutArtistList)
        {

            /// Change lists of artist and artwork into a array for searching 

            Artwork[] SendtoarrayArtwork = Artworks.ToArray();
            Artist[] SendtoarrayArtist = artist.ToArray();

            /// Loop through the array
            for (int i = 0; i < SendtoarrayArtist.Length; i++)
            {
                /// Matches the artist ID to any known artwork with that artist ID
                if (SendtoarrayArtist[i].ThisArtistID == ID)
                {
                    for (int z = 0; z < SendtoarrayArtwork.Length; z++)
                    {
                        if (SendtoarrayArtist[i].ThisArtistID == SendtoarrayArtwork[z].ArtistID)
                        {
                            /// Adds the artwork to the list that called the method
                            SendoutArtistList.Add(SendtoarrayArtwork[z]);

                        }
                    }
                }
            }


        }


        /// <summary>
        /// Change the price of the artwork
        /// </summary>
        /// <param name="artwork"></param> A collection of artwork
        /// <param name="ID"></param> Artwork ID
        /// <param name="newPrice"></param> The new price of the artwork
        public void changeArtworkPrice(List<Artwork> artwork, int ID, decimal newPrice)
        {
            // Changes collection of artwork into a array 

            Artwork[] artworks = artwork.ToArray();

            // Loop through the array
            for (int i = 0; i < artworks.Length; i++)
            {
                /// Matches the artwork ID with the ID provided
                if (artworks[i].ThisArtworkID == ID)
                {
                    /// Changes price of the artwork
                    artworks[i].ThisArtworkPrice = newPrice;

                }
            }
            /// Changes array back into a list
            artwork = artworks.ToList();

            Savexml.SaveArtworkData(artworks, "ArtworkList.xml");
        }

        /// <summary>
        /// Adds a artwork to the gallery
        /// </summary>
        /// <param name="artwork"></param> A collection of artworks
        /// <param name="ID"></param> Artwork ID
        /// <param name="artworkOndisplay"></param> A collection of artworks on display
        public void AddArtworktoDisplay(List<Artwork> artwork, int ID, List<Artwork> artworkOndisplay)
        {
            /// Changes collection of artwork into a array
            Artwork[] artworks = artwork.ToArray();

            // Loop through the array
            for (int i = 0; i < artworks.Length; i++)
            {
                // Maths the ID provided with the artwork ID
                if (artworks[i].ThisArtworkID == ID)
                {
                    /// Sets the time the Artwork is added to the display
                    artwork[i].TimeaddedtoDisplaynow = DateTime.Now;

                    /// Saves the artwork into the collection of artworks
                    artworkOndisplay.Add(artworks[i]);



                }
            }
            // Save the diplay Information
            Savexml.SaveDisplayData(artworkOndisplay, "ArtworkOnDisplay.xml");
        }


        /// <summary>
        /// Removes the Artwork from the display
        /// </summary>
        /// <param name="id"></param> The artwork ID
        /// <param name="artworkondisplay"></param> A  collection of artworks on display
        public void RemoveArtworkFromDisplay(int id, List<Artwork> artworkondisplay)
        {
            /// Changes artworks on display into a array
            Artwork[] artworks = artworkondisplay.ToArray();

            /// Loop through the array
            for (int i = 0; i < artworks.Length; i++)
            {
                /// Check whether the IDs match
                if (artworks[i].ThisArtworkID == id)
                {
                    /// Removes the artwork from the display
                    artworkondisplay.Remove(artworks[i]);
                    //Saves the new display information
                    Savexml.SaveDisplayData(artworkondisplay, "ArtworkOnDisplay.xml");

                }
            }
        }

    }





}
