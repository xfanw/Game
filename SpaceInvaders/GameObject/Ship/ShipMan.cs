using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipMan 
    {

        // Data: ----------------------------------------------
        private static ShipMan _ShipMan;

        // Active
        private ShipLeaf Ship;
        private ShipBulletLeaf BulletLeaf;

        // Reference
        private ShipReadyState ReadyState;
        private ShipMissleFlyingState FlyingState;
        private readonly ShipDeadState DeadState;
        public enum StateName
        {
            Ready,
            Flying,
            Dead
        }

        private ShipMan()//:base(1,1)
        {
            // Store the states
            ReadyState = new ShipReadyState();
            FlyingState = new ShipMissleFlyingState();
            DeadState = new ShipDeadState();

            // set active
            Ship = null;
            BulletLeaf = null;
        }

        public static void Initialize()
        {
            _ShipMan = GetInstance();           
        }

        private static ShipMan GetInstance()
        {
            if (_ShipMan == null)
            {
                _ShipMan = new ShipMan();
            }
            return _ShipMan;
        }

        public static ShipLeaf GetShip()
        {
            return _ShipMan.Ship;
        }
            public static ShipState GetState(StateName stateName)
        {

            switch (stateName)
            {
                case StateName.Ready:
                    {
                        return _ShipMan.ReadyState;
                    }
                case StateName.Flying:
                    {
                        return _ShipMan.FlyingState;
                    }
                case StateName.Dead:
                    {
                        return _ShipMan.DeadState;
                    }
                default:
                    {
                        return null;
                    }

            }
        }

        public static ShipBulletLeaf GetShipBulletLeaf()
        {

            return _ShipMan.BulletLeaf;
        }

        public static void InitializeBullet()
        {
            // get Bullet Group
            ShipBulletCol BulletCol = (ShipBulletCol)GameObjectMan.Find(200, 100).GameObj;
            // if bullet is in the object pool
            if (BulletCol.Reservedchildren.GetHead() != null)
            {
                _ShipMan.BulletLeaf = (ShipBulletLeaf)BulletCol.Reservedchildren.GetHead();
                BulletCol.Reservedchildren.Remove(_ShipMan.BulletLeaf);
                UpdateBulletPos();
                // next line is necessary
                PlayBatchMan.Find(BatchName.Box).Add(GetShipBulletLeaf().CollisionObj.Box);
                PlayBatchMan.Find(BatchName.Box).Add(BulletCol.CollisionObj.Box);
            }
            else    // if bullet is not in the object pool. create new Bullet Obj
            {
                _ShipMan.BulletLeaf = new ShipBulletLeaf(GameSpriteName.ShipBullet, 400, 100, 200, 101);
                UpdateBulletPos();
            }           

            BulletCol.Add(GetShipBulletLeaf());
            
        }

        private static void UpdateBulletPos()
        {
            PlayBatchMan.Find(BatchName.ShipBullet).Add(GetShipBulletLeaf().GetProxy());
            GetShipBulletLeaf().SetPos(GetShip().x, GetShip().y + 20);
            GetShipBulletLeaf().CollisionObj.UpdatePos(GetShip().x, GetShip().y + 20);
        }

        public static void InitializeShip()
        {
            // get Ship Group
            ShipCol ShipC = (ShipCol)GameObjectMan.Find(200, 200).GameObj;
            // if Ship is in the object pool
            if (ShipC.Reservedchildren.GetHead() != null)
            {
                _ShipMan.Ship = (ShipLeaf)ShipC.Reservedchildren.GetHead();
                ShipC.Reservedchildren.Remove(GetShip());
                UpdateShipPos();
                // next line is necessary
                PlayBatchMan.Find(BatchName.Box).Add(GetShip().CollisionObj.Box);
                PlayBatchMan.Find(BatchName.Box).Add(ShipC.CollisionObj.Box);
            }
            else    // if Ship is not in the object pool. create new Bullet Obj
            {
                _ShipMan.Ship = new ShipLeaf(GameSpriteName.Ship, 400, 100, 200, 201);
                UpdateShipPos();                
            }
            GetShip().SetState(StateName.Ready);
            ShipC.Add(GetShip());
        }
        private static void UpdateShipPos()
        {
            PlayBatchMan.Find(BatchName.Ship).Add(GetShip().GetProxy());
            GetShip().SetPos(400,100);
            GetShip().CollisionObj.UpdatePos(400, 100);
        }
    }
}
