using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Announcement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI announcement;
    [SerializeField] SpawnEnemy se;

    // Update is called once per frame
    void Start()
    {
        announcement.text = "Enemies will spawn in " + se.GetSpawnTime() + " seconds";
        Invoke("DisableText", 5f);
    }

    void DisableText()
    {
        announcement.enabled = false;
    }
}
