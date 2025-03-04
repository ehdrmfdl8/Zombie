﻿using UnityEngine;

// 플레이어 캐릭터를 조작하기 위한 사용자 입력을 감지
// 감지된 입력값을 다른 컴포넌트들이 사용할 수 있도록 제공
public class PlayerInput : MonoBehaviour {
    public string z_moveAxisName = "Vertical"; // 앞뒤 움직임을 위한 입력축 이름
    public string x_moveAxisName = "Horizontal"; // 좌우 움직임을 위한 입력축 이름
    public string fireButtonName = "Fire1"; // 발사를 위한 입력 버튼 이름
    public string reloadButtonName = "Reload"; // 재장전을 위한 입력 버튼 이름

    // 값 할당은 내부에서만 가능
    public float z_move { get; private set; } // 감지된 위아래 움직임 입력값
    public float x_move { get; private set; } // 감지된 좌우 움직임 입력값
    public bool fire { get; private set; } // 감지된 발사 입력값
    public bool reload { get; private set; } // 감지된 재장전 입력값

    // 매프레임 사용자 입력을 감지
    private void Update() {
        // 게임오버 상태에서는 사용자 입력을 감지하지 않는다
        if (GameManager.instance != null
            && GameManager.instance.isGameover)
        {
            z_move = 0;
            x_move = 0;
            fire = false;
            reload = false;
            return;
        }

        // z_move에 관한 입력 감지
        z_move = Input.GetAxisRaw(z_moveAxisName);
        // x_move에 관한 입력 감지
        x_move = Input.GetAxisRaw(x_moveAxisName);
        // fire에 관한 입력 감지
        fire = Input.GetButton(fireButtonName);
        // reload에 관한 입력 감지
        reload = Input.GetButtonDown(reloadButtonName);
    }
}