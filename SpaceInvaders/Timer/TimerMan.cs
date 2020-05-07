

using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TimerMan : ManagerBase
    {
        private static TimerMan _ActiveMan;
        private SDLinkedList TimerEvents = new SDLinkedList();
        private float currentTime = 0;

        private static TimerMan _TimerManager;

        // Singleton Pattern
        private TimerMan(int t, int d) : base(t, d)
        {
        }

        private static TimerMan GetInstance(int t = 4, int d = 2)
        {
            if (_TimerManager == null)
            {
                _TimerManager = new TimerMan(t, d);
            }
            return _TimerManager;
        }

        public static void Initialize(int t = 4, int d = 2)
        {
            _TimerManager = GetInstance(t, d);
        }
        // Public constructor and Set State
        public TimerMan() { }

        public static void SetActive(TimerMan actMan)
        {
            _ActiveMan = actMan;
        }
        public static TimerMan GetActiveMan()
        {
            return _ActiveMan;
        }

        // Add and Remove
        public static TimerEvent Add(CommandBase command, float deltaT)
        {
            TimerEvent timerEvent = new TimerEvent(command, deltaT);
            command.SetTimerEvent(timerEvent);
            _ActiveMan.TimerEvents.AddToSorted(timerEvent);
            return timerEvent;
        }

        public static void Remove(CommandBase command)
        {
            TimerEvent timerEvent =command.GetTimerEvent();
            _ActiveMan.TimerEvents.Remove(timerEvent);
        }

        // update time
        public static void Update(float time)
        {
            _ActiveMan.currentTime = time;
            SDLinkedNode currentNode = (SDLinkedNode)_ActiveMan.TimerEvents.GetHead();
            while (currentNode != null)
            {
                SDLinkedNode nextNode = (SDLinkedNode)currentNode.Next;
                TimerEvent tempEvent = (TimerEvent)currentNode;

                if (tempEvent.TriggerTime < _ActiveMan.currentTime)
                {
                    tempEvent.Process();
                    _ActiveMan.TimerEvents.Remove(tempEvent);
                }

                currentNode = nextNode;
            }

        }

        // Find and compare
        public static TimerEvent Find(CommandBase cmd)
        {
            for (SDLinkedNode temp = (SDLinkedNode)_ActiveMan.TimerEvents.GetHead(); temp != null; temp = (SDLinkedNode)temp.Next)
            {
                TimerEvent tTimer = (TimerEvent)temp;
                if (tTimer.Command == cmd) return tTimer;
            }
            return null;
        }


        public override DLinkedNode CreateNode()
        {
            return new TimerEvent();
        }

        public static float GetCurrentTime()
        {
            return _ActiveMan.currentTime;
        }

        public static void PauseUpdate(float delta)
        {
            for (DLinkedNode temp = _ActiveMan.TimerEvents.GetHead(); temp != null; temp = temp.Next)
            {
                ((TimerEvent)temp).TriggerTime += delta;
            }


        }
    }
}

