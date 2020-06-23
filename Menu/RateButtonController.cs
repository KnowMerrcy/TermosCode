using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateButtonController : MonoBehaviour
{
    public void Rate()
    {
        #if UNITY_ANDROID
        FindObjectOfType<AudioManager>().Play("PressButton");
        Application.OpenURL("market://details?id=com.KnowMercy.Termos");
        #endif
    }
}
