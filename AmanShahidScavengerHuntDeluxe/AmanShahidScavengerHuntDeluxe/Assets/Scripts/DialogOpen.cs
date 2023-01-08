using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpen : MonoBehaviour
{

    public string dialog;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    private string[] collectibles;
    private int clue;
    private AudioSource greeting;
    public bool begin = true;
    public bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "key", "fish", "birdhouse", "red airhorn", "magic hat"};
        createClue();
        begin = true;
    }

    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialog();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        greeting.Play(0);
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        interfaceManager.GetComponent<InterfaceManager>().ShowBox(dialog, clue);
    }

    public void searchDialog() {
        dialog = "Hi! Can you help me find my " + collectibles[clue] + "?";
        begin = false;
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            if (collectibles[clue] == "film") {
                dialog = "You found my film! Now I can take pictures!";
            } else if (collectibles[clue] == "balloons") {
                dialog = "I've been looking for my balloons!";
            } else {
                dialog = "You found my " + collectibles[clue] + "! Hooray!";
            }
            
            end = true;
        }
        else
        {
            dialog = "No, that's not my " + collectibles[clue] + ".";
        }
    }
}
