using CV_Library.Controllers;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Buildings
{
    public class Building : GameObject, IGlobalScene
    {
        Point currentFrame;
        Point sheetSize;

        Rectangle[] colliders = new Rectangle[5];
        string[] targetScene = new string[5];
        Rectangle[] doorTrigger = new Rectangle[5];

        Rectangle topRenderRect;
        Rectangle bottomRenderRect;

        bool isPlayerBehind;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="position"></param>
        /// <param name="texture"></param>
        /// <param name="topSize">上部大小</param>
        /// <param name="bottomSize">下部大小</param>
        /// <param name="colliders">碰撞器左上角距离整体左上角的距离和碰撞器大小</param>
        /// <param name="doorTrigger">触发器左上角距离整体左上角的距离和触发器大小</param>
        /// <param name="targetName"></param>

        public Building(Map map, Vector2 position, Texture2D texture, Rectangle topSize, Rectangle bottomSize, Rectangle[] colliders, Rectangle[] doorTrigger, string[] targetName)
        {
            this.map = map;
            this.position = new Vector2(position.X * Define.UnitOFpixel, (position.Y - topSize.Height) * Define.UnitOFpixel);
            this.texture = texture;

            this.scale =1;
            this.topRenderRect = new Rectangle(topSize.X * Define.UnitOFpixel,topSize.Y * Define.UnitOFpixel,topSize.Width * Define.UnitOFpixel,topSize.Height * Define.UnitOFpixel);
            this.bottomRenderRect = new Rectangle(bottomSize.X * Define.UnitOFpixel, bottomSize.Y * Define.UnitOFpixel, bottomSize.Width * Define.UnitOFpixel, bottomSize.Height * Define.UnitOFpixel);
            this.isPlayerBehind = false;

            for (int i = 0; i < colliders.Length; i++)
            {
                this.colliders[i] = new Rectangle((int)(colliders[i].X + this.position.X), (int)(colliders[i].Y + this.position.Y + Define.UnitOFpixel), colliders[i].Width, colliders[i].Height);
            }

            for (int i = 0; i < doorTrigger.Length; i++)
            {
                this.doorTrigger[i] = new Rectangle((int)(this.position.X + doorTrigger[i].X * Define.UnitOFpixel), (int)(this.position.Y + doorTrigger[i].Y * Define.UnitOFpixel),doorTrigger[i].Width * Define.UnitOFpixel,doorTrigger[i].Height * Define.UnitOFpixel);
            }
 
            this.targetScene = targetName;
        }
        public static Building Null = null;
        public static Building CreateBuildingFactory(Map map,Vector2 position, string buildingName)
        {
            switch (buildingName)
            {
                case "village_ambifarm":
                    return new Building(map, position, ResourceController.Buildings_village_ambifarm, new Rectangle(0, 0, 32, 7), new Rectangle(0, 7, 32, 8), new Rectangle[] { new Rectangle(24, 168, 720, 96), new Rectangle(216, 264, 144, 48), new Rectangle(216, 312, 24, 24), new Rectangle(336, 312, 24, 24) }, new Rectangle[] { new Rectangle() }, new string[] { "" });
                case "village_barn":
                    return new Building(map, position, ResourceController.Buildings_village_barn, new Rectangle(0, 0, 10, 11), new Rectangle(0, 11, 10, 4), new Rectangle[] { new Rectangle(24, 144, 192, 192) }, new Rectangle[] { new Rectangle() }, new string[] { "" });
                case "village_clinic":
                    return new Building(map, position, ResourceController.Buildings_village_clinic, new Rectangle(0, 0, 13, 6), new Rectangle(0, 6, 13, 6), new Rectangle[] { new Rectangle(24, 144, 288, 96), new Rectangle(96, 240, 144, 48) }, new Rectangle[] { new Rectangle() }, new string[] { "" });
                case "village_farmhouse":
                    return new Building(map, position, ResourceController.Buildings_village_farmhouse, new Rectangle(0, 0, 13, 6), new Rectangle(0, 6, 13, 8), new Rectangle[] { new Rectangle(24, 144, 264, 120) }, new Rectangle[] { new Rectangle(9, 9, 1, 2) }, new string[] { "village_farmhouse" });
                case "village_farmhouseA":
                    return new Building(map, position, ResourceController.Buildings_village_farmhouseA, new Rectangle(0, 0, 21, 8), new Rectangle(0, 8, 21, 10), new Rectangle[] { new Rectangle(48, 192, 408, 144), new Rectangle(48, 336, 312, 24), new Rectangle(48, 360, 96, 48), new Rectangle(192, 360, 24, 24), new Rectangle(264, 360, 24, 24) }, new Rectangle[] { new Rectangle() }, new string[] { "" });
                case "village_farmhouseB":
                    return new Building(map, position, ResourceController.Buildings_village_farmhouseB, new Rectangle(0, 0, 20, 5), new Rectangle(0, 5, 20, 7), new Rectangle[] { new Rectangle(24, 120, 432, 120), new Rectangle(24, 240, 144, 24), new Rectangle(312, 240, 144, 24), new Rectangle(192, 240, 24, 24), new Rectangle(264, 240, 24, 24) }, new Rectangle[] { new Rectangle() }, new string[] { "" });
                case "village_farmhouseC":
                    return new Building(map, position, ResourceController.Buildings_village_farmhouseC, new Rectangle(0, 0, 17, 6), new Rectangle(0, 6, 17, 5), new Rectangle[] { new Rectangle(24, 144, 360, 96) }, new Rectangle[] { new Rectangle() }, new string[] { "" });
                case "village_hotel":
                    return new Building(map, position, ResourceController.Buildings_village_hotel, new Rectangle(0, 0, 15, 3), new Rectangle(0, 3, 15, 9), new Rectangle[] { new Rectangle(24, 72, 312, 96), new Rectangle(192, 168, 144, 111) }, new Rectangle[] { }, new string[] { "" });
                case "village_house1":
                    return new Building(map, position, ResourceController.Buildings_village_house1, new Rectangle(0, 0, 11, 3), new Rectangle(0, 3, 11, 6), new Rectangle[] { new Rectangle(24, 72, 240, 96) }, new Rectangle[] { }, new string[] { "" });
                case "village_house2":
                    return new Building(map, position, ResourceController.Buildings_village_house2, new Rectangle(0, 0, 11, 5), new Rectangle(0, 5, 11, 5), new Rectangle[] { new Rectangle(24, 120, 216, 48), new Rectangle(24, 168, 96, 48) }, new Rectangle[] { }, new string[] { "" });
                case "village_house3":
                    return new Building(map, position, ResourceController.Buildings_village_house3, new Rectangle(0, 0, 10, 7), new Rectangle(0, 7, 10, 6), new Rectangle[] { new Rectangle(24, 168, 192, 120) }, new Rectangle[] { }, new string[] { "" });
                case "village_house4":
                    return new Building(map, position, ResourceController.Buildings_village_house4, new Rectangle(0, 0, 12, 4), new Rectangle(0, 4, 12, 6), new Rectangle[] { new Rectangle(24, 96, 240, 96) }, new Rectangle[] { }, new string[] { "" });
                case "village_house5":
                    return new Building(map, position, ResourceController.Buildings_village_house5, new Rectangle(0, 0, 11, 4), new Rectangle(0, 4, 11, 6), new Rectangle[] { new Rectangle(24, 96, 216, 72), new Rectangle(24, 168, 96, 48) }, new Rectangle[] { }, new string[] { "" });
                case "village_house6":
                    return new Building(map, position, ResourceController.Buildings_village_house6, new Rectangle(0, 0, 17, 5), new Rectangle(0, 5, 17, 8), new Rectangle[] { new Rectangle(24, 120, 360, 120) }, new Rectangle[] { }, new string[] { "" });
                case "village_house7":
                    return new Building(map, position, ResourceController.Buildings_village_house7, new Rectangle(0, 0, 17, 5), new Rectangle(0, 5, 17, 6), new Rectangle[] { new Rectangle(24, 120, 360, 72), new Rectangle(24, 192, 144, 48) }, new Rectangle[] { }, new string[] { "" });
                case "village_house8":
                    return new Building(map, position, ResourceController.Buildings_village_house8, new Rectangle(0, 0, 13, 4), new Rectangle(0, 4, 13, 6), new Rectangle[] { new Rectangle(24, 96, 264, 72), new Rectangle(96, 168, 120, 24) }, new Rectangle[] { }, new string[] { "" });
                case "village_managehouse":
                    return new Building(map, position, ResourceController.Buildings_village_managehouse, new Rectangle(0, 0, 15, 5), new Rectangle(0, 5, 15, 5), new Rectangle[] { new Rectangle(24, 120, 312, 72), new Rectangle(120, 92, 120, 24) }, new Rectangle[] { }, new string[] { "" });
                case "village_purchasingstation":
                    return new Building(map, position, ResourceController.Buildings_village_purchasingstation, new Rectangle(0, 0, 13, 4), new Rectangle(0, 4, 13, 4), new Rectangle[] { new Rectangle(24, 96, 264, 72) }, new Rectangle[] { }, new string[] { "" });
                case "village_restaurant":
                    return new Building(map, position, ResourceController.Buildings_village_restaurant, new Rectangle(0, 0, 17, 6), new Rectangle(0, 6, 17, 8), new Rectangle[] { new Rectangle(24, 144, 384, 96), new Rectangle(24, 240, 192, 72) }, new Rectangle[] { }, new string[] { "" });
                case "village_shop":
                    return new Building(map, position, ResourceController.Buildings_village_shop, new Rectangle(0, 0, 11, 4), new Rectangle(0, 4, 11, 5), new Rectangle[] { new Rectangle(24, 96, 240, 96) }, new Rectangle[] { }, new string[] { "" });
                case "village_toolhouse":
                    return new Building(map, position, ResourceController.Buildings_village_toolhouse, new Rectangle(0, 0, 10, 5), new Rectangle(0, 5, 10, 6), new Rectangle[] { new Rectangle(24, 120, 192, 120) }, new Rectangle[] { }, new string[] { "" });
                case "town_station":
                    return new Building(map, position, ResourceController.Buildings_town_station, new Rectangle(0, 0, 14, 4), new Rectangle(0, 4, 14, 7), new Rectangle[] { new Rectangle(24, 96, 288, 96), new Rectangle(144, 192, 168, 48) }, new Rectangle[] { }, new string[] { "" });
                case "town_bathroom":
                    return new Building(map, position, ResourceController.Buildings_town_bathroom, new Rectangle(0, 0, 16, 8), new Rectangle(0, 8, 16, 8), new Rectangle[] { new Rectangle(48, 192, 288, 72), new Rectangle(48, 264, 216, 24), new Rectangle(48, 288, 144, 72) }, new Rectangle[] { }, new string[] { "" });
                case "town_restaurant":
                    return new Building(map, position, ResourceController.Buildings_town_restaurant, new Rectangle(0, 0, 15, 13), new Rectangle(0, 13, 15, 7), new Rectangle[] { new Rectangle(24, 312, 312, 120) }, new Rectangle[] { }, new string[] { "" });
                case "town_personalShop":
                    return new Building(map, position, ResourceController.Buildings_town_personalShop, new Rectangle(0, 0, 13, 4), new Rectangle(0, 4, 13, 7), new Rectangle[] { new Rectangle(24, 96, 264, 72), new Rectangle(48, 168, 168, 72) }, new Rectangle[] { }, new string[] { "" });
                case "town_hotel":
                    return new Building(map, position, ResourceController.Buildings_town_hotel, new Rectangle(0, 0, 15, 5), new Rectangle(0, 5, 15, 13), new Rectangle[] { new Rectangle(24, 120, 312, 96), new Rectangle(96, 216, 168, 72), new Rectangle(24, 288, 312, 96), new Rectangle(24, 384, 120, 24), new Rectangle(216, 384, 120, 24) }, new Rectangle[] { }, new string[] { "" });
                case "town_drink":
                    return new Building(map, position, ResourceController.Buildings_town_drink, new Rectangle(0, 0, 9, 5), new Rectangle(0, 5, 9, 5), new Rectangle[] { new Rectangle(24, 120, 168, 72) }, new Rectangle[] { }, new string[] { "" });
                case "town_shop":
                    return new Building(map, position, ResourceController.Buildings_town_shop, new Rectangle(0, 0, 13, 7), new Rectangle(0, 7, 13, 6), new Rectangle[] { new Rectangle(48, 168, 216, 96) }, new Rectangle[] { }, new string[] { "" });
                case "town_clinic":
                    return new Building(map, position, ResourceController.Buildings_town_clinic, new Rectangle(0, 0, 13, 4), new Rectangle(0, 4, 13, 6), new Rectangle[] { new Rectangle(24, 96, 264, 96) }, new Rectangle[] { }, new string[] { "" });
                case "town_managehouse":
                    return new Building(map, position, ResourceController.Buildings_town_managehouse, new Rectangle(0, 0, 15, 6), new Rectangle(0, 6, 15, 5), new Rectangle[] { new Rectangle(24, 144, 312, 72), new Rectangle(120, 216, 120, 24) }, new Rectangle[] { }, new string[] { "" });
                case "town_house1":
                    return new Building(map, position, ResourceController.Buildings_town_house1, new Rectangle(0, 0, 12, 4), new Rectangle(0, 4, 12, 6), new Rectangle[] { new Rectangle(24, 96, 240, 72), new Rectangle(120, 168, 120, 48) }, new Rectangle[] { }, new string[] { "" });
                case "town_house2":
                    return new Building(map, position, ResourceController.Buildings_town_house2, new Rectangle(0, 0, 11, 4), new Rectangle(0, 4, 11, 6), new Rectangle[] { new Rectangle(24, 96, 216, 96) }, new Rectangle[] { }, new string[] { "" });
                case "town_house3":
                    return new Building(map, position, ResourceController.Buildings_town_house3, new Rectangle(0, 0, 11, 4), new Rectangle(0, 4, 11, 4), new Rectangle[] { new Rectangle(24, 96, 216, 72) }, new Rectangle[] { }, new string[] { "" });
                case "town_house4":
                    return new Building(map, position, ResourceController.Buildings_town_house4, new Rectangle(0, 0, 13, 8), new Rectangle(0, 8, 13, 7), new Rectangle[] { new Rectangle(24, 192, 264, 144) }, new Rectangle[] { }, new string[] { "" });
                case "town_house5":
                    return new Building(map, position, ResourceController.Buildings_town_house5, new Rectangle(0, 0, 14, 4), new Rectangle(0, 4, 14, 7), new Rectangle[] { new Rectangle(24, 96, 288, 72), new Rectangle(168, 168, 144, 72) }, new Rectangle[] { }, new string[] { "" });
                case "town_house6":
                    return new Building(map, position, ResourceController.Buildings_town_house6, new Rectangle(0, 0, 15, 8), new Rectangle(0, 8, 15, 7), new Rectangle[] { new Rectangle(24, 192, 312, 96) }, new Rectangle[] { }, new string[] { "" });
                case "town_house7":
                    return new Building(map, position, ResourceController.Buildings_town_house7, new Rectangle(0, 0, 17, 8), new Rectangle(0, 8, 17, 7), new Rectangle[] { new Rectangle(48, 192, 216, 96), new Rectangle(264, 168, 120, 96) }, new Rectangle[] { }, new string[] { "" });
                case "town_house8":
                    return new Building(map, position, ResourceController.Buildings_town_house8, new Rectangle(0, 0, 16, 8), new Rectangle(0, 8, 16, 7), new Rectangle[] { new Rectangle(24, 192, 336, 96) }, new Rectangle[] { }, new string[] { "" });
                case "town_house9":
                    return new Building(map, position, ResourceController.Buildings_town_house9, new Rectangle(0, 0, 19, 7), new Rectangle(0, 7, 19, 12), new Rectangle[] { new Rectangle(24, 168, 408, 96), new Rectangle(216, 264, 216, 168) }, new Rectangle[] { }, new string[] { "" });
                default:
                    return Building.Null;
            }
        }

        public void TestPlayerVisio()
        {
            Vector2 playerPos = GlobalController.Player.MidPos;
            if (this.position.X < playerPos.X && playerPos.X < this.position.X + this.topRenderRect.Width && this.position.Y < playerPos.Y && playerPos.Y < this.position.Y + this.topRenderRect.Height)
            {
                if (!this.isPlayerBehind)
                {
                    this.isPlayerBehind = true;
                }
            }
            else
            {
                if (this.isPlayerBehind)
                {
                    this.isPlayerBehind = false;
                }
            }
        }

        public Point CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }


        public Point SheetSize
        {
            get { return sheetSize; }
            set { sheetSize = value; }
        }

        public Rectangle TopRenderRect
        {
            get { return topRenderRect; }
            set { topRenderRect = value; }
        }
        public Rectangle BottomRenderRect
        {
            get { return bottomRenderRect; }
            set { bottomRenderRect = value; }
        }

        public Vector2 TopRenderPosition
        {
            get { return Camera.HandlePos(new Vector2(position.X, position.Y), GlobalController.Camera); }
        }
        public Vector2 BottomRenderPosition
        {
            get { return Camera.HandlePos(new Vector2(position.X, position.Y + topRenderRect.Height), GlobalController.Camera); }
        }

        public Rectangle[] DoorTrigger
        {
            get { return doorTrigger; }
            set { doorTrigger = value; }
        }
        
        public Rectangle[] Colliders
        {
            get { return colliders; }
            set { colliders = value; }
        }
        public string[] TargetScene
        {
            get { return targetScene; }
            set { targetScene = value; }
        }


        public string GetMap()
        {
            return this.Map.Name;
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(this.Texture, this.TopRenderPosition, this.TopRenderRect, this.isPlayerBehind ? new Color(1, 1, 1, 0.8f) : this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, 1);
            b.Draw(this.Texture, this.BottomRenderPosition, this.BottomRenderRect, this.isPlayerBehind ? new Color(1, 1, 1, 0.8f) : this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, 0.01f);  
        }

        public Rectangle GetCollider()
        {
            return this.Collider;
        }

        public GameObject GetInstance()
        {
            return this;
        }

        public string GetIntanceType()
        {
            return "Building";
        }
    }
}
