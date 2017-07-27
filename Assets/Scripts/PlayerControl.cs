using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator anim;
    public LayerMask groundLayer;
    public float maxVelocity;
    public bool isGrounded;
    public bool primed;
    private bool busy;
    private Vector2 direction;
    private Rigidbody2D body;
    private Vector2 target;
    public float throwForce;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        direction = Vector3.zero;
        throwForce = 1;
    }

    void Update()
    {
        direction = transform.position - GameControl.control.world.position;
        transform.right = Vector3.Cross(direction, Vector3.forward);
        if (body.IsTouchingLayers(groundLayer))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if (!GameControl.control.paused && !busy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isGrounded)
                    Jump();
            }
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                //Nothing
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Move(false);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Move(true);
            }
            else
            {
                anim.SetInteger("Move", 0);
            }
            if (GameControl.control.rocks > 0)
            {
                if ((Input.GetMouseButton(0)))
                {
                    anim.SetBool("Throw", true);
                    Force();
                }
                if ((Input.GetMouseButtonUp(0)))
                {
                    Launch();
                    anim.SetBool("Throw", false);
                }
            }
            if (GameControl.control.components >= 3)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    if (GameControl.control.components >= 3)
                    {
                        busy = true;
                        StartCoroutine(BuildShip(2f));
                    }
                }
            }
        }

    }
    private void FixedUpdate()
    {
        if (body.velocity.magnitude > maxVelocity)
        {
            body.velocity = body.velocity.normalized * maxVelocity;
        }

    }
    private void Move(bool direction)
    {
        if (direction)
        {
            anim.SetInteger("Move", -1);
            body.AddForce(transform.right * 30);
        }
        else
        {
            anim.SetInteger("Move", 1);
            body.AddForce(-transform.right * 30);
        }
    }
    private void Jump()
    {
        anim.SetTrigger("Jump");
        body.velocity = (transform.up * 100);
    }
    private void Force()
    {
        if (!primed) primed = true;
        if (throwForce < 5)
            throwForce += Time.deltaTime;
    }
    private void Launch()
    {
        Transform newRock = Instantiate(GameControl.control.rock, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), newRock.GetComponent<Collider2D>(), true);
        Vector3 point = Camera.main.WorldToScreenPoint(newRock.position);
        target = (Input.mousePosition - point).normalized;
        newRock.GetComponent<RockControl>().thrown = true;
        newRock.GetComponent<Rigidbody2D>().AddForce(target * 400 * throwForce);
        throwForce = 1;
        GameControl.control.rocks--;
        primed = false;
    }
    private IEnumerator BuildShip(float time)
    {
        anim.SetBool("Build", true);

        if (GameControl.control.ship == null)
        {
            yield return new WaitForSeconds(time);
            GameControl.control.ship = Instantiate(GameControl.control.ship0, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            GameControl.control.components = GameControl.control.components - 3;
        }
        else
        {
            if (body.IsTouching(GameControl.control.ship.GetComponent<Collider2D>()))
            {
                if (GameControl.control.ship.GetComponent<ShipControl>().stage == 0)
                {
                    yield return new WaitForSeconds(time);
                    Destroy(GameControl.control.ship.gameObject);
                    GameControl.control.ship = Instantiate(GameControl.control.ship1, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                }
                else if (GameControl.control.ship.GetComponent<ShipControl>().stage == 1)
                {
                    yield return new WaitForSeconds(time);
                    Destroy(GameControl.control.ship.gameObject);
                    GameControl.control.ship = Instantiate(GameControl.control.ship2, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                }
                else if (GameControl.control.ship.GetComponent<ShipControl>().stage == 2)
                {
                    yield return new WaitForSeconds(time);
                    Destroy(GameControl.control.ship.gameObject);
                    GameControl.control.ship = Instantiate(GameControl.control.ship3, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                }
                else if (GameControl.control.ship.GetComponent<ShipControl>().stage == 3)
                {
                    yield return new WaitForSeconds(time);
                    Destroy(GameControl.control.ship.gameObject);
                    GameControl.control.ship = Instantiate(GameControl.control.ship4, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                }
                else if (GameControl.control.ship.GetComponent<ShipControl>().stage == 4)
                {
                    yield return new WaitForSeconds(time);
                    Destroy(GameControl.control.ship.gameObject);
                    GameControl.control.ship = Instantiate(GameControl.control.ship5, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                    GameControl.control.GameWon();
                }
                GameControl.control.components = GameControl.control.components - 3;
            }
        }
        anim.SetBool("Build", false);
        busy = false;
    }
}
