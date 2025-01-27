using UnityEngine;
using UnityEngine.UI; // Для работы с UI

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI; // Ссылка на панель меню паузы
    [SerializeField] private Button _continueButton; // Кнопка продолжить
    [SerializeField] private Button _exitButton; // Кнопка выйти из игры

    private bool _isPaused = false; // Флаг паузы

    private void Start()
    {
        // Прикрепляем обработчики к кнопкам
        _continueButton.onClick.AddListener(ContinueGame);
        _exitButton.onClick.AddListener(ExitGame);

        // Скрыть меню паузы в начале
        _pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        // Проверка нажатия паузы (например, через клавишу ESC)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
                ContinueGame();
            else
                PauseGame();
        }
    }

    private void PauseGame()
    {
        _isPaused = true;
        Time.timeScale = 0f; // Останавливаем игру
        _pauseMenuUI.SetActive(true); // Показываем меню
    }

    private void ContinueGame()
    {
        _isPaused = false;
        Time.timeScale = 1f; // Возвращаем нормальную скорость игры
        _pauseMenuUI.SetActive(false); // Скрываем меню
    }

    private void ExitGame()
    {
       Application.Quit();
    }
}
