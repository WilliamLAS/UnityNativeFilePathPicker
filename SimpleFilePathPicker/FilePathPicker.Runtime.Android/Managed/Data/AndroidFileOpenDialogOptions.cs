using System;
using UnityEngine;

namespace FilePathPicker.Runtime.Android.Managed.Data
{
    internal class AndroidFileOpenDialogOptions : AndroidJavaObject
    {
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