using System.Collections;
using DG.Tweening;
using FlorisDeVToolsFSM.GameSetup;
using Sisus.Init;
using UnityEngine;

namespace FlorisDeVToolsFSM.UnityExtensions
{
    public class GameBehaviour : MonoBehaviour<IGameManagerSo>
    {
        protected IGameManagerSo gameManager;
        public bool IsPaused { get; private set; } = false;
        
        protected override void Init(IGameManagerSo gameManagerSo)
        {
            gameManager = gameManagerSo;
        }
        
        protected override void OnAwake()
        {
            base.OnAwake();
            
            StartCoroutine(SetupBetterMonoBehaviour());
        }
        
        private IEnumerator SetupBetterMonoBehaviour()
        {
            // Wait a frame so every Awake/Start/OnEnable method is called
            yield return new WaitForEndOfFrame();
            InitReferences();

            yield return new WaitForEndOfFrame();
            InitListeners();

            yield return new WaitForEndOfFrame();
            InitInvokers();
        }
        
        /// <summary>
        /// Used to initialize all references
        /// </summary>
        protected virtual void InitReferences()
        {
        }

        /// <summary>
        /// Used to initialize all listeners
        /// </summary>
        protected virtual void InitListeners()
        {
            gameManager.RegisterOnGameStateChanged(OnGameStateChanged);
        }

        /// <summary>
        /// Used to setup internal state, which impacts other classes.
        /// i.e. Invokes of events
        /// </summary>
        protected virtual void InitInvokers()
        {
        }

        protected virtual void OnDisable()
        {
            transform.DORewind();
            transform.DOKill();
            gameManager.RegisterOnGameStateChanged(OnGameStateChanged);
        }

        protected virtual void OnGameStateChanged()
        {
            IsPaused = gameManager.IsGamePaused;
        }
    }
}
