using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionHeathCanvas : MonoBehaviour
{
    [SerializeField] private GameObject minion;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.SetParent(minion.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
