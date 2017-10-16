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
    public class Construction : GameObject, IPlayerScene
    {
        protected string name;

        public Construction(Map map, Vector2 position, Texture2D texture,Point size,string name)
        {
            this.map = map;
            this.position = position;
            this.name = name;
            this.texture = texture;
            this.size = size;           
        }



        public static Construction Null = null;

        public static Construction CreateConstructionFactory(Map map, Vector2 position,string name)
        {
            switch (name)
            {
                case "cowhouse":
                    CowHouse cow = new CowHouse(map, position, ResourceController.Construction_cowhouse, new Point(6, 6));
                    return cow;
                case "fishnet":
                    FishNet fishNet = new FishNet(ResourceController.UI_ordinary, map, position, new Point(3, 3));
                    return fishNet;
                default:
                    return Construction.Null;
            }
        }


        public virtual Rectangle[] GetColliders()
        {
            return null;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string GetMap()
        {
            return this.map.Name;
        }

        public virtual void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b)
        {
            throw new NotImplementedException();
        }

        public Microsoft.Xna.Framework.Rectangle GetCollider()
        {
            return this.Collider;
        }

        public virtual GameObject GetInstance()
        {
            return this;
        }

        public string GetIntanceType()
        {
            return "Construction";
        }

        public virtual string GetSaveParameter()
        {
            return "";
        }

        public virtual Microsoft.Xna.Framework.Rectangle[] GetEffiveClickArea()
        {
            return null;
        }
    }
}
