using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmManager : MonoBehaviour
{
    [SerializeField] AudioClip MissedClip;
    [SerializeField] AudioClip HitClip;
    [SerializeField] audioManager audio;
    public CardSCOB card;
    [SerializeField] SpawnerBeh spawner;
    [SerializeField]float cardsHit=0;
    float timestamp;
    bool canPlay=true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&canPlay)
        {
            cardsHit = 0;
            spawner.PlayRhythm(card);
            canPlay = false;
            timestamp = Time.time+(card.Rhythms.Count+5f);
        }
        if (Time.time > timestamp)
        {
            canPlay= true;
        }
    }
    public void cardHit()
    {
        cardsHit++;
        audio.Play(HitClip);
    }
    public void cardMissed()
    {
        cardsHit--;
        audio.Play(MissedClip);
    }


}
