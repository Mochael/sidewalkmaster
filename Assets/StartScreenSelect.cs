using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenSelect : MonoBehaviour {

	public void loadLevel(string levelName)
	{
		SceneManager.LoadScene (levelName);
	}
}
