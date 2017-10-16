using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CV_Library
{

    public struct NPCInstruct
	{
        public string mapName;
        public double StartTime;
        public double EndTime;
	}

    public static class NPCController
    {
        public static List<NPCInstruct> GetNPCInstructList(string npcName)
        {
            switch (npcName)
            {
                case "chacter_boy":
                    List<NPCInstruct> list = new List<NPCInstruct>();
                    list.Add(new NPCInstruct
                    {
                    });
                    return list;
                default:
                    return new List<NPCInstruct>();
            }
        }
    }
}
