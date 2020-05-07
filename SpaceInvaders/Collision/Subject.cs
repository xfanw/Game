
namespace SpaceInvaders
{
    public class Subject
    {       
        private DLinkedList Observers = new DLinkedList();
        public GameObject ObjA;
        public GameObject ObjB;

        public void Add(Observer observer)
        {
            observer.subject = this;
            Observers.Add(observer);
        }

        public void Notify()
        {
            Observer TempObs = (Observer)Observers.GetHead();

            while (TempObs != null)
            {
                 TempObs.Notify();

                TempObs = (Observer)TempObs.Next;
            }

        }
    }
}
