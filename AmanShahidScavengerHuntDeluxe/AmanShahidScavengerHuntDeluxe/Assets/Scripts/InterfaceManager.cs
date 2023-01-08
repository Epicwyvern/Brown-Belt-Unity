using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public Image seekImage;
    public Image collectible;
    public GameObject showSprite;
    public GameObject npc;
    public GameObject randomSpawn;
    [SerializeField]
    private Sprite[] collectibleSource;
    public bool dialogActive;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        showSprite.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive) {
            if (Input.GetButton("Submit")) {
                dialogBox.SetActive(false);
                dialogActive = false;
                if (npc.GetComponent<DialogOpen>().end == true) {
                    SceneManager.LoadScene(0);
                }
            }
        }
    }

    public void ShowBox(string dialog, int item)
    {
        dialogBox.SetActive(true);
        dialogActive = true;
        dialogText.text = dialog;
        seekImage.GetComponent<Image>().sprite = collectibleSource[item];
        if (npc.GetComponent<DialogOpen>().begin == true)
        {
            randomSpawn.GetComponent<RandomSpawn>().DistributeCollectibles();
            npc.GetComponent<DialogOpen>().begin = false;

        }
    }
    public void CollectibleUpdate(int item)
    {
        showSprite.SetActive(true);
        collectible.GetComponent<Image>().sprite = collectibleSource[item];
    }
}
