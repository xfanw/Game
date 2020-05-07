

namespace SpaceInvaders
{
    public abstract class CommandBase : DLinkedNode
    {
        public virtual void SetTimerEvent(TimerEvent timer) { }
        public virtual TimerEvent GetTimerEvent() { return new TimerEvent(); }
        public abstract void Run();        
    }
}
