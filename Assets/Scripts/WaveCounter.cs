using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    Text TextField;
    private void Start()
    {
        TextField = GetComponent<Text>();
    }
    public void CountUpdate(int count)
    {
        TextField.text = count.ToString();
    }
}
