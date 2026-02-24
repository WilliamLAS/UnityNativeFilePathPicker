using System;
using UnityEngine;

namespace FilePathPicker.Runtime.Android.Managed.Data
{
    /// <summary>
    /// Java Native Interface: public class FileOpenDialogOptionFlags
    /// </summary>
    internal class AndroidFileOpenDialogOptions : AndroidJavaObject
    {
        /// <summary>
        /// Java Native Interface: public int Value
        /// </summary>
        public int Value
        {
            get => Get<int>(nameof(Value));
            set => Set(nameof(Value), value);
        }


        // Initialize
        public AndroidFileOpenDialogOptions(int flagValue) : base("com.cometgames.filepathpicker.managed.data.FileOpenDialogOptionFlags", flagValue)
        { }

        public AndroidFileOpenDialogOptions(IntPtr jobject) : base(jobject)
        { }
    }
}