using FilePathPicker.Runtime.Unmanaged.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilePathPicker.Runtime.Managed.Data
{
    /// <summary>
	/// Lets the user pick a file from the device's storage.
	/// </summary>
    public interface IFilePathPicker
    {
        public FilePathPickerOptions Options { get; }


        // Update
        /// <summary>
        /// Opens the default file picker to allow the user to pick multiple files.
        /// </summary>
        /// <returns>
        /// An IEnumerable of file picking result objects. When the operation was cancelled by the user, this will return an empty collection.
        /// </returns>
        public Task<IEnumerable<FilePath>> PickMultipleAsync();

        /// <summary>
        /// Opens the default file picker to allow the user to pick a single file.
        /// </summary>
        /// <returns>
        /// When the operation was cancelled by the user, this will return an empty file path.
        /// </returns>
        public Task<FilePath> PickAsync();
    }
}