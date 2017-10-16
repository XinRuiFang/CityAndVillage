//using Box2D.XNA;
using CV_Library.Functions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Character : GameObject
    {
        protected float speed;
        protected bool gender;
        protected string name;
        protected bool hasLight;
        protected Texture2D shadow;
        protected Point shadowFrame;
        protected int direct;
        protected int anim;
        protected int frame;

        public Character(Map map, Vector2 pos, string name)
        {

            

            size = new Point(1, 2);
            collider = new Rectangle((int)position.X, (int)(position.Y + Size.Y * Define.UnitOFpixel), Define.UnitOFpixel, (int)(Define.UnitOFpixel * 0.5f));           
            this.scale = 1f;
            this.shadowFrame = new Point(2, 0);
            this.light = new Light();

            this.map = map;
            this.position = pos;
            this.position = pos;
            this.name = name;
            this.direct = 0;
            this.anim = 0;
            this.direct = 0;
            this.frame = 0;

        }

        public override Rectangle Collider
        {
            get 
            {
                collider.X = (int)position.X;
                collider.Y = (int)(position.Y + Size.Y * Define.UnitOFpixel + 6);
                return collider;
            }
        }

        //public void SetBox2D()
        //{
        //    BodyDef bd = new BodyDef();
        //    bd.type = BodyType.Dynamic;
        //    bd.position = this.position / Define.box2d_RATIO;
        //    Body b = GlobalController._World.CreateBody(bd);
        //    PolygonShape bShape = new PolygonShape();
        //    bShape.SetAsBox(24 / Define.box2d_RATIO, 24 / Define.box2d_RATIO);
        //    FixtureDef bShapeDef = new FixtureDef();
        //    bShapeDef.shape = bShape;
        //    bShapeDef.density = 10f;
        //    bShapeDef.isSensor = false;
        //    b.CreateFixture(bShapeDef);

        //    b.SetUserData(this);
        //}

        public override Vector2 MidPos
        {
            get 
            {
                midPos.X = Collider.X + 0.5f * Define.UnitOFpixel;
                midPos.Y = Collider.Y - 1f * Collider.Height;
                return midPos; 
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public float LayerDepth
        {
            get
            {

                return (this.position.Y + 1 * Define.UnitOFpixel) / GlobalController.Map.Size.Y / Define.UnitOFpixel;
            }
        }
        public float PlayerShadowLayerDepth
        {
            get
            {
                return 0.001f;
            }
        }
        public bool HasLight
        {
            get { return hasLight; }
            set { hasLight = value; }
        }
        public Texture2D Shadow
        {
            get { return shadow; }
            set { shadow = value; }
        }
        public Point ShadowFrame
        {
            get { return shadowFrame; }
            set { shadowFrame = value; }
        }


    }
}
