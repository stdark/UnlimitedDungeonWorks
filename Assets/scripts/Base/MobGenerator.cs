using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MobGenerator : MonoBehaviour {
    public GameObject mobToGen ;
    public bool generateMob = false;
    public float mobx =0;
    public float moby =0;

    public void MobGenerate(string x, string y)
    {
        Debug.Log(float.Parse(x) + " " + -float.Parse(y));
        Instantiate(mobToGen, new Vector3(float.Parse(x), -float.Parse(y), -1.0f), Quaternion.identity);
        mobx = float.Parse(x);
        moby = -float.Parse(y);
        generateMob = false;
    }

    public float FindMobX(string name)
    {

        return mobx;
    }
    public float FindMobY(string name)
    {

        return moby;
    }
}
