using System.Collections.Generic;
using System.IO;
using AngelSix.SolidDna;
using Dna;

namespace TestPlugin
{
    /// <summary>
    /// Register COM add-in
    /// </summary>
    public class SolidDnaAddinIntegration : AddInIntegration
    {
        public override void ApplicationStartup()
        {

        }

        public override void PreLoadPlugIns()
        {

        }

        public override void PreConnectToSolidWorks()
        {
            // NOTE: To run in our own AppDomain do the following
            //       Be aware doing so sometimes causes API's to fail
            //       when they try to load dll's
            //
            // PlugInIntegration.UseDetachedAppDomain = true;
        }

        public override void ConfigureServices(FrameworkConstruction construction)
        {

        }
    }

    /// <summary>
    /// Register plug-in
    /// </summary>
    public class SolidDnaPlugin : SolidPlugIn
    {
        #region Private

        private TaskpaneIntegration<TaskPane> mTaskpane;

        #endregion

        #region Public Properties

        public override string AddInDescription => "Test plugin";

        public override string AddInTitle => "Test plugin";

        #endregion

        #region Connect To SolidWorks

        public override void ConnectedToSolidWorks()
        {
            mTaskpane = new TaskpaneIntegration<TaskPane>
            {
                Icon = Path.Combine(this.AssemblyPath(), @"Images\mb-logo_20.png"),
                WpfControl = new MainControl()
            };

            mTaskpane.AddToTaskpaneAsync();
            AddCommands();
        }

        public override void DisconnectedFromSolidWorks()
        {

        }

        #endregion

        #region Command groups

        private static CommandManagerGroup _commandsGroup;
        private const string PluginName = "Test MakerBot SolidWorks Plugin";

        /// <summary>
        /// Add commands tab to work with model
        /// </summary>
        public static void AddCommands()
        {
            var location = Path.GetDirectoryName(typeof(SolidDnaPlugin).Assembly.Location) ?? string.Empty;
            var imageList = Path.Combine(Path.Combine(location, @"Images"), @"mb-logo_{0}.png");

            const string name = "Test plugin";
            const string hint = "Test plugin";

            _commandsGroup = SolidWorksEnvironment.Application.CommandManager.CreateCommands(
                PluginName,
                new List<CommandManagerItem>
                {
                    new CommandManagerItem
                    {
                        Name = name,
                        Tooltip = name,
                        ImageIndex = 0,
                        Hint = hint,
                        VisibleForDrawings = false,
                        VisibleForAssemblies = true,
                        VisibleForParts = true,
                        OnClick = SwCommands.ForcePrintFromWeb
                    }
                },
                imageList, name, hint);
        }
        
        #endregion
    }
}
