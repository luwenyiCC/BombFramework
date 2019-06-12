

namespace HotFix_Project.Kernel
{
    public interface IEntiry
    {
        IComponent AddComponent(IComponent component);

        K AddComponent<K>() where K : IComponent, new();
        K GetComponent<K>() where K : IComponent;

    }
}
