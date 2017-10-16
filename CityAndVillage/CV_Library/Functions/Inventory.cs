using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Inventory
    {
        public Inventory(Item item, bool isNull,int index,int count)
        {
            this.item = item;
            this.isNull = isNull;
            this.index = index;
            this.count = count;
        }
        int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        int index;

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        Item item;

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }

        bool isNull;

        public bool IsNull
        {
            get { return isNull; }
            set { isNull = value; }
        }

        public void Clear()
        {
            this.item = null;
            this.isNull = true;
            this.count = 0;
        }

        public void AddItem(Item item,int count)
        {
            this.Item = item;
            this.isNull = false;
            this.count = count;
        }
    }
}
