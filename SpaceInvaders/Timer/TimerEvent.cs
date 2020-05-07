namespace SpaceInvaders
{
    public class TimerEvent : SDLinkedNode
    {
        public CommandBase Command;
        public float TriggerTime;
        public string Name;
        public float DeltaTime;
        public TimerEvent()
        {
            Name = "uninitialized";            
        }
        public TimerEvent(CommandBase command)
        {
            Command = command;
        }

        public TimerEvent( CommandBase command, float t)
        {
            Name = "Timer";
            Command =command;
            DeltaTime = t;
            TriggerTime = TimerMan.GetCurrentTime() + t;
        }
        internal void Process()
        {
            TimerMan.Add( Command, DeltaTime);
            Command.Run();
        }

        public override bool EqualTo(SDLinkedNode b)
        {
            return TriggerTime == ((TimerEvent)b).TriggerTime;
        }

        public override bool LargerThan(SDLinkedNode b)
        {
            return TriggerTime > ((TimerEvent)b).TriggerTime;
        }

        public override bool SmallerThan(SDLinkedNode b)
        {
            return TriggerTime < ((TimerEvent)b).TriggerTime;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
