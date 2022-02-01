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
        //GetComponent<Collider>().enabled = false;
        if (other.tag == "StackedScoop")
        {
            GetComponent<Collider>().enabled = false;
            for (int i = 0; i < stack.stackObjects.Count; i++)
            {
                if (stack.stackObjects[i] == other.gameObject)
                {
                    stack.GetObjects(stack.stackObjects[i], i);
                    //stack.stackObjects.Remove(stack.stackObjects[i]);
                    //Destroy(stack.stackObjects[i]);
                    //other.gameObject.SetActive(false);

                    //currentScoopHit = stack.stackObjects[i];

                    
                    if (this.gameObject.tag == "Spoon")
                    {
                        newCaughtScoop = Instantiate(stack.stackObjects[i], this.gameObject.transform.position, stack.stackObjects[i].transform.rotation);
                        newCaughtScoop.transform.parent = this.gameObject.transform;
                        newCaughtScoop.transform.localPosition = new Vector3(0f, -0.02f, 0.175f);
                    }
                    if (this.gameObject.tag == "Tongue")
                    {
                        newCaughtScoop = Instantiate(stack.stackObjects[i], this.gameObject.transform.position, stack.stackObjects[i].transform.rotation);
                        newCaughtScoop.transform.parent = this.gameObject.transform;
                        newCaughtScoop.transform.localPosition = new Vector3(0f, 0.35f, 0f);
                        foreach (var c in this.gameObject.GetComponentsInChildren<Collider>())
                        {
                            if (c.isTrigger) c.enabled = false;
                        }
                    }

                    stack.stackObjects[i].gameObject.SetActive(false);
                    Debug.Log("loop count");
                    //break;
                }
            }
            //GetComponent<Collider>().enabled = false;
        }
    }
}
