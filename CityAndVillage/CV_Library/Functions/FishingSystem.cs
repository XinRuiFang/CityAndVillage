using CV_Library.Controllers;
using CV_Library.GameObjects.Items;
using CV_Library.GameObjects.Soils;
using CV_Library.Globals;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Functions
{
    public class FishingSystem : GameObject,IGlobalScene
    {
        #region old code
        //Map map;
        //Vector2 hookPos;
        //Rectangle hookRect;
        //UIFrame fishing;
        //UIFrame hookLimitLeft;
        //UIFrame hookLimitRight;
        //float hookLimitDistance;
        //Vector2 hookAccelerate;
        //List<Vector2> linePosList;
        //Vector2 lineEndPos;
        //Vector2 lineStartPos;
        //float eagle;
        //float lineLength;
        //float hookRotation;
        //List<Fish> fishes;
        //Rectangle hookCollide;
        //bool hitting;
        //Vector2 hittingShowPos;
        //int hittingShowTime;
        //int hittingShow;
        //float hittingScale;
        //bool gettingModel;
        //Fish gettingFish;
        //Rectangle limitRect;
        //List<Vector2> limitRectPoint;
        //bool rectColor;
        //int rectColorShowTime;

        //public FishingSystem(Map map, float hookLimitDistance,float limitWidth)
        //{
        //    this.map = map;
        //    this.hookLimitDistance = hookLimitDistance;
        //    this.hookPos = new Vector2(Define.windowWidth - 384 + 15 * Define.UnitOFpixel, Define.windowHeight - 240 + 48 + 6 * Define.UnitOFpixel);
        //    this.hookRect = new Rectangle(4 * Define.UnitOFpixel + 8, 10 * Define.UnitOFpixel + 5, 12, 16);
        //    this.fishing = new UIFrame(new Point(0, 0), new Vector2(Define.windowWidth - 384, Define.windowHeight - 240 + 48), new Rectangle(0, 0, 16 * Define.UnitOFpixel, 10 * Define.UnitOFpixel), 0.8f, Color.White);
        //    this.hookLimitLeft = new UIFrame(new Point(5, 10), new Vector2(Define.windowWidth - this.hookLimitDistance / 2, Define.windowHeight - 240 + 48), new Rectangle(0, 0, 1 * Define.UnitOFpixel, 1 * Define.UnitOFpixel), 0.81f, Color.White);
        //    this.hookLimitRight = new UIFrame(new Point(6, 10), new Vector2(Define.windowWidth + this.hookLimitDistance / 2 - 2 * Define.UnitOFpixel, Define.windowHeight - 240 + 48), new Rectangle(0, 0, 1 * Define.UnitOFpixel, 1 * Define.UnitOFpixel), 0.81f, Color.White);
        //    this.hookAccelerate = new Vector2(0, 0);
        //    this.linePosList = new List<Vector2>();
        //    lineEndPos = new Vector2(this.hookPos.X, this.hookPos.Y);
        //    lineStartPos = new Vector2(this.hookPos.X, Define.windowHeight - 240 + 48);
        //    for (float i = lineStartPos.Y; i < lineEndPos.Y; i += 1)
        //    {
        //        linePosList.Add(new Vector2(lineEndPos.X, i));
        //    }
        //    this.eagle = 0;
        //    this.lineLength = 0;
        //    this.hookRotation = 0;
        //    fishes = new List<Fish>();
        //    this.hookCollide = new Rectangle(0, 0, 12, 16);
        //    hitting = false;
        //    hittingShowTime = 0;
        //    hittingShowPos = new Vector2();
        //    hittingShow = 0;
        //    hittingScale = 1;
        //    gettingModel = false;
        //    this.limitRect = new Rectangle((int)(Define.windowWidth - limitWidth / 2), Define.windowHeight - 240 + 48, (int)limitWidth, 0);
        //    limitRectPoint = new List<Vector2>();
        //    rectColor = true;
        //    rectColorShowTime = 0;
        //    gettingFish = Fish.Null;
        //}

        //public void HandleHook(int fishDirectStatus,int fishEagleStatus)
        //{
        //    if (!hitting)
        //    {
        //        switch (fishDirectStatus)
        //        {
        //            case 1:
        //                this.hookAccelerate.X -= 0.2f;
        //                break;
        //            case 2:
        //                this.hookAccelerate.Y += 0.1f;
        //                break;
        //            case 3:
        //                this.hookAccelerate.X += 0.2f;
        //                break;
        //            case 4:
        //                this.hookAccelerate.Y -= 0.1f;
        //                break;
        //            case 5:
        //                this.hookAccelerate.X -= 0.2f;
        //                this.hookAccelerate.Y += 0.1f;
        //                break;
        //            case 6:
        //                this.hookAccelerate.X -= 0.2f;
        //                this.hookAccelerate.Y -= 0.1f;
        //                break;
        //            case 7:
        //                this.hookAccelerate.X += 0.2f;
        //                this.hookAccelerate.Y -= 0.1f;
        //                break;
        //            case 8:
        //                this.hookAccelerate.X += 0.2f;
        //                this.hookAccelerate.Y += 0.1f;
        //                break;
        //            default:
        //                if (this.hookAccelerate.X > 0)
        //                {
        //                    this.hookAccelerate.X -= 0.01f;
        //                    if (this.hookAccelerate.X < 0.01f)
        //                    {
        //                        this.hookAccelerate.X = 0;
        //                    }
        //                }
        //                if (this.hookAccelerate.X < 0)
        //                {
        //                    this.hookAccelerate.X += 0.01f;
        //                    if (this.hookAccelerate.X > -0.01f)
        //                    {
        //                        this.hookAccelerate.X = 0;
        //                    }
        //                }
        //                if (this.hookAccelerate.Y > 0)
        //                {
        //                    this.hookAccelerate.Y -= 0.01f;
        //                    if (this.hookAccelerate.Y < 0.01f)
        //                    {
        //                        this.hookAccelerate.Y = 0;
        //                    }
        //                }
        //                if (this.hookAccelerate.Y < 0)
        //                {
        //                    this.hookAccelerate.Y += 0.01f;
        //                    if (this.hookAccelerate.Y > -0.01f)
        //                    {
        //                        this.hookAccelerate.Y = 0;
        //                    }
        //                }
        //                break;

        //        }
        //        if (this.hookAccelerate.X > 2f)
        //        {
        //            this.hookAccelerate.X = 2f;
        //        }
        //        if (this.hookAccelerate.X < -2f)
        //        {
        //            this.hookAccelerate.X = -2f;
        //        }
        //        if (this.hookAccelerate.Y > 2f)
        //        {
        //            this.hookAccelerate.Y = 2f;
        //        }
        //        if (this.hookAccelerate.Y < -2f)
        //        {
        //            this.hookAccelerate.Y = -2f;
        //        }

        //        float resistanceAccelerate = ((this.hookPos.Y / 150 - 1) * 0.8f <= 0 ? 0 : (this.hookPos.Y / 150 - 1) * 0.8f) > 1.9f ? 1.9f : ((this.hookPos.Y / 150 - 1) * 0.8f <= 0 ? 0 : (this.hookPos.Y / 150 - 1) * 0.8f);

        //        this.hookPos.Y += this.hookAccelerate.Y > 0 ? ((this.hookAccelerate.Y - resistanceAccelerate) < 0 ? 0 : (this.hookAccelerate.Y - resistanceAccelerate)) : ((this.hookAccelerate.Y + resistanceAccelerate) > 0 ? 0 : (this.hookAccelerate.Y + resistanceAccelerate));
        //        if (gettingModel)
        //        {
        //            this.hookPos.Y += GettingFishEscape();
        //        }
        //        if (eagle == 0)
        //        {
        //            this.lineLength = this.hookPos.Y - Define.windowHeight + 240 - 48;
        //        }
        //        else
        //        {
        //            this.lineLength = (float)Math.Sqrt(Math.Pow(Math.Abs(this.hookPos.X - this.lineStartPos.X), 2) + Math.Pow(Math.Abs(this.hookPos.Y - this.lineStartPos.Y), 2));
        //        }
        //        this.lineStartPos.X += this.hookAccelerate.X > 0 ? ((this.hookAccelerate.X - resistanceAccelerate) < 0 ? 0 : (this.hookAccelerate.X - resistanceAccelerate)) : ((this.hookAccelerate.X + resistanceAccelerate) > 0 ? 0 : (this.hookAccelerate.X + resistanceAccelerate));

        //        if (this.lineStartPos.X < Define.windowWidth - this.hookLimitDistance / 2)
        //        {
        //            this.lineStartPos.X = Define.windowWidth - this.hookLimitDistance / 2;
        //        }
        //        if (this.lineStartPos.X > Define.windowWidth + this.hookLimitDistance / 2)
        //        {
        //            this.lineStartPos.X = Define.windowWidth + this.hookLimitDistance / 2;
        //        }

        //        if (fishEagleStatus == 1)
        //        {
        //            if (eagle > -Math.PI / 12)
        //            {
        //                eagle -= 0.004f;
        //                //hookRotation += 0.002f;
        //            }

        //        }
        //        if (fishEagleStatus == 2)
        //        {
        //            if (eagle < Math.PI / 12)
        //            {
        //                eagle += 0.004f;
        //                //hookRotation -= 0.002f;
        //            }

        //        }



        //        if (fishEagleStatus == 0)
        //        {
        //            if (eagle > 0)
        //            {
        //                eagle -= 0.002f;
        //            }
        //            else if (eagle < 0)
        //            {
        //                eagle += 0.002f;
        //            }
        //            if (Math.Abs(eagle) < 0.002f)
        //            {
        //                eagle = 0;
        //            }
        //        }
        //        if (gettingModel)
        //        {
        //            eagle += GettingFishRotation();
        //        }
        //        if (eagle > 0)
        //        {
        //            this.hookPos.X = this.lineStartPos.X + (float)Math.Sin(eagle) * this.lineLength;
        //            this.hookPos.Y = this.lineStartPos.Y + (float)Math.Cos(eagle) * this.lineLength;
        //        }
        //        else if (eagle < 0)
        //        {
        //            this.hookPos.X = this.lineStartPos.X - (float)Math.Sin(-eagle) * this.lineLength;
        //            this.hookPos.Y = this.lineStartPos.Y + (float)Math.Cos(-eagle) * this.lineLength;
        //        }
        //        else
        //        {
        //            this.hookPos.X = this.lineStartPos.X;
        //            this.hookPos.Y = this.lineStartPos.Y + this.lineLength;
        //        }

        //        if (this.hookPos.Y < Define.windowHeight - 240 + 48 + 6)
        //        {
        //            FishEnd();
        //        }
        //        if (this.hookPos.Y > Define.windowHeight - 240 + 48 + 18 * Define.UnitOFpixel - 30)
        //        {
        //            this.hookPos.Y = Define.windowHeight - 240 + 48 + 18 * Define.UnitOFpixel - 30;
        //        }
        //        lineEndPos = new Vector2(this.hookPos.X, this.hookPos.Y);
        //        Vector2 p1 = new Vector2(this.lineStartPos.X, this.lineEndPos.Y);
        //        linePosList.Clear();
        //        for (int i = 0; i <= 500; i++)
        //        {
        //            linePosList.Add((float)Math.Pow(1 - i / 500f, 2) * lineStartPos + 2 * i / 500f * (1 - i / 500f) * p1 + (float)Math.Pow(i / 500f, 2) * lineEndPos);
        //        }
        //    }
        //}

        //public void HandleFish(int time)
        //{
        //    if (!hitting && !gettingModel)
        //    {
        //        for (int i = 0; i < fishes.Count; i++)
        //        {
        //            if (this.HookCollide.Intersects(fishes[i].HitCollide))
        //            {
        //                hitting = true;
        //                hittingShowPos = new Vector2(hookPos.X + 10, hookPos.Y - 30);
        //                gettingFish = fishes[i];
        //            }
        //        }
        //        for (int i = 0; i < fishes.Count; i++)
        //        {
        //            fishes[i].Move(time);
        //            if (fishes[i].MovingPos.X < Define.windowWidth - 384 - 2 * Define.UnitOFpixel || fishes[i].MovingPos.X > Define.windowWidth + 384)
        //            {
        //                fishes.Remove(fishes[i]);
        //            }
        //        }
        //        if (fishes.Count < 4)
        //        {
        //            Random ran = new Random();
        //            Fish fish = Item.ItemCreateFactory("06_001") as Fish;
        //            fish.MovingLd = ran.Next(81, 83) / 100f + (float)ran.NextDouble() / 100f;
        //            if (ran.Next(1, 100) > 50)
        //            {
        //                fish.MovingPos = new Vector2(Define.windowWidth + 384 - 24, ran.Next(Define.windowHeight - 240 + 151, Define.windowHeight - 240 + 45 + 14 * Define.UnitOFpixel));
        //                fish.Direct = "left";
        //            }
        //            else
        //            {
        //                fish.MovingPos = new Vector2(Define.windowWidth - 384 - 2 * Define.UnitOFpixel, ran.Next(Define.windowHeight - 240 + 151, Define.windowHeight - 240 + 45 + 14 * Define.UnitOFpixel));
        //                fish.Direct = "right";
        //            }
        //            fishes.Add(fish);
        //        }
        //    }
        //    else if(hitting)
        //    {
        //        hittingShowTime += time;
        //        if (hittingShow % 2 == 0)
        //        {
        //            hittingScale = 1 + hittingShowTime / 300f;
        //        }
        //        else
        //        {
        //            hittingScale = 1 + (300 - hittingShowTime) / 300f;
        //        }
        //        if (hittingShowTime > 300)
        //        {
        //            hittingShow++;                   
        //            hittingShowTime = 0;
        //        }
        //        if(hittingShow == 4)
        //        {
        //            hitting = false;
        //            hittingShow = 0;
        //            gettingModel = true;
        //            fishes.Clear();
        //            limitRectPoint.Clear();
        //            limitRect.X = (int)(this.hookPos.X - limitRect.Width / 2f);
        //            limitRect.Height = (int)((this.hookPos.Y + 3 * Define.UnitOFpixel) - limitRect.Y);
        //            for (int i = limitRect.X; i <=limitRect.X + limitRect.Width; i++)
        //            {
        //                limitRectPoint.Add(new Vector2(i, limitRect.Y));
        //            }
        //            for (int i = limitRect.X; i <= limitRect.X + limitRect.Width; i++)
        //            {
        //                limitRectPoint.Add(new Vector2(i, limitRect.Height + limitRect.Y));
        //            }
        //            for (int i = limitRect.Y; i <= limitRect.Height + limitRect.Y; i++)
        //            {
        //                limitRectPoint.Add(new Vector2(limitRect.X, i));
        //            }
        //            for (int i = limitRect.Y; i <= limitRect.Height + limitRect.Y; i++)
        //            {
        //                limitRectPoint.Add(new Vector2(limitRect.X + limitRect.Width, i));
        //            }

        //        }
        //    }
        //    else if (gettingModel)
        //    {
        //        gettingFish.Shake(time);
        //        if (Math.Abs(this.hookPos.X - this.limitRect.X) < 35 || Math.Abs(this.hookPos.X - this.limitRect.X - this.limitRect.Width) < 35 || Math.Abs(this.hookPos.Y - this.limitRect.Y - this.limitRect.Height) < 35)
        //        {
        //            rectColorShowTime += time;
        //            if (rectColorShowTime > 100)
        //            {
        //                rectColorShowTime = 0;
        //                rectColor = !rectColor;
        //            }
        //        }
        //        else
        //        {
        //            rectColor = true;
        //        }
        //        if (!this.limitRect.Intersects(this.HookCollide) && !this.limitRect.Contains(this.HookCollide))
        //        {
        //            FishEnd();
        //        }
        //    }
        //}

        //float GettingFishEscape()
        //{          
        //    Random ran = new Random();
        //    return (float)(ran.Next(0, 100) > 50 ? ran.NextDouble() : 0.5f + ran.NextDouble());
        //}

        //float GettingFishRotation()
        //{
            
        //    Random ran = new Random();
        //    if (ran.Next(1, 10) > 8)
        //    {
        //        return (float)(ran.Next(0, 100) > 50 ? ran.Next(1, 6) / 100f : -ran.Next(1, 6) / 100f);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //void FishEnd()
        //{
        //    if (gettingFish != Fish.Null)
        //    {
        //        GlobalController._Cv_func._Global_AddNewItemToBag(gettingFish);
        //    }
        //    GlobalController.PlayerIsFishing = false;
        //    GlobalController.rodPos = new Vector2(-1, -1);
        //}

        //public Vector2 HookPos
        //{
        //    get { return hookPos; }
        //    set { hookPos = value; }
        //}

        //public Rectangle HookRect
        //{
        //    get { return hookRect; }
        //    set { hookRect = value; }
        //}

        //public Rectangle HookCollide
        //{
        //    get 
        //    {
        //        this.hookCollide.X = (int)(hookPos.X + 8);
        //        this.hookCollide.Y = (int)(hookPos.Y + 5);
        //        return hookCollide; 
        //    }
            
        //}
        //public string GetMap()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Draw(SpriteBatch b)
        //{
        //    b.Draw(ResourceController.Systems_fishingsys, this.fishing.Pos, this.fishing.Rect, this.fishing.Color, 0, Vector2.Zero, 2, SpriteEffects.None, this.fishing.LayerDepth);
        //    if (!gettingModel)
        //    {
        //        b.Draw(ResourceController.Systems_fishingsys, new Vector2(this.hookPos.X - 8, this.hookPos.Y - 4), this.hookRect, Color.White, this.hookRotation, Vector2.Zero, 2, SpriteEffects.None, 0.82f);
        //    }

        //    b.Draw(ResourceController.Systems_fishingsys, this.hookLimitLeft.Pos, this.hookLimitLeft.Rect, this.hookLimitLeft.Color, 0, Vector2.Zero, 2, SpriteEffects.None, this.hookLimitLeft.LayerDepth);
        //    b.Draw(ResourceController.Systems_fishingsys, this.hookLimitRight.Pos, this.hookLimitRight.Rect, this.hookLimitRight.Color, 0, Vector2.Zero, 2, SpriteEffects.None, this.hookLimitRight.LayerDepth);
        //    foreach (Vector2 item in linePosList)
        //    {
        //        b.Draw(ResourceController.Systems_fishingsys, item, new Rectangle(384, 0, 1, 1), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0.82f);
        //    }
        //    foreach (Fish item in fishes)
        //    {
        //        b.Draw(ResourceController.Systems_fishingsys, item.MovingPos, item.MovingRect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, item.MovingLd);
        //    }
        //    if (hitting)
        //    {
        //        b.Draw(ResourceController.Systems_fishingsys, hittingShowPos, new Rectangle(7 * Define.UnitOFpixel, 10 * Define.UnitOFpixel, 2 * Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, hittingScale, SpriteEffects.None, 0.83f);
        //    }
        //    if (gettingModel)
        //    {
        //        foreach (Vector2 item in limitRectPoint)
        //        {
        //            b.Draw(ResourceController.Systems_fishingsys, item, rectColor ? new Rectangle(385, 0, 1, 1) : new Rectangle(386, 0, 1, 1), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0.81f);
        //        }
        //        b.Draw(ResourceController.Systems_fishingsys, new Vector2(this.hookPos.X - Define.UnitOFpixel / 2, this.hookPos.Y), gettingFish.GetCollide, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, gettingFish.MovingLd + 0.02f);
        //    }
        //}

        //public Microsoft.Xna.Framework.Rectangle GetCollider()
        //{
        //    throw new NotImplementedException();
        //}

        //public GameObject GetInstance()
        //{
        //    throw new NotImplementedException();
        //}

        //public string GetIntanceType()
        //{
        //    throw new NotImplementedException();
        //}
        #endregion
        int step;
        float fishingBarPercent;
        UIFrame fishingProcessBack;
        UIFrame fishingProcessBar;
        Rectangle fishingProcessBarRect;
        bool pressDirect;
        Vector2 hookStartPos;
        Vector2 hookEndPos;
        Vector2 hookPos;
        List<Vector2> fishLine;
        List<Vector2> hookRunLine;
        int iLine;
        int hookAnimTime;
        Point hookFrame;
        Rectangle hookRect;
        int randomGetTime;
        int waitTime;
        bool gettingFish;
        int getWaitingTime;
        float fishingModelBarPercent;
        UIFrame fishingModelProcessBack;
        UIFrame fishingModelProcessBar;
        Rectangle fishingModelProcessBarRect;
        int fishEscapeDirect;
        float fishEscapeStrength;
        int fishStengthDurTime;
        int fishStengthTime;
        float strengthAccelerate;
        float keyStrength;
        int direct;
        Fish fish;


        int keyDirect;
        float strength;
        float playerStrength;

        float fishLineStrength;
        Vector2 standardHookPos;



        public static FishingSystem Null = null;

        public FishingSystem(Map map)
        {
            this.map = map;

            Random ran = new Random();
            this.step = 1;
            this.fishingBarPercent = 0;
            this.fishingProcessBack = new UIFrame(new Point(7, 6), new Vector2(GlobalController.Player.RenderPosition.X - Define.UnitOFpixel, GlobalController.Player.RenderPosition.Y - Define.UnitOFpixel), new Rectangle(0, 0, 3 * Define.UnitOFpixel, Define.UnitOFpixel), 0.99f, Color.White);
            this.fishingProcessBar = new UIFrame(new Point(7, 7), new Vector2(GlobalController.Player.RenderPosition.X - Define.UnitOFpixel, GlobalController.Player.RenderPosition.Y - Define.UnitOFpixel), new Rectangle(0, 0, 3 * Define.UnitOFpixel, Define.UnitOFpixel), 1f, Color.White);
            this.fishingProcessBarRect = new Rectangle(7 * Define.UnitOFpixel + 10, 7 * Define.UnitOFpixel + 8, 3 * Define.UnitOFpixel, 8);
            this.pressDirect = true;
            this.fishLine = new List<Vector2>();
            this.hookRunLine = new List<Vector2>();
            iLine = 0;
            hookAnimTime = 0;
            hookFrame = new Point(0, 24);
            this.hookRect = new Rectangle(0, 0, Define.UnitOFpixel, Define.UnitOFpixel);
            randomGetTime = ran.Next(2000, 8000);
            waitTime = 0;
            gettingFish = false;
            getWaitingTime = 0;
            this.fishingModelBarPercent = 0;
            this.fishingModelProcessBack = new UIFrame(new Point(12, 7), new Vector2(GlobalController.Player.RenderPosition.X - Define.UnitOFpixel, GlobalController.Player.RenderPosition.Y - Define.UnitOFpixel), new Rectangle(0, 0, Define.UnitOFpixel, 3 * Define.UnitOFpixel), 0.99f, Color.White);
            this.fishingModelProcessBar = new UIFrame(new Point(11, 7), new Vector2(GlobalController.Player.RenderPosition.X - Define.UnitOFpixel, GlobalController.Player.RenderPosition.Y - Define.UnitOFpixel), new Rectangle(0, 0, Define.UnitOFpixel, 3 * Define.UnitOFpixel), 1f, Color.White);
            this.fishingModelProcessBarRect = new Rectangle(11 * Define.UnitOFpixel + 1, 7 * Define.UnitOFpixel + 1, 8, 3 * Define.UnitOFpixel);
            fishEscapeDirect = -1;
            fishEscapeStrength = 0;
            fishStengthDurTime = 0;
            fishStengthTime = 0;
            strengthAccelerate = 0;
            keyStrength = 0;
            strength = 0;
            direct = -1;
            fishLineStrength = 0;
            playerStrength = 0;
            standardHookPos = new Vector2(-1, -1);
        }

        public void Handle(int time)
        {
            if (step == 2)
            {
                FishLineHandle();

                this.hookPos = this.hookRunLine[iLine];
                iLine++;
                if (iLine == 75)
                {
                    bool isWater = false;
                    foreach (Vector2 item in GlobalController.WaterJudge)
                    {
                        if (this.HookPos.X >= item.X && this.HookPos.X <= item.X + Define.UnitOFpixel && this.HookPos.Y >= item.Y && this.HookPos.Y <= item.Y + Define.UnitOFpixel)
                        {
                            isWater = true;
                        }
                    }
                    if (isWater)
                    {
                        step = 3;
                        hookFrame.X += 1;
                    }
                    else
                    {
                        FishingEnd(false);
                    }

                }
            }
            if (step == 3)
            {       
                waitTime += time;
                if (waitTime > randomGetTime)
                {
                    gettingFish = true;
                    hookAnimTime += time;
                    getWaitingTime += time;
                    if (hookAnimTime > 100)
                    {
                        hookAnimTime = 0;
                        if (hookFrame.X < 4)
                        {
                            hookFrame.X = 4;
                        }
                        hookFrame.X += 1;
                        if (hookFrame.X > 7)
                        {
                            hookFrame.X = 4;
                        }
                        if (hookFrame.X == 5 || hookFrame.X == 7)
                        {
                            this.hookPos.Y += 5;
                        }
                        else if (hookFrame.X == 6 || hookFrame.X == 4)
                        {
                            this.hookPos.Y -= 5;
                        }
                    }
                    if (getWaitingTime > 1000)
                    {
                        if (hookFrame.X == 5 || hookFrame.X == 7)
                        {
                            this.hookPos.Y -= 5;
                        }
                        if (hookFrame.X == 6 || hookFrame.X == 4)
                        {
                            this.hookPos.Y += 5;
                        }
                        hookFrame.X = 1;
                        gettingFish = false;
                        getWaitingTime = 0;
                        Random ran = new Random();
                        waitTime = 0;
                        randomGetTime = ran.Next(2000, 8000);
                    }
                }
                else
                {
                    hookAnimTime += time;
                    if (hookAnimTime > 1000)
                    {
                        hookAnimTime = 0;
                        hookFrame.X += 1;
                        if (hookFrame.X == 2)
                        {
                            this.hookPos.Y += 4;
                        }
                        else if (hookFrame.X == 3)
                        {
                            this.hookPos.Y -= 4;
                        }
                        if (hookFrame.X > 3)
                        {
                            hookFrame.X = 1;
                        }
                    }
                }
                FishLineHandle();
            }
            if (step == 4)
            {
                if (GlobalController.MouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    strength += strengthAccelerate;
                }
                else
                {
                    strength -= strengthAccelerate;
                }
                if (strength > 40)
                {
                    strength = 40;
                }
                if (strength < 0)
                {
                    strength = 0;
                }
                FishEscapeHandle(time);

                float dirStrength_1 = 0;
                float dirStrength_2 = 0;
                float dirStrength_3 = 0;
                float dirStrength_4 = 0;
                float dirStrength_5 = 0;
                float dirStrength_6 = 0;
                float dirStrength_7 = 0;
                float dirStrength_8 = 0;



                switch (fishEscapeDirect)
                {
                    case 1:
                        dirStrength_1 += fishEscapeStrength;
                        break;
                    case 2:
                        dirStrength_2 += fishEscapeStrength;
                        break;
                    case 3:
                        dirStrength_3 += fishEscapeStrength;
                        break;
                    case 4:
                        dirStrength_4 += fishEscapeStrength;
                        break;
                    case 5:
                        dirStrength_5 += fishEscapeStrength;
                        break;
                    case 6:
                        dirStrength_6 += fishEscapeStrength;
                        break;
                    case 7:
                        dirStrength_7 += fishEscapeStrength;
                        break;
                    case 8:
                        dirStrength_8 += fishEscapeStrength;
                        break;
                    default:
                        break;
                }

                switch (keyDirect)
                {
                    case 1:
                        fishLineStrength += PlayerStrength;
                        dirStrength_1 += fishLineStrength;
                        break;
                    case 2:
                        fishLineStrength += PlayerStrength;
                        dirStrength_2 += fishLineStrength;
                        break;
                    case 3:
                        fishLineStrength += PlayerStrength;
                        dirStrength_3 += fishLineStrength;
                        break;
                    case 4:
                        fishLineStrength += PlayerStrength;
                        dirStrength_4 += fishLineStrength;
                        break;
                    case 5:
                        fishLineStrength += PlayerStrength;
                        dirStrength_5 += fishLineStrength;
                        break;
                    case 6:
                        fishLineStrength += PlayerStrength;
                        dirStrength_6 += fishLineStrength;
                        break;
                    case 7:
                        fishLineStrength += PlayerStrength;
                        dirStrength_7 += fishLineStrength;
                        break;
                    case 8:
                        fishLineStrength += PlayerStrength;
                        dirStrength_8 += fishLineStrength;
                        break;
                    default:
                        fishLineStrength -= 10 * PlayerStrength;
                        break;
                }
                if (fishLineStrength < 0)
                {
                    fishLineStrength = 0;
                }
                if (fishLineStrength > 10)
                {
                    fishLineStrength = 5;
                }
                keyDirect = 0;
                switch (Direct)
                {
                    case 0:
                        this.hookPos.Y -= strength / 50f;
                        break;
                    case 1:
                        this.hookPos.X += strength / 50f;
                        break;
                    case 2:
                        if (dirStrength_1 != 0)
                        {
                            this.hookPos.X -= dirStrength_1 / 100f;

                        }
                        if (dirStrength_2 != 0)
                        {
                            this.hookPos.Y += dirStrength_2 / 100f;
                        }
                        if (dirStrength_3 != 0)
                        {
                            this.hookPos.X += dirStrength_3 / 100f;
                        }
                        if (dirStrength_4 != 0)
                        {
                            this.hookPos.Y -= dirStrength_4 / 100f;
                        }
                        if (dirStrength_5 != 0)
                        {
                            this.hookPos.X -= dirStrength_5 / 100f;
                            this.hookPos.Y += dirStrength_5 / 100f;
                        }
                        if (dirStrength_6 != 0)
                        {
                            this.hookPos.X -= dirStrength_6 / 100f;
                            this.hookPos.Y -= dirStrength_6 / 100f;
                        }
                        if (dirStrength_7 != 0)
                        {
                            this.hookPos.Y -= dirStrength_7 / 100f;
                            this.hookPos.X += dirStrength_7 / 100f;
                        }
                        if (dirStrength_8 != 0)
                        {
                            this.hookPos.Y += dirStrength_8 / 100f;
                            this.hookPos.X += dirStrength_8 / 100f;
                        }
                        break;
                    case 3:
                        this.hookPos.Y += strength / 50f;
                        break;
                    default:
                        break;
                }
                switch (Direct)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        this.hookPos.X -= strength / 100f;
                        this.standardHookPos.X -= strength / 100f;
                        if (this.standardHookPos.X <= GlobalController.Player.Position.X + 2 * Define.UnitOFpixel)
                        {
                            FishingEnd(true);
                        }
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }

                fishingModelBarPercent = ((float)Math.Abs(this.hookPos.X - this.standardHookPos.X) / 96f + (float)Math.Abs(this.hookPos.Y - this.standardHookPos.Y) / 96f) + ((float)Math.Abs(this.hookPos.X - this.standardHookPos.X) / 96f + (float)Math.Abs(this.hookPos.Y - this.standardHookPos.Y) / 96f) * strength / 20;
                FishLineStraightHandle();
                if (fishingModelBarPercent > 1)
                {
                    FishingEnd(false);
                }
            }
        }

        void FishEscapeHandle(int time)
        {
            Random ran = new Random();
            if (fishStengthTime == 0)
            {
                fishEscapeStrength = ran.Next(1, 11) + (float)ran.NextDouble();
                fishStengthDurTime = ran.Next(1000, 2000);
                fishEscapeDirect = ran.Next(1, 9);
            }
            fishStengthTime += time;
            if (fishStengthTime > fishStengthDurTime)
            {
                fishStengthTime = 0;
            }            
        }
        void FishLineHandle()
        {
            this.fishLine.Clear();
            Point p0 = new Point((int)this.HookStartPos.X, (int)this.HookStartPos.Y);
            Point p1 = new Point((int)this.hookPos.X, (int)this.hookPos.Y - Define.UnitOFpixel);
            Point p2 = new Point((int)this.hookPos.X + 12, (int)this.hookPos.Y + 5);
            int pointNUM = (int)(this.hookPos.X - this.hookStartPos.X);
            pointNUM *= 2;

            if (pointNUM > 0)
            {
                for (float i = 0; i <= pointNUM; i += 0.5f)
                {
                    Vector2 p = new Vector2();
                    p.X = (float)((float)Math.Pow(1 - i * 1f / pointNUM * 1f, 2) * p0.X + 2 * i * 1f / pointNUM * 1f * (1 - i * 1f / pointNUM * 1f) * p1.X + (float)Math.Pow(i * 1f / pointNUM * 1f, 2) * p2.X);
                    p.Y = (float)((float)Math.Pow(1 - i * 1f / pointNUM * 1f, 2) * p0.Y + 2 * i * 1f / pointNUM * 1f * (1 - i * 1f / pointNUM * 1f) * p1.Y + (float)Math.Pow(i * 1f / pointNUM * 1f, 2) * p2.Y);
                    this.fishLine.Add(p);
                }
            }
        }

        void FishLineStraightHandle()
        {
            this.fishLine.Clear();
            Point p0 = new Point((int)this.HookStartPos.X, (int)this.HookStartPos.Y);
            Point p1 = new Point((int)this.hookPos.X + 12, (int)this.hookPos.Y + 5);
            int pointNUM = (int)(this.hookPos.X - this.hookStartPos.X);
            pointNUM *= 2;

            if (pointNUM > 0)
            {
                for (float i = 0; i <= pointNUM; i += 0.5f)
                {
                    Vector2 p = new Vector2();
                    p.X = (float)(p0.X + (p1.X - p0.X) * (i * 1f / pointNUM * 1f));
                    p.Y = (float)(p0.Y + (p1.Y - p0.Y) * (i * 1f / pointNUM * 1f));
                    this.fishLine.Add(p);
                }
            }
        }

        void FishingEnd(bool success)
        {
            if (success)
            {
                GlobalController._Cv_func._Global_AddNewItemToBag(fish);
            }
            GlobalController.PlayerIsFishing = false;
            GlobalController.FishingSys = FishingSystem.Null;
        }
        public int Step
        {
            get { return step; }
            set { step = value; }
        }

        public bool PressDirect
        {
            get { return pressDirect; }
            set { pressDirect = value; }
        }


        public float KeyStrength
        {
            get { return keyStrength; }
            set { keyStrength = value; }
        }
        public Vector2 HookStartPos
        {
            get { return hookStartPos; }
            set { hookStartPos = value; }
        }
        public Vector2 HookEndPos
        {
            get { return hookEndPos; }
            set { hookEndPos = value; }
        }
        public Vector2 HookPos
        {
            get { return hookPos; }
            set { hookPos = value; }
        }

        public List<Vector2> HookRunLine
        {
            get { return hookRunLine; }
            set { hookRunLine = value; }
        }

        public float FishingBarPercent
        {
            get { return fishingBarPercent; }
            set { fishingBarPercent = value; }
        }

        Rectangle FishingProcessBarRect
        {
            get
            {
                fishingProcessBarRect.Width = (int)(54 * FishingBarPercent);
                return fishingProcessBarRect;
            }
        }

        public float FishingModelBarPercent
        {
            get { return fishingModelBarPercent; }
            set { fishingModelBarPercent = value; }
        }

        Rectangle FishingModelProcessBarRect
        {
            get
            {
                fishingModelProcessBarRect.Height = (int)(54 * FishingModelBarPercent);
                return fishingModelProcessBarRect;
            }
        }
        public bool GettingFish
        {
            get { return gettingFish; }
            set { gettingFish = value; }
        }
        float GetHookLaterDepth
        {
            get 
            {
                return this.hookPos.Y / Define.UnitOFpixel / map.Size.Y;
            }
        }

        public Point HookFrame
        {
            get { return hookFrame; }
            set { hookFrame = value; }
        }


        public Rectangle HookRect
        {
            get 
            {
                this.hookRect.X = HookFrame.X * Define.UnitOFpixel;
                this.hookRect.Y = HookFrame.Y * Define.UnitOFpixel;
                return hookRect; 
            }
        }

        public int Direct
        {
            get { return direct; }
            set { direct = value; }
        }

        public int KeyDirect
        {
            get { return keyDirect; }
            set { keyDirect = value; }
        }

        public float StrengthAccelerate
        {
            get { return strengthAccelerate; }
            set { strengthAccelerate = value; }
        }

        public Vector2 StandardHookPos
        {
            get { return standardHookPos; }
            set { standardHookPos = value; }
        }


        public float PlayerStrength
        {
            get { return playerStrength; }
            set { playerStrength = value; }
        }

        public Fish Fish
        {
            get { return fish; }
            set { fish = value; }
        }
        public string GetMap()
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch b)
        {
            if (step == 1)
            {
                b.Draw(ResourceController.UI_ordinary, new Vector2(GlobalController.Player.RenderPosition.X * 2 - Define.UnitOFpixel * 2, GlobalController.Player.RenderPosition.Y * 2 - Define.UnitOFpixel * 2), this.fishingProcessBack.Rect, this.fishingProcessBack.Color, 0, Vector2.Zero, 2, SpriteEffects.None, 0.99f);
                b.Draw(ResourceController.UI_ordinary, new Vector2(GlobalController.Player.RenderPosition.X * 2 - Define.UnitOFpixel * 2 + 20, GlobalController.Player.RenderPosition.Y * 2 - Define.UnitOFpixel * 2 + 16), this.FishingProcessBarRect, this.fishingProcessBar.Color, 0, Vector2.Zero, 2, SpriteEffects.None, 1f);
            }
            if (step == 2)
            {
                b.Draw(ResourceController.Scenes_water, new Vector2(Camera.HandlePos(this.hookPos, GlobalController.Camera).X * 2, Camera.HandlePos(this.hookPos, GlobalController.Camera).Y * 2), HookRect, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, GetHookLaterDepth);
                foreach (Vector2 p in fishLine)
                {
                    b.Draw(ResourceController.Systems_fishingsys, new Vector2(Camera.HandlePos(new Vector2(p.X, p.Y), GlobalController.Camera).X * 2, Camera.HandlePos(new Vector2(p.X, p.Y), GlobalController.Camera).Y * 2), new Rectangle(384, 0, 1, 1), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, GetHookLaterDepth + 0.0001f);
                }
            }
            if (step == 3)
            {
                b.Draw(ResourceController.Scenes_water, new Vector2(Camera.HandlePos(this.hookPos, GlobalController.Camera).X * 2, Camera.HandlePos(this.hookPos, GlobalController.Camera).Y * 2), HookRect, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, GetHookLaterDepth);
                foreach (Vector2 p in fishLine)
                {
                    b.Draw(ResourceController.Systems_fishingsys, new Vector2(Camera.HandlePos(new Vector2(p.X, p.Y), GlobalController.Camera).X * 2, Camera.HandlePos(new Vector2(p.X, p.Y), GlobalController.Camera).Y * 2), new Rectangle(384, 0, 1, 1), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, GetHookLaterDepth + 0.0001f);
                }
            }
            if (step == 4)
            {
                foreach (Vector2 p in fishLine)
                {
                    b.Draw(ResourceController.Systems_fishingsys, new Vector2(Camera.HandlePos(new Vector2(p.X, p.Y), GlobalController.Camera).X * 2, Camera.HandlePos(new Vector2(p.X, p.Y), GlobalController.Camera).Y * 2), new Rectangle(384, 0, 1, 1), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, GetHookLaterDepth + 0.0001f);
                }
                b.Draw(ResourceController.Scenes_water, new Vector2(Camera.HandlePos(this.standardHookPos, GlobalController.Camera).X * 2, Camera.HandlePos(this.standardHookPos, GlobalController.Camera).Y * 2), new Rectangle(192, 576, Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, GetHookLaterDepth - 0.001f);
                b.Draw(ResourceController.UI_ordinary, new Vector2(GlobalController.Player.RenderPosition.X * 2 - Define.UnitOFpixel * 2, GlobalController.Player.RenderPosition.Y * 2 - Define.UnitOFpixel * 2), this.fishingModelProcessBack.Rect, this.fishingModelProcessBack.Color, 0, Vector2.Zero, 2, SpriteEffects.None, 0.99f);
                b.Draw(ResourceController.UI_ordinary, new Vector2(GlobalController.Player.RenderPosition.X * 2 - Define.UnitOFpixel * 2 + 2, GlobalController.Player.RenderPosition.Y * 2 - Define.UnitOFpixel * 2 + 2 + (54 - FishingModelProcessBarRect.Height) * 2), this.FishingModelProcessBarRect, this.fishingModelProcessBar.Color, 0, Vector2.Zero, 2, SpriteEffects.None, 1f);
            }
        }

        public Rectangle GetCollider()
        {
            throw new NotImplementedException();
        }

        public GameObject GetInstance()
        {
            throw new NotImplementedException();
        }

        public string GetIntanceType()
        {
            throw new NotImplementedException();
        }
    }
    
}
