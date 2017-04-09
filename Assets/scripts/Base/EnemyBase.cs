using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour {

    public string CharacterName;
    public RaceType CharacterRace;
    public ClassType CharacterClass;
    public int Hits;
    public int Str, Agi, Vit, Int, Wis, Chr;
    public float x, y;
    public Sprite sp;
    
    public EnemyBase()
    {
        CharacterName = "";
        CharacterRace = RaceType.UNSET;
        CharacterClass = ClassType.UNSET;
        Hits = 1;
        Str = 1;
        Agi = 1;
        Vit = 1;
        Int = 1;
        Wis = 1;
        Chr = 1;
        x = 0;
        y = 0;
        sp = new Sprite();
    }
    public EnemyBase(string name, RaceType race, ClassType cls, int hits, int str, int agi, int vit, int i, int wis, int chr, float xc, float yc, Sprite sprite)
    {
        CharacterName = name;
        CharacterRace = race;
        CharacterClass = cls;
        Hits = hits;
        Str = str;
        Agi = agi;
        Vit = vit;
        Int = i;
        Wis = wis;
        Chr = chr;
        x = xc;
        y = yc;
        sp = sprite;
    }
    public void setCoord(float xc, float yc)
    {
        x = xc;
        y = yc;
    }
}
