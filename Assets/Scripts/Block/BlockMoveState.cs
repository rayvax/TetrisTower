
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class BlockMoveState : State
{
    [SerializeField] private float _fallingSpeed;
    [SerializeField] private float _fallingSpeedBoostMultiplier;
    [SerializeField] private float _fallingMassMultiplier;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _moveStepX;
    [Space]
    [SerializeField] private AudioClip[] _onRotateSound;
    [SerializeField] [Range(0, 1)] private float _onRotateSoundVolume = 1;

    private float _destinationX;
    private Rigidbody2D _rigidbody2D;
    private float _defaultGravityScale;
    private float _defaultMass;
    private Coroutine _horizontalMoveCoroutine;
    private Coroutine _moveToDestinationXCoroutine;
    private float _horizontalMovement;

    private const float EPSILON = 0.01f;

    private void OnValidate()
    {
        if (_fallingMassMultiplier <= 0)
            _fallingMassMultiplier = 1;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        PlayerInput.Player.MoveHorizontally.started += OnHorizontalMoveStarted;
        PlayerInput.Player.MoveHorizontally.performed += OnHorizontalMoveEnded;
        PlayerInput.Player.Rotate.performed += OnRotate;
        PlayerInput.Player.BoostFalling.started += OnBoostStarted;
        PlayerInput.Player.BoostFalling.performed += OnBoostEnded;

        _defaultGravityScale = _rigidbody2D.gravityScale;
        _rigidbody2D.gravityScale = 0;
        _defaultMass = _rigidbody2D.mass;
        _rigidbody2D.mass = _defaultMass * _fallingMassMultiplier;
    }

    private void OnDisable()
    {
        PlayerInput.Player.MoveHorizontally.started -= OnHorizontalMoveStarted;
        PlayerInput.Player.MoveHorizontally.performed -= OnHorizontalMoveEnded;
        PlayerInput.Player.Rotate.performed -= OnRotate;
        PlayerInput.Player.BoostFalling.started -= OnBoostStarted;
        PlayerInput.Player.BoostFalling.performed -= OnBoostEnded;

        _rigidbody2D.gravityScale = _defaultGravityScale;
        _rigidbody2D.mass = _defaultMass;


        TryKillCoroutine(ref _horizontalMoveCoroutine);
        TryKillCoroutine(ref _moveToDestinationXCoroutine);
    }

    private void FixedUpdate()
    {
        MoveVertically();
    }

    private void MoveVertically()
    {
        if (Mathf.Abs(_horizontalMovement) > 0)
            return;

        var deltaVerticalMove = Vector2.down * _fallingSpeed * Time.fixedDeltaTime;
        _rigidbody2D.MovePosition(_rigidbody2D.position + deltaVerticalMove);
    }

    private void OnHorizontalMoveStarted(InputAction.CallbackContext moveContext)
    {
        TryKillCoroutine(ref _horizontalMoveCoroutine);
        TryKillCoroutine(ref _moveToDestinationXCoroutine);

        _horizontalMovement = moveContext.action.ReadValue<float>();
        bool movingRight = _horizontalMovement > 0;

        _horizontalMoveCoroutine = StartCoroutine(MoveHorizontally(moveContext, movingRight));
    }

    private void OnHorizontalMoveEnded(InputAction.CallbackContext moveContext)
    {
        _destinationX = transform.position.x;

        if (_horizontalMovement > 0)
            _destinationX += _moveStepX;
        else
            _destinationX -= _moveStepX;

        _destinationX -= _destinationX % _moveStepX;


        _moveToDestinationXCoroutine = StartCoroutine(MoveToDestinationX(_destinationX));
    }

    private IEnumerator MoveHorizontally(InputAction.CallbackContext moveContext, bool moveRight)
    {
        Vector2 moveDirection = moveRight ? Vector3.right : Vector3.left;
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        Vector2 deltaHorizontalMove, deltaFallingMove;

        while (_moveToDestinationXCoroutine == null)
        {
            deltaHorizontalMove = moveDirection * _horizontalSpeed * Time.fixedDeltaTime;
            deltaFallingMove = Vector2.down * _fallingSpeed * Time.fixedDeltaTime;
            _rigidbody2D.MovePosition(_rigidbody2D.position + deltaHorizontalMove + deltaFallingMove);

            yield return waitForFixedUpdate;
        }
    }

    private IEnumerator MoveToDestinationX(float destinationX)
    {
        WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
        float deltaX;
        Vector2 deltaHorizontalMove, deltaVerticalMove;

        var horizontalMoveDirectionVector = destinationX > transform.position.x ? Vector2.right : Vector2.left;
        int horizontalMoveDirection = (int)horizontalMoveDirectionVector.x;
        do
        {
            deltaX = destinationX - transform.position.x;
            deltaHorizontalMove = horizontalMoveDirectionVector * _horizontalSpeed * Time.fixedDeltaTime;
            deltaVerticalMove = Vector2.down * _fallingSpeed * Time.fixedDeltaTime;
            _rigidbody2D.MovePosition(_rigidbody2D.position + deltaHorizontalMove + deltaVerticalMove);

            yield return waitForFixedUpdate;
        } while (deltaX * horizontalMoveDirection > EPSILON);

        transform.position = new Vector3(destinationX, transform.position.y, transform.position.z);
        _horizontalMovement = 0;
    }

    private bool TryKillCoroutine(ref Coroutine targetCoroutine)
    {
        if(targetCoroutine != null)
        {
            StopCoroutine(targetCoroutine);
            targetCoroutine = null;
            return true;
        }

        return false;
    }

    private void OnRotate(InputAction.CallbackContext context)
    {
        transform.Rotate(new Vector3(0, 0, 90));
        PlayOnRotateSFX();
    }

    private void PlayOnRotateSFX()
    {
        int clipIndex = Random.Range(0, _onRotateSound.Length);
        AudioSource.PlayClipAtPoint(_onRotateSound[clipIndex], transform.position, _onRotateSoundVolume);
    }

    private void OnBoostStarted(InputAction.CallbackContext context)
    {
        _fallingSpeed *= _fallingSpeedBoostMultiplier;
    }

    private void OnBoostEnded(InputAction.CallbackContext context)
    {
        _fallingSpeed /= _fallingSpeedBoostMultiplier;
    }
}
