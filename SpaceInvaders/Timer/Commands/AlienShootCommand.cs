
namespace SpaceInvaders
{
    public class AlienShootCommand: CommandBase
    {
        private AliensGrid AlienGrid;
        public override void Run()
        {
            AlienGrid = (AliensGrid)GameObjectMan.Find(0, 0).GameObj;
            AlienGrid.Shoot();
        }

        public override string ToString()
        {
            return "Alien Shoot Cmd";
        }
    }
}
