
using System;

namespace SpaceInvaders
{
    public class OverBatchMan : ManagerBase
    {
        private static OverBatchMan _batchManager;
        private SDLinkedList Batches = new SDLinkedList();
        private Batch compareBatch = new Batch();

        // Singleton Pattern
        private OverBatchMan(int t, int d) : base(t, d) { }

        private static OverBatchMan GetInstance(int t = 4, int d = 1)
        {
            if (_batchManager == null)
            {
                _batchManager = new OverBatchMan(t, d);
            }
            return _batchManager;
        }
        public static void Initialize()
        {
            _batchManager = GetInstance();
        }

        // Add
        public static Batch Add(BatchName name, int p)
        {
            Batch batch = new Batch(name, p);
            _batchManager.Batches.AddToSorted(batch);
            return batch;
        }

        public static void Update()
        {
            for (SDLinkedNode temp = (SDLinkedNode)_batchManager.Batches.GetHead(); temp != null; temp = (SDLinkedNode)temp.Next)
            {
                ((Batch)temp).Update();
            }
        }

        public static void Render()
        {
            for (SDLinkedNode temp = (SDLinkedNode)_batchManager.Batches.GetHead(); temp != null; temp = (SDLinkedNode)temp.Next)
            {
                ((Batch)temp).Render();
            }
        }
        //Find and compare are used for getting an object in the active list.
        public static Batch Find(BatchName name)
        {
            for (SDLinkedNode temp = (SDLinkedNode)_batchManager.Batches.GetHead(); temp != null; temp = (SDLinkedNode)temp.Next)
            {
                Batch tbatch = (Batch)temp;
                if (tbatch.Name == name) return tbatch;
            }

            return null;
        }

        public override bool Compare(DLinkedNode temp)

        {
            Batch bTemp = (Batch)temp;
            if (bTemp.Name == compareBatch.Name)
            {
                return true;
            }

            return false;

        }
        
        public override DLinkedNode CreateNode()
        {
            return new Batch(BatchName.uninitialized, -1);
        }


    }
}

