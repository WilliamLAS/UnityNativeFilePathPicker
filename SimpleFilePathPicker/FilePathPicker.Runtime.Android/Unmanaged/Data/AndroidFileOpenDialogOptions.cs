using System;

namespace FilePathPicker.Runtime.Android.Unmanaged.Data
{
    [Flags]
    internal enum AndroidFileOpenDialogOptions
    {
        None = 0,
        AllowMultipleSelection = 1,
    }
}