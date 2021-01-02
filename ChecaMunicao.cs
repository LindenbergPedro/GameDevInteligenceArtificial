using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TransicaoMunicao")]
public class ChecaMunicao : Transicao
{
    public override bool ChecaCondicao(AgenteIA agent)
    {
        if (agent.QtMunicao <= 0) return true; // VERIFICA SE a MUNICAO DO AGENTE é IGUAL ou menor 0 E COM ISSO RETORNA TRUE
        else return false;

    }
}
