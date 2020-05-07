using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ColPairMan : ManagerBase
    {
        private static ColPairMan _ColMan = null;
        private CollisionPair ComparePair = new CollisionPair();
        public static void Initialize(int t = 4, int d = 1)
        {
            _ColMan = GetInstance(t, d);
        }
        private ColPairMan(int t, int d) : base(t, d) { }
        private static ColPairMan GetInstance(int t = 4, int d = 1)
        {
            if (_ColMan == null)
            {
                _ColMan = new ColPairMan(t, d);
            }
            return _ColMan;
        }

        public static CollisionPair Add(CollisionPairName colpairName, GameObject treeRootA, GameObject treeRootB)
        {
            CollisionPair ColPair = new CollisionPair(colpairName,treeRootA,treeRootB);

            _ColMan.AddToFront(ColPair);

            return ColPair;
        }

        public static void Process()
        {
            CollisionPair temp = (CollisionPair)_ColMan.GetActive().GetHead();

            while (temp != null)
            {
                temp.Process();
                temp = (CollisionPair)temp.Next;
            }
        }

        public static CollisionPair Find(CollisionPairName name)
        {
            _ColMan.ComparePair.Name = name;            
            CollisionPair resultPair = (CollisionPair)_ColMan.BaseFind(_ColMan.ComparePair);
            return resultPair;
        }
        public static void Remove(CollisionPair temp)
        {
            _ColMan.Remove((DLinkedNode)temp);
        }   
        public override bool Compare(DLinkedNode temp)
        {
            if (((CollisionPair)temp).Name == _ColMan.ComparePair.Name)
            {
                return true;
            }
            return false;
        }  

        public override DLinkedNode CreateNode()
        {
            return new CollisionPair();
        }
    }
}