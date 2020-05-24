using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenController : MonoBehaviour
{
  public Animator animator;

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      animator.SetTrigger("splashScreenOut");
    }
  }

  public void GoToGame()
  {
    SceneManager.LoadScene("Stairs");
  }
}
