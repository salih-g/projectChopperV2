using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    private static gameManager instance;

    [Header("GameObjects")]

    private GameObject _player;
    private GameObject _playerTurret;
    [Header("AntiAir")]
   public int[] aaLevelDifficulty = new int[10];

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }


        _player = GameObject.FindGameObjectWithTag("Player");
        _playerTurret = GameObject.FindGameObjectWithTag("PlayerTurret");

        if (_player == null)
            Debug.Log("_player Boş!!!");
        if (_playerTurret == null)
            Debug.Log("_playerTurret Boş!!!");
    }


    public static gameManager Instance
    {
        get
        {
            instance = FindObjectOfType<gameManager>();
            if (instance == null)
            {
                GameObject go = new GameObject();
                go.name = "GameController";
                instance = go.AddComponent<gameManager>();

            }
            return instance;
        }
    }



    public GameObject player
    {
        get
        {
         
            return _player;
        }
    }

    public GameObject playerTurret
    {
        get
        {

            return _playerTurret;
        }
    }
}
