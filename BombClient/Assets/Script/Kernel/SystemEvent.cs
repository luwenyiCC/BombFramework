using System;
using System.Collections.Generic;
namespace BombServer.Kernel
{
    public class SystemEvent
    {
        private uint nextEventID = 0;
        public uint GetEventID()
        {
            return nextEventID++;
        }
        Dictionary<uint,Action> eventMap;
        public SystemEvent()
        {
            eventMap = new Dictionary<uint, Action>();
        }
        public void BindingAction(uint eventID,Action action)
        {
            eventMap[eventID] += action;
        }
        public void RemoveAction(uint eventID, Action action)
        {
            eventMap[eventID] += action;
        }
    }

}
