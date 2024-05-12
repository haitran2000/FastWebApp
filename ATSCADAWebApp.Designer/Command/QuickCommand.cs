using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Service;
using ATSCADAWebApp.Extension.TagCollection;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public class QuickCommand : CommandBase
    {
        private readonly IStorageService storageService;

        private readonly IComponenService componenService;

        private readonly TagCollectionAccess collectionAccess;

        public QuickCommand(
            IStorageService storageService,
            IComponenService componenService)
        {
            Level = 0;
            Name = "Quick";
            Enabled = true;
            Icon = Properties.Resources.Quick;
            ShortcutKeys = Keys.Control | Keys.Q;

            this.storageService = storageService;
            this.componenService = componenService;
            this.collectionAccess = new TagCollectionAccess();
        }

        public override void Execute()
        {
            if (!this.storageService.CheckSaved()) return;
            var defaultComponent = GetDefaultComponents();
            this.storageService.New(defaultComponent);           
        }

        private IEnumerable<IComponent> GetDefaultComponents()
        {
            var tagCollection = this.collectionAccess.Convert();
            var tagNames = tagCollection is null ? new string[0] : tagCollection.ToArray();
            var components = this.componenService.GetComponents(x => x is IDefaultableObject);
            foreach (var component in components)
            {
                var defaultObjects = (component as IDefaultableObject).DefaultObject(tagNames);
                foreach (var defaultObject in defaultObjects)
                    yield return defaultObject;
            }                
        }
    }
}
