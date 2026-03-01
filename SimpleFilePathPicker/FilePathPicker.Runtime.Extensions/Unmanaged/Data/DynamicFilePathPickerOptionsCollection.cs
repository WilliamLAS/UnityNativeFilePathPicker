#if UNITY_EDITOR || UNITY_STANDALONE_WIN
using FilePathPicker.Runtime.Windows.Unmanaged.Data;
#elif UNITY_ANDROID
using FilePathPicker.Runtime.Android.Unmanaged.Data;
#endif

using FilePathPicker.Runtime.Unmanaged.Data;

namespace FilePathPicker.Runtime.Extensions.Unmanaged.Data
{
    public struct DynamicFilePathPickerOptionsCollection
    {
        public static readonly FilePathPickerOptions Songs =
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        WindowsFilePathPickerOptionsCollection.Songs;
#elif UNITY_ANDROID
        AndroidFilePathPickerOptionsCollection.Songs;
#else
        default;
#endif
    }
}