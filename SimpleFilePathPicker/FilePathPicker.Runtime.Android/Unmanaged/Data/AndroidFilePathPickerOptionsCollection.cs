using FilePathPicker.Runtime.Unmanaged.Data;

namespace FilePathPicker.Runtime.Android.Unmanaged.Data
{
    public struct AndroidFilePathPickerOptionsCollection
    {
        public static readonly FilePathPickerOptions Songs = new ()
        {
            PickerTitle = $"Select {nameof(Songs)}",
            FileTypes = new()
            {
                new FileType()
                {
                    Value = "audio/mpeg", // .mp3
                }
            }
        };
    }
}