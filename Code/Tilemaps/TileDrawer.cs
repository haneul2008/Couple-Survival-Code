using System;
using _00.Works.HN.Code.EventSystems;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace _00.Works.HN.Code.Tilemaps
{
    public class TileDrawer : MonoBehaviour
    {
        [SerializeField] private Camera targetCam;
        [SerializeField] private TileBase gridTile;
        [SerializeField] private int drawX;
        [SerializeField] private int drawY;

        private Vector3Int _beforeCamPos;
        private Tilemap _tilemap;

        private void Awake()
        {
            _tilemap = GetComponent<Tilemap>();
        }

        private void Update()
        {
            Transform cameraTrm = targetCam.transform;
            Vector3Int camPos = new Vector3Int(GetCeilValue(cameraTrm.position.x), GetCeilValue(cameraTrm.position.y), 0);
            
            if(_beforeCamPos == camPos) return;
            
            for (int i = -drawX; i <= drawX; i++)
            {
                for (int j = -drawY; j <= drawY; j++)
                {
                    if (!_tilemap.HasTile(new Vector3Int(camPos.x + i, camPos.y + j, 0)))
                    {
                        _tilemap.SetTile(new Vector3Int(camPos.x + i, camPos.y + j, 0), gridTile);
                    }
                }
            }

            _beforeCamPos = camPos;
        }
        
        private int GetCeilValue(float value)
        {
            return Mathf.CeilToInt(value);
        }
    }
}