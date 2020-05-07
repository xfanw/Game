
namespace SpaceInvaders
{
    public class AnimationMan : ManagerBase
    {
        private static AnimationMan _animationMan;
        AnimationCommand compareCommand = new AnimationCommand();
        private AnimationMan(int t, int d) : base(t, d) { }

        private static AnimationMan GetInstance(int t = 10, int d = 5)
        {
            if (_animationMan == null)
            {
                _animationMan = new AnimationMan(t, d);
            }
            return _animationMan;
        }
        public static void Initialize(int t = 10, int d = 5)
        {
            _animationMan = GetInstance(t, d);
        }

        public static AnimationCommand Add(AnimationName Aname)
        {
            AnimationCommand c = CommandFactory.GetCommand(Aname);
            _animationMan.AddToFront(c);
            return c;
        }

        public override bool Compare(DLinkedNode temp)
        {
            return false;
        }

        public override DLinkedNode CreateNode()
        {
            return new AnimationCommand();
        }
    }
}
