using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SencerScript : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "EventTrigger")
        {
            Debug.Log("door");
            if (Input.GetKey(KeyCode.F))
            {
                EventManager.SceneEvent = true;
            }
        }
    }
}
