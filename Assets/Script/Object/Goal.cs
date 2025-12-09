using UnityEngine;

public class Goal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            KakoimaDB.Instance.setGameCount(1);
            KakoimaDB.Instance.setGoalCount(1);
            KakoImaSceneManager.Instance.ReplayMainSceneLoad();
        }
        if (other.gameObject.tag == "ReplayPlayer")
        {
            KakoimaDB.Instance.setGameCount(1);
            KakoimaDB.Instance.setMissCount(1);
            KakoImaSceneManager.Instance.ReplayMainSceneLoad();
        }
    }
}
