using System;
using System.Runtime.InteropServices;

namespace FilePathPicker.Runtime.Windows.Managed.Data
{
    /// <summary>
    /// Represents file array.
    /// </summary>
    /// <remarks>
    /// Since its a COM object, order of functions matters.
    /// </remarks>
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("B63EA76D-1F85-456F-A19C-48159EFA858B")]
    internal interface IWindowsShellItemArray
    {
        public void BindToHandler();
        public void GetPropertyStore();
        public void GetPropertyDescriptionList();
        public void GetAttributes();
        public void GetCount(out uint count);
        public void GetItemAt(uint index, out IWindowsShellItem shellItem);
    }
}