using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RadialBlur : MonoBehaviour
{
    public Shader m_Shader;
    public Vector2 m_Center = new Vector2(0.5f, 0.5f);
    public float m_Dist = 1.0f;
    public float m_Strength = 2.0f;

    protected Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Shader != null && m_Material == null)
        {
            m_Material = new Material(m_Shader);
            m_Material.hideFlags = HideFlags.DontSave;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (m_Material != null)
        {
            m_Material.SetFloat("_SampleDist", m_Dist);
            m_Material.SetFloat("_SampleStrength", m_Strength);
            m_Material.SetVector("_Center", new Vector4(m_Center.x, m_Center.y, 0.0f, 0.0f));
            Graphics.Blit(source, destination, m_Material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
