using CV_Library.Controllers;
using CV_Library.GameObjects.Items;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CV_Library
{
    public class Item : GameObject ,ICloneable, IPlayerScene
    {
        string id;
        string name;
        string introduction;
        Point currentFrame;


        string category;
        int price;
        bool isEquipment;

        public Item(string id, Map map, Vector2 position, string name, Texture2D texture, int price,string introduction = "no introduction.")
        {
            this.id = id;
            this.name = name;
            this.texture = texture;
            this.introduction = introduction;

            this.position = position;
            this.map = map;

            this.size = new Point(1, 1);
            this.scale = 1;
            this.currentFrame = new Point(0, 0);
            this.renderRectangle = new Rectangle(0, 0, this.size.X * Define.UnitOFpixel, this.size.Y * Define.UnitOFpixel);
            this.renderColor = Color.White;
            //this.collider = new Rectangle((int)this.position.X, (int)this.position.Y + 24, 1 * Define.UnitOFpixel_X,  Define.UnitOFpixel_Y);

            this.price = price;

        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Introduction
        {
            get { return introduction; }
            set { introduction = value; }
        }
       
        public Point CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }

        public virtual Rectangle RenderRectangle
        {
            get
            {
                renderRectangle.X = CurrentFrame.X * Define.UnitOFpixel;
                renderRectangle.Y = CurrentFrame.Y * Define.UnitOFpixel;
                return renderRectangle;
            }
        }

        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(this.position, GlobalController.Camera); }
        }

        public float LayerDepth
        {
            get
            {
                return (float)((this.position.Y - 24) / map.Size.Y / Define.UnitOFpixel);
            }
        }

        public new Rectangle Collider
        {
            get { return collider; }
        }       

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public Item Clone()
        {
            return (Item)this.MemberwiseClone(); 

        }

        object ICloneable.Clone()
        {
            throw new NotImplementedException();
        }        

        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        
        public bool IsEquipment
        {
            get { return isEquipment; }
            set { isEquipment = value; }
        }

        // naming rule :
        // 2 Length - category
        // 3 Length - name
        // eg: 01_001 --  01-seeds 001-strawberry seed
        // 02 -- Foods
        // 03 -- Tools
        // 04 -- Property
        // 05 -- Materials
        // 06 -- Fishes
        public static Item ItemCreateFactory(string id)
        {
            XmlNode root = null;
            string categ = id.Substring(0, 2);
            string name = id.Substring(2, 4);
            Random ran = new Random();
            switch (categ)
            {
                case "01":
                    root = DataController.GetItemsCategoryNode("Seeds");
                    foreach (XmlNode node in root)
                    {
                        if (node.Name == name)
                        {
                            string context = node.InnerText;
                            string[] inner = context.Split('|');
                            return new Seeds(id, Map.Null, Vector2.Zero, inner[0], ResourceController.Items_items, int.Parse(inner[1]), float.Parse(inner[2]), float.Parse(inner[3]), float.Parse(inner[4]), float.Parse(inner[5]), float.Parse(inner[6]), inner[7], int.Parse(inner[8]), int.Parse(inner[9]), float.Parse(inner[10]), float.Parse(inner[11]), float.Parse(inner[12]), float.Parse(inner[13]), int.Parse(inner[14]), int.Parse(inner[15]), int.Parse(inner[16]), int.Parse(inner[17]), int.Parse(inner[18]),int.Parse(inner[19]), inner[20]);
                        }
                    }
                    break;
                case "02":
                    root = DataController.GetItemsCategoryNode("Foods");
                    foreach (XmlNode node in root)
                    {
                        if (node.Name == name)
                        {
                            string context = node.InnerText;
                            string[] inner = context.Split('|');
                            return new Food(id, Map.Null, Vector2.Zero, inner[0], ResourceController.Items_items, int.Parse(inner[1]), int.Parse(inner[2]), new Point(int.Parse(inner[3]), int.Parse(inner[4])), inner[5]);
                        }
                    }
                    break;
                case "03":
                    root = DataController.GetItemsCategoryNode("Tools");
                    foreach (XmlNode node in root)
                    {
                        if (node.Name == name)
                        {
                            string context = node.InnerText;
                            string[] inner = context.Split('|');
                            return new Tools(id, Map.Null, Vector2.Zero, inner[0], ResourceController.Items_tools, int.Parse(inner[1]), int.Parse(inner[2]), inner[3]);
                        }
                    }
                    break;
                case "04":
                    root = DataController.GetItemsCategoryNode("Property");
                    foreach (XmlNode node in root)
                    {
                        if (node.Name == name)
                        {
                            string context = node.InnerText;
                            string[] inner = context.Split('|');
                            return new Property(id, Map.Null, Vector2.Zero, inner[0], ResourceController.Items_items, int.Parse(inner[1]), new Point(int.Parse(inner[2]), int.Parse(inner[3])), inner[4]);
                        }
                    }
                    break;
                case "05":
                    root = DataController.GetItemsCategoryNode("Materials");
                    foreach (XmlNode node in root)
                    {
                        if (node.Name == name)
                        {
                            string context = node.InnerText;
                            string[] inner = context.Split('|');
                            return new Materials(id, Map.Null, Vector2.Zero, inner[0], ResourceController.Items_items, int.Parse(inner[1]), new Point(int.Parse(inner[2]), int.Parse(inner[3])), inner[4]);
                        }
                    }
                    break;
                case "06":
                    root = DataController.GetItemsCategoryNode("Fish");
                    foreach (XmlNode node in root)
                    {
                        if (node.Name == name)
                        {
                            string context = node.InnerText;
                            string[] inner = context.Split('|');
                            return new Fish(id, Map.Null, Vector2.Zero, inner[0], ResourceController.Items_items, int.Parse(inner[1]), int.Parse(inner[2]), new Point(int.Parse(inner[3]), int.Parse(inner[4])), inner[5], ran.Next(5, 10) + (float)ran.NextDouble());
                        }
                    }
                    break;
                default:
                    break;
            }
            return null;
        }

        public string GetMap()
        {
            return this.Map.Name;
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
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
            return "Items";
        }

        public string GetSaveParameter()
        {
            throw new NotImplementedException();
        }


        public Rectangle[] GetEffiveClickArea()
        {
            throw new NotImplementedException();
        }
    }
}
