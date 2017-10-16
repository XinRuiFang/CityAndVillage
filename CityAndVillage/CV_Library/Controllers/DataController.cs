using CV_Library.Functions;
using CV_Library.GameObjects.Buildings;
using CV_Library.GameObjects.Characters;
using CV_Library.GameObjects.Characters.Animals;
using CV_Library.GameObjects.Items;
using CV_Library.GameObjects.Soils;
using CV_Library.Globals;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace CV_Library.Controllers
{
    public static class DataController
    {
        static string urlScene = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Content\\Data\\SceneData.xml";
        static string urlItems = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Content\\Data\\ItemsData.xml";
        static string urlConversation = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Content\\Data\\ConversationData.xml";

        static string[] urls = new string[] 
        { 
            "Content\\Data\\maps\\town_station.xml",
            "Content\\Data\\maps\\town_southriver.xml",
            "Content\\Data\\maps\\town_west.xml",
            "Content\\Data\\maps\\town_east.xml",
            "Content\\Data\\maps\\town_suburb.xml",
            "Content\\Data\\maps\\town_centre.xml",
            "Content\\Data\\maps\\village_thefarm.xml",
            "Content\\Data\\maps\\village_suburb_west.xml",
            "Content\\Data\\maps\\village_suburb_east.xml",
            "Content\\Data\\maps\\village_lake.xml",
            "Content\\Data\\maps\\village_centre.xml",
            "Content\\Data\\maps\\village_northfarm.xml",
            "Content\\Data\\maps\\village_ambi.xml",
            "Content\\Data\\maps\\city_entry.xml",
            "Content\\Data\\maps\\city_slumarea.xml",
            "Content\\Data\\maps\\city_busstation.xml",
            "Content\\Data\\maps\\city_market.xml",
            "Content\\Data\\maps\\city_station.xml",
            "Content\\Data\\maps\\city_centre.xml",
            "Content\\Data\\maps\\city_buildingsite.xml",
            "Content\\Data\\maps\\city_suburb.xml",
            "Content\\Data\\maps\\city_villa.xml",
            "Content\\Data\\maps\\city_park.xml",
            "Content\\Data\\maps\\city_school.xml",
            "Content\\Data\\maps\\InDoor\\village_farmhouse.xml",
            "Content\\Data\\maps\\InDoor\\village_centre_clinic.xml",
            "Content\\Data\\maps\\InDoor\\village_centre_hotel.xml",
            "Content\\Data\\maps\\InDoor\\village_centre_house1.xml",
            "Content\\Data\\maps\\InDoor\\village_centre_house2.xml",
            "Content\\Data\\maps\\InDoor\\village_centre_managehouse.xml",
            "Content\\Data\\maps\\InDoor\\village_centre_restaurant.xml",
            "Content\\Data\\maps\\InDoor\\village_centre_shop.xml",
            "Content\\Data\\maps\\InDoor\\village_centre_toolhouse.xml",
            "Content\\Data\\paths\\village_centre_restaurantPath.xml",
            "Content\\Data\\paths\\village_centrePath.xml"
        };

        static XmlDocument xmlFileScene;
        static XmlDocument xmlFileItems;
        static XmlDocument xmlFileConversation;

        static XmlDocument xmlFileDynamic;

        static List<XmlNode> XmlRoot;

        static XmlNode SceneRoot;
        static XmlNode ItemsRoot;
        static XmlNode ConversationRoot;
        public static void Initialize()
        {
            xmlFileScene = new XmlDocument();
            xmlFileItems = new XmlDocument();
            xmlFileConversation = new XmlDocument();

            xmlFileDynamic = new XmlDocument();

            XmlRoot = new List<XmlNode>();

            LoadConfig();

            LoadPlayerSaveFile();

            LoadNpcsFile();

            LoadNpcPositionFile();
        }
        static void LoadConfig()
        {
            try
            {
                xmlFileScene.Load(urlScene);
                xmlFileItems.Load(urlItems);
                xmlFileConversation.Load(urlConversation);

                for (int i = 0; i < urls.Length; i++)
                {
                    xmlFileDynamic.Load(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + urls[i]);
                    XmlRoot.Add(xmlFileDynamic.SelectSingleNode("CV"));            
                }

                SceneRoot = xmlFileScene.SelectSingleNode("global");
                ItemsRoot = xmlFileItems.SelectSingleNode("Items");
                ConversationRoot = xmlFileConversation.SelectSingleNode("Conversations");          
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static XmlNode GetSceneNode(string sceneName)
        {
            foreach (XmlNode node in SceneRoot)
            {
                if (node.Name == sceneName)
                {
                    return node;
                }
            }
            return null;

        }

        public static XmlNode GetItemsCategoryNode(string category)
        {
            foreach (XmlNode node in ItemsRoot)
            {
                if (node.Name == category)
                {
                    return node;
                }
            }
            return null;
        }

        public static XmlNode GetConversationNode()
        {
            return ConversationRoot;
        }

        public static XmlNode GetMapNode(string mapName)
        {
            switch (mapName)
            {
                case "town_station":
                    return XmlRoot[0];
                case "town_southriver":
                    return XmlRoot[1];
                case "town_west":
                    return XmlRoot[2];
                case "town_east":
                    return XmlRoot[3];
                case "town_suburb":
                    return XmlRoot[4];
                case "town_centre":
                    return XmlRoot[5];
                case "village_thefarm":
                    return XmlRoot[6];
                case "village_suburb_west":
                    return XmlRoot[7];
                case "village_suburb_east":
                    return XmlRoot[8];
                case "village_lake":
                    return XmlRoot[9];
                case "village_centre":
                    return XmlRoot[10];
                case "village_northfarm":
                    return XmlRoot[11];
                case "village_ambi":
                    return XmlRoot[12];
                case "city_entry":
                    return XmlRoot[13];
                case "city_slumarea":
                    return XmlRoot[14];
                case "city_busstation":
                    return XmlRoot[15];
                case "city_market":
                    return XmlRoot[16];
                case "city_station":
                    return XmlRoot[17];
                case "city_centre":
                    return XmlRoot[18];
                case "city_buildingsite":
                    return XmlRoot[19];
                case "city_suburb":
                    return XmlRoot[20];
                case "city_villa":
                    return XmlRoot[21];
                case "city_park":
                    return XmlRoot[22];
                case "city_school":
                    return XmlRoot[23];
                case "village_farmhouse":
                    return XmlRoot[24];
                case "village_centre_clinic":
                    return XmlRoot[25];
                case "village_centre_hotel":
                    return XmlRoot[26];
                case "village_centre_house1":
                    return XmlRoot[27];
                case "village_centre_house2":
                    return XmlRoot[28];
                case "village_centre_managehouse":
                    return XmlRoot[29];
                case "village_centre_restaurant":
                    return XmlRoot[30];
                case "village_centre_shop":
                    return XmlRoot[31];
                case "village_centre_toolhouse":
                    return XmlRoot[32];
                default:
                    return null;
            }
        }

        public static void Save()
        {
            SaveNpcsFile();
            SavePlayerFile();
        }

        static void LoadNpcsFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"./Content/Save/NpcsSave.xml");
            XmlNode root = xmlDoc.SelectSingleNode("CV");
            XmlNodeList rootList = root.ChildNodes;
            int i = 0;

            foreach (XmlNode rootNode in rootList)
            {
                NPC npc = new NPC(Map.Null, Vector2.Zero, rootNode.Name);
                XmlNodeList rootNpcList = rootNode.ChildNodes;
                foreach (XmlNode rootNpcNode in rootNpcList)
                {
                    switch (rootNpcNode.Name)
                    {
                        case "Map":
                            npc.Map = new Map(rootNpcNode.InnerText);
                            break;
                        case "Position":
                            npc.Position = new Vector2(float.Parse(rootNpcNode.InnerText.Split('|')[0]), float.Parse(rootNpcNode.InnerText.Split('|')[1]));
                            break;
                        case "Gender":
                            npc.Gender = bool.Parse(rootNpcNode.InnerText);
                            break;
                        case "HasLight":
                            npc.HasLight = bool.Parse(rootNpcNode.InnerText);
                            break;
                        case "Action":
                            npc.Action = rootNpcNode.InnerText;
                            break;
                        case "TargetPosition":
                            npc.TargetPosition = new NpcPosition(new Map(rootNpcNode.InnerText.Split('|')[0]), new Vector2(float.Parse(rootNpcNode.InnerText.Split('|')[1]), float.Parse(rootNpcNode.InnerText.Split('|')[2])), int.Parse(rootNpcNode.InnerText.Split('|')[3]));
                            break;
                        default:
                            break;
                    }
                }
                //npc.SetBox2D();
                GlobalController.Npcs[i] = npc;
                i++;
            }

        }

        static void LoadNpcPositionFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"./Content/Data/NpcPositionData.xml");
            XmlNode root = xmlDoc.SelectSingleNode("CV");
            XmlNodeList rootList = root.ChildNodes;
            foreach (XmlNode rootNode in rootList)
            {
                if (rootNode.Name == "PositionData")
                {
                    foreach (XmlNode node in rootNode)
                    {
                        string[] inner = node.InnerText.Split('|');
                        GlobalController.NpcPositionList.Add(new NpcPosition(new Map(inner[0]), new Vector2(int.Parse(inner[1]) * Define.UnitOFpixel, int.Parse(inner[2]) * Define.UnitOFpixel), int.Parse(inner[3])));
                    }
                }
                if (rootNode.Name == "TriggerData")
                {
                    foreach (XmlNode node in rootNode)
                    {
                        string[] inner = node.InnerText.Split('|');
                        GlobalController.NpcTriggerList.Add(new GlobalController.NpcTrigger
                        {
                            currentMap = new Map(inner[0]),
                            position = new Vector2(int.Parse(inner[1]), int.Parse(inner[2])),
                            targetMap = new Map(inner[3]),
                            targetPosition = new Vector2(int.Parse(inner[4]), int.Parse(inner[5]))
                        });
                    }
                }
            }
        }

        static void LoadNpcPathsFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"./Content/Data/paths/.xml");
            XmlNode root = xmlDoc.SelectSingleNode("CV");
            XmlNodeList rootList = root.ChildNodes;
        }

        static void SaveNpcsFile()
        {

        }

        static void SavePlayerFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
            xmlDoc.AppendChild(node);

            XmlNode root = xmlDoc.CreateElement("CV");
            xmlDoc.AppendChild(root);

            XmlNode nodeGlobal = xmlDoc.CreateNode(XmlNodeType.Element, "Global", null);
            CreateNode(xmlDoc, nodeGlobal, "Time", GlobalController.Time.ToString());
            CreateNode(xmlDoc, nodeGlobal, "Year", GlobalController.Year.ToString());
            CreateNode(xmlDoc, nodeGlobal, "Season", GlobalController.Season.ToString());
            CreateNode(xmlDoc, nodeGlobal, "Date", GlobalController.Date.ToString());
            CreateNode(xmlDoc, nodeGlobal, "WeekDay", GlobalController.WeekDay.ToString());
            CreateNode(xmlDoc, nodeGlobal, "Weather", GlobalController.Weather.ToString());
            CreateNode(xmlDoc, nodeGlobal, "IsShipment", GlobalController.isShipment.ToString());

            XmlNode nodePlayer = xmlDoc.CreateNode(XmlNodeType.Element, "Player", null);
            CreateNode(xmlDoc, nodePlayer, "Map", GlobalController.Map.Name.ToString());
            CreateNode(xmlDoc, nodePlayer, "Position", GlobalController.Player.GetSaveParameter());
            CreateNode(xmlDoc, nodePlayer, "Name", GlobalController.Player.Name.ToString());
            XmlNode nodeCharacter = xmlDoc.CreateNode(XmlNodeType.Element, "Character", null);
            for (int i = 0; i < 8; i++)
            {
                CreateNode(xmlDoc, nodeCharacter, "Element", GlobalController.Player.CTile[i].GetSave());
            }
            CreateNode(xmlDoc, nodePlayer, "Speed", GlobalController.Player.Speed.ToString());
            CreateNode(xmlDoc, nodePlayer, "Gender", GlobalController.Player.Gender.ToString());
            CreateNode(xmlDoc, nodePlayer, "HasLight", GlobalController.Player.HasLight.ToString());
            CreateNode(xmlDoc, nodePlayer, "HpUpper", GlobalController.Player.HpUpper.ToString());
            CreateNode(xmlDoc, nodePlayer, "Hp", GlobalController.Player.Hp.ToString());
            CreateNode(xmlDoc, nodePlayer, "EnergyUpper", GlobalController.Player.EnergyUpper.ToString());
            CreateNode(xmlDoc, nodePlayer, "Energy", GlobalController.Player.Energy.ToString());
            CreateNode(xmlDoc, nodePlayer, "Habitus", GlobalController.Player.Habitus.ToString());
            CreateNode(xmlDoc, nodePlayer, "Hunger", GlobalController.Player.Hunger.ToString());
            CreateNode(xmlDoc, nodePlayer, "Gold", GlobalController.Player.Gold.ToString());
            CreateNode(xmlDoc, nodePlayer, "IsDisease", GlobalController.Player.IsDisease.ToString());
            XmlNode nodePlayerInventory = xmlDoc.CreateNode(XmlNodeType.Element, "Inventory", null);
            CreateNode(xmlDoc, nodePlayerInventory, "InventoryCount", GlobalController.InventoryCount.ToString());
            for (int i = 0; i < GlobalController.InventoryCount; i++)
            {
                if (!GlobalController.InventoryList[i].IsNull)
                {
                    CreateNode(xmlDoc, nodePlayerInventory, "Inventory_" + i, GlobalController.InventoryList[i].Item.Id.ToString() + "_" + GlobalController.InventoryList[i].Count.ToString());
                }
            }
            XmlNode nodePlayerRapidRoom = xmlDoc.CreateNode(XmlNodeType.Element, "RapidRoom", null);
            CreateNode(xmlDoc, nodePlayerRapidRoom, "RapidRoomCount", GlobalController.RapidRoomCount.ToString());
            for (int i = 0; i < GlobalController.RapidRoomCount; i++)
            {
                if (!GlobalController.RapidRoomList[i].IsNull)
                {
                    CreateNode(xmlDoc, nodePlayerRapidRoom, "RapidRoom_" + i, GlobalController.RapidRoomList[i].Item.Id.ToString() + "_" + GlobalController.RapidRoomList[i].Count.ToString());
                }
            }
            XmlNode nodePlayerSelectingRapidRoom = xmlDoc.CreateNode(XmlNodeType.Element, "SelectingRapidRoom", null);
            if (!GlobalController.SelectingRapidRoomItem.IsNull)
            {
                CreateNode(xmlDoc, nodePlayerSelectingRapidRoom, "SelectingRapidRoom", GlobalController.SelectingRapidRoomItem.Item.Id.ToString() + "_" + GlobalController.SelectingRapidRoomItem.Count.ToString());
            }

            XmlNode nodeShop = xmlDoc.CreateNode(XmlNodeType.Element, "Shop", null);

            foreach (Shops shop in GlobalController.Global_Shops)
            {
                XmlNode nodeShops = xmlDoc.CreateNode(XmlNodeType.Element, shop.Name, null);
                for (int i = 0; i < shop.GoodsList.Count; i++)
                {
                    CreateNode(xmlDoc, nodeShops, "Goods_" + i, shop.GoodsList[i].Item.Id.ToString() + "|" + shop.GoodsList[i].Count.ToString() + "|" + shop.GoodsList[i].Discount.ToString());
                }
                nodeShop.AppendChild(nodeShops);
            }

            XmlNode nodePlayerScene = xmlDoc.CreateNode(XmlNodeType.Element, "PlayerScene", null);

            foreach (IPlayerScene playerScene in GlobalController.PlayerSceneList)
            {
                CreateNode(xmlDoc, nodePlayerScene, playerScene.GetIntanceType(), playerScene.GetSaveParameter());
            }
            foreach (IPlayerScene playerScene in GlobalController.SoilList)
            {
                CreateNode(xmlDoc, nodePlayerScene, playerScene.GetIntanceType(), playerScene.GetSaveParameter());
            }
            foreach (Animals animal in GlobalController.AnimalsList)
            {
                CreateNode(xmlDoc, nodePlayerScene, "Animals", animal.GetSaveParameter());
            }

            nodePlayer.AppendChild(nodeCharacter);
            nodePlayer.AppendChild(nodePlayerInventory);
            nodePlayer.AppendChild(nodePlayerRapidRoom);
            nodePlayer.AppendChild(nodePlayerSelectingRapidRoom);
            root.AppendChild(nodeGlobal);
            root.AppendChild(nodePlayer);
            root.AppendChild(nodeShop);
            root.AppendChild(nodePlayerScene);

            try
            {

                if (Directory.Exists("./Content/Save") == false)
                {
                    Directory.CreateDirectory("./Content/Save");
                }
                xmlDoc.Save("./Content/Save/PlayerSave.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void LoadPlayerSaveFile()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"./Content/Save/PlayerSave.xml");
            XmlNode root = xmlDoc.SelectSingleNode("CV");
            XmlNodeList rootList = root.ChildNodes;

            foreach (XmlNode rootNode in rootList)
            {
                switch (rootNode.Name)
                {
                    case "Global":
                        XmlNodeList rootGlobalList = rootNode.ChildNodes;
                        foreach (XmlNode rootGlobalNode in rootGlobalList)
                        {
                            switch (rootGlobalNode.Name)
                            {
                                case "Time":
                                    GlobalController.Time = float.Parse(rootGlobalNode.InnerText);
                                    break;
                                case "Year":
                                    GlobalController.Year = int.Parse(rootGlobalNode.InnerText);
                                    break;
                                case "Season":
                                    GlobalController.Season = int.Parse(rootGlobalNode.InnerText);
                                    break;
                                case "Date":
                                    GlobalController.Date = int.Parse(rootGlobalNode.InnerText);
                                    break;
                                case "WeekDay":
                                    GlobalController.WeekDay = int.Parse(rootGlobalNode.InnerText);
                                    break;
                                case "Weather":
                                    GlobalController.Weather = rootGlobalNode.InnerText;
                                    break;
                                case "IsShipment":
                                    GlobalController.isShipment = bool.Parse(rootGlobalNode.InnerText);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case "Player":
                        XmlNodeList rootPlayerList = rootNode.ChildNodes;
                        foreach (XmlNode rootPlayerNode in rootPlayerList)
                        {
                            switch (rootPlayerNode.Name)
                            {
                                case "Map":
                                    GlobalController.CStatus = new GlobalController.Cs
                                    {
                                        cName = rootPlayerNode.InnerText,
                                        func = 0
                                    };
                                    break;
                                case "Position":
                                    GlobalController.PlayerWithoutInit.Position = new Vector2(float.Parse(rootPlayerNode.InnerText.Split('|')[0]), float.Parse(rootPlayerNode.InnerText.Split('|')[1]));
                                    break;
                                case "Name":
                                    GlobalController.PlayerWithoutInit.Name = rootPlayerNode.InnerText;
                                    break;
                                case "Character":
                                    XmlNodeList elementList = rootPlayerNode.ChildNodes;
                                    CharacterTile[] cTile = new CharacterTile[8];
                                    for (int i = 0; i < 8; i++)
                                    {
                                        string context = elementList[i].InnerText;
                                        string[] inner = context.Split('|');
                                        cTile[i] = new CharacterTile(int.Parse(inner[0]), int.Parse(inner[1]), inner[2], inner[4], inner[6], inner[8], inner[10], inner[12], inner[14], inner[16], inner[18], inner[20], inner[22], inner[24], int.Parse(inner[3].Split(',')[0]), int.Parse(inner[3].Split(',')[1]), int.Parse(inner[5].Split(',')[0]), int.Parse(inner[5].Split(',')[1]), int.Parse(inner[7].Split(',')[0]), int.Parse(inner[7].Split(',')[1]), int.Parse(inner[9].Split(',')[0]), int.Parse(inner[9].Split(',')[1]), int.Parse(inner[11].Split(',')[0]), int.Parse(inner[11].Split(',')[1]), int.Parse(inner[13].Split(',')[0]), int.Parse(inner[13].Split(',')[1]), int.Parse(inner[15].Split(',')[0]), int.Parse(inner[15].Split(',')[1]), int.Parse(inner[17].Split(',')[0]), int.Parse(inner[17].Split(',')[1]), int.Parse(inner[19].Split(',')[0]), int.Parse(inner[19].Split(',')[1]), int.Parse(inner[21].Split(',')[0]), int.Parse(inner[21].Split(',')[1]), int.Parse(inner[23].Split(',')[0]), int.Parse(inner[23].Split(',')[1]), int.Parse(inner[25].Split(',')[0]), int.Parse(inner[25].Split(',')[1]));
                                    }
                                    GlobalController.PlayerWithoutInit.CTile = cTile;
                                    break;
                                case "Speed":
                                    GlobalController.PlayerWithoutInit.Speed = float.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "Gender":
                                    GlobalController.PlayerWithoutInit.Gender = bool.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "HasLight":
                                    GlobalController.PlayerWithoutInit.HasLight = bool.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "HpUpper":
                                    GlobalController.PlayerWithoutInit.HpUpper = float.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "Hp":
                                    GlobalController.PlayerWithoutInit.Hp = float.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "EnergyUpper":
                                    GlobalController.PlayerWithoutInit.EnergyUpper = float.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "Energy":
                                    GlobalController.PlayerWithoutInit.Energy = float.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "Habitus":
                                    GlobalController.PlayerWithoutInit.Habitus = float.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "Hunger":
                                    GlobalController.PlayerWithoutInit.Hunger = float.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "Gold":
                                    GlobalController.PlayerWithoutInit.Gold = int.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "IsDisease":
                                    GlobalController.PlayerWithoutInit.IsDisease = bool.Parse(rootPlayerNode.InnerText);
                                    break;
                                case "Inventory":
                                    XmlNodeList inventoryList = rootPlayerNode.ChildNodes;
                                    for (int i = 0; i < inventoryList.Count; i++)
                                    {
                                        if (i == 0)
                                        {
                                            GlobalController.InventoryCount = int.Parse(inventoryList[i].InnerText);
                                            for (int j = 0; j < GlobalController.InventoryCount; j++)
                                            {
                                                GlobalController.InventoryList.Add(new Inventory(null, true, j + 1, 0));
                                            }
                                        }
                                        else
                                        {
                                            GlobalController.InventoryList[i - 1].AddItem(Item.ItemCreateFactory(inventoryList[i].InnerText.Substring(0, 6)), int.Parse(inventoryList[i].InnerText.Substring(7, inventoryList[i].InnerText.Length - 7)));
                                        }
                                    }
                                    break;
                                case "RapidRoom":
                                    XmlNodeList RapidRoomList = rootPlayerNode.ChildNodes;
                                    for (int i = 0; i < RapidRoomList.Count; i++)
                                    {
                                        if (i == 0)
                                        {
                                            GlobalController.RapidRoomCount = int.Parse(RapidRoomList[i].InnerText);
                                            for (int j = 0; j < GlobalController.RapidRoomCount; j++)
                                            {
                                                GlobalController.RapidRoomList.Add(new Inventory(null, true, j + 1, 0));
                                            }
                                        }
                                        else
                                        {
                                            GlobalController.RapidRoomList[i - 1].AddItem(Item.ItemCreateFactory(RapidRoomList[i].InnerText.Substring(0, 6)), int.Parse(RapidRoomList[i].InnerText.Substring(7, RapidRoomList[i].InnerText.Length - 7)));
                                        }
                                    }
                                    break;
                                case "SelectingRapidRoom":
                                    XmlNodeList SelectingRapidRoom = rootPlayerNode.ChildNodes;
                                    GlobalController.SelectingRapidRoomItem = new Inventory(null, true, 0, 0);
                                    if (SelectingRapidRoom.Count > 0)
                                    {
                                        GlobalController.SelectingRapidRoomItem.AddItem(Item.ItemCreateFactory(SelectingRapidRoom[0].InnerText.Substring(0, 6)), int.Parse(SelectingRapidRoom[0].InnerText.Substring(7, SelectingRapidRoom[0].InnerText.Length - 7)));
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case "Shop":
                        XmlNodeList rootShopList = rootNode.ChildNodes;

                        foreach (XmlNode node in rootShopList)
                        {
                            Shops shop = new Shops(ResourceController.UI_ordinary, ResourceController.UI_logos, Map.Null, node.Name);
                            foreach (XmlNode item in node)
                            {
                                string[] inner = item.InnerText.Split('|');
                                shop.AddGoods(new Goods(Item.ItemCreateFactory(inner[0]), int.Parse(inner[1]), float.Parse(inner[2])));
                            }
                            GlobalController.Global_Shops.Add(shop);
                        }
                        break;
                    case "PlayerScene":
                        XmlNodeList rootPlayerSceneList = rootNode.ChildNodes;
                        foreach (XmlNode rootPlayerSceneNode in rootPlayerSceneList)
                        {
                            switch (rootPlayerSceneNode.Name)
                            {
                                case "Chest":
                                    string[] contextChest = rootPlayerSceneNode.InnerText.Split('|');
                                    Chest chest = new Chest(new Map(contextChest[0]), new Vector2(int.Parse(contextChest[1]), int.Parse(contextChest[2])), ResourceController.Scenes_chest, int.Parse(contextChest[3]));
                                    for (int i = 4; i < contextChest.Length; i++)
                                    {
                                        string[] contextChestItem = contextChest[i].Split('^');
                                        chest.Inventries[int.Parse(contextChestItem[2])].AddItem(Item.ItemCreateFactory(contextChestItem[0]), int.Parse(contextChestItem[1]));
                                    }
                                    GlobalController.PlayerSceneList.Add(chest);
                                    break;
                                case "Soil":
                                    string[] contextSoil = rootPlayerSceneNode.InnerText.Split('|');
                                    if (contextSoil[4] == "True")
                                    {
                                        Soil soil = new Soil(ResourceController.Scenes_soil, new Map(contextSoil[0]), new Vector2(int.Parse(contextSoil[1]), int.Parse(contextSoil[2])), float.Parse(contextSoil[3]), Item.ItemCreateFactory(contextSoil[5]) as Seeds, true);
                                        soil.Seed.LoadingSeeds(float.Parse(contextSoil[6]), bool.Parse(contextSoil[7]), bool.Parse(contextSoil[8]), bool.Parse(contextSoil[9]), float.Parse(contextSoil[10]), float.Parse(contextSoil[11]), float.Parse(contextSoil[12]), float.Parse(contextSoil[13]), float.Parse(contextSoil[14]), float.Parse(contextSoil[15]), float.Parse(contextSoil[16]), float.Parse(contextSoil[17]));
                                        GlobalController.SoilList.Add(soil);

                                    }
                                    else
                                    {
                                        Soil soil = new Soil(ResourceController.Scenes_soil, new Map(contextSoil[0]), new Vector2(int.Parse(contextSoil[1]), int.Parse(contextSoil[2])), float.Parse(contextSoil[3]), Seeds.Null, false);
                                        GlobalController.SoilList.Add(soil);
                                    }
                                    break;
                                case "PterocarpinTree":
                                    string[] contextPTree = rootPlayerSceneNode.InnerText.Split('|');
                                    PterocarpinTree ptree = new PterocarpinTree(new Map(contextPTree[0]), new Vector2(int.Parse(contextPTree
                                        [1]), int.Parse(contextPTree[2])), ResourceController.Decorats_spring_tree, ResourceController.Decorats_tree_shadow, true);
                                    ptree.GrowTime = float.Parse(contextPTree[3]);
                                    GlobalController.PlayerSceneList.Add(ptree);
                                    break;
                                case "Furniture":
                                    string[] contextFurniture = rootPlayerSceneNode.InnerText.Split('|');
                                    GlobalController.PlayerSceneList.Add(Furniture.CreateFurnitureFactory(new Map(contextFurniture[0]), new Vector2(int.Parse(contextFurniture
                                        [1]), int.Parse(contextFurniture[2])), contextFurniture[3]));
                                    break;
                                case "Construction":
                                    string[] contextConstruction = rootPlayerSceneNode.InnerText.Split('|');
                                    if (contextConstruction[3] == "cowhouse")
                                    {
                                        CowHouse cowHouse = Construction.CreateConstructionFactory(new Map(contextConstruction[0]), new Vector2(int.Parse(contextConstruction
                                           [1]), int.Parse(contextConstruction[2])), contextConstruction[3]) as CowHouse;
                                        cowHouse.Init(bool.Parse(contextConstruction[4]), int.Parse(contextConstruction[5]), bool.Parse(contextConstruction[6]));
                                        GlobalController.PlayerSceneList.Add(cowHouse);
                                    }

                                    break;
                                case "Animals":
                                    string[] contextAnimal = rootPlayerSceneNode.InnerText.Split('|');
                                    if (contextAnimal[3] == "cow")
                                    {
                                        Cows cow = Animals.CreateAnimalsFactory(new Map(contextAnimal[0]), new Vector2(int.Parse(contextAnimal
                                           [1]), int.Parse(contextAnimal[2])), contextAnimal[3], int.Parse(contextAnimal[5]), float.Parse(contextAnimal[6])) as Cows;
                                        cow.Init(float.Parse(contextAnimal[4]));
                                        GlobalController.AnimalsList.Add(cow);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            foreach (IPlayerScene ipS in GlobalController.PlayerSceneList)
            {
                if (ipS.GetIntanceType() == "Construction")
                {
                    if ((ipS.GetInstance() as Construction).Name == "cowhouse")
                    {
                        CowHouse ch = ipS.GetInstance() as CowHouse;
                        GlobalController.AnimalsList.ForEach(u =>
                        {
                            if (u.GetIntanceType() == "Cows")
                            {
                                if ((u.GetInstance() as Cows).Id == ch.Id)
                                {
                                    ch.InitAnimal((u.GetInstance() as Cows));
                                }
                            }
                        });
                    }
                }
            }
            //GlobalController.OutdoorItemsList.Add(new OutDoorItem(new Map("village_suburb_west"),new Vector2(2400,1700), new Item("1", new Map("village_suburb_west"), new Vector2(1800, 1300), "water1", Content.Load<Texture2D>("Items/items"), 100)));
        }

        static void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }  
    }
}
