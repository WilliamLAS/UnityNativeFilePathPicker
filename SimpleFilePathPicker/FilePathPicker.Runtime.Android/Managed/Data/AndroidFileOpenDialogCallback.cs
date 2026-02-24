using FilePathPicker.Runtime.Managed.Data;
using FilePathPicker.Runtime.Unmanaged.Data;
using UnityEngine;

namespace FilePathPicker.Runtime.Android.Managed.Data
{
    /// <summary>
    /// Java Native Interface: public interface IFileOpenDialogCallback
    /// </summary>
    public class AndroidFileOpenDialogCallback : AndroidJavaProxy
    {
        private readonly PickFilePathOperation m_PickFilePathOperation;


        // Initialize
        public AndroidFileOpenDialogCallback(PickFilePathOperation pickFilePathOperation)
            : base("com.cometgames.filepathpicker.managed.data.IFileOpenDialogCallback")
        {
            m_PickFilePathOperation = pickFilePathOperation;
        }


        // Update
        /// <summary>
        /// Java Native Interface: public void OnPickedPaths(String[]);
        /// </summary>
        private void OnPickedPaths(string[] paths)
        {
            FilePath[] filePaths = new FilePath[paths.Length];
            for (int i = 0; i < paths.Length; i++)
            {
                filePaths[i] = new FilePath()
                {
                    Value = paths[i],
                };
            }

            m_PickFilePathOperation.CompleteTask(filePaths);
        }
    }
}