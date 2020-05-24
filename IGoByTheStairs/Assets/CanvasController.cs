using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
  public static CanvasController instance;
  public Animator animator;

  // Start is called before the first frame update
  void Start()
  {
    instance = this;
  }

  // Update is called once per frame
  void Update()
  {
        
  }

  public void ShowInstructionsStartAgain()
  {
    animator.SetTrigger("showInstructionsStartAgain");
  }
}
