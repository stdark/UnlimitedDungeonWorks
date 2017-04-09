using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GUIManagerMenu : MonoBehaviour {
    public Text IdField;
    
    public void LogInClick()
    {
       
        Parameters.Inst.id = IdField.text.ToString();
        SceneManager.LoadScene(1);
    }
}
