using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GalleryXnew
{
    public class Customer
    {

        // the variable in the class made private for security
        private List<Artwork> boughtarwork;
        private string name;
        private string address;
        private int CustomerID;

        /// <summary>
        /// method to retrieve the information in the customer class
        /// </summary>
        public int ThisCustomerID
        {
            get { return CustomerID; }
            set { CustomerID = value; }
        }
        public string ThisCustomerName
        {
            get { return name; }
            set { name = value; }
        }
        public string thisCustomerAddress
        {
            get { return address; }
            set { address = value; }
        }
        public List<Artwork> ArtistArtwork
        {
            get { return boughtarwork; }
            set { boughtarwork = value; }
        }


        /// <summary>
        /// Method used to purchase the artwork
        /// </summary>
        /// <param name="Gallery"></param> A list of artworks within the gallery
        /// <param name="ArtworkID"></param> The artwork ID
        /// <param name="customerCollection"></param> A list of customers
        /// <param name="CustomerID"></param> Customer ID
        public void BuyArtwork(List<Artwork> Gallery, int ArtworkID, List<Customer> customerCollection, int CustomerID)
        {
            /// sets the customer list into a array used for searching

            Customer[] customerArray = customerCollection.ToArray();

            /// set the gallery list into a array used for searching 

            Artwork[] artworkondisplayarray = Gallery.ToArray();

            /// Intiate a search through the customer array
            for (int i = 0; i < customerArray.Length; i++)
            {
                /// intiate a search through the artwork array
                for (int t = 0; t < artworkondisplayarray.Length; t++)
                {
                    // Matches the artwork ID with the artwork ID provided by the sales person


                    if (artworkondisplayarray[t].ThisArtworkID == ArtworkID)
                    {

                        /// adds the artwork on display into customer purchase records 

                        customerArray[i].boughtarwork.Add(artworkondisplayarray[t]);
                        ///returns the customer array back into a list
                        customerCollection = customerArray.ToList();
                        /// removes Artwork from the gallery

                        Gallery.Remove(artworkondisplayarray[t]);
                        string sold = "sold Artwork";
                        SalesRecord solds = new SalesRecord();

                        ///create receipt for customer

                        solds.Receipt(artworkondisplayarray[t].ThisArtworkID, customerArray[i].CustomerID, DateTime.Now, sold);

                    }
                }

            }
            //Saves the new display information
            Savexml.SaveDisplayData(Gallery, "ArtworkOnDisplay.xml");

            /// Save the new customer information with their purchases

            Savexml.CustomerInformaiton(customerCollection, "CustomerList.xml");
        }


        /// <summary>
        /// Edit the customer information
        /// </summary>
        /// <param name="customer"></param> A collection of customers
        /// <param name="CustomerID"></param> The customer's ID
        /// <param name="changeAddress"></param>  The customer's new addrress
        public void EditCustomer(List<Customer> customer, int CustomerID, string changeAddress)
        {
            /// intiate a xml document
            XmlDocument doc = new XmlDocument();

            /// Change the list of customer's into a array for searching

            Customer[] CustomerInstance = customer.ToArray();

            /// Loop through the customer array

            for (int i = 0; i < CustomerInstance.Length; i++)
            {
                /// Match the Customer ID with the one provided by the user

                if (CustomerID == CustomerInstance[i].ThisCustomerID)
                {

                    /// Change the customer Address to equal the new address
                    CustomerInstance[i].thisCustomerAddress = changeAddress;

                }
            }

            /// returns array back into customer list
            customer = CustomerInstance.ToList();

            // Save the new customer information
            Savexml.CustomerInformaiton(customer, "CustomerList.xml");

        }


    }
}
