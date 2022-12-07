using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    public UnityEvent PausedGame=new UnityEvent();

    [SerializeField] private PauseMenu pauseMenu;
    [SerializeField] private WinMenu winMenu;
    [SerializeField] private DefeatMenu defeatMenu;
    private bool IsPaused;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        PausedGame.AddListener(PauseGame);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
            OpenPauseMenu();
        }

    }

    public void PauseGame()
    {

       
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;


    }

    public void OpenPauseMenu()
    {
        pauseMenu.gameObject.SetActive(!pauseMenu.isActiveAndEnabled);
    }

    public void OpenDefeatMenu()
    {
        defeatMenu.gameObject.SetActive(true);
    }

    public void OpenWinMenu()
    {
        winMenu.gameObject.SetActive(true);
    }

}
