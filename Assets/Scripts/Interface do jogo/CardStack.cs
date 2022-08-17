using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardStack : MonoBehaviour
{
    public List<int> cards;
    List<int> cardsTest;

    public bool isGameDeck;

    private int count = 0;

    int[] cardsForSave = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public bool HasCards
    {
        get { return cards != null && cards.Count > 0; }
    }

    public event CardEventHandler CardRemoved;
    public event CardEventHandler CardAdded;

    public int CardCount
    {
        get
        {
            if (cards == null)
            {
                return 0;
            }
            else
            {
                return cards.Count;
            }
        }
    }

    public List<int> GetListaCartas()
    {
        return cards;
    }

    public IEnumerable<int> GetCards()
    {
        foreach (int i in cards)
        {
            yield return i;
        }
    }

    public int Pop()
    {
        int temp = cards[0];
        cards.RemoveAt(0);

        if(CardRemoved != null)
        {
            CardRemoved(this, new CardEventArgs(temp));
        }

        return temp;
    }

    public void Push(int card)
    {
        cards.Add(card);
        if(CardAdded != null)
        {
            CardAdded(this, new CardEventArgs(card));
        }
    }

    public int HandValue()
    {
        int total = 0;
        int aces = 0;

        foreach( int card in GetCards())
        {
            int cardRank = card % 13;
            if (cardRank <= 8)
            {
                cardRank += 2;
                total += cardRank;
            }
            else if(cardRank > 8 && cardRank < 12)
            {
                cardRank = 10;
                total += cardRank;
            }
            else
            {
                aces++;
            }
        }

        for (int i = 0; i < aces; i++)
        {
            if (total + 11 <= 21)
            {
                total += 11;
            }
            else
            {
                total += 1;
            }
        }

        return total;
    }

    public void CreateDeck()
    {
        cards.Clear();

        for (int i = 0; i < 20; i++)
        {
            cards.Add(i);
        }
        cardsTest = cards;
        Shuffle();
    }

    public void Shuffle()
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
        if(count == 0)
        {
            int testCount = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                cardsForSave[testCount++] = cards[i];
            }
            for (int i = 0; i < cards.Count; i = i+2)
            {
                int aux = cards[i + 1];
                cards[i + 1] = cards[i];
                cards[i] = aux;
            }
            for (int i = 0; i < cards.Count; i++)
            {
            }
            count++;
        }
        else
        {
            for (int i = 0; i < cards.Count; i++)
            {
                cardsForSave[i] = cards[i];
            }
        }
        
    }

    public int[] cardsForSaveFunction()
    {
        return cardsForSave;
    }

    public void Reset()
    {
        cards.Clear();
        count = 0;
    }

    void Awake () 
    {
        count = 0;
        cards = new List<int>();
        if (isGameDeck)
        {
            CreateDeck();
        }
	}

    void Update() { }
}
