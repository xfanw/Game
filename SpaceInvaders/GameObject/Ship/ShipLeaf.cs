

using System;

namespace SpaceInvaders
{
    public class ShipLeaf : Leaf
    {
        private ShipState state;
        private ShipMan.StateName stateName;

        public ShipLeaf() { }

        public ShipLeaf(GameSpriteName spname, float x, float y, int lx, int ly)
        {
            proxySprite = new ProxySprite(spname, x, y);
            CollisionObj = new CollisionObject(proxySprite);
            PlayBatchMan.Find(BatchName.Box).Add(CollisionObj.Box);
            this.x = x;
            this.y = y;
            locationX = lx;
            locationY = ly;
            state = new ShipReadyState();
        }

        public override void Accept(Visitor other)
        {
            other.Visit(this);
        }

        public void MoveRight()
        {
            state.MoveRight(this);
        }

        public void MoveLeft()
        {
            state.MoveLeft(this);
        }

        public void ShootMissile()
        {
            state.ShootMissile(this);
        }

        public override void Update()
        {
            proxySprite.Set(x, y);
            CollisionObj.UpdatePos(x, y);
        }

        public void SetState(ShipMan.StateName stateName)
        {
            state = ShipMan.GetState(stateName);
            this.stateName = stateName;
        }
        public void Handle()
        {
            state.Handle(this);
        }
        public ShipState GetState()
        {
            return state;
        }
        public ShipMan.StateName GetStateName()
        {
            return stateName;
        }
        public override string ToString()
        {
            return "Ship Leaf: " + locationX + "." + locationY;
        }

        public void SetPos(float v1, float v2)
        {
            x = v1;
            y = v2;
        }

        // Collision
        public override void Visit(BombCol b)
        {
            // Bomb Hit ShipLeaf ->Which Bomb
            GameObject BombChild = (GameObject)Iterator.GetChild(b);
            CollisionPair.Collide(BombChild, this);
        }
        public override void Visit(BombLeaf b)
        {
            // Bombleaf Hit Shipleaf ->Do Something
            CollisionPair pair = ColPairMan.Find(CollisionPairName.Bomb_Ship);
            pair.SetCollision(b, this);
            pair.Notify();
        }

    }
}
