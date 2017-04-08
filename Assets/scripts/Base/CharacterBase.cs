using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour {

    public string CharacterName;
    public RaceType CharacterRace;
    public ClassType CharacterClass;
    public NetworkAdapter go;
    public int Hits;
    public int Str, Agi, Vit, Int, Wis, Chr;
    public BoxCollider2D[] ObjectMass;
    


    private void Start()
    {
        
        ObjectMass = GameObject.Find("Object_obj").GetComponentsInChildren<BoxCollider2D>();
       
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow)) MoveUp();
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) MoveLeft();
        else if (Input.GetKeyDown(KeyCode.DownArrow)) MoveDown();
        else if (Input.GetKeyDown(KeyCode.RightArrow)) MoveRight();
    }
    void MoveLeft()
    {
        GameObject.Find("troll").transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
        gameObject.transform.position += new Vector3(-1.0f,0);
        foreach (BoxCollider2D pgo in ObjectMass)
        {
            
            if (gameObject.transform.position.x == pgo.transform.position.x && gameObject.transform.position.y == pgo.transform.position.y) gameObject.transform.position -= new Vector3(-1.0f, 0);
        }
        go.SendPos(transform.position.x + 1.0f, transform.position.y, 0);

    }
    void MoveRight()
    {
        GameObject.Find("troll").transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        gameObject.transform.position += new Vector3(1.0f, 0);
        foreach (BoxCollider2D pgo in ObjectMass)
        {
            if (gameObject.transform.position.x == pgo.transform.position.x && gameObject.transform.position.y == pgo.transform.position.y) gameObject.transform.position -= new Vector3(1.0f, 0);
        }
        go.SendPos(transform.position.x - 1.0f, transform.position.y, 1);
    }
    void MoveUp()
    {
        gameObject.transform.position += new Vector3(0, 1.0f);
        foreach (BoxCollider2D pgo in ObjectMass)
        {
            if (gameObject.transform.position.x == pgo.transform.position.x && gameObject.transform.position.y == pgo.transform.position.y) gameObject.transform.position -= new Vector3(0, 1.0f);
        }
        go.SendPos(transform.position.x, transform.position.y - 1.0f, 2);
    }
    void MoveDown()
    {
        gameObject.transform.position += new Vector3(0, -1.0f);
        foreach (BoxCollider2D pgo in ObjectMass)
        {
            if (gameObject.transform.position.x == pgo.transform.position.x && gameObject.transform.position.y == pgo.transform.position.y) gameObject.transform.position -= new Vector3(0, -1.0f);
        }
        go.SendPos(transform.position.x, transform.position.y + 1.0f, 3);
    }
    void MoveOnMouse()
    {

    }
}
