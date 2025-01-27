using UnityEngine;
using TMPro; 

public class TriggerTextDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        // Изначально скрываем текст
        textMeshProUGUI.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Проверяем, если объект с тегом "Player" входит в триггер
        if (other.CompareTag("Player"))
        {
            textMeshProUGUI.gameObject.SetActive(true); // Показываем текст
        }
    }
    
}
