using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerController : MonoBehaviour
{
  public string state;
  public static ManagerController instance;
  public Text instructionsText;
  public Text resultText;
  private float elevatorTime;
  private float personTime;

  private void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
    state = "instructions";
    elevatorTime = 0f;
    personTime = 0f;
  }

  // Update is called once per frame
  void Update()
  {
    if (state == "instructions")
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        state = "playing";
        instructionsText.gameObject.SetActive(false);
      }
    }
  }

  public void EndGame()
  {
    state = "end";
    float resultTime = elevatorTime - personTime;
    resultTime = (Mathf.Round(resultTime * 100)) / 100f;
    resultTime = Mathf.Abs(resultTime);
    string message;

    if(resultTime >= 0)
    {
      message = "You win";
    } else
    {
      message = "Elevator wins";
    }

    resultText.text = resultTime + " seconds difference \n" + message;
    resultText.gameObject.SetActive(true);
  }

  public void ElevatorFinishes()
  {
    Debug.Log("ElevatorFinishes");
    elevatorTime = Time.time;
    if(personTime != 0f)
    {
      EndGame();
    }
  }

  public void PersonFinishes()
  {
    Debug.Log("PersonFinishes");
    personTime = Time.time;
    if (elevatorTime != 0f)
    {
      EndGame();
    }
  }
}
