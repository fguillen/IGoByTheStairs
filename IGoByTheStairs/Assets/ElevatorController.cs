using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
  public float timeDoors = 2f;
  public float velocity = 3f;
  public string state;
  public Rigidbody2D theRB;
  public Animator animator;

  // Start is called before the first frame update
  void Start()
  {
    state = "idle";
  }

  // Update is called once per frame
  void Update()
  {
    if(state == "idle")
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        state = "closingDoors";
        animator.SetTrigger("closeDoors");
      }
    }
    if(state == "goingUp")
    {
      theRB.velocity = new Vector3(0f, velocity, 0f);
    }

    if(state == "closingDoors")
    {
      timeDoors -= Time.deltaTime;
      if(timeDoors <= 0)
      {
        state = "goingUp";
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("ElevatorLastPosition"))
    {
      state = "openingDoors";
      animator.SetTrigger("openDoors");
      theRB.velocity = Vector3.zero;
    }
  }
}
