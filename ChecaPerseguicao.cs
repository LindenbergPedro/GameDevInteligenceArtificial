using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TransicaoPerseguicao")] // FAZER COM QUE SE TORNE UM ASSET
public class ChecaPerseguicao : Transicao
{
    public override bool ChecaCondicao(AgenteIA agent)
    {
        if (agent.distancia <= 40 && agent.QtMunicao > 0) return true; // VERIFICA SE A DISTANCIA DO PLAYER COM O AGENTE È MAIOR QUE 40
        else return false;

    }
}
