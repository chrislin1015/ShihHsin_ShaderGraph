#define OVERRIDE_PP

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProcessingTest : MonoBehaviour
{
    public PostProcessingBehaviour m_PostProcessing;
#if OVERRIDE_PP
    protected PostProcessingProfile m_Profile;
#endif

    // Use this for initialization
    void Start ()
    {
#if OVERRIDE_PP
        if (m_PostProcessing != null && m_PostProcessing.profile != null)
        {
            m_Profile = Instantiate(m_PostProcessing.profile);
            m_PostProcessing.profile = m_Profile;
        }
#endif
    }

    // Update is called once per frame
    void Update ()
    {
#if OVERRIDE_PP
        if (m_Profile != null)
        {
            BloomModel.Settings _Bloom = m_Profile.bloom.settings;
            _Bloom.bloom.intensity = Random.Range(0.5f, 2.0f);
            m_Profile.bloom.settings = _Bloom;
        }
#else
        if (m_PostProcessing != null && m_PostProcessing.profile != null)
        {
            BloomModel.Settings _Bloom = m_PostProcessing.profile.bloom.settings;
            _Bloom.bloom.intensity = Random.Range(0.5f, 2.0f);
            m_PostProcessing.profile.bloom.settings = _Bloom;
        }
#endif
    }
}
