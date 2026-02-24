using System;

namespace FilePathPicker.Runtime.Android.Unmanaged.Data
{
    /// <summary>
    /// Represents <see cref="Managed.Data.AndroidFileOpenDialogOptions.Value"/>
    /// </summary>
    [Flags]
    internal enum AndroidFileOpenDialogOptions
    {
        None = 0,
        AllowMultipleSelection = 1,
    }
}