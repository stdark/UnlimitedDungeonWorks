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
    public GameObject[] ObjectMass;
    public BoxCollider2D[] InterMass;

    public GameObject Inv;
    private void Start()
    {

        ObjectMass = GameObject.FindGameObjectsWithTag("Obj");
        
        InterMass = GameObject.Find("Interactive_obj").GetComponentsInChildren<BoxCollider2D>();
    }

    private void Update()
    {
        if (!Inv.active)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) MoveUp();
            else if (Input.GetKeyDown(KeyCode.LeftArrow)) MoveLeft();
            else if (Input.GetKeyDown(KeyCode.DownArrow)) MoveDown();
            else if (Input.GetKeyDown(KeyCode.RightArrow)) MoveRight();
            if (gameObject.transform.position == new Vector3(14.0f, -2.0f, gameObject.transform.position.z))
            {
                gameObject.transform.position = new Vector3(63.0f, -118.0f);
            }
            else if (gameObject.transform.position == new Vector3(63.0f, -119.0f, gameObject.transform.position.z)) gameObject.transform.position = new Vector3(14.0f, -3.0f, gameObject.transform.position.z - 1.0f);
        }
    }
    void MoveLeft()
    {
        GameObject.Find("troll").transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
        gameObject.transform.position += new Vector3(-1.0f,0);
        foreach (GameObject pgo in ObjectMass)
        {
            
            if (gameObject.transform.position.x == pgo.transform.position.x && gameObject.transform.position.y == pgo.transform.position.y) gameObject.transform.position -= new Vector3(-1.0f, 0);
        }
        go.SendPos(transform.position.x + 1.0f, transform.position.y, 0);

    }
    void MoveRight()
    {
        GameObject.Find("troll").transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        gameObject.transform.position += new Vector3(1.0f, 0);
        foreach (GameObject pgo in ObjectMass)
        {
            if (gameObject.transform.position.x == pgo.transform.position.x && gameObject.transform.position.y == pgo.transform.position.y) gameObject.transform.position -= new Vector3(1.0f, 0);
        }
        go.SendPos(transform.position.x - 1.0f, transform.position.y, 1);
    }
    void MoveUp()
    {
        gameObject.transform.position += new Vector3(0, 1.0f);
        foreach (GameObject pgo in ObjectMass)
        {
            if (gameObject.transform.position.x == pgo.transform.position.x && gameObject.transform.position.y == pgo.transform.position.y) gameObject.transform.position -= new Vector3(0, 1.0f);
        }
        go.SendPos(transform.position.x, transform.position.y - 1.0f, 2);
    }
    void MoveDown()
    {
        gameObject.transform.position += new Vector3(0, -1.0f);
        foreach (GameObject pgo in ObjectMass)
        {
            if (gameObject.transform.position.x == pgo.transform.position.x && gameObject.transform.position.y == pgo.transform.position.y) gameObject.transform.position -= new Vector3(0, -1.0f);
        }
        go.SendPos(transform.position.x, transform.position.y + 1.0f, 3);
    }
    void MoveOnMouse()
    {

    }
}
