using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff : MonoBehaviour
{
    public GameObject light;
    public GameObject fire;
    // Start is called before the first frame update
    void Start()
    {
        light.SetActive(!light.activeSelf);
        fire.SetActive(!fire.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            light.SetActive(!light.activeSelf);
            fire.SetActive(!fire.activeSelf);
        }
    }
}
