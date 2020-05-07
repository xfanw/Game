

namespace SpaceInvaders
{
    public class ScoreObserver : Observer
    {
        public override void Notify()
        {
            AlienLeaf Hit = (AlienLeaf)subject.ObjB;
            switch (Hit.locationY)
            {
                case 1:
                    { Score.Add(Nums.SquidScore);
                        break;
                    }
                case 2:
                case 3:
                    {
                        Score.Add(Nums.CrabScore);
                        break;
                    }
                case 4:
                case 5:
                    {
                        Score.Add(Nums.OctopusScore);
                        break;
                    }
                default:
                    {                        
                        break;
                    }

            }
        }
    }
}
