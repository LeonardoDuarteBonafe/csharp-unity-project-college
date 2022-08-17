using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour {

    private Sprite[] diceSides;
    private SpriteRenderer rend;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;

    private void OnMouseDown()
    {
        RodandoDado();
    }

    public void RodandoDado()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;
        yield return new WaitForSeconds(0.05f);
        GameControl.diceSideThrown = 51;
        GameControl.MovePlayer(1);
        whosTurn *= -1;
        coroutineAllowed = true;
    }
}
