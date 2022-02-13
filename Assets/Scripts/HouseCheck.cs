using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCheck : MonoBehaviour
{
    private int animalCount = 0;
    public GameObject clearPanel;
    public AudioSource clearBgm;
    void Update()
    {
        if (animalCount >= 5)
        {
            clearPanel.SetActive(true);
            clearBgm.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Animal")
        {
            animalCount++;
            Debug.Log(animalCount);
        }
    }
}
