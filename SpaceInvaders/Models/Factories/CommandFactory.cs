namespace SpaceInvaders
{
    public class CommandFactory
    {
        public static AnimationCommand GetCommand(AnimationName name)
        {
            AnimationCommand command;
            switch (name)
            {
                case AnimationName.SquidCmd:
                    {
                        command = new AnimationCommand(name, GameSpriteName.Squid);
                        command.AddImage(ImageName.Squid_Open);
                        command.AddImage(ImageName.Squid_Close);
                        break;
                    }
                case AnimationName.CrabCmd:
                    {
                        command = new AnimationCommand(name, GameSpriteName.Crab);
                        command.AddImage(ImageName.Crab_Open);
                        command.AddImage(ImageName.Crab_Close);
                        break;
                    }
                case AnimationName.OctopusCmd:
                    {
                        command = new AnimationCommand(name, GameSpriteName.Octopus);
                        command.AddImage(ImageName.Octopus_Open);
                        command.AddImage(ImageName.Octopus_Close);
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }
           
            return command;

        }
    }
}
