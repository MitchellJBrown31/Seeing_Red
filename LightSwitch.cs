using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{

    public GameObject target;
    public List<GameObject> flashlightList;
    public float flashlightDelay;


    private bool unused = true, dark = false;
    private float count = 0;


    void OnTriggerStay()
    {
        if (unused)
        {
            //enable UI
            if (/*player presses E*/ true )
            {
                target.SetActive(false);

                dark = true;
            }
        }
    }

    private void Update()
    {
        if(dark)
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
