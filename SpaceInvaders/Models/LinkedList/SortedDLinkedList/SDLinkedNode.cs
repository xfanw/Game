
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class SDLinkedNode : DLinkedNode
    {
        public abstract bool LargerThan(SDLinkedNode b);
        public abstract bool SmallerThan(SDLinkedNode b);
        public abstract bool EqualTo(SDLinkedNode b);
    }
}
