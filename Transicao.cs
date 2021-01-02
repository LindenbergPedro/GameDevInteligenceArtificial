using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transicao : ScriptableObject
{
    public EstaodoFSM estadoCasoTrue; // caso o retorno for true
    public EstaodoFSM estadoCasoFalse; // caso o retorno for false

    public abstract bool ChecaCondicao(AgenteIA agent);
}
