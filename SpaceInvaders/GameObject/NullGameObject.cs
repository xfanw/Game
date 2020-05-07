
namespace SpaceInvaders
{
    public class NullGameObject : GameObject
    {
        public NullGameObject() { name = "uninitialized"; }

        public override void Accept(Visitor other) { }

        public override void Add(Component c) { }
        public override Component GetFirstChild() { return null; }
        public override void MoveX() { }
        public override void MoveY() { }
        public override void Remove(Component c) { }

        public override string ToString()
        {
            return name;
        }

        public override void Update() { }
    }
}
