using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ReverseIterator : Iterator
    {
        private Component Root;
        private Component Curr;
        private Component Prev;
        public ReverseIterator(Component Start)
        {
            ForwardIterator ForwardIt = new ForwardIterator(Start);
            Root = Start;
            Curr = Start;
            Prev = null;
            Component PrevComponent = Root;
            Component component = ForwardIt.First();

            while (!ForwardIt.IsDone())
            {
                PrevComponent = component;
                component = ForwardIt.Next();

                if (component != null)
                {
                    component.Reverse = PrevComponent;
                }
            }
            Root.Reverse = PrevComponent;
        }

        override public Component First()
        {
            Curr = Root.Reverse;
            return Curr;
        }

        override public Component Next()
        {
            Prev = Curr;
            Curr = Curr.Reverse;
            return Curr;
        }

        override public bool IsDone()
        {
            return (Prev == Root);
        }
    }
}
