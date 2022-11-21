using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameObject CardPreFab;
    public Transform attackLane, HandCards;
    public Deck cardpool;
    public static bool canPlayCards;
    private void OnEnable()
    {
        CardGameManager.OnStartTurn += SetNewCards;
    }

    private void OnDisable()
    {
        CardGameManager.OnStartTurn -= SetNewCards;
    }

    void SetNewCards()
    {
        canPlayCards = false;
        StartCoroutine(SetNewCardsEnum());
    }
    void spawnDraggableCard(CardSCOB card)
    {
        Instantiate(CardPreFab, HandCards.transform.position, Quaternion.identity, HandCards)
        .GetComponent<DraggableCard>().card = card;
    }
    IEnumerator SetNewCardsEnum()
    {
        if (HandCards.childCount == 0)
        {
            for (int i = 0; i < 5; i++)
            {
                spawnDraggableCard(cardpool.GetNextCard());
            }
            yield return new WaitForSeconds(1 / 5f);
        }
        else
        {
            yield return new WaitForSeconds(1);
        }

        if (HandCards.childCount < 7)
        {
            spawnDraggableCard(cardpool.GetNextCard());
            yield return new WaitForSeconds(1 / 5f);
        }

        canPlayCards = true;
    }
}
