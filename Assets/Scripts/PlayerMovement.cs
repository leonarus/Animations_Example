using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private Animator _animator;

    // Массив с названиями анимаций атаки
    private string[] _attackAnimations = { "AttackWithJump", "Kick" };

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0f, moveVertical);
        transform.Translate(movement * (_moveSpeed * Time.deltaTime), Space.Self);

        // Анимации движения
        _animator.SetFloat("MoveX", moveHorizontal);
        _animator.SetFloat("MoveZ", moveVertical);

        if (Input.GetMouseButtonDown(0))
        {
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        // Получаем случайную анимацию атаки из массива
        string randomAttackAnimation = _attackAnimations[Random.Range(0, _attackAnimations.Length)];

        // Воспроизводим анимацию атаки
        _animator.SetTrigger(randomAttackAnimation);
    }
}