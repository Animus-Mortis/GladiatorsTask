using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [SerializeField] Collider2D[] collidersObjectOnTable;
    [SerializeField] GameObject[] inventoryObject;
    [SerializeField] GameObject textOrObject;
    [SerializeField] GameObject buttonAction;

    Text textNameObject;
    Text buttonText;

    public bool viewTable;
    public string nameObject;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        textNameObject = textOrObject.GetComponent<Text>();
        buttonText = buttonAction.GetComponentInChildren<Text>();
    }
    private void Update()
    {
        if (viewTable)
        {
            for(int i = 0; i < collidersObjectOnTable.Length; i++)
            {
                collidersObjectOnTable[i].enabled = true;
            }
        }
        else
        {
            for (int i = 0; i < collidersObjectOnTable.Length; i++)
            {
                collidersObjectOnTable[i].enabled = false;
                ActiveObject(false);
            }
        }
        if(nameObject == "Book")
        {
            ActiveObject(true);
            textNameObject.text = "Книга";
            buttonText.text = "Взять книгу";
            buttonAction.GetComponent<Button>().onClick.AddListener(() => TakeObject(0));
        }
        else if(nameObject == "Amulet")
        {
            ActiveObject(true);
            textNameObject.text = "Амулет";
            buttonText.text = "Взять амулет";
            buttonAction.GetComponent<Button>().onClick.AddListener(() => TakeObject(1));
        }
        else if (nameObject == "Coins")
        {
            ActiveObject(true);
            textNameObject.text = "33 монеты";
            buttonText.text = "Взять 33 монеты";
            buttonAction.GetComponent<Button>().onClick.AddListener(() => TakeObject(2));
        }
    }
    void ActiveObject(bool active)
    {
        textOrObject.SetActive(active);
        buttonAction.SetActive(active);
    }
    void TakeObject(int number)
    {
        collidersObjectOnTable[number].gameObject.SetActive(false);
        inventoryObject[number].SetActive(true);
    }
}
