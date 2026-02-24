using Unity.Collections;

namespace FilePathPicker.Runtime.Unmanaged.Data
{
    /// <summary>
    /// Platform independent file type.
    /// </summary>
    /// <remarks>
    /// The value is platform dependent.
    /// Windows uses file extension as file type whereas Android uses MIME as file type etc...
    /// </remarks>
    public struct FileType
    {
        public FixedString32Bytes Value;
    }
}