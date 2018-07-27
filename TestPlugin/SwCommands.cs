using System;
using System.IO;
using AngelSix.SolidDna;
using Environment = System.Environment;

namespace TestPlugin
{
    /// <summary>
    /// Incapsulate sw commands logic
    /// </summary>
    public static class SwCommands
    {
        /// <summary>
        /// Upload current active model to CloudSlicer and force Print from Web interface 
        /// </summary>
        public static void ForcePrintFromWeb()
        {
            var location = $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}";
            var tempFileName = $"sw_temp_{Guid.NewGuid()}".Replace("-", "");
            var tempFileLocation = $@"{location}\{tempFileName}.stl";

            var tempResult = SolidWorksEnvironment.Application.ActiveModel.SaveAs(tempFileLocation);
            if (!tempResult.Successful)
            {
                return;
            }

            try
            {
                using (var source = File.Open(tempFileLocation, FileMode.Open, FileAccess.Read, FileShare.Read))
                {

                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                Array.ForEach(new[] { tempFileLocation }, File.Delete);
            }
        }
    }
}
