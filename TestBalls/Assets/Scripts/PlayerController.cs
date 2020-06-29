using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed;//швидкіть об'єкта

    [SerializeField]
    private Text _textScore;//відображення рахунку

    private Vector3 _force;//швидкість*напряомок
    private Rigidbody _rb;
    private bool _onFloor, _onCelling, _onGround;//перевірка місцезнаходження об'єкта(підлога, стеля)
    private int _score;//рахунок

    public bool lose;//перевірка на програш

    private void Start()
    {
        _onGround = false;
        _onCelling = false;
        _onFloor = true;
        lose = false;

        _rb = gameObject.GetComponent<Rigidbody>();// ініціалізація 
        _force = Vector3.down * _playerSpeed;// визначення сили 
    }

    void Update()
    {
        StartCoroutine(Moving());//початок руху
        Jump();
    }
    
    private void Jump()//метод зміни вектору руху об'єкта в залежності від його положення та ведення рахунку
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (_onFloor)
            {
                _force = Vector3.down * _playerSpeed;
            }

            if (_onCelling)
            {
                _force = Vector3.up * _playerSpeed;
            }

            if (_onGround)
            {
                _score += 1;
                _textScore.text = "" + _score;//рахунок
            }
        }
    }

    private void Lose()
    {
        lose = true;//якщо об'єкт перетнув блоки
        _textScore.text = "You lose, your score: " + _score;
        Debug.Log("You lose");
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _onGround = true;
        if (collision.gameObject.tag == "floor")//перевірка місцнаходження об'єкта
        {
            _onFloor = false;
            _onCelling = true;
            
        }

        if (collision.gameObject.tag == "celling")
        {
            _onFloor = true;
            _onCelling = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        _onGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Lose();
    }

    IEnumerator Moving()//початок руху об'єкта
    {
        yield return new WaitForSeconds(5.5f);
        _rb.AddForce(_force * Time.deltaTime, ForceMode.Force);
    }
}
