using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.Presenter;
using System;
using System.Collections.Generic;

namespace ATSCADAWebApp.Designer.View
{
    public interface IAddComponentView
    {
        event Action Loaded;
        
        AddComponentPresenter Presenter { get; set; }

        IComponent Component { get; }
      
        void SetTemplates(IDictionary<Type, IComponent> templates);
    }
}
