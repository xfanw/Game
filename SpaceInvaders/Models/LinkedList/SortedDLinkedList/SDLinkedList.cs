

namespace SpaceInvaders
{
    public class SDLinkedList : DLinkedList
    {

        /*********************************************
         * Insert a node to current sorted linked list
         * Special cases:
         * 1. Empty List
         * 2. Node will be added to the last one InsertEnd
         * 3. regular cases InsertBefore
         * *******************************************/

        public void AddToSorted(SDLinkedNode node)
        {
            if (IsEmpty())
            {
                _head = node;
                _end = node;
                count++;
            }
            else
            {
                bool inserted = false;
                SDLinkedNode temp = (SDLinkedNode) _head;
                while (inserted == false && temp != null)
                {
                    if (temp.LargerThan(node))
                    {
                        InsertBefore(node, temp);
                        inserted = true;
                    }
                    else
                    {
                        temp = (SDLinkedNode)temp.Next;
                    }
                }
                if (!inserted)
                {
                    InsertEnd(node);
                }

            }
        }
    }
}


