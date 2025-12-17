using UnityEngine;

public class ObjectDisAppear : MonoBehaviour
{
    [SerializeField]
    private int disAppearRound = 0;
    void Start()
    {
        if (KakoimaDB.Instance.getGoalCount() < disAppearRound)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
