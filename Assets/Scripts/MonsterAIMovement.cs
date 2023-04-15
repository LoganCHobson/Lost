using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterAIMovement : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform target;
    public bool scared = false;

    public bool chase = false;
    public List<GameObject> retreatPoints = new List<GameObject>();

    GameObject furthestPoint;
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {


        if (chase == true)
        {
            agent.SetDestination(target.position);
        }

        if (scared == true)
        {
            chase = false;
            if (furthestPoint == null)
            {
                float dist1 = 0;
                float dist2 = 0;
                foreach (GameObject obj in retreatPoints)
                {
                    //Debug.Log(obj.transform.name);
                    dist1 = Vector3.Distance(transform.position, obj.transform.position);

                    if (dist1 > dist2)
                    {
                        furthestPoint = obj.transform.gameObject;

                        dist2 = dist1;
                    }

                }
                if (furthestPoint == null)
                {
                    return;
                }

                agent.SetDestination(furthestPoint.transform.position);
              
            }

            if (transform.position == furthestPoint.transform.position)
            {
                scared = false;
                chase = true;
                furthestPoint = null;
                // Destroy(gameObject);
            }
        }
    }
}
