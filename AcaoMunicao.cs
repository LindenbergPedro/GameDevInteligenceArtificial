using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AcaoMunicao")] // FAZER COM QUE SE TORNE UM ASSET
public class AcaoMunicao : Acoes
{
    public override void Agir(AgenteIA agent) // SOBREPONDO A AÇAO para acao ABAIXO
    {
        agent.agente.SetDestination(agent.Municao.position); // FAZ O AGENTE PERSEGUIR O PLAYER
        
        
    }
}
