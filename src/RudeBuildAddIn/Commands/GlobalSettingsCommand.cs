using RudeBuild;

namespace RudeBuildAddIn
{
    public class GlobalSettingsCommand : CommandBase
    {
        private Builder _builder;

        public GlobalSettingsCommand(Builder builder)
        {
            _builder = builder;
        }

        public override void Execute(CommandManager commandManager)
        {
            GlobalSettingsDialog dialog = new GlobalSettingsDialog();
            try
            {
                dialog.ShowDialog();
            }
            finally
            {
                dialog.Close();
            }
        }

        public override bool IsEnabled(CommandManager commandManager)
        {
            return !_builder.IsBuilding;
        }
    }
}