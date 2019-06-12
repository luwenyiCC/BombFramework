


namespace HotFix_Project.Kernel
{
    public abstract class Component : IComponent
    {
        object parent;

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public object GetParent()
        {
            return parent;
        }

        public void SetParent(object obj)
        {
            parent = obj;
        }
    }
}
