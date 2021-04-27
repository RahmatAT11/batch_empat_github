using UnityEngine;

public class Tower : MonoBehaviour
{
    // Tower Component
    [SerializeField] private SpriteRenderer _towerPlace;
    [SerializeField] private SpriteRenderer _towerHead;

    // Tower Properties
    [SerializeField] private int _shootPower = 1;
    [SerializeField] private float _shootDistance = 1f;
    [SerializeField] private float _shootDelay = 5f;
    [SerializeField] private float _bulletSpeed = 1f;
    [SerializeField] private float _bulletSplashRadius = 0f;

    // Digunakan untuk menyimpan posisi yang akan ditempati selama tower di drag
    public Vector2? PlacePosition { get; private set; }

    public void SetPlacePosition(Vector2? newPosition)
    {
        PlacePosition = newPosition;
    }

    public void LockPlacement()
    {
        transform.position = (Vector2) PlacePosition;
    }

    // Mengubah order in layer pada tower yang sedang di drag
    public void ToggleOrderInLayer(bool toFront)
    {
        int orderInLayer = toFront ? 2 : 0;
        _towerPlace.sortingOrder = orderInLayer;
        _towerHead.sortingOrder = orderInLayer;
    }

    // Fungsi yang digunakan untuk mengambil sprite pada Tower Head
    public Sprite GetTowerHeadIcon()
    {
        return _towerHead.sprite;
    }
}
