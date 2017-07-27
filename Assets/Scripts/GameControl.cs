using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public int rocks;
    public int components;
    public bool paused;
    public Transform ship;
    public Rigidbody2D player;
    public Transform world;
    public Transform chunk;
    public Transform meteor;
    public Transform metal;
    public Transform rock;
    private WorldGenerator generator;
    public Transform newRock;
    public Transform ship0;
    public Transform ship1;
    public Transform ship2;
    public Transform ship3;
    public Transform ship4;
    public Transform ship5;
    public float timer;
    public UI ui;
    public GameObject menu;
    public Transform meteorParticle;

    private void Awake()
    {
        control = this;
        Screen.SetResolution(1000, 1000, false);
        generator = GetComponent<WorldGenerator>();
    }
    private void Start()
    {
        rocks = 0;
        components = 0;
        timer = 0;
        Color color1 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.3f, 1f);
        Color color2 = Random.ColorHSV(0f, 1f, 1f, 1f, 0.3f, 1f);
        chunk.GetComponent<SpriteRenderer>().color = color1;
        rock.GetComponent<SpriteRenderer>().color = color1;
        newRock.GetComponent<SpriteRenderer>().color = color1;
        meteor.GetComponent<SpriteRenderer>().color = color2;
        metal.GetComponent<SpriteRenderer>().color = color2;
        ship0.GetComponent<SpriteRenderer>().color = color2;
        ship1.GetComponent<SpriteRenderer>().color = color2;
        ship2.GetComponent<SpriteRenderer>().color = color2;
        ship3.GetComponent<SpriteRenderer>().color = color2;
        ship4.GetComponent<SpriteRenderer>().color = color2;
        ship5.GetComponent<SpriteRenderer>().color = color2;

        generator.GenerateWorld();   
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
            paused = true;
            menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
            menu.SetActive(false);
        }
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        ui.GameOver();
    }
    public void GameWon()
    {
        Time.timeScale = 0;
        ui.GameWon();
    }
}

