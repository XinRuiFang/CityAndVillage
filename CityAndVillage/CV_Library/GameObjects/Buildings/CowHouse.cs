using CV_Library.GameObjects.Characters.Animals;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Buildings
{
    public class CowHouse : Construction
    {
        Rectangle roofRenderRect;
        Rectangle signRenderRect;
        Rectangle foodRenderRect;
        Rectangle doorOpenRenderRect;
        Rectangle doorCloseRenderRect;
        Rectangle foodSinkRenderRect;

        Vector2 doorCloseRenderPos;
        Vector2 doorOpenRenderPos;
        Vector2 foodRenderPos;
        Vector2 signRenderPos;
        Vector2 roofRenderPos;
        Vector2 foodSinkRenderPos;

        bool isDoorOpen;
        bool isHaveFood;
        bool haveAnimal;
        int id;

        Rectangle[] colliders_doorOpen;
        Rectangle[] colliders_doorClose;

        Cows cow;


        public CowHouse(Map map, Vector2 position, Texture2D texture, Point size)
            : base(map, position, texture, size, "cowhouse")
        {
            this.colliders_doorOpen = new Rectangle[20];
            this.colliders_doorOpen[0] = new Rectangle((int)(this.position.X), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[1] = new Rectangle((int)(this.position.X + 1 * Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[2] = new Rectangle((int)(this.position.X + 2 * Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[3] = new Rectangle((int)(this.position.X + 3 * Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[4] = new Rectangle((int)(this.position.X + 4 * Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[5] = new Rectangle((int)(this.position.X + 5 * Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[6] = new Rectangle((int)(this.position.X), (int)(this.position.Y + 4 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[7] = new Rectangle((int)(this.position.X), (int)(this.position.Y + 5 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[8] = new Rectangle((int)(this.position.X), (int)(this.position.Y + 6 * Define.UnitOFpixel), 
                Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[9] = new Rectangle((int)(this.position.X), (int)(this.position.Y + 7 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[10] = new Rectangle((int)(this.position.X + 5 * Define.UnitOFpixel), (int)(this.position.Y + 4 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[11] = new Rectangle((int)(this.position.X + 5 * Define.UnitOFpixel), (int)(this.position.Y + 5 * 
                Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[12] = new Rectangle((int)(this.position.X + 5 * Define.UnitOFpixel), (int)(this.position.Y + 6 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[13] = new Rectangle((int)(this.position.X + 5 * Define.UnitOFpixel), (int)(this.position.Y + 7 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[14] = new Rectangle((int)(this.position.X + 1 * Define.UnitOFpixel), (int)(this.position.Y + 7 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorOpen[15] = new Rectangle((int)(this.position.X + 2 * Define.UnitOFpixel), (int)(this.position.Y + 7 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);

            this.colliders_doorClose = new Rectangle[20];
            this.colliders_doorClose[0] = new Rectangle((int)(this.position.X), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[1] = new Rectangle((int)(this.position.X + 1 * Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[2] = new Rectangle((int)(this.position.X + 2 * Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[3] = new Rectangle((int)(this.position.X + 3 * Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[4] = new Rectangle((int)(this.position.X + 4 * Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[5] = new Rectangle((int)(this.position.X + 5 * Define.UnitOFpixel), (int)(this.position.Y + 3 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[6] = new Rectangle((int)(this.position.X), (int)(this.position.Y + 4 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[7] = new Rectangle((int)(this.position.X), (int)(this.position.Y + 5 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[8] = new Rectangle((int)(this.position.X), (int)(this.position.Y + 6 * Define.UnitOFpixel),
                Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[9] = new Rectangle((int)(this.position.X), (int)(this.position.Y + 7 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[10] = new Rectangle((int)(this.position.X + 5 * Define.UnitOFpixel), (int)(this.position.Y + 4 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[11] = new Rectangle((int)(this.position.X + 5 * Define.UnitOFpixel), (int)(this.position.Y + 5 *
                Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[12] = new Rectangle((int)(this.position.X + 5 * Define.UnitOFpixel), (int)(this.position.Y + 6 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[13] = new Rectangle((int)(this.position.X + 5 * Define.UnitOFpixel), (int)(this.position.Y + 7 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[14] = new Rectangle((int)(this.position.X + 1 * Define.UnitOFpixel), (int)(this.position.Y + 7 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[15] = new Rectangle((int)(this.position.X + 2 * Define.UnitOFpixel), (int)(this.position.Y + 7 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[16] = new Rectangle((int)(this.position.X + 3 * Define.UnitOFpixel), (int)(this.position.Y + 7 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);
            this.colliders_doorClose[17] = new Rectangle((int)(this.position.X + 4 * Define.UnitOFpixel), (int)(this.position.Y + 7 * Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel);

            this.isDoorOpen = true;
            this.isHaveFood = false;

            this.renderRectangle = new Rectangle(0, 0, size.X * Define.UnitOFpixel, size.Y * Define.UnitOFpixel);
            this.roofRenderRect = new Rectangle(6 * Define.UnitOFpixel, 0, 6 * Define.UnitOFpixel, 3 * Define.UnitOFpixel);
            this.signRenderRect = new Rectangle(9 * Define.UnitOFpixel, 5 * Define.UnitOFpixel, 1 * Define.UnitOFpixel, 3 * Define.UnitOFpixel);
            this.foodRenderRect = new Rectangle(0 * Define.UnitOFpixel, 6 * Define.UnitOFpixel, 2 * Define.UnitOFpixel,  Define.UnitOFpixel);
            this.doorOpenRenderRect = new Rectangle(10 * Define.UnitOFpixel, 3 * Define.UnitOFpixel, 2 * Define.UnitOFpixel, 4 * Define.UnitOFpixel);
            this.doorCloseRenderRect = new Rectangle(7 * Define.UnitOFpixel, 3 * Define.UnitOFpixel, 3 * Define.UnitOFpixel, 2 * Define.UnitOFpixel);
            this.foodSinkRenderRect = new Rectangle(6 * Define.UnitOFpixel, 5 * Define.UnitOFpixel, 3 * Define.UnitOFpixel, 3 * Define.UnitOFpixel);

            this.roofRenderPos = new Vector2(this.position.X, this.position.Y - Define.UnitOFpixel);
            this.signRenderPos = new Vector2(this.position.X, this.position.Y + 3 * Define.UnitOFpixel);
            this.foodRenderPos = new Vector2(this.position.X + Define.UnitOFpixel, this.position.Y + 5 * Define.UnitOFpixel);
            this.doorOpenRenderPos = new Vector2(this.position.X + 4 * Define.UnitOFpixel, this.position.Y + 3 * Define.UnitOFpixel);
            this.doorCloseRenderPos = new Vector2(this.position.X + 3 * Define.UnitOFpixel, this.position.Y + 5 * Define.UnitOFpixel);
            this.foodSinkRenderPos = new Vector2(this.position.X, this.position.Y + 5 * Define.UnitOFpixel);
        }

        public void Init(bool isHaveFood,int id,bool haveAnimal)
        {
            this.isHaveFood = isHaveFood;
            this.id = id;
        }

        public void InitAnimal(Cows cow)
        {
            this.cow = cow;
        }


        public bool HaveAnimal
        {
            get { return haveAnimal; }
            set { haveAnimal = value; }
        }

        public Cows Cow
        {
            get { return cow; }
        }

        public bool IsDoorOpen
        {
            get { return isDoorOpen; }
            set { isDoorOpen = value; }
        }

        public bool IsHaveFood
        {
            get { return isHaveFood; }
            set { isHaveFood = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Vector2 foodPos
        {
            get { return new Vector2((int)this.position.X / Define.UnitOFpixel + 1, (int)this.position.Y / Define.UnitOFpixel + 3); }
        }

        public override void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch b)
        {
            b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
            b.Draw(this.Texture, this.RoofRenderPos, this.roofRenderRect, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.roofLayerDepth);
            b.Draw(this.Texture, this.SignRenderPos, this.signRenderRect, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.signLayerDepth);
            b.Draw(this.Texture, this.FoodSinkRenderPos, this.foodSinkRenderRect, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.foodSinkLayerDepth);
            if (IsHaveFood)
            {
                b.Draw(this.Texture, this.FoodRenderPos, this.foodRenderRect, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.foodLayerDepth);
            }
            if (IsDoorOpen)
            {
                b.Draw(this.Texture, this.DoorOpenRenderPos, this.doorOpenRenderRect, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.doorOpenLayerDepth);
            }
            else
            {
                b.Draw(this.Texture, this.DoorCloseRenderPos, this.doorCloseRenderRect, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.doorCloseLayerDepth);
            }

        }
        public override Rectangle[] GetColliders()
        {
            if (isDoorOpen)
            {
                return this.colliders_doorOpen;
            }
            else
            {
                return this.colliders_doorClose;
            }
        }

        public Rectangle RenderRectangle
        {
            get
            {
                return renderRectangle;
            }
        }

        public Vector2 RenderPosition
        {
            get { return Camera.HandlePos(position, GlobalController.Camera); }
        }

        Vector2 DoorCloseRenderPos
        {
            get { return Camera.HandlePos(doorCloseRenderPos, GlobalController.Camera); }
        }

        Vector2 DoorOpenRenderPos
        {
            get { return Camera.HandlePos(doorOpenRenderPos, GlobalController.Camera); }
        }

        Vector2 FoodRenderPos
        {
            get { return Camera.HandlePos(foodRenderPos, GlobalController.Camera); }
        }

        Vector2 SignRenderPos
        {
            get { return Camera.HandlePos(signRenderPos, GlobalController.Camera); }
        }

        Vector2 RoofRenderPos
        {
            get { return Camera.HandlePos(roofRenderPos, GlobalController.Camera); }
        }

        Vector2 FoodSinkRenderPos
        {
            get { return Camera.HandlePos(foodSinkRenderPos, GlobalController.Camera); }
        }

        public float LayerDepth
        {
            get
            {
                return (1f * this.position.Y + 3 * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }
        float roofLayerDepth
        {
            get
            {
                return (1f * this.roofRenderPos.Y + 5 * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }
        float signLayerDepth
        {
            get
            {
                return (1f * this.signRenderPos.Y + 3 * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }
        float foodLayerDepth
        {
            get
            {
                return (1f * this.foodRenderPos.Y + 3 * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }
        float foodSinkLayerDepth
        {
            get
            {
                return (1f * this.foodSinkRenderPos.Y + 2 * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }
        float doorOpenLayerDepth
        {
            get
            {
                return (1f * this.doorOpenRenderPos.Y + 4f * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }
        float doorCloseLayerDepth
        {
            get
            {
                return (1f * this.doorCloseRenderPos.Y + 2.5f * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }
        public override GameObject GetInstance()
        {
            return this;
        }
        public override string GetSaveParameter()
        {
            return this.map.Name + "|" + this.position.X + "|" + this.position.Y + "|" + this.name + "|" + this.IsHaveFood + "|" + this.id + "|" + this.HaveAnimal;
        }
        public override Microsoft.Xna.Framework.Rectangle[] GetEffiveClickArea()
        {
            return new Rectangle[]
                    {
                        new Rectangle((int)this.position.X, (int)(this.position.Y + 3 * Define.UnitOFpixel + Define.UnitOFpixel), Define.UnitOFpixel, Define.UnitOFpixel),// sign
                        new Rectangle((int)this.position.X, (int)(this.position.Y + 4 * Define.UnitOFpixel+ Define.UnitOFpixel), 3 * Define.UnitOFpixel, 2 * Define.UnitOFpixel),// food
                        new Rectangle((int)(this.position.X + 3 * Define.UnitOFpixel), (int)(this.position.Y + 4 * Define.UnitOFpixel+ Define.UnitOFpixel), 3 * Define.UnitOFpixel, 2 * Define.UnitOFpixel)// door
                    };
        }
        

    }
}
