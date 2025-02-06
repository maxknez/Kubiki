using UnityEngine;

public class MaksCameraController : MonoBehaviour
{
    [Header("Base Settings")]
    [SerializeField] private float sensitivity = 0.1f; // Чувствительность (скорость * расстояние)
    [SerializeField] private float deadZoneRadius = 50f; // Зона вокруг центра без движения
    
    [Header("Movement Boundaries")]
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;

    [Header("Collision Settings")]

    private Vector3 _screenCenter;

    private void Start()
    {
        // Запоминаем центр экрана
        _screenCenter = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
    }

    private void Update()
    {
        HandleCameraMovement();
    }

    private void HandleCameraMovement()
    {
        Vector3 mousePosition = Input.mousePosition;
        
        // Рассчитываем вектор от центра экрана к курсору
        Vector3 direction = mousePosition - _screenCenter;
        
        // Игнорируем движение в зоне мертвой зоны
        if (direction.magnitude < deadZoneRadius) return;

        // Нормализуем вектор направления
        direction.Normalize();

        // Рассчитываем силу движения на основе расстояния
        float distanceFromCenter = Vector3.Distance(mousePosition, _screenCenter);
        float speed = (distanceFromCenter - deadZoneRadius) * sensitivity;

        // Вычисляем новую позицию
        Vector3 newPosition = transform.position + 
                             new Vector3(
                                 direction.x * speed * Time.deltaTime,
                                 direction.y * speed * Time.deltaTime,
                                 0
                                 );

        // Ограничиваем позицию границами
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }
}