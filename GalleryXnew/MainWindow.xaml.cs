using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
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
using System.IO;
using System.Xml.Serialization;
using System.Xml;



namespace GalleryXnew
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<Artist> ArtistList = new List<Artist>();
        public static List<Artwork> ArtworkList = new List<Artwork>();
        public static List<Customer> CustomerList = new List<Customer>();
        public static List<Artwork> ArtworkOnDisplay3 = new List<Artwork>();


        public MainWindow()
        {

            InitializeComponent();
        }
        private void SaveArtwork(object sender, RoutedEventArgs e)
        {
            try
            {

                /// Load the artwork list
                if (File.Exists("ArtworkList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artwork>));
                    StreamReader textReader = new StreamReader("ArtworkList.xml");
                    ArtworkList = (List<Artwork>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }

                /// User input of the artist ID
                int ArtistID = int.Parse(ArtistID1textBOX.Text);

                /// Sends artistlist to array
                Artist[] artistx = ArtistList.ToArray();
                var array = artistx;
                var artwork = new Artwork();


                var artistt = ArtistList.Any(p => p.ThisArtistID == ArtistID);
                artwork.HoldArtistID = ArtistID;
                artwork.ThisArtworkDescription = DescriptionTextBox.Text;
                artwork.ThisArtworkPrice = decimal.Parse(PriceTextBox.Text);
                ArtworkList.Add(artwork);
                /// Search through list
                for (int i = 0; i < ArtworkList.Count(); i++)
                {
                    foreach (var Artwork in ArtworkList)
                    {
                        /// sets the ID value
                        if (ArtworkList.Count() == 1)
                        {

                            Artwork.ThisArtworkID = ArtworkList.Count();
                        }
                        else
                        {
                            artwork.ThisArtworkID = ArtworkList.Count() - 1;

                        }



                    }
                }

                /// Save artwork Data
                Savexml.SaveArtworkData(ArtworkList, "ArtworkList.xml");

                ///assign to the artist


                if (File.Exists("ArtistList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artist>));
                    TextReader textReader = new StreamReader("ArtistList.xml");
                    ArtistList = (List<Artist>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }


                Artist a = new Artist();
                a.AssignArtworkToArtist(ArtistList, ArtworkList);
            }




            catch (Exception ex)
            {
                MessageBox.Show("Artist ID and price are numbers");
            }
        }




        private void Save_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                Savexml x = new Savexml();

                // Loads artist information

                if (File.Exists("ArtistList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artist>));
                    StreamReader textReader = new StreamReader("ArtistList.xml");
                    ArtistList = (List<Artist>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }


                /// Creates a artist instance
                var artist = new Artist();
                // Sets variable values
                artist.ThisArtistName = ArtistName.Text;
                artist.thisArtistAddres = ArtistAddress.Text;

                // Adds the artist instance into artistlist
                ArtistList.Add(artist);
                for (int i = 0; i < ArtistList.Count(); i++)
                {
                    foreach (var artistx in ArtistList)
                    {
                        //set ID
                        if (ArtistList.Count() == 1)
                        {
                            artist.ThisArtistID = ArtistList.Count();

                        }
                        else
                        {

                            artist.ThisArtistID = ArtistList.Count();

                        }




                    }
                }

                /// Save artist Information
                Savexml.SaveData(ArtistList, "ArtistList.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadArtist_Click(object sender, RoutedEventArgs e)
        {

            // Load artistList
            if (File.Exists("ArtistList.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Artist>));
                TextReader textReader = new StreamReader("ArtistList.xml");
                ArtistList = (List<Artist>)deserializer.Deserialize(textReader);
                textReader.Close();

            }

            // Display artist information
            foreach (Artist a in ArtistList)
            {
                ShowAllArtist.Items.Add("ID number:  " + a.ThisArtistID);

                ShowAllArtist.Items.Add("Artist Name:  " + a.ThisArtistName);
                ShowAllArtist.Items.Add("Artist Address: " + a.thisArtistAddres);
            }

        }
        private void displayArtist(List<Artist> artist)
        {
            Artist[] artistarray = artist.ToArray();

            Artist showartist = new Artist();
            for (int i = 0; i < artistarray.Length; i++)
            {
                /// Displays all artists
                ShowAllArtist.Items.Add("Artist Name:  " + artistarray[i].ThisArtistName);
                ShowAllArtist.Items.Add("Artist Name:  " + artistarray[i].thisArtistAddres);


            }
            //foreach (Artist a in ArtistList)
            //{
            //    
            //    ShowAllArtist.Items.Add("Artist Address: " + a.thisArtistAddres);

            //}
        }




        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /// Loads Artwork and artist List
                if (File.Exists("ArtworkList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artwork>));
                    StreamReader textReader = new StreamReader("ArtworkList.xml");
                    ArtworkList = (List<Artwork>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }

                if (File.Exists("ArtistList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artist>));
                    StreamReader textReader = new StreamReader("ArtistList.xml");
                    ArtistList = (List<Artist>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }
                // Create a new artwork instance
                var loadArtwork = new Artwork();

                // New artwork list intialised 
                List<Artwork> ARTWORKSBYARTIST = new List<Artwork>();
                // Input by user changed into useable variable
                int ID = int.Parse(ArtistID1textBOX.Text);

                /// Calls method contained in class
                loadArtwork.loadArtist(ArtistList, ArtworkList, ID, ARTWORKSBYARTIST);
                // Clears the display
                ArtworkByArtistdisplay.Items.Clear();

                foreach (var art in ARTWORKSBYARTIST)
                {
                    /// All of the artist artwork is displayed
                    ArtworkByArtistdisplay.Items.Add("Artwork Description:  " + art.ThisArtworkDescription);
                    ArtworkByArtistdisplay.Items.Add("Artwork Price:  " + "£" + art.ThisArtworkPrice);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Artist ID has to be a number");
            }

        }



        private void ChangeAddressSave_Click(object sender, RoutedEventArgs e)
        {
            /// Creates  a artist instance
            Artist a = new Artist();
            // Changes user input into a usable variable
            int ID = int.Parse(ArtistIDforEdit.Text);
            string ChangeAddres = NewAddress.Text;
            // Calls method contained in class
            a.editArtist(ArtistList, ID, ChangeAddres);
        }

        private void AddtoDisplay_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                /// Loads display and artwork data
                if (File.Exists("ArtworkOnDisplay.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artwork>));
                    StreamReader textReader = new StreamReader("ArtworkOnDisplay.xml");
                    ArtworkOnDisplay3 = (List<Artwork>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }
                if (File.Exists("ArtworkList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artwork>));
                    StreamReader textReader = new StreamReader("ArtworkList.xml");
                    ArtworkList = (List<Artwork>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }

                /// User input changed into useable variable
                int id = int.Parse(ArtworkIDtextbox.Text);

                Artwork artworkTodisplay1 = new Artwork();

                /// Calls method contained in class
                artworkTodisplay1.AddArtworktoDisplay(ArtworkList, id, ArtworkOnDisplay3);
                // Displays artwork
                ShowArtworkOnDisplay(ArtworkOnDisplay3);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Artwork ID has to be a number");
            }

        }

        private void ArtistArtwork(object sender, RoutedEventArgs e)
        {
            // Creates a new artwork instance
            var loadArtwork = new Artwork();
            List<Artwork> ARTWORKSBYARTIST = new List<Artwork>();
            int ID = int.Parse(ArtistID1textBOX.Text);
            loadArtwork.loadArtist(ArtistList, ArtworkList, ID, ARTWORKSBYARTIST);
            ArtworkByArtistdisplay.Items.Clear();
            foreach (var art in ARTWORKSBYARTIST)
            {
                ArtworkByArtistdisplay.Items.Add("Artwork Description:  " + art.ThisArtworkDescription);
                ArtworkByArtistdisplay.Items.Add("Artwork Price:  " + "£" + art.ThisArtworkPrice);
            }
        }

        private void SaveArtistChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists("ArtistList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artist>));
                    StreamReader textReader = new StreamReader("ArtistList.xml");
                    ArtistList = (List<Artist>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }

                Artist a = new Artist();
                int ID = int.Parse(ArtistIDforEdit.Text);
                string ChangeAddres = NewAddress.Text;

                a.editArtist(ArtistList, ID, ChangeAddres);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input correct details");
            }
        }

        private void SaveNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /// Loads customer information
                if (File.Exists("CustomerList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Customer>));
                    StreamReader textReader = new StreamReader("CustomerList.xml");
                    CustomerList = (List<Customer>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }
                // Create a new instance for customer
                var customer = new Customer();
                // Give variables a value
                customer.thisCustomerAddress = CustomerAddressTextbox.Text;
                customer.ThisCustomerName = CustomerName.Text;
                /// Add new customer to the list
                CustomerList.Add(customer);

                /// Loop through the customer list
                for (int i = 0; i < CustomerList.Count; i++)
                {
                    foreach (var customerr in CustomerList)
                    {
                        /// Sets customer ID
                        if (CustomerList.Count == 1)
                        {
                            customer.ThisCustomerID = CustomerList.Count;

                        }
                        else
                        {
                            customer.ThisCustomerID = CustomerList.Count;
                        }
                        // Saves the new customer
                        Savexml.CustomerInformaiton(CustomerList, "CustomerList.xml");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Make sure all fields are filled");
            }


        }

        private void EditingCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                /// Loads customer informaiton
                if (File.Exists("CustomerList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Customer>));
                    StreamReader textReader = new StreamReader("CustomerList.xml");
                    CustomerList = (List<Customer>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }
                /// Create a customer instance
                Customer a = new Customer();

                /// Changes user input to appriopriate varaiables
                int CustomerID = int.Parse(CustomerIDforUpdatetextbox.Text);
                string ChangeAddressForCustomer = NewAddressForUpdate.Text;

                /// Calls method contained in class
                a.EditCustomer(CustomerList, CustomerID, ChangeAddressForCustomer);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Make sure that all fields are filled out and that customer ID is a number");
            }
        }

        private void ShowArtworkOnDisplay(List<Artwork> artworkonDisplay)
        {


            /// Shows all artwork on display
            foreach (Artwork a in artworkonDisplay)
            {
                ArtworkonDisplayListBox.Items.Add("Artwork ID:   " + a.ThisArtworkID);
                ArtworkonDisplayListBox.Items.Add("Artwork Description:   " + a.ThisArtworkDescription);
                ArtworkonDisplayListBox.Items.Add("Artwork Price:    £" + a.ThisArtworkPrice);
                ArtworkonDisplayListBox.Items.Add("");
                ArtworkonDisplayListBox.Items.Add("Date added to display:   " + a.TimeaddedtoDisplaynow);
                ArtworkonDisplayListBox.Items.Add("");
            }
        }

        private void Purchase(object sender, RoutedEventArgs e)
        {
            try
            {
                /// User input changed into appriopraite variables
                int customerID = int.Parse(CustomerIDtextBOXforPurchase.Text);
                int ArtworkID = int.Parse(ArtworkIDforPurchase.Text);

                /// initialise Data sources
                if (File.Exists("ArtworkOnDisplay.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artwork>));
                    StreamReader textReader = new StreamReader("ArtworkOnDisplay.xml");
                    ArtworkOnDisplay3 = (List<Artwork>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }

                if (File.Exists("CustomerList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Customer>));
                    StreamReader textReader = new StreamReader("CustomerList.xml");
                    CustomerList = (List<Customer>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }

                /// Customer instance intialised 
                Customer b = new Customer();

                //method called 

                b.BuyArtwork(ArtworkOnDisplay3, ArtworkID, CustomerList, customerID);
                string sold = "Thank you for buying";
                List<SalesRecord> Receipt = new List<SalesRecord>();
                if (File.Exists("Receipt.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<SalesRecord>));
                    StreamReader textReader = new StreamReader("Receipt.xml");
                    Receipt = (List<SalesRecord>)deserializer.Deserialize(textReader);
                    textReader.Close();
                }

                foreach (SalesRecord a in Receipt)
                {
                    RECEIPTlistbox.Items.Add("Customer ID:  " + customerID);
                    RECEIPTlistbox.Items.Add("Artwork ID:  " + a.ArtworkID);
                    RECEIPTlistbox.Items.Add(sold);
                    RECEIPTlistbox.Items.Add(DateTime.Now);

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Sale has failed, make sure you input the correct details");
            }

        }



        private void All_artwork_Click(object sender, RoutedEventArgs e)
        {
            /// Loads Artwork List
            if (File.Exists("ArtworkList.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Artwork>));
                StreamReader textReader = new StreamReader("ArtworkList.xml");
                ArtworkList = (List<Artwork>)deserializer.Deserialize(textReader);
                textReader.Close();

            }
            /// Displays all artwork
            ArtworkByArtistdisplay.Items.Clear();
            foreach (Artwork a in ArtworkList)
            {
                ArtworkByArtistdisplay.Items.Add("Artwork ID:  " + a.ThisArtworkID);
                ArtworkByArtistdisplay.Items.Add("Artwork price:  " + a.ThisArtworkPrice);
                ArtworkByArtistdisplay.Items.Add("Artwork description:  " + a.ThisArtworkDescription);

            }
        }

        private void Load_Gallery_Click(object sender, RoutedEventArgs e)
        {
            /// Loads gallery Data
            if (File.Exists("ArtworkOnDisplay.xml"))
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<Artwork>));
                StreamReader textReader = new StreamReader("ArtworkOnDisplay.xml");
                ArtworkOnDisplay3 = (List<Artwork>)deserializer.Deserialize(textReader);
                textReader.Close();

            }

            foreach (Artwork a in ArtworkOnDisplay3)
            {
                /// Displays all artwork on display
                ArtworkonDisplayListBox.Items.Add("Artwork ID: " + a.ThisArtworkID);
                ArtworkonDisplayListBox.Items.Add("Artwork Price:  " + a.ThisArtworkPrice);
                ArtworkonDisplayListBox.Items.Add("Artwork Description:  " + a.ThisArtworkDescription);
                ArtworkonDisplayListBox.Items.Add("");
                ArtworkonDisplayListBox.Items.Add("Date added to display:  " + a.TimeaddedtoDisplaynow);
                ArtworkonDisplayListBox.Items.Add("");
            }
        }

        private void Artwork_by_artist_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /// Loads xml file into ArtworkList and ArtistList
                if (File.Exists("ArtworkList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artwork>));
                    StreamReader textReader = new StreamReader("ArtworkList.xml");
                    ArtworkList = (List<Artwork>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }
                if (File.Exists("ArtistList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artist>));
                    TextReader textReader = new StreamReader("ArtistList.xml");
                    ArtistList = (List<Artist>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }
                //Creates a artist Instance
                Artist a = new Artist();

                /// Changes List into array
                Artist[] artistarray = ArtistList.ToArray();
                Artwork[] artworkarray = ArtworkList.ToArray();
                int artistid = int.Parse(ArtistIDforsearchingtextbox.Text);

                /// Loop through the arrays
                for (int i = 0; i < artistarray.Length; i++)
                {
                    for (int t = 0; t < artworkarray.Length; t++)
                    {
                        if (artistid == artistarray[i].ThisArtistID)
                        {
                            /// Mathces artist ID with the ID held in artwork
                            if (artistarray[i].ThisArtistID == artworkarray[t].HoldArtistID)
                            {
                                List<Artwork> artwork = new List<Artwork>();
                                artwork.Add(artworkarray[t]);
                                // Displays all artwork under that ID
                                foreach (Artwork v in artwork)
                                {
                                    Artworkbyartistlstbox.Items.Add("Artwork ID:  " + v.ThisArtworkID);
                                    Artworkbyartistlstbox.Items.Add("Artwork price:  " + v.ThisArtworkPrice);
                                    Artworkbyartistlstbox.Items.Add("Artwork description:   " + v.ThisArtworkDescription);
                                    Artworkbyartistlstbox.Items.Add("");
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input a number");
            }
        }

        private void CustomerPurchasedArtwork(object sender, RoutedEventArgs e)
        {

            try
            {
                /// Loads xml into customer list
                if (File.Exists("CustomerList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Customer>));
                    StreamReader textReader = new StreamReader("CustomerList.xml");
                    CustomerList = (List<Customer>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }
                /// User input changed into appriopraite value


                int customerID = int.Parse(CustomerIDforpreviousartworktxt.Text);
                /// Changes customer list into a array
                Customer[] customer = CustomerList.ToArray();

                /// Loop through array
                for (int i = 0; i < customer.Length; i++)
                {
                    //matches ID with the one provided
                    if (customer[i].ThisCustomerID == customerID)
                    {
                        foreach (Artwork a in customer[i].ArtistArtwork)
                        {
                            /// Displays the customer's previous purchases
                            PreviousPurchaseListbox.Items.Add("Artwork ID:  " + a.ThisArtworkID);
                            PreviousPurchaseListbox.Items.Add("Artwork Price:  " + a.ThisArtworkPrice);
                            PreviousPurchaseListbox.Items.Add("Artwork Description: " + a.ThisArtworkDescription);
                            PreviousPurchaseListbox.Items.Add("");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Customer ID has to be a number");
            }
        }

        private void RemoveFromDisplay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /// Load the xml file into a list

                if (File.Exists("ArtworkOnDisplay.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artwork>));
                    StreamReader textReader = new StreamReader("ArtworkOnDisplay.xml");
                    ArtworkOnDisplay3 = (List<Artwork>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }

                /// User input changed into a interger value
                int idofartwork = int.Parse(ArtworkIDforremoving.Text);
                /// Create a artwork instance
                Artwork a = new Artwork();
                // Called the method contained within the class
                a.RemoveArtworkFromDisplay(idofartwork, ArtworkOnDisplay3);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Make sure you input the correct Artwork ID");
            }
        }

        private void ChangeArtworkPrice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /// User input of price and artwork ID changed into appriopraite variables
                decimal price = decimal.Parse(Newprice.Text);
                int id = int.Parse(ArtworkIDfornewPrice.Text);

                /// Loads the xml file into Artwork List
                if (File.Exists("ArtworkList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<Artwork>));
                    StreamReader textReader = new StreamReader("ArtworkList.xml");
                    ArtworkList = (List<Artwork>)deserializer.Deserialize(textReader);
                    textReader.Close();

                }
                // Creates a artwork instance
                Artwork a = new Artwork();
                // Calls method contained within class
                a.changeArtworkPrice(ArtworkList, id, price);
            }
            catch (Exception x)
            {
                /// Catches any invalid input
                MessageBox.Show("Please Make sure your input is correct");
            }
        }

        private void ArtworkIDfornewPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
