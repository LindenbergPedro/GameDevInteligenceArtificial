using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AcoesPatrulhas")]
public class Patrulha : Acoes
{
    public override void Agir(AgenteIA agent)
    {
        //SCRIPT QUE FAZ COM QUE O AGENTE VA DE UM PONTO A ATE O PONTOS RESTANTES.
        if (agent.agente.remainingDistance <= agent.agente.stoppingDistance && !agent.agente.pathPending)
        {
            if (agent.flagWaypoint + 2 > agent.waypoints.Length)
            {
                agent.flagWaypoint = 0;
            }
            else
            {
                agent.flagWaypoint++;
            }
            //agent.estadoAtual = agent.Estado.gira;
        }
        if(agent.QtMunicao > 0 && agent.distancia > 40 && agent.HP > 25)
        {
            agent.agente.SetDestination(agent.waypoints[agent.flagWaypoint].position);
        }
        
    }
}
