
namespace SpaceInvaders
{
    public class AlienSoundCommand : CommandBase
    {
        private DLinkedList SoundItems = new DLinkedList();
        private DLinkedNode pointer;
        public AnimationName Name;
        private TimerEvent parent;
        public AlienSoundCommand()
        {
            Name = AnimationName.uninitialized;
        }
        public void AddSound(SoundName name)
        {
            SoundItems.Add(new SoundNode(name));
        }
        public override void Run()
        {
            if (pointer == null)
            {
                pointer = SoundItems.GetHead();
            }
            else
            {
                pointer = pointer.Next;
                if (pointer == null)
                {
                    pointer = SoundItems.GetHead();
                }
            }
            parent.DeltaTime = Nums.SoundInterval;
            SoundMan.Play(((SoundNode)pointer).SoundItem);
        }

        public override void SetTimerEvent(TimerEvent timer)
        {
            parent = timer;
        }

        public override string ToString()
        {
            return "Sound Command";
        }

    }
}
