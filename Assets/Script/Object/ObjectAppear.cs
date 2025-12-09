using UnityEngine;

public class ObjectAppear : MonoBehaviour
{
    [SerializeField]
    private int appearRound = 0;
    void Start()
    {
        if (KakoimaDB.Instance.getGoalCount() < appearRound)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.gameObject.SetActive(true);
        }
    }
}
