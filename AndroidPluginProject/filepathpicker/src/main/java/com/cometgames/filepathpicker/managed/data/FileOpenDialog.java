package com.cometgames.filepathpicker.managed.data;

import android.database.Cursor;
import android.net.Uri;
import android.provider.OpenableColumns;
import android.util.Log;

import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.ActivityResultRegistry;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.fragment.app.FragmentActivity;

import java.io.File;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.util.List;

/// <summary>
/// Structure for C# .NET, manipulated by C# .NET.
/// </summary>
public class FileOpenDialog
{
    private FragmentActivity m_ResultListenerFragmentActivity;
    private ActivityResultLauncher<String[]> m_SelectionActivityLauncher;

    public String[] MIMEFileTypes = new String[]{"*/*"};
    public String SelectedFilePathDirectory;
    public FileOpenDialogOptionFlags Options = new FileOpenDialogOptionFlags(FileOpenDialogOptionFlags.None);
    public IFileOpenDialogCallback Callback;


    // Helpers
    private String GetFileName(Uri uri) {
        String name = "unknown_file";

        Cursor cursor = m_ResultListenerFragmentActivity.getContentResolver()
                .query(uri, null, null, null, null);

        if (cursor != null) {
            int index = cursor.getColumnIndex(OpenableColumns.DISPLAY_NAME);
            if (index != -1 && cursor.moveToFirst()) {
                name = cursor.getString(index);
            }
            cursor.close();
        }

        return name;
    }

    private String GetCachedFilePath(Uri uri)
    {
        try
        {
            String safeFileName = System.currentTimeMillis() + "_" + GetFileName(uri);
            File cacheFile = new File(SelectedFilePathDirectory, safeFileName);
            InputStream inputStream = m_ResultListenerFragmentActivity.getContentResolver().openInputStream(uri);
            FileOutputStream outputStream = new FileOutputStream(cacheFile);

            byte[] readBytesAtOnce = new byte[4096];
            int length;

            while ((length = inputStream.read(readBytesAtOnce)) > 0)
            {
                outputStream.write(readBytesAtOnce, 0, length);
            }

            inputStream.close();
            outputStream.close();

            return cacheFile.getAbsolutePath();

        }
        catch (Exception e)
        {
            Log.e(getClass().getName(), e.getMessage(), e);
            return "";
        }
    }


    // Update
    private void OnDialogActivityResult(List<Uri> uris)
    {
        m_SelectionActivityLauncher.unregister();
        String[] fileSystemPaths = uris.stream()
            .map(this::GetCachedFilePath)
            .toArray(String[]::new);

        Callback.OnPickedPaths(fileSystemPaths);
    }

    private void OnDialogActivityResult(Uri uri)
    {
        OnDialogActivityResult(List.of(uri));
    }

    public void ShowUsingActivity(FragmentActivity resultListenerFragmentActivity)
    {
        m_ResultListenerFragmentActivity = resultListenerFragmentActivity;
        ActivityResultRegistry resultRegistry = m_ResultListenerFragmentActivity.getActivityResultRegistry();

        if ((Options.Value & FileOpenDialogOptionFlags.AllowMultipleSelection) != 0)
        {
            m_SelectionActivityLauncher = resultRegistry.register
            (
                getClass().getName(),
                new ActivityResultContracts.OpenMultipleDocuments(),
                this::OnDialogActivityResult
            );
        }
        else
        {
            m_SelectionActivityLauncher = resultRegistry.register
            (
                getClass().getName(),
                new ActivityResultContracts.OpenDocument(),
                this::OnDialogActivityResult
            );
        }

        m_SelectionActivityLauncher.launch(MIMEFileTypes);
    }
}
