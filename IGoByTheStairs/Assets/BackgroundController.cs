using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
  public GameObject cameraObject;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    gameObject.transform.position = new Vector3(cameraObject.transform.position.x, cameraObject.transform.position.y, gameObject.transform.position.z);
  }
}
