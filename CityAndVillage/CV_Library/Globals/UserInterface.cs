using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Globals
{
    public static class UserInterface
    {
        public static UIFrame UserInfo = new UIFrame(new Point(0, 0), new Vector2(0, 0), new Rectangle(0, 0, 7 * Define.UnitOFpixel, 5 * Define.UnitOFpixel), 0.7f, Color.White);

        public static UIFrame UserInfoHunger = new UIFrame(new Point(11, 0), new Vector2(2 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), new Rectangle(0, 0, 1 * Define.UnitOFpixel, 1 * Define.UnitOFpixel), 0.71f, Color.White);

        public static UIFrame UserInfoHabitus = new UIFrame(new Point(7, 1), new Vector2(0, 3 * Define.UnitOFpixel), new Rectangle(0, 0, 2 * Define.UnitOFpixel, 2 * Define.UnitOFpixel), 0.71f, Color.White);

        #region - userInfoHP
        public static float UserInfoHPPercent = 1;
        public static Vector2 UserInfoHPPos = new Vector2(3 * Define.UnitOFpixel + 2, Define.UnitOFpixel + 7);
        private static Rectangle userInfoHPRect = new Rectangle(7 * Define.UnitOFpixel, 0, 78, 12);
        public static Rectangle UserInfoHPRect
        {
            get
            {
                UserInterface.userInfoHPRect.X = 7 * Define.UnitOFpixel + 78 - (int)(78 * UserInfoHPPercent);
                UserInterface.userInfoHPRect.Width = (int)(78 * UserInfoHPPercent);
                return UserInterface.userInfoHPRect;
            }
        }
        public static float UserInfoHPLD = 0.71f;
        public static Color UserInfoHPColor;
        #endregion

        #region - userInfoE
        public static float UserInfoEPercent = 1;
        public static Vector2 UserInfoEPos = new Vector2(1 * Define.UnitOFpixel + 19, 2 * Define.UnitOFpixel + 5);
        private static Rectangle userInfoERect = new Rectangle(7 * Define.UnitOFpixel, 0, 78, 12);
        public static Rectangle UserInfoERect
        {
            get
            {
                UserInterface.userInfoERect.X = 7 * Define.UnitOFpixel + 78 - (int)(78 * UserInfoEPercent);
                UserInterface.userInfoERect.Width = (int)(78 * UserInfoEPercent);
                return UserInterface.userInfoERect;
            }
        }
        public static float UserInfoELD = 0.71f;
        public static Color UserInfoEColor;
        #endregion


        public static UIFrame Calendar = new UIFrame(new Point(0, 0), new Vector2(Define.windowWidth * 2 - 12 * Define.UnitOFpixel, 0), new Rectangle(0, 0, 12 * Define.UnitOFpixel, 9 * Define.UnitOFpixel), 0.735f, Color.White);

        public static UIFrame CalendarConditionGround = new UIFrame(new Point(0, 9), new Vector2(Define.windowWidth * 2 - 12 * Define.UnitOFpixel + 4, 2 * Define.UnitOFpixel + 19), new Rectangle(0, 0, 12 * Define.UnitOFpixel, 1 * Define.UnitOFpixel), 0.72f, Color.White);

        public static UIFrame CalendarConditionSky = new UIFrame(new Point(0, 10), new Vector2(Define.windowWidth * 2 - 12 * Define.UnitOFpixel + 4, 6), new Rectangle(0, 0, 12 * Define.UnitOFpixel, 4 * Define.UnitOFpixel), 0.71f, Color.SkyBlue);

        public static UIFrame CalendarConditionLocation = new UIFrame(new Point(0, 15), new Vector2(Define.windowWidth * 2 - 12 * Define.UnitOFpixel, 0), new Rectangle(0, 0, 13 * Define.UnitOFpixel, 4 * Define.UnitOFpixel), 0.73f, Color.White);

        public static UIFrame CalendarConditionSun = new UIFrame(new Point(0, 14), new Vector2(Define.windowWidth * 2 - 14 * Define.UnitOFpixel + 320, 15), new Rectangle(0, 0, 1 * Define.UnitOFpixel, 1 * Define.UnitOFpixel), 0.725f, Color.White);

        public static UIFrame CalendarConditionMoon = new UIFrame(new Point(1, 14), new Vector2(Define.windowWidth * 2 - 14 * Define.UnitOFpixel + 320, 15), new Rectangle(0, 0, 1 * Define.UnitOFpixel, 1 * Define.UnitOFpixel), 0.725f, Color.White);

        public static UIFrame CalendarContent = new UIFrame(new Point(12, 0), new Vector2(Define.windowWidth * 2 - 12 * Define.UnitOFpixel, 6 * Define.UnitOFpixel), new Rectangle(0, 0, 3 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), 0.74f, Color.White);

        public static UIFrame CalendarExhibition = new UIFrame(new Point(12, 5), new Vector2(Define.windowWidth * 2 - 12 * Define.UnitOFpixel, 6 * Define.UnitOFpixel), new Rectangle(0, 0, 2 * Define.UnitOFpixel, 1 * Define.UnitOFpixel), 0.745f, Color.White);

        public static UIFrame MenuBackpackIcon = new UIFrame(new Point(0, 5), new Vector2(-160, 200), new Rectangle(0, 0, 6 * Define.UnitOFpixel,3 * Define.UnitOFpixel), 0.7f, Color.White);
        public static UIFrame MenuPersonalIcon = new UIFrame(new Point(0, 8), new Vector2(-160, 260), new Rectangle(0, 0, 6 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), 0.701f, Color.White);
        public static UIFrame MenuSkillIcon = new UIFrame(new Point(0, 11), new Vector2(-160, 320), new Rectangle(0, 0, 6 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), 0.702f, Color.White);
        public static UIFrame MenuContactIcon = new UIFrame(new Point(0, 14), new Vector2(-160, 380), new Rectangle(0, 0, 6 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), 0.703f, Color.White);
        public static UIFrame MenuSettingsIcon = new UIFrame(new Point(0, 17), new Vector2(-160, 440), new Rectangle(0, 0, 6 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), 0.704f, Color.White);

        public static UIFrame MenuBackpack = new UIFrame(new Point(0, 0), new Vector2((Define.windowWidth * 2 - 888) / 2 + 384, Define.windowHeight - 240), new Rectangle(0, 0, 21 * Define.UnitOFpixel, 20 * Define.UnitOFpixel), 0.8f, Color.White);

        public static UIFrame MenuPersonalMsg = new UIFrame(new Point(0, 0), new Vector2((Define.windowWidth * 2 - 888) / 2, Define.windowHeight - 240), new Rectangle(0, 0, 18 * Define.UnitOFpixel, 20 * Define.UnitOFpixel), 0.79f, Color.White);

        public static UIFrame ProcessBack = new UIFrame(new Point(7, 4), new Vector2(GlobalController.Player.RenderPosition.X - Define.UnitOFpixel, GlobalController.Player.RenderPosition.Y - Define.UnitOFpixel), new Rectangle(0, 0, 3 * Define.UnitOFpixel, Define.UnitOFpixel), GlobalController.ProgressLayerDepth, Color.White);
        public static UIFrame ProcessBar = new UIFrame(new Point(7, 5), new Vector2(GlobalController.Player.RenderPosition.X - Define.UnitOFpixel, GlobalController.Player.RenderPosition.Y - Define.UnitOFpixel), new Rectangle(0, 0, 3 * Define.UnitOFpixel, Define.UnitOFpixel), GlobalController.ProgressLayerDepth + 0.01f, Color.White);
        static Rectangle processBarRect = new Rectangle(7 * Define.UnitOFpixel + 17, 5 * Define.UnitOFpixel + 12, 3 * Define.UnitOFpixel, 2);
        public static Rectangle ProcessBarRect
        {
            get
            {
                UserInterface.processBarRect.Width = (int)(32 * GlobalController.PrograssPercent);
                return UserInterface.processBarRect;
            }
        }

        public static UIFrame Alert = new UIFrame(new Point(13, 7), new Vector2(0, 0), new Rectangle(0, 0, 9 * Define.UnitOFpixel, 4 * Define.UnitOFpixel), 0.85f, Color.White);
        public static UIFrame Banner = new UIFrame(new Point(13, 11), new Vector2(2 * (Define.windowWidth - Define.UnitOFpixel * 4 - 7), 2 * (Define.windowHeight - Define.UnitOFpixel - 7)), new Rectangle(0, 0, 8 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), 0.8f, Color.White);

        public static UIFrame RapidList = new UIFrame(new Point(12, 3), new Vector2(Define.windowWidth - 6 * Define.UnitOFpixel, Define.windowHeight * 2 - 3 * Define.UnitOFpixel), new Rectangle(0, 0, 12 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), 0.7f, Color.White);

        public static UIFrame Dialogue = new UIFrame(new Point(0, 0), new Vector2(Define.windowWidth - 480, (Define.windowHeight - 144) * 2 - 20), new Rectangle(0, 0, 40 * Define.UnitOFpixel, 12 * Define.UnitOFpixel), 0.85f, Color.White);
        public static UIFrame DialogueSelect = new UIFrame(new Point(0, 35), new Vector2(0,0), new Rectangle(0, 0, 17 * Define.UnitOFpixel, 2 * Define.UnitOFpixel), 0.86f, Color.White);

        
    }
}
