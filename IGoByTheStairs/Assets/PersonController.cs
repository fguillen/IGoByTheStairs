using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
  private Vector2 direction;
  public float velocity = 3f;
  public Rigidbody2D theRG;

  // Start is called before the first frame update
  void Start()
  {
    
  }

  // Update is called once per frame
  void Update()
  {
    direction = GetDirection();
    Move();
  }

  void Move()
  {
    theRG.velocity = direction * velocity;
  }

  Vector2 GetDirection()
  {
    Vector2 result;

    if (Input.GetKey(KeyCode.RightArrow))
    {
      result = new Vector2(1f, 0f);
    }
    else if (Input.GetKey(KeyCode.LeftArrow))
    {
      result = new Vector2(-1f, 0f);
    }
    else
    {
      result = Vector2.zero;
    }

    return result;
  }
}
