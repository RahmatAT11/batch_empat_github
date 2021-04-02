using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Tombol untuk bergerak ke atas
    public KeyCode upButton = KeyCode.W;

    // Tombol untuk bergerak ke bawah
    public KeyCode downButton = KeyCode.S;

    // Kecepatan gerak
    public float speed = 10.0f;

    // Batas atas dan batas bawah game scene (Batas bawah menggunakan minus (-))
    public float yBoundary = 9.0f;

    // Rigidbody 2D raket ini
    public Rigidbody2D rigidbody2D;

    // Skor pemain
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Dapatkan kecepatan raket sekarang.
        Vector2 velocity = rigidbody2D.velocity;

        // Jika pemain menekan tombol ke atas, maka beri kecepatan positif ke komponen y (ke atas).
        if (Input.GetKey(upButton))
        {
            velocity.y = speed;
        }

        // Jika pemain menekan tombol ke bawah, maka beri kecepatan negatif ke komponen y (ke bawah).
        else if (Input.GetKey(downButton))
        {
            velocity.y = -speed;
        }

        // Jike pemain tidak menekan tombol apa-apa, kecepatannya nol.
        else
        {
            velocity.y = 0.0f;
        }

        // Masukkan kembali kecepatan ke rigidbody2D
        rigidbody2D.velocity = velocity;

        // Dapatkan posisi raket sekarang
        Vector3 position = transform.position;

        // Jika posisi raket melewati batas atas (yBoundary), kembalikan ke batas atas tersebut.
        if (position.y > yBoundary)
        {
            position.y = yBoundary;
        }

        // Jika posisi raket melewati batas bawah (-yBounday), kembalikan ke batas bawah tersebut.
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        // Masukkan kembali posisinya ke transform
        transform.position = position;
    }

    // Menaikkan score sebanyak 1 poin
    public void IncrementScore()
    {
        score++;
    }

    // Mengembalikan score menjadi 0
    public void ResetScore()
    {
        score = 0;
    }

    // Mendapatkan nilai score
    public int Score
    {
        get { return score; }
    }
}
