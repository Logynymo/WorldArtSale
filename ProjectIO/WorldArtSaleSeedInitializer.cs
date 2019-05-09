using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Repositoty;

namespace ProjectIO
{
    class WorldArtSaleSeedInitializer  : DropCreateDatabaseIfModelChanges<WorldArtSaleContext>
    {
        IList<ClassArt> artPiecesList = new List<ClassArt>();
        IList<ClassCustomer> customerList = new List<ClassCustomer>
        {
            new ClassCustomer() { name = "Egrici Von Hermann", address = "VillavejMedStorBalkon 14",
                                  zipCity = "6500 Vojens", country = "Danmark",
                                  email = "rigmand247@gmail.com", phoneNo = "20560026",
                                  maxBid = 0, preferredCurrency = "DKK"}
        };



        public WorldArtSaleSeedInitializer()
        {
            artPiecesList.Add(new ClassArt() { picturePath = $"insert Path Here",
                                               pictureDescription = "Insert Desc Here",
                                               pictureTitel = "Insert Title Here" });

        }

        protected override void Seed(WorldArtSaleContext context)
        {
            foreach (ClassArt artPiece in artPiecesList)
            {
                context.ArtTable.Add(artPiece);
            }
            foreach (ClassCustomer individualCustomer in customerList)
            {
                context.Customer.Add(individualCustomer);
            }
            /*foreach (var item in collection)
            {

            }*/
            context.SaveChanges();
            base.Seed(context);
        }

    }
}
