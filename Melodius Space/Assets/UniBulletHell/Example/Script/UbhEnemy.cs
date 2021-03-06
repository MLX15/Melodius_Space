using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(UbhSpaceship))]
public class UbhEnemy : UbhMonoBehaviour
{
    public const string NAME_PLAYER = "Player";
    public const string NAME_PLAYER_BULLET = "PlayerBullet";
    const string ANIM_DAMAGE_TRIGGER = "Damage";
    [SerializeField]
    public int _Hp = 1;
    [SerializeField]
    int _Point = 100;
    [SerializeField]
    bool _UseStop = false;
    [SerializeField]
    float _StopPoint = 2f;
    UbhSpaceship _Spaceship;
    public Slider healthSlider;  

    float _currentHp;  

    void Start ()
    {
        _Spaceship = GetComponent<UbhSpaceship>();
        Move(transform.up.normalized * -1);
        _currentHp = _Hp;
        healthSlider.value = _currentHp;
        healthSlider.maxValue = _Hp;
    }

    void FixedUpdate ()
    {
        if (_UseStop) {
            if (transform.position.y < _StopPoint) {
                rigidbody2D.velocity = Vector2.zero;
                _UseStop = false;
            }
        }
    }


    public void Move (Vector2 direction)
    {
        rigidbody2D.velocity = direction * _Spaceship._Speed;
    }

    public void OnTriggerEnter2D (Collider2D c)
    {
        // *It is compared with name in order to separate as Asset from project settings.
        //  However, it is recommended to use Layer or Tag.
        if (c.name.Contains(NAME_PLAYER_BULLET)) {
            UbhSimpleBullet bullet = c.transform.parent.GetComponent<UbhSimpleBullet>();

            UbhObjectPool.Instance.ReleaseGameObject(c.transform.parent.gameObject);

            CurrentHp = CurrentHp - bullet._Power;

            if (CurrentHp <= 0) {
                FindObjectOfType<UbhScore>().AddPoint(_Point);

                _Spaceship.Explosion();

                Destroy(gameObject);
            } else {
                _Spaceship.GetAnimator().SetTrigger(ANIM_DAMAGE_TRIGGER);
            }
        }
    }

    void Update() {
        healthSlider.value = _currentHp;
        CurrentHp = _currentHp;
    }

    public float CurrentHp {
        get {return _currentHp;}
        set {_currentHp = value;}
    }
}