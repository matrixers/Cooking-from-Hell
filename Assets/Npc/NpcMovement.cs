using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SocialPlatforms.GameCenter;

public class NpcMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public float radius; //radius of sphere

    public Transform centrePoint; //area npc wants to move in


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 point;
            if(RandomNavmeshLocation(centrePoint.position, radius, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1f);
                agent.SetDestination(point);
            }
        }

    }
    bool RandomNavmeshLocation(Vector3 center, float radius, out Vector3 result)
    {
        Vector3 randomPoint = center +  Random.insideUnitSphere * radius;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, radius, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }
        result = Vector3.zero;
        return false;
    }
}
