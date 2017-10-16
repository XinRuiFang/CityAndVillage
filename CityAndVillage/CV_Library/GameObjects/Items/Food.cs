using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Items
{
    public class Food : Item
    {
        int foodType; // 1 - fruit 


        public Food(string id, Map map, Vector2 position, string name, Texture2D texture, int type, int price, Point currentFrame, string introduction)
            : base(id, map, position, name, texture, price, introduction)
        {
            foodType = type;
            this.Category = "Food";
            base.CurrentFrame = currentFrame;

            IsEquipment = false;
        }


        public int FoodType
        {
            get { return foodType; }
        }

    }
}
