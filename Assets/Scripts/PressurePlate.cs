using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class PressurePlateEvent : UnityEvent { };
public class PressurePlate : MonoBehaviour
{
    public PressurePlateEvent onActivate;
    public PressurePlateEvent onDeactivate;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            onActivate.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            onDeactivate.Invoke();
        }
    }
}