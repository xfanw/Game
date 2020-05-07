using System.Diagnostics;

namespace SpaceInvaders
{
    public class ScenePlay : SceneState
    {
        TimerMan PlayTimerMan;
        Batch DeadObjs;
        public ScenePlay()
        {
            this.Initialize();
        }
        public override void Handle()
        {
            SceneContext.SetState(SceneContext.Scene.Over);
        }

        public override void Initialize()
        {
            // Initialize sepcial Singlton State
            PlayBatchMan.Initialize();

            PlayTimerMan = new TimerMan();
            TimerMan.SetActive(PlayTimerMan);
            ProxyMan.Initialize();
            //---------------------------------------------------------------------------------------------------------
            // Creat Groups  
            //---------------------------------------------------------------------------------------------------------



            PlayBatchMan.Add(BatchName.Aliens, 100);
            Batch temp = PlayBatchMan.Add(BatchName.Box, 2000);
            //temp.SetVisible(false);
            temp = PlayBatchMan.Add(BatchName.Walls, 201);
            //temp.SetVisible(false);
            temp = PlayBatchMan.Add(BatchName.Bumps, 202);
            //temp.SetVisible(false);

            PlayBatchMan.Add(BatchName.Texts, 300);
            PlayBatchMan.Add(BatchName.Ship, 400);
            PlayBatchMan.Add(BatchName.ShipBullet, 401);
            PlayBatchMan.Add(BatchName.Bombs, 402);
            PlayBatchMan.Add(BatchName.UFO, 502);


            // Initialize TimerEvents
            AnimationMan.Initialize();

            // Initialize GameObj and Collision
            GameObjectMan.Initialize();
            ColPairMan.Initialize();

            //
            UFOMan.Initialize();

            //
            RemoveMan.Initialize();

            //---------------------------------------------------------------------------------------------------------
            // Add Animation Command 
            //---------------------------------------------------------------------------------------------------------

            CommandBase SquidCmd = AnimationMan.Add(AnimationName.SquidCmd);
            CommandBase CrabCmd = AnimationMan.Add(AnimationName.CrabCmd);
            CommandBase OctopusCmd = AnimationMan.Add(AnimationName.OctopusCmd);

            TimerMan.Add(SquidCmd, 0.5f);
            TimerMan.Add(CrabCmd, 0.5f);
            TimerMan.Add(OctopusCmd, 0.5f);

            AlienSoundCommand MarchingSound = new AlienSoundCommand();
            MarchingSound.AddSound(SoundName.Invader1);
            MarchingSound.AddSound(SoundName.Invader2);
            MarchingSound.AddSound(SoundName.Invader3);
            MarchingSound.AddSound(SoundName.Invader4);

            TimerMan.Add(MarchingSound, Nums.SoundInterval);



            //---------------------------------------------------------------------------------------------------------
            // Add Input 
            //---------------------------------------------------------------------------------------------------------

            InputMan.GetArrowRightSubject().Add(new MoveRightObserver());
            InputMan.GetArrowLeftSubject().Add(new MoveLeftObserver());
            InputMan.GetSpaceSubject().Add(new ShootObserver());
            InputMan.GetBSubject().Add(new BoxObserver());
            InputMan.GetOneSubject().Add(new OneObserver());
            InputMan.GetTwoSubject().Add(new TwoObserver());


            //******************Non-moviable Ship *****************************
            Batch ships = PlayBatchMan.Add(BatchName.StaticShip, 400);
            ships.Add(GameSpriteMan.Find(GameSpriteName.Ship1));
            ships.Add(GameSpriteMan.Find(GameSpriteName.Ship2));

            //---------------------------------------------------------------------------------------------------------
            // Creat Game objects
            //---------------------------------------------------------------------------------------------------------
            // ***** Aliens *****
            AlienGridMan.Initialize();
            GameObject Aliens = new AliensGrid(0, 0);
            GameObjectMan.Add(Aliens);
            AlienGridMan.GetGrid();

            //AlienGridMan.InitializeGrid();

            // ***** Walls ***** 
            GameObject Walls = WallFactory.CreateWalls();
            GameObjectMan.Add(Walls);

            // ***** Bump *****
            GameObject Bumps = BumpFactory.CreateBumps();
            GameObjectMan.Add(Bumps);


            // ***** Sound *****
            //SoundMan.PlayMusic(SoundName.Theme);

            // ***** Font *****            

            //FontMan.Add(Font.Name.TestMessage, "ABC", 500, 100);
            Batch texts = PlayBatchMan.Find(BatchName.Texts);
            FontMan.Add(FontName.SCORE, texts, "SCORE", 50, 580);
            FontMan.Add(FontName.score1, texts, Score.GetCurrent().ToString(), 50, 550);
            FontMan.Add(FontName.PLAYER, texts, "PLAYER", 300, 580);
            FontMan.Add(FontName.player, texts, "1", 400, 580);
            FontMan.Add(FontName.LEVEL, texts, "LEVEL", 320, 550);
            FontMan.Add(FontName.level, texts, Nums.Level.ToString(), 400, 550);
            FontMan.Add(FontName.HIGHEST, texts, "HIGHEST", 550, 580);
            FontMan.Add(FontName.highest, texts, Score.GetHighest().ToString(), 550, 550);
            FontMan.Add(FontName.lives, texts, Nums.ShipLife.ToString() + "X", 10, 25);


            // ***** Shield *****

            PlayBatchMan.Add(BatchName.Bricks, 501);
            GameObject Shields = new ShieldGrid(300, 0);
            GameObjectMan.Add(Shields);

            Shields = BrickObjectFactory.GetShield();



            // ***** UFO *****            
            GameObject UFOs = new UFOCol(50, 50);
            GameObjectMan.Add(UFOs);

            // ***** Ship and bullet *****
            ShipMan.Initialize();
            GameObject Ships = new ShipCol(200, 200);
            GameObjectMan.Add(Ships);
            GameObject Bullets = new ShipBulletCol(200, 100);
            GameObjectMan.Add(Bullets);
            ShipMan.InitializeShip();

            // ***** Bomb *****
            BombMan.Initialize();
            GameObject Bombs = new BombCol(0, 10);
            GameObjectMan.Add(Bombs);

            // ***** Dead Objects *****
            DeadObjs = PlayBatchMan.Add(BatchName.DeadObj, 503);


            // *************** COMMANDS ***************   

            // ***** UFO Moving *****  
            CommandBase UFOStartCmd = new UFOStartingCommand();
            TimerMan.Add(UFOStartCmd, Rand.GetNext(10, 30));

            // ***** Aliens MoveY *****
            CommandBase AliensMoveY = new AlienMoveYCommand();
            TimerMan.Add(AliensMoveY, 15);

            // ***** Aliens Faster *****
            CommandBase AliensFaster = new AlienFasterCommand();
            TimerMan.Add(AliensFaster, Nums.TimeUp);

            // ***** Aliens shoot *****
            CommandBase AliensShoot = new AlienShootCommand();
            TimerMan.Add(AliensShoot, Rand.GetNext(2, 4));

            //---------------------------------------------------------------------------------------------------------
            // ******************Collision ************************Always Load Last
            //---------------------------------------------------------------------------------------------------------

            // real collision test            
            CollisionPair pair;
            // Missle hit Alien   ----200,100->bullet; 0,0->Alien Grid
            pair = ColPairMan.Add(CollisionPairName.Alien_Bullet, Bullets, Aliens);
            pair.AddListener(new ShipBulletObserver());
            pair.AddListener(new ShipReadyObserver());
            pair.AddListener(new BoomObserver());
            pair.AddListener(new HitAlienObserver());
            pair.AddListener(new ScoreObserver());

            // Missle hit Wall    
            pair = ColPairMan.Add(CollisionPairName.Bullet_Wall, Bullets, Walls);
            pair.AddListener(new ShipBulletObserver());
            pair.AddListener(new ShipReadyObserver());
            pair.AddListener(new WallSoundObserver());

            // AlienGrid Hit Wall       
            pair = ColPairMan.Add(CollisionPairName.Alien_Wall, Aliens, Walls);


            // Ship Hit Bumps       
            pair = ColPairMan.Add(CollisionPairName.Ship_Bump, Ships, Bumps);
            pair.AddListener(new WallTopObserver());

            // Missle hit Shields  
            pair = ColPairMan.Add(CollisionPairName.Bullet_Shield, Bullets, Shields);
            pair.AddListener(new ShipBulletObserver());
            pair.AddListener(new ShipReadyObserver());
            pair.AddListener(new HitShieldObserver());

            // Missle hit UFO  
            pair = ColPairMan.Add(CollisionPairName.Bullet_UFO, Bullets, UFOs);
            pair.AddListener(new ShipBulletObserver());
            pair.AddListener(new ShipReadyObserver());
            pair.AddListener(new BoomObserver());
            pair.AddListener(new UFOObserver());

            // UFO hit Wall  
            pair = ColPairMan.Add(CollisionPairName.UFO_Wall, UFOs, Walls);
            pair.AddListener(new UFOObserver());

            // Bomb hit Wall  
            pair = ColPairMan.Add(CollisionPairName.Bomb_Wall, Bombs, Walls);
            pair.AddListener(new BombObserver());
            pair.AddListener(new WallSoundObserver());

            // Bomb hit Shield  
            pair = ColPairMan.Add(CollisionPairName.Bomb_Shield, Bombs, Shields);
            pair.AddListener(new BombObserver());
            pair.AddListener(new HitShieldObserver());

            // Alien hit BumpGroup 
            pair = ColPairMan.Add(CollisionPairName.Alien_Bump, Aliens, Bumps);


            // Bullet hit Bomb
            pair = ColPairMan.Add(CollisionPairName.Bullet_Bomb, Bullets, Bombs);
            pair.AddListener(new HitBombObserver());
            pair.AddListener(new ShipBulletObserver());
            pair.AddListener(new ShipReadyObserver());

            // Bomb hit Ship 
            pair = ColPairMan.Add(CollisionPairName.Bomb_Ship, Bombs, Ships);
            pair.AddListener(new BombObserver());
            pair.AddListener(new ShipDeathObserver());
            pair.AddListener(new BoomObserver());
            pair.AddListener(new HitShipObserver());
            pair.AddListener(new GameOverObserver());

            // Alien Hit Shiled
            pair = ColPairMan.Add(CollisionPairName.Alien_Shield, Aliens, Shields);
            pair.AddListener(new HitShieldObserver());
            GameObjectMan.Update();

        }

        public override void Update(float systemTime)
        {
            InputMan.Update();
            TimerMan.Update(systemTime);
            ColPairMan.Process();


            // ***** Update Score *****
            Font message;
            message = FontMan.Find(FontName.score1);
            message.UpdateMessage(Score.GetCurrent().ToString());
            message = FontMan.Find(FontName.highest);
            message.UpdateMessage(Score.GetHighest().ToString());
            message = FontMan.Find(FontName.lives);
            message.UpdateMessage(Nums.ShipLife.ToString() + "X");
            message = FontMan.Find(FontName.level);
            message.UpdateMessage(Nums.Level.ToString());

            GameObjectMan.Update();
            RemoveMan.Run();
            PlayBatchMan.Find(BatchName.StaticShip).Update();
            DeadObjs.Update();

        }

        public override void Draw()
        {
            // draw all objects
            PlayBatchMan.Render();
        }

        public override void Entering()
        {

            TimerMan.SetActive(PlayTimerMan);

            // Update timer since last pause
            float t0 = GlobalTimer.GetTime();
            float t1 = this.TimeAtPause;
            float delta = t0 - t1;
            TimerMan.PauseUpdate(delta);
        }
        public override void Leaving()
        {
            TimeAtPause = TimerMan.GetCurrentTime();
            AlienGridMan.GetGrid();
            RemoveMan.Clear();
            ShipMan.InitializeShip();
            GameObjectMan.Find(300, 0).GameObj = BrickObjectFactory.GetShield();
            SoundMan.sndEngine.StopAllSounds();
            Nums.AlienDeltaX = 2 * Nums.LevelUp;
            Nums.SoundInterval = 0.5f / Nums.LevelUp;            
        }
    }
}