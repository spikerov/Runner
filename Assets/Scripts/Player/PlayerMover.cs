using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private PlayerAnimation _playerAnimation;
    [SerializeField] private SoundManager _soundManager;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _laneChangeSpeed = 15;

    private Rigidbody _rigidbody;
    private float _laneOffset = 0.8f;
    private float _pointStart;
    private float _pointFinish;
    private bool _chamgingTrack = false;
    private bool isGround = true;
    private Coroutine movingCoroutine;

    private void OnEnable()
    {
        Rock.OnRock += OnDead;
    }

    private void OnDisable()
    {
        Rock.OnRock -= OnDead;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && _pointFinish > -_laneOffset)
        {
            MoveHorizontal(-_laneChangeSpeed);
            _soundManager.PlayChangeTrack();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && _pointFinish < _laneOffset)
        {
            MoveHorizontal(_laneChangeSpeed);
            _soundManager.PlayChangeTrack();
        }

        if (Input.GetKey(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(_rigidbody.position + forwardMove);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            isGround = true;
        }
    }

    public void Jump()
    {
        _rigidbody.velocity = Vector3.up * _jumpForce;
        _playerAnimation.StartJumpAnimation();
    }

    private void MoveHorizontal(float speed)
    {
        _pointStart = _pointFinish;
        _pointFinish +=  Mathf.Sign(speed) * _laneOffset;

        if (_chamgingTrack == true)
        {
            StopCoroutine(movingCoroutine);
            _chamgingTrack = false;
        }

        movingCoroutine = StartCoroutine(MoveCoroutine(speed));
    }

    private void OnDead()
    {
        _playerAnimation.RockCollision();
        _soundManager.PlayCollision();
    }

    IEnumerator MoveCoroutine(float vectorX)
    {
        _chamgingTrack = true;

        while (Mathf.Abs(_pointStart - transform.position.x) < _laneOffset)
        {
            yield return new WaitForFixedUpdate();

            _rigidbody.velocity = new Vector3(vectorX, _rigidbody.velocity.y, 0);
            float x = Mathf.Clamp(transform.position.x, Mathf.Min(_pointStart, _pointFinish), Mathf.Max(_pointStart, _pointFinish));
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        _rigidbody.velocity = Vector3.zero;
        transform.position = new Vector3(_pointFinish, transform.position.y, transform.position.z);
        _chamgingTrack = false;
    }
}
