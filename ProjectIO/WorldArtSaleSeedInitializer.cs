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
            artPiecesList.Add(new ClassArt() { picturePath = $"C:/CodeMappe/Image/dsb1.jpg",
                                               pictureDescription = "CHOOO CHOOOOOOOOOOO!",
                                               pictureTitel = "Train, Fast, Smoke." });
            artPiecesList.Add(new ClassArt()
            {
                picturePath = $"C:/CodeMappe/Image/dsb3.jpg",
                pictureDescription = "im a bird.",
                pictureTitel = "Smash Bird."
            });
            artPiecesList.Add(new ClassArt()
            {
                picturePath = $"C:/CodeMappe/Image/dsb2.jpg",
                pictureDescription = "Hjulene på toget drejer rundt rundt rundt!",
                pictureTitel = "Van Gogh's most renown painting."
            });

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
