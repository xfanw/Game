using System;

namespace SpaceInvaders
{
    public class RemoveMan
    {
        private DLinkedList Commands = new DLinkedList();
        private static RemoveMan _RemoveMan;

        private Texture compareTexture = new Texture();

        public static void Initialize()
        {
            _RemoveMan = GetInstance();
        }

        private RemoveMan() { }

        private static RemoveMan GetInstance()
        {
            if (_RemoveMan == null)
            {
                _RemoveMan = new RemoveMan();
            }
            return _RemoveMan;
        }

        public static void Add(CommandBase command)
        {
            _RemoveMan.Commands.Add(command);
        }

        public static void Run()
        {
            if (_RemoveMan.Commands.GetHead() != null)
            {
                for (DLinkedNode node = _RemoveMan.Commands.GetHead(); node != null; node = node.Next)
                {
                    ((CommandBase)node).Run();
                }
                _RemoveMan.Commands = new DLinkedList();
            }
        }

        public static void Clear()
        {
            _RemoveMan.Commands = new DLinkedList();
        }
    }
}
