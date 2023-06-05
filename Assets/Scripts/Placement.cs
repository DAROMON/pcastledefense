using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public GameObject Tower;
    public GameObject BuyMenuOverlay;
    public BuyMenu BuyMenu;
    int lvl = 0;
    Tower twr;

    private void Start()
    {
        twr = Tower.GetComponent<Tower>();
    }
    void OnMouseDown()
    {
        BuyMenuOverlay.SetActive(true);
        BuyMenu.SetPlacement(this, lvl);
        
        
        //Tower.SetActive(true);
    }
    public void Build()
    {
        GetComponent<MeshRenderer>().enabled = false;
        Tower.SetActive(true);
        lvl++;
        BuyMenuOverlay.SetActive(false);
    }
    public void Upgrade()
    {
        twr.UpdateParametres(lvl);
        lvl++;
        BuyMenuOverlay.SetActive(false);
    }
}
