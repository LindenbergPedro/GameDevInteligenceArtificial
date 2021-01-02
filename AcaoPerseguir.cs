using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AcaoPerseguir")] // FAZER COM QUE SE TORNE UM ASSET
public class AcaoPerseguir : Acoes // O CODIGO È FILHO DO CODIGO AÇOES
{
    public override void Agir(AgenteIA agent) // SOBREPONDO A AÇAO para acao ABAIXO
    {
        agent.agente.SetDestination(agent.player.position); // FAZ O AGENTE PERSEGUIR O PLAYER

        if(agent.QtMunicao>0 && agent.HP > 25) // VERIFICA O TANTO DE MUNIÇAO TEM
        {
            agent.Atirar(); // CHAMA O METODO ATIRAR
        }
        
    }
}
