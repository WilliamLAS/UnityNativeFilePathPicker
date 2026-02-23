using System;

namespace FilePathPicker.Runtime.Windows.Unmanaged.Data
{
    [Flags]
    internal enum WindowsFileOpenDialogOptions : uint
    {
        None = 0,
        AllowMultipleSelection = 512,
        PathMustExist = 2048,
        FileMustExist = 4096,
    }
}