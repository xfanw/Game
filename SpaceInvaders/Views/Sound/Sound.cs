

namespace SpaceInvaders
{
    public class Sound : DLinkedNode
    {
        public  SoundName Name;
        private string source;        
        public Sound() { }
        public Sound(SoundName name, string source)
        {
            Name = name;
            this.source = source;
        }

        public string GetSource()
        {
            return source;
        }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
