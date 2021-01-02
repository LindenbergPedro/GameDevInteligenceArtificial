using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AcoesOlha")]
public class Visao : Acoes
{
    public float alcance;

    public override void Agir(AgenteIA agent)
    {
        //SCRIPT PRA VERIFICAR SE O AGENTEIA CONSEGUIU LOCALIZAR UM PLAYER
        Debug.DrawRay(agent.eye.position, agent.eye.forward * alcance, Color.yellow);
        RaycastHit hit;
        if (Physics.Raycast(agent.eye.position, agent.eye.forward, out hit, alcance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                agent.taperto = true;
            }
            else agent.taperto = false;

        }
        
    }
}
