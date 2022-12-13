using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Ore: ScriptableObject
{
    public new string OreName;
    public int Value;
    public Sprite artwork;
    public bool isHeal;

    //When heal is true, will heal the players health rather then increase the score counter
    //When heal is false, it will instead increase the score counter(and not increase health)
    //Value whe heal is true will add that value health
    //Value when heal is false will instead increase the score counter
}
