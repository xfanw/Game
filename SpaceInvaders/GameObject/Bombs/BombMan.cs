using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class BombMan
    {
        private static BombMan _BombMan;
        private BombLeaf Bomb;

        private BombMan() { }

        public static void Initialize()
        {
            _BombMan = GetInstance();
        }

        private static BombMan GetInstance()
        {
            if (_BombMan == null)
            {
                _BombMan = new BombMan();
            }
            return _BombMan;
        }


        public static BombLeaf GetBomb()
        {
            return _BombMan.Bomb;
        }

        public static void GetRandomBomb()
        {
            int NextBomb = Rand.GetNext(1, 3);
            switch (NextBomb)
            {
                case 1:
                    //{
                    //    _BombMan.Bomb = new BombLeaf(GameSpriteName.BombC, new FallCross(), 700, 700, 1, 11);
                    //    break;
                    //}
                case 2:
                    //{
                    //    _BombMan.Bomb = new BombLeaf(GameSpriteName.BombT, new FallT(), 600, 700, 2, 11);
                    //    break;
                    //}
                case 3:
                    {
                        _BombMan.Bomb = new BombLeaf(GameSpriteName.BombZ, new FallZigZag(), 500, 700, 3, 11);
                        break;
                    }
                default:
                    {
                        Debug.WriteLine("Random number 1-3");
                        break;
                    }
            }
        }

        public static void InitializeBomb(float x, float y)
        {
            // get Bomb Group
            BombCol BCol = (BombCol)GameObjectMan.Find(0, 10).GameObj;
            // if bullet is in the object pool
            if (BCol.Reservedchildren.GetHead() != null)
            {
                _BombMan.Bomb = (BombLeaf)BCol.Reservedchildren.GetHead();
                BCol.Reservedchildren.Remove(_BombMan.Bomb);
                UpdateBombPos(x, y);
                _BombMan.Bomb.ResetStrategy();
                // next line is necessary
                PlayBatchMan.Find(BatchName.Box).Add(GetBomb().CollisionObj.Box);
                PlayBatchMan.Find(BatchName.Box).Add(BCol.CollisionObj.Box);
            }
            else    // if bullet is not in the object pool. create new Bullet Obj
            {
                GetRandomBomb();
                UpdateBombPos(x, y);
            }


            BCol.Add(GetBomb());

        }


        private static void UpdateBombPos(float x, float y)
        {
            PlayBatchMan.Find(BatchName.Bombs).Add(GetBomb().GetProxy());
            GetBomb().SetPos(x, y);
            GetBomb().CollisionObj.UpdatePos(x, y);
        }

        public static void KillAll()
        {
            BombCol BCol = (BombCol)GameObjectMan.Find(0, 10).GameObj;
            DLinkedNode Child = BCol.GetFirstChild();
            while (Child != null)
            {
                // Kill all Child
                DLinkedNode NextChild = Child.Next;

                BCol.Remove((BombLeaf)Child);
                // Remove Box Obj
                PlayBatchMan.Find(BatchName.Box).Remove(((BombLeaf)Child).CollisionObj.Box);
                PlayBatchMan.Find(BatchName.Bombs).Remove(((BombLeaf)Child).GetProxy());
                Child = NextChild;
            }
        }
    }
}
