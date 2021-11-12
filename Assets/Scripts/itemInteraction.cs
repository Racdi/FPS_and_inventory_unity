using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    Outline outline;
    public float intensity = 10f;
    float timeout = 0;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeout <= 0){
            outline.OutlineWidth = 0f;
            return;
        }
        outline.OutlineWidth = timeout;
        timeout = timeout - 5*Time.deltaTime;
        
    }

    public void IsLookedAt(){
        timeout = intensity;
    }

}
