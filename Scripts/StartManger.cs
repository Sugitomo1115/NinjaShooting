using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManger : MonoBehaviour
{
	public Text HighScoreNum;

	//保存されているハイスコアを表示
    public void Start()
	{
		this.HighScoreNum.text = PlayerPrefs.GetInt("HighScore").ToString("F0");
	}

	//カウントダウン画面に移行
	public void PlayGame()
	{
		SceneManager.LoadScene("LoadScene");
	}

	//ゲームを終了
	public void QuitGame()
	{
		Application.Quit();
	}
}
