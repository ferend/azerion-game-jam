using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBack;
    private int dialogCount = 0;
    public GameObject playerDialog;
    public GameObject enemyDialog;
    public GameObject playerDialog2;
    public GameObject enemyDialog2;
    public AudioClip p1, p2, e1;
    public AudioSource audioSource;
    public BattleManager battleManager;


    private void Start()
    {
         // StartDialog();
    }
    public void StartDialog()
    {
        GameFlowManager.Instance.StopGameFlow();
        dialogBack.SetActive(true);
        audioSource.PlayOneShot(p1);
    }
    public void NextStatus()
    {
        dialogCount++;
        if (dialogCount == 1)
        {
            enemyDialog.transform.DOMoveX(1192,0.5f ,true).OnComplete(() =>audioSource.PlayOneShot(e1));

        }
        if (dialogCount == 2)
        {
            playerDialog.SetActive(false);
            playerDialog2.SetActive(true);
            playerDialog2.transform.DOMoveX(67,0.5f ,true);
            audioSource.PlayOneShot(p2);
        }
        if (dialogCount == 3)
        {
            enemyDialog.SetActive(false);
            enemyDialog2.SetActive(true);
            enemyDialog2.transform.DOMoveX(1192,0.5f ,true);

        }
        if (dialogCount >= 4)
        {
            battleManager.OpenBattle();
                return;
        }

    }
    
}
