using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
	VideoPlayer StartingCutscene;
	public float EndVideoTime;
	bool IsStarting;
	Scene LVL1;

	private void Start()
	{
		StartingCutscene = FindObjectOfType<VideoPlayer>();
	}

	private void Update()
	{
		if (IsStarting && StartingCutscene.targetCameraAlpha < 1) StartingCutscene.targetCameraAlpha = StartingCutscene.targetCameraAlpha + 0.0075f;
		if ((IsStarting && Time.time >= EndVideoTime)||(IsStarting && (Input.GetKeyDown("enter") || Input.GetKeyDown("return"))))
		{
			SceneManager.LoadScene("TFL_LVL1");
		}
	}

	public void PlayGame()
	{
		StartingCutscene.Play();
		IsStarting = true;
		EndVideoTime = Time.time + (float)StartingCutscene.clip.length + 2;
	}

    public void Quitgame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}