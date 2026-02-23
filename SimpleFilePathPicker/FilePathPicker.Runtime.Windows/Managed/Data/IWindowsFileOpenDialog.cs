using FilePathPicker.Runtime.Windows.Unmanaged.Data;
using System;
using System.Runtime.InteropServices;

namespace FilePathPicker.Runtime.Windows.Managed.Data
{
    [ComImport]
    [Guid("d57c7288-d4ad-4768-be02-9d969532d960")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface IWindowsFileOpenDialog
    {
        /// <remarks>
        /// Blocks thread until something happens
        /// </remarks>
        /// <returns> 0 if succeeded </returns>
        [PreserveSig]
        public int Show(IntPtr parentWindowHandle);

        public void SetFileTypes(uint fileTypesCount, [MarshalAs(UnmanagedType.LPArray)] WindowsFileType[] fileTypes);

        public void SetFileTypeIndex(uint selectedFileTypeIndex);
        public void GetFileTypeIndex(out uint selectedFileTypeIndex);
        public void Advise();
        public void Unadvise();
        public void SetOptions(WindowsFileOpenDialogOptions options);
        public void GetOptions(out WindowsFileOpenDialogOptions options);
        public void SetDefaultFolder();
        public void SetFolder();
        public void GetFolder();
        public void GetCurrentSelection();
        public void SetFileName();
        public void GetFileName();
        public void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string dialogTitle);
        public void SetOkButtonLabel();
        public void SetFileNameLabel();
        public void GetResult(out IWindowsShellItem item);
        public void AddPlace();
        public void SetDefaultExtension();
        public void Close();
        public void SetClientGuid();
        public void ClearClientData();
        public void SetFilter();
        public void GetResults(out IWindowsShellItemArray items);
        public void GetSelectedItems(out IWindowsShellItemArray items);
    }
}