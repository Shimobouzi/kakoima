using UnityEngine;

public class ObjectDisAppear : MonoBehaviour
{
    [SerializeField]
    private int appearRound = 0;
    void Start()
    {
        if (KakoimaDB.Instance.getGoalCount() < appearRound)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
