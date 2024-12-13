using UnityEngine;
using UnityEngine.UI;

public class Dealer : MonoBehaviour
{
    public GameObject interactionButton; // Кнопка взаимодействия
    public GameObject shopUI; // UI магазина

    private void Start()
    {
        interactionButton.SetActive(false); // Скрываем кнопку при старте
        shopUI.SetActive(false); // Скрываем магазин при старте
    }

void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
        interactionButton.SetActive(true);
        Debug.Log("Игрок вошел в триггер!");
        // Здесь добавьте логику для взаимодействия с игроком или выполните необходимые действия
    }
}

private void OnTriggerExit2D(Collider2D other)
{
   
    if (other.CompareTag("Player"))
    {
        interactionButton.SetActive(false);
        Debug.Log("Player exited trigger"); //Added log
        
    }
}

private void Update()
{
    if (interactionButton.activeSelf && Input.GetKeyDown(KeyCode.E))
    {
        Debug.Log("E key pressed, opening shop"); //Added log
       shopUI.SetActive(true);
    }
}
}