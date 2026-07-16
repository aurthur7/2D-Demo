using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudioController : MonoBehaviour
{
    private void Start()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.menuBGMplay();
        }
    }
}
