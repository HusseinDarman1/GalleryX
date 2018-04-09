using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryXnew
{
public    class SalesRecord
    {
    /// <summary>
    /// Used to create a temporary receipt for customers
    /// </summary>
    /// 
   ///The variables used within the class
        public int customerID;
        public int ArtworkID;
        public string artworkSold;
        public DateTime TimeofSale;


    // method to create a receipt, where the sales person inputes the artworkID and CustomerID
        public void Receipt(int ArtworkID, int CustomerID, DateTime now, string TypeSold)

        {
           var receipt = new SalesRecord();
            List<SalesRecord> Sale = new List<SalesRecord>();
            receipt.artworkSold = TypeSold;
            receipt.ArtworkID = ArtworkID;
            receipt.customerID = CustomerID;

            Sale.Add(receipt);

            //save to a xml file where you can print the receipt 
            Savexml.Receipt(Sale, "Receipt.xml");

        }
    }
   
}
