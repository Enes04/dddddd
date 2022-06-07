using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class enemysc : MonoBehaviour
{
    public GameObject pref;
    GameObject currentmi;
    public GameObject pl;
    bool mızrakBool;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        if (mızrakBool && timer >1)
        {
            timer = 0;
            currentmi = Instantiate(pref);
            currentmi.transform.position = transform.position;
            currentmi.transform.DOJump(pl.transform.position+new Vector3(0,0,15f), 2, 1, 2, false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            mızrakBool = true;
        }
    }
}
