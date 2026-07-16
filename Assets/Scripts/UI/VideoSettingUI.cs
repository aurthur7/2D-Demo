using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettingUI : MonoBehaviour
{
    public Dropdown resolutiondropdown;
    public Dropdown iswindoweddropdown;
    private Vector2Int[] resolutions =
        { new Vector2Int(1920,1080),new Vector2Int(1600,900),new Vector2Int(1280,720) };
    private FullScreenMode[] windowtype = { FullScreenMode.FullScreenWindow,FullScreenMode.Windowed};
    private const string RESOLUTION_KEY = "resolutionindex";
    private const string WINDOWTYPE = "windowtype";
    private void Start()
    {
        int resolutionsavedindex=PlayerPrefs.GetInt(RESOLUTION_KEY,0);
        resolutionsavedindex = Mathf.Clamp(resolutionsavedindex,0,resolutions.Length-1);
        resolutiondropdown.SetValueWithoutNotify(resolutionsavedindex);

        int isfullscreensavedindex=PlayerPrefs.GetInt(WINDOWTYPE,0);
        isfullscreensavedindex = Mathf.Clamp(isfullscreensavedindex,0,windowtype.Length-1);
        iswindoweddropdown.SetValueWithoutNotify(isfullscreensavedindex);
    }
    public void applyvideosetting()
    {
        int resolutionindex=resolutiondropdown.value;
        resolutionindex = Mathf.Clamp(resolutionindex,0,resolutions.Length-1);
        Vector2Int resolution=resolutions[resolutionindex];
        int fullscreenindex=iswindoweddropdown.value;
        fullscreenindex = Mathf.Clamp(fullscreenindex,0,windowtype.Length-1);
        FullScreenMode mode = windowtype[fullscreenindex];
        Screen.SetResolution(resolution.x,resolution.y,mode);
        PlayerPrefs.SetInt(RESOLUTION_KEY,resolutiondropdown.value);
        PlayerPrefs.SetInt(WINDOWTYPE, iswindoweddropdown.value);
        PlayerPrefs.Save();
    }
}
