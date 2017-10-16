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
using CV_Library.GameObjects.Decorats;
using CV_Library.GameObjects.Buildings;
using CV_Library.GameObjects.Environments;
using CV_Library.GameObjects.Items;
using CV_Library.GameObjects.Soils;
using CV_Library.Interfaces;
using CV_Library.Globals;
using CV_Library.GameObjects.Characters.Animals;
using System.Text;
using CV_Library.Functions;


namespace CV_xLibrary
{
    public class PlayerHandler : Microsoft.Xna.Framework.GameComponent
    {

        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 130;
        int millisecondsPerFrameAnim = 100;
        Point lastFrame = new Point(0, 0);

        bool isHolding;
        public static bool showAnim_;
        static string anim;
        static int direct;
        static bool firstExecute;
        static OutDoorItem item_para;
        static int int_para;
        static Vector2 vector2_para;
        static GameObject go_para;
        static string string_para;
        int currentExecTime;
        int funcExecTime;
        int secondFuncExecTime;
        int thirdFuncExecTime;
        int endExecTime;
        int playerdirect = -1;
        int directStatus = 0;
        Vector2 testPos;
        Rectangle testRect;
        List<int> collideCondition = new List<int>();
        bool perior;

        public PlayerHandler(Game game)
            : base(game)
        {
        }

        public override void Initialize()
        {
            GlobalController.PlayerCanMove = true;
            GlobalController.MoveWaitTime = 0d;
            showAnim_ = false;
            firstExecute = true;

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            if (!GlobalController.isPause)
            {
                if (!GlobalController.isTalking && !GlobalController.Isshopping && !GlobalController.SaleBoxOut && !GlobalController.PlayerIsFishing)
                {
                    if (GlobalController.PlayerCanMove && !GlobalController.PlayerSleeping)
                    {
                        Framehandle(gameTime);                     
                        MoveHandle(gameTime);
                        CollideDetection();
                        MoveFinalHandle();

                        HoldingCheck();
                    }
                    else
                    {
                        if (showAnim_)
                        {
                            switch (anim)
                            {
                                case "picky": ShowPickAnim(direct, gameTime); break;
                                case "usingTools": ShowUsingToolsAnim(direct, gameTime,int_para); break;
                                case "seeding": ShowSeedingAnim(direct, gameTime); break;
                                case "harvest": ShowHarvestAnim(direct, gameTime); break;
                                case "giving": ShowGivingAnim(direct, gameTime); break;
                                case "backOff": ShowBackOffAnim(direct, gameTime); break;
                                case "fishing": ShowFishingAnim(direct, gameTime); break;
                                default:
                                    break;
                                    
                            }
                        }
                        if (GlobalController.MoveWaitTime > 0)
                        {
                            GlobalController.MoveWaitTime -= gameTime.ElapsedGameTime.TotalMilliseconds;
                            if (GlobalController.MoveWaitTime <= 0)
                            {
                                GlobalController.MoveWaitTime = 0;
                                GlobalController.PlayerCanMove = true;
                            }
                        }
                    }
                }
                if (GlobalController.PlayerIsFishing)
                {
                    FishingHandle();
                }
            }
            
            base.Update(gameTime);           
        }

        void Framehandle(GameTime gameTime)
        {
 	         if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W) && !InputHandler.KeyboardState.IsKeyDown(Keys.S))
                        {
                            playerdirect = -1;
                            directStatus = -1;
                        }

                        if (InputHandler.KeyboardState.IsKeyDown(Keys.A))
                        {
                            if (!InputHandler.LastKeyboardState.IsKeyDown(Keys.A))
                            {
                                timeSinceLastFrame = millisecondsPerFrame;
                                playerdirect = 1;
                            }                   
                        }
                        else
                        {
                            if (InputHandler.LastKeyboardState.IsKeyDown(Keys.A))
                            {
                                if (InputHandler.KeyboardState.IsKeyDown(Keys.A))
                                {
                                    playerdirect = 1;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.S))
                                {
                                    playerdirect = 2;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.D))
                                {
                                    playerdirect = 3;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.W))
                                {
                                    playerdirect = 4;
                                }
                            }    
                        }
                


                        if (InputHandler.KeyboardState.IsKeyDown(Keys.S))
                        {
                            if (!InputHandler.LastKeyboardState.IsKeyDown(Keys.S))
                            {
                                timeSinceLastFrame = millisecondsPerFrame;
                                playerdirect = 2;
                            }                    
                        }
                        else
                        {
                            if (InputHandler.LastKeyboardState.IsKeyDown(Keys.S))
                            {
                                if (InputHandler.KeyboardState.IsKeyDown(Keys.A))
                                {
                                    playerdirect = 1;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.S))
                                {
                                    playerdirect = 2;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.D))
                                {
                                    playerdirect = 3;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.W))
                                {
                                    playerdirect = 4;
                                }
                            }
                        }
                
                        if (InputHandler.KeyboardState.IsKeyDown(Keys.D))
                        {
                            if (!InputHandler.LastKeyboardState.IsKeyDown(Keys.D))
                            {
                                timeSinceLastFrame = millisecondsPerFrame;
                                playerdirect = 3;
                            }
                   
                        }
                        else
                        {
                            if (InputHandler.LastKeyboardState.IsKeyDown(Keys.D))
                            {
                                if (InputHandler.KeyboardState.IsKeyDown(Keys.A))
                                {
                                    playerdirect = 1;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.S))
                                {
                                    playerdirect = 2;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.D))
                                {
                                    playerdirect = 3;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.W))
                                {
                                    playerdirect = 4;
                                }
                            }
                        }
                
                        if (InputHandler.KeyboardState.IsKeyDown(Keys.W))
                        {
                            if (!InputHandler.LastKeyboardState.IsKeyDown(Keys.W))
                            {
                                timeSinceLastFrame = millisecondsPerFrame;
                                playerdirect = 4;
                            }
                    
                        }
                        else
                        {
                            if (InputHandler.LastKeyboardState.IsKeyDown(Keys.W))
                            {
                                if (InputHandler.KeyboardState.IsKeyDown(Keys.A))
                                {
                                    playerdirect = 1;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.S))
                                {
                                    playerdirect = 2;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.D))
                                {
                                    playerdirect = 3;
                                }
                                else if (InputHandler.KeyboardState.IsKeyDown(Keys.W))
                                {
                                    playerdirect = 4;
                                }
                            }
                        }

                        if (playerdirect == 1)
                        {
                            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                            if (timeSinceLastFrame > millisecondsPerFrame)
                            {
                                timeSinceLastFrame -= millisecondsPerFrame;
                                GlobalController.Player.Anim = 1;
                                GlobalController.Player.Direct = 1;
                                GlobalController.Player.Frame++;
                                if (GlobalController.Player.Frame > 5)
                                {
                                    GlobalController.Player.Frame = 0;
                                }
                                if (GlobalController.Player.Frame == 2 || GlobalController.Player.Frame == 5)
                                {
                                    GlobalController.Player.ShadowFrame = new Point(1, 0);
                                }
                                else
                                {
                                    GlobalController.Player.ShadowFrame = new Point(2, 0);
                                }
                            }
                        }
                        else if (playerdirect == 2)
                        {
                            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                            if (timeSinceLastFrame > millisecondsPerFrame)
                            {
                                timeSinceLastFrame -= millisecondsPerFrame;
                                GlobalController.Player.Anim = 1;
                                GlobalController.Player.Direct = 0;
                                GlobalController.Player.Frame++;
                                if (GlobalController.Player.Frame > 5)
                                {
                                    GlobalController.Player.Frame = 0;
                                }
                                if (GlobalController.Player.Frame == 2 || GlobalController.Player.Frame == 5)
                                {
                                    GlobalController.Player.ShadowFrame = new Point(1, 0);
                                }
                                else
                                {
                                    GlobalController.Player.ShadowFrame = new Point(2, 0);
                                }
                            }
                        }
                        else if (playerdirect == 3)
                        {
                            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                            if (timeSinceLastFrame > millisecondsPerFrame)
                            {
                                timeSinceLastFrame -= millisecondsPerFrame;
                                GlobalController.Player.Anim = 1;
                                GlobalController.Player.Direct = 2;
                                GlobalController.Player.Frame++;
                                if (GlobalController.Player.Frame > 5)
                                {
                                    GlobalController.Player.Frame = 0;
                                }
                                if (GlobalController.Player.Frame == 2 || GlobalController.Player.Frame == 5)
                                {
                                    GlobalController.Player.ShadowFrame = new Point(1, 0);
                                }
                                else
                                {
                                    GlobalController.Player.ShadowFrame = new Point(2, 0);
                                }
                            }
                        }
                        else if (playerdirect == 4)
                        {
                            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                            if (timeSinceLastFrame > millisecondsPerFrame)
                            {
                                timeSinceLastFrame -= millisecondsPerFrame;
                                GlobalController.Player.Anim = 1;
                                GlobalController.Player.Direct = 3;
                                GlobalController.Player.Frame++;
                                if (GlobalController.Player.Frame > 5)
                                {
                                    GlobalController.Player.Frame = 0;
                                }
                                if (GlobalController.Player.Frame == 2 || GlobalController.Player.Frame == 5)
                                {
                                    GlobalController.Player.ShadowFrame = new Point(1, 0);
                                }
                                else
                                {
                                    GlobalController.Player.ShadowFrame = new Point(2, 0);
                                }
                            }
                        }
                        else
                        {
                            GlobalController.Player.Anim = 0;
                            GlobalController.Player.Frame = 0;
                            GlobalController.Player.ShadowFrame = new Point(2, 0);
                        }        
        }

        void MoveHandle(GameTime gameTime)
        {

            if (GlobalController.PlayerCanMove)
            {

                if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.S) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    directStatus = 1;
                }
                if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.S) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    directStatus = 2;
                }
                if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.S) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    directStatus = 3;
                }
                if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.S) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    directStatus = 4;
                }
                if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.S) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    directStatus = 5;
                }
                if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.S) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    directStatus = 6;
                }
                if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.S) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    directStatus = 7;
                }
                if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.S) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    directStatus = 8;
                }
                if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.S) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    directStatus = 2;
                }
                if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.W) && !InputHandler.KeyboardState.IsKeyDown(Keys.S))
                {
                    directStatus = 4;
                }

                switch (directStatus)
                {
                    case 1:
                        testPos = new Vector2(GlobalController.Player.Position.X - 2f, GlobalController.Player.Position.Y);
                        break;
                    case 2:
                        testPos = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + 2f);
                        break;
                    case 3:
                        testPos = new Vector2(GlobalController.Player.Position.X + 2f, GlobalController.Player.Position.Y);
                        break;
                    case 4:
                        testPos = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - 2f);
                        break;
                    case 5:
                        testPos = new Vector2(GlobalController.Player.Position.X - 2f, GlobalController.Player.Position.Y + 2f);
                        break;
                    case 6:
                        testPos = new Vector2(GlobalController.Player.Position.X - 2f, GlobalController.Player.Position.Y - 2f);
                        break;
                    case 7:
                        testPos = new Vector2(GlobalController.Player.Position.X + 2f, GlobalController.Player.Position.Y - 2f);
                        break;
                    case 8:
                        testPos = new Vector2(GlobalController.Player.Position.X + 2f, GlobalController.Player.Position.Y + 2f);
                        break;
                    default:
                        testPos = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y);
                        break;
                }

                testRect.Width = (int)(0.9f * Define.UnitOFpixel);
                testRect.Height = 23;
                testRect.X = (int)testPos.X + 2;
                testRect.Y = (int)(testPos.Y + 2 * Define.UnitOFpixel + 8);
            }
        }

        void CollideDetection()
        {
            collideCondition.Clear();
            for (int i = 0; i < GlobalController.Npcs.Length; i++)
            {
                if (GlobalController.Npcs[i].Map.Name == GlobalController.Map.Name)
                {
                    if (testRect.Intersects(GlobalController.Npcs[i].Collider))
                    {
                        ColliderHandler(testRect, GlobalController.Npcs[i].Collider);
                    }
                }
            }
            foreach (Tree tree in GlobalController.TreeList)
            {
                if (testRect.Intersects(tree.Collider))
                {
                    ColliderHandler(testRect, tree.Collider);
                }
            }
            foreach (Bush bush in GlobalController.BushList)
            {
                if (testRect.Intersects(bush.Collider))
                {
                    ColliderHandler(testRect, bush.Collider);
                }
            }
            foreach (Building building in GlobalController.BuildingList)
            {
                for (int i = 0; i < building.Colliders.Length; i++)
                {
                    if (testRect.Intersects(building.Colliders[i]))
                    {
                        ColliderHandler(testRect, building.Colliders[i]);
                    }
                }
                
            }
            foreach (Soil soil in GlobalController.SoilList)
            {
                if (soil.Seed != Seeds.Null && soil.Seed.Status > 0)
                {
                    if (GlobalController.Player.Collider.Intersects(soil.Collider))
                    {
                        soil.IsShaking = true;
                    }
                    else
                    {
                        soil.IsShaking = false;
                        soil.ShakeTimes = 0;
                    }
                }
            }
            if (GlobalController.bus != null)
            {
                if (GlobalController.Player.Collider.Intersects(GlobalController.bus.Trigger) && !GlobalController.bus.IsMoving)
                {
                    GlobalController.isTalking = true;
                    GlobalController.ConversationOptionSelect.Add("bus");
                    GlobalController.ConversationContent.Clear();
                    GlobalController.ConversationContent.Add("All right,seems like you get a ticket!|1");
                    GlobalController.ConversationContent.Add("#");
                    GlobalController.ConversationContent.Add("yes|6|1");
                    GlobalController.ConversationContent.Add("no|6|2");
                    GlobalController.ConversationContent.Add("#");
                    GlobalController.ConversationContent.Add("Go right now?");
                    GlobalController.ConversationContent.Add("end");
                    GlobalController.ConversationIndex = 0;
                    GlobalController.Conversation = GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[0];
                    GlobalController.ConversationIndex = Convert.ToInt32(GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[1]);
                }
                if (testRect.Intersects(GlobalController.bus.Collider) && !GlobalController.bus.IsMoving)
                {
                    perior = true;
                    ColliderHandler(testRect, GlobalController.bus.Collider);
                }
                if (GlobalController.Player.Collider.Intersects(GlobalController.bus.Collider) && GlobalController.bus.IsMoving)
                {
                    Point playerMid = new Point((GlobalController.Player.Collider.X + GlobalController.Player.Collider.X + GlobalController.Player.Collider.Width) / 2, (GlobalController.Player.Collider.Y + GlobalController.Player.Collider.Y + GlobalController.Player.Collider.Height) / 2);

                    if (playerMid.Y < GlobalController.bus.Collider.Y && playerMid.X > GlobalController.bus.Collider.X && playerMid.X < GlobalController.bus.Collider.X + GlobalController.bus.Collider.Width)
                    {
                        showAnim_ = true;
                        anim = "backOff";
                        direct = 0;
                        GameController.PlayerMoveSleep(250);
                    }
                    if (playerMid.Y > GlobalController.bus.Collider.Y + GlobalController.bus.Collider.Height && playerMid.X > GlobalController.bus.Collider.X && playerMid.X < GlobalController.bus.Collider.X + GlobalController.bus.Collider.Width)
                    {
                        showAnim_ = true;
                        anim = "backOff";
                        direct = 1;
                        GameController.PlayerMoveSleep(250);
                    }
                    if (playerMid.X < GlobalController.bus.Collider.X && playerMid.Y > GlobalController.bus.Collider.Y && playerMid.Y < GlobalController.bus.Collider.Y + GlobalController.bus.Collider.Height)
                    {
                        showAnim_ = true;
                        anim = "backOff";
                        direct = 2;
                        GameController.PlayerMoveSleep(250);
                    }
                    if (playerMid.X > GlobalController.bus.Collider.X && playerMid.Y > GlobalController.bus.Collider.Y && playerMid.Y < GlobalController.bus.Collider.Y + GlobalController.bus.Collider.Height)
                    {
                        showAnim_ = true;
                        anim = "backOff";
                        direct = 3;
                        GameController.PlayerMoveSleep(250);
                    }
                    
                }
            }
            foreach (Barrier barrier in GlobalController.BarrierList)
            {
                if (testRect.Intersects(barrier.Collider))
                {
                    ColliderHandler(testRect, barrier.Collider);
                }
            }
            foreach (Trigger trigger in GlobalController.TriggerList)
            {
                if (GlobalController.Player.Collider.Intersects(trigger.Collider))
                {
                    GameController.PlayerMoveSleep(1000d);
                    GlobalController.CollidingTrigger = trigger;
                    GlobalController._Cv_func._Global_ChangingSceneTrigger(trigger.Index);
                    
                }
            }
            foreach (Decorats decorat in GlobalController.DecoratList)
            {
                if (decorat.Map.Name == GlobalController.Map.Name)
                {
                    if (testRect.Intersects(decorat.Collider))
                    {
                        ColliderHandler(testRect, decorat.Collider);
                    }
                }

            }
            foreach (IPlayerScene playerScene in GlobalController.PlayerSceneList)
            {
                if (playerScene.GetMap() == GlobalController.Map.Name)
                {
                    if (playerScene.GetIntanceType() != "Construction")
                    {
                        if (testRect.Intersects(playerScene.GetCollider()))
                        {
                            ColliderHandler(testRect, playerScene.GetCollider());
                        }
                    }
                    else
                    {
                        Construction con = playerScene as Construction;
                        for (int i = 0; i < con.GetColliders().Length; i++)
                        {
                            if (testRect.Intersects(con.GetColliders()[i]))
                            {
                                ColliderHandler(testRect, con.GetColliders()[i]);
                            }
                        }
                    }
                }

            }
            foreach (Animals animal in GlobalController.AnimalsList)
            {
                if (animal.GetMap() == GlobalController.Map.Name)
                {
                    if (testRect.Intersects(animal.GetCollider()))
                    {
                        ColliderHandler(testRect, animal.GetCollider());
                    } 
                }
            }
        }

        void ColliderHandler(Rectangle collision, Rectangle collisioned)
        {
            Vector2 standardPos = new Vector2();
            switch (directStatus)
            {
                case 1:
                    standardPos = new Vector2(GlobalController.Player.Position.X - 1.1f, GlobalController.Player.Position.Y);
                    break;
                case 2:
                    standardPos = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + 1.1f);
                    break;
                case 3:
                    standardPos = new Vector2(GlobalController.Player.Position.X + 1.1f, GlobalController.Player.Position.Y);
                    break;
                case 4:
                    standardPos = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - 1.1f);
                    break;
                case 5:
                    standardPos = new Vector2(GlobalController.Player.Position.X - 1.1f, GlobalController.Player.Position.Y + 1.1f);
                    break;
                case 6:
                    standardPos = new Vector2(GlobalController.Player.Position.X - 1.1f, GlobalController.Player.Position.Y - 1.1f);
                    break;
                case 7:
                    standardPos = new Vector2(GlobalController.Player.Position.X + 1.1f, GlobalController.Player.Position.Y - 1.1f);
                    break;
                case 8:
                    standardPos = new Vector2(GlobalController.Player.Position.X + 1.1f, GlobalController.Player.Position.Y + 1.1f);
                    break;
                default:
                    standardPos = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y);
                    break;
            }

            standardPos.X = standardPos.X + 2;
            standardPos.Y = standardPos.Y + 2 * Define.UnitOFpixel + 8;

            Vector2 collisionLeftTop = new Vector2(standardPos.X, standardPos.Y);
            Vector2 collisionLeftBottom = new Vector2(standardPos.X, standardPos.Y + collision.Height);
            Vector2 collisionRightTop = new Vector2(standardPos.X + collision.Width, standardPos.Y);
            Vector2 collisionRightBottom = new Vector2(standardPos.X + collision.Width, standardPos.Y + collision.Height);

            Vector2 collisionedLeftTop = new Vector2(collisioned.X, collisioned.Y);
            Vector2 collisionedLeftBottom = new Vector2(collisioned.X, collisioned.Y + collisioned.Height);
            Vector2 collisionedRightTop = new Vector2(collisioned.X + collisioned.Width, collisioned.Y);
            Vector2 collisionedRightBottom = new Vector2(collisioned.X + collisioned.Width, collisioned.Y + collisioned.Height);

            int status = 0;


            bool collisionLeftTop_in = false;
            bool collisionRightTop_in = false;
            bool collisionLeftBottom_in = false;
            bool collisionRightBottom_in = false;

            if (collisionedLeftTop.X <= collisionLeftTop.X && collisionLeftTop.X <= collisionedRightTop.X && collisionedLeftTop.Y <= collisionLeftTop.Y && collisionLeftTop.Y <= collisionedLeftBottom.Y)
            {
                collisionLeftTop_in = true;
            }

            if (collisionedLeftTop.X <= collisionRightTop.X && collisionRightTop.X <= collisionedRightTop.X && collisionedLeftTop.Y <= collisionRightTop.Y && collisionRightTop.Y <= collisionedLeftBottom.Y)
            {
                collisionRightTop_in = true;
            }

            if (collisionedLeftTop.X <= collisionLeftBottom.X && collisionLeftBottom.X <= collisionedRightTop.X && collisionedLeftTop.Y <= collisionLeftBottom.Y && collisionLeftBottom.Y <= collisionedLeftBottom.Y)
            {
                collisionLeftBottom_in = true;
            }

            if (collisionedLeftTop.X <= collisionRightBottom.X && collisionRightBottom.X <= collisionedRightTop.X && collisionedLeftTop.Y <= collisionRightBottom.Y && collisionRightBottom.Y <= collisionedLeftBottom.Y)
            {
                collisionRightBottom_in = true;
            }

            
            if (collisionLeftTop_in && !collisionRightTop_in && !collisionLeftBottom_in && !collisionRightBottom_in)
            {
                double eagle = Math.Abs(collisionLeftTop.X - collisionedRightBottom.X) / Math.Abs(collisionLeftTop.Y - collisionedRightBottom.Y);
                if (eagle == 0.90911108644989458 || eagle == 0.90908586489110832)
                {
                    status = 9;
                }
                else if (eagle < Math.Tan(45d))
                {
                    status = 1;
                }
                else if (eagle > Math.Tan(45d))
                {
                    status = 2;
                }
                else
                {
                    status = 9;
                }
            }

            if (!collisionLeftTop_in && collisionRightTop_in && !collisionLeftBottom_in && !collisionRightBottom_in)
            {
                double eagle = Math.Abs(collisionRightTop.X - collisionedLeftBottom.X) / Math.Abs(collisionRightTop.Y - collisionedLeftBottom.Y);
                if (eagle == 0.90911108644989458 || eagle == 0.90908586489110832)
                {
                    status = 10;
                }
                else if (eagle < Math.Tan(45d))
                {
                    status = 3;
                }
                else if (eagle > Math.Tan(45d))
                {
                    status = 4;
                }
                else
                {
                    status = 10;
                }
            }

            if (!collisionLeftTop_in && !collisionRightTop_in && collisionLeftBottom_in && !collisionRightBottom_in)
            {
                double eagle = Math.Abs(collisionLeftBottom.X - collisionedRightTop.X) / Math.Abs(collisionLeftBottom.Y - collisionedRightTop.Y);
                if (eagle == 0.90911108644989458 || eagle == 0.90908586489110832)
                {
                    status = 11;
                }
                else if (eagle < Math.Tan(45d))
                {
                    status = 5;
                }
                else if (eagle > Math.Tan(45d))
                {
                    status = 6;
                }
                else
                {
                    status = 11;
                }
            }

            if (!collisionLeftTop_in && !collisionRightTop_in && !collisionLeftBottom_in && collisionRightBottom_in)
            {
                double eagle = Math.Abs(collisionRightBottom.X - collisionedLeftTop.X) / Math.Abs(collisionRightBottom.Y - collisionedLeftTop.Y);
                if (eagle == 0.90911108644989458 || eagle == 0.90908586489110832)
                {
                    status = 12;
                }
                else if (eagle > Math.Tan(45d))
                {
                    status = 7;
                }
                else if (eagle < Math.Tan(45d))
                {
                    status = 8;
                }
                else
                {
                    status = 12;
                }
            }

            if (collisionLeftTop_in && collisionRightTop_in && !collisionLeftBottom_in && !collisionRightBottom_in)
            {
                status = 13;
            }

            if (collisionLeftTop_in && !collisionRightTop_in && collisionLeftBottom_in && !collisionRightBottom_in)
            {
                status = 14;
            }

            if (!collisionLeftTop_in && collisionRightTop_in && !collisionLeftBottom_in && collisionRightBottom_in)
            {
                status = 15;
            }

            if (!collisionLeftTop_in && !collisionRightTop_in && collisionLeftBottom_in && collisionRightBottom_in)
            {
                status = 16;
            }

            if (!collisionLeftTop_in && !collisionRightTop_in && !collisionLeftBottom_in && !collisionRightBottom_in)
            {
                status = 17;
            }

            collideCondition.Add(status);
        }

        void MoveFinalHandle()
        {
            //Console.WriteLine("[" + collideCondition.Count + "]");
            if (collideCondition.Count > 0)
            {
                //foreach (int item in collideCondition)
                //{
                //    Console.WriteLine(item + "," + directStatus);
                //}
                if (collideCondition.Count == 1)
                {
                    switch (collideCondition[0])
                    {
                        case 1:
                            if (directStatus == 1)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                            }
                            if (directStatus == 5)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                            }
                            if (directStatus == 6)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                            }
                            break;
                        case 2:
                            if (directStatus == 4)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            if (directStatus == 6)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            if (directStatus == 7)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            
                            break;
                        case 3:
                            if (directStatus == 3)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                            }
                            if (directStatus == 7)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                            }
                            if (directStatus == 8)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                            }

                            break;
                        case 4:
                            if (directStatus == 4)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            if (directStatus == 6)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            if (directStatus == 7)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            break;
                        case 5:
                            if (directStatus == 1)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                            }
                            if (directStatus == 5)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                            }
                            if (directStatus == 6)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                            }

                            break;
                        case 6:
                            if (directStatus == 2)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            if (directStatus == 5)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            if (directStatus == 8)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }

                            break;
                        case 7:
                            if (directStatus == 2)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            if (directStatus == 5)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            if (directStatus == 8)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            
                            break;
                        case 8:
                            if (directStatus == 3)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                            }
                            if (directStatus == 7)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                            }
                            if (directStatus == 8)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                            }
                            break;
                        case 9:
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            break;
                        case 10:
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            break;
                        case 11:
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            break;
                        case 12:
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            break;
                        case 13:
                            if (directStatus == 6)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            if (directStatus == 7)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            break;
                        case 14:
                            if (directStatus == 5)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                            }
                            if (directStatus == 6)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                            }
                            break;
                        case 15:
                            if (directStatus == 7)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                            }
                            if (directStatus == 8)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                            }
                            break;
                        case 16: 
                            if (directStatus == 5)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            if (directStatus == 8)
                            {
                                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                            }
                            break;
                        case 17:
                            
                            break;
                        default:
                            break;
                    }

                }
                else if (collideCondition.Count == 2)
                {
                    if ((collideCondition[0] == 2 && collideCondition[1] == 4) || (collideCondition[0] == 4 && collideCondition[1] == 2) || (collideCondition[0] == 1 && collideCondition[1] == 4) || (collideCondition[0] == 4 && collideCondition[1] == 1) || (collideCondition[0] == 2 && collideCondition[1] == 3) || (collideCondition[0] == 3 && collideCondition[1] == 2) || (collideCondition[0] == 1 && collideCondition[1] == 3) || (collideCondition[0] == 3 && collideCondition[1] == 1))
                    {
                        if (directStatus == 6)
                        {
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                        }
                        if (directStatus == 7)
                        {
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                        }
                    }
                    if ((collideCondition[0] == 1 && collideCondition[1] == 5) || (collideCondition[0] == 5 && collideCondition[1] == 1) || (collideCondition[0] == 1 && collideCondition[1] == 6) || (collideCondition[0] == 6 && collideCondition[1] == 1) || (collideCondition[0] == 2 && collideCondition[1] == 5) || (collideCondition[0] == 5 && collideCondition[1] == 2) || (collideCondition[0] == 2 && collideCondition[1] == 6) || (collideCondition[0] == 6 && collideCondition[1] == 2))
                    {
                        if (directStatus == 5)
                        {
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                        }
                        if (directStatus == 6)
                        {
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                        }
                    }
                    if ((collideCondition[0] == 3 && collideCondition[1] == 8) || (collideCondition[0] == 8 && collideCondition[1] == 3) || (collideCondition[0] == 3 && collideCondition[1] == 7) || (collideCondition[0] == 7 && collideCondition[1] == 3) || (collideCondition[0] == 4 && collideCondition[1] == 7) || (collideCondition[0] == 7 && collideCondition[1] == 4) || (collideCondition[0] == 4 && collideCondition[1] == 8) || (collideCondition[0] == 8 && collideCondition[1] == 4))
                    {
                        if (directStatus == 7)
                        {
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                        }
                        if (directStatus == 8)
                        {
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                        }
                    }
                    if ((collideCondition[0] == 6 && collideCondition[1] == 7) || (collideCondition[0] == 7 && collideCondition[1] == 6) || (collideCondition[0] == 6 && collideCondition[1] == 8) || (collideCondition[0] == 8 && collideCondition[1] == 6) || (collideCondition[0] == 5 && collideCondition[1] == 7) || (collideCondition[0] == 7 && collideCondition[1] == 5) || (collideCondition[0] == 5 && collideCondition[1] == 8) || (collideCondition[0] == 8 && collideCondition[1] == 5))
                    {
                        if (directStatus == 5)
                        {
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                        }
                        if (directStatus == 8)
                        {
                            GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y);
                        }
                    }
                }

            }
            else
            {

                switch (directStatus)
                {
                    case 1:
                        GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed, GlobalController.Player.Position.Y);
                        break;
                    case 2:
                        GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.Player.Speed);
                        break;
                    case 3:
                        GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed, GlobalController.Player.Position.Y);
                        break;
                    case 4:
                        GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.Player.Speed);
                        break;
                    case 5:
                        GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                        break;
                    case 6:
                        GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                        break;
                    case 7:
                        GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y - GlobalController.Player.Speed / 2);
                        break;
                    case 8:
                        GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + GlobalController.Player.Speed / 2, GlobalController.Player.Position.Y + GlobalController.Player.Speed / 2);
                        break;
                    default:
                        break;
                } 
            }
        }

        void HoldingCheck()
        {
            //if (GlobalController.InventWithMouse.IsNull)
            //{
            //    if (isHolding && GlobalController.Player.CurrentFrame.Y >= 32)
            //    {
            //        GlobalController.Player.CurrentFrame = new Point(GlobalController.Player.CurrentFrame.X, GlobalController.Player.CurrentFrame.Y - 32);
            //        isHolding = false;
            //    }
            //}
            //else
            //{
            //    if (!isHolding && GlobalController.Player.CurrentFrame.Y < 32)
            //    {
            //        GlobalController.Player.CurrentFrame = new Point(GlobalController.Player.CurrentFrame.X, GlobalController.Player.CurrentFrame.Y + 32);
            //        isHolding = true;
            //    }
            //}
        }

        void FishingHandle()
        {
            #region old code
            //int fishDirectStatus = 0;
            //int fishEagleStatus = 0;
            //if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.Down) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.Up))
            //{
            //    fishDirectStatus = 1;
            //}
            //if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.Down) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.Up))
            //{
            //    fishDirectStatus = 2;
            //}
            //if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.Down) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.Up))
            //{
            //    fishDirectStatus = 3;
            //}
            //if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.Down) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.Up))
            //{
            //    fishDirectStatus = 4;
            //}
            //if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.Down) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.Up))
            //{
            //    fishDirectStatus = 5;
            //}
            //if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.Down) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.Up))
            //{
            //    fishDirectStatus = 6;
            //}
            //if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.Down) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.Up))
            //{
            //    fishDirectStatus = 7;
            //}
            //if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.Down) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.Up))
            //{
            //    fishDirectStatus = 8;
            //}
            //if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.Down) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.Up))
            //{
            //    fishDirectStatus = 2;
            //}
            //if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.Up) && !InputHandler.KeyboardState.IsKeyDown(Keys.Down))
            //{
            //    fishDirectStatus = 4;
            //}
            //if (InputHandler.KeyboardState.IsKeyDown(Keys.Left) && !InputHandler.KeyboardState.IsKeyDown(Keys.Right))
            //{
            //    fishEagleStatus = 1;
            //}
            //if (!InputHandler.KeyboardState.IsKeyDown(Keys.Left) && InputHandler.KeyboardState.IsKeyDown(Keys.Right))
            //{
            //    fishEagleStatus = 2;
            //}
            //GlobalController.FishingSys.HandleHook(fishDirectStatus, fishEagleStatus);
            #endregion
            if (GlobalController.FishingSys.Step == 1)
            {
                if (GlobalController.MouseState.LeftButton == ButtonState.Pressed)
                {
                    if (GlobalController.FishingSys.PressDirect)
                    {
                        GlobalController.FishingSys.FishingBarPercent += 0.03f;
                        if (GlobalController.FishingSys.FishingBarPercent > 1f)
                        {
                            GlobalController.FishingSys.PressDirect = false;
                        }
                    }
                    else
                    {
                        GlobalController.FishingSys.FishingBarPercent -= 0.03f;
                        if (GlobalController.FishingSys.FishingBarPercent < 0f)
                        {
                            GlobalController.FishingSys.PressDirect = true;
                        }
                    }
                }
                else
                {
                    Vector2 p0 = new Vector2();
                    Vector2 p1 = new Vector2();
                    Vector2 p2 = new Vector2();
                    switch (GlobalController.Player.Direct)
                    {
                        case 0:
                            GlobalController.FishingSys.HookStartPos = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + Define.UnitOFpixel);
                            GlobalController.FishingSys.HookEndPos = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + GlobalController.FishingSys.FishingBarPercent * 6 * Define.UnitOFpixel);
                            GlobalController.FishingSys.Direct = 0;
                            break;
                        case 1:
                            GlobalController.FishingSys.HookStartPos = new Vector2(GlobalController.Player.Position.X - Define.UnitOFpixel, GlobalController.Player.Position.Y + Define.UnitOFpixel);
                            p1 = new Vector2(GlobalController.Player.Position.X - GlobalController.FishingSys.FishingBarPercent * 6 * Define.UnitOFpixel * 2, GlobalController.Player.Position.Y + Define.UnitOFpixel);
                            GlobalController.FishingSys.HookEndPos = new Vector2(GlobalController.Player.Position.X - GlobalController.FishingSys.FishingBarPercent * 6 * Define.UnitOFpixel * 2, GlobalController.Player.Position.Y);
                            GlobalController.FishingSys.Direct = 1;
                            break;
                        case 2:
                            GlobalController.FishingSys.HookStartPos = new Vector2(GlobalController.Player.Position.X + 1.5f * Define.UnitOFpixel, GlobalController.Player.Position.Y + 8);
                            p0 = new Vector2(GlobalController.Player.Position.X + 1.5f * Define.UnitOFpixel - 11, GlobalController.Player.Position.Y + 8 - 1);
                            p1 = new Vector2(GlobalController.Player.Position.X + GlobalController.FishingSys.FishingBarPercent * 8 * Define.UnitOFpixel, GlobalController.Player.Position.Y - 3 * Define.UnitOFpixel);
                            p2 = new Vector2(GlobalController.Player.Position.X + GlobalController.FishingSys.FishingBarPercent * 8 * Define.UnitOFpixel, GlobalController.Player.Position.Y + 2 * Define.UnitOFpixel);
                            GlobalController.FishingSys.Direct = 2;
                            break;
                        case 3:
                            GlobalController.FishingSys.HookStartPos = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - Define.UnitOFpixel);
                            GlobalController.FishingSys.HookEndPos = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - GlobalController.FishingSys.FishingBarPercent * 6 * Define.UnitOFpixel);
                            GlobalController.FishingSys.Direct = 3;
                            break;
                        default:
                            break;
                    }
                    GlobalController.FishingSys.HookRunLine.Clear();
                    for (int i = 0; i <= 75; i++)
                    {
                        GlobalController.FishingSys.HookRunLine.Add((float)Math.Pow(1 - i / 75f, 2) * p0 + 2 * i / 75f * (1 - i / 75f) * p1 + (float)Math.Pow(i / 75f, 2) * p2);
                    }
                    GlobalController.FishingSys.Step = 2;
                    GlobalController.PlayerIsFishing = false;
                    
                }
            }
            else if (GlobalController.FishingSys.Step == 4)
            {
                if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.S) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    GlobalController.FishingSys.KeyDirect = 1;
                }
                if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.S) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    GlobalController.FishingSys.KeyDirect = 2;
                }
                if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.S) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    GlobalController.FishingSys.KeyDirect = 3;
                }
                if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.S) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    GlobalController.FishingSys.KeyDirect = 4;
                }
                if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.S) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    GlobalController.FishingSys.KeyDirect = 5;
                }
                if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.S) && !InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    GlobalController.FishingSys.KeyDirect = 6;
                }
                if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && !InputHandler.KeyboardState.IsKeyDown(Keys.S) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    GlobalController.FishingSys.KeyDirect = 7;
                }
                if (!InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.S) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    GlobalController.FishingSys.KeyDirect = 8;
                }
                if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.S) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && !InputHandler.KeyboardState.IsKeyDown(Keys.W))
                {
                    GlobalController.FishingSys.KeyDirect = 2;
                }
                if (InputHandler.KeyboardState.IsKeyDown(Keys.A) && InputHandler.KeyboardState.IsKeyDown(Keys.D) && InputHandler.KeyboardState.IsKeyDown(Keys.W) && !InputHandler.KeyboardState.IsKeyDown(Keys.S))
                {
                    GlobalController.FishingSys.KeyDirect = 4;
                }
            }
        }

        public static void ChangeDirect(int direction)
        {
            direction -= 2;
            if (direction < 0)
            {
                direction = 3;
            }
            GlobalController.Player.Direct = direction;
        }

        void ShowPickAnim(int direction,GameTime gameTime)
        {
            funcExecTime = 2;
            endExecTime = 3;
            secondFuncExecTime = -1;
            thirdFuncExecTime = -1;
            millisecondsPerFrameAnim = 150;
            LoadAnimation(gameTime, direction, 4, -1, "_Global_PickItem");            
        }

        void ShowUsingToolsAnim(int direction, GameTime gameTime, int toolt)
        {

            if (toolt == 1)
            {
                funcExecTime = 4;
                endExecTime = 5;
                secondFuncExecTime = -1;
                thirdFuncExecTime = -1;
                millisecondsPerFrameAnim = 100;
                LoadAnimation(gameTime, direction, 8, 0, "_Agriculture_DoReclaim");
            }
            else if (toolt == 2)
            {
                funcExecTime = 2;
                endExecTime = 3;
                secondFuncExecTime = -1;
                thirdFuncExecTime = -1;
                millisecondsPerFrameAnim = 150;
                LoadAnimation(gameTime, direction, 16, 4, "_Agriculture_Watering");
            }
            else if (toolt == 3)
            {
                funcExecTime = 4;
                endExecTime = 5;
                secondFuncExecTime = -1;
                thirdFuncExecTime = -1;
                millisecondsPerFrameAnim = 80;
                LoadAnimation(gameTime, direction, 36, 8, "_Logging_CutTree");
            }
        }

        void ShowSeedingAnim(int direction, GameTime gameTime)
        {
            funcExecTime = 2;
            endExecTime = 3;
            secondFuncExecTime = -1;
            thirdFuncExecTime = -1;
            millisecondsPerFrameAnim = 150;
            LoadAnimation(gameTime, direction, 12, -1, "_Agriculture_Seed");
        }

        void ShowHarvestAnim(int direction, GameTime gameTime)
        {
            millisecondsPerFrameAnim = 150;
            LoadAnimationProgress(gameTime, direction, 20, -1, 2, 5, "_Agriculture_HarvestItem");           
        }

        void ShowGivingAnim(int direction, GameTime gameTime)
        {
            funcExecTime = 4;
            secondFuncExecTime = -1;
            thirdFuncExecTime = -1;
            endExecTime = 5;
            millisecondsPerFrameAnim = 100;
            LoadAnimation(gameTime, direction, 28, -1, "_Global_Giving");          
        }

        void ShowBackOffAnim(int direction, GameTime gameTime)
        {
            if (direction == 0)
            {
                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y - 5);
            }
            else if (direction == 1)
            {
                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X, GlobalController.Player.Position.Y + 5);
            }
            else if (direction == 2)
            {
                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X - 5, GlobalController.Player.Position.Y);
            }
            else if (direction == 3)
            {
                GlobalController.Player.Position = new Vector2(GlobalController.Player.Position.X + 5, GlobalController.Player.Position.Y);
            }
        }

        void ShowFishingAnim(int direction, GameTime gameTime)
        {
            funcExecTime = 1;
            secondFuncExecTime = 3;
            thirdFuncExecTime = -1;
            endExecTime = 5;
            millisecondsPerFrameAnim = 120;
            LoadAnimation(gameTime, direction, 40, 12, "_Global_Fishing");     
        }


        void LoadAnimation(GameTime gameTime, int direction, int playingAnim, int toolFrameY, string funcName)
        {
            direction -= 2;
            if (direction < 0)
            {
                direction = 3;
            }
            Point newToolFrame = GlobalController.Player.ToolsFrame;
            if (firstExecute)
            {
                timeSinceLastFrame = 0;
                GlobalController.Player.Frame = 0;
                GlobalController.Player.Anim = playingAnim;
                GlobalController.Player.Direct = direction;
                newToolFrame.X = 0;
                if (toolFrameY != -1)
                {
                    newToolFrame.Y = toolFrameY + direction;
                }
                currentExecTime = 0;
                firstExecute = false;
            }
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrameAnim)
            {
                timeSinceLastFrame = 0;
                ++GlobalController.Player.Frame;
                if (toolFrameY != -1)
                {
                    ++newToolFrame.X;
                }

                ++currentExecTime;

                if (currentExecTime == funcExecTime)
                {
                    switch (funcName)
                    {
                        case "_Agriculture_DoReclaim":
                            GlobalController._Cv_func._Agriculture_DoReclaim(vector2_para);
                            break;
                        case "_Agriculture_Watering":
                            GlobalController._Cv_func._Agriculture_Watering(vector2_para);
                            break;
                        case "_Agriculture_Seed":
                            GlobalController._Cv_func._Agriculture_Seed(int_para);
                            break;
                        case "_Global_Giving":
                            GlobalController._Cv_func._Global_Giving(go_para, string_para);
                            break;
                        case "_Global_PickItem":
                            GlobalController._Cv_func._Global_PickItem(item_para);
                            break;
                        case "_Logging_CutTree":
                            GlobalController._Cv_func._Logging_CutTree(go_para as Tree);
                            break;
                        case "_Global_Fishing":
                            GlobalController._Cv_func._Breed_Fishing();
                            break;
                        default:
                            break;
                    }
                }
                if (currentExecTime == secondFuncExecTime)
                {
                    switch (funcName)
                    {                        
                        case "_Global_Fishing":
                            GlobalController._Cv_func._Breed_ThrowHook();
                            break;
                        default:
                            break;
                    }
                }
                if (currentExecTime >= endExecTime)
                {
                    showAnim_ = false;
                    firstExecute = true;
                    direct = 0;
                    anim = "";
                    GlobalController.Player.Frame = 0;
                    GlobalController.Player.Anim = 0;
                    GlobalController.Player.Direct = direction;
                    newToolFrame.X = 0;
                    newToolFrame.Y = 0;
                    timeSinceLastFrame = millisecondsPerFrame;
                    GlobalController.PlayerCanMove = true;
                    GlobalController.Player.ShadowFrame = new Point(2, 0);
                }

            }
            GlobalController.Player.ToolsFrame = newToolFrame;
        }

        void LoadAnimationProgress(GameTime gameTime, int direction, int playingAnim, int toolFrameY, int startFrame, int endFrame, string funcName)
        {
            direction -= 2;
            if (direction < 0)
            {
                direction = 3;
            }
            Point newToolFrame = GlobalController.Player.ToolsFrame;
            if (firstExecute)
            {
                timeSinceLastFrame = 0;
                GlobalController.Player.Frame = 0;
                GlobalController.Player.Anim = playingAnim;
                GlobalController.Player.Direct = direction;
                newToolFrame.X = 0;
                if (toolFrameY != -1)
                {
                    newToolFrame.Y = toolFrameY + direction;
                }
                currentExecTime = 0;
                firstExecute = false;
            }
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrameAnim)
            {
                timeSinceLastFrame = 0;
                ++GlobalController.Player.Frame;
                if (toolFrameY != -1)
                {
                    ++newToolFrame.X;
                }
                ++currentExecTime;
                if (currentExecTime >= endFrame)
                {
                    currentExecTime = startFrame;
                    GlobalController.Player.Frame = startFrame;
                }
                if (currentExecTime >= startFrame)
                {
                    GlobalController.Player.ShadowFrame = new Point(3, 0);

                }
                if (!GlobalController.ShowProgress)
                {
                    switch (funcName)
                    {
                        case "_Agriculture_HarvestItem":
                            GlobalController._Cv_func._Agriculture_HarvestItem(int_para);
                            break;
                        default:
                            break;
                    }
                    showAnim_ = false;
                    firstExecute = true;
                    direct = 0;
                    anim = "";
                    GlobalController.Player.Frame = 0;
                    GlobalController.Player.Anim = 0;
                    GlobalController.Player.Direct = direction;
                    newToolFrame.X = 0;
                    newToolFrame.Y = 0;
                    timeSinceLastFrame = millisecondsPerFrame;
                    GlobalController.PlayerCanMove = true;
                    GlobalController.Player.ShadowFrame = new Point(2, 0);
                }
            }
            GlobalController.Player.ToolsFrame = newToolFrame;
        }

        public static void ShowAnim(string an,int dir)
        {
            showAnim_ = true;
            anim = an;
            direct = dir;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnim(string an, int dir,OutDoorItem item)
        {
            showAnim_ = true;
            anim = an;
            direct = dir;
            item_para = item;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnim(string an, int dir, GameObject go, string _string)
        {
            showAnim_ = true;
            anim = an;
            direct = dir;
            go_para = go;
            string_para = _string;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnim(string an, int dir, GameObject go, int _number)
        {
            showAnim_ = true;
            anim = an;
            direct = dir;
            go_para = go;
            int_para = _number;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnim(string _anim, int _direct, int _int)
        {
            showAnim_ = true;
            anim = _anim;
            direct = _direct;
            int_para = _int;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnim(string _anim, int _direct, Vector2 _vector2)
        {
            showAnim_ = true;
            anim = _anim;
            direct = _direct;
            vector2_para = _vector2;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnim(string _anim, int _int, OutDoorItem _item, int _number)
        {
            showAnim_ = true;
            anim = _anim;
            direct = _int;
            item_para = _item;
            int_para = _number;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnim(string _anim, int _direct, Vector2 _vector2, int _int)
        {
            showAnim_ = true;
            anim = _anim;
            direct = _direct;
            vector2_para = _vector2;
            int_para = _int;
            GlobalController.PlayerCanMove = false;
        }



        public static void ShowAnimProgress(string _anim, int _direct)
        {
            showAnim_ = true;
            anim = _anim;
            direct = _direct;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnimProgress(string _anim, int _direct, OutDoorItem _item)
        {
            showAnim_ = true;
            anim = _anim;
            direct = _direct;
            item_para = _item;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnimProgress(string _anim, int _direct, int _int)
        {
            showAnim_ = true;
            anim = _anim;
            direct = _direct;
            int_para = _int;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnimProgress(string _anim, int _direct, Vector2 _vector2)
        {
            showAnim_ = true;
            anim = _anim;
            direct = _direct;
            vector2_para = _vector2;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnimProgress(string _anim, int _direct, OutDoorItem _item, int _int)
        {
            showAnim_ = true;
            anim = _anim;
            direct = _direct;
            item_para = _item;
            int_para = _int;
            GlobalController.PlayerCanMove = false;
        }

        public static void ShowAnimProgress(string _anim, int _direct, Vector2 _vector2, int _int)
        {
            showAnim_ = true;
            anim = _anim;
            direct = _direct;
            vector2_para = _vector2;
            int_para = _int;
            GlobalController.PlayerCanMove = false;
        }


    }
}
