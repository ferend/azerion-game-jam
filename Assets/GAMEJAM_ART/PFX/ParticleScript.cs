using UnityEngine;

namespace Utilities
{
    public class ParticleScript : MonoBehaviour
{
    void Start()
    {
        var main = GetComponent<ParticleSystem>().main;
        main.stopAction = ParticleSystemStopAction.Callback;
    }
    
    public void OnParticleSystemStopped()
    {
        Destroy(gameObject);
    }

}
}
