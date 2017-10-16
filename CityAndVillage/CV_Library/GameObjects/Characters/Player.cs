//using Box2D.XNA;
using CV_Library.Controllers;
using CV_Library.Functions;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Player: Character, IPlayerScene
    {
        float hpUpper;
        float hp;
        float energyUpper;
        float energy;
        float habitus;
        float hunger;
        int gold;
        bool isDisease;
        Point toolsFrame;
        string region;
        protected CharacterTile[] cTile;

        int collideTriggerXMove;
        int collideTriggerYMove;

        NPC connectNPC;


        public Player(Map map, Vector2 pos, string name,CharacterTile[] cTile, float speed, bool gender, bool hasLight, float hpUpper, float hp, float energyUpper, float energy, float habitus, float hunger, int gold, bool isDisease, string region)
            : base(map, pos, name)
        {
            this.speed = speed;

            this.hasLight = hasLight;
            this.gender = gender;
            this.toolsFrame = new Point(0, 0);
            this.cTile = cTile;

            this.hpUpper = hpUpper;
            this.hp = hp;
            this.energyUpper = energyUpper;
            this.energy = energy;
            this.habitus = habitus;
            this.hunger = hunger;
            this.gold = gold;
            this.isDisease = isDisease;
            this.region = region;
            this.collideTriggerXMove = 0;

            this.connectNPC = NPC.NULL;
        }


        public Vector2 RenderPosition
        {
            get
            {
                return Camera.HandlePos(position, GlobalController.Camera);
            }
        }

        public override Vector2 MidPos
        {
            get
            {
                return new Vector2(this.Position.X + 0.5f * Define.UnitOFpixel, this.Position.Y + 1.5f * Define.UnitOFpixel);
            }
        }

        public NPC ConnectNPC
        {
            get { return connectNPC; }
            set { connectNPC = value; }
        }
        public float HpUpper
        {
            get 
            {               
                return hpUpper + Habitus * 1.3f; 
            }
            set { hpUpper = value; }
        }
        public float Hp
        {
            get { return hp; }
            set { hp = value; }
        }


        public float EnergyUpper
        {
            get { return energyUpper + Habitus * 1.5f; }
            set { energyUpper = value; }
        }


        public float Energy
        {
            get { return energy; }
            set { energy = value; }
        }


        public float Habitus
        {
            get { return habitus; }
            set { habitus = value; }
        }


        public float Hunger
        {
            get { return hunger; }
            set { hunger = value; }
        }

        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }


        public bool IsDisease
        {
            get { return isDisease; }
            set { isDisease = value; }
        }
        public override Rectangle Collider
        {
            get
            {
                collider.Width = (int)(0.9f * Define.UnitOFpixel);
                collider.Height = (int)(0.7f * Define.UnitOFpixel);
                collider.X = (int)position.X + 2;
                collider.Y = (int)(position.Y + Size.Y * Define.UnitOFpixel + 8);
                return collider;
            }
        }


        public Point ToolsFrame
        {
            get { return toolsFrame; }
            set { toolsFrame = value; }
        }

        public string Region
        {
            get { return region; }
            set { region = value; }
        }


        public int CollideTriggerXMove
        {
            get { return collideTriggerXMove; }
            set { collideTriggerXMove = value; }
        }

        public int CollideTriggerYMove
        {
            get { return collideTriggerYMove; }
            set { collideTriggerYMove = value; }
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
        public CharacterTile[] CTile
        {
            get { return cTile; }
            set { cTile = value; }
        } 

        public string GetMap()
        {
            return this.map.Name;
        }


        public void Draw(SpriteBatch b)
        {
            for (int i = 0; i < 8; i++)
            {
                this.CTile[i].Draw(b, new Vector2(position.X,position.Y + 4), new Point(frame * 2, anim * 16 + direct * 4));
            }
           b.Draw(ResourceController.Characters_character_shadow, new Vector2(GlobalController.Player.RenderPosition.X, GlobalController.Player.RenderPosition.Y + 1.87f * Define.UnitOFpixel), new Rectangle(Define.UnitOFpixel * GlobalController.Player.ShadowFrame.X, Define.UnitOFpixel * GlobalController.Player.ShadowFrame.Y, Define.UnitOFpixel, Define.UnitOFpixel / 2), GlobalController.Player.RenderColor, GlobalController.Player.Rotation, GlobalController.Player.Origin, GlobalController.Player.Scale, GlobalController.Player.SpriteEffects, GlobalController.Player.PlayerShadowLayerDepth);         
            b.Draw(ResourceController.Systems_fishingsys, this.MidPos, new Rectangle(384, 0, 1, 1), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, this.layerDepth + 0.0001f);
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
            return "Player";
        }

        public string GetSaveParameter()
        {
            return this.Position.X.ToString() + "|" + this.Position.Y.ToString();
        }

        public Rectangle[] GetEffiveClickArea()
        {
            return new Rectangle[]
            {
                new Rectangle((int)this.position.X, (int)this.position.Y, Define.UnitOFpixel, 2 * Define.UnitOFpixel)
            };
        }

    }
}
