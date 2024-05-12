namespace ATSCADAWebApp.Core
{
    public interface ICompositeSerializer
    {
        string Location { get; set; }

        bool Serialize(IComposite app);

        IComposite Deserialize();     
    }
}
