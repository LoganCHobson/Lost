using UnityEngine;
using UnityEngine.UI;



public class MonsterBehavior : MonoBehaviour
{
    public float countDown;
    public Slider slider;
    PlayerInfo playerInfo;

    float maxDistance;
    public GameObject treeScareAnim;
    GameObject furthestTree;

    public float flashLightRange = 20;
    public GameObject prefab;

    public Transform location;

    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
    }

    void Update()
    {
        Debug.DrawRay(gameObject.GetComponentInChildren<Transform>().transform.position, gameObject.GetComponentInChildren<Transform>().transform.forward * 30, Color.red);
        Debug.DrawRay(gameObject.transform.position, gameObject.transform.forward * flashLightRange, Color.yellow);
        switch (playerInfo.state)
        {
            case FearState.TIER1:
                countDown = 20;
                break;

            case FearState.TIER2:
                countDown = 15;
                break;

            case FearState.TIER3:
                countDown = 10;
                break;

            case FearState.TIER4:
                countDown = 5;
                break;
        }
        Scares();

        
    }

    public void Scares()
    {
        int rand = Random.Range(3, 3);
       
        switch (rand)
        {
            case 1: //Tree Scare
                RaycastHit[] hit;
                Collider col;
                hit = Physics.BoxCastAll(
                    gameObject.GetComponentInChildren<Transform>().transform.position,
                    gameObject.GetComponentInChildren<Transform>().transform.position,
                    transform.forward,
                    Quaternion.identity,
                    30f, ~127);
               
                
                if(hit != null && furthestTree == null)
                {
                    float dist1 = 0;
                    float dist2 = 0;
                    foreach(RaycastHit obj in hit)
                    {
                        //Debug.Log(obj.transform.name);
                         dist1 = Vector3.Distance(transform.position, obj.transform.position);

                        if(dist1 > dist2)
                        {
                            furthestTree = obj.transform.gameObject;
                           
                            dist2 = dist1;
                        }
                       
                    }
                    if(furthestTree == null)
                    {
                        return;
                    }
                    else
                    {
                        Debug.Log("Furthest tree = " + furthestTree.name);
                        Vector3 spawnPosition = furthestTree.transform.position - furthestTree.transform.forward * 2;
                        Quaternion spawnRotation = Quaternion.LookRotation(transform.position - spawnPosition, Vector3.up);
                        GameObject temp = Instantiate(treeScareAnim, spawnPosition, spawnRotation);
                        temp.transform.LookAt(playerInfo.gameObject.transform);
                    }
                    
                    
                    
                }
                break;
                
            case 2:
                RaycastHit flashlightHit;

                Physics.Raycast(gameObject.transform.position, transform.forward, out flashlightHit, flashLightRange);
                Debug.Log(flashlightHit);
                if (flashlightHit.transform.gameObject.CompareTag("Enemy"))
                {
                    flashlightHit.transform.GetComponent<MonsterAIMovement>().scared = true;
                }
                else
                {
                    return;
                }
                break;

            case 3:
                GameObject audio = Instantiate(prefab, location);
                audio.GetComponent<AudioSource>().Play();

                

                break;

            case 4:

                break;

            case 5:

                break;

            case 6:

                break;

            case 7:

                break;

        }

    }


}
