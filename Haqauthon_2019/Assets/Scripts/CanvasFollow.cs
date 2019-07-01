using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(this.gameObject.GetComponent<Transform>().rotation.x + ", " + this.gameObject.GetComponent<Transform>().rotation.y + ", " + this.gameObject.GetComponent<Transform>().rotation.z);
    }
}
