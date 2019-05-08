using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositoty
{
    public class ClassArt : ClassNotify
    {
        private string _picturePath;
        private string _pictureDescription;
        private string _pictureTitel;
        private int _id;

        public ClassArt()
        {

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

        public string pictureTitel
        {
            get { return _pictureTitel; }
            set
            {
                if (value != _pictureTitel)
                {
                    _pictureTitel = value;
                    Notify("pictureTitel");
                }
            }
        }


        public string pictureDescription
        {
            get { return _pictureDescription; }
            set
            {
                if (value != _pictureDescription)
                {
                    _pictureDescription = value;
                    Notify("pictureDescription");
                }
            }
        }


        public string picturePath
        {
            get { return _picturePath; }
            set
            {
                if (value != _picturePath)
                {
                    _picturePath = value;
                    Notify("picturePath");
                }
            }
        }

    }
}
