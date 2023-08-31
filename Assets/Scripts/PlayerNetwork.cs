using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerNetwork : NetworkBehaviour
{
    struct PlayerNetworkData : INetworkSerializable
    {
        private short _x, _y;
        private short _xScale;

        internal Vector3 Position
        {
            get => new Vector3(_x, _y, 0);
            set
            {
                _x = (short)value.x;
                _y = (short)value.y;
            }
        }

        internal Vector3 Scale
        {
            get => new Vector3(_xScale, 1, 1);
            set
            {
                _xScale = (short)value.x;
            }
        }

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _x);
            serializer.SerializeValue(ref _y);
            serializer.SerializeValue(ref _xScale);
        }
    }

    private NetworkVariable<PlayerNetworkData> _netState = new NetworkVariable<PlayerNetworkData>(writePerm: NetworkVariableWritePermission.Owner);
    private Vector3 _vel;
    [SerializeField] private float _cheapInterpolationTime = 0.1f;

    void Update()
    {
        if (IsOwner)
        {
            _netState.Value = new PlayerNetworkData()
            {
                Position = transform.position,
                Scale = transform.localScale
            };
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, _netState.Value.Position, ref _vel, _cheapInterpolationTime);
            transform.localScale = _netState.Value.Scale;
        }
    }


}
