namespace FramePush.BackStack
{
    public interface IBackStackable
    {
        /// <summary>
        /// Called when back or escape pressed. Should perform cleanup.
        /// </summary>
        void Dismiss();
        
        /// <summary>
        /// Re-initialize when coming back from another item.
        /// </summary>
        void GoBackTo();
    }
}