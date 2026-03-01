using Unity.Collections;

namespace FilePathPicker.Runtime.Unmanaged.Data
{
    /// <summary>
    /// Represents options that can be used to customize the working of <see cref="Managed.Data.IFilePathPicker"/>.
    /// </summary>
    public struct FilePathPickerOptions
    {
        /// <summary>
        /// Title used for the file picker that is shown to the user.
        /// </summary>
        /// <remarks>
        /// Not guaranteed to be shown. If you dont see it, its because of the platform.
        /// </remarks>
        public FixedString32Bytes PickerTitle;

        /// <summary>
        /// List of file types that file file picker should return.
        /// </summary>
        /// <remarks>
        /// The contents of this array is platform specific; every platform has its own way to
        /// specify the file types.
        /// <para>On Android you can specify one or more MIME types, e.g.
        /// <c>image/png</c>. Additionally, wildcard characters can be used, e.g. <c>image/*</c></para>
        /// <para>On iOS, you can specify <c>UTType</c> constants, e.g. <c>UTType.Image</c>.</para>
        /// <para>On Windows, you can specify a list of extensions, like this: <c>"*.jpg", "*.png"</c>.</para>
        ///</remarks>
        public FixedList512Bytes<FileType> FileTypes;

        /// <summary>
        /// To ensure the security of the file, you wont get the actual file path.
        /// Instead, the system will create a copy of that file at that directory.
        /// </summary>
        public FixedString128Bytes SelectedFilePathDirectory;
    }
}