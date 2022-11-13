using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName =("New Rhythm Card"),menuName =("Card/Rhythm Card"))]
public class CardSCOB : ScriptableObject
{
    public enum Rarity
    {
        Common,
        Rare,
        Legendary,
        Unique
    }
    public int ID;
    public int Cost;
    public string Name;
    public string Description;
    public GameObject ObjModel;
    public int okayMinimum;
    public int goodMinimum;
    public List<RhythmUwU> Rhythms;
    public List<Effect> OnFail;
    public List<Effect> OnOkay;
    public List<Effect> OnGood;
    public List<Effect> OnPerfect;
    public AudioClip clip;
    public float BPM;
    public enum Type
    {
        Damage,
        Defense,
        SelfDamage,
        RecoverHealth
    }
    public enum Direction
    {
        Red,
        Green,
        Blue,
        Yellow
    }
    

    [System.Serializable]
    public struct Effect
    {
        public Type type;
        public float ammount;
    }

    [System.Serializable]
    public struct RhythmUwU
    {
        public Direction direction;
        public int timesDuration;
        public int beat;

    }
}
