using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Service
{
    public class FileHelper
    {
        #region FIELDS

        private const string ProjectFolder = "Project Files";

        private const string ConfigFolder = "Template/AppConfig";

        private const string ConfigFile = "ATSCADAWebConfig.xml";
       
        private readonly string startupLocation;
        
        #endregion

        #region CONSTRUCTORS

        public FileHelper()
        {
            this.startupLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);          
        }

        public FileHelper(string startupLocation)
        {
            this.startupLocation = startupLocation;            
        }

        #endregion

        #region METHODS

        public bool Exists(string location)
        {
            return File.Exists(location);
        }

        public bool GetOpenFileLocation(out string location)
        {
            location = string.Empty;
            var projectFolderLocation = Path.Combine(startupLocation, ProjectFolder);            
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML Files (*.xml)|*.xml";
            openFileDialog.InitialDirectory = projectFolderLocation;
            if (openFileDialog.ShowDialog() != DialogResult.OK) return false;
            if (!string.Equals(Path.GetExtension(openFileDialog.FileName), ".xml", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("The type of the selected file is not supported by this application. You must select an XML file.",
                              "ATSCADA Message",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return false;
            }
            location = openFileDialog.FileName;
            return true;
        }

        public bool GetSaveFileLocation(out string location)
        {
            location = string.Empty;
            var projectFolderLocation = Path.Combine(startupLocation, ProjectFolder);            
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
            saveFileDialog.InitialDirectory = projectFolderLocation;
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return false;
            location = saveFileDialog.FileName;
            return true;
        }

        public void RegisterProject(string sourceLocation)
        {
            if (!string.Equals(Path.GetExtension(sourceLocation), ".xml", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("The project file is not supported by this application. You must select an XML file.",
                              "ATSCADA Message",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return;
            }
            var configFolderLocation = Path.Combine(this.startupLocation, ConfigFolder);
            if (!Directory.Exists(configFolderLocation))
                Directory.CreateDirectory(configFolderLocation);

            var configFileLocation = Path.Combine(configFolderLocation, ConfigFile);
            File.Copy(sourceLocation, configFileLocation, true);
        }
        
        #endregion;
    }
}
