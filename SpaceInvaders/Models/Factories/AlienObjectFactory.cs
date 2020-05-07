
namespace SpaceInvaders
{
    public class AlienObjectFactory
    {
        public static GameObject CreateObj(GameSpriteName name, int locX, int locY)
        {
            GameObject obj;
            switch (name)
            {
                case GameSpriteName.Squid:
                    {
                        obj = new AlienLeaf(GameSpriteName.Squid, (60 + 40 * locX), (500 - locY * 30), locX, locY);
                        break;
                    }
                case GameSpriteName.Crab:
                    {
                        obj = new AlienLeaf(GameSpriteName.Crab, (60 + 40 * locX), (500 - locY * 30), locX, locY);
                        break;
                    }
                case GameSpriteName.Octopus:
                    {
                        obj = new AlienLeaf(GameSpriteName.Octopus, (60 + 40 * locX), (500 - locY * 30), locX, locY);
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }
            PlayBatchMan.Find(BatchName.Aliens).Add(obj.GetProxy());                       
            return obj;

        }

        public static Composite CreatComposite(int locX)
        {
            Composite col = new AliensCol(locX, 0);
            col.Add(CreateObj(GameSpriteName.Squid, locX, 1));
            col.Add(CreateObj(GameSpriteName.Crab, locX, 2));
            col.Add(CreateObj(GameSpriteName.Crab, locX, 3));
            col.Add(CreateObj(GameSpriteName.Octopus, locX, 4));
            col.Add(CreateObj(GameSpriteName.Octopus, locX, 5));
            return col;
        }
    }
}
