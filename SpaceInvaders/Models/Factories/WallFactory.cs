
namespace SpaceInvaders
{
    public class WallFactory
    {
        public static GameObject CreateWalls()
        {
            GameObject leftWall = new WallLeaf(50, 300, 15, 400, 100, 101);
            GameObject rightWall = new WallLeaf(750, 300, 15, 400, 100, 102);
            GameObject topWall = new WallLeaf(400, 520, 700, 15, 100, 103);
            GameObject bottomWall = new WallLeaf(400, 50, 700, 15, 100, 104);

            Batch WallBatch = PlayBatchMan.Find(BatchName.Walls);
            WallBatch.Add(leftWall.CollisionObj.Box);
            WallBatch.Add(rightWall.CollisionObj.Box);
            WallBatch.Add(topWall.CollisionObj.Box);
            WallBatch.Add(bottomWall.CollisionObj.Box);

            GameObject Walls = new WallCol(100,100);
            Walls.Add(leftWall);
            Walls.Add(rightWall);
            Walls.Add(topWall);
            Walls.Add(bottomWall);
            return Walls;

        }

    }
}
