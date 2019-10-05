using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;


    private GameObject _player;
    private GameObject _playerTurret;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerTurret = GameObject.FindGameObjectWithTag("PlayerTurret");
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
