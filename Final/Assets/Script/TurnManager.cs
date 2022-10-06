using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    private Player[] players;

    private Transform playerCamera;

    private int currentPlayer;

    

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        players = GameObject.FindObjectsOfType<Player>();
        playerCamera = Camera.main.transform;

        for (int i = 0; i < players.Length; i++)
        {
            players[i].playerID = i;
        }

        NextPlayer();
    }

    public bool IsMyTurn(int i)
    {
        return i == currentPlayer;
    }

    public void NextPlayer()
    {
        StartCoroutine(_NextPlayer());
    }

    public IEnumerator _NextPlayer()
    {
        players[currentPlayer].GetComponentInChildren<Camera>().enabled = false;
        players[currentPlayer].GetComponentInChildren<MouseLook>().enabled = false;

        int nextPlayer = currentPlayer + 1;
        currentPlayer -= 1;

        yield return new WaitForSeconds(0.1f);

        currentPlayer = nextPlayer;

        if(currentPlayer >= players.Length)
        {
            currentPlayer = 0;
        }

        /*Vector3 v = playerCamera.transform.localPosition;

        playerCamera.SetParent(players[currentPlayer].transform);

        playerCamera.transform.localPosition = v;*/

        players[currentPlayer].GetComponentInChildren<Camera>().enabled = true;
        players[currentPlayer].GetComponentInChildren<MouseLook>().enabled = true;

    }

    /*
    private static TurnManager instance;
    [SerializeField] private PlayerTurn playerOne;
    [SerializeField] private PlayerTurn playerTwo;
    [SerializeField] private float timeBetweenTurns;
    [SerializeField] private float turnDuration;

    private int currentPlayerIndex;
    private bool waitingForNextTurn;
    private float turnDelay;
    private float currentTurn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
            playerOne.SetPlayerTurn(1);
            playerTwo.SetPlayerTurn(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingForNextTurn)
        {
            turnDelay += Time.deltaTime;
            if (turnDelay > timeBetweenTurns)
            {
                turnDelay = 0;
                waitingForNextTurn = false;
                ChangeTurn();
            }
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        if (waitingForNextTurn)
        {
            return false;
        }

        return index == currentPlayerIndex;

    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void TriggerChangeTurn()
    {
        waitingForNextTurn = true;
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
        }
    }*/


    /*
    private static TurnManager instance;

    private int currentPlayerIndex;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentPlayerIndex = 1;
        }
    }

    public bool IsItPlayerTurn(int index)
    {
        return index == currentPlayerIndex;
    }

    public static TurnManager GetInstance()
    {
        return instance;
    }

    public void ChangeTurn()
    {
        if (currentPlayerIndex == 1)
        {
            currentPlayerIndex = 2;
        }
        else if (currentPlayerIndex == 2)
        {
            currentPlayerIndex = 1;
        }
    }*/
}
