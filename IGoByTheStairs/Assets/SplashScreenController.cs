using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenController : MonoBehaviour
{
  public float waitSeconds = 2f;
  public float whiteSeconds = 2f;
  public Image white;

  // Start is called before the first frame update
  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    waitSeconds -= Time.deltaTime;
    if(waitSeconds <= 0)
    {
      white.color = new Color(white.color.r, white.color.g, white.color.b, Mathf.MoveTowards(white.color.a, 1f, whiteSeconds));

      if (white.color.a <= 1f) {
        SceneManager.LoadScene("Stairs");
      }
    }
  }
}
