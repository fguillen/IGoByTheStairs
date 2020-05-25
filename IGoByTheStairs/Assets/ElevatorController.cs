using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
  public float timeDoors;
  private float timeDoorsCounter;
  public float velocity;
  public string state;
  public Rigidbody2D theRB;
  public Animator animator;

  // Start is called before the first frame update
  void Start()
  {
    state = "idle";
    timeDoorsCounter = timeDoors;
  }

  // Update is called once per frame
  void Update()
  {
    if(ManagerController.instance.state == "playing" && state == "idle")
    {
      state = "closingDoors";
      animator.SetTrigger("closeDoors");
      AudioController.instance.PlayElevatorDoorsClose();
    }
    if(state == "goingUp")
    {
      theRB.velocity = new Vector3(0f, velocity, 0f);
    }

    if(state == "openingDoors")
    {
      timeDoorsCounter -= Time.deltaTime;
      if(timeDoorsCounter <= 0)
      {
        state = "end";
        ManagerController.instance.ElevatorFinishes();
      }
    }

    if (state == "closingDoors")
    {
      timeDoorsCounter -= Time.deltaTime;
      if (timeDoorsCounter <= 0)
      {
        state = "goingUp";
        AudioController.instance.PlayElevatorUp();
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
      timeDoorsCounter = timeDoors;
      AudioController.instance.PlayElevatorDoorsOpen();
    }
  }
}
