using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameManager : MonoBehaviour
{
    public delegate void GameManagerEvents();
    public static event GameManagerEvents OnStartTurn, OnStartBattle, 
    OnEndTurn, OnEnemyTurn;

    private void Start() {
        StartTurn();
    }
    public void StartTurn()
    {
        OnStartTurn();
    }
    public void StartBattle()
    {
        OnStartBattle();
    }
}
