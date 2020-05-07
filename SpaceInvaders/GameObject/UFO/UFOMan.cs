using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class UFOMan : ManagerBase
    {

        private static UFOMan _UFOMan;

        private UFOLeaf UFO;
        private UFOMan() : base(1, 1)
        {
        }

        public static void Initialize()
        {
            _UFOMan = GetInstance();
        }

        private static UFOMan GetInstance()
        {
            if (_UFOMan == null)
            {
                _UFOMan = new UFOMan();
            }
            return _UFOMan;
        }

        public static UFOLeaf GetUFO()
        {
            return _UFOMan.UFO;
        }

        private static void UpdateUFOPos()
        {
            PlayBatchMan.Find(BatchName.UFO).Add(GetUFO().GetProxy());
            GetUFO().SetPos(100, 200);
            GetUFO().CollisionObj.UpdatePos(100, 200);
        }

        public static void InitialUFO()
        {
            UFOCol UCol = (UFOCol)GameObjectMan.Find(50, 50).GameObj;
            if (UCol.Reservedchildren.GetHead() != null)
            {
                _UFOMan.UFO = (UFOLeaf)UCol.Reservedchildren.GetHead();
                UCol.Reservedchildren.Remove(GetUFO());
                 UpdateUFOPos();
                PlayBatchMan.Find(BatchName.Box).Add(GetUFO().CollisionObj.Box);
                PlayBatchMan.Find(BatchName.Box).Add(UCol.CollisionObj.Box);
            }
            else
            {
                _UFOMan.UFO = new UFOLeaf(GameSpriteName.UFO, 400, 200, 50, 6);
                UpdateUFOPos();
            }
            UCol.Add(_UFOMan.UFO);
        }


        public override DLinkedNode CreateNode()
        {
            return new UFOLeaf();
        }
    }
}
