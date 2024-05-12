using System.Collections.Generic;

namespace ATSCADAWebApp.Designer.Command
{
    /// <summary>
    /// Kho chua, quan ly cac Command
    /// </summary>
    public interface ICommandFactory
    {
        /// <summary>
        /// Dang kys doi tuong Command
        /// </summary>
        /// <param name="commands"></param>
        void Register(params object[] commands);

        void Register(object command);

        /// <summary>
        /// Get Command theo Type, kieu Class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        ICommand Get<T>() where T : class, ICommand;

        IEnumerable<ICommand> GetAll();
    }
}
