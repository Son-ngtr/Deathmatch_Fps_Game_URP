using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

/*
 * Cơ chế quản lý của game
 * RoomManager -> PlayerManager -> PlayerController
 */

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager instance;

    private void Awake()
    {
        // Kiểm tra nếu có RoomManager khác có tồn tại
        if (instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    // Đăng ký sự kiện OnSceneLoad cho đối tượng RoomManager
    public override void OnEnable()
    {
        base.OnEnable();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        // Kiểm tra Scene hiện tại, trạng thái 1 <-> Game Scene 
        if (scene.buildIndex == 1)
        {
            // Tạo đối tượng Prefabs - PlayerManager trên máy chủ Photon
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);
        }
    }

    void Start()
    {
            
    }

    void Update()
    {

    }
}
