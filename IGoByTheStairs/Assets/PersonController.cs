using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
  private Vector2 direction;
  public float velocity = 10f;
  public float actualVelocity;
  public Rigidbody2D theRB;
  public bool onStairs;

  // Start is called before the first frame update
  void Start()
  {
    direction = new Vector2(1f, 0f);
  }

  // Update is called once per frame
  void Update()
  {
    if (ManagerController.instance.state == "playing")
    {
      ChangeVelocityOnStairs();
      ToogleDirection();
      Move();
      FlipCharacter();
    } else
    {
      theRB.velocity = Vector2.zero; // TODO fix this trick
    }
  }

  void Move()
  {
    if (Input.GetKey(KeyCode.UpArrow))
    {
      theRB.velocity = direction * actualVelocity;
    } else
    {
      theRB.velocity = Vector2.zero;
    }
  }

  void FlipCharacter()
  {
    if(direction.x > 0)
    {
      theRB.transform.localScale = new Vector3(1f, 1f, 1f);
    } else
    {
      theRB.transform.localScale = new Vector3(-1f, 1f, 1f);
    }
  }

  void ChangeVelocityOnStairs()
  {
    if(onStairs)
    {
      actualVelocity = velocity * 2;
    } else
    {
      actualVelocity = velocity;
    }
  }

  void ToogleDirection()
  {
    if(!onStairs && Input.GetKeyDown(KeyCode.Space))
    {
      direction = new Vector2(direction.x * -1f, 0f);
    }
  }

  public void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Steps"))
    {
      onStairs = true;
    }
  }

  public void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Steps"))
    {
      onStairs = false;
    }
  }

  public void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("PersonLastPosition"))
    {
      ManagerController.instance.PersonFinishes();
    }
  }
}
