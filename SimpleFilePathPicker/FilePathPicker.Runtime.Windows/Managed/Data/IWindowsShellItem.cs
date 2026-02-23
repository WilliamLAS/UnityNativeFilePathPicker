using FilePathPicker.Runtime.Windows.Unmanaged.Data;
using System;
using System.Runtime.InteropServices;

namespace FilePathPicker.Runtime.Windows.Managed.Data
{
    /// <summary>
    /// Represents a file.
    /// </summary>
    [ComImport]
    [Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IWindowsShellItem
    {
        public void BindToHandler();
        public void GetParent();
        public void GetDisplayName(WindowsShellItemDisplayNameFormat displayFormat, [MarshalAs(UnmanagedType.LPWStr)] out string result);
    }
}