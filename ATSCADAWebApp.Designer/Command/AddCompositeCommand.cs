using ATSCADAWebApp.Core;
using ATSCADAWebApp.Designer.View;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    public abstract class AddCompositeCommand : CommandBase
    {
        private readonly ICompositeView compositeView;

        private readonly IComponentView componentView;

        public AddCompositeCommand(ICompositeView compositeView, IComponentView componentView)
        {
            this.compositeView = compositeView;
            this.componentView = componentView;
        }

        public override void Execute()
        {
            var compositeNode = this.compositeView.SelectedNode;
            if (compositeNode is null) return;
            while (compositeNode.Level > Level - 1)
            {
                compositeNode = compositeNode.Parent;
                if (compositeNode is null) return;
            }
            if (compositeNode.Tag is IComposite composite)
            {
                var component = GetComponent();                
                if (component.Update())
                {
                    composite.Add(component);
                    this.compositeView.AddNode(compositeNode, component);
                    if (compositeNode.Level == this.compositeView.SelectedNode.Level)
                        this.componentView.AddItem(component);
                    compositeNode.Expand();
                }
            }
            else
            {
                MessageBox.Show(
                    "The object does not support sublist.",
                    "ATSCADA",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning);
            }
        }

        protected abstract IComponent GetComponent();
    }

    public class AddViewCommand : AddCompositeCommand
    {
        public AddViewCommand(ICompositeView compositeView, IComponentView componentView)
            : base(compositeView, componentView)
        {
            Level = 1;
            Name = "New View";
            Icon = null;
            ShortcutKeys = Keys.Alt | Keys.V;
        }

        protected override IComponent GetComponent()
        {
            return new ATSCADAView();
        }
    }

    public class AddHyperlinkViewCommand: AddCompositeCommand
    {
        public AddHyperlinkViewCommand(ICompositeView compositeView, IComponentView componentView)
            : base(compositeView, componentView)
        {
            Level = 1;
            Name = "New HyperlinkView";
            Icon = null;
            ShortcutKeys = Keys.Alt | Keys.H;
        }

        protected override IComponent GetComponent()
        {
            return new ATSCADAHyperlinkView();
        }
    }

    public class AddRowCommand : AddCompositeCommand
    {
        public AddRowCommand(ICompositeView compositeView, IComponentView componentView)
            : base(compositeView, componentView)
        {
            Level = 2;
            Name = "New Row";
            Icon = Properties.Resources.AddRow;
            ShortcutKeys = Keys.Alt | Keys.R;
        }

        protected override IComponent GetComponent()
        {
            return new ATSCADARow();
        }
    }

    public class AddColumnCommand : AddCompositeCommand
    {
        public AddColumnCommand(ICompositeView compositeView, IComponentView componentView)
            : base(compositeView, componentView)
        {
            Level = 3;
            Name = "New Column";
            Icon = Properties.Resources.AddColumn;
            ShortcutKeys = Keys.Alt | Keys.C;
        }

        protected override IComponent GetComponent()
        {
            return new ATSCADAColumn();
        }
    }
}
