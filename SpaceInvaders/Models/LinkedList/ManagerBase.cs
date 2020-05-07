namespace SpaceInvaders
{
    public abstract class ManagerBase
    {
        private DLinkedList _resList = new DLinkedList();
        private DLinkedList _actList = new DLinkedList();

        private int _resNum = 0;
        private int _actNum = 0;
        private int _delta = 0;
        private int _total = 0;

        public ManagerBase() { }
        public ManagerBase(int total, int delta)
        {
            _delta = delta;
            _resNum = 0;
            _total = 0;
        }

        /****************************************
         * Next 4 Functions are Add...() fonctions
         * 1.AddToFront : add to front of active list
         * 2.AddToEnd: add to end of active list
         * 3.AddBefore(node_1, node_2): Add node_1 before node_2 of active list
         * 4.AddAfter(node_1, node_2): Add node_1 after node_2 of active list
         * **************************************/

        public void AddToFront(DLinkedNode node)
        {
            _actList.Add(node);
            _actNum++;
            _total++;
        }

        public void AddToEnd(DLinkedNode node)
        {
            _actList.InsertEnd(node);
            _actNum++;
            _total++;
        }


        public void Remove(DLinkedNode node)
        {
            _actList.Remove(node);
            _actNum--;

            _resList.Add(node);
            _resNum++;
        }

        public DLinkedNode BaseFind(DLinkedNode node)
        {
            for (DLinkedNode temp = _actList.GetHead(); temp != null; temp = temp.Next)
            {
                if (Compare(temp))
                    return temp;
            }
            return null;
        }

        public DLinkedList GetActive()
        {
            return _actList;
        }

        public virtual bool Compare(DLinkedNode temp) { return false; }
        public abstract DLinkedNode CreateNode();


    }
}
