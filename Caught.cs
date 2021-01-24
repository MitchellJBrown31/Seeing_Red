using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caught : MonoBehaviour
{
    float counter = 0;
    int inside = 0;
    List<float> list;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer.Equals(8))
        {

        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(8))
        {
            list.Add(other.>
            inside++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer.Equals(8))
        {
            inside--;
            list.Remove(other.gameObject.GetComponent<distToPlayer>().dist);
        }
    }
    */
    private void Update()
    {

        if (inside >= 1)
        {
            float min = 99999;
            list.ForEach(i =>
            {
                if (i < min)
                    min = i;
            });
            
            counter += Time.deltaTime/min * 10; //if they're LESS than 10 metres away, it'll catch them in LESS than 3 seconds
        }
        else
            counter -= Time.deltaTime;

        counter = Mathf.Clamp(counter, 0, 3);

        if (counter>=3)
        {
            //Trigger detection animation/loss
            Debug.Log("aww you fuckin died bict");
        }
    }
    
}
