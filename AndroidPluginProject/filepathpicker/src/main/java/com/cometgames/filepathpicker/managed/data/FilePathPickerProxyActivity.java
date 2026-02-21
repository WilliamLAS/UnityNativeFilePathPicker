package com.cometgames.filepathpicker.managed.data;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;


public class FilePathPickerProxyActivity extends Activity
{
    private static final int m_RequestCode = 1001;
    // private final Activity m_ResultListenerActivity;
    private IFilePathPickerUnityCallback m_Callback;


    // Initialize
    public FilePathPickerProxyActivity()
    {

    }

    public FilePathPickerProxyActivity(Object m_ResultListenerActivity)
    {
        // this.m_ResultListenerActivity = (Activity)m_ResultListenerActivity;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        Intent intent = new Intent(Intent.ACTION_OPEN_DOCUMENT);
        intent.setType("*/*");
        intent.addCategory(Intent.CATEGORY_OPENABLE);

        startActivityForResult(intent, m_RequestCode);
    }


    // Update
    /*
    /// <remarks>
    /// Blocks thread until something happens
    /// </remarks>
    /// <returns>
    /// 0 if succeeded
    /// </returns>
    public int Show(Activity resultListenerActivity)
    {


        return 0;
    }

    public void SetFileTypes(uint fileTypesCount, [MarshalAs(UnmanagedType.LPArray)] WindowsFileType[] fileTypes);

    public void SetFileTypeIndex(uint selectedFileTypeIndex);
    public void GetFileTypeIndex(out uint selectedFileTypeIndex);
    public void SetOptions(WindowsFileDialogOptions options);
    public void GetOptions(out WindowsFileDialogOptions options);
    public void SetTitle([MarshalAs(UnmanagedType.LPWStr)] string dialogTitle);
    public void GetResult(out IWindowsShellItem item);
    public void GetResults(out IWindowsShellItemArray items);
    public void GetSelectedItems(out IWindowsShellItemArray items);
*/

    /*
    public void onActivityResult(int requestCode, int resultCode, Intent data) {

        if (resultCode == Activity.RESULT_OK && data != null)
        {
            m_Callback.OnPickedPaths(new String[]{"SODA"});
        }
    }
     */
}