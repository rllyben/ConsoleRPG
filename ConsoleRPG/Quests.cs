using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ConsoleRPG.Fighting;

namespace ConsoleRPG
{
    internal class Quest
    {
        public Quest(string questName, byte status, int level, int xpReward, int cashReward = 0) 
        {
            QuestName = questName;
            Status = status;
            Level = level;
            CashReward = cashReward;
            XpReward = xpReward;
            
            ToKill = new List<ToDo>();
        }
        public string QuestName {get; set;}
        public byte Status {get; set;}
        public int Level {get; set;}
        public int CashReward {get; set;}
        public int XpReward {get; set;}
        public List<ToDo> ToKill {get; set;}

        public void SetToKill(ToDo killList)
        {
            ToKill.Add(killList);
        }

    }

    internal class ToDo
    {
        public ToDo(string mobToKill, int count, int checkCount)
        {
            MobToKill = mobToKill;
            Count = count;
            CheckCount = checkCount;
        }
        public string MobToKill {get; set;}
        public int Count {get; set;}
        public int CheckCount {get; set;}
    }

}