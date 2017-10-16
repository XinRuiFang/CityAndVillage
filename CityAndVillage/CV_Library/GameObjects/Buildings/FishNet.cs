using CV_Library.Controllers;
using CV_Library.GameObjects.Items;
using CV_Library.Globals;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Buildings
{
    public class FishNet : Construction, IPlayerScene
    {
        bool showBoard;
        UIFrame detailBoard;
        List<Fish> fishList;
        bool showBanner;
        Fish bannerFish;
        bool hasAddBtn;

        public FishNet(Texture2D texture, Map map, Vector2 position, Point size)
            : base(map, position, texture, size, "fishnet")
        {
            this.texture = texture;
            this.map = map;
            this.position = position;
            this.showBoard = false;
            this.showBanner = false;
            this.hasAddBtn = false;
            this.bannerFish = Fish.Null;
            this.detailBoard = new UIFrame(new Point(0, 47), new Vector2((Define.windowWidth - 6 * Define.UnitOFpixel) / 2, (Define.windowHeight - 10 * Define.UnitOFpixel) / 2), new Rectangle(0, 0, 6 * Define.UnitOFpixel, 10 * Define.UnitOFpixel), 0.8f, Color.White);

            this.renderRectangle = new Rectangle(288, 1248, 3 * Define.UnitOFpixel, 3 * Define.UnitOFpixel);
            this.fishList = new List<Fish>();
        }

        public void InitFishList()
        {
 
        }

        public Rectangle RenderRectangle
        {
            get
            {
                return renderRectangle;
            }
        }

        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(position, GlobalController.Camera); }
        }

        public float LayerDepth
        {
            get
            {
                return (1f * this.position.Y + 2 * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }

        public List<Fish> FishList
        {
            get { return fishList; }
            set { fishList = value; }
        }
        public void ShowBoard()
        {
            showBoard = true;
            GlobalController.Isshopping = true; 
        }
        public void CloseBoard()
        {
            showBoard = false;
            hasAddBtn = false;
            GlobalController.Isshopping = false; 
        }

        public void WithDraw()
        {
            foreach (Fish item in fishList)
            {
                GlobalController._Cv_func._Global_AddNewItemToBag(item);
            }
            GlobalController.PlayerSceneList.Remove(this);
        }

        void ShowFishDetails(Microsoft.Xna.Framework.Graphics.SpriteBatch b, int i, Fish fish)
        {
            Vector2 mousePos = GlobalController.Mouse.Position / 2;
            

            if (i % 2 == 0)
            {
                b.Draw(fish.Texture, new Vector2(detailBoard.Pos.X + 3 + 3 + 2, detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16 + 3), fish.RenderRectangle, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, detailBoard.LayerDepth + 0.002f);
                if (mousePos.X >= detailBoard.Pos.X + 3 + 3 && mousePos.X <= detailBoard.Pos.X + 3 + 3 + 15 && mousePos.Y >= detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16 && mousePos.Y <= detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16 + 15)
                {
                    showBanner = true;
                    bannerFish = fishList[i];
                }
                if (mousePos.X >= detailBoard.Pos.X + 3 + 3 + 39 && mousePos.X <= detailBoard.Pos.X + 3 + 3 + 39 + 22 && mousePos.Y >= detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16 && mousePos.Y <= detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16 + 16)
                {
                    b.Draw(this.Texture, new Vector2(detailBoard.Pos.X + 3 + 3, detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16), new Rectangle(10 * Define.UnitOFpixel, 51 * Define.UnitOFpixel, 61, 16), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, detailBoard.LayerDepth + 0.001f);
                    if (GlobalController.MouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && GlobalController.LastMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                    {
                        GlobalController._Cv_func._Global_AddNewItemToBag(fishList[i]);
                        fishList.Remove(fishList[i]);
                        return;
                    }
                }
                else
                {
                    b.Draw(this.Texture, new Vector2(detailBoard.Pos.X + 3 + 3, detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16), new Rectangle(7 * Define.UnitOFpixel, 51 * Define.UnitOFpixel, 61, 16), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, detailBoard.LayerDepth + 0.001f);
                }               

            }
            if (i % 2 == 1)
            {
                b.Draw(fish.Texture, new Vector2(detailBoard.Pos.X + 3 + 3 + 61 + 8 + 2, detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16 + 3), fish.RenderRectangle, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, detailBoard.LayerDepth + 0.002f);
                if (mousePos.X >= detailBoard.Pos.X + 3 + 3 + 61 + 8 && mousePos.X <= detailBoard.Pos.X + 3 + 3 + 61 + 8 + 15 && mousePos.Y >= detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16 && mousePos.Y <= detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16 + 15)
                {
                    showBanner = true;
                    bannerFish = fishList[i];
                }
                if (mousePos.X >= detailBoard.Pos.X + 3 + 3 + 61 + 8 + 39 && mousePos.X <= detailBoard.Pos.X + 3 + 3 + 61 + 8 + 39 + 22 && mousePos.Y >= detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16 && mousePos.Y <= detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16 + 16)
                {
                    b.Draw(this.Texture, new Vector2(detailBoard.Pos.X + 3 + 3 + 61 + 8, detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16), new Rectangle(10 * Define.UnitOFpixel, 51 * Define.UnitOFpixel, 61, 16), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, detailBoard.LayerDepth + 0.001f);
                    if (GlobalController.MouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released && GlobalController.LastMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                    {                       
                        GlobalController._Cv_func._Global_AddNewItemToBag(fishList[i]);
                        fishList.Remove(fishList[i]);
                        return;
                    }
                }
                else
                {
                    b.Draw(this.Texture, new Vector2(detailBoard.Pos.X + 3 + 3 + 61 + 8, detailBoard.Pos.Y + 3 + (i / 2 + 1) * 4 + i / 2 * 16), new Rectangle(7 * Define.UnitOFpixel, 51 * Define.UnitOFpixel, 61, 16), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, detailBoard.LayerDepth + 0.001f);
                }
                
               
            }
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b)
        {
            b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
            if (showBoard)
            {
                b.Draw(this.Texture, detailBoard.Pos, detailBoard.Rect, detailBoard.Color, 0, Vector2.Zero, 1, SpriteEffects.None, detailBoard.LayerDepth);
                if (!hasAddBtn)
                {
                    GlobalController.buttonList.Add(new Button(ResourceController.UI_ordinary, "1", "FishNet", 0.81f, new Vector2(detailBoard.Pos.X * 2 + 12 * Define.UnitOFpixel - 8 - 16, detailBoard.Pos.Y * 2 - 8 - 16)));
                    GlobalController.buttonList.Add(new Button(ResourceController.UI_ordinary, "2_2", "FishNet", 0.81f, new Vector2(detailBoard.Pos.X * 2 + 48 * 2, detailBoard.Pos.Y * 2 + 205 * 2)));
                    hasAddBtn = true;
                }
                showBanner = false;
                bannerFish = Fish.Null;
                for (int i = 0; i < fishList.Count; i++)
                {
                    ShowFishDetails(b, i, fishList[i]);
                }
                if (showBanner)
                {
                    b.Draw(this.Texture, GlobalController.Mouse.Position / 2, new Rectangle(7 * Define.UnitOFpixel, 47 * Define.UnitOFpixel, 4 * Define.UnitOFpixel, 4 * Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, detailBoard.LayerDepth + 0.003f);
                    b.Draw(bannerFish.Texture, new Vector2(GlobalController.Mouse.Position.X / 2 + 7, GlobalController.Mouse.Position.Y / 2 + 6), bannerFish.RenderRectangle, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, detailBoard.LayerDepth + 0.004f);
                    Fonts.DrawSysFont(bannerFish.Name, new Vector2(GlobalController.Mouse.Position.X / 2 + 37, GlobalController.Mouse.Position.Y / 2 + 6), b, Color.Black, detailBoard.LayerDepth + 0.004f, 0.5f, 30);
                }
            }
        }

        public override GameObject GetInstance()
        {
            return this;
        }

        public override string GetSaveParameter()
        {
            return this.map.Name + "|" + this.position.X + "|" + this.position.Y + "|" + this.name;
        }

        public override Microsoft.Xna.Framework.Rectangle[] GetEffiveClickArea()
        {
            return new Rectangle[]
            {
                new Rectangle((int)this.position.X,(int)this.position.Y,3 * Define.UnitOFpixel,3 * Define.UnitOFpixel)
            };
        }

        public override Rectangle[] GetColliders()
        {
            return new Rectangle[] { };
        }
    }
}
