
namespace SpaceInvaders
{
    public abstract class ImageFactory
    {
        // Abstract Create Class
        public abstract Image Create();
    }

    // All Concreate Classes for Greating Imange (This file hase 24; Add more as needed outside this file)
    public class ShipDie1Factory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.ShipDie1, TextureName.Invader_3, 247, 1020, 226, 120);
        }
    }
    public class ShipDie2Factory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.ShipDie2, TextureName.Invader_3, 488, 1020, 226, 120);
        }
    }
    public class AlienDie1Factory : ImageFactory
    {
        public override Image Create() { return new Image(ImageName.AlienDie1, TextureName.Invader_3, 517, 1252, 165, 135); }
    }
    public class AlienDie2Factory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.AlienDie2, TextureName.Invader_3, 262, 1252, 195, 135);
        }
    }
    public class UFOFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.UFO, TextureName.Invader_3, 120, 788, 240, 105);
        }
    }
    public class UFODieFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.UFODie, TextureName.Invader_3, 563, 788, 305, 105);
        }
    }
    public class BombTFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.BombT, TextureName.Invader_3, 567, 1507, 47, 105);
        }
    }
    public class BombZigZagFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.BombZigZag, TextureName.Invader_3, 337, 1748, 47, 105);
        }
    }
    public class BombCrossFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.BombCross, TextureName.Invader_3, 337, 1507, 47, 105);
        }
    }
    public class BrickFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.Brick, TextureName.Invader_3, 130, 2700, 75, 30);
        }
    }
    public class BrickLeft_Top0Factory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.BrickLeft_Top0, TextureName.Invader_3, 0, 2655, 75, 30);
        }
    }
    public class BrickLeft_Top1Factory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.BrickLeft_Top1, TextureName.Invader_3, 0, 2685, 75, 30);
        }
    }
    public class BrickLeft_BottomFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.BrickLeft_Bottom, TextureName.Invader_3, 70, 2805, 75, 30);
        }
    }
    public class BrickRight_Top0Factory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.BrickRight_Top0, TextureName.Invader_3, 256, 2655, 75, 30);
        }
    }
    public class BrickRight_Top1Factory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.BrickRight_Top1, TextureName.Invader_3, 256, 2685, 75, 30);
        }
    }
    public class BrickRight_BottomFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.BrickRight_Bottom, TextureName.Invader_3, 180, 2805, 75, 30);
        }
    }
    public class ShipFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.Ship, TextureName.Invader_4, 158, 186, 73, 52);
        }
    }
    public class ShipBulletFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.ShipBullet, TextureName.Invader_4, 240, 280, 4, 32);
        }
    }
    public class CrabCloseFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.Crab_Close, TextureName.Invader_4, 9, 2, 110, 80);
        }
    }
    public class CrabOpenFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.Crab_Open, TextureName.Invader_4, 137, 2, 110, 80);
        }
    }
    public class OctopusCloseFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.Octopus_Close, TextureName.Invader_4, 4, 92, 120, 80);
        }
    }
    public class OctopusOpenFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.Octopus_Open, TextureName.Invader_4, 132, 93, 120, 80);
        }
    }
    public class SquidCloseFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.Squid_Close, TextureName.Invader_4, 408, 2, 80, 80);
        }
    }
    public class SquidOpenFactory : ImageFactory
    {
        public override Image Create()
        {
            return new Image(ImageName.Squid_Open, TextureName.Invader_4, 280, 2, 80, 80);
        }
    }
}