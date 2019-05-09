using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Repositoty
{
    public class ClassCurrency : ClassNotify
    {
        private string _USD;
        private string _EUR;
        private Dictionary<string, string> _currencyIdName;

        private Dictionary<string, decimal> _rates;

        public ClassCurrency()
        {

        }  

        

        public string EUR
        {
            get { return _EUR; }
            set
            {
                if (value != _EUR)
                {
                    _EUR = value;
                    Notify("EUR");
                }
            }
        }

        public string USD
        {
            get { return _USD; }
            set
            {
                if (value != _USD)
                {
                    _USD = value;
                    Notify("USD");
                }
            }
        }
        
        public Dictionary<string, string> currencyIdName
        {
            get { return _currencyIdName; }
            set
            {
                if (value != _currencyIdName)
                {
                    _currencyIdName = value;
                    Notify("currencyIdName");
                }
            }
        }


        public string disclaimer { get; set; }
        public string license { get; set; }
        public long timestamp { get; set; }
        [JsonProperty(PropertyName = "base")]
        public string Base { get; set; }
        public Dictionary<string, decimal> rates
        {
            get
            {
                return _rates;
            }
            set
            {
                _rates = value;
                SetValutaValueInProperty();
            }
        }

        private void SetValutaValueInProperty()
        {
            decimal KRkurs = rates["DKK"];
            USD = ((1 / rates["USD"]) * KRkurs).ToString("##0.0000");
            EUR = ((1 / rates["EUR"]) * KRkurs).ToString("##0.0000");
           
        }
    }
}
