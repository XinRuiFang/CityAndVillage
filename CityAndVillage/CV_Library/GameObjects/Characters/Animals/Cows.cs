using CV_Library.GameObjects.Buildings;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Characters.Animals
{

    public class Cows : Animals
    {
        public struct MoveInStruct
        {
            public int direct;
            public int dirTime;
        }
        public struct IdleInstruct
        {
            public int direct;
            public int dirTime;
        }

        public struct AnimInstruct
        {
            public int direct;
            public int dirTime;
        }
        public struct TileDS
        {
            public Vector2 fatherPos;
            public Vector2 pos;
            public float g;
            public float h;
        }

        List<TileDS> openList = new List<TileDS>();
        List<TileDS> closeList = new List<TileDS>();

        float growTime;
        int sheetSize;
        int direct;
        float speed;
        int moveFrame;
        int animframeTime;
        int eatProgress;
        bool usingProgress;


        string action;
        int actionDuringTime;

        MoveInStruct moveInstruct;
        IdleInstruct idleInstruct;
        AnimInstruct animInstruct;


        List<TileDS> path = new List<TileDS>();
        


        public Cows(Map map, Vector2 position, Texture2D texture, Point size, string name)
            : base(map, position, texture, size, name)
        {
            this.renderRectangle = new Rectangle(0, 0, size.X * Define.UnitOFpixel, size.Y * Define.UnitOFpixel);
            this.sheetSize = 12;
            this.direct = 0;
            this.speed = 0.3f;
            this.animframeTime = 0;
            this.moveFrame = 0;
            this.eatProgress = 0;
            this.usingProgress = false;

            this.moveInstruct = new MoveInStruct();
            this.idleInstruct = new IdleInstruct();
            this.animInstruct = new AnimInstruct();

            CowAIHanlder();
        }

        public override void ActionHandler(int time)
        {
            actionDuringTime += time;
            switch (action)
            {
                case "move":
                    if (actionDuringTime < moveInstruct.dirTime)
                    {
                        Move(time, moveInstruct.direct);
                    }
                    else
                    {
                        CowAIHanlder();
                    }
                    break;
                case "idle":
                    if (actionDuringTime < idleInstruct.dirTime)
                    {
                        Idle(idleInstruct.direct);
                    }
                    else
                    {
                        CowAIHanlder();
                    }
                    break;
                case "anim":
                    if (actionDuringTime < animInstruct.dirTime)
                    {
                        Anim(time, animInstruct.direct);
                    }
                    else
                    {
                        CowAIHanlder();
                    }
                    break;
                default:
                    break;
            }
        }

        public override void FindPath()
        {
            this.position = new Vector2((int)this.position.X, (int)this.position.Y);
            TileDS start = new TileDS();
            start.pos = new Vector2((int)this.position.X / Define.UnitOFpixel,(int)this.position.Y / Define.UnitOFpixel);
            start.g = 0;
            start.h = Math.Abs(start.pos.X - TargetPoint.X) + Math.Abs(start.pos.Y - TargetPoint.Y);
            openList.Add(start);
            while (openList.Count != 0)
            {
                float minF = openList.Min<TileDS>(u => (u.g + u.h));
                TileDS minDS = new TileDS();

                foreach (TileDS item in openList)
                {
                    if (item.h + item.g == minF)
                    {
                        minDS = item;
                    }
                }
                closeList.Add(minDS);
                openList.Remove(minDS);

                if (minDS.pos == TargetPoint)
                {
                    List<TileDS> list = new List<TileDS>();
                    list.Add(minDS);
                    while (list.Last<TileDS>().pos != start.pos)
                    {
                        foreach (TileDS item in closeList)
                        {
                            if (item.pos == minDS.fatherPos)
                            {
                                list.Add(item);
                                minDS = item;
                            }
                        }
                    }
                    list.Reverse(0, list.Count);
                    this.path = list;
                    return;
                }

                TileDS tDLeft = new TileDS();
                tDLeft.pos = new Vector2(minDS.pos.X - 1, minDS.pos.Y);
               

                TileDS tDRight = new TileDS();
                tDRight.pos = new Vector2(minDS.pos.X + 1, minDS.pos.Y);
                

                TileDS tDTop = new TileDS();
                tDTop.pos = new Vector2(minDS.pos.X, minDS.pos.Y - 1);
                

                TileDS tDBottom = new TileDS();
                tDBottom.pos = new Vector2(minDS.pos.X, minDS.pos.Y + 1);
                

                List<TileDS> temp = new List<TileDS>();
                if (!CheckCollide(GetColl(new Vector2(tDLeft.pos.X * Define.UnitOFpixel, tDLeft.pos.Y * Define.UnitOFpixel))) && !closeList.Exists(u => (u.pos == tDLeft.pos)))
                {
                    tDLeft.g = minDS.g + 1;
                    tDLeft.h = Math.Abs(tDLeft.pos.X - TargetPoint.X) + Math.Abs(tDLeft.pos.Y - TargetPoint.Y);
                    tDLeft.fatherPos = minDS.pos;
                    temp.Add(tDLeft);
                }
                if (!CheckCollide(GetColl(new Vector2(tDBottom.pos.X * Define.UnitOFpixel, tDBottom.pos.Y * Define.UnitOFpixel))) && !closeList.Exists(u => (u.pos == tDBottom.pos)))//
                {
                    tDBottom.g = minDS.g + 1;
                    tDBottom.h = Math.Abs(tDBottom.pos.X - TargetPoint.X) + Math.Abs(tDBottom.pos.Y - TargetPoint.Y);
                    tDBottom.fatherPos = minDS.pos;
                    temp.Add(tDBottom);
                }
                if (!CheckCollide(GetColl(new Vector2(tDRight.pos.X * Define.UnitOFpixel, tDRight.pos.Y * Define.UnitOFpixel))) && !closeList.Exists(u => (u.pos == tDRight.pos)))//
                {
                    tDRight.g = minDS.g + 1;
                    tDRight.h = Math.Abs(tDRight.pos.X - TargetPoint.X) + Math.Abs(tDRight.pos.Y - TargetPoint.Y);
                    tDRight.fatherPos = minDS.pos;
                    temp.Add(tDRight);
                }
                if (!CheckCollide(GetColl(new Vector2(tDTop.pos.X * Define.UnitOFpixel, tDTop.pos.Y * Define.UnitOFpixel))) && !closeList.Exists(u => (u.pos == tDTop.pos)))//
                {
                    tDTop.g = minDS.g + 1;
                    tDTop.h = Math.Abs(tDTop.pos.X - TargetPoint.X) + Math.Abs(tDTop.pos.Y - TargetPoint.Y);
                    tDTop.fatherPos = minDS.pos;
                    temp.Add(tDTop);
                }


                for (int i = 0; i < temp.Count; i++)
                {

                    bool isExist = false;
                    for (int j = 0; j < openList.Count; j++)
                    {
                        if (openList[j].pos == temp[i].pos)
                        {
                            isExist = true;
                            if (temp[i].g < openList[j].g)
                            {
                                TileDS newTDS = new TileDS();
                                newTDS.fatherPos = minDS.pos;
                                newTDS.pos = openList[j].pos;
                                newTDS.g = temp[i].g;
                                newTDS.h = openList[j].h;
                                openList.Remove(openList[j]);
                                openList.Add(newTDS);
                            }
                        }
                    }
                    if (!isExist)
                    {
                        openList.Add(temp[i]);
                    }
                }

            }
            return;
        }

        public override void MoveByPath(bool isdoorOpen, int time)
        {
            if (this.path.Count == 0)
            {
                FindPath();
            }

            else if(1 < this.path.Count)
            {
                if (this.position == new Vector2(this.path[1].pos.X * 24, this.path[1].pos.Y * 24))
                {
                    closeList.Clear();
                    openList.Clear();
                    this.path.Clear();
                    base.FindingPath = false;
                    if (isdoorOpen)
                    {
                        base.FindingPath = true;
                        this.FindPath();
                    }

                }
                else
                {
                    if (this.position.X < this.path[1].pos.X * 24)
                    {
                        A_Move(time, 2);
                    }
                    else if (this.position.X > this.path[1].pos.X * 24)
                    {
                        A_Move(time, 1);
                    }

                    if (this.position.Y < this.path[1].pos.Y * 24)
                    {
                        A_Move(time, 0);
                    }
                    else if (this.position.Y > this.path[1].pos.Y * 24)
                    {
                        A_Move(time, 3);
                    }
                }               
            }
            else
            {
                closeList.Clear();
                openList.Clear();
                this.path.Clear();
                base.FindingPath = false;
                this.hunger += 100;
                this.emotion = string.Empty;
                this.isEating = true;
            }

        }

        void CowAIHanlder()
        {
            Random ran = new Random();

            this.action = "";
            this.actionDuringTime = 0;
            int random = ran.Next(0,101);

            if (random <= 20)
            {
                this.action = "move";
                moveInstruct.direct = ran.Next(0, 4);
                moveInstruct.dirTime = ran.Next(1000, 4000);
                if (random < 10)
                {
                    this.emotion = "music";
                }
            }
            else if(random > 20 && random <= 40)
            {
                this.action = "idle";
                idleInstruct.direct = ran.Next(0, 4);
                idleInstruct.dirTime = ran.Next(1000, 4000);
                if (random > 25 && random < 30)
                {
                    this.emotion = "question";
                }
            }
            else
            {
                this.action = "anim";
                animInstruct.direct = ran.Next(4, 7);
                animInstruct.dirTime = ran.Next(1000, 4000);
                if (random > 80 && random < 90)
                {
                    this.emotion = "music";
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        /// <param name="direct">0-forward,1-left,2-right,3-back</param>
        void Move(int time,int direct)
        {
            if (direct == 0)
            {
                this.direct = 0;
                this.position.Y += speed;
            }
            else if(direct == 1)
            {
                this.direct = 1;
                this.position.X -= speed;
            }
            else if (direct == 2)
            {
                this.direct = 2;
                this.position.X += speed;
            }
            else if (direct == 3)
            {
                this.direct = 3;
                this.position.Y -= speed;

            }

            animframeTime += time;
            if (animframeTime > 300)
            {
                animframeTime = 0;
                this.moveFrame++;
                if (this.moveFrame >= 4)
                {
                    this.moveFrame = 0;
                }
            }

            bool Collide = false;
            int colliDir = -1;
            foreach (IPlayerScene playerScene in GlobalController.PlayerSceneList)
            {
                if (playerScene.GetMap() == GlobalController.Map.Name)
                {
                    if (playerScene.GetIntanceType() != "Construction")
                    {
                        if (this.Collider.Intersects(playerScene.GetCollider()))
                        {
                            Collide = true;
                            colliDir = HandleCollide(playerScene.GetCollider());
                        }
                    }
                    else
                    {
                        Construction con = playerScene as Construction;
                        for (int i = 0; i < con.GetColliders().Length; i++)
                        {
                            if (this.Collider.Intersects(con.GetColliders()[i]))
                            {
                                Collide = true;
                                colliDir = HandleCollide(con.GetColliders()[i]);
                            }
                        }
                    }
                }

            }
            if (this.Collider.Intersects(GlobalController.Player.Collider))
            {
                Collide = true;
                colliDir = HandleCollide(GlobalController.Player.Collider);
            }
            if (Collide)
            {
                CowAIHanlder();
            }
        }

        void A_Move(int time, int direct)
        {
            if (direct == 0)
            {
                this.direct = 0;
                this.position.Y += 1f;
            }
            else if (direct == 1)
            {
                this.direct = 1;
                this.position.X -= 1f;
            }
            else if (direct == 2)
            {
                this.direct = 2;
                this.position.X += 1f;
            }
            else if (direct == 3)
            {
                this.direct = 3;
                this.position.Y -= 1f;

            }

            animframeTime += time;
            if (animframeTime > 300)
            {
                animframeTime = 0;
                this.moveFrame++;
                if (this.moveFrame >= 4)
                {
                    this.moveFrame = 0;
                }
            }
        }

        int HandleCollide(Rectangle collider)
        {
            Vector2 cMid = new Vector2(collider.X + collider.Width / 2, collider.Y + collider.Height / 2);
            if (ColliMidPos.X > cMid.X)
            {
                if (ColliMidPos.Y > cMid.Y)
                {
                    if (Math.Abs(ColliMidPos.X - cMid.X) > Math.Abs(ColliMidPos.Y - cMid.Y))
                    {
                        return 3;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if (ColliMidPos.Y <= cMid.Y)
                {
                    if (Math.Abs(ColliMidPos.X - cMid.X) > Math.Abs(ColliMidPos.Y - cMid.Y))
                    {
                        return 3;
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
            else if (ColliMidPos.X <= cMid.X)
            {
                if (ColliMidPos.Y > cMid.Y)
                {
                    if (Math.Abs(ColliMidPos.X - cMid.X) > Math.Abs(ColliMidPos.Y - cMid.Y))
                    {
                        return 4;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else if (ColliMidPos.Y <= cMid.Y)
                {
                    if (Math.Abs(ColliMidPos.X - cMid.X) > Math.Abs(ColliMidPos.Y - cMid.Y))
                    {
                        return 4;
                    }
                    else
                    {
                        return 2;
                    }
                }
            }
            return -1;
        }

        bool CheckCollide(Rectangle collider)
        {
            bool collide = false;
            foreach (IPlayerScene playerScene in GlobalController.PlayerSceneList)
            {
                if (playerScene.GetMap() == GlobalController.Map.Name)
                {
                    if (playerScene.GetIntanceType() != "Construction")
                    {
                        if (collider.Intersects(playerScene.GetCollider()))
                        {
                            collide = true;
                        }
                    }
                    else
                    {
                        Construction con = playerScene as Construction;
                        for (int i = 0; i < con.GetColliders().Length; i++)
                        {
                            if (collider.Intersects(con.GetColliders()[i]))
                            {
                                collide = true;
                            }
                        }
                    }
                }

            }

            return collide;
        }

        void Idle(int direct)
        {
            this.moveFrame = 0;
            if (direct == 0)
            {
                this.direct = 0;               
            }
            else if (direct == 1)
            {
                this.direct = 1;
            }
            else if (direct == 2)
            {
                this.direct = 2;
            }
            else if (direct == 3)
            {
                this.direct = 3;
            }
        }

        void Anim(int time,int direct)
        {
            this.direct = direct;
            animframeTime += time;
            if (animframeTime > 300)
            {
                animframeTime = 0;
                this.moveFrame++;
                if (this.moveFrame >= 4)
                {
                    this.moveFrame = 0;
                }
            }
        }

        public override bool EatContinue(int time)
        {
            if (eatProgress < 15000)
            {
                usingProgress = true;
                eatProgress += time;
                Anim(time, 4);
                return false;
            }
            else
            {
                usingProgress = false;
                eatProgress = 0;
                this.isEating = false;
                this.emotion = "heart";
                return true;
            }
        }

        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        public void Init(float growTime)
        {
            this.growTime = growTime;
        }

        public Vector2 ColliMidPos
        {
            get
            {
                return new Vector2(this.position.X + 35, this.position.Y + 60);
            }
        }

        public float GrowTime
        {
            get { return growTime; }
            set { growTime = value; }
        }

        public int Direct
        {
            get { return direct; }
            set { direct = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Point CurrentFrame
        {
            get
            {
                if (GrowTime >= 0 && GrowTime < 1440)
                {
                    return new Point(this.moveFrame * size.X * Define.UnitOFpixel, (0 * sheetSize + direct * Size.Y) * Define.UnitOFpixel);
                }
                else if (GrowTime >= 1440 && GrowTime < 2880)
                {
                    return new Point(this.moveFrame * size.X * Define.UnitOFpixel, (1 * sheetSize + direct * Size.Y) * Define.UnitOFpixel);
                }
                else if (GrowTime >= 2880 && GrowTime < 4320)
                {
                    return new Point(this.moveFrame * size.X * Define.UnitOFpixel, (2 * sheetSize + direct * Size.Y) * Define.UnitOFpixel);
                }
                else
                {
                    return new Point(this.moveFrame * size.X * Define.UnitOFpixel, (3 * sheetSize + direct * Size.Y) * Define.UnitOFpixel);
                }
            }
        }

        public Rectangle RenderRectangle
        {
            get
            {
                renderRectangle.X = CurrentFrame.X;
                renderRectangle.Y = CurrentFrame.Y;
                return renderRectangle;
            }
        }

        Rectangle GetColl(Vector2 pos)
        {

            return new Rectangle((int)(pos.X + Define.UnitOFpixel), (int)(pos.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
        }

        public new Rectangle Collider
        {
            get
            {
                if (direct == 0 || direct == 3)
                {
                    return new Rectangle((int)(this.position.X + Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
                }
                else
                {
                    return new Rectangle((int)(this.position.X + 10), (int)(this.position.Y + 3 * Define.UnitOFpixel), 2 * Define.UnitOFpixel, Define.UnitOFpixel);
                }
            }
        }

        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(position, GlobalController.Camera); }
        }

        public float LayerDepth
        {
            get
            {
                return (1f * this.position.Y + 3 * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }

        public override string GetMap()
        {
            return this.map.Name;
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b)
        {
            if (this.emotion != string.Empty)
            {
                GlobalController._Cv_func._Global_OperateEmotion(b, this.emotion, Camera.HandlePos(new Vector2(this.position.X + Define.UnitOFpixel, this.position.Y), GlobalController.Camera), this.LayerDepth + 0.1f);
            }

            if (this.usingProgress)
            {
                GlobalController._Cv_func._Global_OperateGoProgress(b, eatProgress / 15000f, Camera.HandlePos(new Vector2(this.position.X + 10, this.position.Y), GlobalController.Camera), this.LayerDepth + 0.1f, "Eat!");
            }
            b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
        }

        public override Microsoft.Xna.Framework.Rectangle GetCollider()
        {
            return this.Collider;
        }

        public override GameObject GetInstance()
        {
            return this;
        }

        public override string GetIntanceType()
        {
            return "Cows";
        }

        public override string GetSaveParameter()
        {
            return this.map.Name + "|" + (int)this.position.X + "|" + (int)this.position.Y + "|" + this.name + "|" + this.growTime + "|" + this.Id + "|" + this.Hunger;
        }

        public override Microsoft.Xna.Framework.Rectangle[] GetEffiveClickArea()
        {
            return null;
        }
    }
}
