using System.Diagnostics;

namespace SpaceInvaders
{
    public class DLinkedList
    {
        //a ref of first object in the list
        protected DLinkedNode _head;

        //a ref of last object in the list
        protected DLinkedNode _end;

        //some statistics including count......
        protected int count;

        //Default constractor
        public DLinkedList()
        {
            _head = null;
            _end = null;
            count = 0;
        }
        /*********************************************
         * Get head node
         *  @return DLinedNode _head
         * *******************************************/

        public DLinkedNode GetHead()
        {
            return _head;
        }

        /*********************************************
         * test if the list is empty
         * @return true if is empty
         * @return flase if not empty
         * *******************************************/
        public bool IsEmpty()
        {
            return _head == null;
        }


        /*********************************************
         * get the size of current linked list
         * @return size : int
         * *******************************************/
        public int Size()
        {
            return count;
        }



        /*********************************************
         * test if the list has a node, and returns its position
         * @return position : int
         * @return 0 if node is not in the list
         * *******************************************/
        //???might be private
        public float GetPosition(DLinkedNode node)
        {
            float position = 0;
            if (!IsEmpty())
            {
                for (DLinkedNode temp = _head; temp != null; temp = temp.Next)
                {
                    position++;

                    if (temp.Equals(node))
                    {
                        return position;
                    }
                }
            }

            return 0;
        }

        /*************************************
         * If call add, the add to front
         * ***********************************/
        public void Add(DLinkedNode node)
        {
            InsertFront(node);
        }



        /*********************************************
         * Add a node to the front of a list
         * *******************************************/
        public void InsertFront(DLinkedNode node)
        {
            if (node == null)
            {
                return;
            }
            if (IsEmpty())
            {
                _head = node;
                _end = node;
                count++;
            }
            else
            {
                node.Next = _head;
                _head.Prev = node;
                _head = node;
                count++;
            }

        }

        /*********************************************
         * Add a node to the end of a list
         * *******************************************/
        public void InsertEnd(DLinkedNode node)
        {
            if (IsEmpty())
            {
                _head = node;
                _end = node;
                count++;
            }
            else
            {
                node.Prev = _end;
                _end.Next = node;
                _end = node;
                count++;
            }

        }

        /*********************************************
         * Insert a node before currentNode in the list
         * Sepcial case:
         * 1.currentNode is not in the list
         * 2.currentNode is the head of the list
         * *******************************************/
        public void InsertBefore(DLinkedNode insertingNode, DLinkedNode currentNode)
        {
            float position = GetPosition(currentNode);
            if (position == 0)
            {
                return;
            }

            else if (position == 1)
            {
                InsertFront(insertingNode);
            }

            else
            {
                currentNode.Prev.Next = insertingNode;
                insertingNode.Prev = currentNode.Prev;
                currentNode.Prev = insertingNode;
                insertingNode.Next = currentNode;
                count++;
            }

        }


        /*********************************************
         * Delete a node from current linked list
         * Special cases:
         * 1. Empty List
         * 2. node not in the list
         * 3. only one node in the list
         * 4. node is head or end of list
         * 5. regular cases
         * *******************************************/
        public void Remove(DLinkedNode node)
        {
            if (IsEmpty())
            {
                return;
            }
            else
            {
                float position = GetPosition(node);
                if (position == 0)
                {
                    return;
                }
                else if (Size() == 1)
                {
                    RemoveOnly(node);
                }
                else if (position == 1)
                {
                    RemoveFront(node);
                }
                else if (position == count)
                {
                    RemoveEnd(node);
                }
                else
                {
                    node.Next.Prev = node.Prev;
                    node.Prev.Next = node.Next;
                    node.CleanNode();
                    count--;
                }
            }
        }

        private void RemoveEnd(DLinkedNode node)
        {
            if (node.Prev == null)
            {
                return;
            }
            else
            {
                _end = node.Prev;
                _end.Next = null;
                count--;
                node.CleanNode();
            }
        }

        private void RemoveFront(DLinkedNode node)
        {
            _head = node.Next;
            _head.Prev = null;
            count--;
            node.CleanNode();
        }

        private void RemoveOnly(DLinkedNode node)
        {
            _head = null;
            _end = null;
            count = 0;
            node.CleanNode();

        }
    }
}