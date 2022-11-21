using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
[CreateAssetMenu(fileName = ("New Deck"), menuName = ("Deck"))]
public class Deck : ScriptableObject
{
    [SerializeField] List<CardSCOB> cards;
    [SerializeField] List<CardSCOB> gravejard;


    private void Start()
    {
        shuffleCards();
    }
    private void OnEnable()
    {
        CardGameManager.OnStartTurn += shuffleCards;
    }
    private void OnDisable()
    {
        CardGameManager.OnStartTurn -= shuffleCards;
    }

    void shuffleCards()
    {
        cards.AddRange(gravejard);
        gravejard.Clear();
        for (int i = 0; i < cards.Count - 1; i++)
        {
            CardSCOB tmp = cards[i];
            int rand = Random.Range(i, cards.Count);
            cards[i] = cards[rand];
            cards[rand] = tmp;
        }
    }

    public void AddCard(CardSCOB values)
    {
        CardSCOB newCard = new CardSCOB();
        JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(values), newCard);

        cards.Add(newCard);
    }
    public void RemoveCard(CardSCOB values)
    {
        CardSCOB newCard = new CardSCOB();
        JsonUtility.FromJsonOverwrite(JsonUtility.ToJson(values), newCard);
        gravejard.Add(newCard);

        cards.Remove(newCard);
    }

    public CardSCOB GetNextCard()
    {
        CardSCOB tmp = cards[0];

        if (cards.Count > 0)
        {
            gravejard.Add(tmp);

            cards.RemoveAt(0);
        }
        else if (cards.Count <= 0)
        {
            shuffleCards();
            return GetNextCard();
        }

        return tmp;
    }
}
