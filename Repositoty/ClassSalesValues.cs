using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoty
{
    public class ClassSalesValues : ClassNotify
    {
        private ClassCurrency _classCurrency;
        private int _id;
        private int _customerID;
        private int _artID;
        private string _customersBidUSD;
        private string _customersBidEUR;
        private string _customersBidOwnValuta;
        private string _priceWithFeesUSD;
        private string _priceWithFeesEUR;
        private string _priceWithFeesOwnValuta;
        private string _date;


        public ClassSalesValues()
        {
            
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



        public int id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    Notify("id");
                }
            }
        }



        public int customerID
        {
            get { return _customerID; }
            set
            {
                if (value != _customerID)
                {
                    _customerID = value;
                    Notify("customerID");
                }
            }
        }



        public int artID
        {
            get { return _artID; }
            set
            {
                if (value != _artID)
                {
                    _artID = value;
                    Notify("artID");
                }
            }
        }



        public string customersBidUSD
        {
            get { return _customersBidUSD; }
            set
            {
                if (value != _customersBidUSD)
                {
                    _customersBidUSD = value;
                    Notify("customersBidUSD");
                }
            }
        }



        public string customersBidEUR
        {
            get { return _customersBidEUR; }
            set
            {
                if (value != _customersBidEUR)
                {
                    _customersBidEUR = value;
                    Notify("customersBidEUR");
                }
            }
        }



        public string customersBidOwnValuta
        {
            get { return _customersBidOwnValuta; }
            set
            {
                if (value != _customersBidOwnValuta)
                {
                    _customersBidOwnValuta = value;
                    Notify("customersBidOwnValuta");
                }
            }
        }



        public string priceWithFeesUSD
        {
            get { return _priceWithFeesUSD; }
            set
            {
                if (value != _priceWithFeesUSD)
                {
                    _priceWithFeesUSD = value;
                    Notify("priceWithFeesUSD");
                }
            }
        }



        public string priceWithFeesEUR
        {
            get { return _priceWithFeesEUR; }
            set
            {
                if (value != _priceWithFeesEUR)
                {
                    _priceWithFeesEUR = value;
                    Notify("priceWithFeesEUR");
                }
            }
        }



        public string priceWithFeesOwnValuta
        {
            get { return _priceWithFeesOwnValuta; }
            set
            {
                if (value != _priceWithFeesOwnValuta)
                {
                    _priceWithFeesOwnValuta = value;
                    Notify("priceWithFeesOwnValuta");
                }
            }
        }



        public string date
        {
            get { return _date; }
            set
            {
                if (value != _date)
                {
                    _date = value;
                    Notify("date");
                }
            }
        }

        private void CalculateAll()
        {   
                decimal valutaRateOvnValuta = classCurrency.rates[currencyID];
                decimal.TryParse(bidUSD, out decimal calckUSD);
                decimal valutaRateEUR = classCurrency.rates["EUR"];
                decimal KRkurs = classCurrency.rates["DKK"];

                bidEUR = (calckUSD * valutaRateEUR).ToString("#,##0.00");
                bidOwnValuta = (calckUSD * valutaRateOvnValuta).ToString("#,##0.00");

                priceWithFeeUSD = (calckUSD * 1.075M).ToString("#,##0.00");
                priceWithFeeEUR = ((calckUSD * valutaRateEUR) * 1.075M).ToString("#,##0.00");
                priceWithFeeOwnValuta = ((calckUSD * valutaRateOvnValuta) * 1.075M).ToString("#,##0.00");
        }
    }
}
