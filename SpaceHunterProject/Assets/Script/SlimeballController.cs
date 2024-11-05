using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeballController : MonoBehaviour
{

    float slimeballSpeed = 4;
    float lifeTime = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
       /* transform.Translate(Vector3(0,0,0) * slimeballSpeed * Time.deltaTime);*/
    }
}
