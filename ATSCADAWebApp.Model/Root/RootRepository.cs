using ATSCADAWebApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ATSCADAWebApp.Model
{
    public class RootRepository
    {
        #region FILEDS

        private string role;
     
        private readonly ICompositeSerializer serializer;

        private static readonly Lazy<RootRepository> lazy = new Lazy<RootRepository>(() => new RootRepository());

        #endregion

        #region PROPERTIES

        public static RootRepository Instance => lazy.Value;

        public bool Status => Application != null;

        // App
        public ATSCADAApp Application { get; private set; }

        // Danh sach View duoc phep truy cap
        public IEnumerable<IATSCADAView> ViewAccessed { get; private set; }

        public string Role
        {
            get => this.role;
            set
            {
                if (this.role == value) return;
                this.role = value;

                ViewAccessed = GetViews();
            }
        }

        #endregion

        private RootRepository()
        {
            this.serializer = new CompositeSerializer<ATSCADAApp>();
        }
        /// <summary>
        /// Load project tu file cau hinh .xml
        /// </summary>
        /// <param name="configPath"></param>
        /// <returns></returns>
        public bool Deserialize(string configPath)
        {
            this.serializer.Location = configPath;
            Application = this.serializer.Deserialize() as ATSCADAApp;            
            return Status;
        }

        // Get danh sach View duoc phep truy cap theo Role
        private IEnumerable<IATSCADAView> GetViews()
        {
            foreach (var component in Application?.Components)
            {
                if (component is IATSCADAView view)
                {
                    if (!Application.Authentication.Required)
                        yield return view;
                    else
                    {
                        var roles = view.Roles.Split(',').Select(x => x.Trim()).ToArray();
                        var index = Array.IndexOf(roles, this.role.Trim());
                        if (Array.IndexOf(roles, this.role.Trim()) > -1)
                            yield return view;
                    }
                }
            }
        }
    }
}
