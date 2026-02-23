using FilePathPicker.Runtime.Unmanaged.Data;
using System.Runtime.InteropServices;

namespace FilePathPicker.Runtime.Windows.Managed.Data
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal readonly struct WindowsFileType
    {
        [MarshalAs(UnmanagedType.LPWStr)]
        private readonly string m_DisplayName;

        [MarshalAs(UnmanagedType.LPWStr)]
        private readonly string m_FileType;


        // Initialize
        public WindowsFileType(FileType fileType)
        {
            string fileTypeValue = fileType.Value.ToString();
            m_DisplayName = fileTypeValue;
            m_FileType = fileTypeValue;
        }
    }
}