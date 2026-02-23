package com.cometgames.filepathpicker.managed.data;

import android.net.Uri;
import android.util.Log;

import androidx.activity.result.ActivityResultLauncher;
import androidx.activity.result.ActivityResultRegistry;
import androidx.activity.result.contract.ActivityResultContracts;
import androidx.fragment.app.FragmentActivity;

import java.io.File;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.util.List;

public class FileOpenDialog
{
    private FragmentActivity m_ResultListenerFragmentActivity;
    private ActivityResultLauncher<String[]> m_DialogActivityLauncher;

    public String[] MIMEFileTypes = new String[]{"*/*"};
    public FileOpenDialogOptionFlags Options = new FileOpenDialogOptionFlags(FileOpenDialogOptionFlags.None);
    public IFileOpenDialogCallback Callback;


    // Helpers
    private String GetAbsoluteFilePath(Uri uri)
    {
        try
        {
            String fileName = "picked_" + System.currentTimeMillis();
            File cacheFile = new File(m_ResultListenerFragmentActivity.getCacheDir(), fileName);
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
        m_DialogActivityLauncher.unregister();
        String[] fileSystemPaths = uris.stream()
            .map(this::GetAbsoluteFilePath)
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
            m_DialogActivityLauncher = resultRegistry.register
            (
                getClass().getName(),
                new ActivityResultContracts.OpenMultipleDocuments(),
                this::OnDialogActivityResult
            );
        }
        else
        {
            m_DialogActivityLauncher = resultRegistry.register
            (
                getClass().getName(),
                new ActivityResultContracts.OpenDocument(),
                this::OnDialogActivityResult
            );
        }

        m_DialogActivityLauncher.launch(MIMEFileTypes);
    }
}
