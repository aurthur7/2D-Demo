using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonSound : MonoBehaviour
{
    public AudioClip clickSFX;
    private void Start()
    {
        Button[] buttons = GetComponentsInChildren<Button>(true);
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(onclicksound);
        }
    }
    public void onclicksound()
    {
        if (AudioManager.Instance == null)
        {
            return;
        }
        if (clickSFX == null)
        {
            return ;
        }
        AudioManager.Instance.SFXplay(clickSFX);
    }
}
