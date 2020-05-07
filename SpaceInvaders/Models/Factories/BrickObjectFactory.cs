

using System;

namespace SpaceInvaders
{
    public class BrickObjectFactory
    {
        public static GameObject GetShield()
        {
            GameObject Shields = GameObjectMan.Find(300, 0).GameObj;

            for (int i = 1; i <= 4; i++)
            {
                Shields.Add(BrickObjectFactory.GetShieldBlock(i));
            }

            return Shields;
        }

        public static Component GetShieldBlock(int initialX)
        {
            ShieldBlock ShieldB = new ShieldBlock(300, initialX);
            ShieldB.Add(GetCol1(initialX));
            ShieldB.Add(GetCol2(initialX));
            ShieldB.Add(GetCol3(initialX));
            ShieldB.Add(GetCol4(initialX));
            ShieldB.Add(GetCol5(initialX));
            ShieldB.Add(GetCol6(initialX));
            return ShieldB;
        }


        private static Component GetBrick(int initialX, int locX, int locY)
        {
            ShieldBrick ShieldBrick;
            ShieldBrick = new ShieldBrick(GameSpriteName.Brick, 20 + initialX * 140 + locX * 10, 200 - locY * 5, locX, locY);
            PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
            return ShieldBrick;
        }


        private static Component GetCol1(int initialX)
        {
            ShieldCol ShieldCol = new ShieldCol(301, 1);
            ShieldBrick ShieldBrick;
            //left upper 

            ShieldBrick = new ShieldBrick(GameSpriteName.Brick_LT0, 20 + initialX * 140 + 1 * 10, 200 - 1 * 5, 1, 1);
            PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
            ShieldCol.Add(ShieldBrick);

            ShieldBrick = new ShieldBrick(GameSpriteName.Brick_LT1, 20 + initialX * 140 + 1 * 10, 200 - 2 * 5, 1, 2);
            PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
            ShieldCol.Add(ShieldBrick);

            //   others
            for (int j = 3; j <= 10; j++)
            {
                ShieldBrick = new ShieldBrick(GameSpriteName.Brick, 20 + initialX * 140 + 1 * 10, 200 - j * 5, 1, j);
                PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
                ShieldCol.Add(ShieldBrick);
            }
            return ShieldCol;

        }
        private static Component GetCol2(int initialX)
        {
            ShieldCol ShieldCol = new ShieldCol(301, 2);
            ShieldBrick ShieldBrick;

            // others 
            for (int j = 1; j <= 7; j++)
            {
                ShieldBrick = new ShieldBrick(GameSpriteName.Brick, 20 + initialX * 140 + 2 * 10, 200 - j * 5, 2, j);
                PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
                ShieldCol.Add(ShieldBrick);
            }

            //left lower
            ShieldBrick = new ShieldBrick(GameSpriteName.Brick_LB, 20 + initialX * 140 + 2 * 10, 200 - 8 * 5, 2, 8);
            PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
            ShieldCol.Add(ShieldBrick);

            return ShieldCol;
        }
        private static Component GetCol3(int initialX)
        {
            ShieldCol ShieldCol = new ShieldCol(301, 3);
            ShieldBrick ShieldBrick;
            for (int j = 1; j <= 7; j++)
            {
                ShieldBrick = new ShieldBrick(GameSpriteName.Brick, 20 + initialX * 140 + 3 * 10, 200 - j * 5, 3, j);
                PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
                ShieldCol.Add(ShieldBrick);
            }
            return ShieldCol;
        }
        private static Component GetCol4(int initialX)
        {
            ShieldCol ShieldCol = new ShieldCol(301, 4);
            ShieldBrick ShieldBrick;
            for (int j = 1; j <= 7; j++)
            {
                ShieldBrick = new ShieldBrick(GameSpriteName.Brick, 20 + initialX * 140 + 4 * 10, 200 - j * 5, 4, j);
                PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
                ShieldCol.Add(ShieldBrick);
            }
            return ShieldCol;
        }
        private static Component GetCol5(int initialX)
        {
            ShieldCol ShieldCol = new ShieldCol(301, 5);
            ShieldBrick ShieldBrick;

            // others 
            for (int j = 1; j <= 7; j++)
            {
                ShieldBrick = new ShieldBrick(GameSpriteName.Brick, 20 + initialX * 140 + 5 * 10, 200 - j * 5, 5, j);
                PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
                ShieldCol.Add(ShieldBrick);
            }

            // right lower
            ShieldBrick = new ShieldBrick(GameSpriteName.Brick_RB, 20 + initialX * 140 + 5 * 10, 200 - 8 * 5, 5, 8);
            PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
            ShieldCol.Add(ShieldBrick);
            return ShieldCol;
        }
        private static Component GetCol6(int initialX)
        {
            ShieldCol ShieldCol = new ShieldCol(301, 5);
            ShieldBrick ShieldBrick;

            // right upper
            ShieldBrick = new ShieldBrick(GameSpriteName.Brick_RT0, 20 + initialX * 140 + 6 * 10, 200 - 1 * 5, 6, 1);
            PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
            ShieldCol.Add(ShieldBrick);

            ShieldBrick = new ShieldBrick(GameSpriteName.Brick_RT1, 20 + initialX * 140 + 6 * 10, 200 - 2 * 5, 6, 2);
            PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
            ShieldCol.Add(ShieldBrick);

            //   others
            for (int j = 3; j <= 10; j++)
            {
                ShieldBrick = new ShieldBrick(GameSpriteName.Brick, 20 + initialX * 140 + 6 * 10, 200 - j * 5, 6, j);
                PlayBatchMan.Find(BatchName.Bricks).Add(ShieldBrick.GetProxy());
                ShieldCol.Add(ShieldBrick);
            }
            return ShieldCol;
        }

    }
}
