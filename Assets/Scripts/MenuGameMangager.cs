using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGameMangager : MonoBehaviour {
    public static MenuGameMangager instance = null;
	private int bestScore;

    private void Start() {
        Invoke("CallAdsBanner", 0.01f);
        bestScore = PlayerPrefs.GetInt("bestScore", bestScore);
    }

	private void OnHideUnity(bool isGameShown)
	{
		if (!isGameShown)
		{
			// Pause the game - we will need to hide
			Time.timeScale = 0;
		}
		else
		{
			// Resume the game - we're getting focus again
			Time.timeScale = 1;
		}
	}

	public void GoToGamePlay() {
        SceneManager.LoadScene("GamePlay");
    }

    public void GoToShop() {
        SceneManager.LoadScene("Shop");
    }
}
