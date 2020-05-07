

namespace SpaceInvaders
{
    public abstract class Observer : DLinkedNode
    {
        public Subject subject;
        public abstract void Notify();
        public override string ToString() { return "Some Observer"; }
    }
}
