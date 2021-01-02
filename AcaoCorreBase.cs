using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AcaoCorreBase")] // FAZER COM QUE SE TORNE UM ASSET
public class AcaoCorreBase : Acoes
{
    public override void Agir(AgenteIA agent)
    {
        agent.agente.SetDestination(agent.localBase.position); // FAZ COM QUE O AGENTE VA ATE A BASE
    }
}
