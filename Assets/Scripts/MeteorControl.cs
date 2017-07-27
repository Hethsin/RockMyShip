using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControl : MonoBehaviour {
    private bool collided;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collided) return;
        if (collision.transform.tag == "Player")
        {
            collided = true;
            Destroy(collision.gameObject);
            DestroyMeteor();
            GameControl.control.GameOver();
        }
        if (collision.transform.tag == "Ship")
        {
            collided = true;
            Destroy(collision.gameObject);
            Spawn("metal");
            DestroyMeteor();
        }
        if (collision.transform.tag == "Planet")
        {
            collided = true;
            Destroy(collision.gameObject);
            Spawn("rock");
            DestroyMeteor();
        }
        else if (collision.transform.tag == "Meteor")
        {
            collided = true;
            Spawn("rock");
            DestroyMeteor();
        }
        else if (collision.transform.tag == "Rock")
        {
            collided = true;
            Spawn("metal");
            DestroyMeteor();
        }
    }
    private void Spawn(string spawn)
    {
        if (spawn == "metal")
        {
            Transform newMetal = Instantiate(GameControl.control.metal, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), newMetal.GetComponent<Collider2D>(), true);
        }
        else if (spawn == "rock")
        {
            Transform newRock = Instantiate(GameControl.control.newRock, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), newRock.GetComponent<Collider2D>(), true);
            newRock = Instantiate(GameControl.control.newRock, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), newRock.GetComponent<Collider2D>(), true);
        }
    }
    private void DestroyMeteor()
    {
        Transform particle = Instantiate(GameControl.control.meteorParticle, transform.position, transform.rotation);
        particle.GetComponent<ParticleSystem>().startColor = GetComponent<SpriteRenderer>().color;
        particle.GetComponent<ParticleSystem>().startSize = transform.localScale.x;
        Destroy(gameObject);
    }
}
