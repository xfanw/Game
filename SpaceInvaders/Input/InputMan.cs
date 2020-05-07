
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputMan
    {
        private static InputMan _InputMan = null;
        private bool _BKeyPrev;
        private bool _SpaceKeyPrev;
        private bool _TwoKeyPrev;
        private Subject Right;
        private Subject Left;
        private Subject Space;
        private Subject B;
        private Subject One;
        private Subject Two;
        private InputMan()
        {
            Left = new Subject();
            Right = new Subject();
            Space = new Subject();
            B = new Subject();
            One = new Subject();
            Two = new Subject();
        }

        private static InputMan GetInstance()
        {
            if (_InputMan == null)
            {
                _InputMan = new InputMan();
            }

            return _InputMan;
        }

        public static void Initialize()
        {
            _InputMan = GetInstance();
        }

        public static Subject GetArrowRightSubject()
        {
            return _InputMan.Right;
        }

        public static Subject GetArrowLeftSubject()
        {
            return _InputMan.Left;
        }

        public static Subject GetSpaceSubject()
        {
            return _InputMan.Space;
        }

        public static Subject GetBSubject()
        {
            return _InputMan.B;
        }

        public static Subject GetOneSubject()
        {
            return _InputMan.One;
        }

        public static Subject GetTwoSubject()
        {
            return _InputMan.Two;
        }
        public static void Update()
        {

            // Space Key ->Shoot

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE) == true )
            {
                _InputMan.Space.Notify();
            }

            //bool _SpaceKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_SPACE);
            //if (_SpaceKeyCurr == true && _InputMan._SpaceKeyPrev == false)
            //{
            //    _InputMan.Space.Notify();
            //}
            //_InputMan._SpaceKeyPrev = _SpaceKeyCurr;

            // LeftKey: 
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_LEFT) == true)
            {
                _InputMan.Left.Notify();
            }

            // RightKey: 
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_ARROW_RIGHT) == true)
            {
                _InputMan.Right.Notify();
            }

            // B Key
            bool _BKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_B);
            if (_BKeyCurr == true && _InputMan._BKeyPrev == false)
            {
                _InputMan.B.Notify();
            }

            _InputMan._BKeyPrev = _BKeyCurr;
            // One Key
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true)
            {
                _InputMan.One.Notify();
            }

            // Two Key
            bool _TwoKeyCurr = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_2);
            if (_TwoKeyCurr == true && _InputMan._TwoKeyPrev == false)
            {
                _InputMan.Two.Notify();
            }
            _InputMan._TwoKeyPrev = _TwoKeyCurr;

        }


    }
}
