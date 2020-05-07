using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class GlobalTimer
    {
        private static GlobalTimer _GlobalTimer = null;
        private float CurrentTime;
        private float GoalTime;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        private GlobalTimer()
        {
            CurrentTime = 0.0f;
        }

        private static GlobalTimer GetInstance()
        {
            // Do the initialization
            if (_GlobalTimer == null)
            {
                _GlobalTimer = new GlobalTimer();
            }

            return _GlobalTimer;
        }

        //----------------------------------------------------------------------
        // Static Methods
        //----------------------------------------------------------------------

        public static void Update(float time)
        {
            GlobalTimer Timer = GetInstance();
            Timer.CurrentTime = time;
        }

        public static float GetTime()
        {
            GlobalTimer Timer = GetInstance();
            return Timer.CurrentTime;
        }

        public static void Wait(float delta)
        {
            GlobalTimer Timer = GetInstance();
            Timer.GoalTime = GetTime() + 1;
            while (GetTime() < Timer.GoalTime)
            {
            }
        }
    }
}
