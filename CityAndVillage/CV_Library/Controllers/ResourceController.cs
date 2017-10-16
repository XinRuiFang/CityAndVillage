using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Controllers
{
    public class ResourceController
    {
        static ContentManager Content;

        const string Prefix_animals = @"Animals/";
        const string Prefix_buildings = @"Buildings/";
        const string Prefix_characters = @"Characters/";
        const string Prefix_construction = @"Constructions/";
        const string Prefix_decorats = @"Decorats/";
        const string Prefix_effects = @"Effects/";
        const string Prefix_fonts = @"Fonts/";
        const string Prefix_items = @"Items/";
        const string Prefix_light = @"Lights/";
        const string Prefix_maps = @"Maps/";
        const string Prefix_scenes = @"Scenes/";
        const string Prefix_systems = @"Systems/";
        const string Prefix_tiles = @"Tiles/";
        const string Prefix_UI = @"UI/";
        const string Prefix_weathers = @"Weathers/";

        public static Texture2D Animals_ox;

        
        public static Texture2D Buildings_village_ambifarm;
        public static Texture2D Buildings_village_barn;
        public static Texture2D Buildings_village_clinic;
        public static Texture2D Buildings_village_farmhouse;
        public static Texture2D Buildings_village_farmhouseA;
        public static Texture2D Buildings_village_farmhouseB;
        public static Texture2D Buildings_village_farmhouseC;
        public static Texture2D Buildings_village_hotel;
        public static Texture2D Buildings_village_house1;
        public static Texture2D Buildings_village_house2;
        public static Texture2D Buildings_village_house3;
        public static Texture2D Buildings_village_house4;
        public static Texture2D Buildings_village_house5;
        public static Texture2D Buildings_village_house6;
        public static Texture2D Buildings_village_house7;
        public static Texture2D Buildings_village_house8;
        public static Texture2D Buildings_village_managehouse;
        public static Texture2D Buildings_village_purchasingstation;
        public static Texture2D Buildings_village_restaurant;
        public static Texture2D Buildings_village_shop;
        public static Texture2D Buildings_village_toolhouse;

        public static Texture2D Buildings_town_station;
        public static Texture2D Buildings_town_clinic;
        public static Texture2D Buildings_town_hotel;
        public static Texture2D Buildings_town_managehouse;
        public static Texture2D Buildings_town_personalShop;
        public static Texture2D Buildings_town_restaurant;
        public static Texture2D Buildings_town_bathroom;
        public static Texture2D Buildings_town_shop;
        public static Texture2D Buildings_town_drink;
        public static Texture2D Buildings_town_house1;
        public static Texture2D Buildings_town_house2;
        public static Texture2D Buildings_town_house3;
        public static Texture2D Buildings_town_house4;
        public static Texture2D Buildings_town_house5;
        public static Texture2D Buildings_town_house6;
        public static Texture2D Buildings_town_house7;
        public static Texture2D Buildings_town_house8;
        public static Texture2D Buildings_town_house9;

        public static Texture2D Characters_character_shadow;
        public static Texture2D Characters_armAnim_0;
        public static Texture2D Characters_eyeAnim_0;
        public static Texture2D Characters_faceAnim_0;
        public static Texture2D Characters_clothesAnim_0;
        public static Texture2D Characters_hairforwardAnim_0;
        public static Texture2D Characters_hairbackwardAnim_0;
        public static Texture2D Characters_legAnim_0;
        public static Texture2D Characters_shouseAnim_0;
        public static Texture2D Characters_Lilis;
        public static Texture2D Characters_Lilis_pic;
        public static Texture2D Characters_Olivia;
        public static Texture2D Characters_Sabina;

        public static Texture2D Construction_cowhouse;

        public static Texture2D Decorats_spring_decorat;
        public static Texture2D Decorats_spring_shrub;
        public static Texture2D Decorats_spring_tree;
        public static Texture2D Decorats_tree_shadow;

        public static Effect Effects_Light;

        public static SpriteFont Fonts_UI;
        public static SpriteFont Fonts_UI6;
        public static Texture2D Font_small;
        public static Texture2D Font_time;
        public static Texture2D Font_date;
        public static Texture2D Font_deposit;

        public static Texture2D Items_items;
        public static Texture2D Items_seeds;
        public static Texture2D Items_tools;

        public static Texture2D Lights_light;

        public static Texture2D Scenes_bus_right;
        public static Texture2D Scenes_soil;
        public static Texture2D Scenes_chest;
        public static Texture2D Scenes_water;
        public static Texture2D Scenes_indoor_things;

        public static Texture2D Systems_fishingsys;

        public static Texture2D Tiles_Buildings_1;
        public static Texture2D Tiles_Buildings_2;
        public static Texture2D Tiles_Buildings_3;
        public static Texture2D Tiles_Buildings_4;
        public static Texture2D Tiles_Buildings_5;
        public static Texture2D Tiles_Buildings_6;
        public static Texture2D Tiles_Buildings_7;
        public static Texture2D Tiles_Buildings_8;
        public static Texture2D Tiles_Buildings_9;
        public static Texture2D Tiles_Buildings_10;
        public static Texture2D Tiles_Buildings_11;
        public static Texture2D Tiles_Buildings_12;
        public static Texture2D Tiles_Buildings_13;
        public static Texture2D Tiles_Buildings_14;
        public static Texture2D Tiles_Buildings_15;
        public static Texture2D Tiles_Buildings_16;
        public static Texture2D Tiles_Buildings_17;
        public static Texture2D Tiles_Buildings_18;
        public static Texture2D Tiles_Buildings_19;
        public static Texture2D Tiles_Buildings_20;
        public static Texture2D Tiles_Buildings_21;
        public static Texture2D Tiles_Buildings_22;
        public static Texture2D Tiles_Buildings_23;
        public static Texture2D Tiles_Decorats_1;
        public static Texture2D Tiles_Decorats_2;
        public static Texture2D Tiles_Objects_1;
        public static Texture2D Tiles_Terrains_1;
        public static Texture2D Tiles_Terrains_2;
        public static Texture2D Tiles_Terrains_3;
        public static Texture2D Tiles_Terrains_4;

        public static Texture2D UI_ordinary;
        public static Texture2D UI_calendar;
        public static Texture2D UI_logos;
        public static Texture2D UI_bubble;
        public static Texture2D UI_baggagelist;
        public static Texture2D UI_personalMsg;
        public static Texture2D UI_conversation;

        public static Texture2D Weathers_spring_rain;
        public static Texture2D Weathers_spring_wind;

        public static void Initialize(ContentManager content)
        {
            Content = content;

            Animals_ox = Content.Load<Texture2D>(Prefix_animals + "ox");

            Buildings_village_ambifarm = Content.Load<Texture2D>(Prefix_buildings + "village_ambifarm");
            Buildings_village_barn = Content.Load<Texture2D>(Prefix_buildings + "village_barn");
            Buildings_village_clinic = Content.Load<Texture2D>(Prefix_buildings + "village_clinic");
            Buildings_village_farmhouse = Content.Load<Texture2D>(Prefix_buildings + "village_farmhouse");
            Buildings_village_farmhouseA = Content.Load<Texture2D>(Prefix_buildings + "village_farmhouseA");
            Buildings_village_farmhouseB = Content.Load<Texture2D>(Prefix_buildings + "village_farmhouseB");
            Buildings_village_farmhouseC = Content.Load<Texture2D>(Prefix_buildings + "village_farmhouseC");
            Buildings_village_hotel = Content.Load<Texture2D>(Prefix_buildings + "village_hotel");
            Buildings_village_house1 = Content.Load<Texture2D>(Prefix_buildings + "village_house1");
            Buildings_village_house2 = Content.Load<Texture2D>(Prefix_buildings + "village_house2");
            Buildings_village_house3 = Content.Load<Texture2D>(Prefix_buildings + "village_house3");
            Buildings_village_house4 = Content.Load<Texture2D>(Prefix_buildings + "village_house4");
            Buildings_village_house5 = Content.Load<Texture2D>(Prefix_buildings + "village_house5");
            Buildings_village_house6 = Content.Load<Texture2D>(Prefix_buildings + "village_house6");
            Buildings_village_house7 = Content.Load<Texture2D>(Prefix_buildings + "village_house7");
            Buildings_village_house8 = Content.Load<Texture2D>(Prefix_buildings + "village_house8");
            Buildings_village_managehouse = Content.Load<Texture2D>(Prefix_buildings + "village_managehouse");
            Buildings_village_purchasingstation = Content.Load<Texture2D>(Prefix_buildings + "village_purchasingstation");
            Buildings_village_restaurant = Content.Load<Texture2D>(Prefix_buildings + "village_restaurant");
            Buildings_village_shop = Content.Load<Texture2D>(Prefix_buildings + "village_shop");
            Buildings_village_toolhouse = Content.Load<Texture2D>(Prefix_buildings + "village_toolhouse");

            Buildings_town_station = Content.Load<Texture2D>(Prefix_buildings + "town_station");
            Buildings_town_bathroom = Content.Load<Texture2D>(Prefix_buildings + "town_bathroom");
            Buildings_town_hotel = Content.Load<Texture2D>(Prefix_buildings + "town_hotel");
            Buildings_town_drink = Content.Load<Texture2D>(Prefix_buildings + "town_drink");
            Buildings_town_clinic = Content.Load<Texture2D>(Prefix_buildings + "town_clinic");
            Buildings_town_managehouse = Content.Load<Texture2D>(Prefix_buildings + "town_managehouse");
            Buildings_town_personalShop = Content.Load<Texture2D>(Prefix_buildings + "town_personalShop");
            Buildings_town_restaurant = Content.Load<Texture2D>(Prefix_buildings + "town_restaurant");
            Buildings_town_shop = Content.Load<Texture2D>(Prefix_buildings + "town_shop");
            Buildings_town_house1 = Content.Load<Texture2D>(Prefix_buildings + "town_house1");
            Buildings_town_house2 = Content.Load<Texture2D>(Prefix_buildings + "town_house2");
            Buildings_town_house3 = Content.Load<Texture2D>(Prefix_buildings + "town_house3");
            Buildings_town_house4 = Content.Load<Texture2D>(Prefix_buildings + "town_house4");
            Buildings_town_house5 = Content.Load<Texture2D>(Prefix_buildings + "town_house5");
            Buildings_town_house6 = Content.Load<Texture2D>(Prefix_buildings + "town_house6");
            Buildings_town_house7 = Content.Load<Texture2D>(Prefix_buildings + "town_house7");
            Buildings_town_house8 = Content.Load<Texture2D>(Prefix_buildings + "town_house8");
            Buildings_town_house9 = Content.Load<Texture2D>(Prefix_buildings + "town_house9");

            Characters_character_shadow = Content.Load<Texture2D>(Prefix_characters + "character_shadow");
            Characters_armAnim_0 = Content.Load<Texture2D>(Prefix_characters + "armAnim_0");
            Characters_clothesAnim_0 = Content.Load<Texture2D>(Prefix_characters + "clothesAnim_0");
            Characters_faceAnim_0 = Content.Load<Texture2D>(Prefix_characters + "faceAnim_0");
            Characters_eyeAnim_0 = Content.Load<Texture2D>(Prefix_characters + "eyeAnim_0");
            Characters_hairforwardAnim_0 = Content.Load<Texture2D>(Prefix_characters + "hairforwardAnim_0");
            Characters_hairbackwardAnim_0 = Content.Load<Texture2D>(Prefix_characters + "hairbackwardAnim_0");
            Characters_legAnim_0 = Content.Load<Texture2D>(Prefix_characters + "legAnim_0");
            Characters_shouseAnim_0 = Content.Load<Texture2D>(Prefix_characters + "shouseAnim_0");
            Characters_Lilis = Content.Load<Texture2D>(Prefix_characters + "NPC//Lilis");
            Characters_Lilis_pic = Content.Load<Texture2D>(Prefix_characters + "NPC//Pic//Lilis");
            Characters_Olivia = Content.Load<Texture2D>(Prefix_characters + "NPC//Olivia");
            Characters_Sabina = Content.Load<Texture2D>(Prefix_characters + "NPC//Sabina");


            Construction_cowhouse = Content.Load<Texture2D>(Prefix_construction + "cowhouse");

            Decorats_spring_decorat = Content.Load<Texture2D>(Prefix_decorats + "spring_decorat");
            Decorats_spring_shrub = Content.Load<Texture2D>(Prefix_decorats + "spring_shrub");
            Decorats_spring_tree = Content.Load<Texture2D>(Prefix_decorats + "spring_tree");
            Decorats_tree_shadow = Content.Load<Texture2D>(Prefix_decorats + "tree_shadow");

            Effects_Light = Content.Load<Effect>(Prefix_effects + "Light");

            Fonts_UI = Content.Load<SpriteFont>(Prefix_fonts + "UI");
            Fonts_UI6 = Content.Load<SpriteFont>(Prefix_fonts + "UI6");
            Font_small = Content.Load<Texture2D>(Prefix_fonts + "font_small");
            Font_time = Content.Load<Texture2D>(Prefix_fonts + "font_time");
            Font_date = Content.Load<Texture2D>(Prefix_fonts + "font_date");
            Font_deposit = Content.Load<Texture2D>(Prefix_fonts + "font_deposit");

            Items_items = Content.Load<Texture2D>(Prefix_items + "items");
            Items_seeds = Content.Load<Texture2D>(Prefix_items + "seeds");
            Items_tools = Content.Load<Texture2D>(Prefix_items + "tools");

            Lights_light = Content.Load<Texture2D>(Prefix_light + "light");

            Scenes_bus_right = Content.Load<Texture2D>(Prefix_scenes + "bus_right");
            Scenes_soil = Content.Load<Texture2D>(Prefix_scenes + "soil");
            Scenes_chest = Content.Load<Texture2D>(Prefix_scenes + "scene_chest");
            Scenes_water = Content.Load<Texture2D>(Prefix_scenes + "water");
            Scenes_indoor_things = Content.Load<Texture2D>(Prefix_scenes + "indoor_things");

            Systems_fishingsys = Content.Load<Texture2D>(Prefix_systems + "fishingsys");

            Tiles_Buildings_1 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/1");
            Tiles_Buildings_2 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/2");
            Tiles_Buildings_3 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/3");
            Tiles_Buildings_4 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/4");
            Tiles_Buildings_5 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/5");
            Tiles_Buildings_6 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/6");
            Tiles_Buildings_7 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/7");
            Tiles_Buildings_8 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/8");
            Tiles_Buildings_9 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/9");
            Tiles_Buildings_10 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/10");
            Tiles_Buildings_11 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/11");
            Tiles_Buildings_12 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/12");
            Tiles_Buildings_13 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/13");
            Tiles_Buildings_14 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/14");
            Tiles_Buildings_15 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/15");
            Tiles_Buildings_16 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/16");
            Tiles_Buildings_17 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/17");
            Tiles_Buildings_18 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/18");
            Tiles_Buildings_19 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/19");
            Tiles_Buildings_20 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/20");
            Tiles_Buildings_21 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/21");
            Tiles_Buildings_22 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/22");
            Tiles_Buildings_23 = Content.Load<Texture2D>(Prefix_tiles + "Buildings/23");
            Tiles_Decorats_1 = Content.Load<Texture2D>(Prefix_tiles + "Decorats/1");
            Tiles_Decorats_2 = Content.Load<Texture2D>(Prefix_tiles + "Decorats//2");
            Tiles_Objects_1 = Content.Load<Texture2D>(Prefix_tiles + "Objects/1");
            Tiles_Terrains_1 = Content.Load<Texture2D>(Prefix_tiles + "Terrains/1");
            Tiles_Terrains_2 = Content.Load<Texture2D>(Prefix_tiles + "Terrains/2");
            Tiles_Terrains_3 = Content.Load<Texture2D>(Prefix_tiles + "Terrains/3");
            Tiles_Terrains_4 = Content.Load<Texture2D>(Prefix_tiles + "Terrains/4");

            UI_ordinary = Content.Load<Texture2D>(Prefix_UI + "UI_ordinary");
            UI_calendar = Content.Load<Texture2D>(Prefix_UI + "UI_calendar");
            UI_logos = Content.Load<Texture2D>(Prefix_UI + "UI_logos");
            UI_bubble = Content.Load<Texture2D>(Prefix_UI + "UI_bubble");
            UI_baggagelist = Content.Load<Texture2D>(Prefix_UI + "UI_baggagelist");
            UI_personalMsg = Content.Load<Texture2D>(Prefix_UI + "UI_personalMsg");
            UI_conversation = Content.Load<Texture2D>(Prefix_UI + "UI_conversation");

            Weathers_spring_rain = Content.Load<Texture2D>(Prefix_weathers + "spring_rain");
            Weathers_spring_wind = Content.Load<Texture2D>(Prefix_weathers + "spring_wind");
        }

        public static Texture2D GetMapTexture(string name)
        {            
            return Content.Load<Texture2D>(Prefix_maps + name);
        }
    }
}
