using CV_Library.Controllers;
using CV_Library.Functions;
using CV_Library.GameObjects.Buildings;
using CV_Library.GameObjects.Characters;
using CV_Library.GameObjects.Decorats;
using CV_Library.GameObjects.Items;
using CV_Library.GameObjects.Soils;
using CV_Library.GameObjects.Trees;
using CV_Library.Globals;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;

namespace CV_Library
{
    public class GameController
    {
        public const string prefix_character = @"Characters/";
        public const string prefix_maps = @"Maps/";
        public static ContentManager SContent;
        public static GameController _instance;

        ContentManager Content;
        public GameController(ContentManager content)
        {
            SContent = content;
            Content = content;
            _instance = this;
        }

        public void Draw(SpriteBatch b)
        {
            Camera.Execute(GlobalController.Camera);
            GlobalController.Player.Draw(b);

            for (int i = 0; i < GlobalController.Npcs.Length; i++)
            {
                if (GlobalController.Npcs[i].Map.Name == GlobalController.Map.Name)
                {
                    GlobalController.Npcs[i].Draw(b);
                }

            }

            if (!GlobalController.InventWithMouse.IsNull)
            {
                if ((GlobalController.Player.Frame == 2 || GlobalController.Player.Frame == 5) && GlobalController.PlayerCanMove)
                {
                    b.Draw(GlobalController.InventWithMouse.Item.Texture, new Vector2(GlobalController.Player.RenderPosition.X, GlobalController.Player.RenderPosition.Y - 7), GlobalController.InventWithMouse.Item.RenderRectangle, GlobalController.InventWithMouse.Item.RenderColor, GlobalController.InventWithMouse.Item.Rotation, GlobalController.InventWithMouse.Item.Origin, 1f, GlobalController.InventWithMouse.Item.SpriteEffects, GlobalController.Player.LayerDepth + 0.001f);
                }
                else
                {
                    b.Draw(GlobalController.InventWithMouse.Item.Texture, new Vector2(GlobalController.Player.RenderPosition.X, GlobalController.Player.RenderPosition.Y - 8), GlobalController.InventWithMouse.Item.RenderRectangle, GlobalController.InventWithMouse.Item.RenderColor, GlobalController.InventWithMouse.Item.Rotation, GlobalController.InventWithMouse.Item.Origin, 1f, GlobalController.InventWithMouse.Item.SpriteEffects, GlobalController.Player.LayerDepth + 0.001f);
                }
            }
            GlobalController._Cv_func._Global_CreateMapTile(b);

            
            foreach (Bush bush in GlobalController.BushList)
            {
                if (bush.GetMap() == GlobalController.Map.Name)
                {
                    bush.Draw(b);
                }
            }
            foreach (OutDoorItem item in GlobalController.OutdoorItemsList)
            {
                if (item.Map.Name == GlobalController.Map.Name)
                {
                    item.Draw(b);
                }
            }

            foreach (Flower flower in GlobalController.FlowerList)
            {
                if (flower.GetMap() == GlobalController.Map.Name)
                {
                    flower.Draw(b);
                }
            }
            foreach (Decorats decorat in GlobalController.DecoratList)
            {
                if (decorat.GetMap() == GlobalController.Map.Name)
                {
                    decorat.Draw(b);
                }
            }


            if (GlobalController.bus != null)
            {
                GlobalController.bus.Draw(b);
            }

            foreach (Soil soil in GlobalController.SoilList)
            {
                if (soil.GetMap() == GlobalController.Map.Name)
                {
                    soil.Draw(b);
                }
            }

            foreach (IPlayerScene item in GlobalController.PlayerSceneList)
            {
                if (item.GetMap() == GlobalController.Map.Name)
                {
                    item.Draw(b);
                }

            }            
        }

        public void DrawUI(SpriteBatch b)
        {
            //spriteBatch.Draw(加载的图片,针对于屏幕来说开始画的位置，针对于图片来说剪裁的矩形位置和大小，图片渲染颜色（可做夜晚效果？），旋转，针对于图片的原点位置，缩放，渲染效果，层深度)

            GlobalController._Cv_func._Global_Show_UI(b);
            b.Draw(GlobalController.Mouse.Texture, new Vector2(GlobalController.Mouse.Position.X - 14, GlobalController.Mouse.Position.Y - 8), GlobalController.Mouse.MouseRect, GlobalController.Mouse.Color, 0, Vector2.Zero, 2, SpriteEffects.None, 0.9f);
            
            

        

            if (GlobalController.SaleBoxOut)
            {
                b.Draw(Content.Load<Texture2D>("UI/UI_salebox"), new Vector2(Define.windowWidth - 408, Define.windowHeight - 216), new Rectangle(0, 0, 408, 216), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0.8f);
                foreach (Inventory inventory in GlobalController.InventoryList)
                {
                    if (!inventory.IsNull)
                    {
                        b.Draw(inventory.Item.Texture, new Vector2(Define.windowWidth - 408 + 38 + 58 * ((inventory.Index - 1) % 6), Define.windowHeight - 264 + 80 + 58 * (int)((inventory.Index - 1) / 6)), inventory.Item.RenderRectangle, inventory.Item.RenderColor, inventory.Item.Rotation, inventory.Item.Origin, 2, inventory.Item.SpriteEffects, 0.81f);
                        if (inventory.Count > 1)
                        {
                            Fonts.DrawString(inventory.Count.ToString(), new Vector2(Define.windowWidth - 408 + 38 + 58 * ((inventory.Index - 1) % 6) + 20, Define.windowHeight - 264 + 80 + 58 * (int)((inventory.Index - 1) / 6) + 20), b, Color.White, 0.811f, 1, 30);
                        }

                    }
                }
                foreach (Inventory inventory in GlobalController.OpengingChest.Inventries)
                {
                    if (!inventory.IsNull)
                    {
                        b.Draw(inventory.Item.Texture, new Vector2(Define.windowWidth + 38 + 58 * ((inventory.Index - 1) % 6), Define.windowHeight - 264 + 80 + 58 * (int)((inventory.Index - 1) / 6)), inventory.Item.RenderRectangle, inventory.Item.RenderColor, inventory.Item.Rotation, inventory.Item.Origin, 2, inventory.Item.SpriteEffects, 0.81f);
                        if (inventory.Count > 1)
                        {
                            Fonts.DrawString(inventory.Count.ToString(), new Vector2(Define.windowWidth + 38 + 58 * ((inventory.Index - 1) % 6) + 20, Define.windowHeight - 264 + 80 + 58 * (int)((inventory.Index - 1) / 6) + 20), b, Color.White, 0.811f, 1, 30);
                        }

                    }
                }
            }

            

        }

        public void DrawPause(SpriteBatch b)
        {
            if (GlobalController.isPause)
            {
                b.Draw(Content.Load<Texture2D>("UI/pause"), new Vector2(260, 90), new Rectangle(0, 0, 240, 240), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0.8f);
            }
        }

        public static void PlayerMoveSleep(double milliseTime)
        {
            GlobalController.PlayerCanMove = false;
            GlobalController.MoveWaitTime = milliseTime;
        }

        public void DrawLight(SpriteBatch b)
        {
            if (GlobalController.Player.HasLight)
            {
                b.Draw(ResourceController.Lights_light, new Vector2(GlobalController.Player.RenderPosition.X + Define.UnitOFpixel * GlobalController.Player.Size.X / (GlobalController.Player.Scale * 2) - GlobalController.Player.Light.Size.X / 2, GlobalController.Player.RenderPosition.Y + 2 * Define.UnitOFpixel * GlobalController.Player.Size.Y / (GlobalController.Player.Scale * 2) - GlobalController.Player.Light.Size.Y / 2), GlobalController.Player.Light.RenderColor);
            }

            for (int i = 0; i < GlobalController.Npcs.Length; i++)
            {
                if (GlobalController.Npcs[i].Map.Name == GlobalController.Map.Name)
                {
                    if (GlobalController.Npcs[i].HasLight)
                    {
                        b.Draw(ResourceController.Lights_light, new Vector2(GlobalController.Npcs[i].RenderPosition.X + Define.UnitOFpixel * GlobalController.Npcs[i].Size.X / (GlobalController.Npcs[i].Scale * 2) - GlobalController.Npcs[i].Light.Size.X / 2, GlobalController.Npcs[i].RenderPosition.Y + Define.UnitOFpixel * GlobalController.Npcs[i].Size.Y / (GlobalController.Npcs[i].Scale * 2) - GlobalController.Npcs[i].Light.Size.Y / 2), GlobalController.Npcs[i].Light.RenderColor);
                    }
                }
            }

        }

        public Color GetLightByTime(float time)
        {
            if (GlobalController.Weather == "sunny")
            {
                if (GlobalController.DayTime <= time && time <= GlobalController.NightTime - GlobalController.LightTurningTime)
                {
                    return Color.White;
                }
                else if (time >= 0 && time < GlobalController.DayTime - GlobalController.LightTurningTime)
                {
                    return new Color(0, 0.1f, 0.3f);
                }
                else if (GlobalController.NightTime < time && time <= 1440f)
                {
                    return new Color(0, 0.1f, 0.3f);
                }
                else if (GlobalController.DayTime - GlobalController.LightTurningTime <= time && time <= GlobalController.DayTime)
                {
                    return new Color((float)(1 * (time - 300) / 120), (float)(0.1 + 0.9 * (time - 300) / 120), (float)(0.3 + 0.7 * (time - 300) / 120));
                }
                else if (GlobalController.NightTime - GlobalController.LightTurningTime < time && time <= GlobalController.NightTime)
                {
                    return new Color((float)(1 - 1 * (time - 1140) / 120), (float)(1 - 0.9 * (time - 1140) / 120), (float)(1 - 0.7 * (time - 1140) / 120));
                }
                else
                {
                    return Color.White;
                }
            }
            else if (GlobalController.Weather == "rainy")
            {
                if (GlobalController.DayTime <= time && time <= GlobalController.NightTime - GlobalController.LightTurningTime)
                {
                    return Color.White;
                }
                else if (time >= 0 && time < GlobalController.DayTime - GlobalController.LightTurningTime)
                {
                    return new Color(0, 0.1f, 0.3f);
                }
                else if (GlobalController.NightTime < time && time <= 1440f)
                {
                    return new Color(0, 0.1f, 0.3f);
                }
                else if (GlobalController.DayTime - GlobalController.LightTurningTime <= time && time <= GlobalController.DayTime)
                {
                    return new Color((float)(1 * (time - 300) / 120), (float)(0.1 + 0.9 * (time - 300) / 120), (float)(0.3 + 0.7 * (time - 300) / 120));
                }
                else if (GlobalController.NightTime - GlobalController.LightTurningTime < time && time <= GlobalController.NightTime)
                {
                    return new Color((float)(1 - 1 * (time - 1140) / 120), (float)(1 - 0.9 * (time - 1140) / 120), (float)(1 - 0.7 * (time - 1140) / 120));
                }
                else
                {
                    return Color.White;
                }
            }
            else if (GlobalController.Weather == "windy")
            {
                if (GlobalController.DayTime <= time && time <= GlobalController.NightTime - GlobalController.LightTurningTime)
                {
                    return Color.White;
                }
                else if (time >= 0 && time < GlobalController.DayTime - GlobalController.LightTurningTime)
                {
                    return new Color(0, 0.1f, 0.3f);
                }
                else if (GlobalController.NightTime < time && time <= 1440f)
                {
                    return new Color(0, 0.1f, 0.3f);
                }
                else if (GlobalController.DayTime - GlobalController.LightTurningTime <= time && time <= GlobalController.DayTime)
                {
                    return new Color((float)(1 * (time - 300) / 120), (float)(0.1 + 0.9 * (time - 300) / 120), (float)(0.3 + 0.7 * (time - 300) / 120));
                }
                else if (GlobalController.NightTime - GlobalController.LightTurningTime < time && time <= GlobalController.NightTime)
                {
                    return new Color((float)(1 - 1 * (time - 1140) / 120), (float)(1 - 0.9 * (time - 1140) / 120), (float)(1 - 0.7 * (time - 1140) / 120));
                }
                else
                {
                    return Color.White;
                }
            }
            else
            {
                return Color.White;
            }
        }

        public void DrawWeather(SpriteBatch b)
        {
            if (GlobalController.Weather == "rainy")
            {
                foreach (Rain item in GlobalController.WeatherHandleList)
                {
                    b.Draw(item.Texture, item.RenderPosition, item.RenderRectangle, item.RenderColor, item.Rotation, item.Origin, item.Scale, item.SpriteEffects, 0.89f);
                }
            }
            else if (GlobalController.Weather == "windy")
            {
                foreach (Wind item in GlobalController.WeatherHandleList)
                {
                    b.Draw(item.Texture, item.RenderPosition, item.RenderRectangle, item.RenderColor, item.Rotation, item.Origin, item.Scale, item.SpriteEffects, 0.89f);
                }
            }
        }

        public void ShowAlert(string content, int showTime)
        {
            GlobalController.ShowAlert = true;
            GlobalController.AlertContent = content;
            GlobalController.AlertShowTime = showTime;
        }

        public void ShowProcessing(string content, int showTime)
        {
            GlobalController.ShowProgress = true;
            GlobalController.ProgressContent = content;

            GlobalController.ProgressLayerDepth = 0.84f;
            if (showTime <= 5000)
            {
                GlobalController.ProgressShowTime = showTime;
            }
            else if (5000 < showTime && showTime <= 60000)
            {
                GlobalController.ProgressShowTime = 5000 + showTime * 5000 / 60000;
                GlobalController.TimeAccelerate = showTime * 1.0f / GlobalController.ProgressShowTime;
            }
            else
            {
                GlobalController.ProgressShowTime = 10000;
                GlobalController.TimeAccelerate = showTime * 1.0f / GlobalController.ProgressShowTime;
            }
        }

        public void TimeAccelerate(int trueTime, int gameTime)
        {
            GlobalController.TimeAccelerate = gameTime * 1.0f / trueTime;
        }

        public void ChangeScene(string screenName, int playerIntoFunc)
        {
            switch (screenName)
            {
                #region town
                case "town_centre":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position, 0, "town_centre", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(1 * 24, 32 * 24),  2, "town_centre", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(118 * 24, 99 * 24),  1, "town_centre", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(118 * 24, 48 * 24),  1, "town_centre", "town", playerIntoFunc);
                    }
                    break;
                case "town_hospital_indoor_first":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "town_hospital_indoor_first", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(20 * 24, 22 * 24),  3, "town_hospital_indoor_first", "town", playerIntoFunc);
                    }
                    break;
                case "town_suburb":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "town_suburb", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(98 * 24, 32 * 24),  1, "town_suburb", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(1 * 24, 12 * 24),  2, "town_suburb", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(1 * 24, 107 * 24),  2, "town_suburb", "town", playerIntoFunc);
                    }
                    break;
                case "town_station":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "town_station", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(1 * 24, 19 * 24),  2, "town_station", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(56 * 24, 1 * 24),  0, "town_station", "town", playerIntoFunc);
                    }
                    break;
                case "town_west":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "town_west", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(58 * 24, 12 * 24),  1, "town_west", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(41 * 24, 77 * 24),  3, "town_west", "town", playerIntoFunc);
                    }
                    break;
                case "town_east":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "town_east", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(1 * 24, 48 * 24),  2, "town_east", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(55 * 24, 77 * 24),  3, "town_east", "town", playerIntoFunc);
                    }
                    break;
                case "town_southriver":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "town_southriver", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(58 * 24, 27 * 24),  1, "town_southriver", "town", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(40 * 24, 1 * 24),  0, "town_southriver", "town", playerIntoFunc);
                    }
                    break;
                #endregion

                #region village
                case "village_suburb_west":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "village_suburb_west", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(13 * 24, 90 * 24),  0, "village_suburb_west", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(166 * 24, 28 * 24),  1, "village_suburb_west", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(166 * 24, 79 * 24),  1, "village_suburb_west", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 4)
                    {
                        SceneLoading(new Vector2(130 * 24, 1 * 24),  0, "village_suburb_west", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 5)
                    {
                        SceneLoading(new Vector2(21 * 24, 1 * 24),  0, "village_suburb_west", "village", playerIntoFunc);
                    }
                    break;
                case "village_suburb_east":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "village_suburb_east", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(1 * 24, 21 * 24),  2, "village_suburb_east", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(76 * 24, 1 * 24),  0, "village_suburb_east", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(97 * 24, 18 * 24),  1, "village_suburb_east", "village", playerIntoFunc);
                    }
                    break;
                case "village_thefarm":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "village_thefarm", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(1 * 24, 51 * 24),  2, "village_thefarm", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(36 * 24, 15 * 24),  0, "village_thefarm", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(76 * 24, 77 * 24),  3, "village_thefarm", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 4)
                    {
                        SceneLoading(new Vector2(97 * 24, 16 * 24),  1, "village_thefarm", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 5)
                    {
                        SceneLoading(new Vector2(1 * 24, 14 * 24),  2, "village_thefarm", "village", playerIntoFunc);
                    }
                    break;
                case "village_lake":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "village_lake", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(1 * 24, 104 * 24),  2, "village_lake", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(1 * 24, 14 * 24),  2, "village_lake", "village", playerIntoFunc);
                    }
                    break;
                case "village_centre":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(63 * 24, 87 * 24),  3, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(118 * 24, 58 * 24),  1, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(1 * 24, 7 * 24),  2, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 4)
                    {
                        SceneLoading(new Vector2(28 * 24, 20 * 24), 0, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 5)
                    {
                        SceneLoading(new Vector2(42 * 24, 37 * 24), 0, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 6)
                    {
                        SceneLoading(new Vector2(61 * 24, 36 * 24), 0, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 7)
                    {
                        SceneLoading(new Vector2(55 * 24, 12 * 24), 0, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 8)
                    {
                        SceneLoading(new Vector2(78 * 24, 19 * 24), 0, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 9)
                    {
                        SceneLoading(new Vector2(88 * 24, 32 * 24), 0, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 10)
                    {
                        SceneLoading(new Vector2(93 * 24, 19 * 24), 0, "village_centre", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 11)
                    {
                        SceneLoading(new Vector2(108 * 24, 27 * 24), 0, "village_centre", "village", playerIntoFunc);
                    }
                    break;
                case "village_northfarm":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "village_northfarm", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(98 * 24, 47 * 24),  1, "village_northfarm", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(53 * 24, 116 * 24),  3, "village_northfarm", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(1 * 24, 55 * 24),  2, "village_northfarm", "village", playerIntoFunc);
                    }
                    break;
                case "village_ambi":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "village_ambi", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(98 * 24, 96 * 24),  1, "village_ambi", "village", playerIntoFunc);
                    }
                    break;
                #endregion

                #region city
                case "city_entry":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_entry", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 81 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_entry", "city", playerIntoFunc);
                    }
                    break;
                case "city_slumarea":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_slumarea", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(90 * 24 + GlobalController.Player.CollideTriggerXMove, 81.8f * 24),  3, "city_slumarea", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 31 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_slumarea", "city", playerIntoFunc);
                    }
                    break;
                case "city_busstation":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_busstation", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(60 * 24 + GlobalController.Player.CollideTriggerXMove, 0.2f * 24),  0, "city_busstation", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 31 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_busstation", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(117.8f * 24, 31 * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_busstation", "city", playerIntoFunc);
                    }
                    break;
                case "city_market":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_market", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(67.8f * 24, 46 * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_market", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 46 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_market", "city", playerIntoFunc);
                    }
                    break;
                case "city_station":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_station", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(97.8f * 24, 31 * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_station", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 31 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_station", "city", playerIntoFunc);
                    }
                    break;
                case "city_centre":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_centre", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(117.8f * 24, 96 * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_centre", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(100 * 24 + GlobalController.Player.CollideTriggerXMove, 111.8f * 24),  3, "city_centre", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(10 * 24 + GlobalController.Player.CollideTriggerXMove, 111.8f * 24),  3, "city_centre", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 4)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 96 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_centre", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 5)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 61 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_centre", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 6)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 31 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_centre", "city", playerIntoFunc);
                    }
                    break;
                case "city_buildingsite":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_buildingsite", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(100 * 24 + GlobalController.Player.CollideTriggerXMove, 0.2f * 24),  0, "city_buildingsite", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(10 * 24 + GlobalController.Player.CollideTriggerXMove, 0.2f * 24),  0, "city_buildingsite", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 30 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_buildingsite", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 4)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 81 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_buildingsite", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 5)
                    {
                        SceneLoading(new Vector2(10 * 24 + GlobalController.Player.CollideTriggerXMove, 96.8f * 24),  3, "city_buildingsite", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 6)
                    {
                        SceneLoading(new Vector2(80 * 24 + GlobalController.Player.CollideTriggerXMove, 96.8f * 24),  3, "city_buildingsite", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 7)
                    {
                        SceneLoading(new Vector2(117.8f * 24, 81 * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_buildingsite", "city", playerIntoFunc);
                    }
                    break;
                case "city_suburb":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_suburb", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(80 * 24 + GlobalController.Player.CollideTriggerXMove, 0.2f * 24),  0, "city_suburb", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(10 * 24 + GlobalController.Player.CollideTriggerXMove, 0.2f * 24),  0, "city_suburb", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(1.2f * 24, 36 * 24 + GlobalController.Player.CollideTriggerYMove),  2, "city_suburb", "city", playerIntoFunc);
                    }
                    break;
                case "city_villa":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_villa", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(137.8f * 24, 31 * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_villa", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(137.8f * 24, 61 * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_villa", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(35 * 24 + GlobalController.Player.CollideTriggerXMove, 71.8f * 24),  3, "city_villa", "city", playerIntoFunc);
                    }
                    break;
                case "city_park":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_park", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(5 * 24 + GlobalController.Player.CollideTriggerXMove, 0.2f * 24),  0, "city_park", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(107.8f * 24, 21 * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_park", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(107.8f * 24, 71
                            * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_park", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 4)
                    {
                        SceneLoading(new Vector2(30 * 24 + GlobalController.Player.CollideTriggerXMove, 81.8f * 24),  3, "city_park", "city", playerIntoFunc);
                    }
                    break;
                case "city_school":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position,  0, "city_school", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(30 * 24 + GlobalController.Player.CollideTriggerXMove, 0.2f * 24),  0, "city_school", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 2)
                    {
                        SceneLoading(new Vector2(107.8f * 24, 31 * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_school", "city", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 3)
                    {
                        SceneLoading(new Vector2(107.8f * 24, 86 * 24 + GlobalController.Player.CollideTriggerYMove),  1, "city_school", "city", playerIntoFunc);
                    }
                    break;
                #endregion

                #region inDoor
                case "village_farmhouse":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position, 0, "village_farmhouse", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(23 * 24, 21 * 24), 3, "village_farmhouse", "village", playerIntoFunc);
                    }
                    break;
                case "village_centre_clinic":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position, 0, "village_centre_clinic", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(23 * 24, 21 * 24), 3, "village_centre_clinic", "village", playerIntoFunc);
                    }
                    break;
                case "village_centre_hotel":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position, 0, "village_centre_hotel", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(23 * 24, 21 * 24), 3, "village_centre_hotel", "village", playerIntoFunc);
                    }
                    break;
                case "village_centre_house1":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position, 0, "village_centre_house1", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(23 * 24, 21 * 24), 3, "village_centre_house1", "village", playerIntoFunc);
                    }
                    break;
                case "village_centre_house2":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position, 0, "village_centre_house2", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(23 * 24, 21 * 24), 3, "village_centre_house2", "village", playerIntoFunc);
                    }
                    break;
                case "village_centre_managehouse":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position, 0, "village_centre_managehouse", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(23 * 24, 21 * 24), 3, "village_centre_managehouse", "village", playerIntoFunc);
                    }
                    break;
                case "village_centre_restaurant":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position, 0, "village_centre_restaurant", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(23 * 24, 21 * 24), 3, "village_centre_restaurant", "village", playerIntoFunc);
                    }
                    break;
                case "village_centre_shop":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position, 0, "village_centre_shop", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(23 * 24, 21 * 24), 3, "village_centre_shop", "village", playerIntoFunc);
                    }
                    break;
                case "village_centre_toolhouse":
                    if (playerIntoFunc == 0)
                    {
                        SceneLoading(GlobalController.PlayerWithoutInit.Position, 0, "village_centre_toolhouse", "village", playerIntoFunc);
                    }
                    else if (playerIntoFunc == 1)
                    {
                        SceneLoading(new Vector2(23 * 24, 21 * 24), 3, "village_centre_toolhouse", "village", playerIntoFunc);
                    }
                    break;
                #endregion

                default:
                    break;
            }
        }

        public static void SavePlayerFile()
        {
            GlobalController.SavingStart = true;
        }

        void SceneLoading(Vector2 position, int direct, string mapName, string region, int playerIntoFunc)
        {
            if (playerIntoFunc == 0)
            {
                GlobalController.Map = new CV_Library.Map(mapName);

                GlobalController.Player = new Player(GlobalController.Map, position, GlobalController.PlayerWithoutInit.Name, GlobalController.PlayerWithoutInit.CTile, GlobalController.PlayerWithoutInit.Speed, GlobalController.PlayerWithoutInit.Gender, GlobalController.PlayerWithoutInit.HasLight, GlobalController.PlayerWithoutInit.HpUpper, GlobalController.PlayerWithoutInit.Hp, GlobalController.PlayerWithoutInit.EnergyUpper, GlobalController.PlayerWithoutInit.Energy, GlobalController.PlayerWithoutInit.Habitus, GlobalController.PlayerWithoutInit.Hunger, GlobalController.PlayerWithoutInit.Gold, GlobalController.PlayerWithoutInit.IsDisease, region);
                //GlobalController.Player.SetBox2D();
            }
            else
            {
                GlobalController.Map = new CV_Library.Map(mapName);

                GlobalController.Player.Map = GlobalController.Map;
                GlobalController.Player.Region = region;
                GlobalController.Player.Position = position;
                GlobalController.Player.Anim = 0;
                GlobalController.Player.Direct = direct;

            }
            LoadMap(GlobalController.Map.Name);
            GlobalController.PlayerInDoor = false;
            GlobalController.Camera = new Camera();
            Camera.HandleCamera(GlobalController.Camera);
            ShowAlert(mapName, 2000);
        }     


        //void SceneTown_station(Vector2 position, Point frame, bool init)
        //{
        //    if (init)
        //    {
        //        GlobalController.Map = new CV_Library.Map("town_station");

        //        GlobalController.Player = new Player(GlobalController.Map, position, 2f, false, ResourceController.Characters_character_girl, true, new Light(ResourceController.Lights_light), ResourceController.Characters_character_shadow, ResourceController.Characters_character_usingtools, 100, 100, 100, 100, 100, 100, GlobalController.PlayerGoldWithoutInit, false, "town");
        //    }
        //    else
        //    {
        //        GlobalController.Map = new CV_Library.Map("town_station");

        //        GlobalController.Player.Map = GlobalController.Map;
        //        GlobalController.Player.Region = "town";
        //        GlobalController.Player.Position = position;
        //        GlobalController.Player.CurrentFrame = frame;

        //    }


        //    LoadMap(GlobalController.Map.Name);
        //    GlobalController.PlayerInDoor = false;
        //    GlobalController.NpcSchedule = new List<NPCSchedule>();
        //    GlobalController.NpcSchedule.Add(new NPCSchedule("character_girl_Conductor", new List<totalInstruct> { 
        //                new totalInstruct
        //                {
        //                    mapName = "town_station",
        //                    instruct = new List<instruct>
        //                    {                              
        //                    }
        //                }
        //            }, new Vector2(1080f, 178f), false));

        //    GlobalController.Npcs = new List<NPC>();
        //    foreach (NPCSchedule nsc in GlobalController.NpcSchedule)
        //    {
        //        if (nsc.MapName == GlobalController.Map.Name)
        //        {
        //            GlobalController.Npcs.Add(new NPC(nsc.Name, GlobalController.Map, nsc.Pos, Content.Load<Texture2D>(GameController.prefix_character + nsc.Name), true, new Light(ResourceController.Lights_light), nsc.HasAnotherFrame, ResourceController.Characters_character_shadow));
        //        }
        //    }
        //    GlobalController.Camera = new Camera();
        //    Camera.HandleCamera(GlobalController.Camera);

        //    GlobalController.bus = null;

        //    ShowAlert("Town-Station", 2000);
        //}

     
       
        //void SceneVillage_suburb_west(Vector2 position, Point frame, bool init, int playerIntoFunc)
        //{
        //    //XmlNode root = DataController.GetSceneNode("village_suburb_west");
        //    if (init)
        //    {
        //        GlobalController.Map = new CV_Library.Map("village_suburb_west");

        //        GlobalController.Player = new Player(GlobalController.Map, position, 2f, false, ResourceController.Characters_character_girl, true, new Light(ResourceController.Lights_light), ResourceController.Characters_character_shadow, ResourceController.Characters_character_usingtools, 100, 100, 100, 100, 100, 100, GlobalController.PlayerGoldWithoutInit, false, "village");
        //    }
        //    else
        //    {
        //        GlobalController.Map = new CV_Library.Map("village_suburb_west");

        //        GlobalController.Player.Map = GlobalController.Map;
        //        GlobalController.Player.Region = "village";
        //        GlobalController.Player.Position = position;
        //        GlobalController.Player.CurrentFrame = frame;

        //    }
        //    LoadMap(GlobalController.Map.Name);
        //    GlobalController.PlayerInDoor = false;
        //    GlobalController.NpcSchedule = new List<NPCSchedule>();

        //    GlobalController.Npcs = new List<NPC>();
        //    foreach (NPCSchedule nsc in GlobalController.NpcSchedule)
        //    {
        //        if (nsc.MapName == GlobalController.Map.Name)
        //        {
        //            GlobalController.Npcs.Add(new NPC(nsc.Name, GlobalController.Map, nsc.Pos, Content.Load<Texture2D>(GameController.prefix_character + nsc.Name), true, new Light(ResourceController.Lights_light), nsc.HasAnotherFrame, ResourceController.Characters_character_shadow));
        //        }
        //    }
        //    GlobalController.Camera = new Camera();
        //    Camera.HandleCamera(GlobalController.Camera);
        //    if (playerIntoFunc == 1)
        //    {
        //        GlobalController.bus = null;
        //        GlobalController.BusRequest = 2;
        //        PlayerMoveSleep(3500);
        //    }


        //    //SceneLoading(root);

        //    ShowAlert("Village-Suburb-West", 2000);
        //}
        //void SceneVillage_thefarm(Vector2 position, Point frame, bool init)
        //{
        //    //XmlNode root = DataController.GetSceneNode("village_thefarm");
        //    if (init)
        //    {
        //        GlobalController.Map = new CV_Library.Map("village_thefarm");
                

        //        GlobalController.Player = new Player(GlobalController.Map, position, 2f, false, ResourceController.Characters_character_girl, true, new Light(ResourceController.Lights_light), ResourceController.Characters_character_shadow, ResourceController.Characters_character_usingtools, 100, 230, 100, 100, 100, 0, GlobalController.PlayerGoldWithoutInit, false, "village");
        //    }
        //    else
        //    {
        //        GlobalController.Map = new CV_Library.Map("village_thefarm");

        //        GlobalController.Player.Map = GlobalController.Map;
        //        GlobalController.Player.Region = "village";
        //        GlobalController.Player.Position = position;
        //        GlobalController.Player.CurrentFrame = frame;

        //    }
        //    LoadMap(GlobalController.Map.Name);
        //    GlobalController.PlayerInDoor = false;
        //    GlobalController.NpcSchedule = new List<NPCSchedule>();
        //    GlobalController.NpcSchedule.Add(new NPCSchedule("character_shopper", new List<totalInstruct> { 
        //                new totalInstruct
        //                {
        //                    mapName = "village_thefarm",
        //                    instruct = new List<instruct>
        //                    {                              
        //                    }
        //                }
        //            }, new Vector2(360f, 360f), false));

        //    GlobalController.Npcs = new List<NPC>();
        //    foreach (NPCSchedule nsc in GlobalController.NpcSchedule)
        //    {
        //        if (nsc.MapName == GlobalController.Map.Name)
        //        {
        //            GlobalController.Npcs.Add(new NPC(nsc.Name, GlobalController.Map, nsc.Pos, Content.Load<Texture2D>(GameController.prefix_character + nsc.Name), true, new Light(ResourceController.Lights_light), nsc.HasAnotherFrame, ResourceController.Characters_character_shadow));
        //        }
        //    }
        //    GlobalController.Camera = new Camera();
        //    Camera.HandleCamera(GlobalController.Camera);

        //    //SceneLoading(root);

        //    ShowAlert("Village TheFarm", 2000);
        //}       

        void LoadMap(string mapName)
        {
            GlobalController.MapTileList.Clear();
            GlobalController.TreeList.Clear();
            GlobalController.BarrierList.Clear();
            GlobalController.TriggerList.Clear();
            GlobalController.BushList.Clear();
            GlobalController.FlowerList.Clear();
            GlobalController.DecoratList.Clear();
            GlobalController.BuildingList.Clear();
            GlobalController.WaterProduceList.Clear();
            GlobalController.WCliffList.Clear();
            GlobalController.WaterInit = false;
            GlobalController.SandList.Clear();
            GlobalController.WaveList.Clear();
            GlobalController.WaterList.Clear();
            GlobalController.WaterJudge.Clear();
            GlobalController.NpcSceneCollide.Clear();
            GlobalController.DoorTriggerList.Clear();
            Random ran = new Random();


            //GameController.PlayerMoveSleep(600);
            XmlNode root = DataController.GetMapNode(mapName);
            XmlNodeList rootList = root.ChildNodes;
            foreach (XmlNode rootNode in rootList)
            {
                switch (rootNode.Name)
                {
                    case "Tiles":
                        XmlNodeList tiles = rootNode.ChildNodes;
                        foreach (XmlNode tile in tiles)
                        {
                            string context = tile.InnerText;
                            string[] inner = context.Split('|');
                            GlobalController.MapTileList.Add(new Tile(int.Parse(inner[0]), int.Parse(inner[1]), inner[2], inner[4], inner[6], inner[8], inner[10], inner[12], inner[14], int.Parse(inner[3].Split(',')[0]), int.Parse(inner[3].Split(',')[1]), int.Parse(inner[5].Split(',')[0]), int.Parse(inner[5].Split(',')[1]), int.Parse(inner[7].Split(',')[0]), int.Parse(inner[7].Split(',')[1]), int.Parse(inner[9].Split(',')[0]), int.Parse(inner[9].Split(',')[1]), int.Parse(inner[11].Split(',')[0]), int.Parse(inner[11].Split(',')[1]), int.Parse(inner[13].Split(',')[0]), int.Parse(inner[13].Split(',')[1]), int.Parse(inner[15].Split(',')[0]), int.Parse(inner[15].Split(',')[1])));
                            if (bool.Parse(inner[16]))
                            {
                                GlobalController.NpcSceneCollide.Add(new Point(int.Parse(inner[0]), int.Parse(inner[1])));
                            }
                        }
                        break;
                    case "Objects":
                        XmlNodeList objects = rootNode.ChildNodes;
                        foreach (XmlNode obj in objects)
                        {
                            string context = obj.InnerText;
                            string[] inner = context.Split('|');
                            switch (obj.Name)
                            {
                                case "PterocarpinTree":
                                    GlobalController.TreeList.Add(new PterocarpinTree(GlobalController.Map,new Vector2(int.Parse(inner[0]),int.Parse(inner[1])),ResourceController.Decorats_spring_tree,ResourceController.Decorats_tree_shadow,false));
                                    break;
                                case "KiriTree":
                                    GlobalController.TreeList.Add(new KiriTree(GlobalController.Map, new Vector2(int.Parse(inner[0]), int.Parse(inner[1])), ResourceController.Decorats_spring_tree, ResourceController.Decorats_tree_shadow, false));
                                    break;
                                case "Bush":
                                    GlobalController.BushList.Add(new Bush(GlobalController.Map,int.Parse(inner[2]),ResourceController.Decorats_spring_shrub,new Vector2(int.Parse(inner[0]),int.Parse(inner[1]))));
                                    break;
                                case "Flower":
                                    GlobalController.FlowerList.Add(new Flower(GlobalController.Map, ResourceController.Decorats_spring_decorat, new Vector2(int.Parse(inner[0]), int.Parse(inner[1])), ran.Next(800, 1200)));
                                    break;
                                case "Decorats":
                                    GlobalController.DecoratList.Add(new Decorats(GlobalController.Map, ResourceController.Decorats_spring_decorat, new Vector2(int.Parse(inner[0]), int.Parse(inner[1])), int.Parse(inner[2])));
                                    break;
                                case "Barrier":
                                    GlobalController.BarrierList.Add(new Barrier(int.Parse(inner[0]), int.Parse(inner[1]), 1, 1));
                                    break;
                                case "Water":
                                    GlobalController.WaterProducer wp = new GlobalController.WaterProducer
                                    {
                                        position = new Vector2((int.Parse(inner[0]) + 1) * Define.UnitOFpixel, int.Parse(inner[1]) * Define.UnitOFpixel),
                                        distance = int.Parse(inner[2]) * Define.UnitOFpixel
                                    };                                    
                                    GlobalController.WaterProduceList.Add(wp);                                    
                                    break;
                                case "Trigger":
                                    GlobalController.TriggerList.Add(new Trigger(int.Parse(inner[0]), int.Parse(inner[1]), int.Parse(inner[2]), int.Parse(inner[3]), int.Parse(inner[4])));
                                    break;
                                case "DoorTrigger":
                                    GlobalController.DoorTriggerList.Add(new Trigger(int.Parse(inner[0]), int.Parse(inner[1]), int.Parse(inner[2]), int.Parse(inner[3]), int.Parse(inner[4])));
                                    break;
                                //case "NpcTrigger":
                                //    GlobalController.NpcTriggerList.Add(new GlobalController.NpcTrigger{
                                //        position = new Vector2(int.Parse(inner[0]), int.Parse(inner[1])),
                                //        map = new Map(inner[2]),
                                //        targetPosition = new Vector2(int.Parse(inner[3]), int.Parse(inner[4]))
                                //    });
                                //    break;
                                case "Cliff":
                                    GlobalController.WCliffList.Add(new WCliff(GlobalController.Map, int.Parse(inner[2]), ResourceController.Scenes_water, new Vector2(int.Parse(inner[0]), int.Parse(inner[1]))));
                                    break;
                                case "Building":
                                    GlobalController.BuildingList.Add(Building.CreateBuildingFactory(GlobalController.Map, new Vector2(int.Parse(inner[0]), int.Parse(inner[1])), inner[2]));
                                    break;
                                case "Wave":
                                    GlobalController.WaveList.Add(new Wave
                                        (ResourceController.Scenes_water, GlobalController.Map, new Vector2(int.Parse(inner[0]), int.Parse(inner[1])), inner[2]));
                                    break;
                                case "Sand":
                                    GlobalController.SandList.Add(new Sand(ResourceController.Tiles_Decorats_1, GlobalController.Map, new Vector2(int.Parse(inner[0]), int.Parse(inner[1])), inner[2]));
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
        }
    }
}
