#if UNITY_EDITOR || UNITY_STANDALONE_WIN
using FilePathPicker.Runtime.Windows.Unmanaged.Data;
#elif UNITY_ANDROID
using FilePathPicker.Runtime.Android.Unmanaged.Data;
#endif

using FilePathPicker.Runtime.Managed.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using FilePathPicker.Runtime.Unmanaged.Data;

namespace FilePathPicker.Runtime.Extensions.Unmanaged.Data
{
    /// <inheritdoc cref="IFilePathPicker"/>
	public struct DynamicFilePathPicker : IFilePathPicker
    {
        public FilePathPickerOptions Options { get; set; }


        // Update
        public readonly IFilePathPicker GetPickerForCurrentPlatform()
        {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            return new WindowsFilePathPicker()
            {
                Options = this.Options,
            };
#elif UNITY_ANDROID
            return new AndroidFilePathPicker()
            {
                Options = this.Options,
            };
#else
            Debug.LogError(
                @$"Platform not supported. You can solve with these steps:
                1) Create picker for {Application.platform}
            ");
            return null;
#endif
        }

        public readonly Task<FilePath> PickAsync()
        {
            return GetPickerForCurrentPlatform().PickAsync();
        }

        public readonly Task<IEnumerable<FilePath>> PickMultipleAsync()
        {
            return GetPickerForCurrentPlatform().PickMultipleAsync();
        }
    }
}
