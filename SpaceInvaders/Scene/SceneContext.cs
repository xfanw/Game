namespace SpaceInvaders
{
    public class SceneContext
    {
        public static string currentState;
        private static SceneState _SceneState;
        private static SceneSelect _SceneSelect;
        private static SceneOver _SceneOver;
        private static ScenePlay _ScenePlay;

        public enum Scene
        {
            Select,
            Play,
            Over,
            LeverUp,
            ShipDeath
        }
        public SceneContext()
        {
            // reserve the states
            _SceneSelect = new SceneSelect();
            _ScenePlay = new ScenePlay();
            _SceneOver = new SceneOver();


            // initialize to the select state
            _SceneState = _SceneSelect;
            currentState = "Select";
            _SceneState.Entering();
        }

        public static void Initialize()
        {
            new SceneContext();
        }
        public static SceneState GetState()
        {
            return _SceneState;
        }

        public static string GetStateName()
        {
            return currentState;
        }
        public static void SetState(Scene eScene)
        {
            currentState = eScene.ToString();
            _SceneState.Leaving();
            switch (eScene)
            {
                case Scene.Select:
                    _SceneState = _SceneSelect;
                    break;
                case Scene.Play:
                    _SceneState = _ScenePlay;
                    break;
                case Scene.Over:
                    _SceneState = _SceneOver;
                    break;
            }
            _SceneState.Entering();
        }
    }
}
