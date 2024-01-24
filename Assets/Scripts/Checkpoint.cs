using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Vector3 _userPosition;

    void Start()
    {
        LoadData();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Checkpoint"))
        {
            PlayerPrefs.SetFloat("positionX", transform.position.x);
            PlayerPrefs.SetFloat("positionZ", transform.position.z);
            PlayerPrefs.SetFloat("positionY", transform.position.y);
        }
    }

    public void LoadData()
    {
        {
            float x = PlayerPrefs.GetFloat("positionX", 0f);
            float z = PlayerPrefs.GetFloat("positionZ", 0f);
            float y = PlayerPrefs.GetFloat("positionY", 1f);
            _userPosition = new Vector3(x,y,z);

            transform.position = _userPosition;
        }
    }
}
