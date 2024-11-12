using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public static SlimeController instance;
    [SerializeField]
    GameObject slimeBallPrefab;
    public Transform targetObject;
    public Transform SpawnPoint;

    public float viewRaduis = 10;
    public float viewAngles = 360;
    public float slimeBallSpeed = 4;

    public float fireRate = 1f;
    private float nextFire = 0.0f;

    public LayerMask playerMask;

    public bool m_PlayerInRAnge;

    Vector3 m_PlayerPosition;

    Coroutine monsterCorout;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        m_PlayerInRAnge = false;
    }
    public void OnDrawGizmosSelected()
    {
        Handles.color = m_PlayerInRAnge ? Color.red : Color.green;
        Handles.DrawSolidArc(transform.position, Vector3.up, transform.forward, viewAngles, viewRaduis);

    }

    // Update is called once per frame
    void Update()
    {
        SlimeView();
    }

    public void SlimeView()
    {
        Collider[] playerInRange = Physics.OverlapSphere(transform.position, viewRaduis, playerMask);
        for (int i = 0; i < playerInRange.Length; i++)
        {
           
            if (playerInRange.Length > 0)
            {
                targetObject = playerInRange[0].transform;
                m_PlayerInRAnge = true;
                if (monsterCorout == null)
                {
                    monsterCorout = StartCoroutine(FireCorout());
                }

            }
            else
            {
                m_PlayerInRAnge = false;
                targetObject = null;
            }
        }
    }
    IEnumerator FireCorout()
    {
        Debug.Log("start coroutine");
        while (m_PlayerInRAnge)
        {
            float fireDelay = Random.Range(1f, 2f);
            yield return new WaitForSeconds(fireDelay);
            transform.LookAt(targetObject.position);
            GameObject projectilInstance = Instantiate(slimeBallPrefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation) as GameObject;
            Rigidbody bullRig = projectilInstance.GetComponent<Rigidbody>();
            bullRig.AddForce(bullRig.transform.forward * slimeBallSpeed);
        }
        monsterCorout = null;
    }

}
