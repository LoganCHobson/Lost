using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject prefab;
    public float destroyTime = 10f;

    public GameObject spawnedObject;
    PlayerInfo playerInfo;
    MonsterAIMovement monsterAIMovement;

    public float countDown;
    float countDownSet;

    public Transform soundSpawnLocation;

    public List<GameObject> spookSounds = new List<GameObject>();
    private void Start()
    {
        playerInfo = FindObjectOfType<PlayerInfo>();
        monsterAIMovement = FindObjectOfType<MonsterAIMovement>();
    }
    private void Update()
    {
        countDown -= Time.deltaTime;

        if (countDown <= 0)
        {
            Scares();
            countDown = countDownSet;
        }
        FlashLight();

        switch (playerInfo.state)
        {
            case FearState.TIER1:
                countDownSet = 20;
                break;

            case FearState.TIER2:
                countDownSet = 15;
                break;

            case FearState.TIER3:
                countDownSet = 10;
                break;

            case FearState.TIER4:
                countDownSet = 5;
                break;
        }
    }

    void Scares()
    {
        int rand = Random.Range(1, 4);
        switch (rand)
        {
            case 1:
                Debug.Log("Case1");
                TreeScare();
                break;

            case 2:
                Debug.Log("Case2");
                int rand2 = Random.Range(0, spookSounds.Count);
                AudioSource sound = Instantiate(spookSounds[rand2].GetComponent<AudioSource>(), soundSpawnLocation);
                if (sound.isPlaying == false)
                {
                    sound.Play();
                    Destroy(sound.gameObject, sound.clip.length + 1);
                }
                else
                {
                    return;
                }
                break;

            case 3:

                break;
        }

        if (playerInfo.slider.value <= 0)
        {
            monsterAIMovement.chase = true;
        }
    }

    void TreeScare()
    {
        if (spawnedObject == null)
        {
            RaycastHit[] hits = Physics.BoxCastAll(transform.position, Vector3.one * 0.5f, transform.forward, Quaternion.identity, 30f, layerMask);

            if (hits.Length > 0)
            {
                float farthestDistance = 0f;
                RaycastHit farthestHit = hits[0];

                foreach (RaycastHit hit in hits)
                {
                    float distance = Vector3.Distance(transform.position, hit.point);
                    if (distance > farthestDistance)
                    {
                        farthestDistance = distance;
                        farthestHit = hit;
                    }
                }

                spawnedObject = Instantiate(prefab, farthestHit.point + (farthestHit.normal * -1.5f) + Vector3.up * 0.5f, Quaternion.LookRotation(-farthestHit.normal));
                Destroy(spawnedObject, destroyTime);
            }
        }
    }

    void FlashLight()
    {
        bool warding = Physics.Raycast(transform.position, transform.forward, 30f, 8);

        if (warding)
        {
            monsterAIMovement.scared = true;
        }
    }

}