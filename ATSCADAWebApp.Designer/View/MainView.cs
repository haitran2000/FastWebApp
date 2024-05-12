using ATSCADAWebApp.Designer.Presenter;
using ATSCADAWebApp.Designer.Service;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.View
{
    public partial class MainView : Form, IMainView
    {
        private const string Default = "FastWeb Designer - Ver 4.0.0.1";

        private readonly IStorageService storageService;

        public MainPresenter Presenter { get; set; }

        public MainView(           
            Control menuView,
            Control toolbarView,
            Control toolStripView,
            Control groupView,
            Control elementListView,
            IStorageService storageService)
        {
            InitializeComponent();
            this.storageService = storageService;

            Controls.Add(toolbarView);
            Controls.Add(menuView);
            Controls.Add(toolStripView);
            groupView.Dock = DockStyle.Fill;
            elementListView.Dock = DockStyle.Fill;
            this.mainContainer.Panel1.Controls.Add(groupView);
            this.mainContainer.Panel2.Controls.Add(elementListView);
            this.storageService.PropertyChanged += StoragePropertyChanged;

            this.Text = $"{Default}";            
            this.FormClosing += MainView_FormClosing;
        }

        private void StoragePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (string.Equals(e.PropertyName, "RequestSaved") ||
                string.Equals(e.PropertyName, "Location"))
            {
                this.Text = this.storageService.RequestSaved ?
                $"{Default}     {this.storageService.Location}  *" :
                $"{Default}     {this.storageService.Location}";
            }
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.storageService.CheckSaved()) e.Cancel = true;            
        }
    }
}
