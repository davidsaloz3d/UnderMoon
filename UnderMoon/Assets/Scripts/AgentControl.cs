using UnityEngine;
using UnityEngine.AI;

public class AgentControl : MonoBehaviour
{
   NavMeshAgent agent; 
    [SerializeField] GameObject[] path; 
    int goal = 0;

    [Header("Detection")]
    [SerializeField] GameObject player;
    [SerializeField] float visionArea = 5;
    [SerializeField] float visionAtaque =2;

    [SerializeField] GameObject Perro;

    [SerializeField] Animator anim;


    float distance;
    float ataque;
    bool follow = false;
    bool Siguiendo = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      
        agent.destination = path[goal].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       
        distance = Vector3.Distance(transform.position, 
                            player.transform.position);

        if (distance <= visionArea){
            agent.destination = player.transform.position;
            follow = true; 
            Siguiendo = true;
        } else {
            agent.destination = path[goal].transform.position;
            follow = false;
            Siguiendo = false;
            
        }

        if(distance<= visionAtaque){
             //transform.LookAt(player.transform.position);
            anim.SetBool("Bite", true);
            Perro.GetComponent<NavMeshAgent>().speed = 0.2f;
            
            
        }
        else{
            anim.SetBool("Bite", false);
            Perro.GetComponent<NavMeshAgent>().speed = 3.5f;

        }

        if (agent.remainingDistance < 1 && !follow){
            goal++;
            if (goal == path.Length){
                goal = 0; 
            }
            agent.destination = path[goal].transform.position;
        }

        if(Siguiendo == true){

            anim.SetBool("Corriendo", true);
        }

        else{

            anim.SetBool("Corriendo", false);
        }


   
}
}
