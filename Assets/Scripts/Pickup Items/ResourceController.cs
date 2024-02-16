using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceController : MonoBehaviour
{
    private Vector3 currentPos;
    public bool isBeeingWatched;
    [SerializeField] float currentLife;
    [SerializeField] GameObject dropPrefab;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = GetComponent<Transform>().position;
        currentLife = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if(isBeeingWatched)
        {
            if(Input.GetMouseButtonDown(0))
            {
                StartCoroutine(LoseLife(5f));
            }
        }
    }

    IEnumerator LoseLife(float damage)
    {
        currentLife -= damage;
        if(currentLife <= 0)
        {
            Instantiate(dropPrefab, currentPos, Quaternion.identity);
            Instantiate(dropPrefab, currentPos, Quaternion.identity);
            Instantiate(dropPrefab, currentPos, Quaternion.identity);
            Destroy(this.gameObject);
        }
        yield return null;
    }
}
