using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScenePlayerController : MonoBehaviour
{
    [SerializeField]
    public Transform[] particlePos;
    [SerializeField]
    public Transform player;
    [SerializeField]
    public ParticleSystem  verticalEmitters, horizontalEmitters;
    float speed = 2;
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
        PlayerMove(speed);

    }

    public void UpdateEmittersPos(float verticalAxis , float horizonralAxis)
    {
        int index = verticalAxis < 0 ? 0: 1;
        verticalEmitters.transform.position = particlePos[index].position;
        verticalEmitters.transform.rotation = particlePos[index].rotation;
        index = horizonralAxis < 0 ? 2: 3;
        horizontalEmitters.transform.position= particlePos[index].position;
        horizontalEmitters.transform.rotation= particlePos[index].rotation;
    }
    public void PlayerMove( float speed)
    {
        float verticalAxis = Input.GetAxis("Vertical");
        float horizontalAxis = Input.GetAxis("Horizontal");
      /*  player.transform.position.x = horizontalAxis * speed;
        player.transform.position.y = verticalAxis * speed;*/
    }
}
