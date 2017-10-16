using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Items
{
    public class Fish : Item
    {
        #region old code
        //Point movingFrame;
        //Vector2 movingPos;
        //float movingLd;
        //Rectangle movingRect;
        //string direct;
        //string action;
        //int frameTime;
        //float speedH;
        //float speedV;
        //int speedExecTime;
        //int speedRanTime;
        //int speedDirect;
        //Rectangle hitRect;
        //Rectangle hitCollide;
        //Rectangle getCollide;
        //int shakeTime;
        //this.movingFrame = new Point(0, 15);
        //this.movingRect = new Rectangle(0, 0, 2 * Define.UnitOFpixel, Define.UnitOFpixel);
        //action = "move";
        //frameTime = 0;
        //speedH = 0;
        //speedV = 0;
        //speedExecTime = 0;
        //speedRanTime = 0;
        //speedDirect = 0;
        //this.getCollide = new Rectangle(0, 0, 2 * Define.UnitOFpixel, 2 * Define.UnitOFpixel);
        //shakeTime = 0;
        //public Vector2 MovingPos
        //{
        //    get
        //    {
        //        if (movingPos.X <= Define.windowWidth - 384 + 24 && movingPos.X > Define.windowWidth - 384 + 24 - 2 * Define.UnitOFpixel)
        //        {
        //            return new Vector2(Define.windowWidth - 384 + 24, movingPos.Y);
        //        }
        //        return movingPos;
        //    }
        //    set { movingPos = value; }
        //}

        //public float MovingLd
        //{
        //    get { return movingLd; }
        //    set { movingLd = value; }
        //}

        //public string Direct
        //{
        //    get { return direct; }
        //    set { direct = value; }
        //}


        //public Rectangle HitRect
        //{
        //    get
        //    {
        //        if (weight > 5 && weight <= 7)
        //        {
        //            this.hitRect = new Rectangle(1, 3, 23, 18);
        //        }
        //        else if (weight > 7 && weight <= 9)
        //        {
        //            this.hitRect = new Rectangle(10, 1, 38, 22);
        //        }
        //        else
        //        {
        //            this.hitRect = new Rectangle(0, 0, 48, 24);
        //        }
        //        return hitRect;
        //    }
        //}

        //public Rectangle HitCollide
        //{
        //    get
        //    {
        //        this.hitCollide.X = (int)this.movingPos.X + this.HitRect.X;
        //        this.hitCollide.Y = (int)this.movingPos.Y + this.HitRect.Y;
        //        this.hitCollide.Width = this.HitRect.Width;
        //        this.hitCollide.Height = this.HitRect.Height;
        //        return hitCollide;
        //    }
        //}


        //public Rectangle GetCollide
        //{
        //    get
        //    {
        //        if (weight > 5 && weight <= 7)
        //        {
        //            this.getCollide = new Rectangle(getCollide.X, 28 * Define.UnitOFpixel, Define.UnitOFpixel, 2 * Define.UnitOFpixel);
        //        }
        //        else if (weight > 7 && weight <= 9)
        //        {
        //            this.getCollide = new Rectangle(getCollide.X, 30 * Define.UnitOFpixel, Define.UnitOFpixel, 2 * Define.UnitOFpixel);
        //        }
        //        else
        //        {
        //            this.getCollide = new Rectangle(getCollide.X, 32 * Define.UnitOFpixel, Define.UnitOFpixel, 2 * Define.UnitOFpixel);
        //        }
        //        return getCollide;
        //    }
        //}

        //public Point MovingFrame
        //{
        //    get
        //    {
        //        if (weight > 5 && weight <= 7)
        //        {
        //            this.movingFrame.Y = 16 + (action == "move" ? 0 : 1) + (direct == "right" ? 0 : 2);
        //        }
        //        else if (weight > 7 && weight <= 9)
        //        {
        //            this.movingFrame.Y = 20 + (action == "move" ? 0 : 1) + (direct == "right" ? 0 : 2);
        //        }
        //        else
        //        {
        //            this.movingFrame.Y = 24 + (action == "move" ? 0 : 1) + (direct == "right" ? 0 : 2);
        //        }
        //        return movingFrame;
        //    }
        //}
        //public Rectangle MovingRect
        //{
        //    get
        //    {
        //        movingRect.X = MovingFrame.X * Define.UnitOFpixel;
        //        movingRect.Y = MovingFrame.Y * Define.UnitOFpixel;
        //        if (movingPos.X >= Define.windowWidth + 384 - 24 - 2 * Define.UnitOFpixel)
        //        {
        //            movingRect.Width = (int)((Define.windowWidth + 384 - 24) - movingPos.X);
        //        }
        //        else if (movingPos.X <= Define.windowWidth - 384 + 24)
        //        {
        //            movingRect.Width = (int)(2 * Define.UnitOFpixel - Define.windowWidth + 384 - 24 + (int)movingPos.X);
        //            movingRect.X = (int)(movingRect.X + Define.windowWidth - 384 + 24 - (int)movingPos.X);
        //        }
        //        else
        //        {
        //            movingRect.Width = 2 * Define.UnitOFpixel;
        //        }
        //        return movingRect;
        //    }
        //}
        //public void Move(int time)
        //{
        //    Random ran = new Random();


        //    if (action == "move")
        //    {
        //        if (speedExecTime == 0)
        //        {
        //            speedH = ran.Next(0, 2) + (float)ran.NextDouble();
        //            speedV = (float)ran.NextDouble();
        //            speedRanTime = ran.Next(2000, 5000);
        //            speedDirect = ran.Next(0, 9);
        //            if (direct == "left" && (speedDirect == 1 || speedDirect == 5 || speedDirect == 7 || speedDirect == 3))
        //            {
        //                if (ran.Next(0, 101) < 30)
        //                {
        //                    action = "turn";
        //                    movingFrame.X = 0;
        //                    frameTime = 0;
        //                }
        //                else
        //                {
        //                    speedDirect++;
        //                }
        //            }
        //            if (direct == "right" && (speedDirect == 2 || speedDirect == 6 || speedDirect == 8 || speedDirect == 4))
        //            {
        //                if (ran.Next(0, 101) > 70)
        //                {
        //                    action = "turn";
        //                    movingFrame.X = 0;
        //                    frameTime = 0;
        //                }
        //                else
        //                {
        //                    speedDirect--;
        //                }
        //            }
        //        }
        //        frameTime += time;
        //        speedExecTime += time;
        //        if (speedExecTime > speedRanTime)
        //        {
        //            speedExecTime = 0;
        //        }
        //        if (frameTime > 100)
        //        {
        //            frameTime = 0;
        //            this.movingFrame.X += 2;
        //            if (this.movingFrame.X > 19)
        //            {
        //                this.movingFrame.X = 0;
        //            }
        //        }
        //        switch (speedDirect)
        //        {
        //            case 1:
        //                this.movingPos.X += speedH;
        //                break;
        //            case 2:
        //                this.movingPos.X -= speedH;
        //                break;
        //            case 3:
        //                this.movingPos.X += speedH;
        //                break;
        //            case 4:
        //                this.movingPos.X -= speedH;
        //                break;
        //            case 5:
        //                this.movingPos.X += speedH;
        //                this.movingPos.Y += speedV;
        //                break;
        //            case 6:
        //                this.movingPos.X -= speedH;
        //                this.movingPos.Y += speedV;
        //                break;
        //            case 7:
        //                this.movingPos.X += speedH;
        //                this.movingPos.Y -= speedV;
        //                break;
        //            case 8:
        //                this.movingPos.X -= speedH;
        //                this.movingPos.Y -= speedV;
        //                break;
        //            default:
        //                break;
        //        }
        //        if (this.movingPos.Y <= Define.windowHeight - 240 + 148)
        //        {
        //            if (speedDirect == 7)
        //            {
        //                speedDirect = 5;
        //            }
        //            if (speedDirect == 8)
        //            {
        //                speedDirect = 6;
        //            }
        //        }
        //        if (this.movingPos.Y >= Define.windowHeight - 240 + 48 + 14 * Define.UnitOFpixel)
        //        {
        //            if (speedDirect == 5)
        //            {
        //                speedDirect = 7;
        //            }
        //            if (speedDirect == 6)
        //            {
        //                speedDirect = 8;
        //            }
        //        }
        //    }

        //    else if (action == "turn")
        //    {
        //        frameTime += time;
        //        if (frameTime > 50)
        //        {
        //            frameTime = 0;
        //            movingFrame.X += 2;
        //            if (movingFrame.X > 17)
        //            {
        //                action = "move";
        //                speedExecTime = 1;
        //                if (direct == "left")
        //                {
        //                    direct = "right";
        //                }
        //                else
        //                {
        //                    direct = "left";
        //                }
        //            }
        //        }
        //    }
        //}

        //public void Shake(int time)
        //{
        //    shakeTime += time;
        //    if (shakeTime > 30)
        //    {
        //        shakeTime = 0;
        //        getCollide.X += 24;
        //        if (getCollide.X > 216)
        //        {
        //            getCollide.X = 0;
        //        }
        //    }

        //}

        #endregion

        int fishType; // 1 - Grayfish
        float weight;
        public Fish(string id, Map map, Vector2 position, string name, Texture2D texture, int type, int price, Point currentFrame, string introduction,float weight)
            : base(id, map, position, name, texture, price, introduction)
        {
            fishType = type;
            this.Category = "Fish";
            base.CurrentFrame = currentFrame;

            IsEquipment = false;

            
            this.weight = weight;
            
        }


        public static Fish Null = null;

        public int FishType
        {
            get { return fishType; }
        }

        public float Weight
        {
            get { return weight; }
            set { weight = value; }
        }


      

    }
}
