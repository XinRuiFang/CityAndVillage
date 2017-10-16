using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{
    public class Camera
    {
        public Camera()
        {
            cameraArea = new Rectangle((int)(GlobalController.Player.Position.X + 1 * Define.UnitOFpixel * GlobalController.Player.Size.X / 2 - Define.windowWidth / 2), (int)(GlobalController.Player.Position.Y + 1 * Define.UnitOFpixel * GlobalController.Player.Size.Y / 2 - Define.windowHeight / 2), Define.windowWidth, Define.windowHeight);
            cameraTarget = new Vector2((int)(GlobalController.Player.Position.X + 1 * Define.UnitOFpixel * GlobalController.Player.Size.X / 2 - Define.windowWidth / 2), (int)(GlobalController.Player.Position.Y + 1 * Define.UnitOFpixel * GlobalController.Player.Size.Y / 2 - Define.windowHeight / 2));
            speed = 0;
        }
        Rectangle cameraArea;
        Vector2 cameraTarget;
        float speed;

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public Vector2 CameraTarget
        {
            get 
            {
                cameraTarget.X = GlobalController.Player.Position.X + 1 * Define.UnitOFpixel * GlobalController.Player.Size.X / 2 - Define.windowWidth / 2;
                cameraTarget.Y = GlobalController.Player.Position.Y + 1 * Define.UnitOFpixel * GlobalController.Player.Size.Y / 2 - Define.windowHeight / 2;
                return cameraTarget; 
            }
        }
        public Rectangle CameraArea
        {
            get
            {
                if (cameraArea.X < 0)
                {
                    cameraArea.X = 0;
                }
                if (cameraArea.Y < 0)
                {
                    cameraArea.Y = 0;
                }
                if (cameraArea.X > GlobalController.Player.Map.Size.X * Define.UnitOFpixel - Define.windowWidth)
                {
                    cameraArea.X = GlobalController.Player.Map.Size.X * Define.UnitOFpixel - Define.windowWidth;
                }
                if (cameraArea.Y > GlobalController.Player.Map.Size.Y * Define.UnitOFpixel - Define.windowHeight)
                {
                    cameraArea.Y = GlobalController.Player.Map.Size.Y * Define.UnitOFpixel - Define.windowHeight;
                }
                return cameraArea;
            }
            set 
            {
                cameraArea = value;
            }
        }

        public static void HandleCamera(Camera main)
        {
            //让场景切换更自然 初始化时向y轴方向偏移 +30
            main.cameraArea = new Rectangle((int)(GlobalController.Player.Position.X + 1 * Define.UnitOFpixel * GlobalController.Player.Size.X / 2 - Define.windowWidth / 2), (int)(GlobalController.Player.Position.Y + 1 * Define.UnitOFpixel * GlobalController.Player.Size.Y / 2 - Define.windowHeight / 2 + 30), Define.windowWidth, Define.windowHeight);
        }

        public static Vector2 HandlePos(Vector2 pos,Camera main)
        {
            return new Vector2(pos.X - main.CameraArea.X, pos.Y - main.CameraArea.Y);
        }
        public static Vector2 HandleScreenPostoLocal(Vector2 pos,Camera main)
        {
            return new Vector2(main.cameraArea.X + pos.X / 2, main.cameraArea.Y + pos.Y / 2);
        }

        public static void Execute(Camera camera)
        {
            Vector2 res = new Vector2();
            Vector2 v1 = new Vector2(camera.CameraArea.X, camera.CameraArea.Y);
            Vector2 v2 = camera.CameraTarget;
            Vector2.Lerp(ref v1, ref v2, 0.08f, out res);
            camera.CameraArea = new Rectangle((int)res.X, (int)res.Y, camera.CameraArea.Width, camera.CameraArea.Height);
        }
    }
}
