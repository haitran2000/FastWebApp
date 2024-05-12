namespace ATSCADAWebApp.Core
{
    /// <summary>
    /// Giao dien cua trang (view)
    /// Moi view la 1 web pages (Ex: Layout, Report, Settings,...)
    /// </summary>
    public interface IATSCADAView : ISupportRender
    {
        string Content { get; set; }

        string Location { get; set; }

        string Icon { get; set; }

        string Roles { get; set; }    

    }    
}
