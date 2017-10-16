using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using CV_Library;


namespace CV_xLibrary
{
    public class InputHandler : Microsoft.Xna.Framework.GameComponent
    {
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;
        public static KeyboardState KeyboardState
        {
            get { return keyboardState; }
        }
        public static KeyboardState LastKeyboardState
        {
            get { return lastKeyboardState; }
        }

        public InputHandler(Game game)
            : base(game)
        {
            keyboardState = Keyboard.GetState();
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();
            if (!GlobalController.isPause)
            {
                if (!GlobalController.isTalking && !GlobalController.Isshopping && !GlobalController.SaleBoxOut)
                {
                    if (GlobalController.PlayerCanMove && !GlobalController.PlayerSleeping)
                    {
                        ActionTest();
                        ShowMenu();
                    }
                }
            }
            Pause();
            base.Update(gameTime);
        }
        public static void Flush()
        {
            lastKeyboardState = keyboardState;
        }
        public static bool KeyReleased(Keys key)
        {
            return keyboardState.IsKeyUp(key) &&
            lastKeyboardState.IsKeyDown(key);
        }
        public static bool KeyPressed(Keys key)
        {
            return keyboardState.IsKeyDown(key) &&
            lastKeyboardState.IsKeyUp(key);
        }
        public static bool KeyDown(Keys key)
        {
            return keyboardState.IsKeyDown(key);
        }

        void ShowMenu()
        {
            if (InputHandler.KeyPressed(Keys.Space))
            {
                if (GlobalController.MenuOut)
                {
                    GlobalController.MenuOut = false;
                    GlobalController.BaggageOut = false;
                    for (int i = 0; i < GlobalController.buttonList.Count; i++)
                    {
                        if (GlobalController.buttonList[i].BingFunc == "BaggageOut")
                        {
                            GlobalController.buttonList.Remove(GlobalController.buttonList[i]);
                        }
                    }
                }
                else
                {
                    GlobalController.MenuOut = true;
                }
            }
        }

        void ActionTest()
        {
            if (InputHandler.KeyPressed(Keys.F))
            {
                GlobalController.Player.Energy -= 1;
            }
            if (InputHandler.KeyPressed(Keys.G))
            {
                GlobalController.Player.Hp -= 1;
            }
        }

        void Pause()
        {
            if (InputHandler.KeyPressed(Keys.Escape))
            {
                if (GlobalController.isPause)
                {
                    GlobalController.PauseMask = new Color(0, 0, 0, 0f);
                    GlobalController.isPause = false;
                }
                else
                {
                    GlobalController.PauseMask = new Color(0, 0, 0, 0.5f);
                    GlobalController.isPause = true;
                }
            }
        }
    }
}
