using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScenePlayerController : MonoBehaviour
{
    [SerializeField]
    public Transform[] particlePos;
    [SerializeField]
    public ParticleSystem  verticalEmitters, horizontalEmitters;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float verticalAxis = Input.GetAxis("Vertical");
        if (verticalAxis != 0) { verticalEmitters.Play();  } 
        else { verticalEmitters.Stop(); }
        UpdateEmittersPos(verticalAxis, 0);
        float horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis != 0) { horizontalEmitters.Play(); } 
        else { horizontalEmitters.Stop(); }
        UpdateEmittersPos(0, horizontalAxis);
    }

    public void UpdateEmittersPos(float verticalAxis , float HorizonralAxis)
    {
        int index = verticalAxis < 0 ? 0: 1;
        verticalEmitters.transform.position = particlePos[index].position;
        verticalEmitters.transform.rotation = particlePos[index].rotation;
    }
}
