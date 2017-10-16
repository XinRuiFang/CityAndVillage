using CV_Library.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Functions
{
    public class CharacterTile
    {
        public CharacterTile(int x, int y, string nameLayer1 = "none", string nameLayer2 = "none", string nameLayer3 = "none", string nameLayer4 = "none", string nameLayer5 = "none", string nameLayer6 = "none", string nameLayer7 = "none", string nameLayer8 = "none", string nameLayer9 = "none", string nameLayer10 = "none", string nameLayer11 = "none", string nameLayer12 = "none", int dePosLayer1_x = -1, int dePosLayer1_y = -1, int dePosLayer2_x = -1, int dePosLayer2_y = -1, int dePosLayer3_x = -1, int dePosLayer3_y = -1, int dePosLayer4_x = -1, int dePosLayer4_y = -1, int dePosLayer5_x = -1, int dePosLayer5_y = -1, int dePosLayer6_x = -1, int dePosLayer6_y = -1, int dePosLayer7_x = -1, int dePosLayer7_y = -1, int dePosLayer8_x = -1, int dePosLayer8_y = -1, int dePosLayer9_x = -1, int dePosLayer9_y = -1, int dePosLayer10_x = -1, int dePosLayer10_y = -1, int dePosLayer11_x = -1, int dePosLayer11_y = -1, int dePosLayer12_x = -1, int dePosLayer12_y = -1)
        {
            this.x = x;
            this.y = y;
            this.nameLayer1 = nameLayer1;
            this.nameLayer2 = nameLayer2;
            this.nameLayer3 = nameLayer3;
            this.nameLayer4 = nameLayer4;
            this.nameLayer5 = nameLayer5;
            this.nameLayer6 = nameLayer6;
            this.nameLayer7 = nameLayer7;
            this.nameLayer8 = nameLayer8;
            this.nameLayer9 = nameLayer9;
            this.nameLayer10 = nameLayer10;
            this.nameLayer11 = nameLayer11;
            this.nameLayer12 = nameLayer12;
            this.dePosLayer1 = new Point(dePosLayer1_x, dePosLayer1_y);
            this.dePosLayer2 = new Point(dePosLayer2_x, dePosLayer2_y);
            this.dePosLayer3 = new Point(dePosLayer3_x, dePosLayer3_y);
            this.dePosLayer4 = new Point(dePosLayer4_x, dePosLayer4_y);
            this.dePosLayer5 = new Point(dePosLayer5_x, dePosLayer5_y);
            this.dePosLayer6 = new Point(dePosLayer6_x, dePosLayer6_y);
            this.dePosLayer7 = new Point(dePosLayer7_x, dePosLayer7_y);
            this.dePosLayer8 = new Point(dePosLayer8_x, dePosLayer8_y);
            this.dePosLayer9 = new Point(dePosLayer9_x, dePosLayer9_y);
            this.dePosLayer10 = new Point(dePosLayer10_x, dePosLayer10_y);
            this.dePosLayer11 = new Point(dePosLayer11_x, dePosLayer11_y);
            this.dePosLayer12 = new Point(dePosLayer12_x, dePosLayer12_y);
        }

        int x;
        public int X
        {
            get { return x; }
        }
        int y;

        public int Y
        {
            get { return y; }
        }

        string nameLayer1;

        public string NameLayer1
        {
            get { return nameLayer1; }
            set { nameLayer1 = value; }
        }
        string nameLayer2;

        public string NameLayer2
        {
            get { return nameLayer2; }
            set { nameLayer2 = value; }
        }
        string nameLayer3;

        public string NameLayer3
        {
            get { return nameLayer3; }
            set { nameLayer3 = value; }
        }
        string nameLayer4;

        public string NameLayer4
        {
            get { return nameLayer4; }
            set { nameLayer4 = value; }
        }
        string nameLayer5;

        public string NameLayer5
        {
            get { return nameLayer5; }
            set { nameLayer5 = value; }
        }
        string nameLayer6;

        public string NameLayer6
        {
            get { return nameLayer6; }
            set { nameLayer6 = value; }
        }

        Point dePosLayer1;

        public Point DePosLayer1
        {
            get { return dePosLayer1; }
            set { dePosLayer1 = value; }
        }
        Point dePosLayer2;

        public Point DePosLayer2
        {
            get { return dePosLayer2; }
            set { dePosLayer2 = value; }
        }
        Point dePosLayer3;

        public Point DePosLayer3
        {
            get { return dePosLayer3; }
            set { dePosLayer3 = value; }
        }
        Point dePosLayer4;

        public Point DePosLayer4
        {
            get { return dePosLayer4; }
            set { dePosLayer4 = value; }
        }
        Point dePosLayer5;

        public Point DePosLayer5
        {
            get { return dePosLayer5; }
            set { dePosLayer5 = value; }
        }
        Point dePosLayer6;

        public Point DePosLayer6
        {
            get { return dePosLayer6; }
            set { dePosLayer6 = value; }
        }

        Point dePosLayer7;

        public Point DePosLayer7
        {
            get { return dePosLayer7; }
            set { dePosLayer7 = value; }
        }
        Point dePosLayer8;

        public Point DePosLayer8
        {
            get { return dePosLayer8; }
            set { dePosLayer8 = value; }
        }
        Point dePosLayer9;

        public Point DePosLayer9
        {
            get { return dePosLayer9; }
            set { dePosLayer9 = value; }
        }
        Point dePosLayer10;

        public Point DePosLayer10
        {
            get { return dePosLayer10; }
            set { dePosLayer10 = value; }
        }
        Point dePosLayer11;

        public Point DePosLayer11
        {
            get { return dePosLayer11; }
            set { dePosLayer11 = value; }
        }
        Point dePosLayer12;

        public Point DePosLayer12
        {
            get { return dePosLayer12; }
            set { dePosLayer12 = value; }
        }
        string nameLayer7;

        public string NameLayer7
        {
            get { return nameLayer7; }
            set { nameLayer7 = value; }
        }
        string nameLayer8;

        public string NameLayer8
        {
            get { return nameLayer8; }
            set { nameLayer8 = value; }
        }
        string nameLayer9;

        public string NameLayer9
        {
            get { return nameLayer9; }
            set { nameLayer9 = value; }
        }
        string nameLayer10;

        public string NameLayer10
        {
            get { return nameLayer10; }
            set { nameLayer10 = value; }
        }
        string nameLayer11;

        public string NameLayer11
        {
            get { return nameLayer11; }
            set { nameLayer11 = value; }
        }
        string nameLayer12;

        public string NameLayer12
        {
            get { return nameLayer12; }
            set { nameLayer12 = value; }
        }
        public string GetSave()
        {
            return this.x + "|" + this.y + "|" + this.nameLayer1 + "|" + this.dePosLayer1.X + "," + this.dePosLayer1.Y + "|" + this.nameLayer2 + "|" + this.dePosLayer2.X + "," + this.dePosLayer2.Y + "|" + this.nameLayer3 + "|" + this.dePosLayer3.X + "," + this.dePosLayer3.Y + "|" + this.nameLayer4 + "|" + this.dePosLayer4.X + "," + this.dePosLayer4.Y + "|" + this.nameLayer5 + "|" + this.dePosLayer5.X + "," + this.dePosLayer5.Y + "|" + this.nameLayer6 + "|" + this.dePosLayer6.X + "," + this.dePosLayer6.Y + "|" + this.nameLayer7 + "|" + this.dePosLayer7.X + "," + this.dePosLayer7.Y + "|" + this.nameLayer8 + "|" + this.dePosLayer8.X + "," + this.dePosLayer8.Y + "|" + this.nameLayer9 + "|" + this.dePosLayer9.X + "," + this.dePosLayer9.Y + "|" + this.nameLayer10 + "|" + this.dePosLayer10.X + "," + this.dePosLayer10.Y + "|" + this.nameLayer11 + "|" + this.dePosLayer11.X + "," + this.dePosLayer11.Y + "|" + this.nameLayer12 + "|" + this.dePosLayer12.X + "," + this.dePosLayer12.Y;
        }

        public Texture2D ReturnCharacterTile(string nameLayer,Point dePosLayer)
        { 
                int index = 0;
                index += dePosLayer.X / 2;
                index += (dePosLayer.Y / 4) * 5;
                switch (nameLayer)
                {
                    case "1":
                        switch (index)
                        {
                            case 0:
                                return ResourceController.Characters_armAnim_0;
                            default:
                                break;
                        }
                        break;
                    case "2":
                        switch (index)
                        {
                            case 0:
                                return ResourceController.Characters_clothesAnim_0;
                            default:
                                break;
                        }
                        break;
                    case "3":
                        switch (index)
                        {
                            case 0:
                                return ResourceController.Characters_eyeAnim_0;
                            default:
                                break;
                        }
                        break;
                    case "4":
                        switch (index)
                        {
                            case 0:
                                return ResourceController.Characters_faceAnim_0;
                            default:
                                break;
                        }
                        break;
                    case "5":
                        switch (index)
                        {
                            case 0:
                                return ResourceController.Characters_hairbackwardAnim_0;
                            default:
                                break;
                        }
                        break;
                    case "6":
                        switch (index)
                        {
                            case 0:
                                return ResourceController.Characters_hairforwardAnim_0;
                            default:
                                break;
                        }
                        break;
                    case "7":
                        switch (index)
                        {
                            case 0:
                                return ResourceController.Characters_legAnim_0;
                            default:
                                break;
                        }
                        break;
                    case "8":
                        switch (index)
                        {
                            case 0:
                                return ResourceController.Characters_shouseAnim_0;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                return null;
            }
           
          

        /// <summary>
        /// explain attribute anim
        /// </summary>
        /// <param name="b"></param>
        /// <param name="position"></param>
        /// <param name="LayerDepth"></param>
        /// <param name="anim">new Point(animX,animY)</param>
        public void Draw(SpriteBatch b, Vector2 position, Point anim)
        {
            if (nameLayer1 != "none" && dePosLayer1 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer1, dePosLayer1), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000001f);
            }
            if (nameLayer2 != "none" && dePosLayer2 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer2, dePosLayer2), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000002f);
            }
            if (nameLayer3 != "none" && dePosLayer3 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer3, dePosLayer3), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000003f);
            }
            if (nameLayer4 != "none" && dePosLayer4 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer4, dePosLayer4), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000004f);
            }
            if (nameLayer5 != "none" && dePosLayer5 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer5, dePosLayer5), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000005f);
            }
            if (nameLayer6 != "none" && dePosLayer6 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer6, dePosLayer6), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000006f);
            }
            if (nameLayer7 != "none" && dePosLayer7 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer7, dePosLayer7), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000007f);
            }
            if (nameLayer8 != "none" && dePosLayer8 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer8, dePosLayer8), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000008f);
            }
            if (nameLayer9 != "none" && dePosLayer9 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer9, dePosLayer9), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000009f);
            }
            if (nameLayer10 != "none" && dePosLayer10 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer10, dePosLayer10), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000010f);
            }
            if (nameLayer11 != "none" && dePosLayer11 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer11, dePosLayer11), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000011f);
            }
            if (nameLayer12 != "none" && dePosLayer12 != new Point(-1, -1))
            {
                b.Draw(ReturnCharacterTile(nameLayer12, dePosLayer12), Camera.HandlePos(new Vector2(position.X + this.x * 0.5f * Define.UnitOFpixel, position.Y + this.y * 0.5f * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(anim.X * Define.UnitOFpixel + this.x * Define.UnitOFpixel, anim.Y * Define.UnitOFpixel + this.y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, GetTileLayerDepth(position.Y, this.y) + 0.000012f);
            }

        }
        float GetTileLayerDepth(float y,int b)
        {
            
            return (y + 1 * Define.UnitOFpixel) / GlobalController.Map.Size.Y / Define.UnitOFpixel;
        }
    }
}
