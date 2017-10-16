using CV_Library.GameObjects.Items;
using CV_Library.Globals;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Characters
{
    public class Shops : GameObject,IPlayerScene
    {
        string name;
        List<Goods> goodsList;
        Texture2D logoTexture;
        int index;
        Rectangle saleRect;
        Goods isSelecting;
        bool arrowUp;
        bool arrowDown;



        public Shops(Texture2D texture,Texture2D logoTexture, Map map,string name)
        {
            this.texture = texture;
            this.logoTexture = logoTexture;
            this.map = map;
            this.name = name;
            this.goodsList = new List<Goods>();
            index = 0;
            saleRect = new Rectangle(17 * Define.UnitOFpixel, 37 * Define.UnitOFpixel, 2 * Define.UnitOFpixel, Define.UnitOFpixel);
            isSelecting = Goods.Null;
            this.arrowUp = true;
            this.arrowDown = true;
        }

        public bool ArrowUp
        {
            get { return arrowUp; }
            set { arrowUp = value; }
        }
        public bool ArrowDown
        {
            get { return arrowDown; }
            set { arrowDown = value; }
        }
        public Goods IsSelecting
        {
            get { return isSelecting; }
            set { isSelecting = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public List<Goods> GoodsList
        {
            get { return goodsList; }
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public Rectangle SaleRect
        {
            get { return saleRect; }
            set { saleRect = value; }
        }

        public string GetMap()
        {
            return this.Map.Name;
        }

        public void Unload()
        {
            for (int i = 0; i < this.goodsList.Count; i++)
            {
                this.GoodsList[i].PurchasingCount = 0;
                this.GoodsList[i].IsSelecting = false;               
            }
            this.IsSelecting = Goods.Null;
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(this.Texture, new Vector2(Define.windowWidth - 17 * Define.UnitOFpixel, Define.windowHeight - 10 * Define.UnitOFpixel), new Rectangle(0, 37 * Define.UnitOFpixel, 17 * Define.UnitOFpixel, 10 * Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0.8f);
            switch (this.Name)
            {
                case "Village_seedshop":
                    b.Draw(this.logoTexture, new Vector2(Define.windowWidth - 17 * Define.UnitOFpixel - 60, Define.windowHeight - 10 * Define.UnitOFpixel - 30), new Rectangle(0, 0, 8 * Define.UnitOFpixel, 4 * Define.UnitOFpixel), Color.White, -0.1f, Vector2.Zero, 1, SpriteEffects.None, 0.83f);
                    break;
                default:
                    break;
            }

        }
        public void DrawNoGoods(SpriteBatch b,Vector2 position)
        {
            b.Draw(this.Texture, position, new Rectangle(16 * Define.UnitOFpixel, 28 * Define.UnitOFpixel, 4 * Define.UnitOFpixel, 1 * Define.UnitOFpixel), Color.White, -0.05f, Vector2.Zero, 2, SpriteEffects.None, 0.81f);
        }
        public void DrawNoInventory(SpriteBatch b, Vector2 position)
        {
            b.Draw(this.Texture, position, new Rectangle(16 * Define.UnitOFpixel, 27 * Define.UnitOFpixel, 5 * Define.UnitOFpixel, 1 * Define.UnitOFpixel), Color.White, -0.05f, Vector2.Zero, 2, SpriteEffects.None, 0.822f);
        }

        public void DrawSale(SpriteBatch b, Vector2 position)
        {
            b.Draw(this.Texture, position, this.saleRect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.822f);
        }

        public void DrawMoneyIcon(SpriteBatch b, Vector2 position)
        {
            b.Draw(this.Texture, position, new Rectangle(19 * Define.UnitOFpixel, 37 * Define.UnitOFpixel, 1 * Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.822f);
        }

        public void DrawAddtion(SpriteBatch b, Vector2 position)
        {
            b.Draw(this.Texture, new Vector2(position.X + 57, position.Y), new Rectangle(20 * Define.UnitOFpixel, 37 * Define.UnitOFpixel, 1 * Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0.822f);
            b.Draw(this.Texture, position, new Rectangle(19 * Define.UnitOFpixel, 38 * Define.UnitOFpixel, 1 * Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0.822f);
        }
        public void DrawSmallPic(SpriteBatch b, Vector2 position, Goods good)
        {
            b.Draw(this.Texture, position, new Rectangle(17 * Define.UnitOFpixel, 41 * Define.UnitOFpixel, 1 * Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0.81f);
            b.Draw(good.Item.Texture,new Vector2(position.X + 4,position.Y + 2),good.Item.RenderRectangle, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.811f);
        }
        public void DrawArrows(SpriteBatch b)
        {
            if (ArrowUp)
            {
                b.Draw(this.Texture, new Vector2(Define.windowWidth - 408 + 432, Define.windowHeight - 240 + 40), new Rectangle(17 * Define.UnitOFpixel, 39 * Define.UnitOFpixel, 1 * Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.822f);
            }
            else
            {
                b.Draw(this.Texture, new Vector2(Define.windowWidth - 408 + 432, Define.windowHeight - 240 + 42), new Rectangle(17 * Define.UnitOFpixel, 39 * Define.UnitOFpixel, 1 * Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.822f);
            }
            if (ArrowDown)
            {
                b.Draw(this.Texture, new Vector2(Define.windowWidth - 408 + 432, Define.windowHeight - 240 + 365), new Rectangle(18 * Define.UnitOFpixel, 39 * Define.UnitOFpixel, 1 * Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.822f);
            }
            else
            {
                b.Draw(this.Texture, new Vector2(Define.windowWidth - 408 + 432, Define.windowHeight - 240 + 363), new Rectangle(18 * Define.UnitOFpixel, 39 * Define.UnitOFpixel, 1 * Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.822f);
            }
        }
        public void DrawIntroduction(SpriteBatch b)
        {
            if (this.IsSelecting != Goods.Null)
            {
                b.Draw(this.Texture, new Vector2(Define.windowWidth - 408 + 494, Define.windowHeight - 240 + 56), new Rectangle(19 * Define.UnitOFpixel, 39 * Define.UnitOFpixel, 2 * Define.UnitOFpixel, 2 * Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0.81f);
                b.Draw(this.IsSelecting.Item.Texture, new Vector2(Define.windowWidth - 408 + 500, Define.windowHeight - 240 + 60), this.IsSelecting.Item.RenderRectangle, this.IsSelecting.Item.RenderColor, this.IsSelecting.Item.Rotation, this.IsSelecting.Item.Origin, 2, this.IsSelecting.Item.SpriteEffects, 0.811f);
                Fonts.DrawString(this.IsSelecting.Item.Name, new Vector2(Define.windowWidth + 155, Define.windowHeight - 180), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.815f, 1f, 30);
                Fonts.DrawSysFont(this.IsSelecting.Item.Category, new Vector2(Define.windowWidth + 155, Define.windowHeight - 160), b, Color.Green, 0.815f, 1, 30);
                Fonts.DrawSysFont("Inventory:" + this.IsSelecting.Count, new Vector2(Define.windowWidth + 155, Define.windowHeight - 140), b, Color.Black, 0.815f, 1, 30);
                Fonts.DrawSysFont(this.IsSelecting.Item.Introduction, new Vector2(Define.windowWidth + 95, Define.windowHeight - 115), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.815f, 1, 25);
            }
        }

        public Microsoft.Xna.Framework.Rectangle GetCollider()
        {
            throw new NotImplementedException();
        }

        public GameObject GetInstance()
        {
            return this;
        }

        public string GetIntanceType()
        {
            return "Shops";
        }

        public string GetSaveParameter()
        {
            throw new NotImplementedException();
        }

        public Microsoft.Xna.Framework.Rectangle[] GetEffiveClickArea()
        {
            throw new NotImplementedException();
        }

        public void AddGoods(Goods good)
        {
            this.goodsList.Add(good);
        }
    }
}
