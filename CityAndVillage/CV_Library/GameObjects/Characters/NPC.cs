using CV_Library.Controllers;
using CV_Library.Functions;
using CV_Library.Globals;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class NPC : Character
    {
        string action;
        NpcPosition targetPosition;
        List<TileDS> path = new List<TileDS>();
        public struct TileDS
        {
            public Vector2 fatherPos;
            public Vector2 pos;
            public float g;
            public float h;
        }

        List<TileDS> openList = new List<TileDS>();
        List<TileDS> closeList = new List<TileDS>();
        bool findingPath;
        int animframeTime;
        bool movingProtect;
        //NPC connectNPC;
        int playerCollideTime;
        bool ifplayerCollideProtect;
        int playerCollideProtectTime;
        bool movingCollide;
        int movingCollideTime;
        int idleTime;
        int thinkTime;
        string emotion;
        int[] pathArray;
        Vector2 targetMapTemporary;
        GlobalController.NpcTrigger nT;

        public NPC(Map map, Vector2 pos, string name)
            : base(map, pos, name)
        {
            switch (name)
            {
                case "Lilis":
                    this.texture = ResourceController.Characters_Lilis;
                    break;
                case "Olivia":
                    this.texture = ResourceController.Characters_Olivia;
                    break;
                case "Sabina":
                    this.texture = ResourceController.Characters_Sabina;
                    break;
                default:
                    break;
            }
            this.renderRectangle = new Rectangle(frame * 2 * Define.UnitOFpixel, (anim * 16 + direct * 4) * Define.UnitOFpixel, 2 * Define.UnitOFpixel, 4 * Define.UnitOFpixel);
            //this.connectNPC = NPC.NULL;
            this.playerCollideTime = 0;
            this.ifplayerCollideProtect = false;
            this.playerCollideProtectTime = 0;
            this.movingCollide = false;
            this.movingCollideTime = 0;
            this.movingProtect = false;
            this.idleTime = 0;
            this.thinkTime = 0;
            this.emotion = string.Empty;
            this.pathArray = new int[] { };
            this.targetMapTemporary = new Vector2();
            nT = new GlobalController.NpcTrigger();
        }

        public static NPC NULL = null;

        public static NPC PLAYER = new NPC(Map.Null, Vector2.Zero, "Player");

        //public NPC ConnectNPC
        //{
        //    get { return connectNPC; }
        //    set { connectNPC = value; }
        //}
        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        public NpcPosition TargetPosition
        {
            get { return targetPosition; }
            set { targetPosition = value; }
        }

        public bool FindingPath
        {
            get { return findingPath; }
            set { findingPath = value; }
        }

        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(this.position, GlobalController.Camera); }
        }
        public Rectangle RenderRectangle
        {
            get
            {
                renderRectangle.X = frame * 2 * Define.UnitOFpixel;
                renderRectangle.Y = (anim * 16 + direct * 4) * Define.UnitOFpixel;
                return renderRectangle;
            }
        }

        public override Rectangle Collider
        {
            get
            {
                if (ifplayerCollideProtect)
                {
                    return new Rectangle();
                }
                else
                {
                    return base.Collider;
                }
            }
        }

        public Rectangle MovingCollider
        {
            get
            {
                return base.Collider;
            }
        }
        //0 -forward
        //1 -left
        //2 -right
        //3 -back
        public int Direct
        {
            get { return direct; }
            set { direct = value; }
        }

        //idle - 0
        //walk - 1
        public int Anim
        {
            get { return anim; }
            set { anim = value; }
        }
        public int Frame
        {
            get { return frame; }
            set { frame = value; }
        }

        bool CheckCollide(Rectangle collide)
        {
            bool colli = false;
            foreach (Point item in GlobalController.NpcSceneCollide)
            {
                if (collide.Intersects(new Rectangle(item.X * Define.UnitOFpixel, item.Y * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel)))
                {
                    colli = true;
                }
            }
            return colli;
        }
        void FindPath(Vector2 tarP)
        {
            this.position = new Vector2((int)this.position.X, (int)this.position.Y);
            TileDS start = new TileDS();
            start.pos = new Vector2((int)this.position.X / Define.UnitOFpixel, (int)this.position.Y / Define.UnitOFpixel);
            start.g = 0;
            start.h = Math.Abs(start.pos.X - tarP.X) + Math.Abs(start.pos.Y - tarP.Y);
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

                if (minDS.pos == tarP)
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
                    closeList.Clear();
                    openList.Clear();
                    this.path = list;
                    this.action = "move";
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

                if (!CheckCollide(new Rectangle((int)(tDLeft.pos.X * Define.UnitOFpixel), (int)(tDLeft.pos.Y * Define.UnitOFpixel),Define.UnitOFpixel,Define.UnitOFpixel)) && !closeList.Exists(u => (u.pos == tDLeft.pos)))
                {
                    tDLeft.g = minDS.g + 1;
                    tDLeft.h = Math.Abs(tDLeft.pos.X - tarP.X) + Math.Abs(tDLeft.pos.Y - tarP.Y);
                    tDLeft.fatherPos = minDS.pos;
                    temp.Add(tDLeft);
                }
                if (!CheckCollide(new Rectangle((int)(tDBottom.pos.X * Define.UnitOFpixel), (int)(tDBottom.pos.Y * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel)) && !closeList.Exists(u => (u.pos == tDBottom.pos)))
                {
                    tDBottom.g = minDS.g + 1;
                    tDBottom.h = Math.Abs(tDBottom.pos.X - tarP.X) + Math.Abs(tDBottom.pos.Y - tarP.Y);
                    tDBottom.fatherPos = minDS.pos;
                    temp.Add(tDBottom);
                }
                if (!CheckCollide(new Rectangle((int)(tDRight.pos.X * Define.UnitOFpixel), (int)(tDRight.pos.Y * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel)) && !closeList.Exists(u => (u.pos == tDRight.pos)))
                {
                    tDRight.g = minDS.g + 1;
                    tDRight.h = Math.Abs(tDRight.pos.X - tarP.X) + Math.Abs(tDRight.pos.Y - tarP.Y);
                    tDRight.fatherPos = minDS.pos;
                    temp.Add(tDRight);
                }
                if (!CheckCollide(new Rectangle((int)(tDTop.pos.X * Define.UnitOFpixel), (int)(tDTop.pos.Y * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel)) && !closeList.Exists(u => (u.pos == tDTop.pos)))
                {
                    tDTop.g = minDS.g + 1;
                    tDTop.h = Math.Abs(tDTop.pos.X - tarP.X) + Math.Abs(tDTop.pos.Y - tarP.Y);
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

        void MoveByPath(int time)
        {
            if (this.targetPosition.Map.Name == this.map.Name)
            {
                if ((int)(this.position.X / Define.UnitOFpixel) == (int)(this.targetPosition.Position.X / Define.UnitOFpixel) && (int)(this.position.Y / Define.UnitOFpixel) == (int)(this.targetPosition.Position.Y / Define.UnitOFpixel))
                {
                    this.action = "idle";
                    Random ran = new Random();
                    idleTime = ran.Next(3000, 10000);
                    this.direct = this.targetPosition.Direct;
                    this.anim = 0;
                    this.frame = 0;
                }
                else
                {
                    if (this.path.Count == 0)
                    {
                        if (GlobalController.NpcSceneCollide.Count > 0)
                        {
                            FindPath(new Vector2((int)TargetPosition.Position.X / Define.UnitOFpixel, (int)TargetPosition.Position.Y / Define.UnitOFpixel));
                        }
                    }
                    else if (0 < this.path.Count)
                    {
                        Vector2 tPos;
                        if (this.position == new Vector2(this.path[1].pos.X * 24, this.path[1].pos.Y * 24))
                        {
                            this.path.RemoveAt(0);
                            tPos = this.path[1].pos;
                        }
                        else
                        {
                            tPos = this.path[1].pos;                         
                        }
                        if (this.position.X < tPos.X * 24)
                        {
                            ActionMove(time, 2);
                        }
                        else if (this.position.X > tPos.X * 24)
                        {
                            ActionMove(time, 1);
                        }
                        if (this.position.Y < tPos.Y * 24)
                        {
                            ActionMove(time, 0);
                        }
                        else if (this.position.Y > tPos.Y * 24)
                        {
                            ActionMove(time, 3);
                        }
                    }
                    else
                    {
                        closeList.Clear();
                        openList.Clear();
                        this.path.Clear();
                        this.FindingPath = false;
                    }


                }
            }
            else
            {
                if ((int)(this.position.X / Define.UnitOFpixel) == (int)this.targetMapTemporary.X && (int)((this.position.Y) / Define.UnitOFpixel) == (int)this.targetMapTemporary.Y)
                {
                    this.map = Map.GetMapByID(this.pathArray[0]);
                    ArrayList al = new ArrayList(this.pathArray);
                    al.RemoveAt(0);
                    this.pathArray = (int[])al.ToArray(typeof(int));
                    this.targetMapTemporary = Vector2.Zero;
                    this.path.Clear();
                    this.position = this.nT.targetPosition * Define.UnitOFpixel;
                    this.nT = new GlobalController.NpcTrigger();
                }
                else
                {
                    if (this.pathArray.Length == 0)
                    {
                        this.pathArray = GlobalController._Cv_func._Npc_MapWeighted(this.map, this.targetPosition.Map);
                    }
                    else if (this.path.Count == 0)
                    {
                        Map tMap = Map.GetMapByID(this.pathArray[0]);
                        foreach (GlobalController.NpcTrigger nT in GlobalController.NpcTriggerList)
                        {
                            if (nT.targetMap.Name == tMap.Name && nT.currentMap.Name == this.map.Name)
                            {
                                this.nT = nT;
                                this.targetMapTemporary = nT.position;
                                break;
                            }
                        }
                        FindPath(this.targetMapTemporary);
                    }
                    else if (0 < this.path.Count)
                    {
                        Vector2 tPos;
                        if (this.position == new Vector2(this.path[1].pos.X * 24, this.path[1].pos.Y * 24))
                        {                     
                            this.path.RemoveAt(0);
                             tPos = this.path[1].pos;                          
                        }
                        else
                        {
                            tPos = this.path[1].pos;
                        }
                        if (this.position.X < tPos.X * 24)
                        {
                            ActionMove(time, 2);
                        }
                        else if (this.position.X > tPos.X * 24)
                        {
                            ActionMove(time, 1);
                        }
                        if (this.position.Y < tPos.Y * 24)
                        {
                            ActionMove(time, 0);
                        }
                        else if (this.position.Y > tPos.Y * 24)
                        {
                            ActionMove(time, 3);
                        }
                    }
                    else
                    {
                        closeList.Clear();
                        openList.Clear();
                        this.path.Clear();
                        this.FindingPath = false;
                    }
                }
            }
        }
        void ActionMove(int time, int direct)
        {
            if (!this.movingCollide)
            {
                this.anim = 1;
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
                if (animframeTime > 120)
                {
                    animframeTime = 0;
                    this.frame++;
                    if (this.frame > 5)
                    {
                        this.frame = 0;
                    }
                }
                if (!this.movingProtect)
                {
                    foreach (NPC npc in GlobalController.Npcs)
                    {
                        if ((this.MovingCollider.Intersects(npc.MovingCollider) && this.MovingCollider != npc.MovingCollider) || this.MovingCollider.Intersects(GlobalController.Player.Collider))
                        {
                            this.movingCollide = true;
                        }
                    }
                }
            }
            else
            {
                this.movingCollideTime += time;
                if (this.movingCollideTime > 3000)
                {
                    this.movingCollideTime = 0;
                    this.movingCollide = false;
                    this.movingProtect = true;
                }
                else
                {
                    bool testCollide = true;
                    foreach (NPC npc in GlobalController.Npcs)
                    {
                        if (this.MovingCollider.Intersects(npc.MovingCollider) && this.MovingCollider != npc.MovingCollider)
                        {
                            testCollide = false;

                        }
                    }
                    if (testCollide && !this.MovingCollider.Intersects(GlobalController.Player.Collider))
                    {
                        this.movingCollide = false;
                    }
                }
            }
        }

        void NpcThinkingFunc(int time)
        {
            this.thinkTime += time;
            if (thinkTime > 1500)
            {
                thinkTime = 0;
                //TODO by the character emotion
                Random ran = new Random();
                bool notfound = true;
                do
                {
                    int a = ran.Next(0, GlobalController.NpcPositionList.Count);
                    if (!GlobalController.NpcPositionList[a].IsUsing)
                    {
                        this.targetPosition = GlobalController.NpcPositionList[a];
                        GlobalController.NpcPositionList[a].IsUsing = true;
                        notfound = false;
                    }
                }
                while (notfound);

                this.path.Clear();
                this.action = "move";
                this.emotion = string.Empty;
            }
            else
            {
                this.emotion = "nosay";
            }
        }

        void NpcIdleFunc(int time)
        {
            this.idleTime -= time;
            if (idleTime <= 0)
            {
                idleTime = 0;
                this.action = "think";
            }
        }
        public void InstructHandle(int time)
        {
           
            if (this.Collider.Intersects(GlobalController.Player.Collider))
            {
                this.playerCollideTime += time;
                
                if (playerCollideTime > 2000)
                {
                    playerCollideTime = 0;
                    ifplayerCollideProtect = true;
                }
            }
            else if (ifplayerCollideProtect)
            {
                playerCollideProtectTime += time;

                if (playerCollideProtectTime > 1000)
                {
                    playerCollideProtectTime = 0;
                    ifplayerCollideProtect = false;
                }              
            }
            switch (action)
            {

                case "idle":
                    NpcIdleFunc(time);
                    break;
                case "move":
                    MoveByPath(time);
                    break;
                case "think":
                    NpcThinkingFunc(time);
                    break;
                default:
                    break;
            }
        }
        public void Draw(SpriteBatch b)
        {
            b.Draw(this.texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, 0.5f, this.SpriteEffects, this.LayerDepth);

            b.Draw(ResourceController.Characters_character_shadow, new Vector2(this.RenderPosition.X, this.RenderPosition.Y + 1.55f * Define.UnitOFpixel), new Rectangle(Define.UnitOFpixel * this.ShadowFrame.X, Define.UnitOFpixel * this.ShadowFrame.Y, Define.UnitOFpixel, Define.UnitOFpixel / 2), this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth - 0.001f);

            if (this.emotion != string.Empty)
            {
                GlobalController._Cv_func._Global_OperateEmotion(b, this.emotion, Camera.HandlePos(new Vector2(this.position.X , this.position.Y - Define.UnitOFpixel), GlobalController.Camera), this.LayerDepth + 0.1f);
            }
        }

        int LookAtGameObject(GameObject go)
        {
            Vector2 goPos = go.MidPos;
            Vector2 NPCPos = this.MidPos;

            if (goPos.X > NPCPos.X)
            {
                if (goPos.Y > NPCPos.Y)
                {
                    if (Math.Abs(goPos.X - NPCPos.X) > Math.Abs(goPos.Y - NPCPos.Y))
                    {
                        return 2;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    if (Math.Abs(goPos.X - NPCPos.X) > Math.Abs(goPos.Y - NPCPos.Y))
                    {
                        return 2;
                    }
                    else
                    {
                        return 3;
                    }
                }
            }
            else
            {
                if (goPos.Y > NPCPos.Y)
                {
                    if (Math.Abs(goPos.X - NPCPos.X) > Math.Abs(goPos.Y - NPCPos.Y))
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
                    if (Math.Abs(goPos.X - NPCPos.X) > Math.Abs(goPos.Y - NPCPos.Y))
                    {
                        return 1;
                    }
                    else
                    {
                        return 3;
                    }
                }
            }
        }
    }
}
