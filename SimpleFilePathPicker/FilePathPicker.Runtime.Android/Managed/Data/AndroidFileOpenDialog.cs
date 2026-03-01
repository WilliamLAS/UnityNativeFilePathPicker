using System;
using UnityEngine;
using UnityEngine.Android;

namespace FilePathPicker.Runtime.Android.Managed.Data
{
    /// <summary>
    /// Java Native Interface: public class FileOpenDialog
    /// </summary>
    internal class AndroidFileOpenDialog : AndroidJavaObject
    {
        /// <summary>
        /// Java Native Interface: public String[] MIMEFileTypes
        /// </summary>
        public string[] MIMEFileTypes
        {
            set => Set(nameof(MIMEFileTypes), value);
        }

        /// <summary>
        /// Java Native Interface: public String SelectedFilePathDirectory
        /// </summary>
        public string SelectedFilePathDirectory
        {
            set => Set(nameof(SelectedFilePathDirectory), value);
        }

        /// <summary>
        /// Java Native Interface: public FileOpenDialogOptionFlags Options
        /// </summary>
        public AndroidFileOpenDialogOptions Options
        {
            get => new AndroidFileOpenDialogOptions(Get<AndroidJavaObject>(nameof(Options)).GetRawObject());
            set => Set(nameof(Options), value);
        }

        /// <summary>
        /// Java Native Interface: public IFileOpenDialogCallback Callback
        /// </summary>
        public AndroidFileOpenDialogCallback Callback
        {
            set => Set(nameof(Callback), value);
        }


        // Initialize
        public AndroidFileOpenDialog() : base("com.cometgames.filepathpicker.managed.data.FileOpenDialog")
        { }


        // Update
        /// <summary>
        /// Java Native Interface: public void ShowUsingActivity(FragmentActivity)
        /// </summary>
        public void ShowUsingGameActivity()
        {
            Call("ShowUsingActivity", AndroidApplication.currentActivity);
        }
    }
}