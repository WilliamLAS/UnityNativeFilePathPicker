using FilePathPicker.Runtime.Unmanaged.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilePathPicker.Runtime.Managed.Data
{
    /// <summary>
	/// Wrapper for async operation of file picking.
	/// </summary>
    public readonly struct PickFilePathOperation
    {
        private readonly FilePathPickerOptions m_Options;
        private readonly TaskCompletionSource<IEnumerable<FilePath>> m_TaskController;

        public readonly FilePathPickerOptions Options
            => m_Options;

        public readonly Task<IEnumerable<FilePath>> Task
            => m_TaskController.Task;


        // Initialize
        public PickFilePathOperation(FilePathPickerOptions options)
        {
            m_Options = options;
            m_TaskController = new ();
        }


        // Update
        public readonly void CompleteTask(IEnumerable<FilePath> value)
        {
            m_TaskController.SetResult(value);
        }
    }
}