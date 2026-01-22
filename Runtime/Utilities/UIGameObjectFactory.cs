using UnityEngine;

namespace Rehawk.UIFramework
{
    public delegate GameObject CreateDelegate(GameObject prefab, Transform parent);
    public delegate void DestroyDelegate(GameObject gameObject);

    /// <summary>
    /// Provides a framework to facilitate the creation and destruction of GameObjects for UI purposes.
    /// </summary>
    public static class UIGameObjectFactory
    {
        private static CreateDelegate createAction;
        private static DestroyDelegate destroyAction;

        /// <summary>
        /// Configures the factory with the specified creation and destruction logic for managing GameObjects.
        /// </summary>
        /// <param name="createAction">The delegate method used for creating GameObjects.</param>
        /// <param name="destroyAction">The delegate method used for destroying GameObjects.</param>
        public static void Setup(CreateDelegate createAction, DestroyDelegate destroyAction)
        {
            UIGameObjectFactory.createAction = createAction;
            UIGameObjectFactory.destroyAction = destroyAction;
        }

        internal static GameObject Get(GameObject prefab, Transform parent)
        {
            return createAction.Invoke(prefab, parent);
        }
        
        internal static void Return(GameObject gameObject)
        {
            destroyAction.Invoke(gameObject);
        }
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void OnSubsystemRegistration()
        {
            Setup(Object.Instantiate, Object.Destroy);
        }
    }
}