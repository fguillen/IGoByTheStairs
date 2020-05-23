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
    
  }

  // Update is called once per frame
  void Update()
  {
    ChangeVelocity();
    ChangeDirection();
    Move();
    FlipCharacter();
  }

  void Move()
  {
    theRB.velocity = direction * actualVelocity;
    //theRB.AddForce(direction * actualVelocity);
  }

  void FlipCharacter()
  {
    if(direction.x < 0)
    {
      theRB.transform.localScale = new Vector3(1f, 1f, 1f);
    } else
    {
      theRB.transform.localScale = new Vector3(-1f, 1f, 1f);
    }
  }

  void ChangeVelocity()
  {
    if(onStairs)
    {
      actualVelocity = velocity * 2;
    } else
    {
      actualVelocity = velocity;
    }
  }

  void ChangeDirection()
  {
    if (Input.GetKey(KeyCode.RightArrow))
    { 
      direction = new Vector2(1f, 0f);
    }
    else if (Input.GetKey(KeyCode.LeftArrow))
    {
      direction = new Vector2(-1f, 0f);
    }
    else
    {
      direction = Vector2.zero;
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


  //void OnCollisionEnter(Collision: collider)
  //{
  //  Debug.Log("GameObject Hit: " + collider.gameObject.name);
  //}
}
