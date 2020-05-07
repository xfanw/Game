
namespace SpaceInvaders
{
    public class ShipDeathObserver : Observer
    {
        public override void Notify()
        {
            ShipMan.GetShip().SetState(ShipMan.StateName.Dead);
            Nums.ShipLife--;

            Batch Ships = PlayBatchMan.Find(BatchName.StaticShip);
            if (Nums.ShipLife == 2)
            {
                Ships.Remove(GameSpriteMan.Find(GameSpriteName.Ship2));
            }
            else if (Nums.ShipLife == 1)
            {
                Ships.Remove(GameSpriteMan.Find(GameSpriteName.Ship1));
            }                       
        }
    }
}

