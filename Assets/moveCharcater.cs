using UnityEngine;
using System.Collections;

public class moveCharcater : MonoBehaviour {

	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
	public string horizontalTag = "Horizontal";
	public string verticalTag = "Vertical";
	private Vector3 moveDirection = Vector3.zero;
	void Update() {
		CharacterController controller = GetComponent<CharacterController>();
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis(horizontalTag), 0, Input.GetAxis(verticalTag));
			if (moveDirection != Vector3.zero)
			{
				var rotation = transform.rotation;
				rotation.SetLookRotation(moveDirection);
				transform.rotation = rotation;
			}
			moveDirection *= speed;
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
			
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
