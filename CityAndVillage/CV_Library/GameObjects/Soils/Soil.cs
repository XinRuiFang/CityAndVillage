using CV_Library.Controllers;
using CV_Library.GameObjects.Items;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Soils
{
    public class Soil : GameObject,IPlayerScene
    {
        Vector2 seedPosition;
        Point currentFrame;
        int type;
        Seeds seed;
        float waterContent;
        float waterConsume;
        bool isSeeded;
        bool isShaking;
        int shakeTimes;

        double eagle;
        double a;
        double b;
        double c;
        protected Vector2 rotationPoint;

        public Soil(Texture2D texture,Map map,Vector2 position,float waterContent,Seeds seed,bool isSeeded)
        {
            this.texture = texture;
            this.map = map;
            this.position = position;
            this.seedPosition = new Vector2(position.X, position.Y - 2 * Define.UnitOFpixel);

            this.size = new Point(2, 2);
            this.scale = 1;
            this.type = 1;
            
            this.currentFrame = new Point(0, 0);

            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
            this.collider = new Rectangle((int)(this.Position.X + 0.5f * Define.UnitOFpixel), (int)(this.Position.Y + 1.8f * Define.UnitOFpixel), Define.UnitOFpixel,(int)(0.4f * Define.UnitOFpixel));

            this.isShaking = false;
            this.shakeTimes = 0;
            this.seed = seed;
            this.waterContent = waterContent;
            this.isSeeded = isSeeded;

            this.rotationPoint = new Vector2(this.seedPosition.X + Define.UnitOFpixel, this.seedPosition.Y + 3 * Define.UnitOFpixel);
            this.a = 1d;
            this.b = 3d;
            this.c = Math.Sqrt(a * a + b * b);
            this.eagle = Math.Asin(a / c);
            this.c *= Define.UnitOFpixel;

            waterConsume = 0.277f;
        }

        public Point CurrentFrame
        {
            get {
                switch (type)
                {
                    case 1: currentFrame.Y = 0; break;
                    case 2: currentFrame.Y = 1; break;
                    default:
                        break;
                }
                if (waterContent == 0)
                {
                    currentFrame.X = 0;
                }
                else if (0 < waterContent && waterContent <= 500)
                {
                    currentFrame.X = 1;
                }
                else if (500 < waterContent && waterContent <= 1000)
                {
                    currentFrame.X = 2;
                }
                else if (1000 < waterContent)
                {
                    currentFrame.X = 3;
                }
                else
                {
                    currentFrame.X = 0;
                }
                return currentFrame; 
            }
        }

        public Rectangle RenderRectangle
        {
            get
            {
                renderRectangle.X = CurrentFrame.X * size.X * Define.UnitOFpixel;
                renderRectangle.Y = CurrentFrame.Y * size.Y * Define.UnitOFpixel;
                return renderRectangle;
            }
        }

        public bool IsShaking
        {
            get { return isShaking; }
            set { isShaking = value; }
        }

        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(this.position, GlobalController.Camera); }
        }

        public Vector2 RenderSeedPosition
        {
            get { return Camera.HandlePos(this.seedPosition, GlobalController.Camera); }
        }


        public int ShakeTimes
        {
            get { return shakeTimes; }
            set { shakeTimes = value; }
        }
        public float LayerDepth
        {
            get
            {
                return 0.05f;
            }
        }
        public float SeedLayerDepth
        {
            get
            {
                if (this.seed.Status == 0)
                {
                    return 0.051f;
                }
                return (this.position.Y * 1f + 1.5f * Define.UnitOFpixel) / this.map.Size.Y / Define.UnitOFpixel;
            }
        }

        public bool IsSeeded
        {
            get { return isSeeded; }
            set { isSeeded = value; }
        }


        public int Type
        {
            get { return type; }
            set { type = value; }
        }


        public Seeds Seed
        {
            get { return seed; }
            set { seed = value; }
        }

        public float WaterContent
        {
            get { return waterContent; }
            set { waterContent = value; }
        }


        public float WaterConsume
        {
            get { return waterConsume; }
            set { waterConsume = value; }
        }

        public void Watering(float quantity)
        {
            waterContent += quantity;
        }
        public new Rectangle Collider
        {
            get
            {
                return collider;
            }
        }

        public void Shake()
        {
            shakeTimes++;
            if (shakeTimes < 6)
            {
                if (shakeTimes % 10 == 1)
                {
                    eagle += 0.075f;
                    this.seedPosition = GlobalController._Cv_func._Global_ItemShake(eagle, c, rotationPoint);
                    this.seed.Rotation -= 0.075f;
                }
                else if (shakeTimes % 10 == 3)
                {
                    eagle -= 0.15f;
                    this.seedPosition = GlobalController._Cv_func._Global_ItemShake(eagle, c, rotationPoint);
                    this.seed.Rotation += 0.15f;
                }
                else if (shakeTimes % 10 == 5)
                {
                    eagle += 0.075f;
                    this.seedPosition = GlobalController._Cv_func._Global_ItemShake(eagle, c, rotationPoint);
                    this.seed.Rotation -= 0.075f;
                    this.isShaking = false;
                }
            }
        }

        public string GetMap()
        {
            return this.Map.Name;
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
            if (this.IsSeeded)
            {
                b.Draw(ResourceController.Items_seeds, this.RenderSeedPosition, this.Seed.RenderItemRectangle, this.Seed.RenderColor, this.Seed.Rotation, this.Seed.Origin, this.Seed.Scale, this.Seed.SpriteEffects, this.SeedLayerDepth);
            }
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
            return "Soil";
        }

        public string GetSaveParameter()
        {
            if (IsSeeded)
            {
                return this.Map.Name + "|" + this.Position.X.ToString() + "|" + this.Position.Y.ToString() + "|" + this.waterContent.ToString() + "|" + this.IsSeeded + "|" + this.Seed.Id.ToString() + "|" + this.Seed.SavingSeeds();
            }
            else
            {
                return this.Map.Name + "|" + this.Position.X.ToString() + "|" + this.Position.Y.ToString() + "|" + this.waterContent.ToString() + "|" + this.IsSeeded;
            }
        }


        public Rectangle[] GetEffiveClickArea()
        {
            throw new NotImplementedException();
        }
    }
}
