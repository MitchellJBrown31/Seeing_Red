using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{

    public List<GameObject> targetList;
    public List<GameObject> flashlightList;
    public float flashlightDelay;
    public bool reusable;


    private bool unused = true, dark = false, withinRange = false;
    private float count = 0;


    void OnTriggerEnter(Collider other)
    {
        if ((unused || reusable) && other.gameObject.layer.Equals(11))
        {
            //enable UI
            withinRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer.Equals(11))
        {
            //disable UI
            withinRange = false;
        }
    }

    private void Update()
    {
        if (withinRange && Input.GetKeyDown("e"))
        {
            if(unused || reusable)
            {
                this.targetList.ForEach(i =>
                {
                    if (i.active == false)
                        i.SetActive(true);
                    else
                        i.SetActive(false);
                });

                unused = false;
                dark = true;

            }

            
        }


        if (dark)
        {
            count += Time.deltaTime;
            if(count >= flashlightDelay)
            {
                dark = false;
                flashlightList.ForEach(i =>
               {
                   i.SetActive(true);
               });
            }

        }
    }
}
