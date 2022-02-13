using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimalManager : MonoBehaviour
{
    NavMeshAgent agent;
    Animator anim;
    public GameObject SE;

    [SerializeField] ParticleSystem particle;
    public Transform target;
    private bool isStalking = true;
    private float chargeTime = 5.0f;
    private float timeCount;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isStalking)
        {
            particle.gameObject.SetActive(true);
            SE.gameObject.SetActive(true);
        }
        if (other.gameObject.tag == "Gate" && !isStalking)
        {
            transform.Rotate(new Vector3(0, 90, 0));
            anim.SetBool("walk", false);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (collision.gameObject.tag == "Player" && isStalking)
        {
            anim.SetBool("walk", true);
            agent.destination = target.position;
            if (distance < 1.5)
            {
                anim.SetBool("walk", false);
            }
        }
        else if (collision.gameObject.tag == "House")
        {
            timeCount += Time.deltaTime;
            isStalking = false;
            transform.position += transform.forward * Time.deltaTime;
            if (timeCount > chargeTime)
            {
                Vector3 course = new Vector3(0, Random.Range(0, 180), 0);
                transform.localRotation = Quaternion.Euler(course);
                timeCount = 0;
            }
        }
    }
}
