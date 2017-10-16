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
using CV_Library.GameObjects.Items;
using CV_Library.GameObjects.Soils;
using CV_Library.GameObjects.Buildings;
using CV_Library.Interfaces;
using CV_Library.GameObjects.Characters;
using CV_Library.Globals;
using CV_Library.Controllers;
using CV_Library.Functions;


namespace CV_xLibrary
{
    public class MouseHandler : Microsoft.Xna.Framework.GameComponent
    {
        static MouseState mouseState;
        static MouseState lastmouseState;
        
        public static MouseState MouseState
        {
            get { return mouseState; }
        }
        public static MouseState LastmouseState
        {
            get { return lastmouseState; }
        }
        public MouseHandler(Game game)
            : base(game)
        {
            mouseState = GlobalController.MouseState;
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public override void Update(GameTime gameTime)
        {
            lastmouseState = mouseState;
            mouseState = GlobalController.MouseState;
            if (!GlobalController.isPause)
            {
                if (!GlobalController.isTalking)
                {
                    CheckClick();
                    ShowDetail();
                    ShowRapidRoomItemsDetail();
                    ShowDetailInBaggage();
                    ShowNpcHover();
                    CheckUsingTools();
                    ShowIndoor();
                    ShowMenuItemsHover();
                    ShowBtnHover();
                }
                else
                {
                    CheckSelectDialogue();
                    CheckConversation();

                }
            }
            base.Update(gameTime);
        }

        public static float MousePlayerDistance()
        {
            Vector2 mousePos = Camera.HandleScreenPostoLocal(new Vector2(GlobalController.MouseState.X, GlobalController.MouseState.Y), GlobalController.Camera);
            Vector2 playerPos = GlobalController.Player.MidPos;

            return (float)Math.Sqrt(Math.Pow(Math.Abs(mousePos.X - playerPos.X), 2) + Math.Pow(Math.Abs(mousePos.Y - playerPos.Y), 2));
        }

        public static float GameObjectPlayerDistance(GameObject go)
        {
            Vector2 goPos = go.MidPos;
            Vector2 playerPos = GlobalController.Player.MidPos;

            return (float)Math.Sqrt(Math.Pow(Math.Abs(goPos.X - playerPos.X), 2) + Math.Pow(Math.Abs(goPos.Y - playerPos.Y), 2));
        }

        public static float RectanglePlayerDistance(Rectangle rect)
        {
            Vector2 rectPos = new Vector2(rect.X + rect.Width / 2, rect.Y + rect.Height / 2 + 7);
            Vector2 playerPos = GlobalController.Player.MidPos;

            return (float)Math.Sqrt(Math.Pow(Math.Abs(rectPos.X - playerPos.X), 2) + Math.Pow(Math.Abs(rectPos.Y - playerPos.Y), 2));
        }

        /// <summary>
        /// return player direct
        /// </summary>
        /// <param name="go"></param>
        /// <returns>1-forward 2-left 3-right 4-back</returns>
        public static int PlayerLookAtGameObject(GameObject go)
        {
            Vector2 goPos = go.MidPos;
            Vector2 playerPos = GlobalController.Player.MidPos;

            if (goPos.X > playerPos.X)
            {
                if (goPos.Y > playerPos.Y)
                {
                    if (Math.Abs(goPos.X - playerPos.X) > Math.Abs(goPos.Y - playerPos.Y))
                    {
                        return 4;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    if (Math.Abs(goPos.X - playerPos.X) > Math.Abs(goPos.Y - playerPos.Y))
                    {
                        return 4;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            else
            {
                if (goPos.Y > playerPos.Y)
                {
                    if (Math.Abs(goPos.X - playerPos.X) > Math.Abs(goPos.Y - playerPos.Y))
                    {
                        return 3;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    if (Math.Abs(goPos.X - playerPos.X) > Math.Abs(goPos.Y - playerPos.Y))
                    {
                        return 3;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }

        public static int PlayerLookAtMouse()
        {
            Vector2 mousePos = Camera.HandleScreenPostoLocal(new Vector2(GlobalController.MouseState.X, GlobalController.MouseState.Y), GlobalController.Camera);
            Vector2 playerPos = GlobalController.Player.MidPos;

            if (mousePos.X > playerPos.X)
            {
                if (mousePos.Y > playerPos.Y)
                {
                    if (Math.Abs(mousePos.X - playerPos.X) > Math.Abs(mousePos.Y - playerPos.Y))
                    {
                        return 4;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    if (Math.Abs(mousePos.X - playerPos.X) > Math.Abs(mousePos.Y - playerPos.Y))
                    {
                        return 4;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            else
            {
                if (mousePos.Y > playerPos.Y)
                {
                    if (Math.Abs(mousePos.X - playerPos.X) > Math.Abs(mousePos.Y - playerPos.Y))
                    {
                        return 3;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    if (Math.Abs(mousePos.X - playerPos.X) > Math.Abs(mousePos.Y - playerPos.Y))
                    {
                        return 3;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
        }

        void CheckClick()
        {
            if (mouseState.LeftButton == ButtonState.Pressed && lastmouseState.LeftButton == ButtonState.Released)
            {
                Vector2 clickpos = new Vector2(mouseState.X, mouseState.Y);

                CheckMenuItemsClick(clickpos);

                CheckBaggageItemsClick(clickpos);

                CheckOutdoorItemsClick(clickpos);

                CheckRapidRoomItemsClick(clickpos);

                CheckNpcClick(clickpos);

                UsingToolsClick(clickpos);

                ShoppingClick(clickpos);

                IndoorClick(clickpos);

                PlayerSceneClick(clickpos);

                SaleBoxClick(clickpos);

                CheckBtnClick(clickpos);

                FishingClick(clickpos);
            }
            if (mouseState.RightButton == ButtonState.Pressed && lastmouseState.RightButton == ButtonState.Released)
            {
                Vector2 clickpos = new Vector2(mouseState.X, mouseState.Y);
                CheckRapidRoomItemsClickRight(clickpos);
            }
        }
      
        void CheckBtnClick(Vector2 clickpos)
        {
            if (GlobalController.buttonList.Count > 0)
            {
                for (int i = 0; i < GlobalController.buttonList.Count; i++)
                {
                    if (GlobalController.buttonList[i].CheckPos(clickpos))
                    {
                        switch (GlobalController.buttonList[i].BingFunc)
                        {
                            case "BaggageOut":
                                switch (GlobalController.buttonList[i].Type.Substring(0, 1))
                                {
                                    case "1":
                                        if (GlobalController.buttonList[i].Type == "1")
                                        {
                                            GlobalController.BaggageOut = false;
                                            GlobalController.buttonList.Remove(GlobalController.buttonList[i]);
                                        }
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            case "Village_seedshop":
                                switch (GlobalController.buttonList[i].Type.Substring(0, 1))
                                {
                                    case "1":
                                        GlobalController.Isshopping = false;
                                        for (int j = 0; j < GlobalController.Global_Shops.Count; j++)
                                        {
                                            if (GlobalController.Global_Shops[j].Name == GlobalController.ShoppingPlace)
                                            {
                                                GlobalController.Global_Shops[j].Unload();
                                            }
                                        }
                                        for (int j = 0; j < GlobalController.buttonList.Count; j++)
                                        {
                                            if (GlobalController.buttonList[j].BingFunc == "Village_seedshop")
                                            {
                                                GlobalController.buttonList.Remove(GlobalController.buttonList[j]);
                                            }
                                        }
                                        GlobalController.buttonList.Remove(GlobalController.buttonList[i]);
                                        break;
                                    case "2":
                                        int sum = 0;


                                        for (int j = 0; j < GlobalController.Global_Shops.Count; j++)
                                        {
                                            if (GlobalController.Global_Shops[j].Name == GlobalController.ShoppingPlace)
                                            {
                                                foreach (Goods item in GlobalController.Global_Shops[j].GoodsList)
                                                {
                                                    if (item.PurchasingCount > 0)
                                                    {
                                                        sum += (int)(item.Item.Price * item.Discount) * item.PurchasingCount;
                                                    }
                                                }
                                            }
                                        }
                                        if (GlobalController.Player.Gold >= sum)
                                        {
                                            GlobalController.Isshopping = false;
                                            for (int j = 0; j < GlobalController.Global_Shops.Count; j++)
                                            {
                                                if (GlobalController.Global_Shops[j].Name == GlobalController.ShoppingPlace)
                                                {
                                                    foreach (Goods item in GlobalController.Global_Shops[j].GoodsList)
                                                    {
                                                        if (item.PurchasingCount > 0)
                                                        {
                                                            for (int k = 0; k < GlobalController.InventoryList.Count; k++)
                                                            {
                                                                if (GlobalController.InventoryList[k].IsNull)
                                                                {
                                                                    GlobalController.InventoryList[k].AddItem(item.Item.Clone(), item.PurchasingCount);
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                        item.Count -= item.PurchasingCount;
                                                    }
                                                    GlobalController.Global_Shops[j].Unload();
                                                }
                                            }
                                            GlobalController.buttonList.Remove(GlobalController.buttonList[i]);
                                            for (int j = 0; j < GlobalController.buttonList.Count; j++)
                                            {
                                                if (GlobalController.buttonList[j].BingFunc == "Village_seedshop")
                                                {
                                                    GlobalController.buttonList.Remove(GlobalController.buttonList[j]);
                                                }
                                            }
                                            GlobalController.Player.Gold -= sum;
                                        }
                                        else
                                        {
                                            GameController._instance.ShowAlert("NO Enough Money!", 2000);
                                        }

                                        break;
                                    default:
                                        break;
                                }

                                break;
                            case "FishNet":
                                switch (GlobalController.buttonList[i].Type.Substring(0, 1))
                                {
                                    case "1":
                                        foreach (IPlayerScene ipS in GlobalController.PlayerSceneList)
                                        {
                                            if (ipS.GetMap() == GlobalController.Map.Name)
                                            {
                                                if (ipS.GetIntanceType() == "Construction")
                                                {
                                                    if ((ipS.GetInstance() as Construction).Name == "fishnet")
                                                    {
                                                        (ipS.GetInstance() as FishNet).CloseBoard();

                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    case "2":
                                        for (int j = 0; j < GlobalController.PlayerSceneList.Count; j++)
                                        {
                                            if (GlobalController.PlayerSceneList[j].GetMap() == GlobalController.Map.Name)
                                            {
                                                if (GlobalController.PlayerSceneList[j].GetIntanceType() == "Construction")
                                                {
                                                    if ((GlobalController.PlayerSceneList[j].GetInstance() as Construction).Name == "fishnet")
                                                    {
                                                        (GlobalController.PlayerSceneList[j].GetInstance() as FishNet).CloseBoard();
                                                        (GlobalController.PlayerSceneList[j].GetInstance() as FishNet).WithDraw();
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                }
                                
                                GlobalController.buttonList.Remove(GlobalController.buttonList[i]);
                                for (int j = 0; j < GlobalController.buttonList.Count; j++)
                                {
                                    if (GlobalController.buttonList[j].BingFunc == "FishNet")
                                    {
                                        GlobalController.buttonList.Remove(GlobalController.buttonList[j]);
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        void CheckMenuItemsClick(Vector2 clickpos)
        {
            if (GlobalController.MenuOut)
            {
                if ((0 < clickpos.X && clickpos.X < 144) && (200 < clickpos.Y && clickpos.Y < 258))
                {
                    GlobalController.BaggageOut = true;
                    GlobalController.buttonList.Add(new Button(ResourceController.UI_ordinary, "1", "BaggageOut", 0.81f, new Vector2(Define.windowWidth + 15 * Define.UnitOFpixel - 5, Define.windowHeight - 10 * Define.UnitOFpixel)));
                }
            }
        }        

        void CheckBaggageItemsClick(Vector2 clickpos)
        {
            if (GlobalController.BaggageOut)
            {
                for (int i = 0; i < GlobalController.InventoryCount; i++)
                {
                    if ((Define.windowWidth * 2 - 888) / 2 + 384 + 75 + 48 * (i % 8) <= clickpos.X && clickpos.X <= (Define.windowWidth * 2 - 888) / 2 + 384 + 75 + 48 * (i % 8) + Define.UnitOFpixel * 2 && Define.windowHeight - 240 + 44 + 48 * (int)(i / 8) <= clickpos.Y && clickpos.Y <= Define.windowHeight - 240 + 44 + 48 * (int)(i / 8) + Define.UnitOFpixel * 2)
                    {
                        if (!GlobalController.InventoryList[i].IsNull && GlobalController.InventWithMouse.IsNull)
                        {
                            if (!InputHandler.KeyboardState.IsKeyDown(Keys.LeftShift))
                            {
                                GlobalController.InventWithMouse.Item = GlobalController.InventoryList[i].Item;
                                GlobalController.InventWithMouse.IsNull = false;
                                GlobalController.InventWithMouse.Count = GlobalController.InventoryList[i].Count;
                                GlobalController.InventoryList[i].Clear();
                            }
                            else
                            {
                                if (GlobalController.InventoryList[i].Count > 1)
                                {
                                    GlobalController.InventWithMouse.Item = GlobalController.InventoryList[i].Item;
                                    GlobalController.InventWithMouse.IsNull = false;
                                    GlobalController.InventWithMouse.Count = GlobalController.InventoryList[i].Count / 2;
                                    GlobalController.InventoryList[i].Count -= GlobalController.InventWithMouse.Count;
                                }
                                else
                                {
                                    GlobalController.InventWithMouse.Item = GlobalController.InventoryList[i].Item;
                                    GlobalController.InventWithMouse.IsNull = false;
                                    GlobalController.InventWithMouse.Count = GlobalController.InventoryList[i].Count;
                                    GlobalController.InventoryList[i].Clear();
                                }
                            }

                        }
                        else if (GlobalController.InventoryList[i].IsNull && !GlobalController.InventWithMouse.IsNull)
                        {
                            GlobalController.InventoryList[i].Item = GlobalController.InventWithMouse.Item;
                            GlobalController.InventoryList[i].IsNull = false;
                            GlobalController.InventoryList[i].Count = GlobalController.InventWithMouse.Count;
                            GlobalController.InventWithMouse.IsNull = true;
                            GlobalController.InventWithMouse.Count = 0;
                            GlobalController.InventWithMouse.Item = null;
                        }
                        else if (!GlobalController.InventoryList[i].IsNull && !GlobalController.InventWithMouse.IsNull)
                        {
                            if (GlobalController.InventWithMouse.Item.Id != GlobalController.InventoryList[i].Item.Id)
                            {
                                Item switchItem = GlobalController.InventWithMouse.Item;
                                int switchCount = GlobalController.InventWithMouse.Count;

                                GlobalController.InventWithMouse.Item = GlobalController.InventoryList[i].Item;
                                GlobalController.InventWithMouse.Count = GlobalController.InventoryList[i].Count;
                                GlobalController.InventoryList[i].Item = switchItem;
                                GlobalController.InventoryList[i].Count = switchCount;
                            }
                            else
                            {
                                GlobalController.InventoryList[i].Count += GlobalController.InventWithMouse.Count;
                                GlobalController.InventWithMouse.IsNull = true;
                                GlobalController.InventWithMouse.Count = 0;
                                GlobalController.InventWithMouse.Item = null;
                            }
                        }
                    }
                }
            }
        }

        void CheckRapidRoomItemsClick(Vector2 clickpos)
        {
            if (GlobalController.PlayerCanMove && !GlobalController.Isshopping)
            {
                if (Define.windowWidth + 79 <= clickpos.X && clickpos.X <= Define.windowWidth + 79 + 48 && Define.windowHeight * 2 - 55 <= clickpos.Y && clickpos.Y <= Define.windowHeight * 2 - 55 + 48)
                {
                    if (!GlobalController.InventWithMouse.IsNull && GlobalController.SelectingRapidRoomItem.IsNull)
                    {
                        if (GlobalController.InventWithMouse.Item.IsEquipment)
                        {
                            GlobalController.SelectingRapidRoomItem.Item = GlobalController.InventWithMouse.Item;
                            GlobalController.SelectingRapidRoomItem.IsNull = false;
                            GlobalController.SelectingRapidRoomItem.Count = GlobalController.InventWithMouse.Count;
                            GlobalController.InventWithMouse.IsNull = true;
                            GlobalController.InventWithMouse.Count = 0;
                            GlobalController.InventWithMouse.Item = null;
                        }
                    }
                    else if (GlobalController.InventWithMouse.IsNull && !GlobalController.SelectingRapidRoomItem.IsNull)
                    {
                        GlobalController.InventWithMouse.Item = GlobalController.SelectingRapidRoomItem.Item;
                        GlobalController.InventWithMouse.IsNull = false;
                        GlobalController.InventWithMouse.Count = GlobalController.SelectingRapidRoomItem.Count;
                        GlobalController.SelectingRapidRoomItem.Clear();
                    }
                    else if (!GlobalController.InventWithMouse.IsNull && !GlobalController.SelectingRapidRoomItem.IsNull)
                    {
                        if (GlobalController.InventWithMouse.Item.IsEquipment)
                        {
                            if (GlobalController.InventWithMouse.Item.Id != GlobalController.SelectingRapidRoomItem.Item.Id)
                            {
                                Item switchItem = GlobalController.InventWithMouse.Item;
                                int switchCount = GlobalController.InventWithMouse.Count;

                                GlobalController.InventWithMouse.Item = GlobalController.SelectingRapidRoomItem.Item;
                                GlobalController.InventWithMouse.Count = GlobalController.SelectingRapidRoomItem.Count;
                                GlobalController.SelectingRapidRoomItem.Item = switchItem;
                                GlobalController.SelectingRapidRoomItem.Count = switchCount;
                            }
                            else
                            {
                                GlobalController.SelectingRapidRoomItem.Count += GlobalController.InventWithMouse.Count;
                                GlobalController.InventWithMouse.IsNull = true;
                                GlobalController.InventWithMouse.Count = 0;
                                GlobalController.InventWithMouse.Item = null;
                            }
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < GlobalController.RapidRoomCount; i++)
                    {
                        if (Define.windowWidth - 6 * Define.UnitOFpixel + 24 + 48 * i <= clickpos.X && clickpos.X <= Define.windowWidth - 6 * Define.UnitOFpixel + 24 + 48 * i + Define.UnitOFpixel * 2 && Define.windowHeight * 2 - 48 <= clickpos.Y && clickpos.Y <= Define.windowHeight * 2 - 48 + Define.UnitOFpixel * 2)
                        {
                            if (!GlobalController.RapidRoomList[i].IsNull && GlobalController.InventWithMouse.IsNull)
                            {
                                if (!InputHandler.KeyboardState.IsKeyDown(Keys.LeftShift))
                                {
                                    GlobalController.InventWithMouse.Item = GlobalController.RapidRoomList[i].Item;
                                    GlobalController.InventWithMouse.IsNull = false;
                                    GlobalController.InventWithMouse.Count = GlobalController.RapidRoomList[i].Count;
                                    GlobalController.RapidRoomList[i].Clear();
                                }
                                else
                                {
                                    if (GlobalController.RapidRoomList[i].Count > 1)
                                    {
                                        GlobalController.InventWithMouse.Item = GlobalController.RapidRoomList[i].Item;
                                        GlobalController.InventWithMouse.IsNull = false;
                                        GlobalController.InventWithMouse.Count = GlobalController.RapidRoomList[i].Count / 2;
                                        GlobalController.RapidRoomList[i].Count -= GlobalController.InventWithMouse.Count;
                                    }
                                    else
                                    {
                                        GlobalController.InventWithMouse.Item = GlobalController.RapidRoomList[i].Item;
                                        GlobalController.InventWithMouse.IsNull = false;
                                        GlobalController.InventWithMouse.Count = GlobalController.RapidRoomList[i].Count;
                                        GlobalController.RapidRoomList[i].Clear();
                                    }
                                }
                            }
                            else if (GlobalController.RapidRoomList[i].IsNull && !GlobalController.InventWithMouse.IsNull)
                            {
                                GlobalController.RapidRoomList[i].Item = GlobalController.InventWithMouse.Item;
                                GlobalController.RapidRoomList[i].IsNull = false;
                                GlobalController.RapidRoomList[i].Count = GlobalController.InventWithMouse.Count;
                                GlobalController.InventWithMouse.IsNull = true;
                                GlobalController.InventWithMouse.Count = 0;
                                GlobalController.InventWithMouse.Item = null;
                            }
                            else if (!GlobalController.RapidRoomList[i].IsNull && !GlobalController.InventWithMouse.IsNull)
                            {
                                if (GlobalController.InventWithMouse.Item.Id != GlobalController.RapidRoomList[i].Item.Id)
                                {
                                    Item switchItem = GlobalController.InventWithMouse.Item;
                                    int switchCount = GlobalController.InventWithMouse.Count;

                                    GlobalController.InventWithMouse.Item = GlobalController.RapidRoomList[i].Item;
                                    GlobalController.InventWithMouse.Count = GlobalController.RapidRoomList[i].Count;
                                    GlobalController.RapidRoomList[i].Item = switchItem;
                                    GlobalController.RapidRoomList[i].Count = switchCount;
                                }
                                else
                                {
                                    GlobalController.RapidRoomList[i].Count += GlobalController.InventWithMouse.Count;
                                    GlobalController.InventWithMouse.IsNull = true;
                                    GlobalController.InventWithMouse.Count = 0;
                                    GlobalController.InventWithMouse.Item = null;
                                }
                            }
                        }

                    }
                }

            }
        }

        void CheckRapidRoomItemsClickRight(Vector2 clickpos)
        {
            if (GlobalController.InventWithMouse.IsNull && GlobalController.PlayerCanMove && !GlobalController.Isshopping)
            {
                if (Define.windowWidth + 124 + 14 <= clickpos.X && clickpos.X <= Define.windowWidth + 124 + 54 && Define.windowHeight * 2 - 76 + 10 <= clickpos.Y && clickpos.Y <= Define.windowHeight * 2 - 76 + 60)
                {
                    if (!GlobalController.SelectingRapidRoomItem.IsNull)
                    {
                        bool haveRoom = false;
                        int roomIndex = -1;
                        for (int i = 0; i < GlobalController.RapidRoomList.Count; i++)
                        {
                            if (GlobalController.RapidRoomList[i].IsNull)
                            {
                                haveRoom = true;
                                roomIndex = i;
                                break;
                            }
                        }
                        if (haveRoom)
                        {
                            GlobalController.RapidRoomList[roomIndex].Item = GlobalController.SelectingRapidRoomItem.Item;
                            GlobalController.RapidRoomList[roomIndex].Count = GlobalController.SelectingRapidRoomItem.Count;
                            GlobalController.RapidRoomList[roomIndex].IsNull = false;
                            GlobalController.SelectingRapidRoomItem.Item = null;
                            GlobalController.SelectingRapidRoomItem.IsNull = true;
                            GlobalController.SelectingRapidRoomItem.Count = 0;
                        }
                    }

                }
                else
                {
                    for (int i = 0; i < GlobalController.RapidRoomCount; i++)
                    {
                        if (Define.windowWidth - 124 + 12 + 58 * i <= clickpos.X && clickpos.X <= Define.windowWidth - 124 + 12 + 58 * i + Define.UnitOFpixel * 2 && Define.windowHeight * 2 - 70 + 8 <= clickpos.Y && clickpos.Y <= Define.windowHeight * 2 - 70 + 8 + Define.UnitOFpixel * 2)
                        {
                            if (!GlobalController.RapidRoomList[i].IsNull && GlobalController.RapidRoomList[i].Item.IsEquipment)
                            {
                                if (GlobalController.SelectingRapidRoomItem.IsNull)
                                {
                                    GlobalController.SelectingRapidRoomItem.Item = GlobalController.RapidRoomList[i].Item;
                                    GlobalController.SelectingRapidRoomItem.Count = GlobalController.RapidRoomList[i].Count;
                                    GlobalController.SelectingRapidRoomItem.IsNull = false;
                                    GlobalController.RapidRoomList[i].Item = null;
                                    GlobalController.RapidRoomList[i].IsNull = true;
                                    GlobalController.RapidRoomList[i].Count = 0;
                                }
                                else
                                {
                                    if (GlobalController.SelectingRapidRoomItem.Item.Id != GlobalController.RapidRoomList[i].Item.Id)
                                    {
                                        Item switchItem = GlobalController.RapidRoomList[i].Item;
                                        int switchCount = GlobalController.RapidRoomList[i].Count;

                                        GlobalController.RapidRoomList[i].Item = GlobalController.SelectingRapidRoomItem.Item;
                                        GlobalController.RapidRoomList[i].Count = GlobalController.SelectingRapidRoomItem.Count;
                                        GlobalController.SelectingRapidRoomItem.Item = switchItem;
                                        GlobalController.SelectingRapidRoomItem.Count = switchCount;
                                    }
                                    else
                                    {
                                        GlobalController.SelectingRapidRoomItem.Count += GlobalController.RapidRoomList[i].Count;
                                        GlobalController.RapidRoomList[i].IsNull = true;
                                        GlobalController.RapidRoomList[i].Count = 0;
                                        GlobalController.RapidRoomList[i].Item = null;
                                    }
                                }
                            }
                            else if (!GlobalController.RapidRoomList[i].IsNull && GlobalController.RapidRoomList[i].Item.Category == "Property")
                            {
                                (GlobalController.RapidRoomList[i].Item as Property).UsingProperty();
                            }
                        }

                    }
                }
            }

        }

        void CheckNpcClick(Vector2 clickpos)
        {
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping && !GlobalController.SaleBoxOut && GlobalController.PlayerCanMove)
            {
                clickpos = Camera.HandleScreenPostoLocal(clickpos, GlobalController.Camera);
                for (int i = 0; i < GlobalController.Npcs.Length; i++)
                {
                    if (GlobalController.Npcs[i].Map.Name == GlobalController.Map.Name)
                    {
                        if (MouseHandler.GameObjectPlayerDistance(GlobalController.Npcs[i]) < 1.4f * Define.UnitOFpixel && clickpos.X > GlobalController.Npcs[i].Position.X && clickpos.X < GlobalController.Npcs[i].Position.X + Define.UnitOFpixel && clickpos.Y > GlobalController.Npcs[i].Position.Y && clickpos.Y < GlobalController.Npcs[i].Position.Y + 2 * Define.UnitOFpixel)
                        {
                            int answer = MouseHandler.PlayerLookAtGameObject(GlobalController.Npcs[i]);
                            if (answer != -1)
                            {
                                answer -= 2;
                                if (answer < 0)
                                {
                                    answer = 3;
                                }
                                GlobalController._Cv_func._Global_NpcFrame_ConversationHandler(GlobalController.Npcs[i], 3 - answer, answer);
                            }
                        }                    
                    }
                }
            }
        }

        void CheckOutdoorItemsClick(Vector2 clickpos)
        {
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping && !GlobalController.SaleBoxOut && GlobalController.PlayerCanMove)
            {
                for (int i = 0; i < GlobalController.OutdoorItemsList.Count; i++)
                {
                    if (GlobalController.OutdoorItemsList[i].Map.Name == GlobalController.Map.Name)
                    {
                        if (MouseHandler.GameObjectPlayerDistance(GlobalController.OutdoorItemsList[i]) < 1.2f * Define.UnitOFpixel)
                        {
                            PlayerHandler.ShowAnim("picky", MouseHandler.PlayerLookAtGameObject(GlobalController.OutdoorItemsList[i]), GlobalController.OutdoorItemsList[i]);
                        }
                    }
                }
            }
        }

        void ShowRapidRoomItemsDetail()
        {
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping)
            {
                Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);
                for (int i = 0; i < GlobalController.RapidRoomCount; i++)
                {
                    if (Define.windowWidth - 124 + 12 + 58 * i <= mousePos.X && mousePos.X <= Define.windowWidth - 124 + 12 + 58 * i + Define.UnitOFpixel * 2 && Define.windowHeight * 2 - 70 + 8 <= mousePos.Y && mousePos.Y <= Define.windowHeight * 2 - 70 + 8 + Define.UnitOFpixel * 2)
                    {
                        if (!GlobalController.RapidRoomList[i].IsNull)
                        {
                            GlobalController.ShowDetail = true;
                            GlobalController.ShowDetailTime = 500;
                            GlobalController.DetailBanner = GlobalController.RapidRoomList[i].Item.Name;
                        }
                    }
                }

            }
        }

        void ShowDetail()
        {
            Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping && !GlobalController.SaleBoxOut && GlobalController.PlayerCanMove && !GlobalController.PlayerIsFishing)
            {
                for (int i = 0; i < GlobalController.OutdoorItemsList.Count; i++)
                {
                    if (GlobalController.OutdoorItemsList[i].Map.Name == GlobalController.Map.Name)
                    {
                        if (MouseHandler.GameObjectPlayerDistance(GlobalController.OutdoorItemsList[i]) < 1.2f * Define.UnitOFpixel)
                        {
                            GlobalController.ShowDetail = true;
                            GlobalController.ShowDetailTime = 500;
                            GlobalController.DetailBanner = GlobalController.OutdoorItemsList[i].Item.Name;
                            GlobalController.Mouse.Status = 3;
                        }                       
                    }
                }
            }
        }

        void ShowDetailInBaggage()
        {
            Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);
            if (GlobalController.BaggageOut && !GlobalController.Isshopping && GlobalController.PlayerCanMove)
            {
                for (int i = 0; i < GlobalController.RapidRoomCount; i++)
                {
                    if (Define.windowWidth - 124 + 12 + 58 * i <= mousePos.X && mousePos.X <= Define.windowWidth - 124 + 12 + 58 * i + Define.UnitOFpixel * 2 && Define.windowHeight * 2 - 70 + 8 <= mousePos.Y && mousePos.Y <= Define.windowHeight * 2 - 70 + 8 + Define.UnitOFpixel * 2)
                    {
                        if (!GlobalController.RapidRoomList[i].IsNull)
                        {
                            GlobalController.BaggageBanner.Item = GlobalController.RapidRoomList[i].Item;
                            GlobalController.BaggageBanner.IsNull = false;
                        }


                    }
                }
                for (int i = 0; i < GlobalController.InventoryCount; i++)
                {
                    if (Define.windowWidth - 408 + 72 + 66 * (i % 6) <= mousePos.X && mousePos.X <= Define.windowWidth - 408 + 72 + 66 * (i % 6) + Define.UnitOFpixel * 2 && Define.windowHeight - 240 + 66 + 60 * (int)(i / 6) <= mousePos.Y && mousePos.Y <= Define.windowHeight - 240 + 66 + 60 * (int)(i / 6) + Define.UnitOFpixel * 2)
                    {
                        if (!GlobalController.InventoryList[i].IsNull)
                        {
                            GlobalController.BaggageBanner.Item = GlobalController.InventoryList[i].Item;
                            GlobalController.BaggageBanner.IsNull = false;
                        }

                    }
                }

            }
        }

        void ShowNpcHover()
        {
            Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);
            mousePos = Camera.HandleScreenPostoLocal(mousePos,GlobalController.Camera);
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping && !GlobalController.SaleBoxOut)
            {
                for (int i = 0; i < GlobalController.Npcs.Length; i++)
                {
                    if (GlobalController.Npcs[i].Map.Name == GlobalController.Map.Name)
                    {
                        if (MouseHandler.GameObjectPlayerDistance(GlobalController.Npcs[i]) < 1.4f * Define.UnitOFpixel && mousePos.X > GlobalController.Npcs[i].Position.X && mousePos.X < GlobalController.Npcs[i].Position.X + Define.UnitOFpixel && mousePos.Y > GlobalController.Npcs[i].Position.Y && mousePos.Y < GlobalController.Npcs[i].Position.Y + 2 * Define.UnitOFpixel)
                        {
                            GlobalController.Mouse.Color = Color.Yellow;
                        }
                    }
                }
            }
        }

        void ShowMenuItemsHover()
        {
            if (GlobalController.MenuOut)
            {
                Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);
                if ((0 < mousePos.X && mousePos.X < 144) && (200 < mousePos.Y && mousePos.Y < 258) || GlobalController.BaggageOut)
                {
                    UserInterface.MenuBackpackIcon.Frame = new Point(6, 5);
                }
                else
                {
                    UserInterface.MenuBackpackIcon.Frame = new Point(0, 5);
                }

                if ((0 < mousePos.X && mousePos.X < 144) && (260 < mousePos.Y && mousePos.Y < 318))
                {
                    UserInterface.MenuPersonalIcon.Frame = new Point(6, 8);
                }
                else
                {
                    UserInterface.MenuPersonalIcon.Frame = new Point(0, 8);
                }
                if ((0 < mousePos.X && mousePos.X < 144) && (320 < mousePos.Y && mousePos.Y < 378))
                {
                    UserInterface.MenuSkillIcon.Frame = new Point(6, 11);
                }
                else
                {
                    UserInterface.MenuSkillIcon.Frame = new Point(0, 11);
                }
                if ((0 < mousePos.X && mousePos.X < 144) && (380 < mousePos.Y && mousePos.Y < 438))
                {
                    UserInterface.MenuContactIcon.Frame = new Point(6, 14);
                }
                else
                {
                    UserInterface.MenuContactIcon.Frame = new Point(0, 14);
                }
                if ((0 < mousePos.X && mousePos.X < 144) && (440 < mousePos.Y && mousePos.Y < 498))
                {
                    UserInterface.MenuSettingsIcon.Frame = new Point(6, 17);
                }
                else
                {
                    UserInterface.MenuSettingsIcon.Frame = new Point(0, 17);
                }
            }
        }

        void ShowBtnHover()
        {
            if (GlobalController.buttonList.Count > 0)
            {
                Vector2 mousePos = new Vector2(mouseState.X, mouseState.Y);
                for (int i = 0; i < GlobalController.buttonList.Count; i++)
                {
                    if (GlobalController.buttonList[i].CheckPos(mousePos))
                    {
                        switch (GlobalController.buttonList[i].Type.Substring(0,1))
                        {
                            case "1":
                                GlobalController.buttonList[i].CurrentFrame = new Point(8, GlobalController.buttonList[i].CurrentFrame.Y);
                                break;
                            case "2":
                                GlobalController.buttonList[i].CurrentFrame = new Point(13, GlobalController.buttonList[i].CurrentFrame.Y);
                                break;
                            default:
                                break;
                        }
                        


                    }
                    else
                    {
                        switch (GlobalController.buttonList[i].Type.Substring(0,1))
                        {
                            case "1":
                                GlobalController.buttonList[i].CurrentFrame = new Point(7, GlobalController.buttonList[i].CurrentFrame.Y);
                                break;
                            case "2":
                                GlobalController.buttonList[i].CurrentFrame = new Point(10, GlobalController.buttonList[i].CurrentFrame.Y);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        void CheckConversation()
        {
            if (!GlobalController.SelectDialogue) 
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastmouseState.LeftButton == ButtonState.Released)
                {

                    if (GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[0] == "#")
                    {
                        GlobalController.SelectDialogue = true;
                        GlobalController.SelectDialogueContent.Clear();
                        GlobalController.ConversationIndex += 1;
                        for (int i = GlobalController.ConversationIndex; i < GlobalController.ConversationContent.Count; i++)
                        {
                            if (GlobalController.ConversationContent[i].Split('|')[0] != "#")
                            {
                                GlobalController.SelectDialogueContent.Add(GlobalController.ConversationContent[i]);
                            }
                            else
                            {
                                GlobalController.ConversationIndex = i + 1;
                                break;
                            }
                        }
                        GlobalController.Conversation = GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[0];
                    }
                    else if (GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[0] == "end")
                    {
                        GlobalController.isTalking = false;
                        GlobalController.ConversationContent.Clear();
                        GlobalController.ConversationIndex = -1;
                    }
                    else
                    {
                        GlobalController.Conversation = GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[0];
                        GlobalController.ConversationIndex = Convert.ToInt32(GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[1]);
                    }
                }
            }

        }

        void CheckSelectDialogue()
        {
            Vector2 clickpos = new Vector2(mouseState.X, mouseState.Y);
            if (GlobalController.SelectDialogue)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && lastmouseState.LeftButton == ButtonState.Released)
                {

                    if (Define.windowWidth - 408 <= clickpos.X && clickpos.X <= Define.windowWidth + 408 && Define.windowHeight - 250 <= clickpos.Y && clickpos.Y <= Define.windowHeight - 172 && GlobalController.SelectDialogueContent.Count > 0)
                    {
                        string[] handle = GlobalController.SelectDialogueContent[0].Split('|');
                        GlobalController.ConversationIndex = Convert.ToInt32(handle[1]);
                        GlobalController.ConversationOptionSelect.Add(handle[2]);
                        GlobalController.SelectDialogue = false;
                    }
                    if (Define.windowWidth - 408 <= clickpos.X && clickpos.X <= Define.windowWidth + 408 && Define.windowHeight - 150 <= clickpos.Y && clickpos.Y <= Define.windowHeight - 72 && GlobalController.SelectDialogueContent.Count > 0)
                    {
                        string[] handle = GlobalController.SelectDialogueContent[1].Split('|');
                        GlobalController.ConversationIndex = Convert.ToInt32(handle[1]);
                        GlobalController.ConversationOptionSelect.Add(handle[2]);
                        GlobalController.SelectDialogue = false;
                    }
                    if (Define.windowWidth - 408 <= clickpos.X && clickpos.X <= Define.windowWidth + 408 && Define.windowHeight - 50 <= clickpos.Y && clickpos.Y <= Define.windowHeight + 28 && GlobalController.SelectDialogueContent.Count > 0)
                    {
                        string[] handle = GlobalController.SelectDialogueContent[2].Split('|');
                        GlobalController.ConversationIndex = Convert.ToInt32(handle[1]);
                        GlobalController.ConversationOptionSelect.Add(handle[2]);
                        GlobalController.SelectDialogue = false;
                    }
                    if (Define.windowWidth - 408 <= clickpos.X && clickpos.X <= Define.windowWidth + 408 && Define.windowHeight + 50 <= clickpos.Y && clickpos.Y <= Define.windowHeight + 128 && GlobalController.SelectDialogueContent.Count > 0)
                    {
                        string[] handle = GlobalController.SelectDialogueContent[3].Split('|');
                        GlobalController.ConversationIndex = Convert.ToInt32(handle[1]);
                        GlobalController.ConversationOptionSelect.Add(handle[2]);
                        GlobalController.SelectDialogue = false;
                    }
                }
            }
        }

        void CheckUsingTools()
        {
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping && !GlobalController.SaleBoxOut && GlobalController.InventWithMouse.IsNull && GlobalController.Player.Map.Name == "village_thefarm" && FarmAreaCheck() && !PlayerHandler.showAnim_ && GlobalController.PlayerCanMove)
            {
                Vector2 playerPos = Camera.HandlePos(GlobalController.Player.Position, GlobalController.Camera);
                Vector2 leftTopLimit = new Vector2(playerPos.X - Define.UnitOFpixel, playerPos.Y);
                Vector2 RightTopLimit = new Vector2(playerPos.X + 2 * Define.UnitOFpixel, playerPos.Y);
                Vector2 leftBottomLimit = new Vector2(playerPos.X - Define.UnitOFpixel, playerPos.Y + 3 * Define.UnitOFpixel);
                Vector2 RightBottomLimit = new Vector2(playerPos.X + 2 * Define.UnitOFpixel, playerPos.Y + 3 * Define.UnitOFpixel);
                if (mouseState.X / 2 >= leftTopLimit.X && mouseState.X / 2 <= RightTopLimit.X && mouseState.Y / 2 >= leftTopLimit.Y && mouseState.Y / 2 <= RightBottomLimit.Y)
                {


                    Vector2 truePos = Camera.HandleScreenPostoLocal(new Vector2(mouseState.X, mouseState.Y), GlobalController.Camera);

                    int xMove = (int)(truePos.X) % 48;
                    int yMove = (int)(truePos.Y) % 48;

                    Vector2 standardPos = new Vector2((int)(truePos.X) - xMove, (int)(truePos.Y) - yMove);

                    bool ifExist = false;
                    int index = 0;

                    for (int i = 0; i < GlobalController.SoilList.Count; i++)
                    {
                        if (GlobalController.SoilList[i].Position == standardPos)
                        {
                            ifExist = true;
                            index = i;
                        }
                    }
                    if (ifExist && GlobalController.SoilList[index].Seed != Seeds.Null && GlobalController.SoilList[index].Seed.Status == 4)
                    {
                        GlobalController.Mouse.Status = 3;                   
                    }
                    else
                    {
                        if (!GlobalController.SelectingRapidRoomItem.IsNull && GlobalController.SelectingRapidRoomItem.Item.Category == "Tool")
                        {
                            int toolType = ((GlobalController.SelectingRapidRoomItem.Item) as Tools).ToolsType;

                            if (toolType == 1)
                            {

                                if (!ifExist)
                                {
                                    GlobalController.Mouse.Status = 1;

                                    //Vector2 mousePos = Camera.HandlePos(standardPos, GlobalController.Camera);

                                    //GlobalController.Mouse.Position = new Vector2(mousePos.X * 2, mousePos.Y * 2);
                                }



                            }
                            else if (toolType == 2)
                            {
                                if (ifExist)
                                {
                                    GlobalController.Mouse.Status = 4;

                                    //Vector2 mousePos = Camera.HandlePos(standardPos, GlobalController.Camera);

                                    //GlobalController.Mouse.Position = new Vector2(mousePos.X * 2, mousePos.Y * 2);

                                }


                            }


                        }

                        else if (!GlobalController.SelectingRapidRoomItem.IsNull && GlobalController.SelectingRapidRoomItem.Item.Category == "Seed")
                        {

                            if (ifExist && !GlobalController.SoilList[index].IsSeeded)
                            {
                                GlobalController.Mouse.Status = 2;
                                //Vector2 mousePos = Camera.HandlePos(standardPos, GlobalController.Camera);

                                //GlobalController.Mouse.Position = new Vector2(mousePos.X * 2, mousePos.Y * 2);
                            }
                            else
                            {
                                GlobalController.Mouse.Status = 0;
                            }


                        }
                    }
                    

                }
            }

        }       

        void UsingToolsClick(Vector2 clickpos)
        {
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping && !GlobalController.SaleBoxOut && GlobalController.InventWithMouse.IsNull && GlobalController.Player.Map.Name == "village_thefarm" && FarmAreaCheck() && !PlayerHandler.showAnim_ && GlobalController.PlayerCanMove)
            {               
                Vector2 playerPos = Camera.HandlePos(GlobalController.Player.Position, GlobalController.Camera);
                Vector2 leftTopLimit = new Vector2(playerPos.X - Define.UnitOFpixel, playerPos.Y);
                Vector2 RightTopLimit = new Vector2(playerPos.X + 2 * Define.UnitOFpixel, playerPos.Y);
                Vector2 leftBottomLimit = new Vector2(playerPos.X - Define.UnitOFpixel, playerPos.Y + 3 * Define.UnitOFpixel);
                Vector2 RightBottomLimit = new Vector2(playerPos.X + 2 * Define.UnitOFpixel, playerPos.Y + 3 * Define.UnitOFpixel);

                if (mouseState.X / 2 >= leftTopLimit.X && mouseState.X / 2 <= RightTopLimit.X && mouseState.Y / 2 >= leftTopLimit.Y && mouseState.Y / 2 <= RightBottomLimit.Y)
                {
                    Vector2 truePos = Camera.HandleScreenPostoLocal(new Vector2(mouseState.X, mouseState.Y), GlobalController.Camera);

                    int xMove = (int)(truePos.X) % 48;
                    int yMove = (int)(truePos.Y) % 48;

                    Vector2 newSoilPos = new Vector2((int)(truePos.X) - xMove, (int)(truePos.Y) - yMove);
                    bool ifExist = false;
                    int index = 0;

                    for (int i = 0; i < GlobalController.SoilList.Count; i++)
                    {
                        if (GlobalController.SoilList[i].Position == newSoilPos)
                        {
                            ifExist = true;
                            index = i;
                        }
                    }
                    if (ifExist && GlobalController.SoilList[index].Seed != Seeds.Null && GlobalController.SoilList[index].Seed.Status == 4)
                    {
                        PlayerHandler.ShowAnimProgress("harvest", MouseHandler.PlayerLookAtGameObject(GlobalController.SoilList[index]), index);
                        GameController._instance.ShowProcessing("harvesting...", GlobalController.SoilList[index].Seed.HarvestTime);
                    }
                    else
                    {
                        if (!GlobalController.SelectingRapidRoomItem.IsNull && GlobalController.SelectingRapidRoomItem.Item.Category == "Tool")
                        {
                            int toolType = ((GlobalController.SelectingRapidRoomItem.Item) as Tools).ToolsType;

                            if (toolType == 1)
                            {
                                if (!PlayerHandler.showAnim_)
                                {
                                    if (!ifExist)
                                    {
                                        PlayerHandler.ShowAnim("usingTools", MouseHandler.PlayerLookAtMouse(), newSoilPos, toolType);
                                    }

                                }


                            }
                            else if (toolType == 2)
                            {
                                if (!PlayerHandler.showAnim_)
                                {
                                    if (ifExist)
                                    {
                                        PlayerHandler.ShowAnim("usingTools", MouseHandler.PlayerLookAtMouse(), newSoilPos, toolType);
                                    }
                                }
                            }
                        }
                        else if (!GlobalController.SelectingRapidRoomItem.IsNull && GlobalController.SelectingRapidRoomItem.Item.Category == "Seed")
                        {
                            if (!PlayerHandler.showAnim_)
                            {

                                if (ifExist && !GlobalController.SoilList[index].IsSeeded)
                                {
                                    PlayerHandler.ShowAnim("seeding", MouseHandler.PlayerLookAtMouse(), index);
                                }
                            }
                        }
                    }
                }
            }

        }

        bool CheckDistance(Vector2 position, Point size, float distance)
        {
            Vector2 playerPos = GlobalController.Player.MidPos;
            Vector2 goPos = new Vector2(position.X + size.X * 1f / 2 * Define.UnitOFpixel, position.Y + size.Y * 1f / 2 * Define.UnitOFpixel);
            float x = Math.Abs(goPos.X - playerPos.X);
            float y = Math.Abs(goPos.Y - playerPos.Y);
            if (Math.Sqrt(x * x + y * y) < distance * Define.UnitOFpixel)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool FarmAreaCheck()
        {
            List<Rectangle> rect = GlobalController.Map.CanDoReclaimCheck();
            foreach (IPlayerScene item in GlobalController.PlayerSceneList)
            {
                if (item.GetMap() == "village_thefarm")
                {
                    rect.Add(item.GetCollider());
                }                
            }
            
            Vector2 truePos = Camera.HandleScreenPostoLocal(new Vector2(mouseState.X, mouseState.Y), GlobalController.Camera);
            bool inArea = true;

            foreach (Rectangle rec in rect)
            {
                if (rec.X <= truePos.X && truePos.X <= rec.X + rec.Width && rec.Y <= truePos.Y && truePos.Y <= rec.Y + rec.Height)
                {
                    inArea = false;
                }
            }
            return inArea;
        }

        void ShoppingClick(Vector2 clickpos)
        {
            if (GlobalController.Isshopping)
            {
                foreach (Shops shop in GlobalController.Global_Shops)
                {
                    if (GlobalController.ShoppingPlace == shop.Name)
                    {
                        if (Define.windowWidth - 408 + 432 <= clickpos.X && clickpos.X <= Define.windowWidth - 408 + 432 + 11 && Define.windowHeight - 240 + 40 <= clickpos.Y && clickpos.Y <= Define.windowHeight - 240 + 40 + 16)
                        {
                            if (shop.Index > 0)
                            {
                                shop.Index -= 1;
                            }                           
                        }
                        else if (Define.windowWidth - 408 + 432 <= clickpos.X && clickpos.X <= Define.windowWidth - 408 + 432 + 22 && Define.windowHeight - 240 + 365 <= clickpos.Y && clickpos.Y <= Define.windowHeight - 240 + 365 + 16)
                        {
                            if (shop.Index < shop.GoodsList.Count - 6)
                            {
                                shop.Index += 1;
                            }                           
                        }
                        else
                        {
                            for (int i = 0; i < 6; i++)
                            {
                                if (shop.Index + i < shop.GoodsList.Count)
                                {
                                    if (Define.windowWidth - 408 + 56 <= clickpos.X && clickpos.X <= Define.windowWidth - 408 + 56 + 280 && Define.windowHeight - 240 + 44 + 58 * i <= clickpos.Y && clickpos.Y <= Define.windowHeight - 240 + 44 + 58 * i + 44 && shop.GoodsList[i + shop.Index].Count > 0)
                                    {
                                        for (int j = 0; j < shop.GoodsList.Count; j++)
                                        {
                                            shop.GoodsList[j].IsSelecting = false;

                                        }
                                        shop.IsSelecting = shop.GoodsList[i + shop.Index];
                                        shop.GoodsList[i + shop.Index].IsSelecting = true;
                                    }
                                    else if (Define.windowWidth - 408 + 338 <= clickpos.X && clickpos.X <= Define.windowWidth - 408 + 338 + 45 && Define.windowHeight - 240 + 46 + 58 * i <= clickpos.Y && clickpos.Y <= Define.windowHeight - 240 + 46 + 58 * i + 40 && shop.GoodsList[i + shop.Index].IsSelecting)
                                    {
                                        if (shop.GoodsList[i + shop.Index].PurchasingCount < shop.GoodsList[i + shop.Index].Count)
                                        {
                                            shop.GoodsList[i + shop.Index].PurchasingCount += 1;
                                        }

                                    }
                                    else if (Define.windowWidth - 408 + 338 + 46 <= clickpos.X && clickpos.X <= Define.windowWidth - 408 + 338 + 90 && Define.windowHeight - 240 + 46 + 58 * i <= clickpos.Y && clickpos.Y <= Define.windowHeight - 240 + 46 + 58 * i + 40 && shop.GoodsList[i + shop.Index].IsSelecting)
                                    {
                                        if (shop.GoodsList[i + shop.Index].PurchasingCount > 0)
                                        {
                                            shop.GoodsList[i + shop.Index].PurchasingCount -= 1;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }               
            }


        }

        void ShowIndoor()
        {
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping && GlobalController.InventWithMouse.IsNull && !GlobalController.SaleBoxOut && GlobalController.PlayerCanMove)
            {
                Vector2 truePos = Camera.HandleScreenPostoLocal(new Vector2(mouseState.X, mouseState.Y), GlobalController.Camera);
                foreach (Building building in GlobalController.BuildingList)
                {
                    if (building.GetMap() == GlobalController.Map.Name)
                    {
                        for (int i = 0; i < building.DoorTrigger.Length; i++)
                        {
                            if (building.DoorTrigger[i].X < truePos.X && truePos.X < building.DoorTrigger[i].X + building.DoorTrigger[i].Width && building.DoorTrigger[i].Y < truePos.Y && truePos.Y < building.DoorTrigger[i].Y + building.DoorTrigger[i].Height)
                            {
                                if (CheckDistance(new Vector2(building.DoorTrigger[i].X, building.DoorTrigger[i].Y), new Point(building.DoorTrigger[i].Width / Define.UnitOFpixel, building.DoorTrigger[i].Height / Define.UnitOFpixel), 1.5f))
                                {
                                    GlobalController.Mouse.Status = 5;
                                }
                            }
                        }
                    }
                }
                foreach (Trigger trigger in GlobalController.DoorTriggerList)
                {
                    if (trigger.Collider.X < truePos.X && truePos.X < trigger.Collider.X + trigger.Collider.Width && trigger.Collider.Y < truePos.Y && truePos.Y < trigger.Collider.Y + trigger.Collider.Height)
                    {
                        if (CheckDistance(new Vector2(trigger.Collider.X, trigger.Collider.Y), new Point(trigger.Collider.Width / Define.UnitOFpixel, trigger.Collider.Height / Define.UnitOFpixel), 1.5f))
                        {
                            GlobalController.Mouse.Status = 5;
                        }
                    }
                }
            }
        }

        void IndoorClick(Vector2 clickpos)
        {
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping && GlobalController.InventWithMouse.IsNull && !GlobalController.SaleBoxOut && GlobalController.PlayerCanMove)
            {
                Vector2 truePos = Camera.HandleScreenPostoLocal(clickpos, GlobalController.Camera);
                foreach (Building building in GlobalController.BuildingList)
                {
                    if (building.GetMap() == GlobalController.Map.Name)
                    {
                        for (int i = 0; i < building.DoorTrigger.Length; i++)
                        {
                            if (building.DoorTrigger[i].X < truePos.X && truePos.X < building.DoorTrigger[i].X + building.DoorTrigger[i].Width && building.DoorTrigger[i].Y < truePos.Y && truePos.Y < building.DoorTrigger[i].Y + building.DoorTrigger[i].Height)
                            {
                                if (CheckDistance(new Vector2(building.DoorTrigger[i].X, building.DoorTrigger[i].Y), new Point(building.DoorTrigger[i].Width / Define.UnitOFpixel, building.DoorTrigger[i].Height / Define.UnitOFpixel), 1.5f))
                                {
                                    GlobalController.SStatus = new GlobalController.Cs
                                    {
                                        cName = building.TargetScene[i],
                                        func = 1
                                    };
                                }
                            }                        
                        }

                    }
                }

                foreach (Trigger trigger in GlobalController.DoorTriggerList)
                {
                    if (trigger.Collider.X < truePos.X && truePos.X < trigger.Collider.X + trigger.Collider.Width && trigger.Collider.Y < truePos.Y && truePos.Y < trigger.Collider.Y + trigger.Collider.Height)
                    {
                        if (CheckDistance(new Vector2(trigger.Collider.X, trigger.Collider.Y), new Point(trigger.Collider.Width / Define.UnitOFpixel, trigger.Collider.Height / Define.UnitOFpixel), 1.5f))
                        {
                            string cn = "";
                            switch (trigger.Index)
                            {
                                case 51:
                                    cn = "village_centre_clinic";
                                    break;
                                case 52:
                                    cn = "village_centre_hotel";
                                    break;
                                case 53:
                                    cn = "village_centre_restaurant";
                                    break;
                                case 54:
                                    cn = "village_centre_managehouse";
                                    break;
                                case 55:
                                    cn = "village_centre_house1";
                                    break;
                                case 56:
                                    cn = "village_centre_house2";
                                    break;
                                case 57:
                                    cn = "village_centre_toolhouse";
                                    break;
                                case 58:
                                    cn = "village_centre_shop";
                                    break;
                                default:
                                    break;
                            }
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = cn,
                                func = 1
                            };
                        }
                    }
                }

            }
        }

        void PlayerSceneClick(Vector2 clickpos)
        {
            Vector2 playerPos = Camera.HandlePos(GlobalController.Player.Position, GlobalController.Camera);
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping && GlobalController.PlayerCanMove)
            {
                Vector2 truePos = Camera.HandleScreenPostoLocal(clickpos, GlobalController.Camera);
                foreach (IPlayerScene ipS in GlobalController.PlayerSceneList)
                {
                    if (ipS.GetMap() == GlobalController.Map.Name)
                    {
                        for (int i = 0; i < ipS.GetEffiveClickArea().Length; i++)
                        {
                            if (ipS.GetEffiveClickArea()[i].X < truePos.X && truePos.X < ipS.GetEffiveClickArea()[i].X + ipS.GetEffiveClickArea()[i].Width && ipS.GetEffiveClickArea()[i].Y < truePos.Y && truePos.Y < ipS.GetEffiveClickArea()[i].Y + ipS.GetEffiveClickArea()[i].Height)
                            {
                                switch (ipS.GetIntanceType())
                                {
                                    case "PterocarpinTree":
                                        if (((GlobalController.SelectingRapidRoomItem.Item) as Tools).ToolsType == 3 && (ipS.GetInstance() as Tree).GrowTime > 2880)
                                        {
                                            if (MouseHandler.GameObjectPlayerDistance(ipS.GetInstance()) < 1.2f * Define.UnitOFpixel)
                                            {
                                               
                                                PlayerHandler.ShowAnim("usingTools", MouseHandler.PlayerLookAtGameObject(ipS.GetInstance()), ipS.GetInstance(), 3);
                                            }
                                        }

                                        break;
                                    case "Chest":
                                        if ((ipS.GetInstance() as Chest).Type == 1)
                                        {
                                            if (GlobalController.InventWithMouse.IsNull)
                                            {
                                                GlobalController.SaleBoxOut = true;
                                                GlobalController.OpengingChest = ipS.GetInstance() as Chest;
                                            }
                                            else
                                            {
                                                Chest chest = ipS.GetInstance() as Chest;

                                                PlayerHandler.ShowAnim("giving", MouseHandler.PlayerLookAtGameObject(chest), chest, "Chest");                                               
                                            }
                                        }
                                        break;
                                    case "Furniture":
                                        if (MouseHandler.GameObjectPlayerDistance(ipS.GetInstance()) < 3f * Define.UnitOFpixel)
                                        {
                                            PlayerHandler.ChangeDirect(MouseHandler.PlayerLookAtGameObject(ipS.GetInstance()));
                                            GlobalController.isTalking = true;
                                            GlobalController.ConversationOptionSelect.Add("bed");
                                            GlobalController.ConversationName = "bed";
                                            GlobalController.ConversationContent.Clear();
                                            GlobalController.ConversationContent.Add((GlobalController.isDayTime ? "Daytime." : "Night.") + "|1");
                                            GlobalController.ConversationContent.Add("#");
                                            GlobalController.ConversationContent.Add("yes|6|1");
                                            GlobalController.ConversationContent.Add("no|6|2");
                                            GlobalController.ConversationContent.Add("#");
                                            GlobalController.ConversationContent.Add("Sleep?");
                                            GlobalController.ConversationContent.Add("end");
                                            GlobalController.ConversationIndex = 0;
                                            GlobalController.Conversation = GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[0];
                                            GlobalController.ConversationIndex = Convert.ToInt32(GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[1]);
                                        }
                                       
                                        break;
                                    case "Construction":
                                        if ((ipS.GetInstance() as Construction).Name == "cowhouse")
                                        {
                                            if (i == 1)
                                            {
                                                if (MouseHandler.RectanglePlayerDistance(ipS.GetEffiveClickArea()[i]) < 1.5f * Define.UnitOFpixel)
                                                {
                                                    if (!GlobalController.InventWithMouse.IsNull && GlobalController.InventWithMouse.Item.Id == "05_003" && !(ipS.GetInstance() as CowHouse).IsHaveFood)
                                                    {
                                                        (ipS.GetInstance() as CowHouse).IsHaveFood = true;
                                                        GlobalController.InventWithMouse.Count--;

                                                    }
                                                }
                                            }
                                            else if (i == 2)
                                            {
                                                Console.WriteLine(MouseHandler.RectanglePlayerDistance(ipS.GetEffiveClickArea()[i]));
                                                if (MouseHandler.RectanglePlayerDistance(ipS.GetEffiveClickArea()[i]) < 3f * Define.UnitOFpixel)
                                                {
                                                    Rectangle rect = new Rectangle(ipS.GetEffiveClickArea()[i].X, ipS.GetEffiveClickArea()[i].Y + 2 * Define.UnitOFpixel, ipS.GetEffiveClickArea()[i].Width, Define.UnitOFpixel);
                                                    if (!GlobalController.Player.Collider.Intersects(rect))
                                                    {
                                                        if ((ipS.GetInstance() as CowHouse).IsDoorOpen)
                                                        {
                                                            (ipS.GetInstance() as CowHouse).IsDoorOpen = false;
                                                        }
                                                        else
                                                        {
                                                            (ipS.GetInstance() as CowHouse).IsDoorOpen = true;
                                                        }
                                                    }

                                                }
                                            }
                                        }

                                        if ((ipS.GetInstance() as Construction).Name == "fishnet")
                                        {
                                            if (GlobalController.InventWithMouse.IsNull)
                                            {
                                                FishNet fn = ipS.GetInstance() as FishNet;
                                                fn.ShowBoard();
                                            }
                                            else if (GlobalController.InventWithMouse.Item.Id.Substring(0, 2) == "06")
                                            {
                                                FishNet fn = ipS.GetInstance() as FishNet;
                                                if (fn.FishList.Count < 20)
                                                {
                                                    fn.FishList.Add(GlobalController.InventWithMouse.Item.Clone() as Fish);
                                                    GlobalController.InventWithMouse.Count--;
                                                }
                                                else
                                                {
                                                    GameController._instance.ShowAlert("Net is full", 2000);
                                                }
                                            }
                                        }

                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }

                }
            }

        }

        void SaleBoxClick(Vector2 clickpos)
        {
            if (GlobalController.SaleBoxOut)
            {
                if (Define.windowWidth + 262 <= clickpos.X && clickpos.X <= Define.windowWidth + 262 + 96 && Define.windowHeight + 120 <= clickpos.Y && clickpos.Y <= Define.windowHeight + 120 + 48)
                {
                    GlobalController.SaleBoxOut = false;
                }
                else
                {
                    for (int i = 0; i < GlobalController.InventoryCount; i++)
                    {
                        if (Define.windowWidth - 408 + 38 + 58 * (i % 6) <= clickpos.X && clickpos.X <= Define.windowWidth - 408 + 38 + 58 * (i % 6) + Define.UnitOFpixel * 2 && Define.windowHeight - 264 + 80 + 58 * (int)(i / 6) <= clickpos.Y && clickpos.Y <= Define.windowHeight - 264 + 80 + 58 * (int)(i / 6) + Define.UnitOFpixel * 2)
                        {
                            if (!GlobalController.InventoryList[i].IsNull && GlobalController.InventWithMouse.IsNull)
                            {
                                if (!InputHandler.KeyboardState.IsKeyDown(Keys.LeftShift))
                                {
                                    GlobalController.InventWithMouse.Item = GlobalController.InventoryList[i].Item;
                                    GlobalController.InventWithMouse.IsNull = false;
                                    GlobalController.InventWithMouse.Count = GlobalController.InventoryList[i].Count;
                                    GlobalController.InventoryList[i].Clear();
                                }
                                else
                                {
                                    if (GlobalController.InventoryList[i].Count > 1)
                                    {
                                        GlobalController.InventWithMouse.Item = GlobalController.InventoryList[i].Item;
                                        GlobalController.InventWithMouse.IsNull = false;
                                        GlobalController.InventWithMouse.Count = GlobalController.InventoryList[i].Count / 2;
                                        GlobalController.InventoryList[i].Count -= GlobalController.InventWithMouse.Count;
                                    }
                                    else
                                    {
                                        GlobalController.InventWithMouse.Item = GlobalController.InventoryList[i].Item;
                                        GlobalController.InventWithMouse.IsNull = false;
                                        GlobalController.InventWithMouse.Count = GlobalController.InventoryList[i].Count;
                                        GlobalController.InventoryList[i].Clear();
                                    }
                                }

                            }
                            else if (GlobalController.InventoryList[i].IsNull && !GlobalController.InventWithMouse.IsNull)
                            {
                                GlobalController.InventoryList[i].Item = GlobalController.InventWithMouse.Item;
                                GlobalController.InventoryList[i].IsNull = false;
                                GlobalController.InventoryList[i].Count = GlobalController.InventWithMouse.Count;
                                GlobalController.InventWithMouse.IsNull = true;
                                GlobalController.InventWithMouse.Count = 0;
                                GlobalController.InventWithMouse.Item = null;
                            }
                            else if (!GlobalController.InventoryList[i].IsNull && !GlobalController.InventWithMouse.IsNull)
                            {
                                if (GlobalController.InventWithMouse.Item.Id != GlobalController.InventoryList[i].Item.Id)
                                {
                                    Item switchItem = GlobalController.InventWithMouse.Item;
                                    int switchCount = GlobalController.InventWithMouse.Count;

                                    GlobalController.InventWithMouse.Item = GlobalController.InventoryList[i].Item;
                                    GlobalController.InventWithMouse.Count = GlobalController.InventoryList[i].Count;
                                    GlobalController.InventoryList[i].Item = switchItem;
                                    GlobalController.InventoryList[i].Count = switchCount;
                                }
                                else
                                {
                                    GlobalController.InventoryList[i].Count += GlobalController.InventWithMouse.Count;
                                    GlobalController.InventWithMouse.IsNull = true;
                                    GlobalController.InventWithMouse.Count = 0;
                                    GlobalController.InventWithMouse.Item = null;
                                }
                            }
                        }
                    }

                    for (int i = 0; i < GlobalController.OpengingChest.Amount; i++)
                    {
                        if (Define.windowWidth + 38 + 58 * (i % 6) <= clickpos.X && clickpos.X <= Define.windowWidth + 38 + 58 * (i % 6) + Define.UnitOFpixel * 2 && Define.windowHeight - 264 + 80 + 58 * (int)(i / 6) <= clickpos.Y && clickpos.Y <= Define.windowHeight - 264 + 80 + 58 * (int)(i / 6) + Define.UnitOFpixel * 2)
                        {
                            if (!GlobalController.OpengingChest.Inventries[i].IsNull && GlobalController.InventWithMouse.IsNull)
                            {
                                if (!InputHandler.KeyboardState.IsKeyDown(Keys.LeftShift))
                                {
                                    GlobalController.InventWithMouse.Item = GlobalController.OpengingChest.Inventries[i].Item;
                                    GlobalController.InventWithMouse.IsNull = false;
                                    GlobalController.InventWithMouse.Count = GlobalController.OpengingChest.Inventries[i].Count;
                                    GlobalController.OpengingChest.Inventries[i].Clear();
                                }
                                else
                                {
                                    if (GlobalController.OpengingChest.Inventries[i].Count > 1)
                                    {
                                        GlobalController.InventWithMouse.Item = GlobalController.OpengingChest.Inventries[i].Item;
                                        GlobalController.InventWithMouse.IsNull = false;
                                        GlobalController.InventWithMouse.Count = GlobalController.OpengingChest.Inventries[i].Count / 2;
                                        GlobalController.OpengingChest.Inventries[i].Count -= GlobalController.InventWithMouse.Count;
                                    }
                                    else
                                    {
                                        GlobalController.InventWithMouse.Item = GlobalController.OpengingChest.Inventries[i].Item;
                                        GlobalController.InventWithMouse.IsNull = false;
                                        GlobalController.InventWithMouse.Count = GlobalController.OpengingChest.Inventries[i].Count;
                                        GlobalController.OpengingChest.Inventries[i].Clear();
                                    }
                                }

                            }
                            else if (GlobalController.OpengingChest.Inventries[i].IsNull && !GlobalController.InventWithMouse.IsNull)
                            {
                                GlobalController.OpengingChest.Inventries[i].Item = GlobalController.InventWithMouse.Item;
                                GlobalController.OpengingChest.Inventries[i].IsNull = false;
                                GlobalController.OpengingChest.Inventries[i].Count = GlobalController.InventWithMouse.Count;
                                GlobalController.InventWithMouse.IsNull = true;
                                GlobalController.InventWithMouse.Count = 0;
                                GlobalController.InventWithMouse.Item = null;
                            }
                            else if (!GlobalController.OpengingChest.Inventries[i].IsNull && !GlobalController.InventWithMouse.IsNull)
                            {
                                if (GlobalController.InventWithMouse.Item.Id != GlobalController.OpengingChest.Inventries[i].Item.Id)
                                {
                                    Item switchItem = GlobalController.InventWithMouse.Item;
                                    int switchCount = GlobalController.InventWithMouse.Count;

                                    GlobalController.InventWithMouse.Item = GlobalController.OpengingChest.Inventries[i].Item;
                                    GlobalController.InventWithMouse.Count = GlobalController.OpengingChest.Inventries[i].Count;
                                    GlobalController.OpengingChest.Inventries[i].Item = switchItem;
                                    GlobalController.OpengingChest.Inventries[i].Count = switchCount;
                                }
                                else
                                {
                                    GlobalController.OpengingChest.Inventries[i].Count += GlobalController.InventWithMouse.Count;
                                    GlobalController.InventWithMouse.IsNull = true;
                                    GlobalController.InventWithMouse.Count = 0;
                                    GlobalController.InventWithMouse.Item = null;
                                }
                            }
                        }
                    }


                }
            }
        }

        void FishingClick(Vector2 clickpos)
        {
            if (!GlobalController.BaggageOut && !GlobalController.Isshopping && !GlobalController.SaleBoxOut && GlobalController.InventWithMouse.IsNull && !PlayerHandler.showAnim_ && GlobalController.PlayerCanMove)
            {
                if (!GlobalController.SelectingRapidRoomItem.IsNull && GlobalController.SelectingRapidRoomItem.Item.Category == "Tool")
                {
                    int toolType = ((GlobalController.SelectingRapidRoomItem.Item) as Tools).ToolsType;

                    if (toolType == 4)
                    {
                        if (!PlayerHandler.showAnim_)
                        {
                            Vector2 playerPos = Camera.HandlePos(GlobalController.Player.Position, GlobalController.Camera);
                            PlayerHandler.ShowAnim("fishing", MouseHandler.PlayerLookAtMouse());
                        }
                    }
                }
            }

            if (GlobalController.PlayerIsFishing && GlobalController.FishingSys.Step != 4)
            {
                if (GlobalController.FishingSys.GettingFish)
                {
                    GlobalController.FishingSys.GettingFish = false;
                    GlobalController.FishingSys.StandardHookPos = GlobalController.FishingSys.HookPos;
                    GlobalController.FishingSys.Step = 4;
                    GlobalController.FishingSys.Fish = Item.ItemCreateFactory("06_001") as Fish;
                }
                else
                {
                    GlobalController.PlayerIsFishing = false;
                    GlobalController.FishingSys = FishingSystem.Null;
                }

            }

        }

    }
}



