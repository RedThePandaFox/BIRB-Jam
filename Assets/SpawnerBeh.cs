using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBeh : MonoBehaviour
{
    [SerializeField] Transform[] spawnerPoints;
    public GameObject prefab;
    float noteSpeed = 1f;
    
    
    public void PlayRhythm(CardSCOB card)
    {
        noteSpeed = card.BPM;
        for(int i = 0; i < card.Rhythms.Count; i++)
        {
            Spawn(card, i);
        }
    }
    public void Spawn(CardSCOB card, int i)
    {
        int spawnerID=-1;

        switch (card.Rhythms[i].direction)
        {
            case CardSCOB.Direction.Red:
                spawnerID = 0;
                break;
            case CardSCOB.Direction.Green:
                spawnerID = 1;
                break;
            case CardSCOB.Direction.Blue:
                spawnerID = 2;
                break;
            case CardSCOB.Direction.Yellow:
                spawnerID = 3;
                break;
        }
        if(spawnerID == -1)
        {
            return;
        }
        Vector2 SpawnPos = new Vector2(spawnerPoints[spawnerID].position.x, spawnerPoints[spawnerID].position.y - card.Rhythms[i].beat);
        GameObject note = Instantiate(prefab, SpawnPos,Quaternion.identity);
        Note noteScript = note.GetComponent<Note>();
        noteScript.SetVel(noteSpeed);
    }
}
