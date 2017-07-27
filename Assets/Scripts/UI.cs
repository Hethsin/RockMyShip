using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    public Text rockCounter;
    public Text componentCounter;
    public Text timeCounter;
    public GameObject gameOver;
    public GameObject gameWon;
    public Slider slider;
    private PlayerControl player;

    private void Start()
    {
        player = GameControl.control.player.GetComponent<PlayerControl>();
    }
    private void Update()
    {
        rockCounter.text = GameControl.control.rocks.ToString();
        componentCounter.text = GameControl.control.components.ToString();
        timeCounter.text = GameControl.control.timer.ToString("f0");
        if (player.primed)
        {
            slider.value = player.throwForce;
        }
        else
        {
            slider.value = 0;
        }
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
    }
    public void GameWon()
    {
        gameWon.SetActive(true);
    }
}
