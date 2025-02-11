using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text infoText;
    public Image KeyIcon;
    public bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasKey)
        {
            KeyIcon.enabled = true;
        
        }
        else
        {
            KeyIcon.enabled = false;
        }
    }
}
