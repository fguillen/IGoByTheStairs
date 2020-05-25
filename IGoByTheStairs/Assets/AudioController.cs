using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
  public static AudioController instance;

  public AudioSource elevatorDoorsClose;
  public AudioSource elevatorDoorsOpen;
  public AudioSource elevatorUp;

  private void Awake()
  {
    instance = this;
  }

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  public void PlayElevatorDoorsClose()
  {
    elevatorDoorsClose.Play();
  }

  public void PlayElevatorUp()
  {
    elevatorUp.Play();
  }

  public void PlayElevatorDoorsOpen()
  {
    elevatorUp.Stop();
    elevatorDoorsOpen.Play();
  }
}
