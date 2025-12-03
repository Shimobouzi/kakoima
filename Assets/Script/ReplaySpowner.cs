using UnityEngine;

public class ReplaySpowner : MonoBehaviour
{
    [SerializeField]
    private GameObject replayPlayer;
    [SerializeField]
    private Transform spownPosi;
    private int ReplayCount = 0;
    private void Start()
    {
        ReplayCount = JsonController.instance.GetFileCount();
        for (int i = 0; i < ReplayCount; i++)
        {
            Instantiate(replayPlayer, spownPosi.position, spownPosi.rotation);
        }
    }
}
