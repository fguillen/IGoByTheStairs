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
  public int clicksCounter = 0;
  public int clicksPerSecond = 0;
  private float lastClicksCountTime;

  // Start is called before the first frame update
  void Start()
  {
    direction = new Vector2(1f, 0f);
  }

  // Update is called once per frame
  void Update()
  {
    ChangeVelocityOnStairs();
    ToogleDirection();
    Move();
    FlipCharacter();
    //CountClicksPerSecond();
  }

  //void CountClicksPerSecond()
  //{
  //  if (Input.GetKeyDown(KeyCode.RightArrow))
  //  {
  //    if(clicksCounter == 0)
  //    {
  //      lastClicksCountTime = Time.time;
  //    }

  //    clicksCounter++;
  //  }

  //  var secondsDistance = Time.time - lastClicksCountTime;
    
  //  if(secondsDistance >= 1f)
  //  {
  //    lastClicksCountTime = Time.time;
  //    clicksPerSecond = clicksCounter;
  //    clicksCounter = 0;
  //    Debug.Log("clicksPerSecond: " + clicksPerSecond);
  //  }
  //}

  void Move()
  {
    if (Input.GetKey(KeyCode.RightArrow))
    {
      theRB.velocity = direction * actualVelocity;
      //var newX = gameObject.transform.position.x + (actualVelocity * Time.deltaTime);
      //gameObject.transform.position = new Vector3(newX, gameObject.transform.position.y, gameObject.transform.position.z);

      //theRB.AddForce(direction * actualVelocity);
    } else
    {
      theRB.velocity = Vector2.zero;
    }
    
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


  //void OnCollisionEnter(Collision: collider)
  //{
  //  Debug.Log("GameObject Hit: " + collider.gameObject.name);
  //}
}
