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
using CV_xLibrary;
using CV_Library;
using System.Text;
using CV_Library.Controllers;
using CV_Library.GameObjects.Items;
using System.Xml;
using System.IO;
using CV_Library.Interfaces;
using CV_Library.GameObjects.Buildings;
using CV_Library.GameObjects.Soils;
using CV_Library.Globals;
using CV_Library.GameObjects.Characters;
using CV_Library.GameObjects.Trees;
using CV_Library.GameObjects.Characters.Animals;
using CV_Library.Functions;
//using Box2D.XNA;

namespace CityAndVillage
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        GameController gc;

        RenderTarget2D lightsTarget;
        RenderTarget2D gameTarget;
        RenderTarget2D UITarget;
        RenderTarget2D mainTarget;
        RenderTarget2D maskTarget;
        RenderTarget2D pauseTarget;
        RenderTarget2D weatherTarget;

        Effect lightingEffect;

        bool changeMask255_0 = false;
        bool changeMask0_255 = false;

        bool savingMask255_0 = false;
        bool savingMask0_255 = false;

        bool gameActiveInit = false;


        int rainFresh = 0;
        int windFresh = 0;
        int windWaitTime = 0;
        int windWaitTimeStart = 0;
        int windWaitTimeEnd = 0;
        int soilFresh = 0;
        int seedDeathCheckTime = 0;
        int seedDeathCheckDuringTime = 0;
        int playerHungerShowTime = 0;

        //int playerDecoratShowTimeRan = 0;
        //int playerDecoratShowTime = 0;
        //bool playerDecoratDirect = true;
        //int playerDecoratMoveTimes = 0;
        //int playerDecoratMoveTimesRan = 0;

        int calendarExhibitionMoveTime = 0;
        int calendarExhibitionMoveTimeRan = 0;
        bool calendarExhibitionAnim = false;
        int calendarExhibitionTimes = 0;

        int waterMove = 0;
        int waterMoveTime = 0;

        int shopRectMoveTime = 0;
        int shopArrowUpMoveTime = 0;
        int shopArrowDownMoveTime = 0;

        int waterCliffMoveTime = 0;
        int waveMoveTime = 0;
        int waveMoveStatus = 0;

        bool sleepMask255_0 = false;
        bool sleepMask0_255 = false;
        float sleepingTotalTime = -1;
        Game1 game;

        int varAmountTestTime = 0;
        int cameraTestTime = 0;
        int framesTestTime = 0;
        int updateTime = 0;
        int drawTime = 0;


        public Game1()
        {            
            graphics = new GraphicsDeviceManager(this);
            //graphics.SynchronizeWithVerticalRetrace = true;
            //graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
           
            graphics.PreferredBackBufferHeight = 640;
            graphics.PreferredBackBufferWidth = 1024;
            Components.Add(new InputHandler(this));
            Components.Add(new PlayerHandler(this));
            Components.Add(new MouseHandler(this));
            game = this;
        }

        protected override void Initialize()
        {
            gc = new GameController(Content);
            base.IsFixedTimeStep = false;
            //base.IsFixedTimeStep = true;
            //graphics.SynchronizeWithVerticalRetrace = true;
            Define.windowHeight = Window.ClientBounds.Height / 2;
            Define.windowWidth = Window.ClientBounds.Width / 2;
            //Define.box2d_RATIO = Define.windowWidth / 10;

            //Vector2 gravity = new Vector2(0.0f, 0.0f);
            //bool doSleep = false;
            //GlobalController._World = new World(gravity, doSleep);
            //GlobalController._World.ContactListener = new CollisionListener(); 

            base.Initialize();           
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
           
            var pp = GraphicsDevice.PresentationParameters;
            lightsTarget = new RenderTarget2D(
                GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
            gameTarget = new RenderTarget2D(
                GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
            UITarget = new RenderTarget2D(
                GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
            mainTarget = new RenderTarget2D(
                GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
            maskTarget = new RenderTarget2D(
                GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
            weatherTarget = new RenderTarget2D(
                GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);
            pauseTarget = new RenderTarget2D(
                GraphicsDevice, pp.BackBufferWidth, pp.BackBufferHeight);

            //Console.WriteLine(pp.BackBufferWidth+"_"+pp.BackBufferHeight);
            

            ResourceController.Initialize(Content);

            lightingEffect = ResourceController.Effects_Light;

            InitGlobal();

            DataController.Initialize();
        }

        void InitGlobal()
        {
            GlobalController.isPause = false;
            GlobalController.Mask = new Color(0, 0, 0);
            GlobalController.PauseMask = new Color(0, 0, 0, 0f);          
            GlobalController.TimeAccelerate = 1f;
            GlobalController.OutdoorLight = gc.GetLightByTime(GlobalController.Time);
            GlobalController.MenuOut = false;            
            GlobalController.Mouse = new CV_Library.Functions.Mouse(Content.Load<Texture2D>(@"UI/UI_mouse_status"));
            GlobalController.InventWithMouse = new Inventory(null, true, 0, 0);
            GlobalController.Isshopping = false;
            GlobalController.BaggageOut = false;
            GlobalController.SaleBoxOut = false;
            GlobalController.BaggageBanner = new Inventory(null, true, -1, 0);           
            GlobalController.ShowDetail = false;
            GlobalController.isTalking = false;
            GlobalController.SelectDialogue = false;
            GlobalController.ShowAlert = false;
            GlobalController.PlayerDecoratMove = false;
            GlobalController.SleepingStart = false;
            GlobalController.SleepingEnd = false;
            GlobalController.SleepingTime = 0;
            GlobalController.PlayerSleeping = false;
            GlobalController.PlayerIsFishing = false;
            GlobalController.AlertPos = new Vector2(Define.windowWidth - 120, -100);
            GlobalController.ProgressLayerDepth = -0.02f;
            GlobalController.PlayerWithoutInit = new Player(Map.Null, Vector2.Zero, "", null, -1f, false, false, -1f, -1f, -1f, -1f, -1f, -1f, -1, false, "");           
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            //VarTestHandler(gameTime);
            //CameraTestHandler(gameTime);
            //FrameTestHandler(gameTime);
            //CharacterAnimTestHandler(gameTime);
            //if (GlobalController.Map != null)
            //{
            //    Console.WriteLine(GlobalController.Player.LayerDepth);
            //    Console.WriteLine();
            //    for (int i = 0; i < GlobalController.Npcs.Length; i++)
            //    {
            //        Console.WriteLine(GlobalController.Npcs[i].LayerDepth);
            //    }
            //    Console.WriteLine();
            //}


            //updateTime++;
            
            if (GlobalController.MouseState != null)
            {
                GlobalController.LastMouseState = GlobalController.MouseState;
            }
            GlobalController.MouseState = Microsoft.Xna.Framework.Input. Mouse.GetState();

            if (!GlobalController.isPause)
            {
                if (!game.IsActive)
                {
                    if (gameActiveInit)
                    {
                        GlobalController.PauseMask = new Color(0, 0, 0, 0.5f);
                        GlobalController.isPause = true;
                    }
                    else
                    {
                        gameActiveInit = true;
                    }
                }
                if (!GlobalController.isTalking)
                {

                    TimeHandler(gameTime);

                    CalenderHandler();

                    OutdoorLightHandler();

                    SceneHandler(gameTime);

                    NpcHandler(gameTime);

                    SavingMaskHandler(gameTime);                   

                    BusRequestHandler(gameTime);

                    ConversationEventHandler();

                    SoilConsumeWater(gameTime);

                    SeedGrow(gameTime);

                    SeedDeathCheck(gameTime);

                    ProgressHandler(gameTime);

                    SaleBox_ShopsHandle();

                    ChestHandler();

                    SleepHandler(gameTime);

                    TreeHandler(gameTime);

                    AnimalHanlder(gameTime);

                    FishingHanlder(gameTime);

                    //Box2DHandler(gameTime);

                }

                WeatherHandler(gameTime);

                FlowerHandler(gameTime);

                OutDoorItemHandler();

                UIHandler(gameTime);

                //Vector2 v = new Vector2(GlobalController.Player.Position.X / 24, GlobalController.Player.Position.Y / 24);
                //Console.WriteLine((int)v.X + "," + (int)(v.Y + 3));
                //Console.WriteLine(GlobalController.Player.MidPos);
            }

            //VisioHandler();

            DetailHandler(gameTime);

            AlertHandler(gameTime);

            MouseHandler(gameTime);

            IfMouseLeaveHandler();

            IfBaggageCloseHandler();

            CheckInventaryItemCount();

            WaterHandler(gameTime);


            base.Update(gameTime);            
        }

        //void Box2DHandler(GameTime gameTime)
        //{
        //    GlobalController._World.Step(0.002f, 8, 3);
        //    for (Body b = GlobalController._World.GetBodyList(); b!= null;b = b.GetNext() )
        //    {
        //        if (b.GetUserData() != null)
        //        {
        //            Character c = b.GetUserData() as Character;

        //            b.SetTransform(c.Position / Define.box2d_RATIO, 0);
        //            //c.Position = b.Position * Define.box2d_RATIO;
        //        }
        //    }
        //}

        void CharacterAnimTestHandler(GameTime gamTime)
        {
            if (GlobalController.Player != null)
            {
                Console.WriteLine(GlobalController.Player.Frame);
                Console.WriteLine(GlobalController.Player.Anim);
                Console.WriteLine(GlobalController.Player.Direct);
            }
        }

        void FrameTestHandler(GameTime gameTime)
        {
            framesTestTime += gameTime.ElapsedGameTime.Milliseconds;
            if (framesTestTime > 1000)
            {
                framesTestTime = 0;
                Console.WriteLine("updateTime/frame:" + updateTime);
                Console.WriteLine("drawTime/frame:" + drawTime);
                updateTime = 0;
                drawTime = 0;
                Console.WriteLine();
            }
        }

        void VarTestHandler(GameTime gameTime)
        {
            varAmountTestTime += gameTime.ElapsedGameTime.Milliseconds;
            if (varAmountTestTime > 3000)
            {
                varAmountTestTime = 0;
                Console.WriteLine("Npc nums:" + GlobalController.Npcs.Length);
                Console.WriteLine("MapTile nums:" + GlobalController.MapTileList.Count);
                Console.WriteLine("WaterProducer nums:" + GlobalController.WaterProduceList.Count);
                Console.WriteLine("WaterTile nums:" + GlobalController.WaterList.Count);
                Console.WriteLine("PlayerScene nums:" + GlobalController.PlayerSceneList.Count);
                Console.WriteLine("Weather nums:" + GlobalController.WeatherHandleList.Count);
                Console.WriteLine("Tree nums:" + GlobalController.TreeList.Count);
                Console.WriteLine("Leaf nums:" + GlobalController.LeafList.Count);
                Console.WriteLine("Barrier nums:" + GlobalController.BarrierList.Count);
                Console.WriteLine("Bush nums:" + GlobalController.BushList.Count);
                Console.WriteLine("Trigger nums:" + GlobalController.TriggerList.Count);
                Console.WriteLine("OutdoorItems nums:" + GlobalController.OutdoorItemsList.Count);
                Console.WriteLine("Flower nums:" + GlobalController.FlowerList.Count);
                Console.WriteLine("Decorat nums:" + GlobalController.DecoratList.Count);
                Console.WriteLine("Building nums:" + GlobalController.BuildingList.Count);
                Console.WriteLine("Soil nums:" + GlobalController.SoilList.Count);
                Console.WriteLine("WCliff nums:" + GlobalController.WCliffList.Count);
                Console.WriteLine("Wave nums:" + GlobalController.WaveList.Count);
                Console.WriteLine("Sand nums:" + GlobalController.SandList.Count);
                Console.WriteLine("Animals nums:" + GlobalController.AnimalsList.Count);
                Console.WriteLine("button nums:" + GlobalController.buttonList.Count);
                Console.WriteLine("Inventory nums:" + GlobalController.InventoryList.Count);
                Console.WriteLine("RapidRoom nums:" + GlobalController.RapidRoomList.Count);
                Console.WriteLine("ConversationContent nums:" + GlobalController.ConversationContent.Count);
                Console.WriteLine("SelectDialogueContent nums:" + GlobalController.SelectDialogueContent.Count);
                Console.WriteLine("ConversationOptionSelect nums:" + GlobalController.ConversationOptionSelect.Count);
                Console.WriteLine("Global_Shops nums:" + GlobalController.Global_Shops.Count);
                Console.WriteLine("Player_ShoppingCart nums:" + GlobalController.Player_ShoppingCart.Count);
                Console.WriteLine("WaterJudge nums:" + GlobalController.WaterJudge.Count);
                Console.WriteLine();
            }
        }

        void CameraTestHandler(GameTime gameTime)
        {
            cameraTestTime += gameTime.ElapsedGameTime.Milliseconds;
            if (cameraTestTime > 1000)
            {
                cameraTestTime = 0;
                Console.WriteLine("PlayerPos:" + GlobalController.Player.Position);

                //Console.WriteLine("PlayerArea:" + GlobalController.Camera.PlayerArea);
                //Console.WriteLine("PlayerCenterPoint:" + GlobalController.Camera.PlayerCenterPoint);

                //Console.WriteLine("SmallArea:" + GlobalController.Camera.SmallArea);
                //Console.WriteLine("SmallCenterPoint" + GlobalController.Camera.SmallCenterPoint);

                Console.WriteLine("CameraArea:" + GlobalController.Camera.CameraArea);
                //Console.WriteLine("CameraCenterPoint:" + GlobalController.Camera.CameraCenterPoint);
                Console.WriteLine();
            }
            
        }

        void VisioHandler()
        {
            foreach (Building building in GlobalController.BuildingList)
            {
                building.TestPlayerVisio();
            }
        }

        void FishingHanlder(GameTime gameTime)
        {
            if (GlobalController.PlayerIsFishing)
            {
                GlobalController.FishingSys.Handle(gameTime.ElapsedGameTime.Milliseconds);
            }
        }

        void AnimalHanlder(GameTime gameTime)
        {
            foreach (Animals animal in GlobalController.AnimalsList)
            {
                if (animal.Emotion != string.Empty && animal.Emotion != "hungry")
                {
                    animal.EmotionShowTime += gameTime.ElapsedGameTime.Milliseconds;
                    if (animal.EmotionShowTime > 3000)
                    {
                        animal.EmotionShowTime = 0;
                        animal.Emotion = string.Empty;
                    }
                }
                animal.Hunger -= gameTime.ElapsedGameTime.Milliseconds / 1000f * GlobalController.TimeAccelerate;
                if (animal.FindingPath)
                {
                    foreach (IPlayerScene ipS in GlobalController.PlayerSceneList)
                    {
                        if (ipS.GetIntanceType() == "Construction")
                        {
                            if ((ipS.GetInstance() as Construction).Name == "cowhouse")
                            {
                                if ((ipS.GetInstance() as CowHouse).Id == animal.Id)
                                {
                                    animal.MoveByPath((ipS.GetInstance() as CowHouse).IsDoorOpen, gameTime.ElapsedGameTime.Milliseconds);
                                }
                            }
                        }
                    }
                    
                }
                else if (animal.IsEating)
                {
                    if (animal.EatContinue((int)(gameTime.ElapsedGameTime.Milliseconds * GlobalController.TimeAccelerate)))
                    {
                        if (animal.EatOutSide)
                        {
                            animal.EatingSoil.Seed.GrowTime -= 1440;
                        }
                        else
                        {
                            foreach (IPlayerScene ipS in GlobalController.PlayerSceneList)
                            {
                                if (ipS.GetIntanceType() == "Construction")
                                {
                                    if ((ipS.GetInstance() as Construction).Name == "cowhouse")
                                    {
                                        if ((ipS.GetInstance() as CowHouse).Id == animal.Id)
                                        {
                                            (ipS.GetInstance() as CowHouse).IsHaveFood = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    animal.ActionHandler(gameTime.ElapsedGameTime.Milliseconds);
                }              
            }
            foreach (IPlayerScene ipS in GlobalController.PlayerSceneList)
            {
                if (ipS.GetIntanceType() == "Construction")
                {
                    if ((ipS.GetInstance() as Construction).Name == "cowhouse")
                    {
                        if ((ipS.GetInstance() as CowHouse).Cow.Hunger <= 30f)
                        {
                            (ipS.GetInstance() as CowHouse).Cow.Emotion = "hungry";
                            foreach (Soil soil in GlobalController.SoilList)
                            {
                                if (soil.Seed != null && soil.Seed.Id == "01_002" && soil.Seed.Status > 0 && soil.Seed.Status < 5)
                                {
                                    (ipS.GetInstance() as CowHouse).Cow.FindingPath = true;
                                    (ipS.GetInstance() as CowHouse).Cow.TargetPoint = new Vector2(soil.Position.X / Define.UnitOFpixel , soil.Position.Y / Define.UnitOFpixel- 2);
                                    (ipS.GetInstance() as CowHouse).Cow.EatingSoil = soil;
                                    (ipS.GetInstance() as CowHouse).Cow.EatOutSide = true;
                                    break;
                                }
                            }
                            if (!(ipS.GetInstance() as CowHouse).Cow.EatOutSide)
                            {
                                if ((ipS.GetInstance() as CowHouse).IsHaveFood && (ipS.GetInstance() as CowHouse).IsDoorOpen)
                                {
                                    (ipS.GetInstance() as CowHouse).Cow.FindingPath = true;
                                    (ipS.GetInstance() as CowHouse).Cow.TargetPoint = (ipS.GetInstance() as CowHouse).foodPos;
                                }
                            }
                        }
                    }
                }
            }
        }

        void OutDoorItemHandler()
        {
            foreach (OutDoorItem odi in GlobalController.OutdoorItemsList)
            {
                if (odi.InitAnim <= 24)
                {
                    odi.ShowInitAnim();
                }
            }
        }

        void TreeHandler(GameTime gameTime)
        {
            foreach (IPlayerScene ipS in GlobalController.PlayerSceneList)
            {
                if (ipS.GetIntanceType() == "PterocarpinTree")
                {
                    Tree tree = ipS.GetInstance() as Tree;
                    if (tree.IsShaking)
                    {
                        tree.Shake();
                    }
                    if (tree.IsDroping)
                    {
                        tree.Drop(gameTime.ElapsedGameTime.Milliseconds);
                    }
                    if (tree.GrowTime < 9000)
                    {
                        tree.GrowTime += gameTime.ElapsedGameTime.Milliseconds * GlobalController.TimeAccelerate / 1000f;
                    }

                }

            }
            if (GlobalController.LeafList.Count > 0)
            {

                    for (int i = 0; i < GlobalController.LeafList.Count; i++)
                    {
                        GlobalController.LeafList[i].Move();
                    }
                
            }
        }

        void TimeHandler(GameTime gameTime)
        {
            GlobalController.Time += (float)gameTime.ElapsedGameTime.TotalSeconds * GlobalController.TimeAccelerate;
            if (1441f >= GlobalController.Time && GlobalController.Time >= GlobalController.NightTime)
            {
                GlobalController.isNight = true;
                GlobalController.isDayTime = false;
            }
            else if (GlobalController.NightTime > GlobalController.Time && GlobalController.Time >= GlobalController.DayTime)
            {
                GlobalController.isNight = false;
                GlobalController.isDayTime = true;
            }
            else if (GlobalController.DayTime > GlobalController.Time && GlobalController.Time >= 0)
            {
                GlobalController.isNight = true;
                GlobalController.isDayTime = false;
            }
            else
            {
                throw new Exception("TimeHandlerError");
            }
        }

        void SleepHandler(GameTime gameTime)
        {
            if (GlobalController.SleepingStart)
            {
                sleepMask255_0 = true;
                GlobalController.SleepingStart = false;
                GlobalController.PlayerSleeping = true;
            }
            if (sleepMask255_0)
            {
                GlobalController.Mask.R -= (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.G -= (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.B -= (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                if ((int)GlobalController.Mask.R <= 12 && (int)GlobalController.Mask.G <= 12 && (int)GlobalController.Mask.B <= 12)
                {
                    GlobalController.Mask.R = 0;
                    GlobalController.Mask.G = 0;
                    GlobalController.Mask.B = 0;
                    sleepMask255_0 = false;
                    
                    GameController._instance.TimeAccelerate(10, GlobalController.SleepingTime);
                }
            }
            if (GlobalController.PlayerSleeping)
            {
                sleepingTotalTime += (float)gameTime.ElapsedGameTime.TotalSeconds * GlobalController.TimeAccelerate;
            }
            if (sleepingTotalTime >= GlobalController.SleepingTime)
            {
                GlobalController.PlayerSleeping = false;
                GlobalController.TimeAccelerate = 1.0f;
                GlobalController.SleepingTime = 0;
                sleepingTotalTime = -1;
                GlobalController.SleepingEnd = true;
            }
            if (GlobalController.SleepingEnd)
            {
                sleepMask0_255 = true;
                GlobalController.SleepingEnd = false;
            }
            if (sleepMask0_255)
            {
                GlobalController.Mask.R += (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.G += (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.B += (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                if ((int)GlobalController.Mask.R >= 248 && (int)GlobalController.Mask.G >= 248 && (int)GlobalController.Mask.B >= 248)
                {
                    GlobalController.Mask.R = 255;
                    GlobalController.Mask.G = 255;
                    GlobalController.Mask.B = 255;
                    sleepMask0_255 = false;
                }
            }
        }


        //Note: GlobalController.MenuOut = false; ------ must close the menu before start conversation
        void ConversationEventHandler()
        {
            if (GlobalController.ConversationOptionSelect.Count != 0)
            {
                GlobalController.MenuOut = false;
                switch (GlobalController.ConversationOptionSelect[0])
                {
                    case "bus":
                        if (GlobalController.ConversationOptionSelect.Count >= 2 && GlobalController.ConversationOptionSelect[1] == "1")
                        {
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_suburb_west",
                                func = 1
                            };
                            GlobalController.BusRequest = 0;
                        }
                        break;
                    case "bed":
                        if (GlobalController.ConversationOptionSelect.Count >= 2 && GlobalController.ConversationOptionSelect[1] == "1")
                        {
                            GlobalController.SleepingStart = true;
                            GlobalController.SleepingTime = 10 * 60;
                        }
                        break;
                    case "character_girl_Conductor":
                        if (GlobalController.ConversationOptionSelect.Count >= 3 && GlobalController.ConversationOptionSelect[2] == "2")
                        {
                            GlobalController.BusRequest = 1;
                        }
                        break;
                    case "character_shopper":
                        if (GlobalController.ConversationOptionSelect.Count >= 2 && GlobalController.ConversationOptionSelect[1] == "1")
                        {
                            GlobalController.Isshopping = true;
                            GlobalController.ShoppingPlace = "Village_seedshop";
                            GlobalController.buttonList.Add(new Button(ResourceController.UI_ordinary, "1", "Village_seedshop", 0.81f, new Vector2(Define.windowWidth + 15 * Define.UnitOFpixel - 5, Define.windowHeight - 10 * Define.UnitOFpixel)));
                            GlobalController.buttonList.Add(new Button(ResourceController.UI_ordinary, "2_1", "Village_seedshop", 0.81f, new Vector2(Define.windowWidth - 408 + 454 - 108, Define.windowHeight - 240 + 450 - 52)));
                        }
                        break;
                    default:
                        break;
                }
                GlobalController.ConversationOptionSelect.Clear();
            }
        }

        void CalenderHandler()
        {
            if (GlobalController.Time >= 1440d)
            {
                GlobalController.WeekDay++;
                if (GlobalController.WeekDay > 7)
                {
                    GlobalController.WeekDay = 1;
                }
                GlobalController.Date++;
                if (GlobalController.Date > 30)
                {
                    GlobalController.Date = 1;
                    GlobalController.Season++;
                    if (GlobalController.Season > 4)
                    {
                        GlobalController.Season = 1;
                        GlobalController.Year++;
                    }
                }
                GlobalController.Time = 0f;
                GlobalController.isShipment = false;
            }
        }

        void NpcHandler(GameTime gameTime)
        {
            for (int i = 0; i < GlobalController.Npcs.Length; i++)
            {
                GlobalController.Npcs[i].InstructHandle(gameTime.ElapsedGameTime.Milliseconds);
            }
        }

        void SceneHandler(GameTime gameTime)
        {
            if (!changeMask0_255 && !changeMask255_0)
            {
                if (GlobalController.SStatus.func != -1)
                {
                    changeMask255_0 = true;
                }
            }

            if (GlobalController.CStatus.func != -1)
            {
                changeMask0_255 = true;
                gc.ChangeScene(GlobalController.CStatus.cName, GlobalController.CStatus.func);
                GlobalController.CStatus = new GlobalController.Cs
                {
                    cName = "",
                    func = -1
                };
            }
            if (changeMask0_255)
            {
                GlobalController.Mask.R += (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.G += (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.B += (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                if ((int)GlobalController.Mask.R >= 248 && (int)GlobalController.Mask.G >= 248 && (int)GlobalController.Mask.B >= 248)
                {
                    GlobalController.Mask.R = 255;
                    GlobalController.Mask.G = 255;
                    GlobalController.Mask.B = 255;
                    changeMask0_255 = false;
                }
            }
            if (changeMask255_0)
            {
                GlobalController.Mask.R -= (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.G -= (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.B -= (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                if ((int)GlobalController.Mask.R <= 12 && (int)GlobalController.Mask.G <= 12 && (int)GlobalController.Mask.B <= 12)
                {
                    GlobalController.Mask.R = 0;
                    GlobalController.Mask.G = 0;
                    GlobalController.Mask.B = 0;
                    changeMask255_0 = false;
                    GlobalController.CStatus = GlobalController.SStatus;
                    GlobalController.SStatus = new GlobalController.Cs
                    {
                        cName = "",
                        func = -1
                    };
                }
            }


        }

        void SavingMaskHandler(GameTime gameTime)
        {
            if (GlobalController.SavingStart)
            {
                savingMask255_0 = true;
                GlobalController.SavingStart = false;
            }
            if (savingMask255_0)
            {
                GlobalController.Mask.R -= (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.G -= (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.B -= (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                if ((int)GlobalController.Mask.R <= 12 && (int)GlobalController.Mask.G <= 12 && (int)GlobalController.Mask.B <= 12)
                {
                    GlobalController.Mask.R = 0;
                    GlobalController.Mask.G = 0;
                    GlobalController.Mask.B = 0;
                    savingMask255_0 = false;
                    DataController.Save();
                    savingMask0_255 = true;
                }
            }
            if (savingMask0_255)
            {
                GlobalController.Mask.R += (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.G += (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                GlobalController.Mask.B += (byte)(255 * gameTime.ElapsedGameTime.Milliseconds / 500);
                if ((int)GlobalController.Mask.R >= 248 && (int)GlobalController.Mask.G >= 248 && (int)GlobalController.Mask.B >= 248)
                {
                    GlobalController.Mask.R = 255;
                    GlobalController.Mask.G = 255;
                    GlobalController.Mask.B = 255;
                    savingMask0_255 = false;
                }
            }
        }

        void OutdoorLightHandler()
        {
            GlobalController.OutdoorLight = gc.GetLightByTime(GlobalController.Time);
        }

        void WeatherHandler(GameTime gameTime)
        {
            if (GlobalController.Weather == "rainy")
            {
                rainFresh += gameTime.ElapsedGameTime.Milliseconds;
                if (rainFresh > 200)
                {
                    rainFresh = 0;
                    Random ran = new Random();
                    for (int i = 0; i < 20; i++)
                    {
                        GlobalController.WeatherHandleList.Add(new Rain(ResourceController.Weathers_spring_rain, new Vector2(ran.Next(0, Define.windowWidth * 2 + 250), ran.Next(-500, Define.windowHeight * 2))));
                    }
                }
                for (int i = 0; i < GlobalController.WeatherHandleList.Count; i++)
                {
                    if ((GlobalController.WeatherHandleList[i] as Rain).EndMoving)
                    {
                        if ((GlobalController.WeatherHandleList[i] as Rain).End)
                        {
                            GlobalController.WeatherHandleList.Remove(GlobalController.WeatherHandleList[i]);
                        }
                        else
                        {
                            (GlobalController.WeatherHandleList[i] as Rain).Anim(gameTime.ElapsedGameTime.Milliseconds);
                        }
                    }
                    else
                    {
                        (GlobalController.WeatherHandleList[i] as Rain).Move();
                    }
                }
            }
            else if (GlobalController.Weather == "windy")
            {
                Random ran = new Random();
                windFresh += gameTime.ElapsedGameTime.Milliseconds;
                windWaitTime += gameTime.ElapsedGameTime.Milliseconds;
                if (windWaitTimeStart == 0)
                {
                    windWaitTimeStart = ran.Next(4000, 7000);
                }
                if (windWaitTimeEnd == 0)
                {
                    windWaitTimeEnd = ran.Next(12000, 20000);
                }
                if (windWaitTime > windWaitTimeStart)
                {
                    if (windFresh > 250)
                    {
                        windFresh = 0;
                        
                        int count = ran.Next(10);
                        for (int i = 0; i < count; i++)
                        {
                            GlobalController.WeatherHandleList.Add(new Wind(ResourceController.Weathers_spring_wind, new Vector2(ran.Next(0, Define.windowWidth * 2 + 700), ran.Next(-100, Define.windowHeight * 2)), ran.Next(0, 10) / 10f));
                        }
                    }
                    if (windWaitTime > windWaitTimeEnd)
                    {
                        windWaitTime = 0;
                        windWaitTimeEnd = ran.Next(12000, 20000);
                        windWaitTimeStart = ran.Next(4000, 7000);
                    }
                }

                for (int i = 0; i < GlobalController.WeatherHandleList.Count; i++)
                {
                    if ((GlobalController.WeatherHandleList[i] as Wind).End)
                    {
                        GlobalController.WeatherHandleList.Remove(GlobalController.WeatherHandleList[i]);
                    }
                    else
                    {
                        (GlobalController.WeatherHandleList[i] as Wind).Anim(gameTime.ElapsedGameTime.Milliseconds);
                    }

                }
            }
        }

        void DetailHandler(GameTime gameTime)
        {
            if (GlobalController.ShowDetail)
            {
                GlobalController.ShowDetailTime -= gameTime.ElapsedGameTime.Milliseconds;
                if (GlobalController.ShowDetailTime <= 0)
                {
                    GlobalController.ShowDetailTime = 0;
                    GlobalController.ShowDetail = false;
                }
            }
        }

        void IfBaggageCloseHandler()
        {
            if (!GlobalController.BaggageOut)
            {
                GlobalController.BaggageBanner.IsNull = true;
                GlobalController.BaggageBanner.Item = null;
            }
        }

        void IfMouseLeaveHandler()
        {
            GlobalController.Mouse.Status = 0;
            GlobalController.Mouse.Color = Color.White;
        }

        void MouseHandler(GameTime gameTime)
        {
            GlobalController.Mouse.Position = new Vector2(GlobalController.MouseState.X, GlobalController.MouseState.Y);
            if (GlobalController.Mouse.Status != 0)
            {
                GlobalController.Mouse.AnimTime += gameTime.ElapsedGameTime.Milliseconds;
                if (GlobalController.Mouse.AnimTime > 100)
                {
                    GlobalController.Mouse.AnimFrame += 1;
                    GlobalController.Mouse.AnimTime = 0;
                    if (GlobalController.Mouse.AnimFrame >= 5)
                    {
                        GlobalController.Mouse.AnimFrame = 0;
                    }
                }
            }
        }

        void AlertHandler(GameTime gameTime)
        {
            if (GlobalController.ShowAlert)
            {
                GlobalController.AlertShowTime -= gameTime.ElapsedGameTime.Milliseconds;
                if (GlobalController.AlertShowTime > 0)
                {
                    if (GlobalController.AlertPos.Y < 10)
                    {
                        GlobalController.AlertPos = new Vector2(GlobalController.AlertPos.X, GlobalController.AlertPos.Y + 10);
                    }
                }

                else
                {
                    GlobalController.AlertPos = new Vector2(GlobalController.AlertPos.X, GlobalController.AlertPos.Y - 10);
                    if (GlobalController.AlertPos.Y <= -100)
                    {
                        GlobalController.AlertShowTime = 0;
                        GlobalController.ShowAlert = false;
                        GlobalController.AlertContent = "";
                        GlobalController.AlertPos = new Vector2(Define.windowWidth - 120, -100);
                    }

                }

            }
        }

        void ProgressHandler(GameTime gameTime)
        {
            if (GlobalController.ShowProgress)
            {
                GlobalController.ProgressHaveShowTime += gameTime.ElapsedGameTime.Milliseconds;
                
                if (GlobalController.ProgressHaveShowTime >= GlobalController.ProgressShowTime)
                {
                    GlobalController.TimeAccelerate = 1.0f;
                    GlobalController.ShowProgress = false;
                    GlobalController.ProgressLayerDepth = -0.02f;
                    GlobalController.ProgressHaveShowTime = 0;
                    GlobalController.ProgressContent = "";
                    GlobalController.ProgressShowTime = 0;
                    GlobalController.PrograssPercent = 0f;
                }
                else
                {
                    GlobalController.PrograssPercent = 1.0f * GlobalController.ProgressHaveShowTime / GlobalController.ProgressShowTime;
                }
            }
        }

        void FlowerHandler(GameTime gameTime)
        {
            foreach (Flower flower in GlobalController.FlowerList)
            {
                flower.NowAnimTime += gameTime.ElapsedGameTime.Milliseconds;
                if (flower.NowAnimTime > flower.AnimTime)
                {
                    flower.NowAnimTime = 0;
                    if (flower.CurrentFrame.X == 5)
                    {
                        Point p = new Point(6, 1);
                        flower.CurrentFrame = p;
                    }
                    else
                    {
                        Point p = new Point(5, 1);
                        flower.CurrentFrame = p;
                    }
                }
            }
        }

        void BusRequestHandler(GameTime gameTime)
        {
            if (GlobalController.BusRequest != 0)
            {
                switch (GlobalController.BusRequest)
                {
                    case 1:
                        if(GlobalController.bus == null)
                        {
                            GlobalController.bus = new CV_Library.GameObjects.Environments.Bus(GlobalController.Map, ResourceController.Scenes_bus_right, 1);
                        }
                        else
                        {
                            if (GlobalController.bus.WaitTime > 15000)
                            {
                                GlobalController.bus.Move();
                            }
                            else
                            {
                                GlobalController.bus.WaitTime += gameTime.ElapsedGameTime.Milliseconds * GlobalController.TimeAccelerate;
                            }
                        }
                        break;
                    case 2:
                        if (GlobalController.bus == null)
                        {
                            GlobalController.bus = new CV_Library.GameObjects.Environments.Bus(GlobalController.Map, ResourceController.Scenes_bus_right, 2);
                        }
                        else
                        {
                            if (GlobalController.bus.WaitTime > 1000)
                            {
                                GlobalController.bus.Move();
                            }
                            else
                            {
                                GlobalController.bus.WaitTime += gameTime.ElapsedGameTime.Milliseconds;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            if (GlobalController.bus != null && GlobalController.bus.OpeningDoor && GlobalController.bus.DoorHandleTime < 6)
            {
                GlobalController.bus.DoorHandleTime += 1;
                GlobalController.bus.DoorHandle();
            }
        }

        void CheckInventaryItemCount()
        {
            for (int i = 0; i < GlobalController.RapidRoomList.Count; i++)
            {
                if(GlobalController.RapidRoomList[i].Count == 0)
                {
                    GlobalController.RapidRoomList[i] = new Inventory(null, true, i + 1, 0);
                }
            }
        }

        void SoilConsumeWater(GameTime gameTime)
        {
            if (soilFresh >= 1000)
            {
                soilFresh = 0;
                for (int i = 0; i < GlobalController.SoilList.Count; i++)
                {
                    if (GlobalController.SoilList[i].WaterContent > 0)
                    {
                        if (GlobalController.SoilList[i].WaterContent > 1500)
                        {
                            GlobalController.SoilList[i].WaterContent = 1500;
                        }
                        GlobalController.SoilList[i].WaterContent -= GlobalController.SoilList[i].WaterConsume;
                        if (GlobalController.SoilList[i].Seed != Seeds.Null)
                        {
                            GlobalController.SoilList[i].WaterContent -= GlobalController.SoilList[i].Seed.WaterConsume;
                        }

                        if (GlobalController.SoilList[i].WaterContent <= 0)
                        {
                            GlobalController.SoilList[i].WaterContent = 0;
                        }
                    }
                    
                }
            }
            else
            {
                soilFresh += (int)(gameTime.ElapsedGameTime.Milliseconds * GlobalController.TimeAccelerate);
            }

        }

        void SeedGrow(GameTime gameTime)
        {
            for (int i = 0; i < GlobalController.SoilList.Count; i++)
            {
                if (GlobalController.SoilList[i].Seed != Seeds.Null && !GlobalController.SoilList[i].Seed.Is_moistDeath && !GlobalController.SoilList[i].Seed.Is_dryDeath)
                {
                    if (GlobalController.SoilList[i].Seed.Status == 5)
                    {
                        if (GlobalController.SoilList[i].Seed.Harvest_postpone_health > 0)
                        {
                            GlobalController.SoilList[i].Seed.Harvest_postpone_health -= gameTime.ElapsedGameTime.Milliseconds * GlobalController.TimeAccelerate / 1000f;
                            if (GlobalController.SoilList[i].Seed.Harvest_postpone_health < 0)
                            {
                                GlobalController.SoilList[i].Seed.Harvest_postpone_health = 0;
                            }
                        }
                        else
                        {
                            GlobalController.SoilList[i].Seed.Harvest_postpone_time += gameTime.ElapsedGameTime.Milliseconds * GlobalController.TimeAccelerate / 1000f;
                        }
                    }


                    if (GlobalController.SoilList[i].WaterContent == 0)
                    {
                        GlobalController.SoilList[i].Seed.GrowTime += gameTime.ElapsedGameTime.Milliseconds / 1000f * GlobalController.TimeAccelerate * GlobalController.SoilList[i].Seed.GrowSpeed * 0.2f;
                        GlobalController.SoilList[i].Seed.Moist_time = 0;
                        if (GlobalController.SoilList[i].Seed.Dry_health > 0)
                        {
                            GlobalController.SoilList[i].Seed.Dry_health -= gameTime.ElapsedGameTime.Milliseconds /1000f * GlobalController.TimeAccelerate;
                            if (GlobalController.SoilList[i].Seed.Dry_health < 0)
                            {
                                GlobalController.SoilList[i].Seed.Dry_health = 0;
                            }
                        }
                        else
                        {
                            GlobalController.SoilList[i].Seed.Dry_time += gameTime.ElapsedGameTime.Milliseconds /1000f * GlobalController.TimeAccelerate;
                        }
                    }
                    else if (0 < GlobalController.SoilList[i].WaterContent && GlobalController.SoilList[i].WaterContent <= 500)
                    {
                        GlobalController.SoilList[i].Seed.GrowTime += gameTime.ElapsedGameTime.Milliseconds /1000f * GlobalController.TimeAccelerate * GlobalController.SoilList[i].Seed.GrowSpeed * 0.8f;
                        GlobalController.SoilList[i].Seed.Moist_time = 0;
                        GlobalController.SoilList[i].Seed.Dry_time = 0;
                    }
                    else if (500 < GlobalController.SoilList[i].WaterContent && GlobalController.SoilList[i].WaterContent <= 1000)
                    {
                        GlobalController.SoilList[i].Seed.GrowTime += gameTime.ElapsedGameTime.Milliseconds /1000f * GlobalController.TimeAccelerate * GlobalController.SoilList[i].Seed.GrowSpeed * 1f;
                        GlobalController.SoilList[i].Seed.Moist_time = 0;
                        GlobalController.SoilList[i].Seed.Dry_time = 0;
                    }
                    else if (1000 < GlobalController.SoilList[i].WaterContent && GlobalController.SoilList[i].WaterContent <= 1500)
                    {
                        GlobalController.SoilList[i].Seed.GrowTime += gameTime.ElapsedGameTime.Milliseconds /1000f * GlobalController.TimeAccelerate * GlobalController.SoilList[i].Seed.GrowSpeed * 0.8f;
                        GlobalController.SoilList[i].Seed.Dry_time = 0;
                        if (GlobalController.SoilList[i].Seed.Moist_health > 0)
                        {
                            GlobalController.SoilList[i].Seed.Moist_health -= gameTime.ElapsedGameTime.Milliseconds /1000f * GlobalController.TimeAccelerate;
                            if (GlobalController.SoilList[i].Seed.Moist_health < 0)
                            {
                                GlobalController.SoilList[i].Seed.Moist_health = 0;
                            }
                        }
                        else
                        {
                            GlobalController.SoilList[i].Seed.Moist_time += gameTime.ElapsedGameTime.Milliseconds /1000f * GlobalController.TimeAccelerate;
                        }
                    }
                    else
                    {
                        GlobalController.SoilList[i].Seed.GrowTime += 0;
                    }
                }


                if (GlobalController.SoilList[i].IsShaking)
                {
                    GlobalController.SoilList[i].Shake();
                }
            }
        }

        void SeedDeathCheck(GameTime gameTime)
        {
            Random random = new Random();
            if (seedDeathCheckTime == 0)
            {
                seedDeathCheckTime = random.Next(15000, 60000);
            }
            if (seedDeathCheckDuringTime >= seedDeathCheckTime)
            {
                seedDeathCheckDuringTime = 0;
                seedDeathCheckTime = random.Next(15000, 60000);
                for (int i = 0; i < GlobalController.SoilList.Count; i++)
                {
                    if (GlobalController.SoilList[i].Seed != Seeds.Null)
                    {
                        float dryDeathCheck = (float)random.NextDouble();
                        float moistDeathCheck = (float)random.NextDouble();
                        float harvest_postponeDeathCheck = (float)random.NextDouble();
                        float diseaseDeathCheck = (float)random.NextDouble();
                        if (dryDeathCheck < GlobalController.SoilList[i].Seed.Dry_death_probability)
                        {
                            GlobalController.SoilList[i].Seed.Is_dryDeath = true;
                        }
                        if (moistDeathCheck < GlobalController.SoilList[i].Seed.Moist_death_probability)
                        {
                            GlobalController.SoilList[i].Seed.Is_moistDeath = true;
                        }
                        if (harvest_postponeDeathCheck < GlobalController.SoilList[i].Seed.Harvest_postpone_death_probability)
                        {
                            GlobalController.SoilList[i].Seed.Is_moistDeath = true;
                        }
                        if (diseaseDeathCheck < GlobalController.SoilList[i].Seed.Disease_death_probability)
                        {
                            GlobalController.SoilList[i].Seed.Is_dryDeath = true;
                        }
                    }
                }
            }
            else
            {
                seedDeathCheckDuringTime += gameTime.ElapsedGameTime.Milliseconds;
            }
        }

        void SaleBox_ShopsHandle()
        {
            if (!GlobalController.isShipment)
            {
                if (GlobalController.Time > 1080)
                {
                    int goldSum = 0;
                    for (int i = 0; i < GlobalController.PlayerSceneList.Count; i++)
                    {
                        if (GlobalController.PlayerSceneList[i].GetIntanceType() == "Chest" && (GlobalController.PlayerSceneList[i].GetInstance() as Chest).Type == 1)
                        {
                            Chest chest = GlobalController.PlayerSceneList[i].GetInstance() as Chest;
                            
                            for (int j = 0; j < chest.Inventries.Count; j++)
                            {
                                if (!chest.Inventries[j].IsNull)
                                {
                                    goldSum += chest.Inventries[j].Item.Price * chest.Inventries[j].Count;
                                    chest.Inventries[j].Clear();
                                }
                            }
                           
                        }
                    }


                    GameController._instance.ShowAlert("Gold+" + goldSum.ToString(), 2000);
                    GlobalController.Player.Gold += goldSum;
                    GlobalController.isShipment = true;
                }
            }

        }

        void UIHandler(GameTime gameTime)
        {
            Random ran = new Random();
            if (GlobalController.Player.Hunger == 0)
            {
                playerHungerShowTime += gameTime.ElapsedGameTime.Milliseconds;
                if (0 <= playerHungerShowTime && playerHungerShowTime < 1000)
                {
                    UserInterface.UserInfoHunger.Frame = new Point(11, 0);
                }
                else if (1000 <= playerHungerShowTime && playerHungerShowTime < 2000)
                {
                    UserInterface.UserInfoHunger.Frame = new Point(12, 0);
                }
                else
                {
                    playerHungerShowTime = 0;
                }
            }
            else if (0 < GlobalController.Player.Hunger && GlobalController.Player.Hunger <= 25)
            {
                UserInterface.UserInfoHunger.Frame = new Point(13, 0);
            }
            else if (25 < GlobalController.Player.Hunger && GlobalController.Player.Hunger <= 50)
            {
                UserInterface.UserInfoHunger.Frame = new Point(14, 0);
            }
            else if (50 < GlobalController.Player.Hunger && GlobalController.Player.Hunger <= 75)
            {
                UserInterface.UserInfoHunger.Frame = new Point(15, 0);
            }
            else if (75 < GlobalController.Player.Hunger && GlobalController.Player.Hunger <= 100)
            {
                UserInterface.UserInfoHunger.Frame = new Point(16, 0);
            }


            if (GlobalController.Player.IsDisease)
            {
                UserInterface.UserInfoHabitus.Frame = new Point(7, 1);
            }
            else
            {
                if (0 <= GlobalController.Player.Habitus && GlobalController.Player.Habitus < 40)
                {
                    UserInterface.UserInfoHabitus.Frame = new Point(9, 1);
                }
                else if (40 <= GlobalController.Player.Habitus && GlobalController.Player.Habitus < 80)
                {
                    UserInterface.UserInfoHabitus.Frame = new Point(11, 1);
                }
                else if (80 <= GlobalController.Player.Habitus && GlobalController.Player.Habitus < 120)
                {
                    UserInterface.UserInfoHabitus.Frame = new Point(13, 1);
                }
                else if (120 <= GlobalController.Player.Habitus && GlobalController.Player.Habitus < 160)
                {
                    UserInterface.UserInfoHabitus.Frame = new Point(15, 1);
                }
                else if (160 <= GlobalController.Player.Habitus && GlobalController.Player.Habitus <= 200)
                {
                    UserInterface.UserInfoHabitus.Frame = new Point(17, 1);
                }
            }

            UserInterface.UserInfoHPPercent = GlobalController.Player.Hp / GlobalController.Player.HpUpper;
            UserInterface.UserInfoHPColor = new Color(1, 1f * UserInterface.UserInfoHPPercent, 0);

            UserInterface.UserInfoEPercent = GlobalController.Player.Energy / GlobalController.Player.EnergyUpper;
            UserInterface.UserInfoEColor = new Color(0.212f + (1 - 0.212f) * (1 - UserInterface.UserInfoEPercent), 1f * UserInterface.UserInfoEPercent, 0.231f * UserInterface.UserInfoEPercent);

            switch (GlobalController.Player.Region)
            {
                case "town":
                    if (GlobalController.isDayTime)
                    {
                        UserInterface.CalendarConditionLocation.Frame = new Point(0, 15);
                    }
                    if (GlobalController.isNight)
                    {
                        UserInterface.CalendarConditionLocation.Frame = new Point(0, 19);
                    }
                    
                    break;
                case "village":
                    if (GlobalController.isDayTime)
                    {
                        UserInterface.CalendarConditionLocation.Frame = new Point(0, 23);
                    }
                    if (GlobalController.isNight)
                    {
                        UserInterface.CalendarConditionLocation.Frame = new Point(0, 27);
                    }
                    break;
                case "city":
                    if (GlobalController.isDayTime)
                    {
                        UserInterface.CalendarConditionLocation.Frame = new Point(0, 31);
                    }
                    if (GlobalController.isNight)
                    {
                        UserInterface.CalendarConditionLocation.Frame = new Point(0, 35);
                    }
                    break;
                default:
                    break;
            }

            if (GlobalController.isDayTime)
            {
                UserInterface.CalendarConditionSun.Pos = new Vector2((GlobalController.Time - GlobalController.DayTime) / (GlobalController.NightTime - GlobalController.DayTime) * 304f + Define.windowWidth * 2 - 14 * Define.UnitOFpixel + 24, Math.Abs((GlobalController.Time - GlobalController.DayTime) / (GlobalController.NightTime - GlobalController.DayTime) - 0.5f) * 10 + 10);
                
            }
            if (GlobalController.isNight)
            {
                UserInterface.CalendarConditionMoon.Pos = new Vector2(GlobalController.Time <= GlobalController.DayTime ? (GlobalController.Time + 1440f - GlobalController.NightTime) / (1440f - GlobalController.NightTime + GlobalController.DayTime) * 304f + Define.windowWidth * 2 - 14 * Define.UnitOFpixel + 24 : (GlobalController.Time - GlobalController.NightTime) / (1440f - GlobalController.NightTime + GlobalController.DayTime) * 304f + Define.windowWidth * 2 - 14 * Define.UnitOFpixel + 24, Math.Abs((GlobalController.Time <= GlobalController.DayTime ? (GlobalController.Time + 1440f - GlobalController.NightTime) / (1440f - GlobalController.NightTime + GlobalController.DayTime) : (GlobalController.Time - GlobalController.NightTime) / (1440f - GlobalController.NightTime + GlobalController.DayTime)) - 0.5f) * 10 + 10);
            }
            if (GlobalController.Weather == "sunny")
            {
                if (GlobalController.DayTime <= GlobalController.Time && GlobalController.Time <= GlobalController.NightTime - GlobalController.LightTurningTime)
                {
                    UserInterface.CalendarConditionSky.Color =  Color.SkyBlue;
                }
                else if (GlobalController.Time >= 0 && GlobalController.Time < GlobalController.DayTime - GlobalController.LightTurningTime)
                {
                    UserInterface.CalendarConditionSky.Color = Color.MidnightBlue;
                }
                else if (GlobalController.NightTime < GlobalController.Time && GlobalController.Time <= 1440f)
                {
                    UserInterface.CalendarConditionSky.Color = Color.MidnightBlue;
                }
                else if (GlobalController.DayTime - GlobalController.LightTurningTime <= GlobalController.Time && GlobalController.Time <= GlobalController.DayTime)
                {
                    UserInterface.CalendarConditionSky.Color = new Color(((110f * (GlobalController.Time - GlobalController.DayTime + GlobalController.LightTurningTime) / GlobalController.LightTurningTime) + 25) / 255f, ((25 + 181 * (GlobalController.Time - GlobalController.DayTime + GlobalController.LightTurningTime) / GlobalController.LightTurningTime)) / 255f, ((112 + 123 * (GlobalController.Time - GlobalController.DayTime + GlobalController.LightTurningTime) / GlobalController.LightTurningTime)) / 255f);
                }
                else if (GlobalController.NightTime - GlobalController.LightTurningTime < GlobalController.Time && GlobalController.Time <= GlobalController.NightTime)
                {
                    UserInterface.CalendarConditionSky.Color = new Color(((135 - 110 * (GlobalController.Time - GlobalController.NightTime + GlobalController.LightTurningTime) / GlobalController.LightTurningTime)) / 255f, ((206 - 181 * (GlobalController.Time - GlobalController.NightTime + GlobalController.LightTurningTime) / GlobalController.LightTurningTime)) / 255f, ((235 - 123 * (GlobalController.Time - GlobalController.NightTime + GlobalController.LightTurningTime) / GlobalController.LightTurningTime)) / 255f);
                }
                else
                {
                    UserInterface.CalendarConditionSky.Color = Color.SkyBlue;
                }
            }

            //if (GlobalController.PlayerDecoratMove)
            //{
            //    playerDecoratShowTime += gameTime.ElapsedGameTime.Milliseconds;
            //    if (playerDecoratShowTime > 800)
            //    {
            //        playerDecoratShowTime = 0;


            //        if (playerDecoratDirect)
            //        {
            //            UserInterface.UserInfoDecorat.Frame = new Point(UserInterface.UserInfoDecorat.Frame.X + 2, UserInterface.UserInfoDecorat.Frame.Y);
            //            if (UserInterface.UserInfoDecorat.Frame.X == 4)
            //            {
            //                playerDecoratDirect = false;
            //            }
            //        }
            //        else
            //        {
            //            UserInterface.UserInfoDecorat.Frame = new Point(UserInterface.UserInfoDecorat.Frame.X - 2, UserInterface.UserInfoDecorat.Frame.Y);
            //            if (UserInterface.UserInfoDecorat.Frame.X == 0)
            //            {
            //                playerDecoratDirect = true;
            //            }
            //        }

            //        if (UserInterface.UserInfoDecorat.Frame.X == 2)
            //        {
            //            playerDecoratMoveTimes += 1;
            //        }


            //        if (playerDecoratMoveTimes == playerDecoratMoveTimesRan)
            //        {
            //            GlobalController.PlayerDecoratMove = false;
            //        }
            //    }
            //}
            //else
            //{
            //    if (playerDecoratShowTimeRan == 0)
            //    {                    
            //        playerDecoratShowTimeRan = ran.Next(5000, 15000);
            //    }
            //    playerDecoratShowTime += gameTime.ElapsedGameTime.Milliseconds;
            //    if (playerDecoratShowTime > playerDecoratShowTimeRan)
            //    {
            //        GlobalController.PlayerDecoratMove = true;
            //        playerDecoratMoveTimesRan = ran.Next(1, 10);
            //        playerDecoratShowTime = 0;
            //        playerDecoratShowTimeRan = 0;
            //    }
            //}

            if (calendarExhibitionMoveTimeRan == 0 && calendarExhibitionAnim == false)
            {
                calendarExhibitionMoveTimeRan = ran.Next(2000, 15000);
            }
            else if(!calendarExhibitionAnim)
            {
                calendarExhibitionMoveTime += gameTime.ElapsedGameTime.Milliseconds;
                if (calendarExhibitionMoveTime > calendarExhibitionMoveTimeRan)
                {
                    calendarExhibitionMoveTimeRan = 0;
                    calendarExhibitionMoveTime = 0;
                    calendarExhibitionAnim = true;
                }
            }
            if (calendarExhibitionAnim)
            {
                calendarExhibitionMoveTimeRan = 300;
                calendarExhibitionMoveTime += gameTime.ElapsedGameTime.Milliseconds;
                if (calendarExhibitionMoveTime >= calendarExhibitionMoveTimeRan)
                {
                    if (UserInterface.CalendarExhibition.Frame.Y != 3)
                    {
                        UserInterface.CalendarExhibition.Frame = new Point(UserInterface.CalendarExhibition.Frame.X, UserInterface.CalendarExhibition.Frame.Y - 1);
                    }
                    else
                    {
                        UserInterface.CalendarExhibition.Frame = new Point(UserInterface.CalendarExhibition.Frame.X, UserInterface.CalendarExhibition.Frame.Y + 1);
                    }
                    calendarExhibitionTimes++;
                    calendarExhibitionMoveTime = 0;
                }
                if (calendarExhibitionTimes == 5)
                {
                    UserInterface.CalendarExhibition.Frame = new Point(12, 5);
                    calendarExhibitionTimes = 0;
                    calendarExhibitionMoveTimeRan = 0;
                    calendarExhibitionAnim = false;
                    calendarExhibitionMoveTime = 0;
                }
            }

            if (GlobalController.MenuOut)
            {
                if (UserInterface.MenuBackpackIcon.Pos.X < 0)
                {
                    UserInterface.MenuBackpackIcon.Pos = new Vector2(UserInterface.MenuBackpackIcon.Pos.X + 10, UserInterface.MenuBackpackIcon.Pos.Y);
                }
                else
                {
                    UserInterface.MenuBackpackIcon.Pos = new Vector2(0, UserInterface.MenuBackpackIcon.Pos.Y);
                }
                if (UserInterface.MenuContactIcon.Pos.X < 0)
                {
                    UserInterface.MenuContactIcon.Pos = new Vector2(UserInterface.MenuContactIcon.Pos.X + 7, UserInterface.MenuContactIcon.Pos.Y);
                }
                else
                {
                    UserInterface.MenuContactIcon.Pos = new Vector2(0, UserInterface.MenuContactIcon.Pos.Y);
                }
                if (UserInterface.MenuPersonalIcon.Pos.X < 0)
                {
                    UserInterface.MenuPersonalIcon.Pos = new Vector2(UserInterface.MenuPersonalIcon.Pos.X + 9, UserInterface.MenuPersonalIcon.Pos.Y);
                }
                else
                {
                    UserInterface.MenuPersonalIcon.Pos = new Vector2(0, UserInterface.MenuPersonalIcon.Pos.Y);
                }
                if (UserInterface.MenuSettingsIcon.Pos.X < 0)
                {
                    UserInterface.MenuSettingsIcon.Pos = new Vector2(UserInterface.MenuSettingsIcon.Pos.X + 6, UserInterface.MenuSettingsIcon.Pos.Y);
                }
                else
                {
                    UserInterface.MenuSettingsIcon.Pos = new Vector2(0, UserInterface.MenuSettingsIcon.Pos.Y);
                }
                if (UserInterface.MenuSkillIcon.Pos.X < 0)
                {
                    UserInterface.MenuSkillIcon.Pos = new Vector2(UserInterface.MenuSkillIcon.Pos.X + 8, UserInterface.MenuSkillIcon.Pos.Y);
                }
                else
                {
                    UserInterface.MenuSkillIcon.Pos = new Vector2(0, UserInterface.MenuSkillIcon.Pos.Y);
                }                
            }
            else
            {
                if (UserInterface.MenuBackpackIcon.Pos.X > -160)
                {
                    UserInterface.MenuBackpackIcon.Pos = new Vector2(UserInterface.MenuBackpackIcon.Pos.X - 6, UserInterface.MenuBackpackIcon.Pos.Y);
                }
                if (UserInterface.MenuContactIcon.Pos.X > -160)
                {
                    UserInterface.MenuContactIcon.Pos = new Vector2(UserInterface.MenuContactIcon.Pos.X - 6, UserInterface.MenuContactIcon.Pos.Y);
                }
                if (UserInterface.MenuPersonalIcon.Pos.X > -160)
                {
                    UserInterface.MenuPersonalIcon.Pos = new Vector2(UserInterface.MenuPersonalIcon.Pos.X - 6, UserInterface.MenuPersonalIcon.Pos.Y);
                }
                if (UserInterface.MenuSettingsIcon.Pos.X > -160)
                {
                    UserInterface.MenuSettingsIcon.Pos = new Vector2(UserInterface.MenuSettingsIcon.Pos.X - 6, UserInterface.MenuSettingsIcon.Pos.Y);
                }
                if (UserInterface.MenuSkillIcon.Pos.X > -160)
                {
                    UserInterface.MenuSkillIcon.Pos = new Vector2(UserInterface.MenuSkillIcon.Pos.X - 6, UserInterface.MenuSkillIcon.Pos.Y);
                }            
            }

            if (GlobalController.Isshopping)
            {
                shopRectMoveTime += gameTime.ElapsedGameTime.Milliseconds;
                foreach (Shops shop in GlobalController.Global_Shops)
                {
                    if (shop.Name == GlobalController.ShoppingPlace)
                    {
                        if (shopRectMoveTime > 1000)
                        {
                            if (shop.SaleRect.Y == 37 * Define.UnitOFpixel)
                            {
                                shop.SaleRect = new Rectangle(17 * Define.UnitOFpixel, 38 * Define.UnitOFpixel, 2 * Define.UnitOFpixel, Define.UnitOFpixel);
                            }
                            else
                            {
                                shop.SaleRect = new Rectangle(17 * Define.UnitOFpixel, 37 * Define.UnitOFpixel, 2 * Define.UnitOFpixel, Define.UnitOFpixel);
                            }
                            shopRectMoveTime = 0;
                        }

                        if (shop.Index > 0)
                        {
                            shopArrowUpMoveTime += gameTime.ElapsedGameTime.Milliseconds;
                            if (shopArrowUpMoveTime > 300)
                            {
                                if (shop.ArrowUp)
                                {
                                    shop.ArrowUp = false;
                                }
                                else
                                {
                                    shop.ArrowUp = true;
                                }
                                shopArrowUpMoveTime = 0;
                            }
                        }
                        else
                        {
                            shop.ArrowUp = true;
                            shopArrowUpMoveTime = 0;
                        }
                        if (shop.Index < shop.GoodsList.Count - 6)
                        {
                            shopArrowDownMoveTime += gameTime.ElapsedGameTime.Milliseconds;
                            if (shopArrowDownMoveTime > 300)
                            {
                                if (shop.ArrowDown)
                                {
                                    shop.ArrowDown = false;
                                }
                                else
                                {
                                    shop.ArrowDown = true;
                                }
                                shopArrowDownMoveTime = 0;
                            }
                        }
                        else
                        {
                            shop.ArrowDown = true;
                            shopArrowDownMoveTime = 0;
                        }
                    }
                }
            }
        }

        void WaterHandler(GameTime gameTime)
        {
            if (!GlobalController.WaterInit)
            {
                foreach (GlobalController.WaterProducer wp in GlobalController.WaterProduceList)
                {
                    for (int i = 0; i <= wp.position.X; i+= Define.UnitOFpixel)
                    {
                        GlobalController.WaterList.Add(new Water(ResourceController.Scenes_water, GlobalController.Map, new Vector2(i, wp.position.Y), wp.position.X - wp.distance, GlobalController.WaterCurrentFrameX));
                    }
                    for (int i = 0; i <= wp.position.X - 2 * Define.UnitOFpixel; i += Define.UnitOFpixel)
                    {
                        if (wp.position.X - wp.distance + Define.UnitOFpixel < i)
                        {
                            GlobalController.WaterJudge.Add(new Vector2(i, wp.position.Y));
                        }

                    }
                }
                
                GlobalController.WaterInit = true;
            }
            if (waterMove == 120)
            {
                foreach (GlobalController.WaterProducer item in GlobalController.WaterProduceList)
                {
                    GlobalController.WaterList.Add(new Water(ResourceController.Scenes_water, GlobalController.Map, item.position, item.position.X - item.distance,GlobalController.WaterCurrentFrameX));
                }
                waterMove = 0;

            }
            for (int i = 0; i < GlobalController.WaterList.Count; i++)
            {
                GlobalController.WaterList[i].Move();                
            }
            waterMove += 1;

            waterMoveTime += gameTime.ElapsedGameTime.Milliseconds;
            if (waterMoveTime > 500)
            {
                for (int i = 0; i < GlobalController.WaterList.Count; i++)
                {
                    GlobalController.WaterList[i].NatureMove();
                    
                }
                GlobalController.WaterCurrentFrameX += 1;
                if (GlobalController.WaterCurrentFrameX > 10)
                {
                    GlobalController.WaterCurrentFrameX = 0;
                }
                waterMoveTime = 0;
            }

            if (GlobalController.WCliffList.Count > 0)
            {
                waterCliffMoveTime += gameTime.ElapsedGameTime.Milliseconds;
                if (waterCliffMoveTime > 1500)
                {
                    for (int i = 0; i < GlobalController.WCliffList.Count; i++)
                    {
                        GlobalController.WCliffList[i].Move();
                    }
                    waterCliffMoveTime = 0;
                }
            }

            if (GlobalController.WaveList.Count > 0)
            {
                waveMoveTime += gameTime.ElapsedGameTime.Milliseconds;
                if (waveMoveTime > 300 && (waveMoveStatus == 1 || waveMoveStatus == 2 || waveMoveStatus == 4 || waveMoveStatus == 5 || waveMoveStatus == 6))
                {
                    for (int i = 0; i < GlobalController.WaveList.Count; i++)
                    {
                        GlobalController.WaveList[i].Move();
                    }
                    waveMoveTime = 0;
                    waveMoveStatus++;
                }
                if (waveMoveTime > 600 && waveMoveStatus == 3)
                {
                    for (int i = 0; i < GlobalController.WaveList.Count; i++)
                    {
                        GlobalController.WaveList[i].Move();
                    }
                    waveMoveTime = 0;
                    waveMoveStatus++;
                }
                if (waveMoveTime > 1200 && waveMoveStatus == 0)
                {
                    for (int i = 0; i < GlobalController.WaveList.Count; i++)
                    {
                        GlobalController.WaveList[i].Move();
                    }
                    waveMoveTime = 0;
                    waveMoveStatus++;
                }
                if (waveMoveStatus > 6)
                {
                    waveMoveStatus = 0;
                }
            }
        }

        void ChestHandler()
        {
            if (GlobalController.PlayerSceneList.Count > 0)
            {
                for (int i = 0; i < GlobalController.PlayerSceneList.Count; i++)
                {
                    if (GlobalController.PlayerSceneList[i].GetIntanceType() == "Chest" && (GlobalController.PlayerSceneList[i].GetInstance() as Chest).Type == 1)
                    {
                        (GlobalController.PlayerSceneList[i].GetInstance() as Chest).CheckPlayerNear();
                    }
                }
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            //drawTime++;

            GraphicsDevice.SetRenderTarget(pauseTarget);
            GraphicsDevice.Clear(GlobalController.PauseMask);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            gc.DrawPause(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(UITarget);
            GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(1, 1, 1));
            gc.DrawUI(spriteBatch);
            spriteBatch.End();
            
            GraphicsDevice.SetRenderTarget(lightsTarget);
            GraphicsDevice.Clear(GlobalController.OutdoorLight);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(2, 2, 1));
            gc.DrawLight(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(gameTarget);
            GraphicsDevice.Clear(Color.Black);           
            //spriteBatch.Draw(加载的图片,针对于屏幕来说开始画的位置，针对于图片来说剪裁的矩形位置和大小，图片渲染颜色，旋转，针对于图片的原点位置，缩放，渲染效果，层深度)
            spriteBatch.Begin(SpriteSortMode.FrontToBack,BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(2, 2, 1));
           
            //PlayerHandler.MoveFinalHandle();
            //CameraHandler();
            
            gc.Draw(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(mainTarget);
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            spriteBatch.Draw(gameTarget, Vector2.Zero, Color.White);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(weatherTarget);
            GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            gc.DrawWeather(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(maskTarget);
            //GraphicsDevice.Clear(Color.Transparent);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            
            lightingEffect.Parameters["lightMask"].SetValue(lightsTarget);
            lightingEffect.CurrentTechnique.Passes[0].Apply();          
            spriteBatch.Draw(mainTarget, Vector2.Zero, Color.White);
            spriteBatch.Draw(weatherTarget, Vector2.Zero, Color.White);

            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);


            
            spriteBatch.Draw(maskTarget, Vector2.Zero, GlobalController.Mask);            
            spriteBatch.Draw(UITarget, Vector2.Zero, Color.White);
            spriteBatch.Draw(pauseTarget, Vector2.Zero, Color.White);      
            spriteBatch.End();
            base.Draw(gameTime);
        }      
    }
}
