
using System;

namespace SpaceInvaders
{
    public class CollisionPair : DLinkedNode
    {
        public CollisionPairName Name;
        public GameObject treeA;
        public GameObject treeB;
        private Subject listeners = new Subject();


        // Constractors
        public CollisionPair()
        {
            Name = CollisionPairName.uninitialized;
        }

        public CollisionPair(CollisionPairName colpairCollisionPairName, GameObject pTreeRootA, GameObject pTreeRootB)
        {
            treeA = pTreeRootA;
            treeB = pTreeRootB;
            Name = colpairCollisionPairName;
        }

        // Collision detection
        public void Process()
        {
            Collide(treeA, treeB);
        }

        public static void Collide(GameObject pSafeTreeA, GameObject pSafeTreeB)
        {
            GameObject NodeA = pSafeTreeA;
            GameObject NodeB = pSafeTreeB;

            while (NodeA != null)
            {
                NodeB = pSafeTreeB;
                while (NodeB != null)
                {
                    CollisionRect rectA = NodeA.CollisionObj.Rect;
                    CollisionRect rectB = NodeB.CollisionObj.Rect;

                    if (rectA.Intersect(rectB))
                    {
                        NodeA.Accept(NodeB);
                        break;
                    }
                    NodeB = (GameObject)Iterator.GetSibling(NodeB);
                }
                NodeA = (GameObject)Iterator.GetSibling(NodeA);
            }
        }

        public void Notify()
        {
            listeners.Notify();
        }

        //Add Observer
        public void AddListener(Observer observer)
        {
            listeners.Add(observer);
        }

        public void SetCollision(GameObject pObjA, GameObject pObjB)
        {   
            listeners.ObjA = pObjA;
            listeners.ObjB = pObjB;
        }

        public override string ToString()
        {
            return treeA+" Collide with "+treeB;
        }



    }
}