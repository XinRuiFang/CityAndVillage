using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.GameObjects.Items
{
    public class Seeds : Item 
    {
        float growTime;
        float waterConsume;

        float dry_health;
        float moist_health;
        float harvest_postpone_health;
        float disease_health;

        float dry_time;
        float moist_time;
        float harvest_postpone_time;
        float disease_time;

        float dry_max_time;
        float moist_max_time;
        float harvest_max_postpone_time;
        float disease_max_time;


        float dry_death_probability;
        float moist_death_probability;
        float harvest_postpone_death_probability;
        float disease_death_probability;

        int harvastNum;
        float quality;
        float growSpeed;
        float hiQ_probability;
        float disease_probability;
        float state_1_Time;
        float state_2_Time;
        float state_3_Time;
        float state_4_Time;
        Item harvestThing;
        int harvestTime;
        Point currentSeedFrame;
        Rectangle renderItemRectangle;
        Point seedSize;


        int status;
        bool is_diseased;
        bool is_dryDeath;
        bool is_moistDeath;



        Point currentFrame;

        public static Seeds Null = null;

        public Seeds(string id, Map map, Vector2 position, string name, Texture2D texture, int price, float state_1_Time, float state_2_Time, float state_3_Time, float state_4_Time, float waterConsume, string harvestThingId, int harvastNum, int harvestTime, float dry_health, float moist_health, float harvest_postpone_health, float disease_health, float dry_max_time, float moist_max_time, float harvest_max_postpone_time, float disease_max_time, int frameX, int frameY, string introduction)
            : base(id, map, position, name, texture, price, introduction)
        {
            this.Category = "Seed";
            growSpeed = 1.0f;
            growTime = 0;            
            is_diseased = false;
            is_dryDeath = false;
            is_moistDeath = false;

            this.size = new Point(1, 1);
            this.seedSize = new Point(2, 4);
            this.IsEquipment = true;

            //include id

            this.state_1_Time = state_1_Time;
            this.state_2_Time = state_2_Time;
            this.state_3_Time = state_3_Time;
            this.state_4_Time = state_4_Time;
            this.waterConsume = waterConsume;
            this.harvestThing = Item.ItemCreateFactory(harvestThingId); 
            //new Food("2001", Map.Null, Vector2.Zero, "strawberry", harvestTexture, 1,100);
            this.harvastNum = harvastNum;
            this.harvestTime = harvestTime;
            this.dry_health = dry_health;
            this.moist_health = moist_health;
            this.harvest_postpone_health = harvest_postpone_health;
            this.disease_health = disease_health;
            this.dry_max_time = dry_max_time;
            this.moist_max_time = moist_max_time;
            this.harvest_max_postpone_time = harvest_max_postpone_time;
            this.disease_max_time = disease_max_time;
            this.currentSeedFrame = new Point(frameX, frameY);
            this.renderRectangle = new Rectangle(0, 0, size.X * Define.UnitOFpixel, size.Y * Define.UnitOFpixel);
            this.renderItemRectangle = new Rectangle(0, 0, seedSize.X * Define.UnitOFpixel, seedSize.Y * Define.UnitOFpixel);
        }


        public int Status
        {
            get 
            {
                if (Is_diseased)
                {
                    status = 5;
                }
                else if (Is_dryDeath)
                {
                    status = 6;
                }
                else if (Is_moistDeath)
                {
                    status = 7;
                }
                else
                {
                    if (State_1_Time > GrowTime)
                    {
                        status = 0;
                    }
                    else if (State_1_Time <= GrowTime && GrowTime < State_2_Time)
                    {
                        status = 1;
                    }
                    else if (State_2_Time <= GrowTime && GrowTime < State_3_Time)
                    {
                        status = 2;
                    }
                    else if (State_3_Time <= GrowTime && GrowTime < State_4_Time)
                    {
                        status = 3;
                    }
                    else if (State_4_Time <= GrowTime)
                    {
                        status = 4;
                    }
                    else
                    {
                        status = 7;
                    }
                }
                return status; 
            }
        }

        public float GrowTime
        {
            get { return growTime; }
            set { growTime = value; }
        }

        public Point CurrentSeedFrame
        {
            get { return currentSeedFrame; }
            set { currentSeedFrame = value; }
        }
        public float WaterConsume
        {
            get { return waterConsume; }
            set { waterConsume = value; }
        }

        public float Dry_health
        {
            get { return dry_health; }
            set { dry_health = value; }
        }

        public float Moist_health
        {
            get { return moist_health; }
            set { moist_health = value; }
        }


        public float Disease_health
        {
            get { return disease_health; }
            set { disease_health = value; }
        }

        public float Harvest_postpone_health
        {
            get { return harvest_postpone_health; }
            set { harvest_postpone_health = value; }
        }


        public float Dry_time
        {
            get { return dry_time; }
            set { dry_time = value; }
        }


        public float Moist_time
        {
            get { return moist_time; }
            set { moist_time = value; }
        }


        public float Harvest_postpone_time
        {
            get { return harvest_postpone_time; }
            set { harvest_postpone_time = value; }
        }


        public float Disease_time
        {
            get { return disease_time; }
            set { disease_time = value; }
        }

        public float Dry_max_time
        {
            get { return dry_max_time; }
            set { dry_max_time = value; }
        }
        public float Moist_max_time
        {
            get { return moist_max_time; }
            set { moist_max_time = value; }
        }
        public float Harvest_max_postpone_time
        {
            get { return harvest_max_postpone_time; }
            set { harvest_max_postpone_time = value; }
        }
        public float Disease_max_time
        {
            get { return disease_max_time; }
            set { disease_max_time = value; }
        }
        public float Dry_death_probability
        {
            get 
            {
                dry_death_probability = Dry_time * 1.0f / Dry_max_time / 1000;
                return dry_death_probability; 
            
            }
        }

        public float Moist_death_probability
        {
            get 
            {
                moist_death_probability = Moist_time * 1.0f / Moist_max_time / 1000;
                return moist_death_probability; 
            }
        }

        public float Harvest_postpone_death_probability
        {
            get 
            {
                harvest_postpone_death_probability = Harvest_postpone_time * 1.0f / Harvest_max_postpone_time / 1000;
                return harvest_postpone_death_probability; 
            }
        }

        public float Disease_death_probability
        {
            get 
            {
                disease_death_probability = Disease_time * 1.0f / Disease_max_time / 1000;
                return disease_death_probability; 
            }
        }
        public int HarvastNum
        {
            get { return harvastNum; }
            set { harvastNum = value; }
        }

        public float Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        public float GrowSpeed
        {
            get { return growSpeed; }
            set { growSpeed = value; }
        }

        public float HiQ_probability
        {
            get { return hiQ_probability; }
            set { hiQ_probability = value; }
        }


        public float Disease_probability
        {
            get { return disease_probability; }
            set { disease_probability = value; }
        }


        public float State_1_Time
        {
            get { return state_1_Time; }
            set { state_1_Time = value; }
        }

        public float State_2_Time
        {
            get { return state_2_Time; }
            set { state_2_Time = value; }
        }

        public float State_3_Time
        {
            get { return state_3_Time; }
            set { state_3_Time = value; }
        }

        public float State_4_Time
        {
            get { return state_4_Time; }
            set { state_4_Time = value; }
        }


        public bool Is_diseased
        {
            get { return is_diseased; }
            set { is_diseased = value; }
        }
        public bool Is_dryDeath
        {
            get { return is_dryDeath; }
            set { is_dryDeath = value; }
        }
        public bool Is_moistDeath
        {
            get { return is_moistDeath; }
            set { is_moistDeath = value; }
        }
        public new Point CurrentFrame
        {
            get
            {
                currentFrame.X = Status;
                switch (this.Name)
                {
                    case "strawberry seed":
                        currentFrame.Y = 0;
                        break;
                    case "gress seed":
                        currentFrame.Y = 1;
                        break;
                    default:
                        break;
                }
                return currentFrame;
                
            }
        }
        public override Rectangle RenderRectangle
        {
            get
            {
                renderRectangle.X = currentSeedFrame.X  * Define.UnitOFpixel;
                renderRectangle.Y = currentSeedFrame.Y  * Define.UnitOFpixel;
                return renderRectangle;
            }
        }
        public Rectangle RenderItemRectangle
        {
            get
            {
                renderItemRectangle.X = CurrentFrame.X * seedSize.X * Define.UnitOFpixel;
                renderItemRectangle.Y = CurrentFrame.Y * seedSize.Y * Define.UnitOFpixel;
                return renderItemRectangle;

            }
        }

        public Item HarvestThing
        {
            get { return harvestThing; }
            set { harvestThing = value; }
        }


        public int HarvestTime
        {
            get { return harvestTime; }
            set { harvestTime = value; }
        }

        public void LoadingSeeds(float growTime, bool is_diseased, bool is_dryDeath, bool is_moistDeath, float dry_health, float disease_health, float harvest_postpone_health, float moist_health, float dry_time, float disease_time, float harvest_postpone_time, float moist_time)
        {
            this.GrowTime = growTime;
            this.Is_diseased = is_diseased;
            this.Is_dryDeath = is_dryDeath;
            this.Is_moistDeath = is_moistDeath;
            this.Dry_health = dry_health;
            this.Disease_health = disease_health;
            this.Harvest_postpone_health = harvest_postpone_health;
            this.Moist_health = moist_health;
            this.Dry_time = dry_time;
            this.Disease_time = disease_time;
            this.Harvest_postpone_time = harvest_postpone_time;
            this.Moist_time = moist_time;
        }
        public string SavingSeeds()
        {
            return this.GrowTime.ToString() + "|" + this.Is_diseased.ToString() + "|" + this.Is_dryDeath.ToString() + "|" + this.Is_moistDeath.ToString() + "|" + this.Dry_health.ToString() + "|" + this.Disease_health.ToString() + "|" + this.Harvest_postpone_health.ToString() + "|" + this.Moist_health.ToString() + "|" + this.Dry_time.ToString() + "|" + this.Disease_time.ToString() + "|" + this.Harvest_postpone_time.ToString() + "|" + this.Moist_time.ToString();
        }
    }
}
