using UnityEngine;
/// <summary>
/// 控制模型缩放旋转
/// 目前只实现角色Y轴旋转
/// 需要其他功能可以继续扩展
/// </summary>
public class UIModelContrl : MonoBehaviour
{
    /// <summary>
    /// 水平向左还是向右
    /// </summary>
    private float delat = 0;
    /// <summary>
    /// 旋转速度
    /// </summary>
    public float rotSpeed = 45f;
    /// <summary>
    /// 检测是否可以拖动对象
    /// </summary>
    private bool canDrag = false;
    /// <summary>
    /// 获取UI摄像机
    /// </summary>
    private Camera uiCamera;
    /// <summary>
    /// 注意：默认查找子级
    /// </summary>
    private GameObject targetGo;

    private void Awake()
    {
#if UNITY_EDITOR
        rotSpeed = 180f;
#endif
        //uiCamera = Com.Main.AppFacade.instance.CameraMgr.uiCamera.camera;
    }

    void Update()
    {
        if (uiCamera == null)
        {
            return;
        }

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            StartDragModel(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndDragModel();
        }
#else
        if (Input.touches == null)
        {
            return;
        }
        if (Input.touches.Length > 0)
        {
            StartDragModel(Input.touches[0].position);
        }
        if (Input.touches.Length == 0)
        {
            EndDragModel();
        }
#endif
        if (canDrag)
        {
            DragRotationModel();
        }
    }
    /// <summary>
    /// 开始拖动
    /// </summary>
    /// <param name="screenPos"></param>
    private void StartDragModel(Vector3 screenPos)
    {
        Ray ray = uiCamera.ScreenPointToRay(screenPos);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                canDrag = true;
            }
        }
    }
    /// <summary>
    /// 检测并旋转模型
    /// </summary>
    private void DragRotationModel()
    {
        if (targetGo == null)
        {
            if (transform.childCount > 0)
            {
                targetGo = transform.GetChild(0).gameObject;
            }
        }
        if (targetGo != null)
        {
#if UNITY_EDITOR
            delat = Input.GetAxis("Mouse X");
#else
            delat = Input.touches[0].deltaPosition.x;
#endif
            targetGo.transform.Rotate(Vector3.up, -Time.deltaTime * delat * rotSpeed, Space.World);
        }
    }
    /// <summary>
    /// 结束拖动
    /// </summary>
    private void EndDragModel()
    {
        canDrag = false;
        targetGo = null;
    }
}
