using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KKT_Test
{
    /// <summary>
    /// Movement �׽�Ʈ������ ������ Ŭ�����Դϴ�.
    /// Controller �����Ͻô� �в��� Movement ȣ����� �޼�Ʈ ���� �����ø�
    /// �ش� ������ �����ϼŵ� �˴ϴ�.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public PlayerMovement _movement;
        public PlayerStatus _status;
        private void Update()
        {
            MoveTest();

            // IsAiming ����� �׽�Ʈ �ڵ�
            _status.IsAiming.Value = Input.GetKey(KeyCode.Mouse1);
        }
        /// <summary>
        /// �Ʒ� �޼��忡 ���� �ҽ��ڵ�� ���� ������� ����մϴ�.
        /// </summary>
       public void MoveTest()
        {
            // (ȸ�� ���� ��)�¿� ȸ���� ���� ���� ��ȯ
            Vector3 camRotateDir = _movement.SetAimRotation();

            float moveSpeed;
            if (_status.IsAiming.Value) moveSpeed = _status.WalkSpeed;
            else moveSpeed = _status.RunSpeed;

            _movement.SetMove(moveSpeed);

            Vector3 moveDir = _movement.SetMove(moveSpeed);
            _status.IsMoving.Value = (moveDir != Vector3.zero);

            // ��ü�� ȸ��
            Vector3 avatarDir;
            if (_status.IsAiming.Value) avatarDir = camRotateDir;
            else avatarDir = moveDir;

            _movement.SetAvatarRotation(avatarDir);
        }
    }
}
