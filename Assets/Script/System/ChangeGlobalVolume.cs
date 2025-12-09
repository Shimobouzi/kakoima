using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChangeGlobalVolume : MonoBehaviour
{
    public static ChangeGlobalVolume Instance;
    [SerializeField]
    private Volume volume;
    private Vignette vignette;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            volume.profile.TryGet<Vignette>(out vignette);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetVignette(float v)
    {
        vignette.intensity.value = v;
    }
}
