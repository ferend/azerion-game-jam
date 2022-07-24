using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossInteger;
    public EnemySpawner s1, s2, s3, s4;
    public DialogManager dialogManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // start mini battle battle
            //UIManager.Instance.OpenBossTalkPopup(bossInteger);
            //enemyleri listeye alim sonra destroy

            s1.DestroyEnemies();s2.DestroyEnemies();s4.DestroyEnemies();s4.DestroyEnemies();
            dialogManager.StartDialog();
        }
        
    }
}
