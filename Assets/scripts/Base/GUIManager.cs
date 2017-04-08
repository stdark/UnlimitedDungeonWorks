using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour {
    static bool isInventoryShow = false;
    public GameObject InvPanel;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.I))
        {
            if (!isInventoryShow)
            {
                InvPanel.active = true;
                isInventoryShow = true;
            }
            else
            {
                InvPanel.active = false;
                isInventoryShow = false;
            }
        }
        
	}
}
