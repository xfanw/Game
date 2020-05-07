
namespace SpaceInvaders
{
    public class BumpFactory
    {
        public static GameObject CreateBumps()
        {
            GameObject leftBump = new BumperLeaf(40, 100, 15, 20, 100, 201);
            GameObject rightBump = new BumperLeaf(760, 100, 15, 20, 100, 202);

            PlayBatchMan.Find(BatchName.Bumps).Add(leftBump.CollisionObj.Box);
            PlayBatchMan.Find(BatchName.Bumps).Add(rightBump.CollisionObj.Box);

            Composite Bumps = new BumperCol(100, 200);
            Bumps.Add(leftBump);
            Bumps.Add(rightBump);
            return Bumps;

        }

    }
}
