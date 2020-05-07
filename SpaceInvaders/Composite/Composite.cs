using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Composite : GameObject
    {
        protected DLinkedList children = new DLinkedList();
        public DLinkedList Reservedchildren = new DLinkedList();
        public void SetPosition(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override void Add(Component component)
        {
            children.InsertEnd(component);
            component.Parent = this;
        }
        override public void Remove(Component component)
        {
            children.Remove(component);
            Reservedchildren.InsertEnd(component);            
        }

        public override string ToString()
        {
            return "\nComposite: Address:" + locationX + "." + locationY + "\n";
        }

        public override Component GetFirstChild()
        {
            return (Component)children.GetHead();
        }
    }
}
