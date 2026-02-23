using FilePathPicker.Runtime.Managed.Data;
using FilePathPicker.Runtime.Unmanaged.Data;
using FilePathPicker.Runtime.Windows.Managed.Data;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FilePathPicker.Runtime.Windows.Unmanaged.Data
{
    /// <inheritdoc cref="IFilePathPicker"/>
    public struct WindowsFilePathPicker : IFilePathPicker
    {
        public FilePathPickerOptions Options { get; set; }


        // Helpers
        private static IWindowsFileOpenDialog CreateFileOpenDialogForOperation(PickFilePathOperation operation, WindowsFileOpenDialogOptions additionalOptions = WindowsFileOpenDialogOptions.None)
        {
            IWindowsFileOpenDialog dialog = (IWindowsFileOpenDialog)new WindowsFileOpenDialog();
            dialog.SetTitle(operation.Options.PickerTitle.ToString());

            dialog.GetOptions(out WindowsFileOpenDialogOptions updatedOptions);
            updatedOptions |= WindowsFileOpenDialogOptions.FileMustExist;
            updatedOptions |= WindowsFileOpenDialogOptions.PathMustExist;
            updatedOptions |= additionalOptions;
            dialog.SetOptions(updatedOptions);

            if (operation.Options.FileTypes.Length > 0)
            {
                uint fileTypesLength = (uint)operation.Options.FileTypes.Length;
                WindowsFileType[] fileTypes = new WindowsFileType[operation.Options.FileTypes.Length]; ;
                for (int i = 0; i < fileTypes.Length; i++)
                {
                    fileTypes[i] = new WindowsFileType(operation.Options.FileTypes[i]);
                }
                dialog.SetFileTypes(fileTypesLength, fileTypes);
            }

            return dialog;
        }

        private static void ShowFileOpenDialogForOperation(IWindowsFileOpenDialog dialog, PickFilePathOperation operation)
        {
            List<FilePath> pickPathResults = new();

            if (dialog.Show(IntPtr.Zero) != 0) // Blocks the execution, 0 means selected something
            {
                operation.CompleteTask(pickPathResults);
                return;
            }

            dialog.GetOptions(out WindowsFileOpenDialogOptions dialogOptions);
            if ((dialogOptions & WindowsFileOpenDialogOptions.AllowMultipleSelection) == 0)
            {
                dialog.GetResult(out IWindowsShellItem fileResult);
                fileResult.GetDisplayName(WindowsShellItemDisplayNameFormat.FileSystemPath, out string fullFilePath);
                pickPathResults.Add(new FilePath()
                {
                    Value = fullFilePath
                });
            }
            else
            {
                dialog.GetResults(out IWindowsShellItemArray fileResults);
                fileResults.GetCount(out uint fileResultsCount);

                for (uint i = 0; i < fileResultsCount; i++)
                {
                    fileResults.GetItemAt(i, out IWindowsShellItem file);
                    file.GetDisplayName(WindowsShellItemDisplayNameFormat.FileSystemPath, out string fullFilePath);
                    pickPathResults.Add(new FilePath()
                    {
                        Value = fullFilePath
                    });
                }
            }

            operation.CompleteTask(pickPathResults);
        }


        // Update
        public Task<FilePath> PickAsync()
        {
            PickFilePathOperation pickFilePathOperation = new(Options);
            return new(() =>
            {
                Thread pickThread = new (() => ShowFileOpenDialogForOperation(CreateFileOpenDialogForOperation(pickFilePathOperation), pickFilePathOperation));
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
                Thread pickThread = new (() => ShowFileOpenDialogForOperation(CreateFileOpenDialogForOperation(pickFilePathOperation, WindowsFileOpenDialogOptions.AllowMultipleSelection), pickFilePathOperation));
                pickThread.SetApartmentState(ApartmentState.STA);
                pickThread.Start();
                pickFilePathOperation.Task.Wait();

                return pickFilePathOperation.Task.Result;
            });
        }
    }
}