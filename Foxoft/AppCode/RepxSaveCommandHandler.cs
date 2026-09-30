using DevExpress.XtraReports.UserDesigner;

namespace Foxoft.AppCode
{
    public class RepxSaveCommandHandler : ICommandHandler
    {
        private readonly XRDesignPanel panel;
        private readonly string filePath;

        public RepxSaveCommandHandler(XRDesignPanel panel, string filePath)
        {
            this.panel = panel;
            this.filePath = filePath;
        }

        public bool CanHandleCommand(ReportCommand command, ref bool defaultHandling)
        {
            return command == ReportCommand.SaveFile || command == ReportCommand.SaveFileAs;
        }

        public void HandleCommand(ReportCommand command, object[] args)
        {
            panel.Report.SaveLayoutToXml(filePath);
            panel.ReportState = ReportState.Saved;
        }
    }
}
