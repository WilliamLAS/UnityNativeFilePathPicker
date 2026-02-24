using Unity.Collections;

namespace FilePathPicker.Runtime.Unmanaged.Data
{
    /// <summary>
    /// Platform independent file path
    /// </summary>
    public struct FilePath
    {
        public FixedString128Bytes Value;
    }
}