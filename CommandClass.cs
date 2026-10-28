using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Intro
{
    [Transaction(TransactionMode.Manual)]
    public class CommandClass : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            TaskDialog.Show("Внимание", "Привет");
            return Result.Succeeded;
        }
    }

    [Transaction(TransactionMode.Manual)]
    public class ApplicationClass : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            application.CreateRibbonTab("Пик-Привет");
            var panel = application.CreateRibbonPanel("Пик-Привет", "Общее");
            var button = new PushButtonData(
                "Hello",
                "Привет",
                "C:\\Users\\avsmirnov\\AppData\\Roaming\\Autodesk\\Revit\\Addins\\2019\\Test\\Intro.dll",
                "Intro.CommandClass");
            panel.AddItem(button);
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}
