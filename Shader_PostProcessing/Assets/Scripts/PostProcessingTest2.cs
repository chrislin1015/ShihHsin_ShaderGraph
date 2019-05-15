#define OVERRIDE_PP

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingTest2 : MonoBehaviour
{
    public PostProcessVolume m_Volume;
    Bloom m_Bloom;

    // Use this for initialization
    void Start ()
    {
#if OVERRIDE_PP
        m_Bloom = m_Volume.profile.GetSetting<Bloom>();
#else
        m_Bloom = m_Volume.sharedProfile.GetSetting<Bloom>();
#endif
    }

    // Update is called once per frame
    void Update ()
    {
        m_Bloom.intensity.value = UnityEngine.Random.Range(2.0f, 5.0f);
    }
}
