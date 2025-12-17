using UnityEngine;

public class GoalTutorialFinal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            KakoImaSceneManager.Instance.MainSceneLoad();
        }
        if (other.gameObject.tag == "ReplayPlayer")
        {
            KakoimaDB.Instance.setGameCount(1);
            KakoimaDB.Instance.setMissCount(1);
            KakoImaSceneManager.Instance.ReplayTutorialSceneLoad();
        }
    }
}
