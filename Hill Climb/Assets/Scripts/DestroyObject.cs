using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // destroy falling object for memory management
        if (transform.position.y < 0.0f) {
            Destroy(gameObject);
        }
        
        
    }
}
