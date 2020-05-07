
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class DLinkedNode
    {
        public DLinkedNode Next;
        public DLinkedNode Prev;


        public void CleanNode()
        {
            Next = null;
            Prev = null;
        }

        public override abstract string ToString();

    }
}
