using ATSCADAWebApp.Core;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Service
{
    /// <summary>
    /// Quan ly chung cho toan bo App
    /// </summary>
    public class StorageService : BindableCore, IStorageService
    {
        #region FIELDS

        private bool requestSaved;

        private string location;

        private IComposite composite;

        private readonly ICompositeSerializer serializer;

        private readonly FileHelper fileHelper;

        #endregion

        #region PROPERTIES
        /// <summary>
        /// Co thay doi ve cau hinh. Yeu cau Save 
        /// </summary>
        public bool RequestSaved
        {
            get => this.requestSaved;
            private set => SetField(ref this.requestSaved, value);
        }
        /// <summary>
        /// Path cua file cau hinh .xml
        /// </summary>
        public string Location
        {
            get => this.location;
            private set => SetField(ref this.location, value);
        }
        /// <summary>
        /// App
        /// </summary>
        public IComposite Composite
        {
            get => this.composite;
            private set
            {
                if (this.composite != null)
                    this.composite.PropertyChanged -= CompositePropertyChanged;
                if (SetField(ref this.composite, value))
                {
                    if (this.composite != null)
                        this.composite.PropertyChanged += CompositePropertyChanged;
                }
            }
        }

        #endregion

        #region CONSTRUCTORS

        public StorageService(ICompositeSerializer serializer)
        {
            this.serializer = serializer;
            this.fileHelper = new FileHelper();
        }

        public StorageService(string startupLocation, ICompositeSerializer serializer)
        {
            this.serializer = serializer;
            this.fileHelper = new FileHelper(startupLocation);
        }

        #endregion

        #region METHODS

        /// <summary>
        /// Tao moi Project
        /// </summary>
        public void New()
        {            
            Location = "";
            Composite = new ATSCADAApp();
            RequestSaved = true;

            Composite?.Update();
        }

        /// <summary>
        /// Tao moi project.\
        /// Tinh nang Quick. Add cac component
        /// </summary>
        /// <param name="components"></param>
        public void New(IEnumerable<IComponent> components)
        {            
            var app = new ATSCADAApp();
            var view = new ATSCADAView(app);
            var row = new ATSCADARow(view);
            var column = new ATSCADAColumn(row);
            foreach (var component in components)
                column.Add(component);          

            Location = "";
            Composite = app;
            RequestSaved = true;            
        }

        /// <summary>
        /// Mo project (tu file .xml)
        /// </summary>
        public void Open()
        {
            if (!this.fileHelper.GetOpenFileLocation(out string location)) return;
            Location = location;
            serializer.Location = Location;
            Composite = this.serializer.Deserialize();
            RequestSaved = false;
        }

        /// <summary>
        /// Luu project
        /// </summary>
        public void Save()
        {
            if (!this.fileHelper.Exists(Location)) SaveAs();
            else
            {
                this.serializer.Serialize(this.composite);
                RequestSaved = false;
            }
        }

        /// <summary>
        /// Tao moi file, luu project
        /// </summary>
        public void SaveAs()
        {
            if (!this.fileHelper.GetSaveFileLocation(out string location)) return;
            Location = location;
            serializer.Location = Location;
            this.serializer.Serialize(this.composite);
            RequestSaved = false;
        }

        /// <summary>
        /// Dang ky file config vao folder web
        /// </summary>
        public void Register()
        {           
            this.fileHelper.RegisterProject(Location);
        }

        private void CompositePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            RequestSaved = true;
        }

        public bool CheckSaved()
        {
            if (this.requestSaved)
            {
                var dialogResult = MessageBox.Show(
                    "The working project file is not saved. Do you want to save now?",
                    "ATSCADA",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Cancel) return false;
                if (dialogResult == DialogResult.Yes)
                {
                    Save();
                    return true;
                }
            }
            return true;
        }

        #endregion

    }
}
