using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library.Globals
{
    public class NpcPosition
    {
        Map map;
        Vector2 position;
        int direct;
        bool isUsing;

        public NpcPosition(Map map,Vector2 position,int direct)
        {
            this.map = map;
            this.position = position;
            this.direct = direct;
            this.isUsing = false;
        }
        public Map Map
        {
            get { return map; }
            set { map = value; }
        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public int Direct
        {
            get { return direct; }
            set { direct = value; }
        }
        public bool IsUsing
        {
            get { return isUsing; }
            set { isUsing = value; }
        }
    }
}
