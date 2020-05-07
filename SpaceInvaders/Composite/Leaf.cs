namespace SpaceInvaders
{
    public abstract class Leaf : GameObject
    {
        public override Component GetFirstChild() { return null; }
        override public void Add(Component c) { }
        override public void Remove(Component c) { }
    }
}
