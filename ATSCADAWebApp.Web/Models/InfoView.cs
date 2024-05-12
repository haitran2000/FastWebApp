using ATSCADAWebApp.Core;

namespace ATSCADAWebApp.Web.Models
{
    // Thong tin ve du an
    public class InfoView
    {        
        // Tieu de
        public string Title { get; set; }

        // Brand
        public string Brand { get; set; }

        // Tac gia
        public string Author { get; set; }

        // Chu thich
        public string Description { get; set; }

        // Co bat che do DarkMode mac dinh hay khong
        public bool DarkMode { get; set; }
        
        public InfoView(ATSCADAApp app)
        {
            if (app is null) return;
            Title = app.Title;
            Brand = app.Brand;
            Author = app.Author;
            Description = app.Description;
            DarkMode = app.DarkMode;
        }       
    }
}
