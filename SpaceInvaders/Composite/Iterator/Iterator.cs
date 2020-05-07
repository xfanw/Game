
namespace SpaceInvaders
{
    public abstract class Iterator
    {
        public abstract Component Next();
        public abstract bool IsDone();
        public abstract Component First();
        public Iterator() : base() { }

        public static Component GetParent(Component component)
        {
            return component.Parent;
        }
        public static Component GetChild(Component component)
        {
            return component.GetFirstChild();
        }
        public static Component GetSibling(Component component)
        {
            return (Component) component.Next;
        }

    }
}
