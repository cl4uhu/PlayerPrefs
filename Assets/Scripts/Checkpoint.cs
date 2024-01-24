using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Vector3 _userPosition;
    [SerializeField] public Text checkpointText;

    void Start()
    {
        LoadData();
        UpdateCheckpointText();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Checkpoint"))
        {
            PlayerPrefs.SetFloat("positionX", transform.position.x);
            PlayerPrefs.SetFloat("positionZ", transform.position.z);
            PlayerPrefs.SetFloat("positionY", transform.position.y);
            
            LoadData();
            UpdateCheckpointText();
        }
    }

    public void UpdateCheckpointText()
    {
        if(checkpointText != null)
        {
            checkpointText.text = "Last Checkpoint: (" + _userPosition.x + ", " + _userPosition.y + ", " + _userPosition.z + ")";
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
