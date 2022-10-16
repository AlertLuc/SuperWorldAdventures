using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class Game : MonoBehaviour
{
    public int total_score;
    public Text scoreText;
    public GameObject _gameObject;
    public static Game _game;
    void Start()
    {
        _game = this;
    }
   public void Updatescore()
    {
        this.scoreText.text = total_score.ToString();
    }
    public void GameOver()
    {
        _gameObject.SetActive(true);
    }
    public void Restar(string a)
    {
        SceneManager.LoadScene(a);
    }
}
