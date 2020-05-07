
namespace SpaceInvaders
{
    class BoxObserver : Observer
    {
        public override void Notify()
        {  
            Batch box = PlayBatchMan.Find(BatchName.Box);
            Batch wall = PlayBatchMan.Find(BatchName.Walls);
            Batch bump = PlayBatchMan.Find(BatchName.Bumps);
            if (box.GetVisible() == true)
            {
                box.SetVisible(false);
                wall.SetVisible(false);
                bump.SetVisible(false);
            }
            else
            {
                wall.SetVisible(true);
                box.SetVisible(true);
                bump.SetVisible(true);
            }
            
        }
    }
}