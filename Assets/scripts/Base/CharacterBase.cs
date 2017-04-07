using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {

    public string CharacterName;
    public RaceType CharacterRace;
    public ClassType CharacterClass;

    public int Hits;
    public int Str, Agi, Vit, Int, Wis, Chr;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) MoveUp();
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) MoveLeft();
        else if (Input.GetKeyDown(KeyCode.DownArrow)) MoveDown();
        else if (Input.GetKeyDown(KeyCode.RightArrow)) MoveRight();
    }
    void MoveLeft()
    {
        gameObject.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
        gameObject.transform.position += new Vector3(-1.0f,0);
    }
    void MoveRight()
    {
        gameObject.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        gameObject.transform.position += new Vector3(1.0f, 0);
    }
    void MoveUp()
    {
        gameObject.transform.position += new Vector3(0, 1.0f);
    }
    void MoveDown()
    {
        gameObject.transform.position += new Vector3(0, -1.0f);
    }
    void MoveOnMouse()
    {

    }
}
