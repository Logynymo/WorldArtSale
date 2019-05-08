using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Repositoty;

namespace ProjectIO
{
    public class ClassWorldArtSaleDB : ClassDbCon
    {

        public ClassWorldArtSaleDB()
        {
            //INDSÆT NAVNET PÅ DIN EGEN DATABASE
            SetCon(@"Server=CV-BB-5781\SQLEXPRESS2017;Database=WorldArtSale;Trusted_Connection=True;");
        }

        public List<ClassCustomer> GetAllCustomerFromDB(ClassCurrency inClassCurrency)
        {
            List<ClassCustomer> listCC = new List<ClassCustomer>();

            DataTable dataTable = DbReturnDataTable("SELECT * FROM Customer");
            foreach (DataRow row in dataTable.Rows)
            {
                ClassCustomer classCustomer = new ClassCustomer();
                classCustomer.classCurrency = inClassCurrency;

                classCustomer.customerID = Convert.ToInt32(row["id"].ToString());
                classCustomer.name = row["name"].ToString();
                classCustomer.address = row["address"].ToString();

                classCustomer.zipCity = row["zipCity"].ToString();
                classCustomer.country = row["country"].ToString();
                classCustomer.email = row["email"].ToString();
                classCustomer.phoneNo = row["phone"].ToString();
                classCustomer.maxBid = row["maximumBid"].ToString();
                classCustomer.customerCurrencyID = row["preferredCurrency"].ToString();
                listCC.Add(classCustomer);
            }

            return listCC;
        }

        public List<ClassArt> GetAllArtFromDB()
        {
            List<ClassArt> listArt = new List<ClassArt>();

            DataTable dataTable = DbReturnDataTable("SELECT * FROM ArtTable");
            foreach (DataRow row in dataTable.Rows)
            {
                ClassArt classArt = new ClassArt();
                classArt.artID = row["id"].ToString();

                classArt.pictureTitel = row["tittel"].ToString();
                classArt.pictureDescription = row["description"].ToString();
                classArt.picturePath = row["picturePath"].ToString();

                listArt.Add(classArt);
            }


            return listArt;
        }

        public void SaveCustomerInDB(ClassCustomer inClassCustomer)
        {
            string maxBidInsert = inClassCustomer.maxBid;
            maxBidInsert = maxBidInsert.Replace(".", "");
            maxBidInsert = maxBidInsert.Replace(",", ".");
            string sqlQuery = $"INSERT INTO Customer (name, address, zipCity, country, email, phone, maximumBid, preferredCurrency) " +
                $"VALUES ('{inClassCustomer.name}', '{inClassCustomer.address}', '{inClassCustomer.zipCity}', '{inClassCustomer.country}', '{inClassCustomer.email}', '{inClassCustomer.phoneNo}', {maxBidInsert}, '{inClassCustomer.customerCurrencyID}')";
            ExecuteNonQuery(sqlQuery);
        }

        public void UpdateCustomerInDB(ClassCustomer inClassCustomer)
        {
            string sqlQuery = $"UPDATE Customer SET name = '{inClassCustomer.name}', " +
                $"address = '{inClassCustomer.address}', zipCity = '{inClassCustomer.zipCity}', " +
                $"country = '{inClassCustomer.country}', email = '{inClassCustomer.email}', " +
                $"phone = '{inClassCustomer.phoneNo}', " +
                $"maximumBid = '{inClassCustomer.maxBid}', " +
                $"preferredCurrency = '{inClassCustomer.customerCurrencyID}' " +
                $"WHERE id = {inClassCustomer.customerID.ToString()}";
            ExecuteNonQuery(sqlQuery);
        }

        public void SaveArtDataInDB(ClassArt inClassArt)
        {
            string sqlQuery = "INSERT INTO ArtTable (picturePath, description, tittel) VALUES ('" + inClassArt.picturePath + "', '" + inClassArt.pictureDescription + "', '" + inClassArt.pictureTitel + "'  )";
            ExecuteNonQuery(sqlQuery);
        }

    }
}
