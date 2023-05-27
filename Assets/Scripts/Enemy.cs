using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour {
    public Transform[] targetArray;
    public NavMeshAgent agent;
    public Transform player;
    public int random;
    public bool isChanging = false;
    Vector3 destination;
    public FieldOfView fov;
    public Timer timeObject;
    Color notAlert = new Color(1F, 0.61F, 0.61F, 1F);
    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        fov = GetComponent<FieldOfView>();
        timeObject = GameObject.Find("TimerController").GetComponent<Timer>();
        agent.autoBraking = false;
        random = Random.Range(0, targetArray.Length);
        destination = agent.destination;
        GotoNextPoint();
    }

    void Update() {
        Debug.Log(agent.remainingDistance);
        if (!fov.canSeePlayer) {
            //ESTADO DE PATRULLA
            agent.speed = 3.5f;
            gameObject.GetComponent<Renderer>().material.color = notAlert;
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        } else if (fov.canSeePlayer) {
            //ESTADO DE PERSECUCION
            agent.destination = player.position;
            agent.speed = 5.5f;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            if (agent.remainingDistance < 1.5f) {
                //ESTADO DE ATAQUE
                timeObject.time = 30f;
                gameObject.GetComponent<Renderer>().material.color = Color.black;
                agent.speed = 1.0f;
            }
        }
    }

    void GotoNextPoint() {
        agent.speed = 4.0f;
        if (targetArray.Length == 0)
            return;
        agent.destination = targetArray[random].position;
        random = Random.Range(0, targetArray.Length);
    }

}
