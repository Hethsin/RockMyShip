using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGenerator : MonoBehaviour {
    public float timer;

    void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (GameControl.control.timer < 25)
        {
            if (timer > 9f)
            {
                SpawnMeteor();
                timer = 0;
            }
        }
        else if (GameControl.control.timer < 50)
        {
            if (timer > 7f)
            {
                SpawnMeteor();
                timer = 0;
            }
        }
        else if (GameControl.control.timer < 70)
        {
            if (timer > 5f)
            {
                SpawnMeteor();
                timer = 0;
            }
        }
        else if (GameControl.control.timer < 120)
        {
            if (timer > 4f)
            {
                SpawnMeteor();
                timer = 0;
            }
        }
        else if (GameControl.control.timer > 120)
        {
            if (timer > 3f)
            {
                SpawnMeteor();
                timer = 0;
            }
        }
    }
    private void SpawnMeteor()
    {
        Transform newMeteor = Instantiate(GameControl.control.meteor, RandomPos(Vector3.zero, 30f), Quaternion.identity);
        float newSize = Random.Range(0.5f, 1.4f);
        newMeteor.GetComponent<Rigidbody2D>().mass = newSize;
        newMeteor.transform.localScale = new Vector3(newSize, newSize, newSize);
        newMeteor.transform.rotation = GameControl.control.player.transform.rotation;
    }
    Vector3 RandomPos(Vector3 center, float radius)
    {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }
}
