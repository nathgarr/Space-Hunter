using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScenePlayerController : MonoBehaviour
{
    [SerializeField]
    public Transform[] particlePos;
    [SerializeField]
    public Rigidbody rb;
    [SerializeField]
    public ParticleSystem  verticalEmitters, horizontalEmitters;
    float speed = 2;
    float verticalAxis, horizontalAxis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalAxis = Input.GetAxis("Vertical");
        if (verticalAxis != 0) { verticalEmitters.Play();  } 
        else { verticalEmitters.Stop(); }
         horizontalAxis = Input.GetAxis("Horizontal");
        if (horizontalAxis != 0) { horizontalEmitters.Play(); } 
        else { horizontalEmitters.Stop(); }
        UpdateEmittersPos(verticalAxis, horizontalAxis);
    }
    public void FixedUpdate()
    {
        PlayerMove(speed);
    }

    public void UpdateEmittersPos(float verticalAxis , float horizonralAxis)
    {
        int index = verticalAxis < 0f ? 0: 1;
        verticalEmitters.transform.position = particlePos[index].position;
        verticalEmitters.transform.rotation = particlePos[index].rotation;
        Debug.Log(index);
        index = horizonralAxis < 0f ? 2: 3;
        horizontalEmitters.transform.position= particlePos[index].position;
        horizontalEmitters.transform.rotation= particlePos[index].rotation;
       
    }
    public void PlayerMove( float speed)
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
        Vector3 velocity = new Vector3(horizontalAxis, verticalAxis, 0);
        rb.AddForce(velocity);
    }
}
