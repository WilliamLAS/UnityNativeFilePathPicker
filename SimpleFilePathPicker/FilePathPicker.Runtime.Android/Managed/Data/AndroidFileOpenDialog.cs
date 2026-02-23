using UnityEngine;
using UnityEngine.Android;

namespace FilePathPicker.Runtime.Android.Managed.Data
{
    internal class AndroidFileOpenDialog : AndroidJavaObject
    {
        public string[] MIMEFileTypes
        {
            get => Get<string[]>(nameof(MIMEFileTypes));
            set => Set(nameof(MIMEFileTypes), value);
        }

        public AndroidFileOpenDialogOptions Options
        {
            get => new AndroidFileOpenDialogOptions(Get<AndroidJavaObject>(nameof(Options)).GetRawObject());
            set => Set(nameof(Options), value);
        }

        public AndroidFileOpenDialogCallback Callback
        {
            get => Get<AndroidFileOpenDialogCallback>(nameof(Callback));
            set => Set(nameof(Callback), value);
        }


        // Initialize
        public AndroidFileOpenDialog() : base("com.cometgames.filepathpicker.managed.data.FileOpenDialog")
        { }


        // Update
        public void ShowUsingGameActivity()
        {
            Call("ShowUsingActivity", AndroidApplication.currentActivity);
        }
    }
}