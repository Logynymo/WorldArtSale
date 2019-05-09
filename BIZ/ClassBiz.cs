using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.Validation;
using System.Threading.Tasks;
using ProjectIO;
using Repositoty;
using Newtonsoft.Json;
using System.Windows;

namespace BIZ
{
    public class ClassBiz : ClassNotify
    {
        private bool runUpdate = true;
        
        ClassCallWebAPI classCallWebAPI = new ClassCallWebAPI();
        ClassFileIO classFileIO = new ClassFileIO();
        //ClassWorldArtSaleDB classWorldArtSaleDB = new ClassWorldArtSaleDB();

        private ClassCurrency _classCurrency;
        private List<ClassCustomer> _listCustomer;
        private ClassCustomer _classCustomer;
        private ClassArt _classArt;
        private List<ClassArt> _listClassArt;
        private ClassCustomer _fallBackCustomer;
        private WorldArtSaleContext getdata = new WorldArtSaleContext();





        public ClassBiz()
        {            
            classCurrency = new ClassCurrency();
            GetAllCurrencyIdAndNames();

            classCustomer = new ClassCustomer();
            //classCustomer.classCurrency = classCurrency;

            //listCustomer = classWorldArtSaleDB.GetAllCustomerFromDB(classCurrency);
            //listClassArt = classWorldArtSaleDB.GetAllArtFromDB();


            listClassArt = new List<ClassArt>(getdata.ArtTable.ToList() as List<ClassArt>);
            listCustomer = new List<ClassCustomer>(getdata.Customer.ToList() as List<ClassCustomer>);

        }

        public void MakeDataBase()
        {
            try
            {
                using (WorldArtSaleContext ctx = new WorldArtSaleContext())
                {
                    ctx.Database.CreateIfNotExists();
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var t in ex.EntityValidationErrors)
                {
                    MessageBox.Show(t.ValidationErrors.First().ErrorMessage);
                }
            }
        }

        public List<ClassArt> listClassArt
        {
            get { return _listClassArt; }
            set
            {
                if (value != _listClassArt)
                {
                    _listClassArt = value;
                    Notify("listClassArt");
                }
            }
        }




        public ClassArt classArt
        {
            get { return _classArt; }
            set
            {
                if (value != _classArt)
                {
                    _classArt = value;
                    Notify("classArt");
                }
            }
        }


        public List<ClassCustomer> listCustomer
        {
            get { return _listCustomer; }
            set
            {
                if (value != _listCustomer)
                {
                    _listCustomer = value;
                    Notify("listCustomer");
                }
            }
        }

        public ClassCustomer classCustomer
        {
            get { return _classCustomer; }
            set
            {
                if (value != _classCustomer)
                {
                    _classCustomer = value;
                    Notify("classCustomer");
                }
            }
        }

        public ClassCustomer fallbackCustomer
        {
            get { return _fallBackCustomer; }
            set
            {
                if (value != _fallBackCustomer)
                {
                    _fallBackCustomer = value;
                    Notify("fallbackCustomer");
                }
            }
        }

        public ClassCurrency classCurrency
        {
            get { return _classCurrency; }
            set
            {
                if (value != _classCurrency)
                {
                    _classCurrency = value;
                    
                    Notify("classCurrency");
                }
            }
        }


        public async Task StartCurrencyApiCall()
        {
            while (runUpdate)
            {
                // GetURLContents returns the contents of url as a byte array.
                byte[] urlContents = await classCallWebAPI.GetURLContentsAsync("https://openexchangerates.org/api/latest.json?app_id=09e34d204d7e4b998d7f178033b742ca");

                string strJson = System.Text.Encoding.UTF8.GetString(urlContents);
                classCurrency = JsonConvert.DeserializeObject<ClassCurrency>(strJson);
                await Task.Delay(60000);
            }
            
        }

        private void GetAllCurrencyIdAndNames()
        {
            try
            {
                classCurrency.currencyIdName = classFileIO.ReadDataFromCurrencyFile();
            }
            catch (Exception ex)
            {

                string strEX = ex.Message;
            }            
        }

        public void SaveArtToDB()
        {
            //classWorldArtSaleDB.SaveArtDataInDB(classArt);
            listClassArt.Clear();
           // listClassArt = classWorldArtSaleDB.GetAllArtFromDB();
        }

        public void SaveCustomerToDB()
        {
            if (classCustomer.customerID == 0)
            {
               // classWorldArtSaleDB.SaveCustomerInDB(classCustomer);
            }
            else
            {
                //classWorldArtSaleDB.UpdateCustomerInDB(classCustomer);
            }
            //listCustomer = classWorldArtSaleDB.GetAllCustomerFromDB(classCurrency);            
        }

    }
}
