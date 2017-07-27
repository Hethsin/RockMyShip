using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControl : MonoBehaviour {
    public bool thrown;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            if (!thrown)
                GameControl.control.rocks++;
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Planet")
        {
            if(thrown)
                Destroy(gameObject);
        }
        else if (collision.transform.tag == "Meteor")
        {
            Destroy(gameObject);
        }
        else if (collision.transform.tag == "Rock")
        {
            if(thrown)
                Destroy(gameObject);
        }
    }
}
