
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameObjectMan : ManagerBase
    {
        private static GameObjectMan _objectMan;
        private GameObjectMan(int t, int d) : base(t, d) { }

        private static GameObjectMan GetInstance(int t = 10, int d = 5)
        {
            if (_objectMan == null)
            {
                _objectMan = new GameObjectMan(t, d);
            }
            return _objectMan;
        }

        public static void Initialize(int t = 10, int d = 5)
        {
            _objectMan = GetInstance(t, d);
        }

        public static void Add(GameObject gameObject)
        {
            GameObjectNode node = new GameObjectNode(gameObject);
            _objectMan.AddToFront(node);
        }
        public static void Remove(GameObject gameObject)
        {
            GameObject Parent = (GameObject)Iterator.GetParent(gameObject);
            if (Parent != null)
            {                
                Parent.Remove(gameObject);
                if (Parent.GetFirstChild() == null)
                {
                    Parent.RemoveBox();
                    Remove(Parent);
                }
                Parent.Update();
            }
        }

        public static void Update()
        {
            for (DLinkedNode rootNode = _objectMan.GetActive().GetHead(); rootNode != null; rootNode = rootNode.Next)
            {
                GameObjectNode root = (GameObjectNode)rootNode;
                ReverseIterator rIt = new ReverseIterator(root.GameObj);
                Component first = rIt.First();
                while (!rIt.IsDone())
                {
                    GameObject pGameObj = (GameObject)first;
                    pGameObj.Update();
                    first = rIt.Next();
                }
                root.Update();
            }
        }


        //Find and compare are used for getting an object in the active list.
        public static GameObjectNode Find(float lx, float ly)
        {
            for (DLinkedNode node = _objectMan.GetActive().GetHead(); node != null; node = node.Next)
            {
                if ((((GameObjectNode)node).GameObj.locationX == lx) && (((GameObjectNode)node).GameObj.locationY == ly))
                {
                    return (GameObjectNode)node;
                }
            }
            return null;

        }
        public override bool Compare(DLinkedNode temp)
        {
            return false;
        }

        public override DLinkedNode CreateNode()
        {
            return new GameObjectNode();
        }
    }
}
