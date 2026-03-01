using FilePathPicker.Runtime.Unmanaged.Data;

namespace FilePathPicker.Runtime.Windows.Unmanaged.Data
{
    public struct WindowsFilePathPickerOptionsCollection
    {
        public static readonly FilePathPickerOptions Songs = new ()
        {
            PickerTitle = $"Select {nameof(Songs)}",
            FileTypes = new()
            {
                new FileType()
                {
                    Value = "*.mp3",
                }
            }
        };
    }
}