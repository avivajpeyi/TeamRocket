using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Visuals.PostProcessing
{
    public class VignettePulse : MonoBehaviour
    {
        private Vignette m_Vignette;
        private PostProcessVolume m_Volume;

        private void Start()
        {
            m_Vignette = ScriptableObject.CreateInstance<Vignette>();
            m_Vignette.enabled.Override(true);
            m_Vignette.intensity.Override(1f);

            m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, m_Vignette);
        }

        private void Update()
        {
            m_Vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
        }

        private void OnDestroy()
        {
            RuntimeUtilities.DestroyVolume(m_Volume, true, true);
        }
    }
}