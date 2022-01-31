using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHit : MonoBehaviour
{
    public Stack stack;
    private GameObject currentScoopHit;
    private GameObject newCaughtScoop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StackedScoop")
        {
            for (int i = 0; i < stack.stackObjects.Count; i++)
            {
                if (stack.stackObjects[i] == other.gameObject)
                {
                    stack.GetObjects(stack.stackObjects[i], i);
                    //stack.stackObjects.Remove(stack.stackObjects[i]);
                    //Destroy(stack.stackObjects[i]);
                    //other.gameObject.SetActive(false);

                    //currentScoopHit = other.gameObject;

                    //newCaughtScoop = Instantiate(currentScoopHit, currentScoopHit.transform.position, currentScoopHit.transform.rotation);
                    //newCaughtScoop.transform.parent = this.gameObject.transform;

                    other.gameObject.SetActive(false);
                }
            }
            GetComponent<Collider>().enabled = false;
        }
    }
}
