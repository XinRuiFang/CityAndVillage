using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Items
{
    public class Property : Item
    {
        bool isConstruct;

        public Property(string id, Map map, Vector2 position, string name, Texture2D texture, int price, Point currentFrame, string introduction)
            : base(id, map, position, name, texture, price, introduction)
        {
            this.Category = "Property";
            base.CurrentFrame = currentFrame;
            this.isConstruct = false;

            if (id == "04_002")
            {
                this.isConstruct = true;
            }

            IsEquipment = false;
        }

        public void UsingProperty()
        {
            if (this.Id == "04_001")
            {
                Crystal_ball();
            }
        }

        void Crystal_ball()
        {
            GameController.SavePlayerFile();
        }

        public bool IsConstruct
        {
            get { return isConstruct; }
            set { isConstruct = value; }
        }
    }
}
