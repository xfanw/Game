
namespace SpaceInvaders
{
    public class AlienMoveYCommand : CommandBase
    {
        private GameObject AliensGrid;
        public AlienMoveYCommand()
        {
            AliensGrid = GameObjectMan.Find(0, 0).GameObj;
        }

        // Command
        public override void Run()
        {
            AliensGrid.MoveY();
        }



        public override string ToString()
        {
            return "Alien Moving Y";
        }
    }
}
