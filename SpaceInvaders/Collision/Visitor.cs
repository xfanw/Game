using System.Diagnostics;


namespace SpaceInvaders
{

    public abstract class Visitor : DLinkedNode
    {
        public Visitor() { }
        public virtual void Accept(Visitor other) { }
        
        public virtual void Visit(AliensCol b) { }
        public virtual void Visit(AlienLeaf b) { }
        public virtual void Visit(ShipBulletCol b) { }
        public virtual void Visit(ShipBulletLeaf b) { }
        public virtual void Visit(ShipCol b) { }
        public virtual void Visit(ShipLeaf b) { }
        public virtual void Visit(UFOCol b) { }
        public virtual void Visit(UFOLeaf b) { }
        public virtual void Visit(BombCol bombCol) { }
        public virtual void Visit(BombLeaf bombCol) { }

        public virtual void Visit(AliensGrid b) { }
        public virtual void Visit(ShieldGrid b) { }
        public virtual void Visit(ShieldBlock b) { }

    }

}