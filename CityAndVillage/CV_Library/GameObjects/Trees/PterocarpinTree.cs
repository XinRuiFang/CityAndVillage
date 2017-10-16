using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class PterocarpinTree : Tree
    {
        public PterocarpinTree(Map map, Vector2 position, Texture2D texture, Texture2D shadow, bool canCrop)
        {
            currentFrame = new Point(3, 0);
            sheetSize = new Point(12, 21);
            this.position = position;
            this.rootPosition = position;
            this.rotationPoint = new Vector2(position.X + 2.5f, position.Y + 6.5f);
            this.collider = new Rectangle((int)position.X * Define.UnitOFpixel, (int)position.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel);
            this.map = map;
            this.texture = texture;
            this.shadow = shadow;
            this.canCrop = canCrop;
            base.name = "PterocarpinTree";
            base.hp = 100;
        }
       
    }
}
