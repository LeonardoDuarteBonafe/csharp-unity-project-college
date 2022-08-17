using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Embaralhar : MonoBehaviour
{
    public GameObject cartaObjeto;
    private float offSet = 0.45f;
    private int cardOffSet = 2;

    public CardStackView playerCardStackView;
    public CardStackView baralhoEsquerdaCardStackView;
    public CardStackView baralhoDireitaCardStackView;

    public DebugChangeCard debugChange;

    public void MovimentoEmbaralhar(bool ladoDireito)
    {
        StartCoroutine(MovimentandoEmbaralhar(ladoDireito));
    }

    IEnumerator MovimentandoEmbaralhar(bool ladoDireito)
    {
        int count = 0;
        if (ladoDireito)
        {
            while (playerCardStackView.start.x + (offSet * count) + ((((cardOffSet / 2)) * playerCardStackView.cardOffset)) < baralhoDireitaCardStackView.start.x)
            {
                cartaObjeto.transform.position = new Vector3(playerCardStackView.start.x + (offSet * count) + ((((cardOffSet / 2)) * playerCardStackView.cardOffset)), playerCardStackView.start.y);
                yield return new WaitForFixedUpdate();
                count++;
            }
            cartaObjeto.transform.position = new Vector3(baralhoDireitaCardStackView.start.x + baralhoDireitaCardStackView.cardOffset, playerCardStackView.start.y);
            yield return new WaitForFixedUpdate();
            debugChange.BaralhoEsquerdaDireitaEmbaralhar(false);
        }
        else
        {
            while (playerCardStackView.start.x - (offSet * count) + ((((cardOffSet / 2)) * playerCardStackView.cardOffset)) > baralhoEsquerdaCardStackView.start.x)
            {
                cartaObjeto.transform.position = new Vector3(playerCardStackView.start.x - (offSet * count) + ((((cardOffSet / 2)) * playerCardStackView.cardOffset)), playerCardStackView.start.y);
                yield return new WaitForFixedUpdate();
                count++;
            }
            cartaObjeto.transform.position = new Vector3(baralhoEsquerdaCardStackView.start.x+baralhoEsquerdaCardStackView.cardOffset, playerCardStackView.start.y);
            yield return new WaitForFixedUpdate();
            debugChange.BaralhoEsquerdaDireitaEmbaralhar(true);
        }
        cardOffSet++;
    }
    
    public void SoAcabar()
    {
        cartaObjeto.transform.position = new Vector3(-6, 1f);
        cardOffSet = 2;
    }

    public void MovimentoDesembaralhar(bool ladoDireito)
    {
        StartCoroutine(MovimentandoDesembaralhar(ladoDireito));
    }

    IEnumerator MovimentandoDesembaralhar(bool ladoDireito)
    {
        int count = 0;
        if (!ladoDireito)
        {
            while (baralhoEsquerdaCardStackView.start.x + (offSet * count) + (((cardOffSet / 2) * baralhoEsquerdaCardStackView.cardOffset)) < playerCardStackView.start.x)
            {
                cartaObjeto.transform.position = new Vector3((baralhoEsquerdaCardStackView.start.x + ((cardOffSet/2) * baralhoEsquerdaCardStackView.cardOffset)) + (offSet * count), playerCardStackView.start.y); ;
                yield return new WaitForFixedUpdate();
                count++;
            }
            cartaObjeto.transform.position = new Vector3(playerCardStackView.start.x, playerCardStackView.start.y) ;
            yield return new WaitForFixedUpdate();
            debugChange.BaralhoEsquerdaDireitaDesembaralhar(true);
        }
        else
        {
            while (baralhoDireitaCardStackView.start.x -(offSet * count) + (((cardOffSet / 2) * baralhoDireitaCardStackView.cardOffset)) > playerCardStackView.start.x)
            {
                cartaObjeto.transform.position = new Vector3(baralhoDireitaCardStackView.start.x -(offSet * count) + (((cardOffSet / 2) * baralhoDireitaCardStackView.cardOffset)), playerCardStackView.start.y); ;
                yield return new WaitForFixedUpdate();
                count++;
            }
            cartaObjeto.transform.position = new Vector3(playerCardStackView.start.x, playerCardStackView.start.y);
            yield return new WaitForFixedUpdate();
            debugChange.BaralhoEsquerdaDireitaDesembaralhar(false);
        }
        cardOffSet++;
    }
}
