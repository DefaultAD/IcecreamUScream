using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoopToppings : MonoBehaviour
{
    public Stack stack;
    public GameObject obiEmitter;
    public GameObject origChocSauce;

    private bool chocSpawn = false;
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
        if (other.tag == "SprinkleTrigger")
        {
            Debug.Log("Sprinkle Trigger");
            for (int i = 0; i < stack.stackObjects.Count; i++)
            {
                stack.stackObjects[i].transform.GetChild(0).gameObject.SetActive(true);
            }
            //GetComponent<Collider>().enabled = false;
        }

        if (other.tag == "ChocSprinkleTrigger")
        {
            Debug.Log("Choc Sprinkle Trigger");
            for (int i = 0; i < stack.stackObjects.Count; i++)
            {
                stack.stackObjects[i].transform.GetChild(1).gameObject.SetActive(true);
                //stack.stackObjects[i].transform.GetChild(1).gameObject.transform.Rotate(0, 0, Random.Range(0, 180));
            }
            //GetComponent<Collider>().enabled = false;
        }

        if (other.tag == "SauceTrigger")
        {
            obiEmitter.SetActive(true);
            Debug.Log("Sauce Trigger");
            StartCoroutine(chocSauceWait());
            
            //GetComponent<Collider>().enabled = false;
        }

        //if (other.tag == "MellowTrigger")
        //{
        //    Debug.Log("Marshmellow Trigger");
        //    for (int i = 0; i < stack.stackObjects.Count; i++)
        //    {
        //        stack.stackObjects[i].transform.GetChild(3).gameObject.SetActive(true);
        //        stack.stackObjects[i].transform.GetChild(3).gameObject.transform.Rotate(0, 0, Random.Range(0, 180));
        //    }
        //    //GetComponent<Collider>().enabled = false;
        //}

        IEnumerator chocSauceWait()
        {
            yield return new WaitForSeconds(1f);
            for (int i = 0; i < stack.stackObjects.Count - 1; i++)
            {
                obiEmitter.SetActive(true);
                stack.stackObjects[i].transform.GetChild(2).gameObject.SetActive(true);
                stack.stackObjects[i].transform.GetChild(2).gameObject.transform.Rotate(0, 0, Random.Range(0, 180));
                origChocSauce.SetActive(true);
            }
        }
    }
}
