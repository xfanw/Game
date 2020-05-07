
namespace SpaceInvaders
{
    public abstract class Component : Visitor
    {

        public Component Parent = null;
        public Component Reverse = null;
        public abstract Component GetFirstChild();
        public abstract void Add(Component c);
        public virtual void Remove(Component c) { }
        override public abstract string ToString();

    }
}
