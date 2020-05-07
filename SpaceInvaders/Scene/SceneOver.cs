using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneOver : SceneState
    {
        
        Batch texts;
        public SceneOver()
        {
            this.Initialize();
        }
        public override void Handle()
        {
            SceneContext.SetState(SceneContext.Scene.Select);
        }

        public override void Initialize()
        {
            // Initialize sepcial Singlton State
            OverBatchMan.Initialize();
            

            // ***** Show -> SCORES *****   
            texts = OverBatchMan.Add(BatchName.Texts, 100);
            FontMan.Add(texts, "GAME OVER", 300, 380);                     
            FontMan.Add(texts, "HI-SCORE", 300, 350);
            FontMan.Add(texts, "PLAYER 1 ", 300, 320);
            FontMan.Add(texts, "PLAYER 2", 300, 290);
            FontMan.Add(texts, "PRESS C TO CONTINUE", 300, 200);
            FontMan.Add(FontName.score_E1, texts, Score.GetCurrent().ToString(), 440, 320);
            FontMan.Add(FontName.score_E2, texts, Score.GetCurrent().ToString(), 440, 290);
            FontMan.Add(FontName.score_EH, texts, Score.GetHighest().ToString(), 440, 350);           

        }
        public override void Update(float systemTime)
        {
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_C) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Select);
            }
            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_P) == true)
            {
                SceneContext.SetState(SceneContext.Scene.Play);
            }
            // ***** Update Score *****
            Font message = FontMan.Find(FontName.score_E1);
            message.UpdateMessage(Score.GetCurrent().ToString());
            message = FontMan.Find(FontName.score_EH);
            message.UpdateMessage(Score.GetHighest().ToString());
        }
        public override void Draw()
        {
            OverBatchMan.Render();
        }

        public override void Entering()
        {
            
        }
        public override void Leaving()
        {
            TimeAtPause = TimerMan.GetCurrentTime();            
        }
    }
}
