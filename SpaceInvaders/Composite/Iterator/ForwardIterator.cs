using System.Diagnostics;

namespace SpaceInvaders
{
    public class ForwardIterator : Iterator
    {
        private Component Current;
        private Component Root;
        public ForwardIterator(Component Start)
        {
            Current = Start;
            Root = Start;
        }

        private Component PrivNextStep(Component node, Component parent, Component child, Component sibling)
        {
            if (child != null)
            {
                node = child;
            }
            else
            {
                if (sibling != null)
                {
                    node = sibling;
                }
                else
                {
                    // No more 
                    //       siblings... 
                    //       children...
                    // Go up a level to the parent

                    while (parent != null)
                    {
                        node = GetSibling(parent);
                        if (node != null)
                        {
                            // Found one
                            break;
                        }
                        else
                        {
                            // Go fish
                            parent = GetParent(parent);
                        }
                    }
                }
            }
            if (parent == null && child == null && sibling == null)
            {
                return null;
            }
                return node;
        }

        override public Component First()
        {
            return Root;
        }
        override public Component Next()
        {
            Component node = Current;

            Component child = GetChild(node);
            Component sibling = GetSibling(node);
            Component parent = GetParent(node);

            node = PrivNextStep(node, parent, child, sibling);
            Current = node;
            return Current;
        }

        override public bool IsDone()
        {
            return (Current == null);
        }



    }
}
