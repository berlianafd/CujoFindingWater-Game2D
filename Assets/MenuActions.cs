using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuActions : MonoBehaviour
{
	//------------------------
	// make Unity load the scene with the given name
	// we call this method when the UI button received an OnClick user interaction event message
	public void MENU_ACTION_GotoPage(string sceneName)
	{
        SceneManager.LoadScene(sceneName);
    }	
}