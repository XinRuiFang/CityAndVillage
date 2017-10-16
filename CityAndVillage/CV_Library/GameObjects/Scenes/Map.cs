using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Map : GameObject
    {
        public Map(string name)
        {
            this.name = name;
            switch (name)
            {
                case "town_centre":
                    this.size = new Point(120, 120);
                    break;
                case "town_suburb":
                    this.size = new Point(100, 120);
                    break;
                case "town_station":
                    this.size = new Point(70, 85);
                    break;
                case "town_west":
                    this.size = new Point(60, 80);
                    break;
                case "town_east":
                    this.size = new Point(60, 80);
                    break;
                case "town_southriver":
                    this.size = new Point(60, 140);
                    break;
                case "town_hospital_indoor_first":
                    this.size = new Point(40, 30);
                    break;
                case "village_suburb_west":
                    this.size = new Point(168, 110);
                    break;
                case "village_thefarm":
                    this.size = new Point(100, 80);
                    break;
                case "village_farmhouse":
                    this.size = new Point(40, 30);
                    break;
                case "village_suburb_east":
                    this.size = new Point(100, 50);
                    break;
                case "village_lake":
                    this.size = new Point(100, 130);
                    break;
                case "village_centre":
                    this.size = new Point(120, 90);
                    break;
                case "village_northfarm":
                    this.size = new Point(100, 120);
                    break;
                case "village_ambi":
                    this.size = new Point(100, 110);
                    break;
                case "village_centre_clinic":
                    this.size = new Point(40, 30);
                    break;
                case "village_centre_hotel":
                    this.size = new Point(40, 30);
                    break;
                case "village_centre_house1":
                    this.size = new Point(40, 30);
                    break;
                case "village_centre_house2":
                    this.size = new Point(40, 30);
                    break;
                case "village_centre_managehouse":
                    this.size = new Point(40, 30);
                    break;
                case "village_centre_restaurant":
                    this.size = new Point(40, 30);
                    break;
                case "village_centre_toolhouse":
                    this.size = new Point(40, 30);
                    break;
                case "village_centre_shop":
                    this.size = new Point(40, 30);
                    break;
                case "city_entry":
                    this.size = new Point(70, 100);
                    break;
                case "city_slumarea":
                    this.size = new Point(150, 85);
                    break;
                case "city_busstation":
                    this.size = new Point(120, 75);
                    break;
                case "city_market":
                    this.size = new Point(70, 110);
                    break;
                case "city_station":
                    this.size = new Point(100, 120);
                    break;
                case "city_centre":
                    this.size = new Point(120, 115);
                    break;
                case "city_buildingsite":
                    this.size = new Point(120, 100);
                    break;
                case "city_suburb":
                    this.size = new Point(120, 75);
                    break;
                case "city_villa":
                    this.size = new Point(140, 75);
                    break;
                case "city_park":
                    this.size = new Point(110, 85);
                    break;
                case "city_school":
                    this.size = new Point(110, 105);
                    break;
                default:
                    break;
            }
            this.scale = 1;
            this.layerDepth = 0f;
            renderPosition = Vector2.Zero;
        }

        public Rectangle RenderRectangle
        {
            get 
            {
                return GlobalController.Camera.CameraArea;
            }
        }
        public Vector2 RenderPosition
        {
            get { return renderPosition; }
        }

        string name;

        public string Name
        {
            get { return name; }
        }

        public float LayerDepth
        {
            get { return layerDepth; }
        }
        public static Map Null = null;

        public List<Rectangle> CanDoReclaimCheck()
        {
            List<Rectangle> rect = new List<Rectangle>();
            rect.Add(new Rectangle(0 * 24, 0 * 24, 100 * 24, 22 * 24));
            rect.Add(new Rectangle(0 * 24, 71 * 24, 100 * 24, 9 * 24));
            rect.Add(new Rectangle(0 * 24, 22 * 24, 10 * 24, 49 * 24));
            rect.Add(new Rectangle(92 * 24, 22 * 24, 8 * 24, 49 * 24));
            return rect;
        }

        public static Map GetMapByID(int id)
        {
            switch (id)
            {
                case 11:
                    return new Map("village_centre");
                case 41:
                    return new Map("village_centre_clinic");
                case 42:
                    return new Map("village_centre_hotel");
                case 43:
                    return new Map("village_centre_house1");
                case 44:
                    return new Map("village_centre_house2");
                case 45:
                    return new Map("village_centre_managehouse");
                case 46:
                    return new Map("village_centre_restaurant");
                case 47:
                    return new Map("village_centre_toolhouse");
                case 48:
                    return new Map("village_centre_shop");
                default:
                    return Map.Null;
            }
        }
    }
}
