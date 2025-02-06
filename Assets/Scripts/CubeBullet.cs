using UnityEngine;

public class CubeBullet : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 10f; // Скорость пули
    [SerializeField] private float destroyZPosition = -10f; // Позиция по Z, при которой пуля уничтожается

    private Vector3 _direction; // Направление движения пули

    public void Initialize(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private void Update()
    {
        // Двигаем пулю
        transform.Translate(_direction * speed * Time.deltaTime);

        // Проверяем, достигла ли пуля позиции для уничтожения
        if (transform.position.z <= destroyZPosition)
        {
            Destroy(gameObject);
        }
    }
}