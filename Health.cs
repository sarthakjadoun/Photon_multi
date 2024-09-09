using Fusion;
using UnityEngine;

public class Health : NetworkBehaviour
{
    [Networked,OnChangedRender(nameof(healthchanged))]
    public float Networkedhealth { get; set; }

    void healthchanged()
    {
        Debug.Log("Health changed to : " + Networkedhealth);
    }

    [Rpc(RpcSources.All,RpcTargets.StateAuthority)]
    public void DamageRpc(float damage)
    {
        Debug.Log("receive DamageRpc on state auth, modifying networked health");
        Networkedhealth -= damage;
    }
}
