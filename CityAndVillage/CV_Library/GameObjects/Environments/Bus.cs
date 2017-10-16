using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Environments
{
    public class Bus : GameObject, IGlobalScene
    {
        Point currentFrame;
        Vector2 targetPosition;
        int speed;
        float waitTime;
        Rectangle trigger;
        bool disappear;
        bool isMoving;
        int wheelFrame;
        bool openingDoor;
        bool doorDown;
        Vector2 doorMovePos;
        int doorHandleTime;


        public Bus(Map map, Texture2D texture, int scholar)
        {
            this.map = map;
            this.size = new Point(12, 6);
            this.texture = texture;
            speed = 3;
            //scholar 1: town -> village
            switch (scholar)
            {
                case 1:
                    this.position = new Vector2(-12 * Define.UnitOFpixel, 56 * Define.UnitOFpixel);
                    this.targetPosition = new Vector2(40 * Define.UnitOFpixel, 56 * Define.UnitOFpixel);
                    disappear = false;
                    break;
                case 2:
                    this.position = new Vector2(3 * Define.UnitOFpixel, 84 * Define.UnitOFpixel);
                    this.targetPosition = new Vector2(40 * Define.UnitOFpixel, 84 * Define.UnitOFpixel);
                    disappear = true;
                    break;
                default:
                    break;
            }

            this.texture = texture;

            this.isMoving = false;
            this.collider.Width = 12 * Define.UnitOFpixel;
            this.collider.Height = 4 * Define.UnitOFpixel;
            this.trigger = new Rectangle((int)(this.position.X + 10 * Define.UnitOFpixel), (int)(this.position.Y + 6 * Define.UnitOFpixel), 2 * Define.UnitOFpixel, 1 * Define.UnitOFpixel);

            this.doorHandleTime = 0;
            this.wheelFrame = 0;
            this.openingDoor = false;
            this.doorMovePos = new Vector2(0, 0);
            this.doorDown = false;
            this.currentFrame = new Point(0, 0);
            this.scale = 1;
            this.renderRectangle = new Rectangle(currentFrame.X * Define.UnitOFpixel, currentFrame.Y * Define.UnitOFpixel, Size.X * Define.UnitOFpixel, Size.Y * Define.UnitOFpixel);
        }
        public bool IsMoving
        {
            get { return isMoving; }
            set { isMoving = value; }
        }


        public bool OpeningDoor
        {
            get { return openingDoor; }
            set { openingDoor = value; }
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

        public float LayerDepth
        {
            get
            {
                return 1f * (this.position.Y + 3 * Define.UnitOFpixel) / Define.UnitOFpixel / map.Size.Y;
            }
        }

        public new Rectangle Collider
        {
            get
            {
                collider.X = (int)position.X;
                collider.Y = (int)position.Y + 3 * Define.UnitOFpixel;
                return collider;
            }
        }


        public Rectangle Trigger
        {
            get
            {
                this.trigger.X = (int)(this.position.X + 10 * Define.UnitOFpixel);
                this.trigger.Y = (int)(this.position.Y + 6 * Define.UnitOFpixel);
                return trigger;
            }
        }


        public int DoorHandleTime
        {
            get { return doorHandleTime; }
            set { doorHandleTime = value; }
        }
        public float WaitTime
        {
            get { return waitTime; }
            set { waitTime = value; }
        }


        public Vector2 DoorMovePos
        {
            get { return doorMovePos; }
            set { doorMovePos = value; }
        }

        public void Move()
        {
            if (targetPosition.X != position.X)
            {
                this.isMoving = true;
                wheelFrame += 1;
                if (wheelFrame > 3)
                {
                    wheelFrame = 1;
                }
                if (targetPosition.X > position.X)
                {
                    position.X += speed;
                }
                else if (targetPosition.X < position.X)
                {
                    position.X -= speed;
                }
            }
            if (targetPosition.X == position.X)
            {
                this.isMoving = false;
                this.OpeningDoor = true;
                wheelFrame = 0;
                if (disappear)
                {
                    GlobalController.bus = null;
                    GlobalController.BusRequest = 0;
                }
            }
        }

        public void DoorHandle()
        {
            if (doorDown)
            {
                this.doorMovePos.X += 5;
            }
            else
            {
                this.doorMovePos.Y += 2;
                doorDown = true;
            }
        }

        public string GetMap()
        {
            return this.Map.Name;
        }

        public void Draw(SpriteBatch b)
        {
            b.Draw(this.Texture, this.RenderPosition, this.RenderRectangle, this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth);
            b.Draw(this.Texture, new Vector2(this.RenderPosition.X + 196, this.RenderPosition.Y + 115), new Rectangle(wheelFrame * Define.UnitOFpixel, 6 * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth + 0.001f);
            b.Draw(this.Texture, new Vector2(this.RenderPosition.X + 21, this.RenderPosition.Y + 115), new Rectangle(wheelFrame * Define.UnitOFpixel, 6 * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth + 0.001f);
            b.Draw(this.Texture, new Vector2(this.RenderPosition.X + 61, this.RenderPosition.Y + 115), new Rectangle(wheelFrame * Define.UnitOFpixel, 6 * Define.UnitOFpixel, Define.UnitOFpixel, Define.UnitOFpixel), this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth + 0.001f);

            b.Draw(this.Texture, new Vector2(this.RenderPosition.X + 225 + doorMovePos.X, this.RenderPosition.Y + 81 + doorMovePos.Y), new Rectangle(4 * Define.UnitOFpixel, 6 * Define.UnitOFpixel, 2 * Define.UnitOFpixel, 2 * Define.UnitOFpixel), this.RenderColor, this.Rotation, this.Origin, this.Scale, this.SpriteEffects, this.LayerDepth + 0.001f);
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
            return "Bus";
        }
    }
}
