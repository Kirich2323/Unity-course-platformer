using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOverTime : MonoBehaviour
{

    public float lifeTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
