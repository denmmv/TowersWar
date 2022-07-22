using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private Button _firstPlayer;
    [SerializeField] private Button _secondPlayer;
    [SerializeField] private GameObject _choose;
    [SerializeField] private GameObject _UI;
    public UnityEvent PlayerFirstSelected;
    public UnityEvent PlayerSecondSelected;
    private void Start()
    {
        _firstPlayer.onClick.AddListener(choiceFirst);
        _secondPlayer.onClick.AddListener(choiceSecond);
    }
    private void choiceFirst()
    {
        startGame();
        PlayerFirstSelected.Invoke();
    }
    private void choiceSecond()
    {
        startGame();
        PlayerSecondSelected.Invoke();
    }
    private void startGame()
    {
        _choose.SetActive(false);
        _UI.SetActive(true);        
    }
}
