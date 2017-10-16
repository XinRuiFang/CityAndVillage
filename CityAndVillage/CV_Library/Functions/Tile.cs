using CV_Library.Controllers;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Functions
{
    public class Tile
    {
        public Tile(int x, int y, string name_layer1 = "none", string name_layer2_1 = "none", string name_layer2_2 = "none", string name_layer2_3 = "none", string name_layer3_1 = "none", string name_layer3_2 = "none", string name_layer3_3 = "none", int dePos_layer1x = -1, int dePos_layer1y = -1, int dePos_layer2_1x = -1, int dePos_layer2_1y = -1, int dePos_layer2_2x = -1, int dePos_layer2_2y = -1, int dePos_layer2_3x = -1, int dePos_layer2_3y = -1, int dePos_layer3_1x = -1, int dePos_layer3_1y = -1, int dePos_layer3_2x = -1, int dePos_layer3_2y = -1, int dePos_layer3_3x = -1, int dePos_layer3_3y = -1)
        {
            this.x = x;
            this.y = y;
            if (x == 13 && y == 13)
            {
 
            }
            dePos_layer1 = new Point(dePos_layer1x, dePos_layer1y);
            dePos_layer2_1 = new Point(dePos_layer2_1x, dePos_layer2_1y);
            dePos_layer2_2 = new Point(dePos_layer2_2x, dePos_layer2_2y);
            dePos_layer2_3 = new Point(dePos_layer2_3x, dePos_layer2_3y);
            dePos_layer3_1 = new Point(dePos_layer3_1x, dePos_layer3_1y);
            dePos_layer3_2 = new Point(dePos_layer3_2x, dePos_layer3_2y);
            dePos_layer3_3 = new Point(dePos_layer3_3x, dePos_layer3_3y);
            this.name_layer1 = name_layer1;
            this.name_layer2_1 = name_layer2_1;
            this.name_layer2_2 = name_layer2_2;
            this.name_layer2_3 = name_layer2_3;
            this.name_layer3_1 = name_layer3_1;
            this.name_layer3_2 = name_layer3_2;
            this.name_layer3_3 = name_layer3_3;
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

        Point dePos_layer1;

        public Point DePos_layer1
        {
            get { return dePos_layer1; }
            set { dePos_layer1 = value; }
        }

        Point dePos_layer2_1;

        public Point DePos_layer2_1
        {
            get { return dePos_layer2_1; }
            set { dePos_layer2_1 = value; }
        }

        Point dePos_layer2_2;
        public Point DePos_layer2_2
        {
            get { return dePos_layer2_2; }
            set { dePos_layer2_2 = value; }
        }

        Point dePos_layer2_3;

        public Point DePos_layer2_3
        {
            get { return dePos_layer2_3; }
            set { dePos_layer2_3 = value; }
        }
        Point dePos_layer3_1;

        public Point DePos_layer3_1
        {
            get { return dePos_layer3_1; }
            set { dePos_layer3_1 = value; }
        }
        Point dePos_layer3_2;

        public Point DePos_layer3_2
        {
            get { return dePos_layer3_2; }
            set { dePos_layer3_2 = value; }
        }
        Point dePos_layer3_3;

        public Point DePos_layer3_3
        {
            get { return dePos_layer3_3; }
            set { dePos_layer3_3 = value; }
        }
        string name_layer1;

        public string Name_layer1
        {
            get { return name_layer1; }
            set { name_layer1 = value; }
        }
        string name_layer2_1;

        public string Name_layer2_1
        {
            get { return name_layer2_1; }
            set { name_layer2_1 = value; }
        }
        string name_layer2_2;

        public string Name_layer2_2
        {
            get { return name_layer2_2; }
            set { name_layer2_2 = value; }
        }
        string name_layer2_3;

        public string Name_layer2_3
        {
            get { return name_layer2_3; }
            set { name_layer2_3 = value; }
        }
        string name_layer3_1;

        public string Name_layer3_1
        {
            get { return name_layer3_1; }
            set { name_layer3_1 = value; }
        }
        string name_layer3_2;

        public string Name_layer3_2
        {
            get { return name_layer3_2; }
            set { name_layer3_2 = value; }
        }
        string name_layer3_3;

        public string Name_layer3_3
        {
            get { return name_layer3_3; }
            set { name_layer3_3 = value; }
        }
        float GetLayerDepth()
        {
            if (GlobalController.PlayerInDoor)
            {
                return 0.99f;
            }
            else
            {
                return ((this.y + 2f) * 1f / GlobalController.Map.Size.Y) > 1 ? 0.99999f : ((this.y + 2f) * 1f / GlobalController.Map.Size.Y);
            }
        }

        public void DrawLayer_1(SpriteBatch b, string textureName)
        {
            b.Draw(GetUsingDecoratsTexture(textureName), Camera.HandlePos(new Vector2(this.X * Define.UnitOFpixel, this.Y * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(this.DePos_layer1.X * Define.UnitOFpixel, this.DePos_layer1.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }
        public void DrawLayer_2_1(SpriteBatch b, string textureName)
        {
            b.Draw(GetUsingDecoratsTexture(textureName), Camera.HandlePos(new Vector2(this.X * Define.UnitOFpixel, this.Y * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(this.DePos_layer2_1.X * Define.UnitOFpixel, this.DePos_layer2_1.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.00001f);             
        }
        public void DrawLayer_2_2(SpriteBatch b, string textureName)
        {
            b.Draw(GetUsingDecoratsTexture(textureName), Camera.HandlePos(new Vector2(this.X * Define.UnitOFpixel, this.Y * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(this.DePos_layer2_2.X * Define.UnitOFpixel, this.DePos_layer2_2.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.00002f);             
        }
        public void DrawLayer_2_3(SpriteBatch b, string textureName)
        {
            b.Draw(GetUsingDecoratsTexture(textureName), Camera.HandlePos(new Vector2(this.X * Define.UnitOFpixel, this.Y * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(this.DePos_layer2_3.X * Define.UnitOFpixel, this.DePos_layer2_3.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.00003f);                  
        }
        public void DrawLayer_3_1(SpriteBatch b, string textureName)
        {
            b.Draw(GetUsingDecoratsTexture(textureName), Camera.HandlePos(new Vector2(this.X * Define.UnitOFpixel, this.Y * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(this.DePos_layer3_1.X * Define.UnitOFpixel, this.DePos_layer3_1.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.99997f);                 
        }
        public void DrawLayer_3_2(SpriteBatch b, string textureName)
        {
            b.Draw(GetUsingDecoratsTexture(textureName), Camera.HandlePos(new Vector2(this.X * Define.UnitOFpixel, this.Y * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(this.DePos_layer3_2.X * Define.UnitOFpixel, this.DePos_layer3_2.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.99998f);            
        }
        public void DrawLayer_3_3(SpriteBatch b, string textureName)
        {
            b.Draw(GetUsingDecoratsTexture(textureName), Camera.HandlePos(new Vector2(this.X * Define.UnitOFpixel, this.Y * Define.UnitOFpixel), GlobalController.Camera), new Rectangle(this.DePos_layer3_3.X * Define.UnitOFpixel, this.DePos_layer3_3.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.99999f);            
        }
        Texture2D GetUsingDecoratsTexture(string usingDecoratsName)
        {
            string classify = usingDecoratsName.Split('_')[0];
            int num = int.Parse(usingDecoratsName.Split('_')[1]);
            switch (classify)
            {
                case "Buildings":

                    if (num == 1)
                    {
                        return ResourceController.Tiles_Buildings_1;
                    }
                    if (num == 2)
                    {
                        return ResourceController.Tiles_Buildings_2;
                    }
                    if (num == 3)
                    {
                        return ResourceController.Tiles_Buildings_3;
                    }
                    if (num == 4)
                    {
                        return ResourceController.Tiles_Buildings_4;
                    }
                    if (num == 5)
                    {
                        return ResourceController.Tiles_Buildings_5;
                    }
                    if (num == 6)
                    {
                        return ResourceController.Tiles_Buildings_6;
                    }
                    if (num == 7)
                    {
                        return ResourceController.Tiles_Buildings_7;
                    }
                    if (num == 8)
                    {
                        return ResourceController.Tiles_Buildings_8;
                    }
                    if (num == 9)
                    {
                        return ResourceController.Tiles_Buildings_9;
                    }
                    if (num == 10)
                    {
                        return ResourceController.Tiles_Buildings_10;
                    }
                    if (num == 11)
                    {
                        return ResourceController.Tiles_Buildings_11;
                    }
                    if (num == 12)
                    {
                        return ResourceController.Tiles_Buildings_12;
                    }
                    if (num == 13)
                    {
                        return ResourceController.Tiles_Buildings_13;
                    }
                    if (num == 14)
                    {
                        return ResourceController.Tiles_Buildings_14;
                    }
                    if (num == 15)
                    {
                        return ResourceController.Tiles_Buildings_15;
                    }
                    if (num == 16)
                    {
                        return ResourceController.Tiles_Buildings_16;
                    }
                    if (num == 17)
                    {
                        return ResourceController.Tiles_Buildings_17;
                    }
                    if (num == 18)
                    {
                        return ResourceController.Tiles_Buildings_18;
                    }
                    if (num == 19)
                    {
                        return ResourceController.Tiles_Buildings_19;
                    }
                    if (num == 20)
                    {
                        return ResourceController.Tiles_Buildings_20;
                    }
                    if (num == 21)
                    {
                        return ResourceController.Tiles_Buildings_21;
                    }
                    if (num == 22)
                    {
                        return ResourceController.Tiles_Buildings_22;
                    }
                    if (num == 23)
                    {
                        return ResourceController.Tiles_Buildings_23;
                    }
                    return null;
                case "Decorats":

                    if (num == 1)
                    {
                        return ResourceController.Tiles_Decorats_1;
                    }
                    if (num == 2)
                    {
                        return ResourceController.Tiles_Decorats_2;
                    }
                    return null;
                case "Objects":

                    if (num == 1)
                    {
                        return ResourceController.Tiles_Objects_1;
                    }
                    return null;
                case "Terrains":

                    if (num == 1)
                    {
                        return ResourceController.Tiles_Terrains_1;
                    }
                    if (num == 2)
                    {
                        return ResourceController.Tiles_Terrains_2;
                    }
                    if (num == 3)
                    {
                        return ResourceController.Tiles_Terrains_3;
                    }
                    if (num == 4)
                    {
                        return ResourceController.Tiles_Terrains_4;
                    }
                    return null;
                case "Others":
                    return null;
                default:
                    return null;
            }
        }
    }
}
