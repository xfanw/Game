
namespace SpaceInvaders
{
    public class SceneSelect : SceneState
    {
        
        public SceneSelect()
        {
            Initialize();
        }

        public override void Handle()
        {
            SceneContext.SetState(SceneContext.Scene.Play);
        }

        public override void Initialize()
        {
            SelectBatchMan.Initialize();
            Batch texts = SelectBatchMan.Add(BatchName.Texts, 100);

            // ***** TOP -> SCORES *****
            FontMan.Add(texts, "SCORE<1>", 50, 580);
            FontMan.Add(texts, "HI-SCORE", 320, 580);
            FontMan.Add(texts, "SCORE<2>", 580, 580);
            FontMan.Add(FontName.score_S1, texts, "0", 50, 550);
            FontMan.Add(FontName.score_S2, texts, "0", 580, 550);
            FontMan.Add(FontName.score_Sh, texts, Score.GetHighest().ToString(), 350, 550);

            // ***** MIDDLE -> TITLE *****
            FontMan.Add(texts, "PLAY", 350, 480);
            FontMan.Add(texts, "SPACE INVADERS", 280, 450);

            // ***** MIDDLE -> INSTRUCTION *****
            FontMan.Add(texts, "INSERT COIN", 300, 380);
            FontMan.Add(texts, "<1 OR 2 PLAYERS>", 270, 340);
            FontMan.Add(texts, "1-> 1PLAYER", 300, 310);
            FontMan.Add(texts, "2-> 2PLAYERS", 300, 280);

            // ***** BOTTOM -> SCORE TABLE *****
            FontMan.Add(texts, "* SCORE ADVANCE TABLE *", 230, 200);
            int yDelta = 30;
            FontMan.Add(texts, " = ? MYSTERY", 310, 200 - yDelta * 1);
            FontMan.Add(texts, " = 30 POINTS", 310, 200 - yDelta * 2);
            FontMan.Add(texts, " = 20 POINTS", 310, 200 - yDelta * 3);
            FontMan.Add(texts, " = 10 POINTS", 310, 200 - yDelta * 4);

            Batch Aliens = SelectBatchMan.Add(BatchName.Aliens, 200);
            ProxySprite SelectUFO = new ProxySprite(GameSpriteName.UFO, 300, 200 - yDelta * 1);
            ProxySprite SelectSquid = new ProxySprite(GameSpriteName.Squid, 300, 200 - yDelta * 2);
            ProxySprite SelectCrab = new ProxySprite(GameSpriteName.Crab, 300, 200 - yDelta * 3);
            ProxySprite SelectOct = new ProxySprite(GameSpriteName.Octopus, 300, 200 - yDelta * 4);
            Aliens.Add(SelectUFO);
            Aliens.Add(SelectSquid);
            Aliens.Add(SelectCrab);
            Aliens.Add(SelectOct);
        }
        public override void Update(float systemTime)
        {
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_1) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Play);
            }
            
        }

        public override void Draw()
        {
            // draw all objects
            SelectBatchMan.Render();
        }


        public override void Entering()
        {
                   
        }
        public override void Leaving()
        {
            TimeAtPause = TimerMan.GetCurrentTime();

            // Reset all Nums
            Score.Reset();
            Nums.ShipLife = 3;
            Nums.Level = 1;
        }

    }
}
