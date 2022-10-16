using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Game2 : MonoBehaviour
{
    public GameObject _gameObject;
    public static Game2 _game; 
    void Start()
    {
        _game = this;
    }
    public void GameWin()
    {
        _gameObject.SetActive(true);
    } 
}
