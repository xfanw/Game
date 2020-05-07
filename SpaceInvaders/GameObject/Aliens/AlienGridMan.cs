using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class AlienGridMan
    {
        private static AlienGridMan _AlienGridMan;
        private AliensGrid _AlienGrid;

        private AlienGridMan() { }

        public static void Initialize()
        {
            _AlienGridMan = GetInstance();
        }



        private static AlienGridMan GetInstance()
        {
            if (_AlienGridMan == null)
            {
                _AlienGridMan = new AlienGridMan();
            }
            return _AlienGridMan;
        }


        public static AliensGrid GetGrid()
        {
            AliensGrid temp = _AlienGridMan._AlienGrid;
            if (temp==null||temp.GetFirstChild() == null)
            {
                InitializeGrid();
            }
            return _AlienGridMan._AlienGrid;
        }


        public static void InitializeGrid()
        {
            // get Alien Grid From ReservedChildren Group
            AliensGrid Grid = (AliensGrid)GameObjectMan.Find(0, 0).GameObj;

            //if Grid has Child in the object pool
            DLinkedNode Col = Grid.Reservedchildren.GetHead();

            if (Col != null)
            {
                ResetGrid(Grid);

                // Update xs and ys of the whole grid
                UpdateGridPos(60, 530 - 30 * Nums.Level);

                // next line is necessary
                PlayBatchMan.Find(BatchName.Box).Add(GetGrid().CollisionObj.Box);
            }
            else
            {   // if Aliens Grid is not in the object pool. create new Grid Obj
                for (int j = 1; j <= 11; j++)
                {
                    Composite col = AlienObjectFactory.CreatComposite(j);
                    Grid.Add(col);
                }
            }
            _AlienGridMan._AlienGrid = Grid;
        }
        public static void KillAll()
        {
            DLinkedNode Child = GetGrid().GetFirstChild();
            while (Child != null)
            {
                // Kill all Child
                DLinkedNode NextChild = Child.Next;

                // Kill all grand Child
                DLinkedNode GrandChild = ((AliensCol)Child).GetFirstChild();
                while (GrandChild != null)
                {
                    DLinkedNode NextGrandChild = GrandChild.Next;
                    AlienLeaf tempGrandChild = ((AlienLeaf)GrandChild);
                    ((AliensCol)Child).Remove(tempGrandChild);

                    // Remove ProxySprite add Box Obj
                    PlayBatchMan.Find(BatchName.Aliens).Remove(((AlienLeaf)GrandChild).GetProxy());
                    PlayBatchMan.Find(BatchName.Box).Remove(((AlienLeaf)GrandChild).CollisionObj.Box);
                    GrandChild = NextGrandChild;

                }

                GetGrid().Remove((AliensCol)Child);
                // Remove Box Obj
                PlayBatchMan.Find(BatchName.Box).Remove(((AliensCol)Child).CollisionObj.Box);
                Child = NextChild;
            }
        }

        // private methods ---------->>>for recycling Aliens
        private static void ResetGrid(AliensGrid Grid)
        {
            DLinkedNode Col = Grid.Reservedchildren.GetHead();
            while (Col != null)
            {
                DLinkedNode NextCol = Col.Next;
                // Active Col
                Grid.Add((AliensCol)Col);

                // Active Leaf
                DLinkedNode Leaf = ((AliensCol)Col).Reservedchildren.GetHead();
                while (Leaf != null)
                {
                    DLinkedNode NextLeaf = Leaf.Next;
                    ((AliensCol)Col).Add((AlienLeaf)Leaf);
                    ((AliensCol)Col).Reservedchildren.Remove((AlienLeaf)Leaf);
                    Leaf = NextLeaf;
                }
                Grid.Reservedchildren.Remove((AliensCol)Col);
                Col = NextCol;
            }
        }



        private static void UpdateGridPos(float x, float y)
        {
            for (DLinkedNode Child = (AliensCol)GetGrid().GetFirstChild(); Child != null; Child = Child.Next)
            {
                // Alien Col do not have to update position, Since they will be updated By GameObjMan.Update()
                // Only add Box Obj to Box batch
                PlayBatchMan.Find(BatchName.Box).Add(((AliensCol)Child).CollisionObj.Box);

                // Alien leaf can be updated by their relative location
                for (DLinkedNode GrandChild = ((AliensCol)Child).GetFirstChild(); GrandChild != null; GrandChild = GrandChild.Next)
                {
                    AlienLeaf tempGrandChild = ((AlienLeaf)GrandChild);
                    tempGrandChild.x = x + 40 * tempGrandChild.locationX;
                    tempGrandChild.y = y - 30 * tempGrandChild.locationY;

                    tempGrandChild.CollisionObj.UpdatePos(tempGrandChild.x, tempGrandChild.y);

                    // Update ProxySprite add Box Obj to  batch
                    PlayBatchMan.Find(BatchName.Aliens).Add(((AlienLeaf)GrandChild).GetProxy());
                    PlayBatchMan.Find(BatchName.Box).Add(((AlienLeaf)GrandChild).CollisionObj.Box);

                }
            }
        }
    }
}
