using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

public class TakeItem : MonoBehaviour
{
    [SerializeField] private float _distanse = 6f;
    [SerializeField] private Transform _itemPos;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private LayerMask _layerMask;
    private Rigidbody _rb;
    private bool _itemIsGeted;

    private Transform _item;

    [SerializeField] private GameObject _infoItem, _dropItem;

     void Update()
    {
        bool itemHit;
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit, _distanse, _layerMask))
        {
            _infoItem.SetActive(true);
            itemHit = true;
        }
        else
        {
            _infoItem.SetActive(false);
            itemHit = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!_itemIsGeted && itemHit)
            {
                if (hit.transform.TryGetComponent<Rigidbody>(out _rb))
                {
                    _item = hit.transform;
                    _rb.isKinematic = true;
                    _itemIsGeted = true;
                    _item.SetParent(_itemPos);
                    _item.localPosition = Vector3.zero;
                    _item.localRotation = Quaternion.identity;
                    _dropItem.SetActive(true);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if(_itemIsGeted)
            {
                _item.SetParent(null);
                _itemIsGeted = false;
                _rb.useGravity = true;
                _rb.isKinematic = false;
                _rb.AddForce(_cameraTransform.forward * 500);
                _dropItem.SetActive(false);
            }
        }       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_cameraTransform.position, _cameraTransform.forward * _distanse);
    }


}
