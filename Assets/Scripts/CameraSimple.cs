using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSimple : MonoBehaviour {
    Transform player;
    public bool rotate;
	void Start () {
        player = GameControl.control.player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if(rotate)
        transform.rotation = player.rotation;
	}
}
