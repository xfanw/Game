

using System;

namespace SpaceInvaders
{
    public class GameObjectNode : DLinkedNode
    {
        public GameObject GameObj = new NullGameObject();
        public GameObjectNode() { }

        public GameObjectNode(GameObject GameObj)
        {
            this.GameObj = GameObj;
        }

        public override string ToString()
        {
            return GameObj.name;
        }

        public void Update()
        {
            GameObj.Update();
        }
    }

}
