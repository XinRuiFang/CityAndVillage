using CV_Library.Controllers;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Characters.Animals
{
    public class Animals : GameObject, IPlayerScene
    {
        protected string name;
        protected float hunger;
        protected int id;
        protected bool findingPath;
        protected string lastPath;
        protected Vector2 targetPoint;
        protected string emotion;
        protected bool isEating;
        protected bool eatOutSide;
        protected Soils.Soil eatingSoil;
        protected int emotionShowTime;

  



        public Animals(Map map, Vector2 position, Texture2D texture, Point size, string name)
        {
            this.map = map;
            this.position = position;
            this.name = name;
            this.texture = texture;
            this.size = size;
            this.findingPath = false;
            this.lastPath = string.Empty;
            this.emotion = string.Empty;
            this.eatOutSide = false;
            this.emotionShowTime = 0;
        }

        public static Animals Null = null;

        public static Animals CreateAnimalsFactory(Map map, Vector2 position, string name,int id,float hunger)
        {
            switch (name)
            {
                case "cow":
                    Cows cow = new Cows(map, position, ResourceController.Animals_ox, new Point(3, 3), "cow");
                    cow.id = id;
                    cow.hunger = hunger;
                    return cow;
                default:
                    return Animals.Null;
            }
        }

        public virtual void ActionHandler(int time)
        {

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public float Hunger
        {
            get { return hunger; }
            set { hunger = value; }
        }

        public bool FindingPath
        {
          get { return findingPath; }
          set { findingPath = value; }
        }

        public Vector2 TargetPoint
        {
            get { return targetPoint; }
            set { targetPoint = value; }
        }

        public string Emotion
        {
            get { return emotion; }
            set { emotion = value; }
        }

        public bool IsEating
        {
            get { return isEating; }
            set { isEating = value; }
        }
        public bool EatOutSide
        {
            get { return eatOutSide; }
            set { eatOutSide = value; }
        }

        public Soils.Soil EatingSoil
        {
            get { return eatingSoil; }
            set { eatingSoil = value; }
        }
        public int EmotionShowTime
        {
            get { return emotionShowTime; }
            set { emotionShowTime = value; }
        }
        public virtual void FindPath()
        {
 
        }

        public virtual void MoveByPath(bool isdoorOpen, int time)
        {
 
        }

        public virtual bool EatContinue(int time)
        {
            return true;
        }

        public virtual string GetMap()
        {
            return this.map.Name;
        }

        public virtual void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b)
        {
            throw new NotImplementedException();
        }

        public virtual Microsoft.Xna.Framework.Rectangle GetCollider()
        {
            return this.Collider;
        }

        public virtual GameObject GetInstance()
        {
            return this;
        }

        public virtual string GetIntanceType()
        {
            return "Animals";
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
