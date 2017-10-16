using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Items
{
    public class Tools :Item
    {
        int toolsType; // 1 - hoe // 2- kettle // 3 - ax // 4 - fishing rod
        float damage;

        public Tools(string id, Map map, Vector2 position, string name, Texture2D texture, int type, int price, string introduction)
            : base(id, map, position, name, texture, price, introduction)
        {
            toolsType = type;
            this.Category = "Tool";
            base.CurrentFrame = new Point(0, (toolsType - 1));

            if (this.toolsType == 3)
            {
                damage = 10f;
            }
            else
            {
                damage = 0f;
            }
            IsEquipment = true;
        }



        public float Damage
        {
            get 
            {
                return damage;
            }
        }

        public int ToolsType
        {
            get { return toolsType; }
        }

    }
}
