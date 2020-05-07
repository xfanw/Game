
namespace SpaceInvaders
{
    public abstract class GameSpriteMan_Base : ManagerBase
    {
        public GameSpriteMan_Base(int t, int d) : base(t, d) { }
    }
    public class GameSpriteMan : GameSpriteMan_Base
    {
        private static GameSpriteMan _spriteMan;
        GameSprite compareSprite = new GameSprite();
        private GameSpriteMan(int t, int d) : base(t, d) { }

        private static GameSpriteMan GetInstance(int t = 10, int d = 5)
        {
            if (_spriteMan == null)
            {
                _spriteMan = new GameSpriteMan(t, d);
            }
            return _spriteMan;
        }
        public static void Initialize(int t = 10, int d = 5)
        {
            _spriteMan = GetInstance(t, d);
        }
        public static GameSprite Add(GameSpriteName name, ImageName image, float x, float y, float w, float h)
        {
            GameSprite s = new GameSprite(name, image, x, y, w, h);
            _spriteMan.AddToFront(s);
            return s;
        }
        public static void Remove(GameSpriteName name)
        {
            GameSprite temp = Find(name);
            _spriteMan.Remove(temp);
        }

        public static GameSprite Find(GameSpriteName name)
        {
            _spriteMan.compareSprite.Name = name;
            GameSprite resultSprite = (GameSprite)_spriteMan.BaseFind(_spriteMan.compareSprite);
            return resultSprite;
        }

        override public bool Compare(DLinkedNode temp)
        {
            GameSprite iTemp = (GameSprite)temp;
            if (iTemp.Name == compareSprite.Name)
            {
                return true;
            }
            return false;
        }

        override public DLinkedNode CreateNode()
        {
            return new GameSprite();
        }

        public static void AddAll()
        {
            GameSprite colorSprite;
            // Aliens
            Add(GameSpriteName.Squid, ImageName.Squid_Open, 100, 500, 20, 20);

            Add(GameSpriteName.Crab, ImageName.Crab_Open, 100, 450, 25, 20);

            Add(GameSpriteName.Octopus, ImageName.Octopus_Open, 100, 350, 30, 20);

            Add(GameSpriteName.ShipBullet, ImageName.ShipBullet, 350, 100, 4, 10);
            // Ships 1 movable, 2 unmovable
            Add(GameSpriteName.Ship, ImageName.Ship, 400, 100, 35, 25);
            Add(GameSpriteName.Ship1, ImageName.Ship, 70, 25, 35, 25);
            Add(GameSpriteName.Ship2, ImageName.Ship, 120, 25, 35, 25);

            //  Bricks
            Add(GameSpriteName.Brick, ImageName.Brick, 300, 200, 10, 5);
            Add(GameSpriteName.Brick_LT0, ImageName.BrickLeft_Top0, 285, 200, 10, 5);
            Add(GameSpriteName.Brick_LT1, ImageName.BrickLeft_Top1, 285, 195, 10, 5);
            Add(GameSpriteName.Brick_RT0, ImageName.BrickRight_Top0, 315, 200, 10, 5);
            Add(GameSpriteName.Brick_RT1, ImageName.BrickRight_Top1, 315, 195, 10, 5);
            Add(GameSpriteName.Brick_LB, ImageName.BrickLeft_Bottom, 285, 165, 10, 5);
            Add(GameSpriteName.Brick_RB, ImageName.BrickRight_Bottom, 315, 165, 10, 5);

            colorSprite = Add(GameSpriteName.UFO, ImageName.UFO, 400, 550, 40, 20);
            colorSprite.SetColor(0.8f, 0, 0);
            // Bombs
            Add(GameSpriteName.BombT, ImageName.BombT, 350, 200, 8, 10);
            Add(GameSpriteName.BombZ, ImageName.BombZigZag, 360, 200, 8, 10);
            Add(GameSpriteName.BombC, ImageName.BombCross, 370, 200, 8, 10);

            // Death Images
            Add(GameSpriteName.AlienDeath, ImageName.AlienDie2, 100, 100, 25, 20);
            Add(GameSpriteName.UFODeath, ImageName.UFODie, 100, 100, 40, 20);
            Add(GameSpriteName.ShipDeath, ImageName.ShipDie1, 100, 100, 35, 25);

        }
    }
}
