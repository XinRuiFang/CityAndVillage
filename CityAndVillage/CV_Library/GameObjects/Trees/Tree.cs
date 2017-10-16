using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Tree : GameObject, IPlayerScene
    {
        protected Point currentFrame;
        protected Point sheetSize;
        protected Texture2D shadow;
        protected bool canCrop;
        protected string name;
        protected float hp;
        bool isShaking;
        bool isDroping;
        double eagle;
        double a;
        double b;
        double c;
        protected Vector2 rotationPoint;
        double endDrop;
        protected Vector2 rootPosition;
        float dropAccelerate;
        bool isDown;
        int lyingTime;
        string dropDirect;
        float shadowExist;
        float growTime;
        int shakeTime;
        int rootFrameY;
        int harvestLogNum;
        int shadowFrame;



        public Tree()
        {
            this.size = new Point(5, 8);          
            this.scale = 1;
            

            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
            this.renderColor = Color.White;
            this.isShaking = false;
            this.isDroping = false;
            this.shadowExist = 255f;
            this.dropAccelerate = 0;
            this.isDown = false;
            this.lyingTime = 0;
            this.shakeTime = 0;
            a = 2.5d;
            b = 6.5d;
            c = Math.Sqrt(a * a + b * b);
            this.eagle = Math.Asin(a / c);
            
        }
        public Rectangle RenderRectangle
        {
            get
            {
                renderRectangle.X = (int)(CurrentFrame.X * Define.UnitOFpixel * Size.X);
                renderRectangle.Y = (int)(CurrentFrame.Y * Define.UnitOFpixel * Size.Y);
                return renderRectangle;
            }
        }
        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(new Vector2((this.position.X - 2) * Define.UnitOFpixel, (this.position.Y - 7) * Define.UnitOFpixel), GlobalController.Camera); }
        }
        public Vector2 RenderRootPosition
        {
            get { return Camera.HandlePos(new Vector2((this.rootPosition.X - 2) * Define.UnitOFpixel, (this.rootPosition.Y - 1) * Define.UnitOFpixel), GlobalController.Camera); }
        }

        public float GrowTime
        {
            get { return growTime; }
            set { growTime = value; }
        }
        public new Rectangle Collider
        {
            get
            {
                return collider;
            }
        }

        public float ShadowExist
        {
            get { return shadowExist; }
            set { shadowExist = value; }
        }

        public string DropDirect
        {
            get { return dropDirect; }
            set 
            {
                if (value == "left")
                {
                    endDrop = 1.5 + eagle;
                }
                else
                {
                    endDrop = -1.5 + eagle;
                }
                dropDirect = value; 
            
            }
        }


        public bool IsShaking
        {
            get { return isShaking; }
            set { isShaking = value; }
        }

        public bool IsDroping
        {
            get { return isDroping; }
            set { isDroping = value; }
        }
        public void Shake()
        {
            CreateLeaves();
            if (shakeTime == 0)
            {
                eagle += 0.02f;
                this.position = GlobalController._Cv_func._Global_ItemShake(eagle, c, rotationPoint);
                this.rotation -= 0.02f;
                shakeTime++;
            }
            else if (shakeTime == 1)
            {
                eagle -= 0.04f;
                this.position = GlobalController._Cv_func._Global_ItemShake(eagle, c, rotationPoint);
                this.rotation += 0.04f;
                shakeTime++;
            }
            else if (shakeTime == 2)
            {
                eagle += 0.02f;
                this.position = GlobalController._Cv_func._Global_ItemShake(eagle, c, rotationPoint);
                this.rotation -= 0.02f;
                shakeTime = 0;
                this.isShaking = false;
            }
        }
        public void Drop(int wTime)
        {
            if (this.dropDirect == "left")
            {
                if (eagle < endDrop)
                {
                    dropAccelerate += 0.0008f;
                    eagle += dropAccelerate;
                    a = Math.Sin(eagle) * c;
                    b = Math.Cos(eagle) * c;
                    this.position = new Vector2((float)(rotationPoint.X - a), (float)(rotationPoint.Y - b));
                    this.rotation -= dropAccelerate;
                    this.shadowExist -= 5;
                }
                else
                {
                    this.shadowExist = 0;
                    lyingTime += wTime;
                    if (lyingTime > 50)
                    {
                        this.isDown = true;
                        this.IsDroping = false;
                        Random ran = new Random();
                        for (int i = 0; i < this.HarvestLogNum; i++)
                        {
                            GlobalController._Cv_func._Global_OutDoorItemFactory("05_001", new Vector2(this.Collider.X - 4 * Define.UnitOFpixel + ran.Next(0, 72), this.Collider.Y - 2 * Define.UnitOFpixel + ran.Next(0, 24)), this.map.Name);                          
                        }

                    }
                }
            }
            else
            {
                if (eagle > endDrop)
                {
                    dropAccelerate -= 0.0008f;
                    eagle += dropAccelerate;
                    a = Math.Sin(eagle) * c;
                    b = Math.Cos(eagle) * c;
                    this.position = new Vector2((float)(rotationPoint.X - a), (float)(rotationPoint.Y - b));
                    this.rotation -= dropAccelerate;
                    this.shadowExist -= 5;
                }
                else
                {
                    this.shadowExist = 0;
                    lyingTime += wTime;
                    if (lyingTime > 50)
                    {
                        this.isDown = true;
                        this.IsDroping = false;
                        Random ran = new Random();
                        for (int i = 0; i < this.HarvestLogNum; i++)
                        {
                            GlobalController._Cv_func._Global_OutDoorItemFactory("05_001", new Vector2(this.Collider.X + 4 * Define.UnitOFpixel - ran.Next(0, 96), this.Collider.Y - 2 * Define.UnitOFpixel + ran.Next(0, 24)), this.map.Name);
                        }
                    }
                }
            }

        }
        void CreateLeaves()
        {
            Random ran = new Random();
            if (growTime >= 2880 && growTime < 5760)
            {
                int x = ran.Next(0, 2);
                for (int i = 0; i < x; i++)
                {

                    Vector2 pos = new Vector2((this.position.X - 1f) * Define.UnitOFpixel + 1f * Define.UnitOFpixel + ran.Next(0, 1 * Define.UnitOFpixel), (this.position.Y - 4) * Define.UnitOFpixel + 1f * Define.UnitOFpixel + ran.Next(0, 2 * Define.UnitOFpixel));
                    GlobalController.LeafList.Add(new GameObjects.Trees.Leaf(this.Texture, GlobalController.Map, pos, ran.Next(1, 6), pos.Y + ran.Next(0 * Define.UnitOFpixel, 1 * Define.UnitOFpixel), (float)ran.Next(4, 6) / 10f));
                }
            }
            else if (growTime >= 5760 && growTime < 8640)
            {
                int x = ran.Next(1, 2);
                for (int i = 0; i < x; i++)
                {

                    Vector2 pos = new Vector2((this.position.X - 2f) * Define.UnitOFpixel + 1f * Define.UnitOFpixel + ran.Next(0, 3 * Define.UnitOFpixel), (this.position.Y - 7) * Define.UnitOFpixel + 1f * Define.UnitOFpixel + ran.Next(0, 3 * Define.UnitOFpixel));
                    GlobalController.LeafList.Add(new GameObjects.Trees.Leaf(this.Texture, GlobalController.Map, pos, ran.Next(1, 6), pos.Y + ran.Next(1 * Define.UnitOFpixel, 2 * Define.UnitOFpixel), (float)ran.Next(5, 7) / 10f));
                }
            }
            else if(growTime >= 8640)
            {
                int x = ran.Next(2, 5);
                for (int i = 0; i < x; i++)
                {

                    Vector2 pos = new Vector2((this.position.X - 2f) * Define.UnitOFpixel + 1f * Define.UnitOFpixel + ran.Next(0, 3 * Define.UnitOFpixel), (this.position.Y - 7) * Define.UnitOFpixel + 1f * Define.UnitOFpixel + ran.Next(0, 3 * Define.UnitOFpixel));
                    GlobalController.LeafList.Add(new GameObjects.Trees.Leaf(this.Texture, GlobalController.Map, pos, ran.Next(1, 6), pos.Y + ran.Next(1 * Define.UnitOFpixel, 2 * Define.UnitOFpixel), (float)ran.Next(6, 8) / 10f));
                }
            }            
        }

        public float Hp
        {
            get { return hp; }
            set { hp = value; }
        }

        public override Vector2 MidPos
        {
            get
            {
                midPos.X = Collider.X + Collider.Width / 2;
                midPos.Y = Collider.Y + Collider.Height / 2 - Define.UnitOFpixel - 4;
                return midPos;
            }
        }
        public Point CurrentFrame
        {
            get {
                if (this.canCrop)
                {
                    if (growTime >= 0 && growTime < 2880)
                    {
                        return new Point(0, currentFrame.Y);
                    }
                    else if (growTime >= 2880 && growTime < 5760)
                    {
                        return new Point(1, currentFrame.Y);
                    }
                    else if (growTime >= 5760 && growTime < 8640)
                    {
                        return new Point(2, currentFrame.Y);
                    }
                    else
                    {
                        return new Point(3, currentFrame.Y);
                    }
                }
                else
                {
                    return currentFrame; 
                }                
            }
            set { currentFrame = value; }
        }


        public int RootFrameY
        {
            get
            {
                if (this.canCrop)
                {
                    if (growTime >= 0 && growTime < 2880)
                    {
                        return 3;
                    }
                    else if (growTime >= 2880 && growTime < 5760)
                    {
                        return 4;
                    }
                    else if (growTime >= 5760 && growTime < 8640)
                    {
                        return 5;
                    }
                    else
                    {
                        return 6;
                    }
                }
                else
                {
                    return 6;
                }          
            }
            set { rootFrameY = value; }
        }


        public int HarvestLogNum
        {
            get 
            {
                if (this.canCrop)
                {
                    if (growTime >= 0 && growTime < 2880)
                    {
                        return 0;
                    }
                    else if (growTime >= 2880 && growTime < 5760)
                    {
                        return 1;
                    }
                    else if (growTime >= 5760 && growTime < 8640)
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    return 3;
                }          
            }
            set { harvestLogNum = value; }
        }


        public int ShadowFrame
        {
            get 
            {
                if (this.canCrop)
                {
                    if (growTime >= 0 && growTime < 2880)
                    {
                        return 3;
                    }
                    else if (growTime >= 2880 && growTime < 5760)
                    {
                        return 2;
                    }
                    else if (growTime >= 5760 && growTime < 8640)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }          
            }
            set { shadowFrame = value; }
        }

        public Point SheetSize
        {
            get { return sheetSize; }
        }
        public float LayerDepth
        {
            get
            {
                return 1f * this.position.Y / map.Size.Y;
            }
        }
        public float rootLayerDepth
        {
            get
            {
                return 1f * this.rootPosition.Y / map.Size.Y;
            }
        }
        public Texture2D Shadow
        {
            get { return shadow; }
            set { shadow = value; }
        }

        public bool CanCrop
        {
            get { return canCrop; }
            set { canCrop = value; }
        }

        public string GetMap()
        {
            return this.Map.Name;
        }

        public void Draw(SpriteBatch b)
        {
            if (!isDown)
            {
                b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
            }
            b.Draw(this.Shadow, new Vector2(this.RenderRootPosition.X, this.RenderRootPosition.Y - 1f * Define.UnitOFpixel), new Rectangle(ShadowFrame * 5 * Define.UnitOFpixel, 0, 5 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), new Color(255 / 255f, 255 / 255f, 255 / 255f, this.shadowExist / 255f), 0, this.Origin, this.Scale, this.SpriteEffects, rootLayerDepth - 0.002f);

            b.Draw(this.Texture, this.RenderRootPosition, new Rectangle(20 * Define.UnitOFpixel, this.RenderRectangle.Y + RootFrameY * Define.UnitOFpixel, this.RenderRectangle.Width, Define.UnitOFpixel), this.RenderColor, 0, this.Origin, this.Scale, this.SpriteEffects, rootLayerDepth - 0.001f);
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
            return this.name;
        }

        public string GetSaveParameter()
        {
            return this.map.Name + "|" + this.position.X + "|" + this.position.Y + "|" + this.GrowTime; 
        }


        public Rectangle[] GetEffiveClickArea()
        {
            return new Rectangle[]
                    {
                        new Rectangle((int)(this.Position.X) * Define.UnitOFpixel,(int)(this.Position.Y - 2) * Define.UnitOFpixel,Define.UnitOFpixel,2 * Define.UnitOFpixel)
                    };
        }
    }
}
