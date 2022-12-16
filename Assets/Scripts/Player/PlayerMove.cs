using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CleanCity
{
	public class PlayerMove : MonoBehaviour
	{
		private Rigidbody rb;
		private IPlayerStatusManager statusManager;

		private void Start()
		{
			rb = GetComponent<Rigidbody>();
			statusManager = GetComponent<IPlayerStatusManager>();
		}

		private void Update()
		{
			MouseMove();
			KeyInputMove();
		}

		//移動
		public void Move(Vector3 dir)
		{
			dir = new Vector3(dir.x, 0, dir.z);
			rb.velocity = dir * statusManager.BaseSpeed;
			transform.rotation = Quaternion.LookRotation(dir);
		}

		//マウス移動
		private void MouseMove()
		{
			if (Input.GetMouseButton(0))
			{
				//カメラから見たマウスの位置と現在位置から方向を算出
				var distance = Vector3.Distance(transform.position, Camera.main.transform.position);
				Vector3 cameraPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
				Vector3 dir = (cameraPos - transform.position).normalized;
				Move(dir);
			}
		}

		//キーボード移動
		private void KeyInputMove()
		{
			Vector3 dir = Vector2.zero;
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
			{
				dir += Vector3.forward;
			}
			if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
			{
				dir += Vector3.back;
			}
			if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				dir += Vector3.left;
			}
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
			{
				dir += Vector3.right;
			}
			if(dir != Vector3.zero) Move(dir.normalized);
		}
	}
}

