namespace FramePush.BackStack
{
    public interface IBackStackable
    {
        void Dismiss();
        void GoBackTo();
    }
}