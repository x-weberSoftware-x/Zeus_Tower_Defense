using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour 
{
    public static int souls;
    public int startSouls = 500;
    public Text soulsText;

    private void Start()
    {
        souls = startSouls;
        soulsText.text = souls.ToString();
    }

    private void Update()
    {
        soulsText.text = souls.ToString();
    }
}
