using RudeBuild;

namespace RudeBuildAddIn
{
    public class GlobalSettingsCommand : CommandBase
    {
        public override void Execute(CommandManager commandManager)
        {
        }

        public override bool IsEnabled(CommandManager commandManager)
        {
            return true;
        }
    }
}
