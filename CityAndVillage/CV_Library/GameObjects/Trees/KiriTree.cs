using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Trees
{
    public class KiriTree : Tree
    {
        public KiriTree(Map map, Vector2 position, Texture2D texture,Texture2D shadow,bool canCrop)
        {
            currentFrame = new Point(0, 1); //当前帧图
            sheetSize = new Point(12, 21);
            this.position = position;
            this.rootPosition = position;
            this.rotationPoint = new Vector2(position.X + 2.5f, position.Y + 6.5f);
            this.collider = new Rectangle((int)position.X * Define.UnitOFpixel, (int)position.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel);
            this.map = map;
            this.texture = texture;
            this.shadow = shadow;
            this.canCrop = canCrop;
            base.name = "KiriTree";
        }

    }
}
