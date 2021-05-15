using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject arSessionOrigin;
    [SerializeField]
    private Button battleButton;
    private ImageTracking imageTracking;
    private  GameObject human, monster;
    public  bool inBattle = false;
    public float battleTime = 5;
    public float seconds = 0;
    // Start is called before the first frame update
    void Start()
    {
        imageTracking = arSessionOrigin.GetComponent<ImageTracking>();
        battleButton.onClick.AddListener(StartBattle);
    }

    // Update is called once per frame
    void Update()
    {
        if(inBattle)
        {
            human.transform.LookAt(monster.transform);
            monster.transform.LookAt(human.transform);
        }
    }

    void StartBattle()
    {
        battleButton.interactable = false;
        Debug.Log("Battle");
        StartCoroutine(Battle(imageTracking.getPlayerCharacter()));
    }

    IEnumerator Battle(GameObject playerCharacter)
    {
        float timer = 0;
        inBattle = true;
        while(timer < battleTime)
        {
            timer += Time.deltaTime;
            seconds = timer;
            playerCharacter.GetComponent<Animator>().SetTrigger("Attack");
            monster.GetComponent<Animator>().SetTrigger("Attack");
            yield return null;
        }
        inBattle = false;
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Monster")
        {
            human = imageTracking.getPlayerCharacter();
            monster = other.gameObject;
            battleButton.interactable = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        battleButton.interactable = false;
    }
}