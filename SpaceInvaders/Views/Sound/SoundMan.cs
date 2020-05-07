using IrrKlang;

namespace SpaceInvaders
{
    public class SoundMan : ManagerBase
    {
        private static SoundMan _SoundMan = null;
        private Sound compareSound = new Sound();
        public static ISoundEngine sndEngine = new ISoundEngine();
        private static ISound playing;
        public static void Initialize(int t = 10, int d = 1)
        {
            _SoundMan = GetInstance(t, d);
        }

        private SoundMan(int t, int d) : base(t, d) { }

        private static SoundMan GetInstance(int t, int d)
        {
            if (_SoundMan == null)
            {
                _SoundMan = new SoundMan(t, d);
            }
            return _SoundMan;
        }

        public static Sound Add(SoundName name, string address)
        {
            Sound sound = new Sound(name, address);
            _SoundMan.AddToFront(sound);
            return sound;
        }

        public static ISound Play(SoundName name)
        {
            string source = Find(name).GetSource();            
            return sndEngine.Play2D(source, false, false);
        }

        public static ISound PlayMusic(SoundName name)
        {
            string source = Find(name).GetSource();
            playing = sndEngine.Play2D(source, true, false);
            return playing;
        }

        public static void Stop()
        {
            playing.Stop();
        }
        public static Sound Find(SoundName name)
        {
            _SoundMan.compareSound.Name = name;
            Sound resultSound = (Sound)_SoundMan.BaseFind(_SoundMan.compareSound);
            return resultSound;
        }
        public override bool Compare(DLinkedNode temp)
        {
            if (((Sound)temp).Name == compareSound.Name)
            {
                return true;
            }
            return false;
        }

        public override DLinkedNode CreateNode()
        {
            return new Sound();
        }

        public static void AddAll()
        {
            Add(SoundName.Explosion, "explosion.wav");
            Add(SoundName.Invader1, "fastinvader1.wav");
            Add(SoundName.Invader2, "fastinvader2.wav");
            Add(SoundName.Invader3, "fastinvader3.wav");
            Add(SoundName.Invader4, "fastinvader4.wav");
            Add(SoundName.InvaderKilled, "invaderkilled.wav");
            Add(SoundName.Shoot, "shoot.wav");
            Add(SoundName.Theme, "theme.wav");
            Add(SoundName.UFO1, "ufo_highpitch.wav");
            Add(SoundName.UFO2, "ufo_lowpitch.wav");
            Add(SoundName.HitWall, "UFODie.mp3");
        }
    }
}
