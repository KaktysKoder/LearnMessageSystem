using UnityEngine;

public class MessageSystem : MonoBehaviour
{
    [SerializeField] private GameObject testObject;

    /// <summary>
    /// Выводит на панель экрана сгенерированные числа.
    /// </summary>
    /// <param name="message"></param>
    public void AddNewMessage(string message)
    {
        GameObject newTextObject = Instantiate(testObject, transform);

        newTextObject.GetComponent<TextMessage>().SetText(message);
    }
    
    private void OnGUI()
    {
        // Отрисовывает кнопку генерации чисел.
        if (GUI.Button(new Rect(0, 0, 200, 20), "Generate a new number..."))
        {
            AddNewMessage(Random.Range(int.MinValue, int.MaxValue).ToString());
        }

        // Отрисовывает кнопку очистки экрана.
        if (GUI.Button(new Rect(200, 0, 200, 20), "Clean"))
        {
            Clean();
        }
    }

    /// <summary>
    /// Полностью удаляет все сгенерированные значения на панели.
    /// </summary>
    public void Clean()
    {
        GameObject mainMessage = GameObject.FindWithTag("SpawnMessage");

        if (mainMessage == null)
        {
            Debug.LogError("Установит тег SpawnMessage на объект к которому прикреплён сценарий MessageSystem.");
            Debug.LogError("Аварийное устранение проблемы...");

            mainMessage = GameObject.Find("MessagePanel");

            Debug.LogWarning("Проблема успешно устранена");
        }

        foreach (Transform item in mainMessage.GetComponentInChildren<RectTransform>())
        {
            Destroy(item.GetComponentInChildren<RectTransform>().gameObject);
        }
    }
}