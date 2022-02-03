using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 3)
        {
            winPanel.SetActive(true);
        }
    }
}
