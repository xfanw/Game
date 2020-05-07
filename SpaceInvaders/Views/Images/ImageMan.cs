namespace SpaceInvaders
{
    public abstract class ImageMan_Base : ManagerBase {
        public ImageMan_Base(int t, int d) : base(t, d) { }
    }
    public class ImageMan : ImageMan_Base
    {
        private static ImageMan _imgMan;
        private Image compareImage = new Image();

        public static void Initialize(int t = 10, int d = 3)
        {
            GetInstance(t, d);
        }

        private ImageMan(int t, int d) : base(t, d) { }

        private static ImageMan GetInstance(int t = 10, int d = 5)
        {
            if (_imgMan == null)
            {
                _imgMan = new ImageMan(t, d);
            }
            return _imgMan;
        }

        public static Image Add(Image image)
        {
            _imgMan.AddToFront(image);
            return image;
        }

        public static void Remove(ImageName image)
        {
            Image temp = Find(image);
            _imgMan.Remove(temp);
        }

        //Find and compare are used for getting an object in the active list.
        public static Image Find(ImageName name)
        {
            _imgMan.compareImage.Name = name;
            Image resultTexture = (Image)_imgMan.BaseFind(_imgMan.compareImage);

            return resultTexture;
        }

        public override bool Compare(DLinkedNode temp)

        {
            Image iTemp = (Image)temp;
            if (iTemp.Name == compareImage.Name)
            {
                //iTemp.Details();
                return true;
            }
            return false;
        }

        public override DLinkedNode CreateNode()
        {
           return new Image();
        }

        public static void AddAll()
        {
            Add((new CrabOpenFactory()).Create());
            Add((new CrabCloseFactory()).Create());
            Add((new SquidOpenFactory()).Create());
            Add((new SquidCloseFactory()).Create());
            Add((new OctopusOpenFactory()).Create());
            Add((new OctopusCloseFactory()).Create());
            Add((new ShipBulletFactory()).Create());
            Add((new ShipFactory()).Create());
               
            Add((new BombTFactory()).Create());
            Add((new BombZigZagFactory()).Create());
            Add((new BombCrossFactory()).Create());
            Add((new BrickFactory()).Create());
            Add((new BrickLeft_Top0Factory()).Create());
            Add((new BrickLeft_Top1Factory()).Create());
            Add((new BrickLeft_BottomFactory()).Create());
            Add((new BrickRight_Top0Factory()).Create());
            Add((new BrickRight_Top1Factory()).Create());
            Add((new BrickRight_BottomFactory()).Create());
             
            Add((new UFOFactory()).Create());
            Add((new UFODieFactory()).Create());
            Add((new ShipDie1Factory()).Create());
            Add((new AlienDie1Factory()).Create());
            Add((new ShipDie2Factory()).Create());
            Add((new AlienDie2Factory()).Create());
        }
    }
}
