using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Globalization;

public class CardFlipper : MonoBehaviour 
{
    SpriteRenderer spriteRenderer;
    CardModel model;
    public float endPosRevelar;
    public float endPosDescartar;
    private float startPos;
    private bool respostaCerta;

    public CardStack player;
    public CardStackView playerStackView;
    private int cardCount = 0;

    public DebugChangeCard change;

    public AnimationCurve scaleCurve;
    public float duration = 0.5f;

    public DisplayMenu mostrarMenu;
    //public DisplayMenuCheckBox mostrarMenuCheckBox;
    public respostaCorreta conferirResposta;
    public BancoDeRespostas bancoDeRespostas;

    public campoResposta campoResposta;

    public GameObject jogadorTabuleiro;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        model = GetComponent<CardModel>();
    }

    public void FlipCard(Sprite startImage, Sprite endImage, int cardIndex)
    {
        StopCoroutine(Flip(startImage, endImage, cardIndex));
        StartCoroutine(Flip(startImage, endImage, cardIndex));
    }

    IEnumerator Flip(Sprite startImage, Sprite endImage, int cardIndex)
    {
        respostaCerta = false;
        spriteRenderer.sprite = startImage;
        float mover = playerStackView.start.x + cardCount * playerStackView.cardOffset;
        float speed = 1.2f;
        Vector3 pos1 = new Vector3(mover, model.transform.position.y);
        model.transform.position = pos1;
        model.transform.localScale = new Vector3(1f, 1f);//1.11 +-

        while (model.transform.position.x <= endPosRevelar)
        {
            mover += speed * Time.deltaTime;
            pos1 = new Vector3(mover , model.transform.position.y);
            model.transform.position = pos1;
            yield return new WaitForFixedUpdate();
        }

        float time = 0f;
        while (time <= 1f)
        {
            float scale = scaleCurve.Evaluate(time);
            time += Time.deltaTime / duration;

            Vector3 localScale = transform.localScale;
            localScale.x = scale;
            transform.localScale = localScale;

            if (time >= 0.5f)
            {
                spriteRenderer.sprite = endImage;
            }
            
            yield return new WaitForFixedUpdate();
        }

        model.transform.localScale = new Vector3(2.2f, 2.2f);
        model.transform.position = new Vector3(model.transform.position.x, model.transform.position.y + 1.05f);
        mostrarMenu.displayBotoes();

        campoResposta.mostrarCampoResposta(true);

        mostrarMenu.pegarDicasDoBanco(cardIndex);

        while (true)
        {
            change.textoPontuacaoAtualAtualizar(mostrarMenu.numeroCliquesBotoes());
            if (mostrarMenu.numeroCliquesBotoes() >= 5 || campoResposta.respostaConfirmada())
            {
                if (campoResposta.respostaConfirmada())
                {
                    if (string.Compare(bancoDeRespostas.pegarRespostaDoBanco(cardIndex), campoResposta.pegarResposta(), CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0)
                    {
                        conferirResposta.checarRespostaCorreta(true);
                        respostaCerta = true;
                    }
                    else
                    {
                        respostaCerta = false;
                        conferirResposta.checarRespostaCorreta(false);
                    }
                }
                else
                {
                    respostaCerta = false;
                    conferirResposta.checarRespostaCorreta(false);
                }
                if (respostaCerta)
                {
                    change.textoPontuacaoGanhaAtualizar(mostrarMenu.numeroCliquesBotoes());
                    change.textoPontuacaoPerdidaAtualizar(mostrarMenu.numeroCliquesBotoes());
                    jogadorTabuleiro.GetComponent<FollowThePath>().casasMover = (5 - mostrarMenu.numeroCliquesBotoes());
                }
                else
                {
                    change.textoPontuacaoGanhaAtualizar(5);
                    change.textoPontuacaoPerdidaAtualizar(5);
                }
                break;
            }
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1);
        conferirResposta.limparTextoChecarResposta();
        //mostrarMenuCheckBox.menuCheckBox(false);

        campoResposta.mostrarCampoResposta(false);

        mostrarMenu.desligarBotoes();
        model.transform.position = new Vector3(model.transform.position.x, model.transform.position.y - 1.05f);
        
        if (cardIndex == -1)
        {
            model.ToggleFace(false);
        }
        else
        {
            model.cardIndex = cardIndex;
            model.ToggleFace(true);
        }

        model.transform.localScale = new Vector3(1, 1);

        time = 0f;
        spriteRenderer.sprite = endImage;
        while (time <= 1f)
        {
            float scale = scaleCurve.Evaluate(time);
            time += Time.deltaTime / duration;

            Vector3 localScale = transform.localScale;
            localScale.x = scale;
            transform.localScale = localScale;

            if (time >= 0.5f)
            {
                spriteRenderer.sprite = startImage;
            }

            yield return new WaitForFixedUpdate();
        }

        model.transform.localScale = new Vector3(1, 1);

        while (model.transform.position.x <= endPosDescartar)
        {
            mover += speed * Time.deltaTime;
            pos1 = new Vector3(mover, model.transform.position.y);
            model.transform.position = pos1;
            yield return new WaitForFixedUpdate();
        }

        model.transform.position = new Vector3(endPosDescartar+0.01f, model.transform.position.y);
        yield return new WaitForFixedUpdate();

        cardCount++;

        model.transform.localScale = new Vector3(1, 1);
        model.transform.position = new Vector3(model.transform.position.x + 100, model.transform.position.y);
        change.AddCartasRemovidas(cardIndex);
    }
}
