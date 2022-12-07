using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public UnityEvent HouseDestroyed = new();
    public UnityEvent PlayerDied = new();
    public UnityEvent EnemyDied = new();
    public UnityEvent PausedGame = new();
    public UnityEvent WinGame = new();
    public UnityEvent DefeatGame = new();

    [SerializeField] private int playerUnitCount;
    public List<GameObject> HousesList { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    void Start()
    {
        HousesList = GameObject.FindGameObjectsWithTag("House").ToList();
        playerUnitCount = GameObject.FindGameObjectsWithTag("Player").Length;
        HouseDestroyed.AddListener(DeleteHouseFromList);
        PlayerDied.AddListener(UpdatePlayerUnitCount);
        WinGame.AddListener(Win);
        DefeatGame.AddListener(Defeat);
    }

    private void UpdatePlayerUnitCount()
    {
        playerUnitCount--;
        if (playerUnitCount == 0)
            Defeat();
    }

    private void DeleteHouseFromList()
    {
        foreach (var house in HousesList)
        {
            if (!house.activeSelf)
            {
                HousesList.Remove(house);
                break;
            }
        }

        if (HousesList.Count == 0)
            Defeat();
    }

    private void Defeat()
    {
        MenuManager.Instance.OpenDefeatMenu();
    }

    private void Win()
    {
        MenuManager.Instance.OpenWinMenu();
    }
}
