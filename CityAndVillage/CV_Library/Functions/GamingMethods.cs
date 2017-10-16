using CV_Library.Controllers;
using CV_Library.GameObjects.Buildings;
using CV_Library.GameObjects.Characters;
using CV_Library.GameObjects.Characters.Animals;
using CV_Library.GameObjects.Items;
using CV_Library.GameObjects.Soils;
using CV_Library.GameObjects.Trees;
using CV_Library.Globals;
using CV_Library.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CV_Library.Functions
{

    public class GamingMethods
    {
        //spriteBatch.Draw(加载的图片,针对于屏幕来说开始画的位置，针对于图片来说剪裁的矩形位置和大小，图片渲染颜色（可做夜晚效果？），旋转，针对于图片的原点位置，缩放，渲染效果，层深度)
        public void _Global_Show_UI(SpriteBatch b)
        {
            b.Draw(ResourceController.UI_ordinary, UserInterface.UserInfo.Pos, UserInterface.UserInfo.Rect, UserInterface.UserInfo.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.UserInfo.LayerDepth);
            b.Draw(ResourceController.UI_ordinary, UserInterface.UserInfoHunger.Pos, UserInterface.UserInfoHunger.Rect, UserInterface.UserInfoHunger.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.UserInfoHunger.LayerDepth);
            b.Draw(ResourceController.UI_ordinary, UserInterface.UserInfoHabitus.Pos, UserInterface.UserInfoHabitus.Rect, UserInterface.UserInfoHabitus.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.UserInfoHabitus.LayerDepth);
            b.Draw(ResourceController.UI_ordinary, UserInterface.UserInfoHPPos, UserInterface.UserInfoHPRect, UserInterface.UserInfoHPColor, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.UserInfoHPLD);
            b.Draw(ResourceController.UI_ordinary, UserInterface.UserInfoEPos, UserInterface.UserInfoERect, UserInterface.UserInfoEColor, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.UserInfoELD);

            b.Draw(ResourceController.UI_calendar, UserInterface.Calendar.Pos, UserInterface.Calendar.Rect, UserInterface.Calendar.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.Calendar.LayerDepth);
            b.Draw(ResourceController.UI_calendar, UserInterface.CalendarConditionGround.Pos, UserInterface.CalendarConditionGround.Rect, UserInterface.CalendarConditionGround.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.CalendarConditionGround.LayerDepth);
            b.Draw(ResourceController.UI_calendar, UserInterface.CalendarConditionSky.Pos, UserInterface.CalendarConditionSky.Rect, UserInterface.CalendarConditionSky.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.CalendarConditionSky.LayerDepth);
            b.Draw(ResourceController.UI_calendar, UserInterface.CalendarConditionLocation.Pos, UserInterface.CalendarConditionLocation.Rect, UserInterface.CalendarConditionLocation.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.CalendarConditionLocation.LayerDepth);
            if (GlobalController.isDayTime)
            {
                b.Draw(ResourceController.UI_calendar, UserInterface.CalendarConditionSun.Pos, UserInterface.CalendarConditionSun.Rect, UserInterface.CalendarConditionSun.Color, 0, Vector2.Zero, 2, SpriteEffects.None, UserInterface.CalendarConditionSun.LayerDepth);
            }
            if (GlobalController.isNight)
            {
                b.Draw(ResourceController.UI_calendar, UserInterface.CalendarConditionMoon.Pos, UserInterface.CalendarConditionMoon.Rect, UserInterface.CalendarConditionMoon.Color, 0, Vector2.Zero, 2, SpriteEffects.None, UserInterface.CalendarConditionMoon.LayerDepth);
            }
            b.Draw(ResourceController.UI_calendar, UserInterface.CalendarContent.Pos, UserInterface.CalendarContent.Rect, UserInterface.CalendarContent.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.CalendarContent.LayerDepth);

            Fonts.DrawTime(new Vector2(Define.windowWidth * 2 - 11 * Define.UnitOFpixel + 2, 4 * Define.UnitOFpixel + 6 ), b, Color.White, 0.745f, 2f);
            Fonts.DrawDate(new Vector2(Define.windowWidth * 2 - 12 * Define.UnitOFpixel + 140, 4 * Define.UnitOFpixel + 12), b, Color.White, 0.745f, 1f);
            Fonts.DrawDeposit(new Vector2(Define.windowWidth * 2 - 28, 160), b, Color.White, 0.745f, 2f);

            b.Draw(ResourceController.UI_calendar, UserInterface.CalendarExhibition.Pos, UserInterface.CalendarExhibition.Rect, UserInterface.CalendarExhibition.Color, 0, Vector2.Zero, 1, SpriteEffects.None, UserInterface.CalendarExhibition.LayerDepth);

            b.Draw(ResourceController.UI_ordinary, UserInterface.MenuBackpackIcon.Pos, UserInterface.MenuBackpackIcon.Rect, UserInterface.MenuBackpackIcon.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.MenuBackpackIcon.LayerDepth);
            b.Draw(ResourceController.UI_ordinary, UserInterface.MenuPersonalIcon.Pos, UserInterface.MenuPersonalIcon.Rect, UserInterface.MenuPersonalIcon.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.MenuPersonalIcon.LayerDepth);
            b.Draw(ResourceController.UI_ordinary, UserInterface.MenuSkillIcon.Pos, UserInterface.MenuSkillIcon.Rect, UserInterface.MenuSkillIcon.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.MenuSkillIcon.LayerDepth);
            b.Draw(ResourceController.UI_ordinary, UserInterface.MenuContactIcon.Pos, UserInterface.MenuContactIcon.Rect, UserInterface.MenuContactIcon.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.MenuContactIcon.LayerDepth);
            b.Draw(ResourceController.UI_ordinary, UserInterface.MenuSettingsIcon.Pos, UserInterface.MenuSettingsIcon.Rect, UserInterface.MenuSettingsIcon.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.MenuSettingsIcon.LayerDepth);

            _Global_OperateBackpack(b);
            _Global_OperateItemWithMouse(b);
            _Global_OperateProgress(b);
            _Global_OperateAlert(b);
            _Global_OperateBanner(b);
            _Global_OperateRapidList(b);
            _Global_OperateCoversation(b);
            _Global_OperateShopping(b);
            _Global_OperateFishingSys(b);

            foreach (Button btn in GlobalController.buttonList)
            {
                btn.Draw(b);
            }
        }

        void _Global_OperateBackpack(SpriteBatch b)
        {
            if (GlobalController.BaggageOut)
            {
                b.Draw(ResourceController.UI_personalMsg, UserInterface.MenuPersonalMsg.Pos, UserInterface.MenuPersonalMsg.Rect, UserInterface.MenuPersonalMsg.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.MenuPersonalMsg.LayerDepth);

                b.Draw(ResourceController.UI_baggagelist, UserInterface.MenuBackpack.Pos, UserInterface.MenuBackpack.Rect, UserInterface.MenuBackpack.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.MenuBackpack.LayerDepth);

                foreach (Inventory inventory in GlobalController.InventoryList)
                {
                    if (!inventory.IsNull)
                    {
                        b.Draw(inventory.Item.Texture, new Vector2((Define.windowWidth * 2 - 888) / 2 + 384 + 75 + 48 * ((inventory.Index - 1) % 8), Define.windowHeight - 240 + 44 + 48 * (int)((inventory.Index - 1) / 8)), inventory.Item.RenderRectangle, inventory.Item.RenderColor, inventory.Item.Rotation, inventory.Item.Origin, 2f, inventory.Item.SpriteEffects, 0.81f);
                        if (inventory.Count > 1)
                        {
                            if (inventory.Count >= 10)
                            {
                                Fonts.DrawString(inventory.Count.ToString(), new Vector2((Define.windowWidth * 2 - 888) / 2 + 384 + 75 + 48 * ((inventory.Index - 1) % 8) + 21, Define.windowHeight - 240 + 44 + 48 * (int)((inventory.Index - 1) / 8) + 30), b, Color.White, 0.811f, 1, 30);
                            }
                            else
                            {
                                Fonts.DrawString(inventory.Count.ToString(), new Vector2((Define.windowWidth * 2 - 888) / 2 + 384 + 75 + 48 * ((inventory.Index - 1) % 8) + 35, Define.windowHeight - 240 + 44 + 48 * (int)((inventory.Index - 1) / 8) + 30), b, Color.White, 0.811f, 1, 30);
                            }
                           
                        }

                    }
                }
                //if (!GlobalController.BaggageBanner.IsNull)
                //{
                //    Fonts.DrawString(GlobalController.BaggageBanner.Item.Name, new Vector2(Define.windowWidth + 115, Define.windowHeight - 160), b, Color.Black, 0.815f, 1f, 30);
                //    Fonts.DrawSysFont(GlobalController.BaggageBanner.Item.Category, new Vector2(Define.windowWidth + 115, Define.windowHeight - 135), b, Color.Green, 0.815f, 1, 30);
                //    Fonts.DrawSysFont(GlobalController.BaggageBanner.Item.Introduction, new Vector2(Define.windowWidth + 115, Define.windowHeight - 120), b, Color.Black, 0.815f, 1, 25);
                //}
                
            }
        }

        void _Global_OperateFishingSys(SpriteBatch b)
        {
            if (GlobalController.PlayerIsFishing)
            {
                GlobalController.FishingSys.Draw(b);
            }
        }

        void _Global_OperateItemWithMouse(SpriteBatch b)
        {
            if (GlobalController.InventWithMouse.Count == 0)
            {
                GlobalController.InventWithMouse.Clear();
            }
            if (!GlobalController.InventWithMouse.IsNull)
            {
                if (GlobalController.InventWithMouse.Item as Property == null || !(GlobalController.InventWithMouse.Item as Property).IsConstruct)
                {
                    b.Draw(GlobalController.InventWithMouse.Item.Texture, new Vector2(GlobalController.MouseState.X - Define.UnitOFpixel, GlobalController.MouseState.Y - Define.UnitOFpixel), GlobalController.InventWithMouse.Item.RenderRectangle, GlobalController.InventWithMouse.Item.RenderColor, GlobalController.InventWithMouse.Item.Rotation, GlobalController.InventWithMouse.Item.Origin, 2, GlobalController.InventWithMouse.Item.SpriteEffects, 0.89f);
                    if (GlobalController.InventWithMouse.Count > 1)
                    {
                        if (GlobalController.InventWithMouse.Count >= 10)
                        {
                            Fonts.DrawString(GlobalController.InventWithMouse.Count.ToString(), new Vector2(GlobalController.MouseState.X - 3, GlobalController.MouseState.Y + 6), b, Color.White, 0.891f, 1, 30);
                        }
                        else
                        {
                            Fonts.DrawString(GlobalController.InventWithMouse.Count.ToString(), new Vector2(GlobalController.MouseState.X + 11, GlobalController.MouseState.Y + 6), b, Color.White, 0.891f, 1, 30);
                        }
                    }
                
                }
                else
                {
                    Property pro = GlobalController.InventWithMouse.Item as Property;
                    Vector2 mousePos = Camera.HandleScreenPostoLocal(new Vector2(GlobalController.MouseState.X, GlobalController.MouseState.Y), GlobalController.Camera);
                    if (pro.Id == "04_002")
                    {
                        bool isWater = false;
                        foreach (Vector2 item in GlobalController.WaterJudge)
                        {
                            if (mousePos.X >= item.X && item.X + Define.UnitOFpixel >= mousePos.X && mousePos.Y >= item.Y && item.Y + Define.UnitOFpixel >= mousePos.Y)
                            {
                                isWater = true;
                            }
                        }
                        if (isWater)
                        {
                            int xMove = (int)(mousePos.X) % 24;
                            int yMove = (int)(mousePos.Y) % 24;
                            GlobalController.Mouse.Position = new Vector2(Camera.HandlePos(new Vector2((int)(mousePos.X) - xMove, (int)(mousePos.Y) - yMove), GlobalController.Camera).X * 2, Camera.HandlePos(new Vector2((int)(mousePos.X) - xMove, (int)(mousePos.Y) - yMove), GlobalController.Camera).Y * 2);

                            Vector2[] judgePos = new Vector2[] 
                            {
                                 new Vector2((int)(mousePos.X - xMove), (int)(mousePos.Y - yMove)),
                                 new Vector2((int)(mousePos.X - xMove + 3 * Define.UnitOFpixel), (int)(mousePos.Y - yMove)),
                                 new Vector2((int)(mousePos.X - xMove), (int)(mousePos.Y - yMove + 3 * Define.UnitOFpixel)),
                                 new Vector2((int)(mousePos.X - xMove + 3 * Define.UnitOFpixel), (int)(mousePos.Y - yMove + 3 * Define.UnitOFpixel)),
                                 new Vector2((int)(mousePos.X - xMove + 1.5f * Define.UnitOFpixel), (int)(mousePos.Y - yMove + 1.5f * Define.UnitOFpixel))
                            };
                            bool suitable = true;
                            for (int i = 0; i < judgePos.Length; i++)
                            {
                                bool isExist = false;
                                foreach (Vector2 pos in GlobalController.WaterJudge)
                                {
                                    if (i == 4)
                                    {
                                        if (judgePos[i].X >= pos.X && judgePos[i].X <= pos.X + Define.UnitOFpixel && judgePos[i].Y >= pos.Y && judgePos[i].Y <= pos.Y + Define.UnitOFpixel)
                                        {
                                            isExist = true;
                                        }                                        
                                    }
                                    else if (judgePos[i] == pos)
                                    {
                                        isExist = true;
                                    }
                                }
                                if (!isExist)
                                {
                                    suitable = false;
                                    break;
                                }
                            }
                            foreach (IPlayerScene item in GlobalController.PlayerSceneList)
                            {
                                if (item.GetIntanceType() == "Construction")
                                {
                                    Construction con = item as Construction;
                                    if (con.Name == "fishnet")
                                    {
                                        bool isExist = true;
                                        for (int i = 0; i < judgePos.Length; i++)
                                        {
                                            if (judgePos[i].X >= con.Position.X && judgePos[i].X <= con.Position.X + 3 * Define.UnitOFpixel && judgePos[i].Y >= con.Position.Y && judgePos[i].Y <= con.Position.Y + 3 * Define.UnitOFpixel)
                                            {
                                                if (i == 0)
                                                {
                                                    if (judgePos[i].Y == con.Position.Y + 3 * Define.UnitOFpixel || judgePos[i].X == con.Position.X + 3 * Define.UnitOFpixel)
                                                    {
                                                        isExist = true;
                                                    }
                                                    else
                                                    {
                                                        isExist = false;
                                                    }
                                                }
                                                if (i == 1)
                                                {
                                                    if (judgePos[i].Y == con.Position.Y + 3 * Define.UnitOFpixel || judgePos[i].X == con.Position.X)
                                                    {
                                                        isExist = true;
                                                    }
                                                    else
                                                    {
                                                        isExist = false;
                                                    }
                                                }
                                                if (i == 2)
                                                {
                                                    if (judgePos[i].Y == con.Position.Y || judgePos[i].X == con.Position.X + 3 * Define.UnitOFpixel)
                                                    {
                                                        isExist = true;
                                                    }
                                                    else
                                                    {
                                                        isExist = false;
                                                    }
                                                }
                                                if (i == 3)
                                                {
                                                    if (judgePos[i].Y == con.Position.Y || judgePos[i].X == con.Position.X)
                                                    {
                                                        isExist = true;
                                                    }
                                                    else
                                                    {
                                                        isExist = false;
                                                    }
                                                }
                                                if (i == 4)
                                                {
                                                    isExist = false;
                                                }
                                            }
                                        }
                                        if (!isExist)
                                        {
                                            suitable = false;
                                        }
                                    }
                                }
                            }
                            if (Math.Sqrt(Math.Pow(GlobalController.Player.MidPos.X - judgePos[4].X, 2) + Math.Pow(GlobalController.Player.MidPos.Y - judgePos[4].Y, 2)) > 3.5f * Define.UnitOFpixel)
                            {
                                suitable = false;
                            }
                            if (suitable)
                            {
                                b.Draw(ResourceController.UI_ordinary, new Vector2(GlobalController.Mouse.Position.X, GlobalController.Mouse.Position.Y), new Rectangle(288, 1248, 3 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), Color.Green, 0, Vector2.Zero, 2, SpriteEffects.None, 0.89f);
                                if (GlobalController.MouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                                {
                                    GlobalController.PlayerSceneList.Add(Construction.CreateConstructionFactory(GlobalController.Map, judgePos[0], "fishnet"));
                                    GlobalController.InventWithMouse.Count--;
                                }
                            }
                            else
                            {
                                b.Draw(ResourceController.UI_ordinary, new Vector2(GlobalController.Mouse.Position.X, GlobalController.Mouse.Position.Y), new Rectangle(288, 1248, 3 * Define.UnitOFpixel, 3 * Define.UnitOFpixel), Color.Red, 0, Vector2.Zero, 2, SpriteEffects.None, 0.89f);
                            }
                            
                        }
                        else
                        {
                            b.Draw(GlobalController.InventWithMouse.Item.Texture, new Vector2(GlobalController.MouseState.X - Define.UnitOFpixel, GlobalController.MouseState.Y - Define.UnitOFpixel), GlobalController.InventWithMouse.Item.RenderRectangle, GlobalController.InventWithMouse.Item.RenderColor, GlobalController.InventWithMouse.Item.Rotation, GlobalController.InventWithMouse.Item.Origin, 2, GlobalController.InventWithMouse.Item.SpriteEffects, 0.89f);
                            if (GlobalController.InventWithMouse.Count > 1)
                            {
                                if (GlobalController.InventWithMouse.Count >= 10)
                                {
                                    Fonts.DrawString(GlobalController.InventWithMouse.Count.ToString(), new Vector2(GlobalController.MouseState.X - 3, GlobalController.MouseState.Y + 6), b, Color.White, 0.891f, 1, 30);
                                }
                                else
                                {
                                    Fonts.DrawString(GlobalController.InventWithMouse.Count.ToString(), new Vector2(GlobalController.MouseState.X + 11, GlobalController.MouseState.Y + 6), b, Color.White, 0.891f, 1, 30);
                                }
                            }
                        }
                    }
                   

                }
                
            }
        }

        void _Global_OperateProgress(SpriteBatch b)
        {
            if (GlobalController.ShowProgress)
            {
                b.Draw(ResourceController.UI_ordinary, new Vector2(GlobalController.Player.RenderPosition.X * 2 - Define.UnitOFpixel * 2, GlobalController.Player.RenderPosition.Y * 2 - Define.UnitOFpixel * 2), UserInterface.ProcessBack.Rect, UserInterface.ProcessBack.Color, 0, Vector2.Zero, 2, SpriteEffects.None, GlobalController.ProgressLayerDepth);
                b.Draw(ResourceController.UI_ordinary, new Vector2(GlobalController.Player.RenderPosition.X * 2 - Define.UnitOFpixel * 2 + 34, GlobalController.Player.RenderPosition.Y * 2 - Define.UnitOFpixel * 2 + 24), UserInterface.ProcessBarRect, UserInterface.ProcessBar.Color, 0, Vector2.Zero, 2, SpriteEffects.None, GlobalController.ProgressLayerDepth + 0.01f);
                Fonts.DrawSysFont(GlobalController.ProgressContent, new Vector2(GlobalController.Player.RenderPosition.X * 2 - Define.UnitOFpixel * 2 + 25, GlobalController.Player.RenderPosition.Y * 2 - Define.UnitOFpixel * 2 + 5), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), GlobalController.ProgressLayerDepth + 0.01f, 1, 30);
            }
        }

        void _Global_OperateAlert(SpriteBatch b)
        {
            if (GlobalController.ShowAlert)
            {
                b.Draw(ResourceController.UI_ordinary, GlobalController.AlertPos, UserInterface.Alert.Rect, UserInterface.Alert.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.Alert.LayerDepth);
                Fonts.DrawSysFont(GlobalController.AlertContent, new Vector2(GlobalController.AlertPos.X + 45, GlobalController.AlertPos.Y + 30), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.851f, 1, 30);
            }
        }

        void _Global_OperateBanner(SpriteBatch b)
        {
            if (GlobalController.ShowDetail)
            {
                b.Draw(ResourceController.UI_ordinary, UserInterface.Banner.Pos, UserInterface.Banner.Rect, UserInterface.Banner.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.Banner.LayerDepth);
                Fonts.DrawSysFont(GlobalController.DetailBanner, new Vector2(UserInterface.Banner.Pos.X + 30,UserInterface.Banner.Pos.Y + 25), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.81f, 1, 30);
            }
        }

        void _Global_OperateRapidList(SpriteBatch b)
        {
            if (!GlobalController.PlayerIsFishing && !GlobalController.Isshopping)
            {
                b.Draw(ResourceController.UI_ordinary, UserInterface.RapidList.Pos, UserInterface.RapidList.Rect, UserInterface.RapidList.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.RapidList.LayerDepth);             
                if (!GlobalController.SelectingRapidRoomItem.IsNull)
                {
                    b.Draw(GlobalController.SelectingRapidRoomItem.Item.Texture, new Vector2(Define.windowWidth + 79, Define.windowHeight * 2 - 55), GlobalController.SelectingRapidRoomItem.Item.RenderRectangle, Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0.751f);
                }

                foreach (Inventory inventory in GlobalController.RapidRoomList)
                {
                    if (!inventory.IsNull)
                    {
                        b.Draw(inventory.Item.Texture, new Vector2(Define.windowWidth - 6 * Define.UnitOFpixel + 24 + 48 * ((inventory.Index - 1) % 4), Define.windowHeight * 2 - 48), inventory.Item.RenderRectangle, inventory.Item.RenderColor, inventory.Item.Rotation, inventory.Item.Origin, 2, inventory.Item.SpriteEffects, 0.71f);
                        if (inventory.Count > 1)
                        {
                            if (inventory.Count >= 10)
                            {
                                Fonts.DrawString(inventory.Count.ToString(), new Vector2(Define.windowWidth - 6 * Define.UnitOFpixel + 24 + 48 * ((inventory.Index - 1) % 4) + 21, Define.windowHeight * 2 - 48 + 30), b, Color.White, 0.711f, 1f, 30);
                            }
                            else
                            {
                                Fonts.DrawString(inventory.Count.ToString(), new Vector2(Define.windowWidth - 6 * Define.UnitOFpixel + 24 + 48 * ((inventory.Index - 1) % 4) + 35, Define.windowHeight * 2 - 48 + 30), b, Color.White, 0.711f, 1f, 30);
                            }
                        }
                    }
                }
            }           
        }

        void _Global_OperateCoversation(SpriteBatch b)
        {
            if (GlobalController.isTalking)
            {
                b.Draw(ResourceController.UI_conversation, UserInterface.Dialogue.Pos, UserInterface.Dialogue.Rect, UserInterface.Dialogue.Color, 0, Vector2.Zero, 1f, SpriteEffects.None, UserInterface.Dialogue.LayerDepth);
                b.Draw(ResourceController.Characters_Lilis_pic, new Vector2(UserInterface.Dialogue.Pos.X, UserInterface.Dialogue.Pos.Y - 220), new Rectangle(0, 0, 120, 120), Color.White, 0, Vector2.Zero, 2f, SpriteEffects.None, UserInterface.Dialogue.LayerDepth - 0.001f);

                Fonts.DrawString(GlobalController.ConversationName, new Vector2(UserInterface.Dialogue.Pos.X + 48, UserInterface.Dialogue.Pos.Y + 50), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.851f, 1f, 30);
                Fonts.DrawString(GlobalController.Conversation, new Vector2(UserInterface.Dialogue.Pos.X + 48, UserInterface.Dialogue.Pos.Y + 130), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.851f, 1f, 50);
     
                if (GlobalController.SelectDialogue)
                {
                    if (GlobalController.SelectDialogueContent.Count > 0)
                    {
                        b.Draw(ResourceController.UI_ordinary, new Vector2(Define.windowWidth - 408, Define.windowHeight - 250), UserInterface.DialogueSelect.Rect, UserInterface.DialogueSelect.Color, 0, Vector2.Zero, 2, SpriteEffects.None, UserInterface.DialogueSelect.LayerDepth);
                        Fonts.DrawString(GlobalController.SelectDialogueContent[0].Split('|')[0], new Vector2(Define.windowWidth - 370, Define.windowHeight - 225), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.861f, 1f, 50);
                    }
                    
                    if (GlobalController.SelectDialogueContent.Count > 1)
                    {
                        b.Draw(ResourceController.UI_ordinary, new Vector2(Define.windowWidth - 408, Define.windowHeight - 150), UserInterface.DialogueSelect.Rect, UserInterface.DialogueSelect.Color, 0, Vector2.Zero, 2, SpriteEffects.None, UserInterface.DialogueSelect.LayerDepth);
                        Fonts.DrawString(GlobalController.SelectDialogueContent[1].Split('|')[0], new Vector2(Define.windowWidth - 370, Define.windowHeight - 125), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.861f, 1f, 50);
                    }
                    if (GlobalController.SelectDialogueContent.Count > 2)
                    {
                        b.Draw(ResourceController.UI_ordinary, new Vector2(Define.windowWidth - 408, Define.windowHeight - 50), UserInterface.DialogueSelect.Rect, UserInterface.DialogueSelect.Color, 0, Vector2.Zero, 2, SpriteEffects.None, UserInterface.DialogueSelect.LayerDepth);
                        Fonts.DrawString(GlobalController.SelectDialogueContent[2].Split('|')[0], new Vector2(Define.windowWidth - 370, Define.windowHeight - 25), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.861f, 1f, 50);
                    }

                    if (GlobalController.SelectDialogueContent.Count > 3)
                    {
                        b.Draw(ResourceController.UI_ordinary, new Vector2(Define.windowWidth - 408, Define.windowHeight + 50), UserInterface.DialogueSelect.Rect, UserInterface.DialogueSelect.Color, 0, Vector2.Zero, 2, SpriteEffects.None, UserInterface.DialogueSelect.LayerDepth);
                        Fonts.DrawString(GlobalController.SelectDialogueContent[3].Split('|')[0], new Vector2(Define.windowWidth - 370, Define.windowHeight + 75), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.861f, 1f, 50);
                    }
                }
            }
        }

        void _Global_OperateShopping(SpriteBatch b)
        {
            if (GlobalController.Isshopping)
            {
                foreach (Shops shop in GlobalController.Global_Shops)
                {
                    if (shop.Name == GlobalController.ShoppingPlace)
                    {
                        shop.Draw(b);
                    }
                }

                foreach (Shops shop in GlobalController.Global_Shops)
                {
                    if (GlobalController.ShoppingPlace == shop.Name)
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            if (shop.Index + i < shop.GoodsList.Count)
                            {
                                Fonts.DrawSysFont(shop.GoodsList[shop.Index + i].Item.Name, new Vector2(Define.windowWidth - 408 + 105, Define.windowHeight - 240 + 57 + 58 * i), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.821f, 1, 30);
                                shop.DrawMoneyIcon(b, new Vector2(Define.windowWidth - 408 + 255, Define.windowHeight - 240 + 57 + 58 * i));
                                shop.DrawSmallPic(b, new Vector2(Define.windowWidth - 408 + 68, Define.windowHeight - 240 + 51 + 58 * i), shop.GoodsList[shop.Index + i]);
                                Fonts.DrawSysFont(((int)(shop.GoodsList[shop.Index + i].Item.Price * shop.GoodsList[shop.Index + i].Discount)).ToString(), new Vector2(Define.windowWidth - 408 + 270, Define.windowHeight - 240 + 57 + 58 * i), b, shop.GoodsList[shop.Index + i].ForSaling ? Color.Green : Color.Gold, 0.821f, 1, 30);
                                Fonts.DrawSysFont(shop.GoodsList[shop.Index + i].PurchasingCount.ToString(), new Vector2(Define.windowWidth - 408 + 375, Define.windowHeight - 240 + 57 + 58 * i), b, new Color(102 / 255f, 80 / 255f, 27 / 255f), 0.821f, 1, 30);
                                shop.DrawArrows(b);
                                if (shop.GoodsList[shop.Index + i].IsSelecting)
                                {
                                    shop.DrawAddtion(b, new Vector2(Define.windowWidth - 408 + 345, Define.windowHeight - 240 + 57 + 58 * i));
                                }
                                if (shop.GoodsList[shop.Index + i].ForSaling)
                                {
                                    shop.DrawSale(b, new Vector2(Define.windowWidth - 408 + 58, Define.windowHeight - 240 + 75 + 58 * i));
                                }

                                if (shop.GoodsList[shop.Index + i].Count <= 0)
                                {
                                    shop.DrawNoInventory(b, new Vector2(Define.windowWidth - 408 + 110, Define.windowHeight - 240 + 56 + 58 * i));
                                }
                            }
                            else
                            {
                                shop.DrawNoGoods(b, new Vector2(Define.windowWidth - 408 + 110, Define.windowHeight - 240 + 56 + 58 * i));
                            }

                        }
                        shop.DrawIntroduction(b);
                    }
                }

                if (GlobalController.Player_ShoppingCart.Count > 0)
                {
                    for (int i = 0; i < GlobalController.Player_ShoppingCart.Count; i++)
                    {
                        b.Draw(GlobalController.Player_ShoppingCart[i].Item.Texture, new Vector2(Define.windowWidth - 408 + 442 + 58 * (i % 6), Define.windowHeight - 240 + 76 + 58 * (int)(i / 6)), GlobalController.Player_ShoppingCart[i].Item.RenderRectangle, GlobalController.Player_ShoppingCart[i].Item.RenderColor, GlobalController.Player_ShoppingCart[i].Item.Rotation, GlobalController.Player_ShoppingCart[i].Item.Origin, 2, GlobalController.Player_ShoppingCart[i].Item.SpriteEffects, 0.81f);
                        if (GlobalController.Player_ShoppingCart[i].Count > 1)
                        {
                            Fonts.DrawString(GlobalController.Player_ShoppingCart[i].Count.ToString(), new Vector2(Define.windowWidth - 408 + 442 + 58 * (i % 6) + 20, Define.windowHeight - 240 + 76 + 58 * (int)(i / 6) + 20), b, Color.White, 0.811f, 1, 30);
                        }
                    }
                }

            }
        }

        public void _Global_OperateGoProgress(SpriteBatch b, float progress, Vector2 position, float layerDepth,string content)
        {
            b.Draw(ResourceController.UI_ordinary, new Vector2(position.X - 10,position.Y), new Rectangle(7 * Define.UnitOFpixel, 4 * Define.UnitOFpixel, 3 * Define.UnitOFpixel, Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, layerDepth);
            b.Draw(ResourceController.UI_ordinary, new Vector2(position.X - 10, position.Y), new Rectangle(7 * Define.UnitOFpixel, 5 * Define.UnitOFpixel, 17 + (int)(32 * progress), Define.UnitOFpixel), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, layerDepth + 0.01f);
            Fonts.DrawSysFont(content, new Vector2(position.X + 10, position.Y + 3), b, Color.Black, layerDepth + 0.01f, 0.5f, 30);
        }

        public void _Global_OperateEmotion(SpriteBatch b, string emotion, Vector2 position, float layerDepth)
        {
            Rectangle rect = new Rectangle(0, 0, Define.UnitOFpixel, Define.UnitOFpixel);
            switch (emotion)
            {
                case "heart":
                    rect.X = 0 * Define.UnitOFpixel;
                    rect.Y = 1 * Define.UnitOFpixel;
                    break;
                case "angry":
                    rect.X = 1 * Define.UnitOFpixel;
                    rect.Y = 1 * Define.UnitOFpixel;
                    break;
                case "nosay":
                    rect.X = 2 * Define.UnitOFpixel;
                    rect.Y = 1 * Define.UnitOFpixel;
                    break;
                case "music":
                    rect.X = 3 * Define.UnitOFpixel;
                    rect.Y = 1 * Define.UnitOFpixel;
                    break;
                case "sweat":
                    rect.X = 4 * Define.UnitOFpixel;
                    rect.Y = 1 * Define.UnitOFpixel;
                    break;
                case "amaze":
                    rect.X = 5 * Define.UnitOFpixel;
                    rect.Y = 1 * Define.UnitOFpixel;
                    break;
                case "question":
                    rect.X = 6 * Define.UnitOFpixel;
                    rect.Y = 1 * Define.UnitOFpixel;
                    break;
                case "sad":
                    rect.X = 7 * Define.UnitOFpixel;
                    rect.Y = 1 * Define.UnitOFpixel;
                    break;
                case "hi":
                    rect.X = 0 * Define.UnitOFpixel;
                    rect.Y = 2 * Define.UnitOFpixel;
                    break;
                case "hungry":
                    rect.X = 1 * Define.UnitOFpixel;
                    rect.Y = 2 * Define.UnitOFpixel;
                    break;
                default:
                    break;
            }
            b.Draw(ResourceController.UI_bubble, position, rect, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, layerDepth);
        }

        public void _Global_CreateMapTile(SpriteBatch b)
        {
            int tileX = Define.windowWidth / Define.UnitOFpixel + 4;
            int tileY = Define.windowHeight / Define.UnitOFpixel + 4;
            Vector2 ltPos = new Vector2(GlobalController.Map.RenderRectangle.X / Define.UnitOFpixel - 2, GlobalController.Map.RenderRectangle.Y / Define.UnitOFpixel - 2);


            foreach (Tile tile in GlobalController.MapTileList)
            {
                if (ltPos.X <= tile.X && tile.X <= ltPos.X + tileX && ltPos.Y <= tile.Y && tile.Y <= ltPos.Y + tileY)
                {
                    if (tile.Name_layer1 != "none")
                    {
                        tile.DrawLayer_1(b, tile.Name_layer1);
                    }
                    if (tile.Name_layer2_1 != "none")
                    {
                        tile.DrawLayer_2_1(b, tile.Name_layer2_1);
                    }
                    if (tile.Name_layer2_2 != "none")
                    {
                        tile.DrawLayer_2_2(b, tile.Name_layer2_2);
                    }
                    if (tile.Name_layer2_3 != "none")
                    {
                        tile.DrawLayer_2_3(b, tile.Name_layer2_3);
                    }
                    if (tile.Name_layer3_1 != "none")
                    {
                        tile.DrawLayer_3_1(b, tile.Name_layer3_1);
                    }
                    if (tile.Name_layer3_2 != "none")
                    {
                        tile.DrawLayer_3_2(b, tile.Name_layer3_2);
                    }
                    if (tile.Name_layer3_3 != "none")
                    {
                        tile.DrawLayer_3_3(b, tile.Name_layer3_3);
                    }
                }

            }
            foreach (IGlobalScene item in GlobalController.WaterList)
            {
                if (item.GetMap() == GlobalController.Map.Name)
                {
                    if (ltPos.X <= (item.GetInstance() as Water).Position.X / Define.UnitOFpixel && (item.GetInstance() as Water).Position.X / Define.UnitOFpixel <= ltPos.X + tileX && ltPos.Y <= (item.GetInstance() as Water).Position.Y / Define.UnitOFpixel && (item.GetInstance() as Water).Position.Y / Define.UnitOFpixel <= ltPos.Y + tileY)
                    {
                        item.Draw(b);
                    }
                    
                }

            }
            foreach (IGlobalScene item in GlobalController.WCliffList)
            {
                if (item.GetMap() == GlobalController.Map.Name)
                {
                    if (ltPos.X <= (item.GetInstance() as WCliff).Position.X / Define.UnitOFpixel && (item.GetInstance() as WCliff).Position.X / Define.UnitOFpixel <= ltPos.X + tileX && ltPos.Y <= (item.GetInstance() as WCliff).Position.Y / Define.UnitOFpixel && (item.GetInstance() as WCliff).Position.Y / Define.UnitOFpixel <= ltPos.Y + tileY)
                    {
                        item.Draw(b);
                    }

                }

            }

            foreach (IGlobalScene item in GlobalController.WaveList)
            {
                if (ltPos.X <= (item.GetInstance() as Wave).Position.X / Define.UnitOFpixel && (item.GetInstance() as Wave).Position.X / Define.UnitOFpixel <= ltPos.X + tileX && ltPos.Y <= (item.GetInstance() as Wave).Position.Y / Define.UnitOFpixel && (item.GetInstance() as Wave).Position.Y / Define.UnitOFpixel <= ltPos.Y + tileY)
                {
                    item.Draw(b);
                }
            }

            foreach (IGlobalScene item in GlobalController.SandList)
            {
                if (ltPos.X <= (item.GetInstance() as Sand).Position.X / Define.UnitOFpixel && (item.GetInstance() as Sand).Position.X / Define.UnitOFpixel <= ltPos.X + tileX && ltPos.Y <= (item.GetInstance() as Sand).Position.Y / Define.UnitOFpixel && (item.GetInstance() as Sand).Position.Y / Define.UnitOFpixel <= ltPos.Y + tileY)
                {
                    item.Draw(b);
                }
            }

            foreach (Tree tree in GlobalController.TreeList)
            {
                if (tree.GetMap() == GlobalController.Map.Name)
                {
                    tree.Draw(b);
                }
            }
            foreach (Leaf leaf in GlobalController.LeafList)
            {
                if (leaf.GetMap() == GlobalController.Map.Name)
                {
                    if (ltPos.X <= (leaf.GetInstance() as Leaf).Position.X / Define.UnitOFpixel && (leaf.GetInstance() as Leaf).Position.X / Define.UnitOFpixel <= ltPos.X + tileX && ltPos.Y <= (leaf.GetInstance() as Leaf).Position.Y / Define.UnitOFpixel && (leaf.GetInstance() as Leaf).Position.Y / Define.UnitOFpixel <= ltPos.Y + tileY)
                    {
                        leaf.Draw(b);
                    }
                }
            }

            foreach (Building building in GlobalController.BuildingList)
            {
                if (building.GetMap() == GlobalController.Map.Name)
                {
                    building.Draw(b);
                }
            }
            foreach (Animals animal in GlobalController.AnimalsList)
            {
                if (animal.GetMap() == GlobalController.Map.Name)
                {
                    animal.Draw(b);
                }
            }
        }       

        public void _Global_ChangingSceneTrigger(int index)
        {
            if (GlobalController.Player.Region == "city" && GlobalController.CollidingTrigger.Collider.Width != 24)
            {
                GlobalController.Player.CollideTriggerXMove = (int)GlobalController.Player.Position.X - GlobalController.CollidingTrigger.Collider.X;
            }
            if (GlobalController.Player.Region == "city" && GlobalController.CollidingTrigger.Collider.Height != 24)
            {
                GlobalController.Player.CollideTriggerYMove = (int)GlobalController.Player.Position.Y - GlobalController.CollidingTrigger.Collider.Y;
            }
            GlobalController.CollidingTrigger = null;

            switch (GlobalController.Map.Name)
            {
                #region town Trigger
                case "town_centre":
                    switch (index)
                    {
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_suburb",
                                func = 1
                            };
                            break;
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_east",
                                func = 1
                            };
                            break;
                        case 42:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_station",
                                func = 1
                            };
                            break;
                        default:
                            break;
                    }
                    break;

                case "town_suburb":
                    switch (index)
                    {
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_west",
                                func = 1
                            };
                            break;
                        case 32:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_southriver",
                                func = 1
                            };
                            break;
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_centre",
                                func = 1
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "town_station":
                    switch (index)
                    {
                        case 11:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_east",
                                func = 2
                            };
                            break;
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_centre",
                                func = 2
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "town_west":
                    switch (index)
                    {
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_southriver",
                                func = 2
                            };
                            break;
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_suburb",
                                func = 2
                            };
                            break;                       
                        default:
                            break;
                    }
                    break;

                case "town_east":
                    switch (index)
                    {
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_centre",
                                func = 3
                            };
                            break;
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_station",
                                func = 2
                            };
                            break;                       
                        default:
                            break;
                    }
                    break;
                case "town_southriver":
                    switch (index)
                    {
                        case 11:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_west",
                                func = 2
                            };
                            break;
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_suburb",
                                func = 3
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion

                #region village Trigger
                case "village_suburb_west":
                    switch (index)
                    {
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_thefarm",
                                func = 1
                            };
                            break;
                        case 42:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_suburb_east",
                                func = 1
                            };
                            break;
                        case 12:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 1
                            };
                            break;
                        case 11:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_northfarm",
                                func = 2
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_suburb_east":
                    switch (index)
                    {
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_suburb_west",
                                func = 3
                            };
                            break;
                        case 11:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_thefarm",
                                func = 3
                            };
                            break;
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_lake",
                                func = 1
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_thefarm":
                    switch (index)
                    {
                        case 32:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_suburb_west",
                                func = 2
                            };
                            break;
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_suburb_east",
                                func = 2
                            };
                            break;
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_lake",
                                func = 2
                            };
                            break;
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 2
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "town_hospital_indoor_first":
                    switch (index)
                    {
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "town_downtown",
                                func = 3
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_lake":
                    switch (index)
                    {
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_thefarm",
                                func = 4
                            };
                            break;
                        case 32:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_suburb_east",
                                func = 3
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_centre":
                    switch (index)
                    {
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_suburb_west",
                                func = 4
                            };
                            break;
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_thefarm",
                                func = 5
                            };
                            break;
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_northfarm",
                                func = 1
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_northfarm":
                    switch (index)
                    {
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 3
                            };
                            break;
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_suburb_west",
                                func = 5
                            };
                            break;
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_ambi",
                                func = 1
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_ambi":
                    switch (index)
                    {
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_northfarm",
                                func = 3
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion

                #region city Trigger
                case "city_entry":
                    switch (index)
                    {
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_busstation",
                                func = 3
                            };
                            break;                       
                        default:
                            break;
                    }
                    break;
                case "city_busstation":
                    switch (index)
                    {
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_entry",
                                func = 1
                            };
                            break;
                        case 11:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_slumarea",
                                func = 1
                            };
                            break;
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_station",
                                func = 1
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "city_slumarea":
                    switch (index)
                    {
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_busstation",
                                func = 1
                            };
                            break;
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_market",
                                func = 1
                            };
                            break;                        
                        default:
                            break;
                    }
                    break;
                case "city_market":
                    switch (index)
                    {
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_centre",
                                func = 1
                            };
                            break;
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_slumarea",
                                func = 2
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "city_station":
                    switch (index)
                    {
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_busstation",
                                func = 2
                            };
                            break;
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_buildingsite",
                                func = 7
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "city_centre":
                    switch (index)
                    {
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_villa",
                                func = 1
                            };
                            break;
                        case 32:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_villa",
                                func = 2
                            };
                            break;
                        case 33:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_park",
                                func = 2
                            };
                            break;
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_buildingsite",
                                func = 2
                            };
                            break;
                        case 22:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_buildingsite",
                                func = 1
                            };
                            break;
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_market",
                                func = 2
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "city_buildingsite":
                    switch (index)
                    {
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_park",
                                func = 3
                            };
                            break;
                        case 32:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_school",
                                func = 2
                            };
                            break;
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_suburb",
                                func = 2
                            };
                            break;
                        case 22:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_suburb",
                                func = 1
                            };
                            break;
                        case 11:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_centre",
                                func = 3
                            };
                            break;
                        case 12:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_centre",
                                func = 2
                            };
                            break;
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_station",
                                func = 2
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "city_suburb":
                    switch (index)
                    {
                        case 11:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_buildingsite",
                                func = 5
                            };
                            break;
                        case 12:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_buildingsite",
                                func = 6
                            };
                            break;
                        case 31:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_school",
                                func = 3
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "city_villa":
                    switch (index)
                    {
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_centre",
                                func = 6
                            };
                            break;
                        case 42:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_centre",
                                func = 5
                            };
                            break;
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_park",
                                func = 1
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "city_park":
                    switch (index)
                    {
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_centre",
                                func = 4
                            };
                            break;
                        case 42:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_buildingsite",
                                func = 3
                            };
                            break;
                        case 21:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_school",
                                func = 1
                            };
                            break;
                        case 11:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_villa",
                                func = 3
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "city_school":
                    switch (index)
                    {
                        case 41:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_buildingsite",
                                func = 4
                            };
                            break;
                        case 42:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_suburb",
                                func = 3
                            };
                            break;
                        case 11:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "city_park",
                                func = 4
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion

                #region inDoor Trigger
                case "village_farmhouse":
                    switch (index)
                    {
                        case 2:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_thefarm",
                                func = 2
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_centre_clinic":
                    switch (index)
                    {
                        case 2:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 4
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_centre_hotel":
                    switch (index)
                    {
                        case 2:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 5
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_centre_restaurant":
                    switch (index)
                    {
                        case 2:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 6
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_centre_managehouse":
                    switch (index)
                    {
                        case 2:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 7
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_centre_house1":
                    switch (index)
                    {
                        case 2:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 8
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_centre_house2":
                    switch (index)
                    {
                        case 2:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 9
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_centre_toolhouse":
                    switch (index)
                    {
                        case 2:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 10
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                case "village_centre_shop":
                    switch (index)
                    {
                        case 2:
                            GlobalController.SStatus = new GlobalController.Cs
                            {
                                cName = "village_centre",
                                func = 11
                            };
                            break;
                        default:
                            break;
                    }
                    break;
                #endregion

                default:
                    break;
            }
        }

        public void _Global_NpcFrame_ConversationHandler(NPC npc, int npcDirect, int playerDirect)
        {
            GlobalController.isTalking = true;
            GlobalController.Player.Direct = playerDirect;
            npc.Direct = npcDirect;

            //TODO base on npc & time & date & emotion... to find what are able to say
            //GlobalController.ConversationOptionSelect.Add(npc.Name);
            //the sentence data structure is 
            //[0]:npc Name
            //[1]:npc Event --- base on what conversation event is going on -- dont forget it
            //[2]~[n]:player Options
            //GlobalController.ConversationContent -- whole conversation content
            //format: talk sentence|next index |(if need) GlobalController.ConversationOptionSelect
            //GlobalController.ConversationIndex -- conversation on which step
            //GlobalController.ConversationOptionSelect would not be execute or clear(Game1) until conversation is over
            GlobalController.ConversationContent.Clear();
            GlobalController.ConversationName = npc.Name;
            XmlNode conversationNode = DataController.GetConversationNode();

            foreach (XmlNode node in conversationNode)
            {
                if (node.Name == npc.Name)
                {
                    //TODO circumstance judge test
                    foreach (XmlNode dialogueHandle in node)
                    {
                        if (dialogueHandle.Name == "regular")
                        {
                            foreach (XmlNode dialogue in dialogueHandle)
                            {
                                if (dialogue.Name == "dialogue")
                                {
                                    string[] contexts = dialogue.InnerText.Split('^');
                                    for (int i = 0; i < contexts.Length - 1; i++)
                                    {
                                        GlobalController.ConversationContent.Add(contexts[i]);
                                    }
                                    string[] endingMark = contexts[contexts.Length - 1].Split('|');
                                    GlobalController.ConversationContent.Add(endingMark[0]);
                                    GlobalController.ConversationOptionSelect.Add(npc.Name);
                                    if (endingMark.Length > 1)
                                    {
                                        for (int i = 1; i < endingMark.Length; i++)
                                        {
                                            GlobalController.ConversationOptionSelect.Add(endingMark[i]);
                                        }                                        
                                    }
                                }
                            }
                        }
                    }                    
                }
            }
            GlobalController.ConversationIndex = 0;
            GlobalController.Conversation = GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[0];
            GlobalController.ConversationIndex = Convert.ToInt32(GlobalController.ConversationContent[GlobalController.ConversationIndex].Split('|')[1]);

        }

        public void _Global_Giving(GameObject goTarget,string goType)
        {
            switch (goType)
            {
                case "Chest":
                    for (int i = 0; i < (goTarget as Chest).Inventries.Count; i++)
                    {
                        if ((goTarget as Chest).Inventries[i].IsNull)
                        {
                            (goTarget as Chest).Inventries[i].AddItem(GlobalController.InventWithMouse.Item.Clone(), GlobalController.InventWithMouse.Count);
                            GlobalController.InventWithMouse.Clear();
                            break;
                        }
                    }

                    break;
                default:
                    break;
            }
        }

        public void _Global_PickItem(OutDoorItem item_para)
        {
            _Global_AddNewItemToBag(item_para.Item);
            GlobalController.OutdoorItemsList.Remove(item_para);
        }

        public void _Global_AddNewItemToBag(Item item)
        {
            bool isRapidRoomFull = true;
            for (int i = 0; i < GlobalController.RapidRoomCount; i++)
            {
                if (GlobalController.RapidRoomList[i].IsNull)
                {
                    isRapidRoomFull = false;
                }
                else
                {
                    if (GlobalController.RapidRoomList[i].Item.Id == item.Id)
                    {
                        isRapidRoomFull = false;
                    }
                }
            }

            if (isRapidRoomFull)
            {
                bool isItemExist = false;
                for (int j = 0; j < GlobalController.InventoryCount; j++)
                {
                    if (GlobalController.InventoryList[j].Item != null)
                    {
                        if (GlobalController.InventoryList[j].Item.Id == item.Id)
                        {
                            GlobalController.InventoryList[j].Count += 1;
                            isItemExist = true;
                        }
                    }
                }
                if (!isItemExist)
                {
                    for (int j = 0; j < GlobalController.InventoryCount; j++)
                    {
                        if (GlobalController.InventoryList[j].IsNull)
                        {
                            GlobalController.InventoryList[j].Item = item;
                            GlobalController.InventoryList[j].IsNull = false;
                            GlobalController.InventoryList[j].Count += 1;
                            break;
                        }
                    }
                }
            }
            else
            {
                bool isItemExist = false;
                for (int j = 0; j < GlobalController.RapidRoomCount; j++)
                {
                    if (GlobalController.RapidRoomList[j].Item != null)
                    {
                        if (GlobalController.RapidRoomList[j].Item.Id == item.Id)
                        {
                            GlobalController.RapidRoomList[j].Count += 1;
                            isItemExist = true;
                        }
                    }
                }
                if (!isItemExist)
                {
                    for (int j = 0; j < GlobalController.RapidRoomCount; j++)
                    {
                        if (GlobalController.RapidRoomList[j].IsNull)
                        {
                            GlobalController.RapidRoomList[j].Item = item;
                            GlobalController.RapidRoomList[j].IsNull = false;
                            GlobalController.RapidRoomList[j].Count += 1;
                            break;
                        }
                    }
                }
            }

        }

        public void _Global_OutDoorItemFactory(string itemID,Vector2 position,string mapName)
        {
            GlobalController.OutdoorItemsList.Add(new OutDoorItem(new Map(mapName), position, Item.ItemCreateFactory(itemID)));
        }

        /// <summary>
        /// a = 左上角距中心偏移x; b = 左上角距中心偏移y;c = Math.Sqrt(a * a + b * b); this.eagle = Math.Asin(a / c);
        /// </summary>
        /// <param name="eagle">夹角Math.Asin(a / c)</param>
        /// <param name="c">斜边(左上角距旋转中心点的距离,非单位值)</param>
        /// <param name="rotationPoint">旋转中心点</param>
        /// <returns></returns>
        public Vector2 _Global_ItemShake(double eagle, double c, Vector2 rotationPoint)
        {
            double a = Math.Sin(eagle) * c;
            double b = Math.Cos(eagle) * c;
            return new Vector2((float)(rotationPoint.X - a), (float)(rotationPoint.Y - b));
        }

        public void _Agriculture_Seed(int int_para)
        {
            GlobalController.SoilList[int_para].IsSeeded = true;
            Item seed = GlobalController.SelectingRapidRoomItem.Item;
            GlobalController.SoilList[int_para].Seed = (Seeds)seed.Clone();
            GlobalController.SelectingRapidRoomItem.Count -= 1;
        }

        public void _Agriculture_Watering(Vector2 vector2_para)
        {
            for (int i = 0; i < GlobalController.SoilList.Count; i++)
            {
                if (GlobalController.SoilList[i].Position == vector2_para)
                {
                    //TODO include kettle
                    GlobalController.SoilList[i].WaterContent += 500;

                }
            }
            GlobalController.Player.Energy -= 2.78f;
        }

        public void _Agriculture_HarvestItem(int int_para)
        {
            bool isRapidRoomFull = true;
            for (int i = 0; i < GlobalController.RapidRoomCount; i++)
            {
                if (GlobalController.RapidRoomList[i].IsNull)
                {
                    isRapidRoomFull = false;
                }
                else
                {
                    if (GlobalController.RapidRoomList[i].Item.Id == GlobalController.SoilList[int_para].Seed.HarvestThing.Id)
                    {
                        isRapidRoomFull = false;
                    }
                }
            }

            if (isRapidRoomFull)
            {
                bool isItemExist = false;
                for (int j = 0; j < GlobalController.InventoryCount; j++)
                {
                    if (GlobalController.InventoryList[j].Item != null)
                    {
                        if (GlobalController.InventoryList[j].Item.Id == GlobalController.SoilList[int_para].Seed.HarvestThing.Id)
                        {
                            GlobalController.InventoryList[j].Count += GlobalController.SoilList[int_para].Seed.HarvastNum;
                            isItemExist = true;
                        }
                    }
                }
                if (!isItemExist)
                {
                    for (int j = 0; j < GlobalController.InventoryCount; j++)
                    {
                        if (GlobalController.InventoryList[j].IsNull)
                        {
                            GlobalController.InventoryList[j].Item = GlobalController.SoilList[int_para].Seed.HarvestThing;
                            GlobalController.InventoryList[j].IsNull = false;
                            GlobalController.InventoryList[j].Count += GlobalController.SoilList[int_para].Seed.HarvastNum;
                            break;
                        }
                    }
                }
            }
            else
            {
                bool isItemExist = false;
                for (int j = 0; j < GlobalController.RapidRoomCount; j++)
                {
                    if (GlobalController.RapidRoomList[j].Item != null)
                    {
                        if (GlobalController.RapidRoomList[j].Item.Id == GlobalController.SoilList[int_para].Seed.HarvestThing.Id)
                        {
                            GlobalController.RapidRoomList[j].Count += GlobalController.SoilList[int_para].Seed.HarvastNum;
                            isItemExist = true;
                        }
                    }
                }
                if (!isItemExist)
                {
                    for (int j = 0; j < GlobalController.RapidRoomCount; j++)
                    {
                        if (GlobalController.RapidRoomList[j].IsNull)
                        {
                            GlobalController.RapidRoomList[j].Item = GlobalController.SoilList[int_para].Seed.HarvestThing;
                            GlobalController.RapidRoomList[j].IsNull = false;
                            GlobalController.RapidRoomList[j].Count += GlobalController.SoilList[int_para].Seed.HarvastNum;
                            break;
                        }
                    }
                }
            }
            GlobalController.SoilList[int_para].Seed = Seeds.Null;
            GlobalController.SoilList[int_para].IsSeeded = false;
        }

        public void _Agriculture_DoReclaim(Vector2 position)
        {
            GlobalController.SoilList.Add(new GameObjects.Soils.Soil(ResourceController.Scenes_soil, GlobalController.Player.Map, position, 0, Seeds.Null, false));
            GlobalController.Player.Energy -= 2.78f;
        }

        public void _Logging_CutTree(Tree tree)
        {
            if (!tree.IsDroping)
            {
                tree.Hp -= (GlobalController.SelectingRapidRoomItem.Item as Tools).Damage;
                if (tree.Hp <= 0)
                {
                    if (GlobalController.Player.Direct == 0 || GlobalController.Player.Direct == 1)
                    {
                        tree.DropDirect = "left";
                    }
                    else
                    {
                        tree.DropDirect = "right";
                    }
                    tree.IsDroping = true;
                }
                else
                {
                    tree.IsShaking = true;
                }  
            }                    
        }

        public void _Breed_Fishing() //Point frame,Point toolframe
        {
            GlobalController.PlayerIsFishing = true;
            GlobalController.FishingSys = new FishingSystem(GlobalController.Map);
            GlobalController.FishingSys.StrengthAccelerate = 0.75f;
            GlobalController.FishingSys.KeyStrength = 10;
            GlobalController.FishingSys.PlayerStrength = 0.1f;
            //Vector2 rodPos = GlobalController.Player.MidPos;
            //switch (GlobalController.Player.CurrentFrame.Y % 4)
            //{
            //    case 0:
            //        rodPos.Y += (2 * Define.UnitOFpixel);
            //        break;
            //    case 1:
            //        rodPos.X -= (2 * Define.UnitOFpixel);
            //        break;
            //    case 2:
            //        rodPos.X += (2 * Define.UnitOFpixel);
            //        break;
            //    case 3:
            //        rodPos.Y -= (2 * Define.UnitOFpixel);
            //        break;
            //    default:
            //        break;
            //}
            //foreach (Water item in GlobalController.WaterList)
            //{
            //    if (item.Position.X < rodPos.X && rodPos.X < item.Position.X + Define.UnitOFpixel && item.Position.Y < rodPos.Y && rodPos.Y < item.Position.Y + Define.UnitOFpixel)
            //    {
            //        GlobalController.PlayerIsFishing = true;
            //        GlobalController.Player.CurrentFrame = frame;
            //        GlobalController.Player.ToolsFrame = toolframe;
            //        GlobalController.rodPos = rodPos;
            //        GlobalController.FishingSys = new FishingSystem(GlobalController.Map, 300f,200f);
            //    }
            //}

        }

        public void _Breed_ThrowHook()
        {
            GlobalController.PlayerIsFishing = true;
        }

        public int[] _Npc_MapWeighted(Map current,Map target)
        {
            if (current.Name == "village_centre" && target.Name == "village_centre_clinic")
            {
                return new int[]{ 41 };
            }
            if (current.Name == "village_centre" && target.Name == "village_centre_hotel")
            {
                return new int[] { 42 };
            }
            if (current.Name == "village_centre" && target.Name == "village_centre_house1")
            {
                return new int[] { 43 };
            }
            if (current.Name == "village_centre" && target.Name == "village_centre_house2")
            {
                return new int[] { 44 };
            }
            if (current.Name == "village_centre" && target.Name == "village_centre_managehouse")
            {
                return new int[] { 45 };
            }
            if (current.Name == "village_centre" && target.Name == "village_centre_restaurant")
            {
                return new int[] { 46 };
            }
            if (current.Name == "village_centre" && target.Name == "village_centre_toolhouse")
            {
                return new int[] { 47 };
            }
            if (current.Name == "village_centre" && target.Name == "village_centre_shop")
            {
                return new int[] { 48 };
            }
            if (current.Name == "village_centre_restaurant" && target.Name == "village_centre")
            {
                return new int[] { 11 };
            }
            return new int[] { };
        }
    }
}

