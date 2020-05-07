
namespace SpaceInvaders
{
    public class UFOStartingCommand : CommandBase
    {
        public override void Run()
        {
            UFOMan.InitialUFO();
            TimerMan.Add(UFOMovingCommand.GetInstance(), 0.01f);
            SoundMan.PlayMusic(SoundName.UFO2);
        }

        public override string ToString()
        {
            return "UFO Start Moving";
        }
    }
}
