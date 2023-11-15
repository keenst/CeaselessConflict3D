using System.Collections.Generic;
using UnityEngine;

public class TorchSpawner : MonoBehaviour
{
    public List<Transform> torchLocations;
    public GameObject torch;
    
    public void PlaceTorch()
    {
        if (torchLocations.Count < 1)
        {
            Invoke(nameof(Test), 5);
            return;
        }

        int index = Random.Range(0, torchLocations.Count - 1);
        GameObject clone = Instantiate(torch);
        clone.transform.position = torchLocations[index].position;
    }

    private void Test()
    {
        Debug.Log(gameObject.name);
        Debug.Log(transform.childCount);
    }
}
