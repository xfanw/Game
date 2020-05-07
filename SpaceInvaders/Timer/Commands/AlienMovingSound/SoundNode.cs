
namespace SpaceInvaders
{
    public class SoundNode : DLinkedNode
    {
        public SoundName SoundItem;

        public SoundNode() { }

        public SoundNode(SoundName name)
        {

            SoundItem = name;
        }


        public override string ToString()
        {
            return "Sound Item" ;
        }

    }
}