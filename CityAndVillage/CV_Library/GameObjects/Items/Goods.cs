using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Items
{
    public class Goods : GameObject
    {
        public Goods(Item item,int count,float discount,bool isSaling = false)
        {
            this.item = item;
            this.count = count;

            this.renderRectangle = new Rectangle(0, 0, 189, 49);
            this.scale = 1;
            this.purchasingCount = 0;
            this.discount = discount;
            this.isSelecting = false;

            if (isSaling)
            {
                Random ran = new Random();
                this.discount = ran.Next(70, 100) / 100f;
            }

            if (this.discount < 1f)
            {
                forSaling = true;
            }
        }

        Item item;
        int count;
        int purchasingCount;
        bool forSaling;
        float discount;
        bool isSelecting;
        public static Goods Null = null;

        public bool IsSelecting
        {
            get { return isSelecting; }
            set { isSelecting = value; }
        }

        public float Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public bool ForSaling
        {
            get { return forSaling; }
            set { forSaling = value; }
        }

        public int PurchasingCount
        {
            get { return purchasingCount; }
            set { purchasingCount = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public Item Item
        {
            get { return item; }
            set { item = value; }
        }
    }
}
