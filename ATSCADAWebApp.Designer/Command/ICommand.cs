using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ATSCADAWebApp.Designer.Command
{
    /// <summary>
    /// Interface commnad. Dai dien cho tat cac ca lenh, thao tac
    /// Dong goi cac dieu khien thanh doi tuong
    /// </summary>
    public interface ICommand : INotifyPropertyChanged
    {
        /// <summary>
        /// Quy dinh Component nao duoc dieu khien
        /// 0. App
        /// 1. View
        /// 2. Row
        /// 3. Column
        /// 4. Element
        /// </summary>
        int Level { get; }

        string Name { get; set; }

        /// <summary>
        /// Co cho phep thao tac hay khong
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Iocn hien thi
        /// </summary>
        Image Icon { get; set; }        

        /// <summary>
        /// Phim tat
        /// </summary>
        Keys ShortcutKeys { get; }

        /// <summary>
        /// Lenh thuc thi
        /// </summary>
        void Execute();
    }
}
