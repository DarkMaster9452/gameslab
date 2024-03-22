using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public void lowQuality()
    {
        QualitySettings.SetQualityLevel(0);
    }
    public void mediumQuality()
    {
        QualitySettings.SetQualityLevel(3);
    }
    public void highQuality()
    {
        QualitySettings.SetQualityLevel(6);
    }
}
