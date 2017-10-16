using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Items
{
    public class Materials : Item
    {
        public Materials(string id, Map map, Vector2 position, string name, Texture2D texture, int price, Point currentFrame, string introduction)
            : base(id, map, position, name, texture, price, introduction)
        {
            this.Category = "Materials";
            base.CurrentFrame = currentFrame;

            IsEquipment = false;
        }
    }
}
