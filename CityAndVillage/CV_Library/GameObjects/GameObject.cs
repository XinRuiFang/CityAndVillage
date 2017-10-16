using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class GameObject
    {
        protected Texture2D texture;
        protected Vector2 renderPosition;
        protected Rectangle renderRectangle;
        protected Color renderColor = Color.White;
        protected float rotation = 0f;
        protected Vector2 origin = Vector2.Zero;
        protected SpriteEffects spriteEffects = SpriteEffects.None;
        protected float scale = 1f;
        protected float layerDepth;
        protected Point size;
        protected Light light;
        protected Rectangle collider;
        protected Vector2 position;
        protected Vector2 midPos;
        protected Map map;

        public virtual Map Map
        {
            get { return map; }
            set { map = value; }
        }

        public virtual Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        public virtual Color RenderColor
        {
            get { return renderColor; }
            set { renderColor = value; }
        }

        public virtual float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public virtual Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public virtual float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public virtual SpriteEffects SpriteEffects
        {
            get { return spriteEffects; }
            set { spriteEffects = value; }
        }

        public virtual Point Size
        {
            get { return size; }
            set { size = value; }
        }

        public virtual Light Light
        {
            get { return light; }
            set { light = value; }
        }

        public virtual Rectangle Collider
        {
            get { return collider; }
            set { collider = value; }
        }

        public virtual Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public virtual Vector2 MidPos
        {
            get { return midPos; }
            set { midPos = value; }
        }

    }
}
