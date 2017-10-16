//using Box2D.XNA;
using CV_Library.Functions;
using CV_Library.GameObjects.Buildings;
using CV_Library.GameObjects.Characters;
using CV_Library.GameObjects.Characters.Animals;
using CV_Library.GameObjects.Decorats;
using CV_Library.GameObjects.Environments;
using CV_Library.GameObjects.Items;
using CV_Library.GameObjects.Soils;
using CV_Library.GameObjects.Trees;
using CV_Library.Globals;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV_Library
{
    public class GlobalController
    {
        public struct Cs
	    {
		    public string cName;
            public int func;
	    }
        public struct WaterProducer
        {
            public Vector2 position;
            public float distance;
        }
        public struct NpcTrigger
        {
            public Map currentMap;
            public Vector2 position;
            public Map targetMap;
            public Vector2 targetPosition;
        }

        public static GamingMethods _Cv_func = new GamingMethods();

        //public static World _World;

        public static Player Player;

        public static Player PlayerWithoutInit;

        public static bool PlayerCanMove;

        public static bool PlayerInDoor;

        public static bool SleepingStart;

        public static bool SleepingEnd;

        public static bool PlayerSleeping;

        public static int SleepingTime;

        public static bool PlayerIsFishing;

        public static double MoveWaitTime;

        public static NPC[] Npcs = new NPC[3];

        public static Map Map;

        public static List<Tile> MapTileList = new List<Tile>();

        public static List<NpcPosition> NpcPositionList = new List<NpcPosition>();

        public static List<NpcTrigger> NpcTriggerList = new List<NpcTrigger>();

        public static List<WaterProducer> WaterProduceList = new List<WaterProducer>();

        public static List<Water> WaterList = new List<Water>();

        public static int WaterCurrentFrameX = 0;

        public static bool WaterInit = false;

        public static Camera Camera;

        public static float Time;

        public static float NightTime = 1260f;

        public static float DayTime = 420f;

        public static float LightTurningTime = 120f;

        public static bool isNight;

        public static bool isDayTime;

        public static float TimeAccelerate;

        public static int Season;

        public static int Date;

        public static int WeekDay;

        public static string Weather;

        public static int Year;

        public static List<IPlayerScene> PlayerSceneList = new List<IPlayerScene>();

        public static List<Point> NpcSceneCollide = new List<Point>();

        public static List<Weather> WeatherHandleList = new List<Weather>();

        public static Task TaskObj;

        public static Color OutdoorLight;

        public static List<Tree> TreeList = new List<Tree>();

        public static List<Leaf> LeafList = new List<Leaf>();

        public static List<Barrier> BarrierList = new List<Barrier>();

        public static List<Bush> BushList = new List<Bush>();

        public static List<Trigger> TriggerList = new List<Trigger>();

        public static List<Trigger> DoorTriggerList = new List<Trigger>();
            
        public static List<OutDoorItem> OutdoorItemsList = new List<OutDoorItem>();

        public static List<Flower> FlowerList = new List<Flower>();

        public static List<Decorats> DecoratList = new List<Decorats>();

        public static List<Building> BuildingList = new List<Building>();

        public static List<Soil> SoilList = new List<Soil>();

        public static List<WCliff> WCliffList = new List<WCliff>();

        public static List<Wave> WaveList = new List<Wave>();

        public static List<Sand> SandList = new List<Sand>();

        public static List<Animals> AnimalsList = new List<Animals>();

        public static Cs CStatus = new Cs
        {
            cName = "",
            func = -1
        };
        public static Cs SStatus = new Cs
        {
            cName = "",
            func = -1
        };

        public static bool SavingStart;

        public static Color Mask;

        public static Color PauseMask;

        public static bool isPause;

        public static Functions.Mouse Mouse;

        public static MouseState MouseState;

        public static MouseState LastMouseState;

        public static Inventory InventWithMouse;

        public static List<Button> buttonList = new List<Button>();

        public static bool MenuOut;

        public static bool BaggageOut;

        public static bool isShipment;

        public static bool SaleBoxOut;

        public static Chest OpengingChest;

        public static bool Isshopping;

        public static string ShoppingPlace;

        public static Inventory BaggageBanner;

        public static int InventoryCount;

        public static List<Inventory> InventoryList = new List<Inventory>();

        public static int RapidRoomCount;

        public static List<Inventory> RapidRoomList = new List<Inventory>();

        public static Inventory SelectingRapidRoomItem;

        public static string DetailBanner;

        public static bool ShowDetail;

        public static int ShowDetailTime;

        public static bool ShowProgress;

        public static string ProgressContent;

        public static int ProgressShowTime;

        public static int ProgressHaveShowTime;

        public static float ProgressLayerDepth;

        public static float PrograssPercent;

        public static bool isTalking;

        public static bool SelectDialogue; 

        public static List<String> ConversationContent = new List<string>();

        public static List<string> SelectDialogueContent = new List<string>();

        public static string Conversation;

        public static int ConversationIndex = -1;

        public static List<string> ConversationOptionSelect = new List<string>();

        public static string ConversationName;

        public static bool ShowAlert;

        public static string AlertContent;

        public static int AlertShowTime;

        public static Vector2 AlertPos;

        public static int BusRequest = 0;

        public static Bus bus = null;

        public static List<Shops> Global_Shops = new List<Shops>();

        public static List<Goods> Player_ShoppingCart = new List<Goods>();

        public static bool PlayerDecoratMove;

        public static FishingSystem FishingSys;

        public static List<Vector2> WaterJudge = new List<Vector2>();

        public static Trigger CollidingTrigger = null;

    }
}
