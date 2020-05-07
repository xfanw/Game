
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("->Set Screen Title Name Here<-");
            this.SetWidthHeight(800, 600);
            this.SetClearColor(0.1f, 0.1f, 0.1f, 1f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //---------------------------------------------------------------------------------------------------------
            // Initialize managers 
            //---------------------------------------------------------------------------------------------------------
            // Initialize and Add All Texture
            TextureMan.Initialize();
            TextureMan.AddAll();

            // Initialize and Add All image
            ImageMan.Initialize();
            ImageMan.AddAll();

            // Initialize and Add All Sprites
            GameSpriteMan.Initialize();
            GameSpriteMan.AddAll();

            // Initialize and Add All Sounds
            SoundMan.Initialize();
            SoundMan.AddAll();

            // Initialize Input and Output            
            GlyphMan.Initialize();
            GlyphMan.AddXml(GlyphName.Consolas36pt, "Consolas36pt.xml", TextureName.Consolas);
            FontMan.Initialize();
            InputMan.Initialize();

            // Initialize TimerEvents
            TimerMan.Initialize();

            // Initialize GameObj and Collision
            PlayBatchMan.Initialize();           

            // ***** Scene *****
            SceneContext.Initialize();

        }


        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------

        public override void Update()
        {
            GlobalTimer.Update(this.GetTime());
            
            SceneContext.GetState().Update(this.GetTime());
        }


        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            SceneContext.GetState().Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {

        }

    }
}

