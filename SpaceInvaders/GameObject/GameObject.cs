

namespace SpaceInvaders
{
    public abstract class GameObject : Component
    {
        public bool MarkForDeath = false;
        public string name = "uninitialized";
        public float x;
        public float y;
        protected ProxySprite proxySprite;

        //instead of using name, I use location (x, y )to locate Game object
        // 
        //***********For leaf Objects*****************
        // y = 1; x = 1,2,3,4,5,6,7,8,9,10,11
        // y = 2; x = 1,2,3,4,5,6,7,8,9,10,11
        // y = 3; x = 1,2,3,4,5,6,7,8,9,10,11
        // y = 4; x = 1,2,3,4,5,6,7,8,9,10,11
        // y = 5; x = 1,2,3,4,5,6,7,8,9,10,11
        //
        //*************For Col Object*******************
        // y = 0; x = 1,2,3,4,5,6,7,8,9,10,11
        //
        //*************For Grid Object******************
        // y = 0; x = 0
        //
        //*************For Walls Object*****************
        // x = 100 -> Boundaries: 
        // y = 100 -> wall group
        // y = 101 -> left; 102 -> right; 103 -> top; 104 -> bottom
        // y = 200 -> bumpers
        // y = 201 -> left bump; y = 202 -> right bump;
        // 
        //**************For ShipBullet*******************
        // x = 200 -> Ships/bullet
        // y = 100 -> Bullet Group;  y = 101 -> Bullet Leaf
        // y = 200 -> Ship Group;    y = 201 -> Ship Leaf
        // 
        // locationY = GameObject.Type
        // locationX = GameObject.Name
        //
        // *************For Shields*******************
        // x = 300 ; y = 0 --> Shield Grid
        // x = 300 ; y = 1, 2, 3, 4 -> Shield Can left->right
        // x = 301 ; y = 1, 2, 3, 4, 5, 6, 7 -> Shield Colum left->right
        // x = 1,2, ...6 ; y = 1, 2, ... , 10 ->Shield bricks
        //
        // *************For UFO*******************
        // x = 50, y = 50 ->UFO Group
        // x = 51, y = 50 ->UFO
        //
        // *************For Bombs*******************
        // y = 10 ; x = 0 -> BombCol
        // y = 10 ; x = 1, 2, 3, ..., 11 -> BombLeaf
        //
        //



        // locationY = GameObject.Type
        // locationX = GameObject.Name
        public int locationX;
        public int locationY;
        public CollisionObject CollisionObj;
        public virtual void MoveY() { }
        public virtual void MoveX() { }
        public virtual void Update() { }
        public void BaseUpdate()
        {
            GameObject Child = (GameObject)Iterator.GetChild(this);

            if (Child != null)
            {
                CollisionObj.Rect.Set(Child.CollisionObj.Rect);
                while (Child != null)
                {
                    CollisionObj.Rect.Union(Child.CollisionObj.Rect);
                    Child = (GameObject)Iterator.GetSibling(Child);
                }

                x = CollisionObj.Rect.x;
                y = CollisionObj.Rect.y;
                CollisionObj.UpdatePos(x, y);
            }

        }

        public void RemoveBox()
        {
            PlayBatchMan.Find(BatchName.Box).Remove(CollisionObj.Box);
        }


        public ProxySprite GetProxy()
        {
            return proxySprite;
        }

    }
}
