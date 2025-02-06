using UnityEngine;

public class CubeShooter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject bulletPrefab; // Префаб пули
    [SerializeField] private float shootInterval = 1f; // Периодичность стрельбы
    [SerializeField] private float randomizerRange = 0.2f; // Диапазон рандомизации

    private float _nextShootTime; // Время следующего выстрела

    private void Start()
    {
        // Устанавливаем время первого выстрела
        _nextShootTime = Time.time + GetRandomizedInterval();
    }

    private void Update()
    {
        // Проверяем, настало ли время для выстрела
        if (Time.time >= _nextShootTime)
        {
            Shoot();
            _nextShootTime = Time.time + GetRandomizedInterval();
        }
    }

    private void Shoot()
    {
        // Создаем пулю
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Направляем пулю по оси Z
        bullet.GetComponent<CubeBullet>().Initialize(Vector3.back);
    }

    private float GetRandomizedInterval()
    {
        // Возвращаем интервал с учетом рандомизации
        return shootInterval + Random.Range(-randomizerRange, randomizerRange);
    }
}