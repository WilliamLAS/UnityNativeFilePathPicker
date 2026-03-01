using FilePathPicker.Runtime.Android.Managed.Data;
using FilePathPicker.Runtime.Managed.Data;
using FilePathPicker.Runtime.Unmanaged.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace FilePathPicker.Runtime.Android.Unmanaged.Data
{
    /// <inheritdoc cref="IFilePathPicker"/>
    public struct AndroidFilePathPicker : IFilePathPicker
    {
        public FilePathPickerOptions Options { get; set; }


        // Helpers
        private static AndroidFileOpenDialog CreateFileOpenDialogForOperation(PickFilePathOperation operation, AndroidFileOpenDialogOptions additionalOptions = AndroidFileOpenDialogOptions.None)
        {
            AndroidFileOpenDialog dialog = new ();
            dialog.Options.Value |= (int)additionalOptions;

            if (operation.Options.FileTypes.Length > 0)
            {
                string[] fileTypes = new string[operation.Options.FileTypes.Length];
                for (int i = 0; i < fileTypes.Length; i++)
                {
                    fileTypes[i] = operation.Options.FileTypes[i].Value.ToString();
                }

                dialog.MIMEFileTypes = fileTypes;
            }

            dialog.SelectedFilePathDirectory = operation.Options.SelectedFilePathDirectory.ToString();
            return dialog;
        }

        private static void ShowFileOpenDialogForOperation(AndroidFileOpenDialog dialog, PickFilePathOperation operation)
        {
            dialog.Callback = new AndroidFileOpenDialogCallback(operation);
            dialog.ShowUsingGameActivity();
        }


        // Update
        public Task<FilePath> PickAsync()
        {
            PickFilePathOperation pickFilePathOperation = new(Options);
            return new(() =>
            {
                Thread pickThread = new(() =>
                {
                    AndroidJNI.AttachCurrentThread();
                    ShowFileOpenDialogForOperation(CreateFileOpenDialogForOperation(pickFilePathOperation), pickFilePathOperation);
                    AndroidJNI.DetachCurrentThread();
                });

                pickThread.SetApartmentState(ApartmentState.STA);
                pickThread.Start();
                pickFilePathOperation.Task.Wait();

                foreach (var filePath in pickFilePathOperation.Task.Result)
                {
                    return filePath;
                }
                return default;
            });
        }

        public Task<IEnumerable<FilePath>> PickMultipleAsync()
        {
            PickFilePathOperation pickFilePathOperation = new(Options);
            return new(() =>
            {
                Thread pickThread = new (() =>
                {
                    AndroidJNI.AttachCurrentThread();
                    ShowFileOpenDialogForOperation(CreateFileOpenDialogForOperation(pickFilePathOperation, AndroidFileOpenDialogOptions.AllowMultipleSelection), pickFilePathOperation);
                    AndroidJNI.DetachCurrentThread();
                }
                );

                pickThread.SetApartmentState(ApartmentState.STA);
                pickThread.Start();
                pickFilePathOperation.Task.Wait();
                
                return pickFilePathOperation.Task.Result;
            });
        }
    }
}