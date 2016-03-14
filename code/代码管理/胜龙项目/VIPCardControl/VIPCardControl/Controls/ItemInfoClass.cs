using System;
using System.Collections.Generic;
using System.Text;

namespace UFIDA.Retail.VIPCardControl
{
    public class ItemInfoClass
    {
        private string _itemcode;

        public string Itemcode
        {
            get { return _itemcode; }
            set { _itemcode = value; }
        }
        
        private string _itemname;

        public string Itemname
        {
            get { return _itemname; }
            set { _itemname = value; }
        }

        private string _itemunitname;

        public string Itemunitname
        {
            get { return _itemunitname; }
            set { _itemunitname = value; }
        }

        private string _itemSpec;

        public string ItemSpec
        {
            get { return _itemSpec; }
            set { _itemSpec = value; }
        }

        private string _itemcFree1;

        public string ItemcFree1
        {
            get { return _itemcFree1; }
            set { _itemcFree1 = value; }
        }

        private string _itemcFree2;

        public string ItemcFree2
        {
            get { return _itemcFree2; }
            set { _itemcFree2 = value; }
        }
    }
}
